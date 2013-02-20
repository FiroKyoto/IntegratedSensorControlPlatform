namespace SickLidar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;

    /// <summary>
    /// We must be logged in before we are allowed to send parametrisation commands.
    /// Request for a data telegram can be done without login.
    /// 
    /// Workflow to parametrize the scan
    /// 1. Log in: sMN SetAccessMode
    /// 2. Set Frequency and Resolution: sMN mLMPsetscancfg
    /// 3. Configure scandata content: sWN LMDscandatacfg
    /// 4. Configure scandata output: sWN LMPoutputRange
    /// 5. Store parameters: sMN mEEwriteall
    /// 6. Log out: sMN Run
    /// 7. Request Scan: sRN LMDscandata / sEN LMDscandata
    /// </summary>
    public class SickLidar
    {
        #region fields

        /// <summary>
        /// For networking
        /// </summary>
        private Socket socket;

        /// <summary>
        /// LMS111 = 0, LMS511 = 1
        /// </summary>
        private int selectDevice;

        /// <summary>
        /// gets or sets of telegram command of laser range finder
        /// </summary>
        private string cmd { get; set; }

        /// <summary>
        /// Start of telegram command
        /// </summary>
        private char STX;

        /// <summary>
        /// End of telegram command
        /// </summary>
        private char ETX;

        /// <summary>
        /// Data buffer for incoming data
        /// </summary>
        private byte[] recData;

        /// <summary>
        /// initialization of variable
        /// </summary>
        public bool isInitializeVal;

        /// <summary>
        /// initialize of list<T>
        /// </summary>
        public bool isInitializeList;

        /// <summary>
        /// Convert received message to string
        /// </summary>
        public string resultStr { get; set; }

        /// <summary>
        /// Output format: 1/10,000'
        /// </summary>
        public double startAngle { get; set; }

        /// <summary>
        /// Output format : 1/10,000'
        /// </summary>
        public double steps { get; set; }

        /// <summary>
        /// scaling factor of laser sensor
        /// </summary>
        public double scalingFactor { get; set; }

        /// <summary>
        /// Defines the number of items on measured output
        /// </summary>
        public int dataLength { get; set; }

        /// <summary>
        /// piBy180 = Math.Pi / 180
        /// </summary>
        public double piBy180 { get; set; }

        /// <summary>
        /// List of measured data (mm)
        /// </summary>
        public List<int> orgList;

        /// <summary>
        /// List of polar coordinate system - row, theta
        /// </summary>
        public List<PolarPoint> polarList;

        /// <summary>
        /// List of Cartesian coordinates system - x, y
        /// </summary>
        public List<CartesianPoint> cartesianList;

        /// <summary>
        /// gets or sets debug message
        /// </summary>
        public string debugMsg { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// constructor - real time mode
        /// </summary>
        public SickLidar(string _host, int _port, int _selectDevice, double _scalingFactor, bool _configureMode)
        {
            this.STX = (char)2;
            this.ETX = (char)3;
            this.recData = new byte[4098];
            this.isInitializeVal = false;
            this.isInitializeList = false;
            this.selectDevice = _selectDevice;
            this.scalingFactor = _scalingFactor;
            this.piBy180 = Math.PI / 180;

            IPAddress address = IPAddress.Parse(_host);
            IPEndPoint ipe = new IPEndPoint(address, _port);
            this.socket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.socket.Connect(ipe);

            if (this.socket.Connected == true)
            {
                if (_configureMode == true)
                {
                    this.LogIn();
                    this.SetFrequencyAndResolution();
                    this.ConfigureTheDataContentForTheScan();
                }

                this.debugMsg = "Socket is connected";
            }
            else
            {
                //--error message--//
                this.debugMsg = "Socket is not connected";
            }

        }

        /// <summary>
        /// constructor - read file mode (txt file)
        /// </summary>
        /// <param name="_selectDevice"></param>
        /// <param name="_scalingFactor"></param>
        public SickLidar(int _selectDevice, double _scalingFactor)
        {
            this.isInitializeList = false;
            this.selectDevice = _selectDevice;
            this.scalingFactor = _scalingFactor;
            this.piBy180 = Math.PI / 180;
            this.startAngle = (double)450000 / 10000;

            this.steps = (double)2500 / 10000;
            this.dataLength = 361;                
        }

        #endregion

        #region methods

        /// <summary>
        /// Send telegram data to the SICK LRF
        /// </summary>
        /// <param name="cmd"></param>
        private void SendDatatoLms(string cmd)
        {
            //--send the data through the socket--//
            byte[] telegram = Encoding.Default.GetBytes(cmd);
            int byteSent = this.socket.Send(telegram);
        }

        /// <summary>
        /// Receive the response from the SICK LMS
        /// </summary>
        private void ReceiveDataFromLms()
        {
            int byteReceive = this.socket.Receive(this.recData);
            this.resultStr = Encoding.ASCII.GetString(this.recData, 0, byteReceive);
        }

        /// <summary>
        /// 1.Type of command: Request (SOPAS method by name)
        /// 2.Command  Select user level
        /// 3.User level: A valid user level must be included in the transmission. 
        ///   Otherwise the LMS declines the command.
        ///   Value: 02h - maintenance personnel, 03h - authorised client, 04h - service
        /// 4.Password E.g. encoded value for "client"
        ///   Value: 00000000h ... FFFFFFFFh
        /// </summary>
        private void LogIn()
        {
            //----------------------//
            //--For LMS111, LMS511--//
            //----------------------//

            //--<STX>sMN SetAccessMode 03 F4724744<ETX>--//
            this.cmd = this.STX + "sMN SetAccessMode 03 F4724744" + this.ETX;
            this.SendDatatoLms(this.cmd);

            //--For debug--//
            //--<STX>sAN Set AccessMode 1<ETX>--//
            this.ReceiveDataFromLms();
        }

        /// <summary>
        /// 0.Command set 
        ///   sMN{spc}mLMPsetscancfg{spc}+5000(50Hz){spc}+1(Reserved){spc}+5000(0.5'){spc}+0(0'){spc}1B7740(180')
        /// 3.ScanningFrequency: Information in 1/100 Hz, the transmitted value can be 25 Hz or 50 Hz.
        ///   Value: 25Hz - 2500, 50Hz - 5000
        /// 4.NumberSegments: For the LMS100 always 1
        /// 5.AngleResolution: Information in 1/10.000 degrees, the transmitted value can be 0.25' or 0.5'
        ///   Value: 0.25' - 2500, 0.5' - 5000
        /// 6.StartingAngle: Not currently possible, in future information in 1/10,000 degree
        ///   Value: –450,000 … +2,250,000
        /// 7.StoppingAngle: Not currently possible, in future information in 1/10,000 degree
        ///   Value: –450,000 … +2,250,000
        /// </summary>
        private void SetFrequencyAndResolution()
        {
            //--LMS111--//
            if (this.selectDevice == 0)
            {
                //--<STX>sMN mLMPsetscancfg +2500 +1 +5000 -450000 +2250000<ETX>--//
                this.cmd = this.STX + "sMN mLMPsetscancfg +2500 +1 +5000 -450000 +2250000" + this.ETX;
            }

            //--LMS511--//
            if (this.selectDevice == 1)
            {
                //--<STX>sMN mLMPsetscancfg +2500 +1 +2500 -50000 +1800000<ETX>--//
                this.cmd = this.STX + "sMN mLMPsetscancfg +2500 +1 +2500 -50000 +1800000" + this.ETX;
            }

            this.SendDatatoLms(this.cmd);

            //--For debug--//
            //--<STX>sAN mLMPsetscancfg 0 1388 1 1388 FFF92230 225510<ETX>--//
            this.ReceiveDataFromLms();
        }

        /// <summary>
        /// Telegram Structure : sWN LMDscandatacfg
        /// </summary>
        private void ConfigureTheDataContentForTheScan()
        {
            //----------------------//
            //--For LMS111, LMS511--//
            //----------------------//

            //--<STX>sWN LMDscandatacfg 01 00 0 1 0 00 00 0 0 0 0 +1<ETX>--//
            this.cmd = this.STX + "sWN LMDscandatacfg 01 00 0 1 0 00 00 0 0 0 0 +1" + this.ETX;

            this.SendDatatoLms(this.cmd);

            //--For debug--//
            //--<STX>sWA LMDscandatacfg<ETX>--//
            this.ReceiveDataFromLms();
        }

        /// <summary>
        /// Output of measured values of one scan
        /// Telegram Structure : sRN LMDscandata
        /// </summary>
        public void RequestScan()
        {
            //----------------------//
            //--For LMS111, LMS511--//
            //----------------------//

            //--<STX>sRN LMDscandata<ETX>--//
            this.cmd = this.STX + "sRN LMDscandata" + this.ETX;

            this.SendDatatoLms(this.cmd);
            this.ReceiveDataFromLms();
        }

        /// <summary>
        /// point of polar coordinates system
        /// </summary>
        public struct PolarPoint
        {
            public double row;
            public double theta;

            public PolarPoint(double _row, double _theta)
            {
                this.row = _row;
                this.theta = _theta;
            }
        }

        /// <summary>
        /// point of cartesian coordinates system
        /// </summary>
        public struct CartesianPoint
        {
            public double x;
            public double y;
            public double z;

            public CartesianPoint(double _x, double _y, double _z)
            {
                this.x = _x;
                this.y = _y;
                this.z = _z;
            }
        }

        /// <summary>
        /// Convert received data From Server
        /// </summary>
        /// <param name="data"></param>
        public void ConvertTcpDataToPolar(List<int> data)
        {
            if (this.isInitializeList == false)
            {
                this.orgList = new List<int>();
                this.polarList = new List<PolarPoint>();
                this.cartesianList = new List<CartesianPoint>();

                this.isInitializeList = true;
            }

            this.orgList.Clear();
            this.polarList.Clear();

            PolarPoint p;

            for (int i = 0; i < this.dataLength; i++)
            {
                //--rowLength value is (mm)--//
                int rowLength = Convert.ToInt32(data[i]);
                this.orgList.Add(rowLength);

                p.theta = ((this.steps * i) + (this.startAngle - 180.0)) * this.piBy180;
                //--convert mm to m--//
                p.row = (double)rowLength * this.scalingFactor / 1000;

                this.polarList.Add(p);
            }
        }

        /// <summary>
        /// Convert read data to polar coordinates system
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void ConvertReadDataToPolar(int index, string[] data)
        {
            string[] lineArr = data[index].Split(' ');

            if (this.isInitializeList == false)
            {
                this.orgList = new List<int>();
                this.polarList = new List<PolarPoint>();
                this.cartesianList = new List<CartesianPoint>();

                this.isInitializeList = true;
            }

            this.orgList.Clear();
            this.polarList.Clear();

            PolarPoint p;

            for (int i = 0; i < this.dataLength; i++)
            {
                //--rowLength value is (mm)--//
                int rowLength = Convert.ToInt32(lineArr[i]);
                this.orgList.Add(rowLength);

                p.theta = ((this.steps * i) + (this.startAngle - 180.0)) * this.piBy180;
                //--convert mm to m--//
                p.row = (double)rowLength * this.scalingFactor / 1000;

                this.polarList.Add(p);
            }

        }

        /// <summary>
        /// Hexadecimal to polar coordinate
        /// http://msdn.microsoft.com/en-us/library/bb311038.aspx
        /// </summary>
        public void ConvertHexToPolar()
        {
            string[] hexValuesSplit = this.resultStr.Split(' ');

            if (this.isInitializeVal == false)
            {
                //--degree of start point--//
                int angle = Convert.ToInt32(hexValuesSplit[23], 16);
                this.startAngle = (double)angle / 10000;

                //--resolution--//
                int resolution = Convert.ToInt32(hexValuesSplit[24], 16);
                this.steps = (double)resolution / 10000;

                //--length of result data--//
                this.dataLength = Convert.ToInt32(hexValuesSplit[25], 16);

                this.isInitializeVal = true;
            }

            if (this.isInitializeList == false)
            {
                this.orgList = new List<int>();
                this.polarList = new List<PolarPoint>();
                this.cartesianList = new List<CartesianPoint>();

                this.isInitializeList = true;
            }

            this.orgList.Clear();
            this.polarList.Clear();

            PolarPoint p;

            for (int i = 0; i < this.dataLength; i++)
            {
                //--rowLength value is j(mm)--//
                int rowLength = Convert.ToInt32(hexValuesSplit[26 + i], 16);
                this.orgList.Add(rowLength);

                p.theta = ((this.steps * i) + (this.startAngle - 180.0)) * this.piBy180;
                
                //--convert mm to m--//
                p.row = (double)rowLength * this.scalingFactor / 1000;

                this.polarList.Add(p);
            }
        }


        /// <summary>
        /// convert polar coordinate system to cartesian coordinate system
        /// x = r*cos(theta), y=r*sin(theta)*cos(tilt angle of camera)
        /// </summary>
        public void ConvertPolarToCartesian()
        {
            this.cartesianList.Clear();
            CartesianPoint c;
            double x = 0;
            double y = 0;
            double z = 0;

            for (int i = 0; i < this.polarList.Count; i++)
            {
                //--LMS111--//
                if (this.selectDevice == 0)
                {
                    int index = this.polarList.Count - 1 - i;
                    
                    //--height = 2.47m, tilt angle = 49.284--//
                    x = -(this.polarList[index].row * Math.Sin(this.polarList[index].theta) * Math.Sin(49.284 * this.piBy180));
                    y = this.polarList[i].row * Math.Cos(this.polarList[i].theta);
                    z = 2.47 + (this.polarList[index].row * Math.Sin(this.polarList[index].theta) * Math.Cos(49.284 * this.piBy180));
                }

                //--LMS511--//
                if (this.selectDevice == 1)
                {
                    //--height = 2.257m, tilt angle = 35--//
                    x = -(this.polarList[i].row * Math.Sin(this.polarList[i].theta) * Math.Sin(35 * this.piBy180));
                    y = this.polarList[i].row * Math.Cos(this.polarList[i].theta);
                    z = 2.257 + (this.polarList[i].row * Math.Sin(this.polarList[i].theta) * Math.Cos(35 * this.piBy180));
                }

                c.x = x;
                c.y = y;
                c.z = z;

                this.cartesianList.Add(c);
            }
        }

        /// <summary>
        /// disconnect socket
        /// </summary>
        public void DisconnectSocket()
        {
            this.socket.Close();
        }

        #endregion
    }
}
