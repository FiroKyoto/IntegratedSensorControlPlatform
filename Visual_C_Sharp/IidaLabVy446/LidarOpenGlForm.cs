
namespace IidaLabVy446
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using System.IO;
    using System.Diagnostics;
    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.OpenGL;
    using SickLidar;
    using FieldMap;
    using ZedGraph;

    public partial class LidarOpenGlForm : Form
    {
        #region fields

        /// <summary>
        /// graph
        /// </summary>
        private FieldMap.Graph _graph;

        /// <summary>
        /// is loaded?
        /// </summary>
        private bool loaded { get; set; }

        /// <summary>
        /// translate value
        /// </summary>
        private int transX { get; set; }
        private int transY { get; set; }
        private int transZ { get; set; }

        /// <summary>
        /// roatate value
        /// </summary>
        private double angle { get; set; }

        /// <summary>
        /// Crop vertex points
        /// </summary>
        //private List<SickLidar.CartesianPoint> crop;
        private Vector3[] cropPoints;
        private Vector3[] groundPoints;
        private int cropCnt { get; set; }
        private int cropOffset { get; set; }
        private int groundOffset { get; set; }

        /// <summary>
        /// transverse mecartor
        /// </summary>
        private float _tmX { get; set; }
        private float _tmY { get; set; }

        /// <summary>
        /// body information
        /// </summary>
        private double _heading_angle { get; set; }
        private double _body_speed { get; set; }

        /// <summary>
        /// manual key control
        /// </summary>
        private bool isManualControl { get; set; }

        /// <summary>
        /// edge points
        /// </summary>
        private Vector3[] edgePoints;
        //private int edgeOffset { get; set; }

        /// <summary>
        /// ideal path points
        /// </summary>
        private Vector3[] idealPathPoints;

        /// <summary>
        /// gets or sets divider of header position
        /// </summary>
        private double headerX { get; set; }
        private double headerY { get; set; }

        /// <summary>
        /// gets or sets combine model index
        /// </summary>
        private int bodyModelIndex { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public LidarOpenGlForm(int _bodyModelIndex)
        {
            InitializeComponent();

            // initialization graph
            this._graph = new FieldMap.Graph();
            this._graph.CreateGraph(zgc1);

            // initialization OpenGl variable
            this.bodyModelIndex = _bodyModelIndex;

            this.loaded = false;
            this.transX = 0;
            this.transY = 0;
            this.transZ = 0;
            this.angle = 0.0;

            //this.crop = new List<SickLidar.CartesianPoint>();
            cropPoints = new Vector3[361 * 50000];
            groundPoints = new Vector3[361 * 50000];
            edgePoints = new Vector3[2 * 50000];
            idealPathPoints = new Vector3[2 * 50000];

            this.cropCnt = 0;
            this.cropOffset = 0;
            this.groundOffset = 0;
            //this.edgeOffset = 0;

            this.isManualControl = false;
        }

        #endregion

        #region Graph

        /// <summary>
        /// Draw traceability map
        /// </summary>
        private void DrawTraceabilityMap()
        {
            PointPairList pplist = new PointPairList();

            // add arrow
            pplist.Add(this._tmX, this._tmY);
            List<double> arrow_end = this.ConvertPoint(0.0, 0.1, this._heading_angle);
            pplist.Add(this._tmX + arrow_end[0], this._tmY + arrow_end[1]);

            // add ideal path
            pplist.Add(this.idealPathPoints[0].X, this.idealPathPoints[0].Y);
            pplist.Add(this.idealPathPoints[1].X, this.idealPathPoints[1].Y);

            // add extracted ransac line
            if (this.ran_running == true)
            {
                pplist.Add(this.edgePoints[0].X, this.edgePoints[0].Y);
                pplist.Add(this.edgePoints[1].X, this.edgePoints[1].Y);
            }

            // add body points
            //List<double> body_a = this.ConvertPoint(-0.5, 1.0, this._heading_angle);
            //pplist.Add(this._tmX + body_a[0], this._tmY + body_a[1]);
            //List<double> body_b = this.ConvertPoint(0.5, 1.0, this._heading_angle);
            //pplist.Add(this._tmX + body_b[0], this._tmY + body_b[1]);
            //List<double> body_d = this.ConvertPoint(0.5, -1.0, this._heading_angle);
            //pplist.Add(this._tmX + body_d[0], this._tmY + body_d[1]);
            //List<double> body_c = this.ConvertPoint(-0.5, -1.0, this._heading_angle);
            //pplist.Add(this._tmX + body_c[0], this._tmY + body_c[1]);

            // draw traceability on the graph
            this._graph.TraceabilityGraph(zgc1, pplist, this.ran_running);
        }

        #endregion

        #region OpenGL Methods

        /// <summary>
        /// Setup view port
        /// </summary>
        private void SetupViewport()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;

            // Use all of the glControl painting area
            GL.Viewport(0, 0, w, h);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //float nRange = 100.0f;
            double aspect_ratio = (double)w / (double)h;
            //GL.Ortho(-nRange, nRange, -nRange * aspect_ratio, nRange * aspect_ratio, -nRange, nRange);

            OpenTK.Matrix4 perspective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver3, (float)aspect_ratio, 1, 100);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        /// <summary>
        /// Draw cartesian coordinates 
        /// </summary>
        private void DrawCoordinates()
        {
            GL.LineWidth(2.0f);
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(2, 0, 0);

            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 2, 0);

            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 2);
            GL.End();
        }

        /// <summary>
        /// draw ground
        /// </summary>
        private void DrawGround()
        {
            GL.LineWidth(1.0f);
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.LightGray);
            for (int i = 0; i <= 200; i++)
            {
                GL.Vertex3(-200, (float)i, 0);
                GL.Vertex3(200, (float)i, 0);

                GL.Vertex3(-200, -(float)i, 0);
                GL.Vertex3(200, -(float)i, 0);

                GL.Vertex3((float)i, 200, 0);
                GL.Vertex3((float)i, -200, 0);

                GL.Vertex3(-(float)i, 200, 0);
                GL.Vertex3(-(float)i, -200, 0);

            }
            GL.End();
        }

        /// <summary>
        /// convert points using heading angle
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_angle"></param>
        /// <returns></returns>
        private List<double> ConvertPoint(double _x, double _y, double _angle)
        {
            List<double> points = new List<double>();

            double bAngle = (_angle - 270.0) * (Math.PI / 180);
            double rotX = (Math.Sin(bAngle) * _y) + (Math.Cos(bAngle) * _x);
            double rotY = (Math.Cos(bAngle) * _y) - (Math.Sin(bAngle) * _x);

            points.Add(rotX);
            points.Add(rotY);

            return points;
        }

        /// <summary>
        /// Draw Body
        /// if _bodyModel is 0 then body model is vy50.
        /// else if _bodyModel is 1 then body model is vy446.
        /// </summary>
        private void DrawBody()
        {
            // arrow
            List<double> arrowLine = this.ConvertPoint(0.0, 2.0, this._heading_angle);
            List<double> arrowA = this.ConvertPoint(0.5, 1.5, this._heading_angle);
            List<double> arrowB = this.ConvertPoint(-0.5, 1.5, this._heading_angle);

            // end of right header
            List<double> rHeaderA = new List<double>();
            List<double> rHeaderB = new List<double>();
            
            // VY50
            if (this.bodyModelIndex == 0)
            {
                double La = 0.45;
                double Lc = 0.6;
                double Lbe = 0.59 + 0.073;
                rHeaderA = this.ConvertPoint(Lbe, La, this._heading_angle);
                rHeaderB = this.ConvertPoint(Lbe, La + Lc, this._heading_angle);
            }

            // VY446
            if (this.bodyModelIndex == 1)
            {
                double La = 0.15;
                double Lc = 0.83;
                double Lbe = 0.79 + 0.038;
                rHeaderA = this.ConvertPoint(Lbe, La, this._heading_angle);
                rHeaderB = this.ConvertPoint(Lbe, La + Lc, this._heading_angle);
            }

            GL.LineWidth(3.0f);
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Yellow);

            // arrow
            GL.Vertex3(this._tmX, this._tmY, 0.0);
            GL.Vertex3(this._tmX, this._tmY, 3.0);

            GL.Vertex3(this._tmX, this._tmY, 2.5);
            GL.Vertex3(this._tmX + arrowLine[0], this._tmY + arrowLine[1], 2.5);

            GL.Vertex3(this._tmX + arrowLine[0], this._tmY + arrowLine[1], 2.5);
            GL.Vertex3(this._tmX + arrowA[0], this._tmY + arrowA[1], 2.5);

            GL.Vertex3(this._tmX + arrowLine[0], this._tmY + arrowLine[1], 2.5);
            GL.Vertex3(this._tmX + arrowB[0], this._tmY + arrowB[1], 2.5);

            // end of right header
            this.headerX = this._tmX + rHeaderB[0];
            this.headerY = this._tmY + rHeaderB[1];

            GL.Vertex3(this._tmX + rHeaderA[0], this._tmY + rHeaderA[1], 0.0);
            GL.Vertex3(this._tmX + rHeaderB[0], this._tmY + rHeaderB[1], 0.0);

            GL.End();

            // GPS circle
            GL.Begin(BeginMode.LineLoop);
            for (int i = 0; i <= 300; i++)
            {
                double angle = 2 * Math.PI * i / 300;
                double x = Math.Cos(angle);
                double y = Math.Sin(angle);
                GL.Vertex3(this._tmX + x, this._tmY + y, 2.5);
            }
            GL.End();
        }


        /// <summary>
        /// add edge point to vertex array
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="_isRan"></param>
        public void AddEdge(List<SickLidar.CartesianPoint> _list, bool _isRan)
        {
            if (_isRan == true)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    //edgePoints[i + this.edgeOffset] = new Vector3((float)_list[i].x, (float)_list[i].y, (float)_list[i].z);
                    edgePoints[i] = new Vector3((float)_list[i].x, (float)_list[i].y, (float)_list[i].z);
                }

                //this.edgeOffset += _list.Count;
            }
        }

        /// <summary>
        /// add ideal path point to vertex array
        /// </summary>
        /// <param name="_list"></param>
        public void AddIdealPath(List<SickLidar.CartesianPoint> _list)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                idealPathPoints[i] = new Vector3((float)_list[i].x, (float)_list[i].y, (float)_list[i].z);
            }
        }

        /// <summary>
        /// discriminate point X between crop and ground
        /// </summary>
        private double discriminate_point_x { get; set; }

        /// <summary>
        /// discriminate point Y between crop and ground
        /// </summary>
        private double discriminate_point_y { get; set; }

        /// <summary>
        /// add crop points to list
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="_glIndex"></param>
        public void AddCrop(List<SickLidar.CartesianPoint> _list, int _glIndex)
        {
            this.discriminate_point_x = _list[_glIndex].x;
            this.discriminate_point_y = _list[_glIndex].y;

            for (int i = 0; i < _glIndex; i++)
            {
                //this.crop.Add(new SickLidar.CartesianPoint(_list[i].x, _list[i].y, _list[i].z));
                this.cropPoints[i + this.cropOffset] = new Vector3((float)_list[i].x, (float)_list[i].y, (float)_list[i].z);
            }
            this.cropOffset += _glIndex;

            int gCnt = 0;
            for (int i = _glIndex; i < _list.Count; i++)
            {
                this.groundPoints[gCnt + this.groundOffset] = new Vector3((float)_list[i].x, (float)_list[i].y, (float)_list[i].z);
                gCnt++;
            }
            this.groundOffset += _list.Count - _glIndex;

            this.cropCnt++;            
        }

        /// <summary>
        /// Draw crop stand on the openGL form
        /// </summary>
        private void DrawCrop()
        {
            //// Immediate mode
            //GL.Begin(BeginMode.Points);
            //GL.PointSize(2);
            //GL.Color3(Color.Violet);
            //for (int i = 0; i < this.crop.Count; i++)
            //{
            //    GL.Vertex3(this.crop[i].x, this.crop[i].y, this.crop[i].z);
            //}
            //GL.End();

            // Vertex array mode
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(3, VertexPointerType.Float, 0, cropPoints);
            GL.Color3(Color.LawnGreen);
            GL.DrawArrays(BeginMode.Points, 0, this.cropOffset - 1);
            GL.DisableClientState(ArrayCap.VertexArray);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(3, VertexPointerType.Float, 0, groundPoints);
            GL.Color3(Color.SaddleBrown);
            GL.DrawArrays(BeginMode.Points, 0, this.groundOffset - 1);
            GL.DisableClientState(ArrayCap.VertexArray);

        }

        /// <summary>
        /// draw edge
        /// </summary>
        private void DrawEdge()
        {
            // Vertex array mode
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(3, VertexPointerType.Float, 0, edgePoints);
            GL.Color3(Color.Red);
            //GL.DrawArrays(BeginMode.Lines, 0, this.edgeOffset - 1);
            GL.DrawArrays(BeginMode.Lines, 0, 3);
            GL.DisableClientState(ArrayCap.VertexArray);

            // Vertex array mode
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(3, VertexPointerType.Float, 0, idealPathPoints);
            GL.Color3(Color.Orange);
            //GL.DrawArrays(BeginMode.Lines, 0, this.edgeOffset - 1);
            GL.DrawArrays(BeginMode.Lines, 0, 3);
            GL.DisableClientState(ArrayCap.VertexArray);
        }

        /// <summary>
        /// Form Update
        /// </summary>
        public void GlUpdate()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // glControl invalidate
            glControl1.Invalidate();

            // draw traceability map
            this.DrawTraceabilityMap();

            // save data
            if (this.GlSaveDataCheckBox.Checked == true)
            {
                this.SaveData();
            }

            watch.Stop();
            this.GlElapsedTxtBox.Text =
                watch.Elapsed.TotalMilliseconds.ToString("N3") + " milliseconds";
        }

        #endregion

        #region Debug methods

        private StreamWriter save_to_txt;
        private bool save_ready = false;
        private int save_index = 0;

        /// <summary>
        /// save data to txt file
        /// </summary>
        private void SaveData()
        {
            // open and add data
            if ((this.ran_start == true) && (this.ran_end == false))
            {
                // initialization
                if (this.save_ready == false)
                {
                    this.save_index++;
                    string save_file_name = "result" + Convert.ToString(this.save_index) + ".txt";
                    this.save_to_txt = new StreamWriter(save_file_name);
                    string title =
                        "Read_count" + " " +
                        "Tm_X" + " " +
                        "Tm_Y" + " " +
                        "Body_angle" + " " +
                        "Ideal_path_angle" + " " +
                        "Current_position_to_ideal_path_angle" + " " +
                        "Perpendicular_distance_Ideal" + " " +
                        "Ransac_angle" + " " +
                        "Header_to_ransac_angle" + " " +
                        "Perpencicular_distance_ransac" + " " +
                        "Steer_command" + " " +
                        "Header_command" + " " +
                        "Discriminate_ptX" + " " +
                        "Discriminate_ptY" + " " +
                        "Right_header_ptX" + " " +
                        "Right_header_ptY" + " " +
                        "Avg_Gnd_Hgt";
                    this.save_to_txt.WriteLine(title);

                    this.save_ready = true;
                }

                string read_cnt = Convert.ToString(this.read_count);
                string tm_x = Convert.ToString(this._tmX);
                string tm_y = Convert.ToString(this._tmY);
                string body_angle = Convert.ToString(this._heading_angle);
                string ideal_path_angle = Convert.ToString(this.ideal_angle);
                string gps_angle = Convert.ToString(this.gps_angle);
                string gps_distance = Convert.ToString(this.gps_distance);
                string ran_angle = "0";
                string header_to_ran_angle = "0";
                string ran_distance = "0";
                string steer_cmd = "0";
                string header_cmd = "0";
                string discriminate_ptX = "0";
                string discriminate_ptY = "0";
                string right_header_ptX = Convert.ToString(this.headerX);
                string right_header_ptY = Convert.ToString(this.headerY);
                string avg_gnd_hgt = "0";

                if (this.ran_start == true)
                {
                    // add discriminate point between ground and crop
                    discriminate_ptX = Convert.ToString(this.discriminate_point_x);
                    discriminate_ptY = Convert.ToString(this.discriminate_point_y);

                    // add ransac information to txt file
                    if (this.ran_running == true)
                    {
                        ran_angle = Convert.ToString(this.ran_heading);
                        header_to_ran_angle = Convert.ToString(this.ran_to_header_angle);
                        ran_distance = Convert.ToString(this.ran_current_dist);

                        if (this.is_autonomous_mode == true)
                        {
                            avg_gnd_hgt = Convert.ToString(this.avgGndHgt);
                        }
                    }
                }

                // add body control information to txt file
                if (this.is_autonomous_mode == true)
                {
                    steer_cmd = this.forward_steer_debug_msg;
                    header_cmd = Convert.ToString(this.cmd_header_potentiometer);
                }

                string data = read_cnt + " " + tm_x + " " + tm_y + " " + body_angle + " " + ideal_path_angle + " " +
                    gps_angle + " " + gps_distance + " " + ran_angle + " " + header_to_ran_angle + " " +
                    ran_distance + " " + steer_cmd + " " + header_cmd + " " + discriminate_point_x + " " +
                    discriminate_point_y + " " + right_header_ptX + " " + right_header_ptY + " " + avg_gnd_hgt;

                this.save_to_txt.WriteLine(data);
            }

            // close
            if ((this.ran_running == false) && (this.ran_end == true) && (this.save_ready == true))
            {
                this.save_to_txt.Close();
                this.save_ready = false;
            }

            // debug
            this.GlSaveStateTxtBox.Text = Convert.ToString(this.save_ready);
        }

        /// <summary>
        /// gets or sets current processing count number
        /// </summary>
        private int read_count { get; set; }

        /// <summary>
        /// Body information debug method
        /// </summary>
        /// <param name="_readCnt"></param>
        /// <param name="_tmX"></param>
        /// <param name="_tmY"></param>
        /// <param name="_tmZ"></param>
        /// <param name="_heading_angle"></param>
        /// <param name="_body_speed"></param>
        public void BodyInformation(int _readCnt, double _tmX, double _tmY, double _tmZ, double _heading_angle, double _body_speed)
        {
            this.GlReadCntTxtBox.Text = Convert.ToString(_readCnt);
            this.read_count = _readCnt;
            this.GlCurCntTxtBox.Text = Convert.ToString(this.cropCnt);
            this.GlTmXTxtBox.Text = _tmX.ToString("N3");
            this._tmX = (float)_tmX;
            this.GlTmYTxtBox.Text = _tmY.ToString("N3");
            this._tmY = (float)_tmY;
            this.GlTmZTxtBox.Text = _tmZ.ToString("N3");
            this.GlBodyHeadingTxtBox.Text = _heading_angle.ToString("N3");
            this._heading_angle = _heading_angle;
            this.GlBodySpeedTxtBox.Text = _body_speed.ToString("N3");
            this._body_speed = _body_speed;

            this.GlHarvestTimesTxtBox.Text = Convert.ToString(this.harvest_times_count);
        }

        /// <summary>
        /// gets or sets is autonomous mode state
        /// </summary>
        private bool is_autonomous_mode = false;

        /// <summary>
        /// vy446 autonomous check debug method
        /// </summary>
        /// <param name="_is_autonomous_mode"></param>
        public void Vy446AutonomousModeCheckDebug(bool _is_autonomous_mode)
        {
            this.GlAutoModeTxtBox.Text = Convert.ToString(_is_autonomous_mode);
            this.is_autonomous_mode = _is_autonomous_mode;
        }

        /// <summary>
        /// gets or sets ransac start state
        /// </summary>
        private bool ran_start { get; set; }
        
        /// <summary>
        /// gets or sets ransac running state
        /// </summary>
        private bool ran_running { get; set; }
        
        /// <summary>
        /// gets or sets ransac end state
        /// </summary>
        private bool ran_end { get; set; }

        /// <summary>
        /// for harvest count
        /// </summary>
        private bool is_harvest_start = false;

        /// <summary>
        /// gets or sets number of times of harvest
        /// </summary>
        public int harvest_times_count { get; set; }

        /// <summary>
        /// gets or sets distance between ransac points
        /// </summary>
        private double ran_distance_between_points { get; set; }

        /// <summary>
        /// ransac state debug method
        /// </summary>
        /// <param name="_ran_start"></param>
        /// <param name="_ran_running"></param>
        /// <param name="_ran_end"></param>
        /// <param name="_ran_distance_between_points"></param>
        public void RansacStateDebug(bool _ran_start, bool _ran_running, bool _ran_end, double _ran_distance_between_points)
        {
            this.GlRanStartTxtBox.Text = Convert.ToString(_ran_start);
            this.ran_start = _ran_start;

            this.GlIsRanTxtBox.Text = Convert.ToString(_ran_running);
            this.ran_running = _ran_running;

            this.GlRanEndTxtBox.Text = Convert.ToString(_ran_end);
            this.ran_end = _ran_end;

            this.GlHarvestDistanceTxtBox.Text = _ran_distance_between_points.ToString("N3");
            this.ran_distance_between_points = _ran_distance_between_points;

            if (this.ran_start == true)
            {
                this.is_harvest_start = true;
            }

            if ((this.ran_end == true) && (this.is_harvest_start == true))
            {
                this.harvest_times_count++;
                this.is_harvest_start = false;
            }
        }

        /// <summary>
        /// gets or sets ransac angle
        /// </summary>
        private double ran_heading { get; set; }

        /// <summary>
        /// gets or sets perpendicular distance between TM point and ransac line
        /// </summary>
        private double ran_current_dist { get; set; }

        /// <summary>
        /// gets or sets average perpendicular distance between TM point and ransac line
        /// </summary>
        private double ran_average_dist { get; set; }

        /// <summary>
        /// gets or sets angle between header and extracted ransac line
        /// </summary>
        private double ran_to_header_angle { get; set; }

        /// <summary>
        /// Ransac result debug
        /// </summary>
        /// <param name="_ran_heading"></param>
        /// <param name="_ran_current_dist"></param>
        /// <param name="_ran_average_dist"></param>
        /// <param name="_ran_to_header_angle"></param>
        public void RansacResultDebug(double _ran_heading, double _ran_current_dist, double _ran_average_dist, double _ran_to_header_angle)
        {
            this.GlRanHeadingTxtBox.Text = _ran_heading.ToString("N3");
            this.ran_heading = _ran_heading;

            this.GlRanDistanceTxtBox.Text = _ran_current_dist.ToString("N3");
            this.ran_current_dist = _ran_current_dist;

            this.GlRanStandDistanceTxtBox.Text = _ran_average_dist.ToString("N3");
            this.ran_average_dist = _ran_average_dist;

            this.GlHeaderRanHeadingTxtBox.Text = _ran_to_header_angle.ToString("N3");
            this.ran_to_header_angle = _ran_to_header_angle;
        }

        /// <summary>
        /// gets or sets forward steering debug message
        /// </summary>
        private string forward_steer_debug_msg { get; set; }

        /// <summary>
        /// Forward Steer Debug
        /// </summary>
        /// <param name="_vy50"></param>
        /// <param name="_vy446"></param>
        /// <param name="_cmd_steer"></param>
        /// <param name="_cmd_hst"></param>
        public void ForwardSteerDebug(bool _vy50, bool _vy446, ushort _cmd_steer, ushort _cmd_hst, string _forward_steer_debug_msg)
        {
            // vy446
            if ((_vy50 == false) && (_vy446 == true))
            {
                this.GlSteerCmdTxtBox.Text = Convert.ToString(_cmd_steer);
                this.GlHstCmdTxtBox.Text = Convert.ToString(_cmd_hst);
                this.GlSteerOperationTxtBox.Text = _forward_steer_debug_msg;
                this.forward_steer_debug_msg = _forward_steer_debug_msg;
            }
        }

        /// <summary>
        /// gets or sets header potentiometer
        /// </summary>
        private ushort cmd_header_potentiometer { get; set; }

        /// <summary>
        /// gets or sets average ground height
        /// </summary>
        private double avgGndHgt { get; set; }

        /// <summary>
        /// header control debug
        /// </summary>
        /// <param name="_cmd_header_potentiometer"></param>
        /// <param name="_karitaka_start_distance"></param>
        /// <param name="_karitaka_end_distance"></param>
        /// <param name="_avgGndHgt"></param>
        public void HeaderControlDebug(ushort _cmd_header_potentiometer, double _karitaka_start_distance, double _karitaka_end_distance, double _avgGndHgt)
        {
            this.GlHeaderPoteniometerTxtBox.Text = Convert.ToString(_cmd_header_potentiometer);
            this.cmd_header_potentiometer = _cmd_header_potentiometer;

            this.GlHeaderStartDistanceTxtBox.Text = _karitaka_start_distance.ToString("N3");
            this.GlHeaderEndDistanceTxtBox.Text = _karitaka_end_distance.ToString("N3");

            this.GlHeaderAvgGndHgtTxtBox.Text = Convert.ToString(_avgGndHgt);
            this.avgGndHgt = _avgGndHgt;
        }

        /// <summary>
        /// gets or sets perpendicular distance between ideal path to gps position
        /// </summary>
        private double gps_distance { get; set; }

        /// <summary>
        /// gets or sets gps angle
        /// </summary>
        private double gps_angle { get; set; }

        /// <summary>
        /// ideal path angle
        /// </summary>
        private double ideal_angle { get; set; }

        /// <summary>
        /// Ideal path to GPS debug
        /// </summary>
        /// <param name="_gps_distance"></param>
        /// <param name="_gps_angle"></param>
        /// <param name="_ideal_angle"></param>
        public void IdealToGpsResultDebug(double _gps_distance, double _gps_angle, double _ideal_angle)
        {
            this.GlGpsDistanceTxtBox.Text = _gps_distance.ToString("N3");
            this.gps_distance = _gps_distance;

            this.GlGpsHeadingTxtBox.Text = _gps_angle.ToString("N3");
            this.gps_angle = _gps_angle;
            
            this.GlIdealHeadingTxtBox.Text = _ideal_angle.ToString("N3");
            this.ideal_angle = _ideal_angle;
        }

        #endregion

        #region Event

        /// <summary>
        /// load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl1_Load(object sender, EventArgs e)
        {
            this.loaded = true;

            // Yey! .NET Colors can be used directly!
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);

            this.SetupViewport();
        }

        /// <summary>
        /// resize event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }

            this.SetupViewport();
            glControl1.Invalidate();
        }

        /// <summary>
        /// GLcontrol paint event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            // play nice
            if (!this.loaded)
            {
                return;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            float eyeVal = 5.0f;
            Matrix4 lookat = Matrix4.LookAt(-eyeVal * (float)Math.Sin(MathHelper.DegreesToRadians(135)), eyeVal, eyeVal, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();
            GL.Rotate(-90.0f, 1.0f, 0.0f, 0.0f);
            GL.Rotate(180.0f, 0.0f, 0.0f, 1.0f);

            GL.Translate(this.transX, this.transY, this.transZ);
            GL.Rotate(angle, 0.0f, 0.0f, 1.0f);

            this.DrawCoordinates();
            this.DrawGround();
            this.DrawBody();
            this.DrawCrop();
            this.DrawEdge();

            glControl1.SwapBuffers();
            //GL.Flush();
        }

        /// <summary>
        /// keyboard event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.L:
                    this.transX--;
                    break;

                case Keys.J:
                    this.transX++;
                    break;

                case Keys.I:
                    this.transZ--;
                    break;

                case Keys.K:
                    this.transZ++;
                    break;

                case Keys.U:
                    this.transY--;
                    break;

                case Keys.O:
                    this.transY++;
                    break;

                case Keys.A:
                    this.angle--;
                    break;

                case Keys.S:
                    this.angle++;
                    break;

                case Keys.M:
                    this.isManualControl = true;
                    break;
            }

            if (this.isManualControl == true)
            {
                glControl1.Invalidate();
            }
        }

        /// <summary>
        /// exit event
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
