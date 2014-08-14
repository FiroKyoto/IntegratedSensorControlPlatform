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
using OpenCvSharp;
using CombineBody;
using Algorithm;

namespace IidaLabVy446
{
    public partial class AugerOpenGlForm : Form
    {
        #region Fields

        private CombineBody.Body3DMap _map;
        private Algorithm.Auger _auger;

        private bool read_from_file { get; set; }

        /// <summary>
        /// gets or sets combine model index
        /// </summary>
        private int bodyModelIndex { get; set; }

        /// <summary>
        /// is loaded?
        /// </summary>
        private bool loaded { get; set; }

        /// <summary>
        /// manual key control
        /// </summary>
        private bool isManualControl { get; set; }

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

        private int read_count { get; set; }
        private float _tmX { get; set; }
        private float _tmY { get; set; }
        private float _tmZ { get; set; }
        private double _heading_angle { get; set; }
        private double _body_speed { get; set; }
        private double DT_AUG_MTR { get; set; }
        private double DT_AUG_CLD { get; set; }

        private SickLidar.Graph _graphXZ;

        private bool is_initialize_save_data = false;
        private bool is_draw_sqaure_in_image = false;
        private bool is_calculated_destination_info = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_bodyModelIndex"></param>
        /// <param name="_read_from_file"></param>
        public AugerOpenGlForm(int _bodyModelIndex, bool _read_from_file)
        {
            InitializeComponent();

            this._map = new Body3DMap(_bodyModelIndex, true);
            this._auger = new Auger(60.0, 0.0, 1081, 400, 400);

            // initialization OpenGl variable
            this.bodyModelIndex = _bodyModelIndex;
            this.read_from_file = _read_from_file;
            this.isManualControl = false;
            this.loaded = false;
            this.transX = 0;
            this.transY = 0;
            this.transZ = 0;
            this.angle = 0.0;

            this._graphXZ = new SickLidar.Graph();
            this._graphXZ.CreateHokuyoGraph(this.zg1, "Cartesian Coordinates System, XZ Plane", "X(m)", "Z(m)");
        }

        #endregion

        #region Processing Methods

        private int AD_FEED_M { get; set; }
        private bool is_set_first_pose = false;
        private double first_pose_X { get; set; }
        private double first_pose_Y { get; set; }

        /// <summary>
        /// Body information debug method
        /// </summary>
        /// <param name="_readCnt"></param>
        /// <param name="_tmX"></param>
        /// <param name="_tmY"></param>
        /// <param name="_tmZ"></param>
        /// <param name="_heading_angle"></param>
        /// <param name="_body_speed"></param>
        /// <param name="_DT_AUG_MTR"></param>
        /// <param name="_DT_AUG_CLD"></param>
        public void BodyInformation(int _readCnt, double _tmX, double _tmY, double _tmZ, double _heading_angle, double _body_speed, double _DT_AUG_MTR, double _DT_AUG_CLD, int _AD_FEED_M)
        {
            this.GlReadCntTxtBox.Text = Convert.ToString(_readCnt);
            this.read_count = _readCnt;
            //this.GlCurCntTxtBox.Text = Convert.ToString(this.cropCnt);
            this.GlTmXTxtBox.Text = _tmX.ToString("N3");
            this._tmX = (float)_tmX;
            this.GlTmYTxtBox.Text = _tmY.ToString("N3");
            this._tmY = (float)_tmY;
            this.GlTmZTxtBox.Text = _tmZ.ToString("N3");
            this._tmZ = (float)_tmZ;
            this.GlBodyHeadingTxtBox.Text = _heading_angle.ToString("N3");
            this._heading_angle = _heading_angle;
            this.GlBodySpeedTxtBox.Text = _body_speed.ToString("N3");
            this._body_speed = _body_speed;
            //this.GlHarvestTimesTxtBox.Text = Convert.ToString(this.harvest_times_count);
            this.DT_AUG_MTR = _DT_AUG_MTR;
            this.DT_AUG_CLD = _DT_AUG_CLD;
            this.GlBodyAD_FEED_MTxtBox.Text = _AD_FEED_M.ToString("N3");
            this.AD_FEED_M = _AD_FEED_M;

            if (this.is_set_first_pose == false)
            {
                this.first_pose_X = _tmX;
                this.first_pose_Y = _tmY;

                this.is_set_first_pose = true;
            }
        }

        /// <summary>
        /// Auger Information Debug Method
        /// </summary>
        private void AugerInformation()
        {
            this.GlAugerLengthTxtBox.Text = this._map._auger_pose.Length_debug.ToString("N3");
            this.GlYawTxtBox.Text = this._map._auger_received.Theta_1.ToString("N3");
            this.GlRollTxtBox.Text = this._map._auger_received.Theta_2.ToString("N3");
            this.GlAugerOriginXTxtBox.Text = this._map._auger_pose.Origin_X.ToString("N3");
            this.GlAugerOriginYTxtBox.Text = this._map._auger_pose.Origin_Y.ToString("N3");
            this.GlAugerOriginZTxtBox.Text = this._map._auger_pose.Origin_Z.ToString("N3");
            this.GlAugerSpoutXTxtBox.Text = this._map._auger_pose.Spout_X.ToString("N3");
            this.GlAugerSpoutYTxtBox.Text = this._map._auger_pose.Spout_Y.ToString("N3");
            this.GlAugerSpoutZTxtBox.Text = this._map._auger_pose.SPout_Z.ToString("N3");
        }

