using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SickLidar;
using ZedGraph;

namespace Display
{
    public partial class PanasonicLidarForm : Form
    {
        #region Fields

        private SickLidar.Panasonic panaLidar;
        private SickLidar.HiPerfTimer hTimer;
        private SickLidar.MicroTimer mTimer;
        //private int received_sensor_count { get; set; }

        private GraphPane myPane1;
        private GraphPane myPane2;
        private GraphPane myPane_line1;
        private GraphPane myPane_line2;
        private GraphPane myPane_line3;
        private GraphPane myPane_line4;
        private GraphPane myPane_line5;
        private GraphPane myPane_line6;
        private GraphPane myPane_line7;
        private GraphPane myPane_line8;
        private GraphPane myPane_line9;
        private GraphPane myPane_line10;
        private GraphPane myPane_line11;

        private PointPairList[] xyPoint;
        private PointPairList[] xzPoint;
        private PointPairList[] rawPoint;

        private CsvFileWriter writer;

        private bool is_timer_interval { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public PanasonicLidarForm()
        {
            InitializeComponent();
            this.panaLidar = new Panasonic();
            //this.received_sensor_count = 0;
            
            this.InitialGraph();
            
            this.hTimer = new HiPerfTimer();
            this.DebugFreqTxtBox.Text = this.hTimer.freq.ToString();

            this.mTimer = new MicroTimer();
            this.mTimer.MicroTimerElapsed +=
                new SickLidar.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);

            this.is_timer_interval = false;
        }
        
        #endregion

        #region 2D graph

        /// <summary>
        /// Initial Graph
        /// </summary>
        private void InitialGraph()
        {
            this.CreateGraph(ref this.zgcCartesianXY, ref this.myPane1, "XY plane", "x [m]", "y [m]");
            this.CreateGraph(ref this.zgcCartesianXZ, ref this.myPane2, "XZ plane", "x [m]", "z [m]");
            this.CreateGraph(ref this.zgcLine1, ref this.myPane_line1, "Raw Data - Line[1]", "x [index]", "y [m]");
            this.CreateGraph(ref this.zgcLine2, ref this.myPane_line2, "Raw Data - Line[2]", "x [index]", "y [m]");
            this.CreateGraph(ref this.zgcLine3, ref this.myPane_line3, "Raw Data - Line[3]", "x [index]", "y [m]");
            this.CreateGraph(ref this.zgcLine4, ref this.myPane_line4, "Raw Data - Line[4]", "x [index]", "y [m]");
            this.CreateGraph(ref this.zgcLine5, ref this.myPane_line5, "Raw Data - Line[5]", "x [index]", "y [m]");
            this.CreateGraph(ref this.zgcLine6, ref this.myPane_line6, "Raw Data - Line[6]", "x [index]", "y [m]");
            this.CreateGraph(ref this.zgcLine7, ref this.myPane_line7, "Raw Data - Line[7]", "x [index]", "y [m]");
            this.CreateGraph(ref this.zgcLine8, ref this.myPane_line8, "Raw Data - Line[8]", "x [index]", "y [m]");
            this.CreateGraph(ref this.zgcLine9, ref this.myPane_line9, "Raw Data - Line[9]", "x [index]", "y [m]");
            this.CreateGraph(ref this.zgcLine10, ref this.myPane_line10, "Raw Data - Line[10]", "x [index]", "y [m]");
            this.CreateGraph(ref this.zgcLine11, ref this.myPane_line11, "Raw Data - Line[11]", "x [index]", "y [m]");

            this.xyPoint = new PointPairList[11];
            this.xzPoint = new PointPairList[11];
            this.rawPoint = new PointPairList[11];
        }

        /// <summary>
        /// Create graph
        /// </summary>
        /// <param name="zgc"></param>
        /// <param name="gPane"></param>
        /// <param name="title"></param>
        /// <param name="x_title"></param>
        /// <param name="y_title"></param>
        private void CreateGraph(ref ZedGraphControl zgc, ref GraphPane gPane, string title, string x_title, string y_title)
        {
            // YZ Plane
            //--get a reference to the graphPane--//
            gPane = zgc.GraphPane;

            //--set the titles--//
            gPane.Title.Text = title;
            gPane.XAxis.Title.Text = x_title;
            gPane.YAxis.Title.Text = y_title;

            //--manually set the x axis range--//
            //gPane.XAxis.Scale.Min = -10.0;
            //gPane.XAxis.Scale.Max = 10.0;
            gPane.XAxis.MajorGrid.IsVisible = true;

            //--manually set the y axis range--//
            //gPane.YAxis.Scale.Min = -10.0;
            //gPane.YAxis.Scale.Max = 10.0;
            gPane.YAxis.MajorGrid.IsVisible = true;
            gPane.YAxis.MajorGrid.IsZeroLine = false;

            //--scale the axes--//
            zgc.AxisChange();
            zgc.Invalidate();
        }

