using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.CSharp.RuntimeBinder;

namespace FieldMap
{
    /// <summary>
    /// For Google Earth Plug-in
    /// Apply a demand for full trust in order
    /// to limit access by partially trusted code.
    [ComVisibleAttribute(true)]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class DrawMap
    {
        #region fields
        
        /// <summary>
        /// struct of gps data
        /// </summary>
        public struct gpsData
        {
            public double latitude;
            public double longitude;

            public gpsData(double _lat, double _lng)
            {
                this.latitude = _lat;
                this.longitude = _lng;
            }
        }

        /// <summary>
        /// gps data of list type
        /// </summary>
        private List<gpsData> data;

        /// <summary>
        /// gets or sets read count
        /// </summary>
        private int readCnt { get; set; }

        /// <summary>
        /// for using google earth methods
        /// </summary>
        private GoogleEarth GE;

        /// <summary>
        /// COM-visible class
        /// </summary>
        private External external;

        /// <summary>
        /// gets or sets debug message
        /// </summary>
        public string debugMsg { get; set; }

        /// <summary>
        /// gets or sets initialize of google earth
        /// </summary>
        public bool IsInitialize { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="_GeWebBrowser"></param>
        public DrawMap(WebBrowser GeWebBrowser)
        {
            if (CheckInternetConnect.IsConnectedToInternet() == true)
            {
                this.external = new External();
                this.GE = new GoogleEarth();

                //--connect event handler--//
                this.external.PluginReady += this.GE.external_PluginReady;
                //this.external.KmlMouseClickEvent += this.GE.external_MouseClick;

                GeWebBrowser.ObjectForScripting = this.external;

                //--insert your localhost.html address below mathod--//
                GeWebBrowser.Navigate(
                    "C:\\Projectdata\\Google\\PlugIn.htm");

                this.data = new List<gpsData>();
                this.data.Clear();
                this.IsInitialize = false;
                this.readCnt = 0;

                //--debug for whether selected or not selected--//
                GE.StartGoogleEarth = true;

                this.debugMsg = "Start Google Earth";
            }
            else
            {
                this.debugMsg = "Network is not connected";
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Receive gps data from read data
        /// </summary>
        /// <param name="_lat"></param>
        /// <param name="_lng"></param>
        public void ReceiveGpsData(double _lat, double _lng)
        {
            gpsData gData;
            gData.latitude = _lat;
            gData.longitude = _lng;

            this.data.Add(gData);

            if (this.readCnt != 9)
            {
                this.readCnt++;
            }
            else
            {
                this.GE.GpsIntervalDraw(this.data);
                this.readCnt = 0;
                this.data.Clear();
            }
        }

        /// <summary>
        /// Create Look At 
        /// </summary>
        /// <param name="_lat"></param>
        /// <param name="_lng"></param>
        /// <param name="_alt"></param>
        /// <param name="_range"></param>
        public void CreateLookAt(double _lat, double _lng, double _alt, double _range)
        {
            if (this.GE.StartGoogleEarth == true)
            {
                this.GE.Latitude = _lat;
                this.GE.Longitude = _lng;
                this.GE.Altitude = _alt;
                this.GE.Range = _range;

                this.GE.CreateLookAt();

                this.debugMsg = "Selected CreateLookAt View Method";
            }
            else
            {
                this.debugMsg = "Please start Google Earth";
            }
        }

        /// <summary>
        /// Dispose google earth
        /// </summary>
        public void Dispose(WebBrowser GeWebBrowser)
        {
            if (GE.StartGoogleEarth == true)
            {
                ((Control)GeWebBrowser).Enabled = false;
                GE.StartGoogleEarth = false;

                this.debugMsg = "Stop Google Earth";
            }
            else
            {
                this.debugMsg = "Already.. status is Stop!!";
            }
        }

        #endregion

    }
}
