using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amedas
{
    public class LocalInfo
    {
        public LocalInfo() { }

        private string _sonobe = "http://www.jma.go.jp/jp/amedas_h/today-61242.html?groupCode=44&areaCode=000";
        private string _kyoto = "http://www.jma.go.jp/jp/amedas_h/today-61286.html?groupCode=44&areaCode=000";
        private int _indexSonobe = 6;

        //--쿄토의 카운트는 여름과 겨울에 바뀐다--//
        private int _indexKyoto = 8;

        public string Sonobe { get { return _sonobe; } }
        public string Kyoto { get { return _kyoto; } }

        public int returnTableIndex(int index)
        {
            int table = 0;

            switch (index + 1)
            {
                case 1:
                    table = _indexSonobe;
                    break;

                case 2:
                    table = _indexKyoto;
                    break;
            }

            return table;
        }

        public string SelectedLocationName(int index)
        {
            string table = "";

            switch (index)
            {
                case 0:
                    table = "sonobe";
                    break;

                case 1:
                    table = "kyoto";
                    break;
            }

            return table;
        }
    }
}
