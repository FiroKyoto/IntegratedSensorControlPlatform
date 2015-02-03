using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SickLidar
{
    /// <summary>
    /// Reference
    /// [1] All command is written using SCIP2.0 by Hokuyo.
    /// http://www.hokuyo-aut.jp/02sensor/07scanner/download/pdf/URG_SCIP20.pdf
    /// [2] Sensor command - All the characters in the Command and Reply are ASCII code.
    /// </summary>
    public class Panasonic
    {
        #region Struct

        public struct pt3
        {
            public double x;
            public double y;
            public double z;

            public pt3(double _x, double _y, double _z)
            {
                this.x = _x;
                this.y = _y;
                this.z = _z;
            }
        }

        public struct parameter
        {
            public int interval;
            public int scan_count;
            public int cur_count;
            public double theta1;
            public double theta2;
            public double angular_step;
            public int amin;
            public int amax;

            public parameter(int _interval, int _scan_count, int _cur_count, double _theta1, double _theta2, double _angular_step, int _amin, int _amax)
            {
                this.interval = _interval;
                this.scan_count = _scan_count;
                this.cur_count = _cur_count;
                this.theta1 = _theta1;
                this.theta2 = _theta2;
                this.angular_step = _angular_step;
                this.amin = _amin;
                this.amax = _amax;
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// The main control for communicating through the RS-232 port
        /// </summary>
        private SerialPort _serialPort;

        /// <summary>
        /// 0 = none
        /// 1 = read
        /// 2 = save
        /// </summary>
        public int file_mode { get; set; }

        public int sensor_count { get; set; }
        public bool isPort { get; set; }
        public long time_stamp { get; set; }
        public string echo_command { get; set; }
        private double get_theta2 { get; set; }

        public List<long> decode_data;
        public List<pt3> point_cloud;
        public List<string> save_data;
        public parameter set_parameter;

        public string current_time { get; set; }
        public double elapsed_time { get; set; }
        public long before_timer { get; set; }
        public double timer_time { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public Panasonic() 
        {
            this.decode_data = new List<long>();
            this.decode_data.Clear();
            this.point_cloud = new List<pt3>();
            this.point_cloud.Clear();
            this.save_data = new List<string>();
            this.file_mode = 0;
            this.sensor_count = 0;
            this.set_parameter = new parameter();
        }
        
        #endregion

        #region Serial Communication

        /// <summary>
        /// Open method
        /// </summary>
        /// <param name="_portName"></param>
        /// <param name="_baudRate"></param>
        /// <param name="_dataBits"></param>
        /// <returns></returns>
        public string Open(string _portName, int _baudRate, int _dataBits)
        {
            string message = null;

            // Create a New SerialPort object with default settings.
            this._serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            this._serialPort.PortName = _portName;
            this._serialPort.BaudRate = _baudRate;
            this._serialPort.DataBits = _dataBits;
            this._serialPort.Parity = Parity.None;
            this._serialPort.StopBits = StopBits.One;

            try
            {
                this._serialPort.Open();
                message = this._serialPort.PortName + " Port open is success.";
                this.isPort = true;
            }
            catch 
            {
                message = this._serialPort.PortName + " Port open is fail.";
                this.isPort = this._serialPort.IsOpen;
            }

            return message;
        }

        /// <summary>
        /// Close method
        /// </summary>
        /// <returns></returns>
        public string Close()
        {
            string message = null;

            if (this._serialPort.IsOpen == true)
            {
                this._serialPort.Close();
                message = this._serialPort.PortName + " port is closed";
                this.isPort = false;
            }
            else
            {
                message = "Port is not open";
            }

            return message;
        }

        /// <summary>
        /// Set parameter
        /// </summary>
        /// <param name="_mode"></param>
        private void SetParameter(int _mode)
        {
            int select_mode = _mode + 1;
            this.set_parameter.interval = 50;
            this.set_parameter.cur_count = 0;

            switch (select_mode)
            {
                case 1:
                    this.set_parameter.scan_count = 1;
                    this.set_parameter.theta1 = (90.0 + 47.5) * Math.PI / 180.0;
                    this.set_parameter.theta2 = 0.0;
                    this.set_parameter.angular_step = -(0.25 * Math.PI / 180.0);
                    break;

                case 2:
                    this.set_parameter.scan_count = 2;
                    this.set_parameter.theta1 = (90.0 + 47.5) * Math.PI / 180.0;
                    this.set_parameter.theta2 = 2.5;
                    this.set_parameter.angular_step = -(0.25 * Math.PI / 180.0);
                    break;

                case 3:
                    this.set_parameter.scan_count = 2;
                    this.set_parameter.theta1 = (90.0 + 47.5) * Math.PI / 180.0;
                    this.set_parameter.theta2 = 5.0;
                    this.set_parameter.angular_step = -(0.25 * Math.PI / 180.0);
                    break;

                case 4:
                    this.set_parameter.scan_count = 2;
                    this.set_parameter.theta1 = (90.0 + 47.5) * Math.PI / 180.0;
                    this.set_parameter.theta2 = 10.0;
                    this.set_parameter.angular_step = -(0.25 * Math.PI / 180.0);
                    break;

                case 5:
                    this.set_parameter.interval = 25;
                    this.set_parameter.scan_count = 11;
                    break;

                case 6:
                    this.set_parameter.interval = 25;
                    this.set_parameter.scan_count = 11;
                    break;

                case 7:
                    this.set_parameter.interval = 25;
                    this.set_parameter.scan_count = 11;
                    break;
            }
        }

        #endregion

        #region Send command(Host->Sensor) based SCIP2.0
        
        /// <summary>
        /// Sensor transmits version details such as, 
        /// serial number, firmware version etc on receiving this command.
        /// </summary>
        public List<string> VV()
        {
            List<string> echo_data = new List<string>();
            string command = "VV\r\n";
            this._serialPort.Write(command);

            for (int i = 0; i < 8; i++)
            {
                echo_data.Add(this._serialPort.ReadLine());
            }

            return echo_data;
        }

        /// <summary>
        /// Sensor transmits its specifications on receiving this command.
        /// </summary>
        /// <returns></returns>
        public List<string> PP()
        {
            List<string> echo_data = new List<string>();
            string command = "PP\r\n";
            this._serialPort.Write(command);

            for (int i = 0; i < 11; i++)
            {
                echo_data.Add(this._serialPort.ReadLine());
            }

            this.set_parameter.amin = this.StepCountFromPP(echo_data[6]);
            this.set_parameter.amax = this.StepCountFromPP(echo_data[7]);

            return echo_data;
        }

        /// <summary>
        /// Calculate Step Count(AMIN, AMAX) using PP command
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        private int StepCountFromPP(string _data)
        {
            string[] split_data1 = _data.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] split_data2 = split_data1[1].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            int val;
            if(int.TryParse(split_data2[0], out val) == false)
            {
                val = -9999;
            }

            return val;
        }


        /// <summary>
        /// This command will illuminate the sensor’s laser enabling the measurement.
        /// num     scan mode       tilt line       tilt angle      command
        /// [1]     single mode     1               none            BM;SS00
        /// [2]     dual mode       2               5               BM;SD05
        /// [3]     dual mode       2               10              BM;SD10
        /// [4]     dual mode       2               20              BM;SD20
        /// [5]     multi mode      11              5               BM;SM05
        /// [6]     multi mode      11              10              BM;SM10
        /// [7]     multi mode      11              20              BM;SM20
        /// </summary>
        /// <param name="_mode">selected scan mode</param>
        /// <returns></returns>
        public List<string> BM(int _mode)
        {
            // set parameter
            this.SetParameter(_mode);

            List<string> echo_data = new List<string>();
            string command = null;
            int select_mode = _mode + 1;
            switch (select_mode)
            {
                case 1:
                    command = "BM;SS00\r\n";
                    break;

                case 2:
                    command = "BM;SD05\r\n";
                    break;

                case 3:
                    command = "BM;SD10\r\n";
                    break;

                case 4:
                    command = "BM;SD20\r\n";
                    break;

                case 5:
                    command = "BM;SM05\r\n";
                    break;

                case 6:
                    command = "BM;SM10\r\n";
                    break;

                case 7:
                    command = "BM;SM20\r\n";
                    break;
            }
            this._serialPort.Write(command);
            for (int i = 0; i < 3; i++)
            {
                echo_data.Add(this._serialPort.ReadLine());
            }

            return echo_data;
        }

        /// <summary>
        /// This is a sensor data acquisition command.
        /// -----------------------------------------------------------------
        /// command format
        /// GD + start step(4byte) + end step(4byte) + operation(1byte) + CR + LF
        /// 
        /// operation mode -> 
        /// 'A' = ready
        /// '1' = scan
        /// 'B' = finish 
        /// -----------------------------------------------------------------
        /// </summary>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <param name="_opt"></param>
        /// <returns></returns>
        public List<string> GD(int _start, int _end, char _opt)
        {
            List<string> echo_data = new List<string>();

            if (this._serialPort.IsOpen == true)
            {
                string command = "GD" + _start.ToString("D4") + _end.ToString("D4") + _opt + "\r\n";
                this._serialPort.Write(command);
                int count = this.CalculateEchoDataCount(_opt);

                if ((_opt == 'A') || (_opt == 'B'))
                {
                    for (int i = 0; i < count; i++)
                    {
                        echo_data.Add(this._serialPort.ReadLine());
                    }
                }
                else
                {
                    // Obtain the number of bytes waiting in the port's buffer
                    int bytes = this._serialPort.BytesToRead;

                    // Create a byte array buffer to hold the incoming data
                    byte[] buffer = new byte[bytes];

                    // Read the data from the port and store it in our buffer
                    this._serialPort.Read(buffer, 0, bytes);

                    string data_ascii = System.Text.Encoding.ASCII.GetString(buffer);
                    string[] split_command = data_ascii.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < split_command.Length; i++)
                    {
                        echo_data.Add(split_command[i]);
                    }
                }
            }

            return echo_data;
        }

        /// <summary>
        /// Calculate Echo Data Count
        /// </summary>
        /// <param name="_opt"></param>
        /// <returns></returns>
        private int CalculateEchoDataCount(char _opt)
        {
            int count = 0;

            switch (_opt)
            {
                case 'A':
                    count = 2;
                    break;

                case 'B':
                    count = 3;
                    break;

                case '1':
                    count = 22;
                    break;
            }

            return count;
        }

        /// <summary>
        /// This command will switch off the laser disabling sensor’s measurement state.
        /// </summary>
        /// <returns></returns>
        public List<string> QT()
        {
            List<string> echo_data = new List<string>();
            string command = "QT\n";
            this._serialPort.Write(command);
            for (int i = 0; i < 3; i++)
            {
                echo_data.Add(this._serialPort.ReadLine());
            }

            return echo_data;
        }

        #endregion

        #region Decode received data from sensor

        /// <summary>
        /// Decode received data from sensor
        /// ---------------------------------
        /// Encoded data format
        /// [0] -> feedback send command
        /// [1] -> status(2byte) + sum(1byte)
        /// [2] -> time stamp(4byte) + sum(1byte)
        /// [3...n] -> data block
        /// ---------------------------------
        /// </summary>
        /// <param name="_echo_data"></param>
        /// <returns></returns>
        public string Decode(List<string> _echo_data)
        {
            string message = null;

            if (_echo_data.Count != 0)
            {
                if ((_echo_data[0].StartsWith("GD") == true) && (_echo_data[1].StartsWith("00") == true))
                {
                    this.echo_command = _echo_data[0];
                    this.time_stamp = this.DecodePartOfString(_echo_data[2], 4);
                    this.DistanceData(_echo_data, 3);
                    message = "Received data format is is valid.";
                }
                else
                {
                    message = "Received data format is is invalid.";
                }
            }
            else
            {
                message = "Received data is null.";
            }

            return message;
        }

        /// <summary>
        /// Decode distance
        /// </summary>
        /// <param name="_echo_data"></param>
        private void DistanceData(List<string> _echo_data, int _start_line)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = _start_line; i < _echo_data.Count; ++i)
            {
                sb.Append(_echo_data[i].Substring(0, _echo_data[i].Length - 1));
            }

            this.DecodeArray(sb.ToString(), 3);
        }

        /// <summary>
        /// Decode array
        /// </summary>
        /// <param name="data"></param>
        /// <param name="size"></param>
        private void DecodeArray(string data, int size)
        {
            this.decode_data.Clear();

            // save mode
            if (this.file_mode == 2)
            {
                this.save_data.Clear();
                this.save_data.Add(this.sensor_count.ToString());
                this.save_data.Add(this.echo_command);
                this.save_data.Add(this.time_stamp.ToString());
            }

            for (int pos = 0; pos <= data.Length - size; pos += size)
            {
                long distance = this.DecodePartOfString(data, size, pos);
                this.decode_data.Add(distance);

                // save mode
                if(this.file_mode == 2)
                {
                    this.save_data.Add(distance.ToString());
                }
            }
        }

        /// <summary>
        /// Decode Part of string
        /// </summary>
        /// <param name="data"></param>
        /// <param name="size"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private long DecodePartOfString(string data, int size, int offset = 0)
        {
            long value = 0;

            for (int i = 0; i < size; ++i)
            {
                value <<= 6;
                value |= (long)data[offset + i] - 0x30;
            }

            return value;
        }

        #endregion

        #region Convert decoded data to 3D point cloud

        /// <summary>
        /// Decode data to 3d point cloud
        /// </summary>
        /// <returns></returns>
        public string DecodedDataToPointCloud()
        {
            string message = null;

            if (this.decode_data.Count != 0)
            {
                this.GetLineNumberOfSensor();
                this.point_cloud.Clear();
                double start_theta1 = this.set_parameter.theta1;
                double start_theta2 = this.get_theta2;

                for (int i = 0; i < this.decode_data.Count; i++)
                {
                    double current_theta1 = start_theta1 + (i * this.set_parameter.angular_step);
                    double current_theta2 = start_theta2;

                    double x = (double)this.decode_data[i] * Math.Cos(current_theta2) * Math.Cos(current_theta1) * 0.001;
                    double y = (double)this.decode_data[i] * Math.Cos(current_theta2) * Math.Sin(current_theta1) * 0.001;
                    double z = (double)this.decode_data[i] * Math.Sin(current_theta2) * 0.001;

                    this.point_cloud.Add(new pt3(x, y, z));
                }

                message = "Yes!Converted data.";
            }
            else
            {
                message = "Decoded data is null.";
            }

            return message;
        }

        /// <summary>
        /// Get line number of sensor
        /// </summary>
        private void GetLineNumberOfSensor()
        {
            // 1 line scan
            if (this.set_parameter.scan_count == 1)
            {
                this.set_parameter.cur_count = 0;
                this.get_theta2 = this.set_parameter.theta2 * (Math.PI / 180.0);
            }

            // 2 line scan
            if (this.set_parameter.scan_count == 2)
            {
                string amin_str = this.echo_command.Substring(2, 4);
                if (amin_str != null)
                {
                    int amin;
                    bool is_num = int.TryParse(amin_str, out amin);
                    if (is_num == true)
                    {
                        if (amin == this.CalculateStep(1))
                        {
                            this.set_parameter.cur_count = 0;
                            this.get_theta2 = this.set_parameter.theta2 * (Math.PI / 180.0);
                        }
                        else if(amin == this.CalculateStep(2))
                        {
                            this.set_parameter.cur_count = 1;
                            this.get_theta2 = -(this.set_parameter.theta2) * (Math.PI / 180.0);
                        }
                    }
                }
            }

            // 11 line scan
            if (this.set_parameter.scan_count == 11)
            {
                string amin_str = this.echo_command.Substring(2, 4);
                if (amin_str != null)
                {
                    int amin;
                    bool is_num = int.TryParse(amin_str, out amin);
                    if (is_num == true)
                    {
                        if (amin == this.CalculateStep(1))
                        {
                            this.set_parameter.cur_count = 0;
                        }
                        else if (amin == this.CalculateStep(2))
                        {
                            this.set_parameter.cur_count = 1;
                        }
                        else if (amin == this.CalculateStep(3))
                        {
                            this.set_parameter.cur_count = 2;
                        }
                        else if (amin == this.CalculateStep(4))
                        {
                            this.set_parameter.cur_count = 3;
                        }
                        else if (amin == this.CalculateStep(5))
                        {
                            this.set_parameter.cur_count = 4;
                        }
                        else if (amin == this.CalculateStep(6))
                        {
                            this.set_parameter.cur_count = 5;
                        }
                        else if (amin == this.CalculateStep(7))
                        {
                            this.set_parameter.cur_count = 6;
                        }
                        else if (amin == this.CalculateStep(8))
                        {
                            this.set_parameter.cur_count = 7;
                        }
                        else if (amin == this.CalculateStep(9))
                        {
                            this.set_parameter.cur_count = 8;
                        }
                        else if (amin == this.CalculateStep(10))
                        {
                            this.set_parameter.cur_count = 9;
                        }
                        else if (amin == this.CalculateStep(11))
                        {
                            this.set_parameter.cur_count = 10;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculate Step
        /// </summary>
        /// <param name="_line"></param>
        /// <returns></returns>
        private int CalculateStep(int _line)
        {
            return (_line - 1) * 380;
        }

        #endregion
    }
}