        /// <summary>
        /// Set graph curve color
        /// </summary>
        /// <param name="_index"></param>
        /// <returns></returns>
        private Color SetColor(int _index)
        {
            Color clr = new Color();

            switch (_index)
            {
                case 0:
                    clr = Color.Red;
                    break;

                case 1:
                    clr = Color.Orange;
                    break;

                case 2:
                    clr = Color.YellowGreen;
                    break;

                case 3:
                    clr = Color.Gray;
                    break;

                case 4:
                    clr = Color.Blue;
                    break;

                case 5:
                    clr = Color.Black;
                    break;

                case 6:
                    clr = Color.Violet;
                    break;

                case 7:
                    clr = Color.Brown;
                    break;

                case 8:
                    clr = Color.Pink;
                    break;

                case 9:
                    clr = Color.SkyBlue;
                    break;

                case 10:
                    clr = Color.Black;
                    break;
            }

            return clr;
        }

        /// <summary>
        /// Update Graph
        /// </summary>
        private void UpdateGraph()
        {
            this.UpdateCartesianGraph(ref this.zgcCartesianXY, ref this.myPane1, 1);
            this.UpdateCartesianGraph(ref this.zgcCartesianXZ, ref this.myPane2, 2);
            this.SelectRawGraph();
        }

        /// <summary>
        /// Update Cartesian graph
        /// </summary>
        /// <param name="zgc"></param>
        /// <param name="gPane"></param>
        /// <param name="graph_index"></param>
        private void UpdateCartesianGraph(ref ZedGraphControl zgc, ref GraphPane gPane, int graph_index)
        {
            if (gPane.GraphObjList != null)
            {
                gPane.GraphObjList.Clear();
            }

            if (zgc.GraphPane.CurveList != null)
            {
                zgc.GraphPane.CurveList.Clear();
            }

            int cur_index = this.panaLidar.set_parameter.cur_count;
            if (graph_index == 1)
            {
                if (this.xyPoint[cur_index] != null)
                {
                    this.xyPoint[cur_index].Clear();
                }
                else
                {
                    this.xyPoint[cur_index] = new PointPairList();
                }
            }

            if (graph_index == 2)
            {
                if (this.xzPoint[cur_index] != null)
                {
                    this.xzPoint[cur_index].Clear();
                }
                else
                {
                    this.xzPoint[cur_index] = new PointPairList();
                }
            }


            for (int i = 0; i < this.panaLidar.point_cloud.Count; i++)
            {
                if (graph_index == 1)
                {
                    this.xyPoint[cur_index].Add(this.panaLidar.point_cloud[i].x, this.panaLidar.point_cloud[i].y);
                }

                if (graph_index == 2)
                {
                    this.xzPoint[cur_index].Add(this.panaLidar.point_cloud[i].x, this.panaLidar.point_cloud[i].z);
                }
            }


            for (int i = 0; i < this.panaLidar.set_parameter.scan_count; i++)
            {
                string label_line = "line " + i.ToString();
                if (graph_index == 1)
                {
                    if (this.xyPoint[i] != null)
                    {
                        gPane.AddCurve(label_line, this.xyPoint[i], this.SetColor(i), SymbolType.None);
                    }
                }

                if (graph_index == 2)
                {
                    if (this.xzPoint[i] != null)
                    {
                        gPane.AddCurve(label_line, this.xzPoint[i], this.SetColor(i), SymbolType.None);
                    }
                }
            }
            
            // tell zedgraph to refigure the axes since the data have changed
            zgc.AxisChange();

            // force redraw
            zgc.Invalidate();
        }

