
namespace SickLidar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ZedGraph;
    using System.Drawing;

    public class Graph
    {
        /// <summary>
        /// GraphPane of XZ-plane for zedGraph
        /// </summary>
        private GraphPane myPane;

        /// <summary>
        /// GraphPane of XY-plane for zedGraph
        /// </summary>
        private GraphPane myPane1;

        /// <summary>
        /// GraphPane of XY-plane for hokuyo sensor
        /// </summary>
        private GraphPane myPane2;

        /// <summary>
        /// PointPairList of XZ-plane for zedGraph
        /// </summary>
        private PointPairList ppList;

        /// <summary>
        /// PointPairList of XY-plane for zedGraph
        /// </summary>
        private PointPairList ppList1;

        /// <summary>
        /// PointPairList of XY-plane for hokuyo sensor
        /// </summary>
        private PointPairList ppList2;

        /// <summary>
        /// basic constructor
        /// </summary>
        public Graph() 
        {
            //make up some data points based on the column average value in image
            this.ppList = new PointPairList();
            this.ppList1 = new PointPairList();
            this.ppList2 = new PointPairList();
        }

        /// <summary>
        /// For hokuyo sensor graph
        /// </summary>
        /// <param name="zgc"></param>
        public void CreateHokuyoGraph(ZedGraphControl zgc)
        {
            // YZ Plane
            //--get a reference to the graphPane--//
            this.myPane2 = zgc.GraphPane;

            //--set the titles--//
            this.myPane2.Title.Text = "XY-plane data graph";
            this.myPane2.XAxis.Title.Text = "X (mm)";
            this.myPane2.YAxis.Title.Text = "Y (mm)";

            //--manually set the x axis range--//
            //this.myPane.XAxis.Scale.Min = -4.0;
            //this.myPane.XAxis.Scale.Max = 4.0;
            this.myPane2.XAxis.MajorGrid.IsVisible = true;

            //--manually set the y axis range--//
            //this.myPane.YAxis.Scale.Min = -0.2;
            //this.myPane.YAxis.Scale.Max = 1.0;
            this.myPane2.YAxis.MajorGrid.IsVisible = true;
            this.myPane2.YAxis.MajorGrid.IsZeroLine = false;

            //--scale the axes--//
            zgc.AxisChange();
        }

        /// <summary>
        /// build the chart
        /// </summary>
        /// <param name="zgc">XZ plane</param>
        /// <param name="zgc1">XY Plane</param>
        public void CreateGraph(ZedGraphControl zgc, ZedGraphControl zgc1)
        {
            // YZ Plane
            //--get a reference to the graphPane--//
            this.myPane = zgc.GraphPane;

            //--set the titles--//
            this.myPane.Title.Text = "XZ-plane data graph";
            this.myPane.XAxis.Title.Text = "X (m)";
            this.myPane.YAxis.Title.Text = "Z (m)";

            //--manually set the x axis range--//
            this.myPane.XAxis.Scale.Min = -4.0;
            this.myPane.XAxis.Scale.Max = 4.0;
            this.myPane.XAxis.MajorGrid.IsVisible = true;

            //--manually set the y axis range--//
            this.myPane.YAxis.Scale.Min = -0.2;
            this.myPane.YAxis.Scale.Max = 1.0;
            this.myPane.YAxis.MajorGrid.IsVisible = true;
            this.myPane.YAxis.MajorGrid.IsZeroLine = false;

            //--scale the axes--//
            zgc.AxisChange();

            // XY Plane
            //--get a reference to the graphPane--//
            this.myPane1 = zgc1.GraphPane;

            //--set the titles--//
            this.myPane1.Title.Text = "XY-plane data graph";
            this.myPane1.XAxis.Title.Text = "X (m)";
            this.myPane1.YAxis.Title.Text = "Y (m)";

            //--manually set the x axis range--//
            this.myPane1.XAxis.Scale.Min = -4.0;
            this.myPane1.XAxis.Scale.Max = 4.0;
            this.myPane1.XAxis.MajorGrid.IsVisible = true;

            //--manually set the y axis range--//
            this.myPane1.YAxis.Scale.Min = 0.0;
            this.myPane1.YAxis.Scale.Max = 4.0;
            this.myPane1.YAxis.MajorGrid.IsVisible = true;
            this.myPane1.YAxis.MajorGrid.IsZeroLine = false;

            //--scale the axes--//
            zgc1.AxisChange();

        }

        /// <summary>
        /// update hokuyo graph
        /// </summary>
        /// <param name="list"></param>
        /// <param name="zgc"></param>
        public void UpdateHokuyoGraph(List<Hokuyo.CartesianXY> list, ZedGraphControl zgc)
        {
            if (this.ppList2 != null)
            {
                this.ppList2.Clear();
            }

            if (zgc.GraphPane.CurveList != null)
            {
                zgc.GraphPane.CurveList.Clear();
            }

            for (int i = 0; i < list.Count; i++)
            {
                this.ppList2.Add(list[i].x, list[i].y);
            }

            //--generate a red curve--//
            this.myPane2.AddCurve(null, this.ppList2, Color.Red, SymbolType.None);

            // tell zedgraph to refigure the axes since the data have changed
            zgc.AxisChange();

            //--make sure the graph gets re-drawn--//
            zgc.Invalidate();
        }

        /// <summary>
        /// Update Graph
        /// </summary>
        /// <param name="list"></param>
        /// <param name="zgc"></param>
        /// <param name="zgc1"></param>
        /// <param name="isOpenGL"></param>
        public void UpdateGraph(List<SickLidar.CartesianPoint> list, ZedGraphControl zgc, ZedGraphControl zgc1, bool isOpenGL)
        {
            if (this.ppList != null)
            {
                this.ppList.Clear();
            }

            if (this.ppList1 != null)
            {
                this.ppList1.Clear();
            }

            if (zgc.GraphPane.CurveList != null)
            {
                zgc.GraphPane.CurveList.Clear();
            }

            if (zgc1.GraphPane.CurveList != null)
            {
                zgc1.GraphPane.CurveList.Clear();
            }

            for (int i = 0; i < list.Count; i++)
            {
                this.ppList.Add(list[i].x, list[i].z);
                this.ppList1.Add(list[i].x, list[i].y);
            }

            //--generate a red curve--//
            this.myPane.AddCurve(null, this.ppList, Color.Red, SymbolType.None);
            this.myPane1.AddCurve(null, this.ppList1, Color.Red, SymbolType.None);

            //--tell zedgraph to refigure the axes since the data have changed--//
            //zgc.AxisChange();

            //--make sure the graph gets re-drawn--//
            if (isOpenGL == false)
            {
                zgc.Invalidate();
            }

            zgc1.Invalidate();
        }

        /// <summary>
        /// Update Perpendicular graph
        /// </summary>
        /// <param name="list"></param>
        /// <param name="zgc"></param>
        /// <param name="isOpenGL"></param>
        public void CutEdgePerpendicularGraph(List<double> list, ZedGraphControl zgc, bool isOpenGL)
        {
            if (this.myPane.GraphObjList != null)
            {
                this.myPane.GraphObjList.Clear();
            }

            // generate a straight line
            this.myPane.GraphObjList.Add(
                new LineObj(Color.Blue, list[0], list[1], list[2], list[3])
               );

            // generate a perpendicular line
            this.myPane.GraphObjList.Add(
                new LineObj(Color.Blue, list[4], list[5], list[6], list[7])
               );

            //--make sure the graph gets re-drawn--//
            if (isOpenGL == true)
            {
                zgc.Invalidate();
            }
        }
    }
}