        /// <summary>
        /// Steering Information Debug
        /// </summary>
        /// <param name="_current_state"></param>
        public void SteeringInformation(string _current_state)
        {
            this.GlSteerStateMsgTxtBox.Text = _current_state;
        }

        /// <summary>
        /// Save Revised body position data to txt file.
        /// </summary>
        /// <param name="_is_save_auger_data"></param>
        public void SaveData(bool _is_save_auger_data)
        {
            if ((this.is_initialize_save_data == false) && (_is_save_auger_data == true))
            {
                //this.save_data_to_txt = new StreamWriter("RevisedBodyData.txt");
                this.is_initialize_save_data = true;
            }
            else if ((this.is_initialize_save_data == true) && (_is_save_auger_data == true))
            {
                //string data = this.read_count + " " + this._tmX + " " + this._tmY;
                //this.save_data_to_txt.WriteLine(data);
            }
            else if ((this.is_initialize_save_data == true) && (_is_save_auger_data == false))
            {
                //this.save_data_to_txt.Close();

                // draw square in image
                //this.DrawSquareInImage();
            }
        }

        /// <summary>
        /// Draw square in image
        /// </summary>
        public void DrawSquareInImage()
        {
            if (this.is_draw_sqaure_in_image == false)
            {
                this._auger.DrawSquareInImage();
                this.pBoxIpl1.ImageIpl = this._auger.top_view_image;
                this.is_draw_sqaure_in_image = true;

                if (this.read_from_file == true)
                {
                    glControl1.Invalidate();
                }
            }
        }


        /// <summary>
        /// Convert Hokuyo lidar data to 3D points of world coordinates system.
        /// </summary>
        /// <param name="_org_list_data"></param>
        /// <param name="_read_index_to_radian"></param>
        public void ConvertLidarPoints(List<int> _org_list_data, List<double> _read_index_to_radian)
        {
            this._auger.ConvertLidarPoints(_org_list_data, _read_index_to_radian, this._map._body_pose, this._map._auger_received, this._map._auger_pose, this._map._auger_lidar_set);
        }

        /// <summary>
        /// Travel distance of combine harvester
        /// </summary>
        /// <returns></returns>
        public double TravelDistance()
        {
            double result = Math.Sqrt(Math.Pow((this._tmX - this.first_pose_X), 2.0) + Math.Pow((this._tmY - this.first_pose_Y), 2.0));
            this.GlSteerTravelDistanceTxtBox.Text = Convert.ToString(result);
            return result;
        }

        /// <summary>
        /// Revised 2014-02-25
        /// Distance between target and current of auger
        /// </summary>
        /// <returns></returns>
        public double DistanceBetweenTargetAndCurrentOfAuger()
        {
            double result = Math.Sqrt(
                Math.Pow((this._map._auger_pose.LinkA_X - this._auger._auger_final_pose.Intersection_Final_X), 2.0) +
                Math.Pow((this._map._auger_pose.LinkA_Y - this._auger._auger_final_pose.Intersection_Final_Y), 2.0)
                );
            GlSteerAugerDistanceTxtBox.Text = Convert.ToString(result);
            return result;
        }

        /// <summary>
        /// Draw Body - Revised 2014-01-24 by Wonjae Cho
        /// if _bodyModel is 0 then body model is vy50.
        /// else if _bodyModel is 1 then body model is vy446.
        /// </summary>
        private void DrawBody()
        {
            this._map._body_pose.X = this._tmX;
            this._map._body_pose.Y = this._tmY;
            this._map._body_pose.Z = this._tmZ;
            this._map._body_pose.Angle = this._heading_angle;
            this._map._auger_received.DT_AUG_MTR = this.DT_AUG_MTR;
            this._map._auger_received.DT_AUG_CLD = this.DT_AUG_CLD;

            this._map.DrawBody();

            this.AugerInformation();
        }

        /// <summary>
        /// Revised 2014-03-19
        /// Draw target path
        /// </summary>
        private void DrawTargetPath()
        {
            if (this.read_count > 10)
            {
                this._auger.CreateIdealTargetPath(
                    this._map._body_pose.X, this._map._body_pose.Y, this._map._body_pose.Z, this._map._body_pose.Angle,
                    this._map._auger_pose.LinkA_X, this._map._auger_pose.LinkA_Y, this._map._auger_pose.LinkA_Z);
            }
        }

        public bool is_grain_tank_detection = false;
        public ushort usCmdLRPos { get; set; }
        public ushort usCmdUDPos { get; set; }

