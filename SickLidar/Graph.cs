
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
            this.myPane.Title.Text = "Measured LRF Data";
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
        public void UpdateGraph(List<SickLidar.CartesianPoint> list, ZedGraphControl zgc, bool algorithm)
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
            if (algorithm == false)
            {
                zgc.Invalidate();
            }
        }

        /// <summary>
        /// Update split-and-merge
        /// </summary>
        /// <param name="index"></param>
        /// <param name="zgc"></param>
        public void UpdataSplitAndMergeGraph(double lateralIndex, double groundHeight, ZedGraphControl zgc, bool algorithm)
        {
            if (algorithm == true)
            {
                if (this.myPane.GraphObjList != null)
                {
                    this.myPane.GraphObjList.Clear();
                }

                // lateral index
                this.myPane.GraphObjList.Add(
                    new LineObj(Color.Blue, lateralIndex, myPane.YAxis.Scale.Min, lateralIndex, myPane.YAxis.Scale.Max)
                   );

                // ground height
                this.myPane.GraphObjList.Add(
                    new LineObj(Color.DarkOliveGreen, myPane.XAxis.Scale.Min, groundHeight, myPane.XAxis.Scale.Max, groundHeight)
                   );
                
                zgc.Invalidate();
            }
        }
    }
}
