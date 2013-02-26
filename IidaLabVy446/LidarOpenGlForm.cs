
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

    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.OpenGL;
    using SickLidar;

    public partial class LidarOpenGlForm : Form
    {
        #region fields

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

        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public LidarOpenGlForm()
        {
            InitializeComponent();
            this.loaded = false;
            this.transX = 0;
            this.transY = 0;
            this.transZ = 0;

            //this.crop = new List<SickLidar.CartesianPoint>();
            cropPoints = new Vector3[361 * 5000];
            groundPoints = new Vector3[361 * 5000];
            this.cropCnt = 0;
            this.cropOffset = 0;
            this.groundOffset = 0;
        }

        #endregion

        #region Methods

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
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.LightGray);
            for (int i = 0; i <= 100; i++)
            {
                GL.Vertex3(-100, (float)i, 0);
                GL.Vertex3(100, (float)i, 0);

                GL.Vertex3(-100, -(float)i, 0);
                GL.Vertex3(100, -(float)i, 0);

                GL.Vertex3((float)i, 100, 0);
                GL.Vertex3((float)i, -100, 0);

                GL.Vertex3(-(float)i, 100, 0);
                GL.Vertex3(-(float)i, -100, 0);

            }
            GL.End();
        }

        /// <summary>
        /// add crop points to list
        /// </summary>
        /// <param name="_list"></param>
        public void AddCrop(List<SickLidar.CartesianPoint> _list, int _glIndex)
        {
            for (int i = 0; i < _glIndex; i++)
            {
                //this.crop.Add(new SickLidar.CartesianPoint(_list[i].x, _list[i].y, _list[i].z));
                cropPoints[i + this.cropOffset] = new Vector3((float)_list[i].x, (float)_list[i].y, (float)_list[i].z);
            }
            this.cropOffset += _glIndex;

            int gCnt = 0;
            for (int i = _glIndex; i < _list.Count; i++)
            {
                groundPoints[gCnt + this.groundOffset] = new Vector3((float)_list[i].x, (float)_list[i].y, (float)_list[i].z);
                gCnt++;
            }
            this.groundOffset += _list.Count - _glIndex;

            this.cropCnt++;

            glControl1.Invalidate();
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
            GL.ClearColor(Color.White);
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
            Matrix4 lookat = Matrix4.LookAt(-eyeVal * (float)Math.Sin(MathHelper.DegreesToRadians(45)), eyeVal, eyeVal, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();
            GL.Rotate(-90.0f, 1.0f, 0.0f, 0.0f);

            GL.Translate(this.transX, this.transY, this.transZ);
            GL.Rotate(angle, 0.0f, 0.0f, 1.0f);

            this.DrawCoordinates();
            this.DrawGround();
            this.DrawCrop();

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
            if (e.KeyCode == Keys.L)
            {
                this.transX--;
            }

            if (e.KeyCode == Keys.J)
            {
                this.transX++;
            }

            if (e.KeyCode == Keys.I)
            {
                this.transZ--;
            }

            if (e.KeyCode == Keys.K)
            {
                this.transZ++;
            }

            if (e.KeyCode == Keys.U)
            {
                this.transY--;
            }

            if (e.KeyCode == Keys.O)
            {
                this.transY++;
            }

            if (e.KeyCode == Keys.N)
            {
                this.angle--;
            }

            if (e.KeyCode == Keys.M)
            {
                this.angle++;
            }

            //glControl1.Invalidate();
        }
        #endregion



    }
}