        /// <summary>
        /// Select raw graph
        /// </summary>
        private void SelectRawGraph()
        {
            int cur_count = this.panaLidar.set_parameter.cur_count;
            if (cur_count == 0)
            {
                this.UpdateRawGraph(ref this.zgcLine1, ref this.myPane_line1, cur_count);
            }
            else if (cur_count == 1)
            {
                this.UpdateRawGraph(ref this.zgcLine2, ref this.myPane_line2, cur_count);
            }
            else if (cur_count == 2)
            {
                this.UpdateRawGraph(ref this.zgcLine3, ref this.myPane_line3, cur_count);
            }
            else if (cur_count == 3)
            {
                this.UpdateRawGraph(ref this.zgcLine4, ref this.myPane_line4, cur_count);
            }
            else if (cur_count == 4)
            {
                this.UpdateRawGraph(ref this.zgcLine5, ref this.myPane_line5, cur_count);
            }
            else if (cur_count == 5)
            {
                this.UpdateRawGraph(ref this.zgcLine6, ref this.myPane_line6, cur_count);
            }
            else if (cur_count == 6)
            {
                this.UpdateRawGraph(ref this.zgcLine7, ref this.myPane_line7, cur_count);
            }
            else if (cur_count == 7)
            {
                this.UpdateRawGraph(ref this.zgcLine8, ref this.myPane_line8, cur_count);
            }
            else if (cur_count == 8)
            {
                this.UpdateRawGraph(ref this.zgcLine9, ref this.myPane_line9, cur_count);
            }
            else if (cur_count == 9)
            {
                this.UpdateRawGraph(ref this.zgcLine10, ref this.myPane_line10, cur_count);
            }
            else if (cur_count == 10)
            {
                this.UpdateRawGraph(ref this.zgcLine11, ref this.myPane_line11, cur_count);
            }
        }

        /// <summary>
        /// Update raw graph
        /// </summary>
        /// <param name="zgc"></param>
        /// <param name="gPane"></param>
        /// <param name="_cur_count"></param>
        private void UpdateRawGraph(ref ZedGraphControl zgc, ref GraphPane gPane, int _cur_count)
        {
            if (gPane.GraphObjList != null)
            {
                gPane.GraphObjList.Clear();
            }

            if (zgc.GraphPane.CurveList != null)
            {
                zgc.GraphPane.CurveList.Clear();
            }

            //--manually set the x axis range--//
            gPane.Title.IsVisible = false;
            gPane.XAxis.Scale.Min = (double)this.panaLidar.set_parameter.amin;
            gPane.XAxis.Scale.Max = (double)this.panaLidar.set_parameter.amax;

            if (this.rawPoint[_cur_count] != null)
            {
                this.rawPoint[_cur_count].Clear();
            }
            else
            {
                this.rawPoint[_cur_count] = new PointPairList();
            }


            for (int i = 0; i < this.panaLidar.decode_data.Count; i++)
            {
                this.rawPoint[_cur_count].Add((double)i, (double)this.panaLidar.decode_data[i]);
            }

            //string label_line = "line " + this.panaLidar.set_parameter.cur_count.ToString();

            if (this.rawPoint[_cur_count] != null)
            {
                //gPane.AddCurve(label_line, rawPoint[_cur_count], this.SetColor(_cur_count), SymbolType.None);
                gPane.AddCurve(null, rawPoint[_cur_count], this.SetColor(_cur_count), SymbolType.None);
            }

            // tell zedgraph to refigure the axes since the data have changed
            zgc.AxisChange();

            // force redraw
            zgc.Invalidate(); 
        }

        #endregion

        #region Method

