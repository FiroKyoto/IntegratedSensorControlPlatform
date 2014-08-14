
namespace Communication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class File
    {
        #region struct 
        
        public struct CmdFromClient
        {
            public int flag;
            public int hst;
            public int steer;
            public int header;
            public int buzzer;
            public int red_lamp;

            public CmdFromClient(int _flag, int _hst, int _steer, int _header, int _buzzer, int _red_lamp)
            {
                this.flag = _flag;
                this.hst = _hst;
                this.steer = _steer;
                this.header = _header;
                this.buzzer = _buzzer;
                this.red_lamp = _red_lamp;
            }
        }

        #endregion

        #region constructor

        /// <summary>
        /// basic Constructor
        /// </summary>
        public File() 
        {
            this.lidarData = new List<int>();
            this.bodyData = new List<int>();
        }
        
        #endregion

        #region fields

        /// <summary>
        /// gets or sets send command to client
        /// </summary>
        public string sendCmdToClient { get; set; }

        /// <summary>
        /// gets or sets read count of lidar data
        /// </summary>
        public int lidarReadCount { get; set; }

        /// <summary>
        /// gets or sets read count of body data
        /// </summary>
        public int bodyReadCount { get; set; }

        /// <summary>
        /// lidar data
        /// </summary>
        public List<int> lidarData;

        /// <summary>
        /// body data
        /// </summary>
        public List<int> bodyData;

        public bool lidar_flag { get; set; }
        public bool body_flag { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Add to String
        /// </summary>
        /// <param name="_readCnt"></param>
        /// <param name="_data"></param>
        /// <returns></returns>
        public string AddToString(int _readCnt, List<int> _data)
        {
            string cmd = null;
            cmd = _readCnt + " ";

            for (int i = 0; i < _data.Count; i++)
            {
                if (i != _data.Count - 1)
                {
                    cmd += Convert.ToString(_data[i]) + " ";
                }
                else
                {
                    cmd += Convert.ToString(_data[i]);
                }
            }

            return cmd;
        }

        /// <summary>
        /// Devide wheel data received from the g27 and convert command for vy446.
        /// </summary>
        /// <param name="_wheel"></param>
        /// <param name="_flag"></param>
        /// <param name="_hst"></param>
        /// <param name="_steer"></param>
        /// <param name="_header"></param>
        /// <returns></returns>
        public CmdFromClient DivideWheelData(string _wheel, int _flag, int _hst, int _steer, int _header)
        {
            CmdFromClient cmd;
            cmd.flag = _flag;
            cmd.hst = _hst;
            cmd.steer = _steer;
            cmd.header = _header;
            cmd.buzzer = 0;
            cmd.red_lamp = 0;

            if (_wheel != null)
            {
                string[] lineArr = _wheel.Split(' ');

                if (Convert.ToInt32(lineArr[6]) == 128)
                {
                    if (_flag == 0)
                    {
                        cmd.flag = 1;
                    }
                    else
                    {
                        cmd.flag = 0;
                    }
                }
                else
                {
                    cmd.flag = _flag;
                }

                if (cmd.flag == 1)
                {
                    // HST
                    if ((Convert.ToInt32(lineArr[4]) == 0) && (Convert.ToInt32(lineArr[5]) == 0))
                    {
                        cmd.hst = 1405;
                    }
                    else if ((Convert.ToInt32(lineArr[4]) == 128) && (Convert.ToInt32(lineArr[5]) == 128))
                    {
                        cmd.hst = 1405;
                    }
                    else if (Convert.ToInt32(lineArr[4]) == 128)
                    {
                        // forward travel
                        cmd.hst = 1700;
                    }
                    else if (Convert.ToInt32(lineArr[5]) == 128)
                    {
                        // backward travel
                        cmd.hst = 1100;
                    }

                    // Header
                    if ((Convert.ToInt32(lineArr[7]) == 0) && (Convert.ToInt32(lineArr[22]) == 0))
                    {
                        cmd.header = _header;
                    }
                    else if ((Convert.ToInt32(lineArr[7]) == 128) && (Convert.ToInt32(lineArr[22]) == 128))
                    {
                        cmd.header = _header;
                    }
                    else if (Convert.ToInt32(lineArr[7]) == 128)
                    {
                        // Header-UP (up to 680)
                        if (cmd.header > 670)
                        {
                            cmd.header = 680;
                        }
                        else
                        {
                            cmd.header = _header + 10;
                        }
                    }
                    else if (Convert.ToInt32(lineArr[22]) == 128)
                    {
                        // Header-Down (down to 330)
                        if (cmd.header < 340)
                        {
                            cmd.header = 330;
                        }
                        else
                        {
                            cmd.header = _header - 10;
                        }
                    }

                    // steer
                    cmd.steer = Convert.ToInt32(Convert.ToDouble(lineArr[23]) / 182.0) + 250;

                    // buzzer
                    if (Convert.ToDouble(lineArr[19]) == 128)
                    {
                        cmd.buzzer = 1;
                    }

                    // red lamp
                    if (Convert.ToDouble(lineArr[21]) == 128)
                    {
                        cmd.red_lamp = 1;
                    }
                }
            }

            return cmd;
        }

        /// <summary>
        /// Divide command data received from client
        /// </summary>
        /// <param name="_receivedData"></param>
        /// <returns></returns>
        public CmdFromClient DivideCmdDataReceivedFromClient(string _receivedData)
        {
            CmdFromClient cmd;
            cmd.flag = 0;
            cmd.hst = 1405;
            cmd.steer = 430;
            cmd.header = 420;
            cmd.buzzer = 0;
            cmd.red_lamp = 0;

            if (_receivedData != null)
            {
                string[] lineArr = _receivedData.Split(' ');
                cmd.flag = Convert.ToInt32(lineArr[0]);
                cmd.hst = Convert.ToInt32(lineArr[1]);
                cmd.steer = Convert.ToInt32(lineArr[2]);
                cmd.header = Convert.ToInt32(lineArr[3]);
                cmd.buzzer = Convert.ToInt32(lineArr[4]);
                cmd.red_lamp = Convert.ToInt32(lineArr[5]);
            }

            return cmd;
        }

        /// <summary>
        /// Divide string data
        /// </summary>
        /// <param name="_receivedData"></param>
        public void DivideStringData(string _receivedData, int _lidarLength, int _bodyDevice)
        {
            this.lidarData.Clear();
            this.bodyData.Clear();

            this.lidar_flag = false;
            this.body_flag = false;

            if (_receivedData != null)
            {
                string[] lineArr = _receivedData.Split(' ');

                // CheckSum
                if ((lineArr[0] == "<SOF>") && (lineArr[lineArr.Length - 1] == "<EOF>"))
                {
                    // LRF
                    if (Convert.ToInt32(lineArr[1]) == 1)
                    {
                        this.lidar_flag = true;

                        if (lineArr.Length > _lidarLength + 1)
                        {
                            this.lidarReadCount = Convert.ToInt32(lineArr[3]);

                            for (int i = 0; i < _lidarLength; i++)
                            {
                                this.lidarData.Add(Convert.ToInt32(lineArr[i + 4]));
                            }
                        } 
                    }

                    // Body
                    if (Convert.ToInt32(lineArr[2]) == 1)
                    {
                        this.body_flag = true;
                    }

                    // vy50
                    if (_bodyDevice == 0)
                    {
                        this.AddToBodyData(82, lineArr, this.lidar_flag, this.body_flag);
                    }

                    // vy446
                    if (_bodyDevice == 1)
                    {
                        this.AddToBodyData(142, lineArr, this.lidar_flag, this.body_flag);
                    }
                }
            }
            else
            { 
            }
        }

        /// <summary>
        /// Add To Body Data
        /// </summary>
        /// <param name="_dataLength"></param>
        /// <param name="lineArr"></param>
        /// <param name="_lidar_flag"></param>
        /// <param name="_body_flag"></param>
        private void AddToBodyData(int _dataLength, string[] lineArr, bool _lidar_flag, bool _body_flag)
        {
            int index = 0;
            if (_lidar_flag == true)
            {
                index = 365;
            }
            else
            {
                index = 4;
            }

            if (_body_flag == true)
            {
                if (lineArr.Length - index == _dataLength + 2)
                {
                    this.bodyReadCount = Convert.ToInt32(lineArr[index]);

                    int chkSum = Convert.ToInt32(lineArr[index + 1]);

                    if (chkSum == 205)
                    {
                        for (int i = index + 1; i < index + 1 + _dataLength; i++)
                        {
                            this.bodyData.Add(Convert.ToInt32(lineArr[i]));
                        }
                    }
                }
            }
            else
            { }
        }

        #endregion
    }
}
