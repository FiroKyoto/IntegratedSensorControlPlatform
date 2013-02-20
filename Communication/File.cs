
namespace Communication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class File
    {
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
        /// Divide string data
        /// </summary>
        /// <param name="_receivedData"></param>
        public void DivideStringData(string _receivedData, int _lidarLength, int _bodyDevice)
        {
            this.lidarData.Clear();
            this.bodyData.Clear();

            if (_receivedData != null)
            {
                string[] lineArr = _receivedData.Split(' ');

                // laser range finder
                if (lineArr.Length > _lidarLength + 1)
                {
                    this.lidarReadCount = Convert.ToInt32(lineArr[0]);

                    for (int i = 0; i < _lidarLength; i++)
                    {
                        this.lidarData.Add(Convert.ToInt32(lineArr[i + 1]));
                    }
                }

                // vy50
                if (_bodyDevice == 0)
                {
                    this.AddToBodyData(82, lineArr);
                }

                // vy446
                if (_bodyDevice == 1)
                {
                    this.AddToBodyData(142, lineArr);
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
        private void AddToBodyData(int _dataLength, string[] lineArr)
        {
            if (lineArr.Length - 362 == _dataLength + 1)
            {
                this.bodyReadCount = Convert.ToInt32(lineArr[362]);

                int chkSum = Convert.ToInt32(lineArr[363]);

                if (chkSum == 205)
                {
                    for (int i = 363; i < 363 + _dataLength; i++)
                    {
                        this.bodyData.Add(Convert.ToInt32(lineArr[i]));
                    }
                }
            }
        }

        #endregion
    }
}