        /// <summary>
        /// Draw grain tank edge
        /// </summary>
        private void DrawGrainTank()
        {
            if (this._auger.is_grain_tank_edge == true)
            {
                this.is_grain_tank_detection = true;
                this._auger.DrawGrainTankEdge();
                this.GlSteerProcessingSpeedTxtBox.Text = this._auger.processing_time;

                if (this.is_calculated_destination_info == false)
                {
                    // destination point
                    this.GlDestinationPoseXTxtBox.Text = this._auger._auger_final_pose.Destination_X.ToString("N3");
                    this.GlDestinationPoseYTxtBox.Text = this._auger._auger_final_pose.Destination_Y.ToString("N3");
                    this.GlDestinationPoseZTxtBox.Text = this._auger._auger_final_pose.Destination_Z.ToString("N3");

                    // calculate destination Roll degree
                    this._auger.CalculateDestinationDegrees(this._map._auger_received.Length, this._map._auger_received.Height, this.AD_FEED_M);

                    if (this._auger._auger_final_pose.Is_Calculated_Radius == true)
                    {
                        this.GlDestinationRollTxtBox.Text = this._auger._auger_final_pose.Roll_Degree.ToString("N3");
                        this.GlDestinationRadiusTxtBox.Text = this._auger._auger_final_pose.Radius.ToString("N3");
                        this.GlDestinationPerpendicularTxtBox.Text = this._auger._auger_final_pose.Perpendicular_Distance.ToString("N3");
                        this.GlDestinationADYawTxtBox.Text = this._auger._auger_final_pose.usCmdLRPos.ToString("N3");
                        this.usCmdLRPos = this._auger._auger_final_pose.usCmdLRPos;
                        this.GlDestinationADRollTxtBox.Text = this._auger._auger_final_pose.usCmdUDPos.ToString("N3");
                        this.usCmdUDPos = this._auger._auger_final_pose.usCmdUDPos;

                        if (this._auger._auger_final_pose.Is_Find_Intersection == true)
                        {
                            this._auger.DecisionIntersectionPoint(this._map._auger_pose.Origin_X, this._map._auger_pose.Origin_Y);

                            this.GlDestinationYawTxtBox.Text = this._auger._auger_final_pose.Yaw_Degree.ToString("N3");
                            this.GlDestinationIntersectionXTxtBox.Text = this._auger._auger_final_pose.Intersection_Final_X.ToString("N3");
                            this.GlDestinationIntersectionYTxtBox.Text = this._auger._auger_final_pose.Intersection_Final_Y.ToString("N3");
                        }
                    }
                    
                    this.is_calculated_destination_info = true;
                }

                // distance between auger spout point to destination point
                this._auger.destination_to_auger_distance = this._auger.DistanceBetween3DPoints(
                    this._map._auger_pose.Spout_X, this._map._auger_pose.Spout_Y, this._map._auger_pose.SPout_Z,
                    this._auger._auger_final_pose.Destination_X, this._auger._auger_final_pose.Destination_Y, this._auger._auger_final_pose.Destination_Z
                    );

                this.GlDistanceAugerToDestinationTxtBox.Text = this._auger.destination_to_auger_distance.ToString("N3");

                // draw radius
                if (this._auger._auger_final_pose.Is_Calculated_Radius == true)
                {
                    this._auger.DrawRadius();

                    if (this._auger._auger_final_pose.Is_Find_Intersection == true)
                    {
                        this._auger.DrawIntersection(0.0, this._map._auger_received.Length);
                        this.GlDestinationSimulatedAugerLengthTxtBox.Text = this._auger.simulated_auger_length.ToString("N3");
                    }
                }
            }
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
        /// Form Update
        /// </summary>
        public void GlUpdate()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // glControl invalidate
            glControl1.Invalidate();

            // draw top view image
            this.pBoxIpl1.ImageIpl = this._auger.top_view_image;

            // draw Converted Hokuyo lidar data to Catesian Coordinates System(XZ)
            this._graphXZ.UpdateHokuyoGraph(this._auger._xzPoints, zg1);

            watch.Stop();
            this.GlProcessingTimeStatusLabel.Text =
                watch.Elapsed.TotalMilliseconds.ToString("N3") + "[m/s]";
        }

        #endregion

        #region OpenGL Event

        /// <summary>
        /// OpenGL Load
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
        /// OpenGL Resize
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
        /// OpenGL Paint
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

            // draw origin coordinates
            this.DrawCoordinates();
            
            // draw ground
            this.DrawGround();
            
            // draw combine body.
            this.DrawBody();
            
            // draw lidar points.
            this._auger.DrawLidarPoints();

            // draw ideal target path.
            this.DrawTargetPath();

            // draw grain tank edge.
            this.DrawGrainTank();

            glControl1.SwapBuffers();
            //GL.Flush();
        }

        /// <summary>
        /// OpenGL KeyDown
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
        /// Exit event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Auto Detection event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DrawSquareInImage();
            this.toolStripStatusLabel3.Text = Convert.ToString(this._auger.processing_time);
        }

        /// <summary>
        /// Save image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int color_number = this.SaveImageComboBox.SelectedIndex;

            if (color_number == 0)
            {
                this.pBoxIpl1.ImageIpl.SaveImage("Top_view.jpg");
            }
            else
            {
                this._auger.SaveImage(color_number);
            }
        }

        #endregion

    }
}