        /// <summary>
        /// Echo data 
        /// </summary>
        /// <param name="_data"></param>
        private void DebugEchoData(List<string> _data)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                this.DebugTxtBox.AppendText(_data[i] + Environment.NewLine);
            }
        }

        /// <summary>
        /// http://msdn.microsoft.com/ko-kr/library/bb882581(v=vs.110).aspx
        /// </summary>
        /// <returns>Millisecond component with full date and time.</returns>
        private string MillisecondDisplay()
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            return time.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
        }

        #endregion

        #region Event

        /// <summary>
        /// Connect Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (this.panaLidar.isPort == false)
            {
                // Read mode
                if (this.FileIoCheckListBox.GetItemChecked(0) == true)
                {
                    this.DebugTxtBox.AppendText("-----Read mode is start.-----" + Environment.NewLine + Environment.NewLine);
                    this.panaLidar.file_mode = 1;
                }

                // Save mode
                if (this.FileIoCheckListBox.GetItemChecked(1) == true)
                {
                    this.DebugTxtBox.AppendText("-----Save mode is start.-----" + Environment.NewLine + Environment.NewLine);
                    this.panaLidar.file_mode = 2;

                    if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        this.writer = new CsvFileWriter(saveFileDialog1.FileName);
                    }
                }

                // serial communication
                string port = this.SerialPortTxtBox.Text;
                int baudRate = Convert.ToInt32(this.SerialBaudrateTxtBox.Text);
                int dataBits = Convert.ToInt32(this.SerialDatabitsTxtBox.Text);
                string open_message = this.panaLidar.Open(port, baudRate, dataBits);
                this.DebugTxtBox.AppendText("-----Open Message-----" + Environment.NewLine);
                this.DebugTxtBox.AppendText(open_message + Environment.NewLine);
                this.DebugTxtBox.AppendText(Environment.NewLine);

                if (this.panaLidar.isPort == true)
                {
                    // version check
                    List<string> vv_message = this.panaLidar.VV();
                    this.DebugTxtBox.AppendText("-----Version Check-----" + Environment.NewLine);
                    this.DebugEchoData(vv_message);

                    // specification check
                    List<string> pp_message = this.panaLidar.PP();
                    this.DebugTxtBox.AppendText("-----Specification Check-----" + Environment.NewLine);
                    this.DebugEchoData(pp_message);
                    this.DebugAminTxtBox.Text = this.panaLidar.set_parameter.amin.ToString();
                    this.DebugAmaxTxtBox.Text = this.panaLidar.set_parameter.amax.ToString();

                    // laser enabling the measurement
                    List<string> bm_message = this.panaLidar.BM(this.ScanModeComboBox.SelectedIndex);
                    this.DebugTxtBox.AppendText("-----Laser Enabling the measurement-----" + Environment.NewLine);
                    this.DebugEchoData(bm_message);

                    // sensor data acquisition
                    List<string> gda_message = this.panaLidar.GD(this.panaLidar.set_parameter.amin, this.panaLidar.set_parameter.amax, 'A');
                    this.DebugTxtBox.AppendText("-----Ready for scanning->GD[A]-----" + Environment.NewLine);
                    this.DebugEchoData(gda_message);
                }
                else
                {
                }
            }
            else
            {
                this.DebugTxtBox.AppendText("Sensor is already connected." + Environment.NewLine);
            }
        }

        /// <summary>
        /// Scan Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanButton_Click(object sender, EventArgs e)
        {
            if (this.panaLidar.isPort == true)
            {
                // timer On
                this.timer1.Interval = this.panaLidar.set_parameter.interval;
                this.timer1.Enabled = true;

                // Call micro timer = 1000µs(1ms) * set_interval
                int mTimer_interval = this.panaLidar.set_parameter.interval * 1000;
                this.mTimer.Interval = mTimer_interval;
                this.mTimer.Enabled = true; // Start timer

                //this.toolStripStatusLabel10.Text = this.panaLidar.set_parameter.interval.ToString();
                this.DebugTxtBox.AppendText("Scanning mode!!." + Environment.NewLine + Environment.NewLine);
            }
            else
            {
                this.DebugTxtBox.AppendText("Sensor is not connected." + Environment.NewLine + Environment.NewLine);
            }
        }

        /// <summary>
        /// Disconnect Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled == true)
            {
                this.timer1.Enabled = false;
            }

            if (this.mTimer.Enabled == true)
            {
                this.mTimer.Enabled = false;
            }

            if (this.panaLidar.isPort == true)
            {
                // the laser disabling sensor’s measurement state.
                List<string> qt_message = this.panaLidar.QT();
                this.DebugTxtBox.AppendText("-----Laser Disabling the measurement-----" + Environment.NewLine);
                this.DebugEchoData(qt_message);

                // close port
                string close_message = this.panaLidar.Close();
                this.DebugTxtBox.AppendText("-----Close Message-----" + Environment.NewLine);
                this.DebugTxtBox.AppendText(close_message + Environment.NewLine);
                this.DebugTxtBox.AppendText(Environment.NewLine);
            }
            else
            {
                this.DebugTxtBox.AppendText("Sensor is not connected." + Environment.NewLine);
            }
        }

        /// <summary>
        /// One line scan event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OneLineScanButton_Click(object sender, EventArgs e)
        {
            if (this.panaLidar.isPort == true)
            {
                // sensor data acquisition
                List<string> gd1_message = this.panaLidar.GD(this.panaLidar.set_parameter.amin, this.panaLidar.set_parameter.amax, '1');
                this.DebugTxtBox.AppendText("-----sensor data acquisition->GD[1]-----" + Environment.NewLine);
                this.DebugEchoData(gd1_message);

                // decoding received data
                string decode_message = this.panaLidar.Decode(gd1_message);
                this.DebugTxtBox.AppendText("-----Decoded data-----" + Environment.NewLine);
                this.DebugTxtBox.AppendText(decode_message + Environment.NewLine);
                this.DebugTxtBox.AppendText("Time stamp: " + this.panaLidar.time_stamp.ToString() + Environment.NewLine);
                this.DebugTxtBox.AppendText("Measurement data:" + Environment.NewLine);
                string d_data = null;
                for (int i = 0; i < this.panaLidar.decode_data.Count; i++)
                {
                    d_data += this.panaLidar.decode_data[i].ToString() + " ";
                }
                this.DebugTxtBox.AppendText(d_data + Environment.NewLine + Environment.NewLine);

            }
            else
            {
                this.DebugTxtBox.AppendText("Sensor is not connected." + Environment.NewLine);
            }
        }

        /// <summary>
        /// Timer Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // current tick count
            this.DebugTickTxtBox.Text = this.hTimer.TotalTickCount().ToString();

            // sensor count
            this.toolStripStatusLabel2.Text = this.panaLidar.sensor_count.ToString();
           
            // time stamp from sensor
            this.toolStripStatusLabel4.Text = this.panaLidar.time_stamp.ToString();

            // processing time
            this.toolStripStatusLabel6.Text = this.panaLidar.elapsed_time.ToString("0000.0000") + " [ms]";

            // current time
            this.toolStripStatusLabel8.Text = this.panaLidar.current_time;

            // timer interval time
            this.toolStripStatusLabel10.Text = this.panaLidar.timer_time.ToString() + " [ms]";
        }

        /// <summary>
        /// Micro Timer Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="timerEventArgs"></param>
        private void OnTimedEvent(object sender, SickLidar.MicroTimerEventArgs timerEventArgs)
        {
            if (this.is_timer_interval == false)
            {
                this.panaLidar.before_timer = timerEventArgs.ElapsedMicroseconds;
                this.is_timer_interval = true;
            }
            else
            {
                this.panaLidar.timer_time = (double)(timerEventArgs.ElapsedMicroseconds - this.panaLidar.before_timer) / (double)(1000.0);
                this.panaLidar.before_timer = timerEventArgs.ElapsedMicroseconds;
            }

            // sensor count
            this.panaLidar.sensor_count = timerEventArgs.TimerCount;

            // current time
            this.panaLidar.current_time = this.MillisecondDisplay();

            // stopwatch start
            this.hTimer.Start();

            // sensor data acquisition
            List<string> gd1_message = this.panaLidar.GD(this.panaLidar.set_parameter.amin, this.panaLidar.set_parameter.amax, '1');

            // decoding received data
            this.panaLidar.Decode(gd1_message);

            // save mode
            if (this.panaLidar.file_mode == 2)
            {
                this.writer.WriteRow(this.panaLidar.save_data);
            }

            // convert decoded data to 3d point cloud
            this.panaLidar.DecodedDataToPointCloud();

            // draw data
            if (this.panaLidar.point_cloud.Count != 0)
            {
                this.UpdateGraph();
            }

            // stopwatch end
            this.hTimer.Stop();

            // processing time
            this.panaLidar.elapsed_time = this.hTimer.Duration;

            //// Do something small that takes significantly less time than Interval
            //Console.WriteLine(string.Format(
            //    "Count = {0:#,0}  Timer = {1:#,0} µs, " +
            //    "LateBy = {2:#,0} µs, ExecutionTime = {3:#,0} µs",
            //    timerEventArgs.TimerCount, timerEventArgs.ElapsedMicroseconds,
            //    timerEventArgs.TimerLateBy, timerEventArgs.CallbackFunctionExecutionTime));
        }

        /// <summary>
        /// Exit Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion     
    }
}
