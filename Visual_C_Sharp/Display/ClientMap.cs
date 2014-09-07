using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using Algorithm;

namespace Display
{
    public partial class ClientMap : Form
    {
        private Algorithm.TargetPath target_path;

        #region Fields

        /// <summary>
        /// GraphPane for zedGraph
        /// </summary>
        private GraphPane myPane;

        private bool is_initialize_update_current_position { get; set; }
                
        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public ClientMap()
        {
            InitializeComponent();
            this.target_path = new TargetPath();
            this.InitializeGraph(this.GraphTargetPath);
            this.is_initialize_update_current_position = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize zed graph
        /// </summary>
        /// <param name="zgc"></param>
        private void InitializeGraph(ZedGraphControl zgc)
        {
            //this.current_pose_list = new PointPairList();

            //--get a reference to the graphPane--//
            this.myPane = zgc.GraphPane;

            //--set the titles--//
            this.myPane.Title.Text = "WGS-84 to Transverse Mercator(TM)";
            this.myPane.XAxis.Title.Text = "X [m]";
            this.myPane.YAxis.Title.Text = "Y [m]";

            //--manually set the x axis range--//
            //this.myPane.XAxis.Scale.Min = -4.0;
            //this.myPane.XAxis.Scale.Max = 4.0;
            this.myPane.XAxis.MajorGrid.IsVisible = true;

            //--manually set the y axis range--//
            //this.myPane.YAxis.Scale.Min = -0.2;
            //this.myPane.YAxis.Scale.Max = 1.0;
            this.myPane.YAxis.MajorGrid.IsVisible = true;
            this.myPane.YAxis.MajorGrid.IsZeroLine = false;

            //--scale the axes--//
            zgc.AxisChange();
        }

        /// <summary>
        /// Update current position
        /// </summary>
        /// <param name="_tm_x"></param>
        /// <param name="_tm_y"></param>
        /// <param name="_angle"></param>
        /// <param name="_body_model"></param>
        public void UpdateCurrentPosition(double _tm_x, double _tm_y, double _angle, int _body_model)
        {
            Algorithm.TargetPath.target_vertices right_divider_pose = this.target_path.RightDivider(_tm_x, _tm_y, _angle, _body_model);
 
            if (this.is_initialize_update_current_position == false)
            {
                // add point
                PointPairList p = new PointPairList();
                p.Add(right_divider_pose.x, right_divider_pose.y);

                // generate a red curve - for tracking travel path
                this.myPane.AddCurve(null, p, Color.Red, SymbolType.None);

                // generate a blue curve - for target path
                PointPairList PathList = new PointPairList();
                for (int i = 0; i < this.target_path.target_path_vertices.Count; i++)
                {
                    PathList.Add(this.target_path.target_path_vertices[i].x, this.target_path.target_path_vertices[i].y);
                }
                this.myPane.AddCurve(null, PathList, Color.Blue, SymbolType.None);

                this.is_initialize_update_current_position = true;
            }
            else
            {
                // make sure that the curvelist has at least one curve
                if (this.GraphTargetPath.GraphPane.CurveList.Count <= 0)
                {
                    return;
                }

                // get the first CurveItems in the graph
                LineItem curve = this.GraphTargetPath.GraphPane.CurveList[0] as LineItem;

                if (curve == null)
                {
                    return;
                }

                // Get the PointPairList 
                IPointListEdit list = curve.Points as IPointListEdit;

                // If this is null, it means the reference at curve.Points does not 
                // support IPointListEdit, so we won't be able to modify it
                if (list == null)
                {
                    return;
                }

                // add new data points to the graph 
                list.Add(right_divider_pose.x, right_divider_pose.y);
            }

            // tell zedgraph to refigure the axes since the data have changed
            this.GraphTargetPath.AxisChange();

            // force redraw
            this.GraphTargetPath.Invalidate();
        }

        /// <summary>
        /// Create Target path's vertices
        /// </summary>
        /// <param name="_length_one"></param>
        /// <param name="_length_two"></param>
        /// <param name="_offset"></param>
        /// <param name="_theta"></param>
        /// <param name="_tm_x"></param>
        /// <param name="_tm_y"></param>
        /// <param name="_body_model"></param>
        public void CreateTargetPath(double _length_one, double _length_two, double _offset, double _theta, double _tm_x, double _tm_y, int _body_model)
        {
            Algorithm.TargetPath.field_information field;
            field.length_one = _length_one;
            field.length_two = _length_two;
            field.offset = _offset;
            field.theta = _theta;
            field.tm_x = _tm_x;
            field.tm_y = _tm_y;
            field.body_model = _body_model;

            this.target_path.CreateTargetPath(field);
        }

        #endregion
    }
}
