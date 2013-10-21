using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UrgCtrl;

namespace SickLidar
{
    public class Hokuyo
    {
        #region Fields
        
        /// <summary>
        /// hokuyo lidar sensor library
        /// </summary>
        private UrgCtrl.UrgCtrl _hokuyo;

        /// <summary>
        /// gets or sets is connected sensor
        /// </summary>
        public bool is_connected_sensor { get; set; }

        /// <summary>
        /// original data received from hokuyo lidar
        /// </summary>
        public int[] org_data;

        /// <summary>
        /// add original data to list
        /// </summary>
        public List<int> org_list_data;

        /// <summary>
        /// Convert original data to cartesian data
        /// </summary>
        public List<CartesianXY> cartesian_data;

        ///// <summary>
        ///// save hokuyo information data to txt file
        ///// </summary>
        //private StreamWriter save_data_to_txt;

        ///// <summary>
        ///// initialization of save data file
        ///// </summary>
        //private bool ini_save_data = false;

        /// <summary>
        /// initialization of read data file
        /// </summary>
        private bool ini_read_data = false;

        /// <summary>
        /// gets or sets read max buffer size
        /// </summary>
        private int read_max_buffer_size { get; set; }

        /// <summary>
        /// index to radian 
        /// </summary>
        private List<double> read_index_to_radian;

        /// <summary>
        /// cartesian xy
        /// </summary>
        public struct CartesianXY
        {
            public double x;
            public double y;

            public CartesianXY(double _x, double _y)
            {
                this.x = _x;
                this.y = _y;
            }
        }
        
        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public Hokuyo()
        {
            this._hokuyo = new UrgCtrl.UrgCtrl();
            this.cartesian_data = new List<CartesianXY>();
        }

        /// <summary>
        /// constructor
        /// </summary>
        public Hokuyo(int _com_port_number, int _baudrate)
        {
            this._hokuyo = new UrgCtrl.UrgCtrl();
            this.is_connected_sensor = this._hokuyo.Connect(_com_port_number, _baudrate);
            this.org_data = new int[this._hokuyo.MaxBufferSize];
            this.cartesian_data = new List<CartesianXY>();
            this.org_list_data = new List<int>();
            
            //// for debug
            //this.save_data_to_txt = new StreamWriter("hokuyo_info.txt");
        }

        #endregion

        #region Methods

        /// <summary>
        /// received data from sensor
        /// </summary>
        public void ReceivedData()
        {
            this.org_data.Initialize();
            this.cartesian_data.Clear();
            this.org_list_data.Clear();

            //capture data
            this._hokuyo.Capture(this.org_data);

            //if (this.ini_save_data == false)
            //{
            //    string max_buffer_size = Convert.ToString(this._hokuyo.MaxBufferSize);
            //    this.save_data_to_txt.WriteLine(max_buffer_size);

            //    string radian2Index = null;
            //    for (int i = 0; i < this._hokuyo.MaxBufferSize; i++)
            //    {
            //        if (i == (this._hokuyo.MaxBufferSize - 1))
            //        {
            //            radian2Index += Convert.ToString(this._hokuyo.Index2Radian(i));
            //        }
            //        else
            //        {
            //            radian2Index += Convert.ToString(this._hokuyo.Index2Radian(i)) + " ";
            //        }
            //    }
            //    this.save_data_to_txt.WriteLine(radian2Index);
            //    this.save_data_to_txt.Close();

            //    this.ini_save_data = true;
            //}

            //calculate point
            CartesianXY point;
            for (int i = 0; i < this._hokuyo.MaxBufferSize; i++)
            {
                //point = calculate_point((this.org_data[i] / 10), (this._hokuyo.Index2Radian(i + 44) * 180.0 / Math.PI));
                point = calculate_point((this.org_data[i]), (this._hokuyo.Index2Radian(i) * 180.0 / Math.PI));
                this.cartesian_data.Add(point);
                this.org_list_data.Add(this.org_data[i]);
            }
        }

        /// <summary>
        /// Convert data from read file
        /// </summary>
        /// <param name="_index"></param>
        /// <param name="_data"></param>
        public void ConvertReadData(int _index, string[] _data)
        {
            if (this.ini_read_data == false)
            {
                StreamReader sr = new StreamReader("hokuyo_info.txt");
                List<string> savedData = new List<string>();
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    savedData.Add(line);
                }
                string[] dataLines = savedData.ToArray();
                string[] max_buffer = dataLines[0].Split(' ');
                this.read_max_buffer_size = Convert.ToInt32(max_buffer[0]);
                string[] radian_angle = dataLines[1].Split(' ');
                this.read_index_to_radian = new List<double>();
                for (int i = 0; i < this.read_max_buffer_size; i++)
                {
                    double rad = Convert.ToDouble(radian_angle[i]);
                    this.read_index_to_radian.Add(rad);
                }

                this.ini_read_data = true;
            }

            this.cartesian_data.Clear();
            string[] lineArr = _data[_index].Split(' ');

            //calculate point
            CartesianXY point;
            for (int i = 0; i < this.read_max_buffer_size; i++)
            {
                int rowLength = Convert.ToInt32(lineArr[i]);
                point = calculate_point((rowLength), (this.read_index_to_radian[i] * 180.0 / Math.PI));
                this.cartesian_data.Add(point);
            }
        }

        /// <summary>
        /// Calculate point base on lenght from center and the angle of the point.
        /// </summary>
        /// <param name="lenght"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private CartesianXY calculate_point(int lenght, double angle)
        {
            CartesianXY point;
            //convert to radian
            angle = angle / 180 * (float)Math.PI;       
            //convert to x and y point
            point.x = -((double)lenght * Math.Sin(angle));  
            point.y = (double)lenght * Math.Cos(angle);

            return point;
        }

        /// <summary>
        /// disconnect method
        /// </summary>
        public void Disconnect()
        {
            this._hokuyo.Disconnect();
        }
        
        #endregion
    }
}
