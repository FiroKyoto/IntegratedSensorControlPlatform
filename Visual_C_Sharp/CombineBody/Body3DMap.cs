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

            public auger_received(double _DT_AUG_MTR, double _DT_AUG_CLD, double _Theta_1, double _Theta_2, double _Length, double _Height, double _Lidar_length)
            {
                this.DT_AUG_MTR = _DT_AUG_MTR;
                this.DT_AUG_CLD = _DT_AUG_CLD;
                this.Theta_1 = _Theta_1;
                this.Theta_2 = _Theta_2;
                this.Length = _Length;
                this.Height = _Height;
                this.Lidar_length = _Lidar_length;
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

            public auger_pose(double _Origin_X, double _Origin_Y, double _Origin_Z, double _Spout_X, double _Spout_Y, double _SPout_Z, double _Lidar_X, double _Lidar_Y, double _Lidar_Z, double _Length_debug)
            {
                this.Origin_X = _Origin_X;
                this.Origin_Y = _Origin_Y;
                this.Origin_Z = _Origin_Z;
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

        public body_pose _body_pose;
        public auger_received _auger_received;
        public header_right _header_right;
        public auger_pose _auger_pose;
        public auger_lidar_set _auger_lidar_set;

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

        private void InitializeMethod()
        {
            if (this.is_used_auger == true)
            {
                this.augerA = new List<double>();
                this.augerB = new List<double>();
                this.lidarB = new List<double>();
                this._auger_lidar_set.Is_divide = false;

                // vy446
                if (this.body_model_index == 1)
                {
                    this._auger_received.Length = 3.8;
                    this._auger_received.Lidar_length = 3.25;
                    this._auger_received.Height = 1.7;
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

            // end of right header
            List<double> rHeaderA = new List<double>();
            List<double> rHeaderB = new List<double>();

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
                rHeaderA = this.ConvertPoint(Lbe, La, this._body_pose.Angle);
                rHeaderB = this.ConvertPoint(Lbe, La + Lc, this._body_pose.Angle);
            }

            // VY446
            if (this.body_model_index == 1)
            {
                double La = 0.15;
                double Lc = 0.83;
                double Lbe = 0.79 + 0.038;
                rHeaderA = this.ConvertPoint(Lbe, La, this._body_pose.Angle);
                rHeaderB = this.ConvertPoint(Lbe, La + Lc, this._body_pose.Angle);

                if (this.is_used_auger == true)
                {
                    double auger_transverse_distance = 0.79 + 0.038;
                    double auger_longitudinal_start = -2.0;
                    augerA = this.ConvertPoint(auger_transverse_distance, auger_longitudinal_start, this._body_pose.Angle);
                    this.ConvertPotentiometerToDegree(this._auger_received.DT_AUG_MTR, this._auger_received.DT_AUG_CLD);
                    augerB = this.ConvertAugerPoint(0.0, this._auger_received.Length, this._body_pose.Angle, this._auger_received.Theta_1, this._auger_received.Theta_2);
                    lidarB = this.ConvertAugerPoint(0.0, this._auger_received.Lidar_length, this._body_pose.Angle, this._auger_received.Theta_1, this._auger_received.Theta_2);
                }
            }

            GL.LineWidth(3.0f);
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Yellow);

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

            GL.Vertex3(this._body_pose.X + rHeaderA[0], this._body_pose.Y + rHeaderA[1], 0.0);
            GL.Vertex3(this._body_pose.X + rHeaderB[0], this._body_pose.Y + rHeaderB[1], 0.0);

            if (this.is_used_auger == true)
            {
                // auger position
                this._auger_pose.Origin_X = this._body_pose.X + augerA[0];
                this._auger_pose.Origin_Y = this._body_pose.Y + augerA[1];
                this._auger_pose.Origin_Z = this._auger_received.Height;
                this._auger_pose.Spout_X = this._auger_pose.Origin_X + augerB[0];
                this._auger_pose.Spout_Y = this._auger_pose.Origin_Y + augerB[1];
                this._auger_pose.SPout_Z = this._auger_pose.Origin_Z + augerB[2];
                this._auger_pose.Lidar_X = this._auger_pose.Origin_X + lidarB[0];
                this._auger_pose.Lidar_Y = this._auger_pose.Origin_Y + lidarB[1];
                this._auger_pose.Lidar_Z = this._auger_pose.Origin_Z + lidarB[2];

                // divide height for draw 3d points
                if (this._auger_lidar_set.Is_divide == false)
                {
                    this._auger_lidar_set.Range = this._auger_pose.SPout_Z / 7.0;
                    this._auger_lidar_set.Is_divide = true;
                }

                // auger length distance
                this._auger_pose.Length_debug = Math.Sqrt(
                    Math.Pow((this._auger_pose.Spout_X - this._auger_pose.Origin_X), 2.0) +
                    Math.Pow((this._auger_pose.Spout_Y - this._auger_pose.Origin_Y), 2.0) +
                    Math.Pow((this._auger_pose.SPout_Z - this._auger_pose.Origin_Z), 2.0));

                GL.Vertex3(this._auger_pose.Origin_X, this._auger_pose.Origin_Y, this._auger_pose.Origin_Z);
                GL.Vertex3(this._auger_pose.Spout_X, this._auger_pose.Spout_Y, this._auger_pose.SPout_Z);
            }

            GL.End();

            // GPS circle
            GL.Begin(BeginMode.LineLoop);
            for (int i = 0; i <= 300; i++)
            {
                double angle = 2 * Math.PI * i / 300;
                double x = Math.Cos(angle);
                double y = Math.Sin(angle);
                GL.Vertex3(this._body_pose.X + x, this._body_pose.Y + y, 2.5);
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
            double theta1 = (_angle - 270.0 + _augerTheta1) * (Math.PI / 180);
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
    }
}

