
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
        /// pointpairlist for traceability
        /// </summary>
        private PointPairList trace_pplist;

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
            this.trace_pplist = new PointPairList();

            //--get a reference to the graphPane--//
            this.myPane = zgc.GraphPane;

            //--set the titles--//
            this.myPane.Title.Text = "WGS-84 to Transverse Mercator(TM)";
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


        /// <summary>
        /// Draw TM points on graph
        /// </summary>
        /// <param name="zgc"></param>
        /// <param name="xValue"></param>
        /// <param name="yValue"></param>
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


        /// <summary>
        /// Draw traceability on the graph
        /// </summary>
        /// <param name="_zgc"></param>
        /// <param name="_pplist"></param>
        /// <param name="_ran_running"></param>
        public void TraceabilityGraph(ZedGraphControl _zgc, PointPairList _pplist, bool _ran_running)
        {
            if (this.myPane.GraphObjList != null)
            {
                this.myPane.GraphObjList.Clear();
            }

            if (_zgc.GraphPane.CurveList != null)
            {
                _zgc.GraphPane.CurveList.Clear();
            }

            // add arrow
            ArrowObj arrow_gps = new ArrowObj(Color.Blue, 30, _pplist[0].X, _pplist[0].Y, _pplist[1].X, _pplist[1].Y);
            this.myPane.GraphObjList.Add(arrow_gps);
            PointPairList arrow_pt = new PointPairList();
            arrow_pt.Add(_pplist[0]);
            arrow_pt.Add(_pplist[1]);
            this.myPane.AddCurve(null, arrow_pt, Color.Blue, SymbolType.None);

            // add body line
            PointPairList body_line = new PointPairList();
            body_line.Add(_pplist[2]);
            body_line.Add(_pplist[3]);
            this.myPane.AddCurve(null, body_line, Color.Orange, SymbolType.None);

            // add path tracking
            this.trace_pplist.Add(_pplist[0]);
            this.myPane.AddCurve(null, this.trace_pplist, Color.Red, SymbolType.None);

            // add extracted ransac line
            if (_ran_running == true)
            {
                PointPairList ransac_line = new PointPairList();
                ransac_line.Add(_pplist[4]);
                ransac_line.Add(_pplist[5]);
                this.myPane.AddCurve(null, ransac_line, Color.BlueViolet, SymbolType.None);
            }

            // tell zedgraph to refigure the axes since the data have changed
            _zgc.AxisChange();

            // force redraw
            _zgc.Invalidate();
        }

        #endregion
    }
}
