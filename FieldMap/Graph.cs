
namespace FieldMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ZedGraph;
    using System.Drawing;

    public class Graph
    {
        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public Graph() 
        {
            this.IsInitialize = false;
        }
        
        #endregion

        #region fields

        /// <summary>
        /// GraphPane for zedGraph
        /// </summary>
        private GraphPane myPane;

        /// <summary>
        /// gets or sets initialize values
        /// </summary>
        private bool IsInitialize { get; set; }
        
        #endregion 

        #region methods

        /// <summary>
        /// build the chart
        /// </summary>
        /// <param name="zgc"></param>
        public void CreateGraph(ZedGraphControl zgc)
        {
            //--get a reference to the graphPane--//
            this.myPane = zgc.GraphPane;

            //--set the titles--//
            this.myPane.Title.Text = "WGS-84 to Tansverse Mercator(TM)";
            this.myPane.XAxis.Title.Text = "x";
            this.myPane.YAxis.Title.Text = "y";

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

        public void AddDataToGraph(ZedGraphControl zgc, double xValue, double yValue)
        {
            if (this.IsInitialize == false)
            {
                // add point
                PointPairList p = new PointPairList();
                p.Add(xValue, yValue);

                //--generate a red curve--//
                this.myPane.AddCurve(null, p, Color.Red, SymbolType.None);
                
                this.IsInitialize = true;
            }
            else
            {
                // make sure that the curvelist has at least one curve
                if (zgc.GraphPane.CurveList.Count <= 0)
                {
                    return;
                }

                // get the first CurveItems in the graph
                LineItem curve = zgc.GraphPane.CurveList[0] as LineItem;

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
                list.Add(xValue, yValue);
            }
            
            // tell zedgraph to refigure the axes since the data have changed
            zgc.AxisChange();

            // force redraw
            zgc.Invalidate();

        }

        #endregion
    }
}
