
namespace Amedas
{
    using System;

    [Serializable()]
    public class AmedasXml
    {
        /// <summary>
        /// XMLファイルに保存するオブジェクトのためのクラス
        /// http://dobon.net/vb/dotnet/file/xmlserializer.html
        /// </summary>

        public AmedasXml() { }

        /// <summary>
        /// 時刻
        /// </summary>
        public string ClockTime { get; set; }

        /// <summary>
        /// 気温
        /// </summary>
        public string Temperature { get; set; }

        /// <summary>
        /// 降水量
        /// </summary>
        public string PrecipitationAmount { get; set; }

        /// <summary>
        /// 風向
        /// </summary>
        public string WindDirection { get; set; }

        /// <summary>
        /// 風速
        /// </summary>
        public string WindSpeed { get; set; }

        /// <summary>
        /// 日照時間
        /// </summary>
        public string SunshineHours { get; set; }

        /// <summary>
        /// 積雪深
        /// </summary>
        public string DepthOfSnow { get; set; }

        /// <summary>
        /// 湿度
        /// </summary>
        public string Humidity { get; set; }

        /// <summary>
        /// 気圧
        /// </summary>
        public string Atmosphere { get; set; }
    }
}
