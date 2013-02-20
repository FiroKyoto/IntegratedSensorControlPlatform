
namespace FieldMap
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using Microsoft.CSharp.RuntimeBinder;
    using GEPlugin;

    /// <summary>
    /// 1) If you want to learn about Google Earth API on .NET Framework, Please below the website.
    /// http://www.phetteplace.net/blog/embedding-google-earth-in-a-c-application/
    /// </summary>
    [ComVisibleAttribute(true)]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class GoogleEarth
    {

        /// <summary>
        /// The Google Earth plugin instance (The plugin object)
        /// </summary>
        //private dynamic ge = null;
        private IGEPlugin ge = null;

        /// <summary>
        /// If the Google earth is started that value is true.
        /// </summary>
        public bool StartGoogleEarth { get; set; }

        /// <summary>
        /// gets or sets latitude value of GPS data(converted value from GPGGA)
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// gets or sets longitude value of GPS data(converted value from GPGGA)
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// gets or sets altitude value of GPS data(converted value from GPGGA)
        /// </summary>
        public double Altitude { get; set; }

        /// <summary>
        /// gets or sets range of the perspective view
        /// </summary>
        public double Range { get; set; }

        /// <summary>
        /// Called when the PluginReady event is fired.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void external_PluginReady(object sender, EventArgs args)
        {
            this.ge = (dynamic)sender;
            this.ge.getWindow().setVisibility(this.ge.VISIBILITY_SHOW);

            //--Some Examples of things you can enable in Google Earth--//
            this.ge.getNavigationControl().setVisibility(this.ge.VISIBILITY_AUTO);
            this.ge.getLayerRoot().enableLayerById(this.ge.LAYER_BORDERS, 1);
            this.ge.getLayerRoot().enableLayerById(this.ge.LAYER_ROADS, 1);
        }

        /// <summary>
        /// Event handler for when the Google Earth
        /// plugin gets a mouse-click event.
        /// </summary>
        public void external_MouseClick(object sender, EventArgs args)
        {
            //MessageBox.Show("Mouse clicked");
        }

        /// <summary>
        /// Create look at mode
        /// </summary>
        public void CreateLookAt()
        {           
            KmlLookAtCoClass lookAt = ge.createLookAt("");
            
            lookAt.set(Latitude, Longitude, Altitude, ge.ALTITUDE_RELATIVE_TO_GROUND, 0, 0, Range);
            ge.getView().setAbstractView(lookAt);

            ge.getLayerRoot().enableLayerById(ge.LAYER_ROADS, 1);


            //create a point
            KmlPointCoClass point = ge.createPoint("");
            point.setLatitude(lookAt.getLatitude());
            point.setLongitude(lookAt.getLongitude());

            //create a placemark
            KmlPlacemarkCoClass placemark = ge.createPlacemark("");
            placemark.setName("Start Position");
            placemark.setGeometry(point);

            ge.getFeatures().appendChild(placemark);
            
        }

        /// <summary>
        /// Draw on the google map
        /// </summary>
        /// <param name="data"></param>
        public void GpsIntervalDraw(List<DrawMap.gpsData> data)
        {
            //create the placemark
            KmlPlacemarkCoClass lineStringPlacemark = ge.createPlacemark("");

            //create the LineString
            IKmlLineString lineString = ge.createLineString("");
            lineStringPlacemark.setGeometry(lineString);

            for (int i = 0; i < data.Count; i++)
            {
                double latitude = data[i].latitude;
                double longitude = data[i].longitude;

                //add lineString points
                lineString.getCoordinates().pushLatLngAlt(latitude, longitude, 0);
            }

            //add the feature to Earth
            ge.getFeatures().appendChild(lineStringPlacemark);
        }


    }
}
