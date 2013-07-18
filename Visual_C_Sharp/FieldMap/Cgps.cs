
namespace FieldMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Cgps
    {
        #region constructor
        /// <summary>
        /// basic constructor
        /// </summary>
        public Cgps() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_zone">zone = 5</param>
        /// <param name="_param">param = 1</param>
        public Cgps(int _zone, int _param)
        {
            this.zone = _zone;
            this.param = _param;

            // zone origin for latitude
            this.B_origin = new double[17]
            { 
                33, 33, 36, 33, 36, 36,
                36, 36, 36, 40, 44, 44,
			    44, 26, 26, 26, 26
            };

            // zone origin for longitude
            this.L_origin = new double[17]
            { 
                129.5, 131, 132.166666666667, 133.5,
                134.333333333333, 136, 137.166666666667,
			    138.5, 139.833333333333, 140.833333333333,
			    140.25, 142.25, 144.25, 142, 127.5, 124, 131
            };

            // coefficient for equation#1
            this.A_coef = new double[8]
            { 
                6366742.52024116306, -15988.6385238568588,
                16.7299538817284, -0.0217848007897,
		        0.0000307730631, -0.0000000453374,
		        0.0000000000685, -0.0000000000001
            };
        }
        #endregion

        #region struct

        public struct XYZ84
        {
            public double X84;
            public double Y84;
            public double Z84;

            public XYZ84(double _X84, double _Y84, double _Z84)
            {
                this.X84 = _X84;
                this.Y84 = _Y84;
                this.Z84 = _Z84;
            }
        }

        public struct XYZ_Tokyo
        {
            public double X_Tokyo;
            public double Y_Tokyo;
            public double Z_Tokyo;

            public XYZ_Tokyo(double _X_Tokyo, double _Y_Tokyo, double _Z_Tokyo)
            {
                this.X_Tokyo = _X_Tokyo;
                this.Y_Tokyo = _Y_Tokyo;
                this.Z_Tokyo = _Z_Tokyo;
            }
        }

        public struct LLA
        {
            public double latitude;
            public double longitude;
            public double altitude;

            public LLA(double _lat, double _lon, double _alt)
            {
                this.latitude = _lat;
                this.longitude = _lon;
                this.altitude = _alt;
            }
        }

        public struct Cartesian
        {
            public double x;
            public double y;
            public double c;

            public Cartesian(double _x, double _y, double _c)
            {
                this.x = _x;
                this.y = _y;
                this.c = _c;
            }
        }

        #endregion

        #region fields

        /// <summary>
        /// zone
        /// </summary>
        private int zone { get; set; }

        /// <summary>
        /// parameter
        /// </summary>
        private int param { get; set; }

        public Cartesian result;

        /// <summary>
        /// 東京測地系に変換するためのパラメータ：ここから
        /// </summary>
        private const double a = 6377397.155;                       
        private const double a84 = 6378137.0;                       /*WGS-84*/
        private const double f84 = 0.00335281066474748;             /*1/298.257223563 WGS-84*/
        private const double f_tokyo = 0.00334277318;               /*1/299.152813*/
        private const double e12 = 0.006719218798;
        private const double e2 = 0.006674372231;
        private const double m0 = 0.9999;

        /// <summary>
        /// zone origin for latitude
        /// </summary>
        private double[] B_origin;

        /// <summary>
        /// zone origin for longitude
        /// </summary>
        private double[] L_origin;

        /// <summary>
        /// coefficient for equation#1
        /// </summary>
        private double[] A_coef;

        #endregion

        #region methods

        /// <summary>
        /// WGS-84 to Cartesian coordinates
        /// </summary>
        /// <param name="lat84"></param>
        /// <param name="lon84"></param>
        /// <param name="alt84"></param>
        public void w84toxyh(double lat84, double lon84, double alt84)
        {
            int datum = 0;

            // STEP 1 : WGS-84 to XYZ
            double lat = this.deg2rad(lat84);
            double lon = this.deg2rad(lon84);
            double alt = this.deg2rad(alt84);

            datum = 1;
            XYZ84 xyz84 = this.dms_to_XYZ(datum, lat, lon, alt);

            // STEP 2 : WGS-84 to TOKYO
            XYZ_Tokyo tokyo = this.WGS84_to_Tokyo(this.param, xyz84);

            // STEP 3 : XYZ to LAT_LON_ALT
            datum = 2;
            LLA lla = this.XYZ_to_dms(datum, tokyo);

            result = this.bl2xy(lla, this.zone);
        }

        /// <summary>
        /// degree to radian
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        /// <summary>
        /// DMS to XYZ
        /// </summary>
        /// <param name="datum"></param>
        /// <param name="lat84"></param>
        /// <param name="lon84"></param>
        /// <param name="alt84"></param>
        /// <returns></returns>
        private XYZ84 dms_to_XYZ(int datum, double lat84, double lon84, double alt84)
        {
            XYZ84 xyz;
            double e_square = 0.0;
            double N = 0.0;
            double f = 0.0; 
            double adms = 0.0;

            switch (datum)
            {
                case 1: // WGS-84
                    adms = a84;
                    f = f84;
                    break;
                case 2: // tokyo datum
                    adms = a;
                    f = f_tokyo;
                    break;
            }

            e_square = f * (2.0 - f);
            N = adms / Math.Sqrt(1.0 - e_square * Math.Pow(Math.Sin(lat84), 2.0));
            xyz.X84 = (N + alt84) * Math.Cos(lat84) * Math.Cos(lon84);
            xyz.Y84 = (N + alt84) * Math.Cos(lat84) * Math.Sin(lon84);
            xyz.Z84 = (N * (1.0 - e_square) + alt84) * Math.Sin(lat84);

            return xyz;
        }

        /// <summary>
        /// WGS84 to Tokyo
        /// </summary>
        /// <param name="param"></param>
        /// <param name="xyz"></param>
        /// <returns></returns>
        private XYZ_Tokyo WGS84_to_Tokyo(int param, XYZ84 xyz)
        {
            XYZ_Tokyo tokyo;
            tokyo.X_Tokyo = 0.0;
            tokyo.Y_Tokyo = 0.0;
            tokyo.Z_Tokyo = 0.0;

            switch (param)
            {
                case 1: // New parameters
                    tokyo.X_Tokyo = xyz.X84 + 147.54;
                    tokyo.Y_Tokyo = xyz.Y84 - 507.26;
                    tokyo.Z_Tokyo = xyz.Z84 - 680.47;
                    break;
                case 2: // Old parameters 
                    tokyo.X_Tokyo = xyz.X84 + 146.43;
                    tokyo.Y_Tokyo = xyz.Y84 - 507.89;
                    tokyo.Z_Tokyo = xyz.Z84 - 681.46;
                    break;
            }

            return tokyo;
        }

        /// <summary>
        /// XYZ to DMS
        /// </summary>
        /// <param name="datum"></param>
        /// <param name="tokyo"></param>
        /// <returns></returns>
        private LLA XYZ_to_dms(int datum, XYZ_Tokyo tokyo)
        {
            LLA lla;

            double b_dash, P, theta, E_square;
            double E_square_dash, neu, f, adms;
            f = adms = 0.0;

            switch (datum)
            {
                case 1: // WGS-84 
                    adms = a84;
                    f = f84;
                    break;
                case 2: // Tokyo datum 
                    adms = a;
                    f = f_tokyo;
                    break;
            }

            b_dash = adms * (1.0 - f);
            P = Math.Sqrt(Math.Pow(tokyo.X_Tokyo, 2.0) + Math.Pow(tokyo.Y_Tokyo, 2.0));
            theta = Math.Atan((tokyo.Z_Tokyo * adms) / (P * b_dash));
            E_square = (adms * adms - b_dash * b_dash) / (adms * adms);
            E_square_dash = (adms * adms - b_dash * b_dash) / (b_dash * b_dash);

            lla.latitude = Math.Atan((tokyo.Z_Tokyo + E_square_dash * b_dash * Math.Pow(Math.Sin(theta), 3.0)) / (P - E_square * adms * Math.Pow(Math.Cos(theta), 3.0)));
            lla.longitude = Math.Atan(tokyo.Y_Tokyo / tokyo.X_Tokyo) + Math.PI;
            neu = adms / Math.Sqrt(1.0 - E_square * Math.Pow(Math.Sin(lla.latitude), 2.0));
            lla.altitude = P / Math.Cos(lla.latitude) - neu;

            return lla;
        }

        /// <summary>
        /// bl to xy
        /// </summary>
        /// <param name="lla"></param>
        /// <param name="zone"></param>
        /// <returns></returns>
        private Cartesian bl2xy(LLA lla, int zone)
        {
            Cartesian carte;
            double dl, dx, mx0;
            double et2, w, N, tn2;
            double x2, x4, x6, x8, y1, y3, y5, y7;
            double B0, L0;
            double sinb, cosb, tanb;
            double M, m;

            B0 = B_origin[zone] * Math.PI / 180.0;
            L0 = L_origin[zone] * Math.PI / 180.0;
            dl = lla.longitude - L0;

            cosb = Math.Cos(lla.latitude);
            sinb = Math.Sin(lla.latitude);
            tanb = Math.Tan(lla.latitude);
            mx0 = mx(B0);
            dx = mx(lla.latitude) - mx0;

            et2 = e12 * Math.Pow(cosb, 2.0);
            w = 1.0 - e2 * Math.Pow(sinb, 2.0);
            N = a / Math.Pow(w, 0.5);
            M = N * (1.0 - e2) / w;
            tn2 = Math.Pow(tanb, 2.0);

            x2 = N * sinb * cosb * Math.Pow(dl, 2.0) / 2.0;
            x4 = N * sinb * Math.Pow(cosb, 3.0) *
                   (5.0 - tn2 + 9.0 * et2 + 4.0 * Math.Pow(et2, 2.0)) * Math.Pow(dl, 4.0) / 24.0;
            x6 = N * sinb * Math.Pow(cosb, 5.0) *
                   (61.0 - 58.0 * tn2 + Math.Pow(tn2, 2.0) + 270.0 * et2 - 330.0 * tn2 * et2) *
                   Math.Pow(dl, 6.0) / 720.0;
            x8 = N * sinb * Math.Pow(cosb, 7.0) *
                   (1385.0 - 3111.0 * tn2 + 543.0 * Math.Pow(tn2, 2.0) - Math.Pow(tn2, 3.0)) *
                   Math.Pow(dl, 8.0) / 40320.0;
            carte.x = m0 * (x8 + x6 + x4 + x2 + dx);

            y1 = N * cosb * dl;
            y3 = N * Math.Pow(cosb, 3.0) * (1.0 - tn2 + et2) * Math.Pow(dl, 3.0) / 6.0;
            y5 = N * Math.Pow(cosb, 5.0) *
                   (5.0 - 18.0 * tn2 + Math.Pow(tn2, 2.0) + 14.0 * et2 - 58.0 * tn2 * et2) *
                       Math.Pow(dl, 5.0) / 120.0;
            y7 = N * Math.Pow(cosb, 7.0) *
                   (61.0 - 479.0 * tn2 + 179.0 * Math.Pow(tn2, 2.0) - Math.Pow(tn2, 3.0)) *
                   Math.Pow(dl, 7.0) / 5040.0;
            carte.y = m0 * (y7 + y5 + y3 + y1);

            carte.c = (sinb * dl + sinb * Math.Pow(cosb, 2.0) * (1.0 + 3.0 * et2) * Math.Pow(dl, 3.0) / 3.0);

            m = 1 + Math.Pow(cosb, 2.0) * (1.0 + Math.Sqrt(e12) * Math.Pow(cosb, 2.0)) *
                Math.Pow(dl, 2.0) / 2.0 + Math.Pow(cosb, 4.0) * (5.0 - Math.Pow(tanb, 2.0)) * Math.Pow(dl, 4.0) / 24;

            return carte;
        }

        /// <summary>
        /// mx
        /// </summary>
        /// <param name="phi"></param>
        /// <returns></returns>
        private double mx(double phi)
        {
            double m;
            int i;

            m = A_coef[0] * phi;

            for (i = 1; i < 8; i++)
            {
                m = m + A_coef[i] * Math.Sin(2.0 * phi * i);
            }

            return (m); 
        }
        #endregion
    }
}
