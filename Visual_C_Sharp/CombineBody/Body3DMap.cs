using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace CombineBody
{
    public class Body3DMap
    {
        #region Structs

        public struct body_pose
        {
            // cartesian coordinates system in openGL
            public double X;
            public double Y;
            public double Z;

            // heading angle(azimuth) of harvester
            public double Angle;

            public body_pose(double _X, double _Y, double _Z, double _Angle)
            {
                this.X = _X;
                this.Y = _Y;
                this.Z = _Z;
                this.Angle = _Angle;
            }
        }

        public struct auger_received
        {
            // received ad poteniometer value from combine harvester
            public double DT_AUG_MTR;
            public double DT_AUG_CLD;

            // calculate yaw and roll degree on the world space
            public double Theta_1;
            public double Theta_2;

            // Auger length
            public double Length;

            // height from ground
            public double Height;

            // auger origin to lidar distance
            public double Lidar_length;

            // distance between origin to Link_A
            public double Origin_to_linkA;

            public auger_received(
                double _DT_AUG_MTR, double _DT_AUG_CLD, 
                double _Theta_1, double _Theta_2,
                double _Length, double _Height, double _Lidar_length, double _Origin_to_linkA
                )
            {
                this.DT_AUG_MTR = _DT_AUG_MTR;
                this.DT_AUG_CLD = _DT_AUG_CLD;
                this.Theta_1 = _Theta_1;
                this.Theta_2 = _Theta_2;
                this.Length = _Length;
                this.Height = _Height;
                this.Lidar_length = _Lidar_length;
                this.Origin_to_linkA = _Origin_to_linkA;
            }
        }

        public struct header_right
        {
            public double X;
            public double Y;

            public header_right(double _X, double _Y)
            {
                this.X = _X;
                this.Y = _Y;
            }
        }

        public struct auger_pose
        {
            // Calculated origin position of auger on OpenGL
            public double Origin_X;
            public double Origin_Y;
            public double Origin_Z;

            // Calculated Link_A position of auger on OpenGL
            public double LinkA_X;
            public double LinkA_Y;
            public double LinkA_Z;

            // Calculated spout position of auger on OpenGL
            public double Spout_X;
            public double Spout_Y;
            public double SPout_Z;

            // Calculated lidar position of mounted auger on OpenGL
            public double Lidar_X;
            public double Lidar_Y;
            public double Lidar_Z;

            // auger length debug using calculated auger's position
            public double Length_debug;

            public auger_pose(
                double _Origin_X, double _Origin_Y, double _Origin_Z, 
                double _LinkA_X, double _LinkA_Y, double _LinkA_Z,
                double _Spout_X, double _Spout_Y, double _SPout_Z, 
                double _Lidar_X, double _Lidar_Y, double _Lidar_Z, 
                double _Length_debug
                )
            {
                this.Origin_X = _Origin_X;
                this.Origin_Y = _Origin_Y;
                this.Origin_Z = _Origin_Z;

                this.LinkA_X = _LinkA_X;
                this.LinkA_Y = _LinkA_Y;
                this.LinkA_Z = _LinkA_Z;

                this.Spout_X = _Spout_X;
                this.Spout_Y = _Spout_Y;
                this.SPout_Z = _SPout_Z;
                
                this.Lidar_X = _Lidar_X;
                this.Lidar_Y = _Lidar_Y;
                this.Lidar_Z = _Lidar_Z;
                this.Length_debug = _Length_debug;
            }

        }

        public struct auger_lidar_set
        {
            public double Range;
            public bool Is_divide;

            public auger_lidar_set(double _Range, bool _Is_divide)
            {
                this.Range = _Range;
                this.Is_divide = _Is_divide;
            }
        }

        #endregion

        #region Fields

        private int body_model_index { get; set; }
        private bool is_used_auger { get; set; }
        private List<double> augerA;
        private List<double> augerB;
        private List<double> lidarB;
        private List<double> auger_link_A;

        public List<double> rHeaderA;
        public List<double> rHeaderB;
        public List<double> lHeaderA;
        public List<double> lHeaderB;

        public body_pose _body_pose;
        public auger_received _auger_received;
        public header_right _header_right;
        public auger_pose _auger_pose;
        public auger_lidar_set _auger_lidar_set;
        public int header_potentiometer { get; set; }
        public double header_meter { get; set; }

        private Vector3[] harvested_area_quad;
        private int harvested_area_count { get; set; }
        private bool harvested_area_point_reverse { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="_body_model_index">vy50 is 0 and vy446 is 1.</param>
        /// <param name="_is_used_auger">is used auger</param>
        public Body3DMap(int _body_model_index, bool _is_used_auger)
        {
            this.body_model_index = _body_model_index;
            this.is_used_auger = _is_used_auger;

            this.InitializeMethod();
        }

        #endregion

        #region Body Methods

        /// <summary>
        /// Initialize method
        /// </summary>
        private void InitializeMethod()
        {
            this.header_potentiometer = -1;
            this.header_meter = 0.0;
            this.rHeaderA = new List<double>();
            this.rHeaderB = new List<double>();
            this.lHeaderA = new List<double>();
            this.lHeaderB = new List<double>();

            this.harvested_area_quad = new Vector3[4 * 50000];
            this.harvested_area_count = 0;
            this.harvested_area_point_reverse = false;

            if (this.is_used_auger == true)
            {
                this.augerA = new List<double>();
                this.augerB = new List<double>();
                this.lidarB = new List<double>();
                this.auger_link_A = new List<double>();
                this._auger_lidar_set.Is_divide = false;

                // vy446
                if (this.body_model_index == 1)
                {
                    this._auger_received.Length = 4.05;
                    this._auger_received.Lidar_length = 3.25;
                    this._auger_received.Height = 1.7;
                    this._auger_received.Origin_to_linkA = 0.2;
                }
            }
        }

        /// <summary>
        /// Draw Body - Revised 2014-02-13 by Wonjae Cho
        /// </summary>
        public void DrawBody()
        {
            // arrow
            List<double> arrowLine = this.ConvertPoint(0.0, 2.0, this._body_pose.Angle);
            List<double> arrowA = this.ConvertPoint(0.5, 1.5, this._body_pose.Angle);
            List<double> arrowB = this.ConvertPoint(-0.5, 1.5, this._body_pose.Angle);

            // header
            this.rHeaderA.Clear();
            this.rHeaderB.Clear();
            this.lHeaderA.Clear();
            this.lHeaderB.Clear();

            if (this.is_used_auger == true)
            {
                // auger position (augerA is origin position of auger, augerB is end of position of auger.)
                this.augerA.Clear();
                this.augerB.Clear();
                this.lidarB.Clear();
            }

            // VY50
            if (this.body_model_index == 0)
            {
                double La = 0.45;
                double Lc = 0.6;
                double Lbe = 0.59 + 0.073;
                double swath = 1.4;
                rHeaderA = this.ConvertPoint(Lbe, La, this._body_pose.Angle);
                rHeaderB = this.ConvertPoint(Lbe, La + Lc, this._body_pose.Angle);
                lHeaderA = this.ConvertPoint(Lbe - swath, La, this._body_pose.Angle);
                lHeaderB = this.ConvertPoint(Lbe - swath, La + Lc, this._body_pose.Angle);
                this.header_meter = this.ConvertHeaderPotentiometer(this.body_model_index, this.header_potentiometer);
            }

            // VY446
            if (this.body_model_index == 1)
            {
                double La = 0.15;
                double Lc = 0.83;
                double Lbe = 0.79 + 0.038;
                double swath = 1.4;
                rHeaderA = this.ConvertPoint(Lbe, La, this._body_pose.Angle);
                rHeaderB = this.ConvertPoint(Lbe, La + Lc, this._body_pose.Angle);
                lHeaderA = this.ConvertPoint(Lbe - swath, La, this._body_pose.Angle);
                lHeaderB = this.ConvertPoint(Lbe - swath, La + Lc, this._body_pose.Angle);
                this.header_meter = this.ConvertHeaderPotentiometer(this.body_model_index, this.header_potentiometer);

                if (this.is_used_auger == true)
                {
                    double auger_transverse_distance = 0.7;
                    double auger_longitudinal_start = -2.25;
                    this.augerA = this.ConvertPoint(auger_transverse_distance, auger_longitudinal_start, this._body_pose.Angle);
                    this.ConvertPotentiometerToDegree(this._auger_received.DT_AUG_MTR, this._auger_received.DT_AUG_CLD);
                    this.augerB = this.ConvertAugerPoint(0.0, this._auger_received.Length, this._body_pose.Angle, this._auger_received.Theta_1, this._auger_received.Theta_2);
                    this.lidarB = this.ConvertAugerPoint(0.0, this._auger_received.Lidar_length, this._body_pose.Angle, this._auger_received.Theta_1, this._auger_received.Theta_2);
                    this.auger_link_A = this.ConvertAugerPoint(0.0, this._auger_received.Origin_to_linkA, this._body_pose.Angle, 90.0 + this._auger_received.Theta_1, 0.0);
                }
            }

            GL.LineWidth(3.0f);
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Black);

            // arrow
            GL.Vertex3(this._body_pose.X, this._body_pose.Y, 0.0);
            GL.Vertex3(this._body_pose.X, this._body_pose.Y, 3.0);

            GL.Vertex3(this._body_pose.X, this._body_pose.Y, 2.5);
            GL.Vertex3(this._body_pose.X + arrowLine[0], this._body_pose.Y + arrowLine[1], 2.5);

            GL.Vertex3(this._body_pose.X + arrowLine[0], this._body_pose.Y + arrowLine[1], 2.5);
            GL.Vertex3(this._body_pose.X + arrowA[0], this._body_pose.Y + arrowA[1], 2.5);

            GL.Vertex3(this._body_pose.X + arrowLine[0], this._body_pose.Y + arrowLine[1], 2.5);
            GL.Vertex3(this._body_pose.X + arrowB[0], this._body_pose.Y + arrowB[1], 2.5);

            // end of right header
            this._header_right.X = this._body_pose.X + rHeaderB[0];
            this._header_right.Y = this._body_pose.Y + rHeaderB[1];

            GL.Vertex3(this._body_pose.X + rHeaderA[0], this._body_pose.Y + rHeaderA[1], this.header_meter);
            GL.Vertex3(this._body_pose.X + rHeaderB[0], this._body_pose.Y + rHeaderB[1], this.header_meter);

            GL.Vertex3(this._body_pose.X + lHeaderA[0], this._body_pose.Y + lHeaderA[1], this.header_meter);
            GL.Vertex3(this._body_pose.X + lHeaderB[0], this._body_pose.Y + lHeaderB[1], this.header_meter);

            GL.End();

            if (this.is_used_auger == true)
            {
                GL.LineWidth(3.0f);
                GL.Begin(BeginMode.Lines);
                GL.Color3(Color.Black);

                // auger position
                this._auger_pose.Origin_X = this._body_pose.X + this.augerA[0];
                this._auger_pose.Origin_Y = this._body_pose.Y + this.augerA[1];
                this._auger_pose.Origin_Z = this._auger_received.Height;
                
                this._auger_pose.LinkA_X = this._auger_pose.Origin_X + this.auger_link_A[0];
                this._auger_pose.LinkA_Y = this._auger_pose.Origin_Y + this.auger_link_A[1];
                this._auger_pose.LinkA_Z = this._auger_pose.Origin_Z;

                this._auger_pose.Spout_X = this._auger_pose.LinkA_X + this.augerB[0];
                this._auger_pose.Spout_Y = this._auger_pose.LinkA_Y + this.augerB[1];
                this._auger_pose.SPout_Z = this._auger_pose.LinkA_Z + this.augerB[2];

                this._auger_pose.Lidar_X = this._auger_pose.LinkA_X + lidarB[0];
                this._auger_pose.Lidar_Y = this._auger_pose.LinkA_Y + lidarB[1];
                this._auger_pose.Lidar_Z = this._auger_pose.LinkA_Z + lidarB[2];

                // divide height for draw 3d points
                if (this._auger_lidar_set.Is_divide == false)
                {
                    this._auger_lidar_set.Range = this._auger_pose.SPout_Z / 7.0;
                    this._auger_lidar_set.Is_divide = true;
                }

                // auger length distance
                this._auger_pose.Length_debug = Math.Sqrt(
                    Math.Pow((this._auger_pose.Spout_X - this._auger_pose.LinkA_X), 2.0) +
                    Math.Pow((this._auger_pose.Spout_Y - this._auger_pose.LinkA_Y), 2.0) +
                    Math.Pow((this._auger_pose.SPout_Z - this._auger_pose.LinkA_Z), 2.0));

                // draw ground to auger origin. 
                GL.Vertex3(this._auger_pose.Origin_X, this._auger_pose.Origin_Y, 0.0);
                GL.Vertex3(this._auger_pose.Origin_X, this._auger_pose.Origin_Y, this._auger_pose.Origin_Z);

                // draw auger origin to auger's Link_A 
                GL.Vertex3(this._auger_pose.Origin_X, this._auger_pose.Origin_Y, this._auger_pose.Origin_Z);
                GL.Vertex3(this._auger_pose.LinkA_X, this._auger_pose.LinkA_Y, this._auger_pose.LinkA_Z);

                // draw auger' link to auger spout.
                GL.Vertex3(this._auger_pose.LinkA_X, this._auger_pose.LinkA_Y, this._auger_pose.LinkA_Z);
                GL.Vertex3(this._auger_pose.Spout_X, this._auger_pose.Spout_Y, this._auger_pose.SPout_Z);


                GL.End();
            }

            // GPS circle
            GL.LineWidth(3.0f);
            GL.Begin(BeginMode.LineLoop);
            GL.Color3(Color.Black);
            for (int i = 0; i <= 300; i++)
            {
                double radius = 0.1;
                double angle = 2.0 * Math.PI * i / 300;
                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);
                GL.Vertex3(this._body_pose.X + x, this._body_pose.Y + y, 2.5);
            }
            GL.End();
        }

        public double harvested_quad_area { get; set; }
        public int harvested_quad_index { get; set; }

        /// <summary>
        /// 2014-10-04, Wonjae Cho
        /// http://darkpgmr.tistory.com/86
        /// Calculate harvested area
        /// </summary>
        private void CalculateHarvestedArea()
        {
            if ((this.harvested_area_count % 2) == 0)
            {
                this.harvested_quad_index = this.harvested_area_count - 1;

                double x1x0 = this.harvested_area_quad[harvested_quad_index - 2].X - this.harvested_area_quad[harvested_quad_index - 3].X;
                double y3y0 = this.harvested_area_quad[harvested_quad_index].Y - this.harvested_area_quad[harvested_quad_index - 3].Y;
                double x3x0 = this.harvested_area_quad[harvested_quad_index].X - this.harvested_area_quad[harvested_quad_index - 3].X;
                double y1y0 = this.harvested_area_quad[harvested_quad_index - 2].Y - this.harvested_area_quad[harvested_quad_index - 3].Y;

                double triangle1 = Math.Abs((x1x0 * y3y0) - (x3x0 * y1y0)) / 2.0;
                this.harvested_quad_area += triangle1;

                double x2x1 = this.harvested_area_quad[harvested_quad_index - 1].X - this.harvested_area_quad[harvested_quad_index - 2].X;
                double y3y1 = this.harvested_area_quad[harvested_quad_index].Y - this.harvested_area_quad[harvested_quad_index - 2].Y;
                double x3x1 = this.harvested_area_quad[harvested_quad_index].X - this.harvested_area_quad[harvested_quad_index - 2].X;
                double y2y1 = this.harvested_area_quad[harvested_quad_index - 1].Y - this.harvested_area_quad[harvested_quad_index - 2].Y;

                double triangle2 = Math.Abs((x2x1 * y3y1) - (x3x1 * y2y1)) / 2.0;
                this.harvested_quad_area += triangle2;
            }
            else
            {
            }
        }

        /// <summary>
        /// Draw Harvested Area
        /// </summary>
        /// <param name="_ran_start"></param>
        /// <param name="_ran_end"></param>
        public void DrawHarvestedArea(bool _ran_start, bool _ran_end)
        {
            if ((_ran_start == true) && (_ran_end == false))
            {
                // add header position
                if (this.harvested_area_point_reverse == false)
                {
                    this.harvested_area_quad[this.harvested_area_count] = new Vector3((float)this._body_pose.X + (float)this.lHeaderB[0], (float)this._body_pose.Y + (float)this.lHeaderB[1], (float)0.0);
                    this.harvested_area_count++;
                    this.harvested_area_quad[this.harvested_area_count] = new Vector3((float)this._body_pose.X + (float)this.rHeaderB[0], (float)this._body_pose.Y + (float)this.rHeaderB[1], (float)0.0);
                    this.harvested_area_count++;
                }
                else
                {
                    this.harvested_area_quad[this.harvested_area_count] = new Vector3((float)this._body_pose.X + (float)this.rHeaderB[0], (float)this._body_pose.Y + (float)this.rHeaderB[1], (float)0.0);
                    this.harvested_area_count++;
                    this.harvested_area_quad[this.harvested_area_count] = new Vector3((float)this._body_pose.X + (float)this.lHeaderB[0], (float)this._body_pose.Y + (float)this.lHeaderB[1], (float)0.0);
                    this.harvested_area_count++;
                }

                // reverse change
                if (this.harvested_area_point_reverse == false)
                {
                    this.harvested_area_point_reverse = true;
                }
                else
                {
                    this.harvested_area_point_reverse = false;
                }

                // Draw area
                if (this.harvested_area_count > 3)
                {
                    // calculate haravested area
                    this.CalculateHarvestedArea();

                    // Vertex array mode
                    GL.EnableClientState(ArrayCap.VertexArray);
                    GL.VertexPointer(3, VertexPointerType.Float, 0, this.harvested_area_quad);
                    GL.Color3(Color.Orange);
                    GL.DrawArrays(BeginMode.Polygon, 0, this.harvested_area_count);
                    GL.DisableClientState(ArrayCap.VertexArray);
                }
            }
            else
            {
                // initialization
                this.harvested_area_quad.Initialize();
                this.harvested_area_count = 0;
                this.harvested_area_point_reverse = false;
            }
        }

        /// <summary>
        /// convert points using heading angle
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_angle"></param>
        /// <returns></returns>
        public List<double> ConvertPoint(double _x, double _y, double _angle)
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
        /// Convert potentiometer to meter of header height
        /// </summary>
        /// <param name="_body_model"></param>
        /// <param name="_header_potentiometer"></param>
        /// <returns></returns>
        public double ConvertHeaderPotentiometer(int _body_model, int _header_potentiometer)
        {
            double convert_meter = 0.0;

            if (_header_potentiometer == -1)
            {
                convert_meter = 0.0;
            }
            else
            {
                if (_body_model == 0)
                {
                    convert_meter = ((double)_header_potentiometer - 85.734) / 169.24;
                }

                else if (_body_model == 1)
                {
                    convert_meter = ((double)_header_potentiometer - 309.47) / 792.01;
                }
            }

            return convert_meter;
        }

        #endregion

        #region auger methods

        /// <summary>
        /// Convert Potentiometer(AD) to Drgree
        /// </summary>
        /// <param name="_DT_AUG_MTR"></param>
        /// <param name="_DT_AUG_CLD"></param>
        private void ConvertPotentiometerToDegree(double _DT_AUG_MTR, double _DT_AUG_CLD)
        {
            this._auger_received.Theta_1 = -0.3896 * _DT_AUG_MTR + 234.16;
            this._auger_received.Theta_2 = -0.0872 * _DT_AUG_CLD + 64.535;
        }

        /// <summary>
        /// Convert Auger Position
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_angle"></param>
        /// <param name="_augerTheta1"></param>
        /// <param name="_augerTheta2"></param>
        /// <returns></returns>
        private List<double> ConvertAugerPoint(double _x, double _y, double _angle, double _augerTheta1, double _augerTheta2)
        {
            List<double> points = new List<double>();
            double x1 = _y;
            double y1 = _x;
            double theta1 = (_angle - 270.0 + (180.0 - _augerTheta1)) * (Math.PI / 180);
            double theta2 = _augerTheta2 * (Math.PI / 180);
            double x2 = (x1 * Math.Cos(theta2)) - (y1 * Math.Sin(theta2));
            double y2 = (x1 * Math.Sin(theta2)) + (y1 * Math.Cos(theta2));
            double rotX = (Math.Sin(theta1) * x2) + (Math.Cos(theta1) * y1);
            double rotY = (Math.Cos(theta1) * x2) - (Math.Sin(theta1) * y1);
            double rotZ = y2;

            points.Add(rotX);
            points.Add(rotY);
            points.Add(rotZ);

            return points;
        }

        #endregion

        #region Setting OpenGL methods

        /// <summary>
        /// Draw Initialize setting
        /// </summary>
        /// <param name="_transX"></param>
        /// <param name="_transY"></param>
        /// <param name="_transZ"></param>
        /// <param name="_angle"></param>
        public void DrawInitialize(float _transX, float _transY, float _transZ, double _angle)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            float eyeVal = 5.0f;
            Matrix4 lookat = Matrix4.LookAt(-eyeVal * (float)Math.Sin(MathHelper.DegreesToRadians(135)), eyeVal, eyeVal, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();
            GL.Rotate(-90.0f, 1.0f, 0.0f, 0.0f);
            GL.Rotate(180.0f, 0.0f, 0.0f, 1.0f);

            GL.Translate(_transX, _transY, _transZ);
            GL.Rotate(_angle, 0.0f, 0.0f, 1.0f);
        }

        /// <summary>
        /// Setup view port
        /// </summary>
        public void SetupViewport(GLControl _glControl)
        {
            int w = _glControl.Width;
            int h = _glControl.Height;

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
        public void DrawCoordinates()
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
        public void DrawGround()
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

        #endregion
    }
}

