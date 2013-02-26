
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
        /// GraphPane for zedGraph
        /// </summary>
        private GraphPane myPane;

        /// <summary>
        /// PointPairList for zedGraph
        /// </summary>
        private PointPairList ppList;

        /// <summary>
        /// basic constructor
        /// </summary>
        public Graph() 
        {
            //make up some data points based on the column average value in image
            this.ppList = new PointPairList();
        }
        
        /// <summary>
        /// build the chart
        /// </summary>
        /// <param name="zgc"></param>
        public void CreateGraph(ZedGraphControl zgc)
        {
            //--get a reference to the graphPane--//
            this.myPane = zgc.GraphPane;

            //--set the titles--//
            this.myPane.Title.Text = "YZ-plane data graph";
            this.myPane.XAxis.Title.Text = "Lateral distance (m)";
            this.myPane.YAxis.Title.Text = "Height (m)";

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
        }

        /// <summary>
        /// Update Graph
        /// </summary>
        /// <param name="list"></param>
        /// <param name="zgc"></param>
        /// <param name="isOpenGL"></param>
        public void UpdateGraph(List<SickLidar.CartesianPoint> list, ZedGraphControl zgc, bool isOpenGL)
        {
            if (this.ppList != null)
            {
                this.ppList.Clear();
            }

            if (zgc.GraphPane.CurveList != null)
            {
                zgc.GraphPane.CurveList.Clear();
            }

            for (int i = 0; i < list.Count; i++)
            {
                this.ppList.Add(list[i].y, list[i].z);
            }

            //--generate a red curve--//
            this.myPane.AddCurve(null, this.ppList, Color.Red, SymbolType.None);

            //--tell zedgraph to refigure the axes since the data have changed--//
            //zgc.AxisChange();

            //--make sure the graph gets re-drawn--//
            if (isOpenGL == false)
            {
                zgc.Invalidate();
            }
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
