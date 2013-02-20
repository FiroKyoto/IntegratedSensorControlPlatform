
namespace Amedas
{
    using System;
    using System.Windows.Forms;

    public class Amedas
    {
        #region fields

        private LocalInfo LI;
        private WebBrowser wb;
        private AmedasXml[] xobj;
        private int tableIndexNum;
        public int SelectedLocal { get; set; }
        public string debugMsg { get; set; }

        #endregion

        #region Constructor

        public Amedas() { }

        public Amedas(WebBrowser _wb)
        {
            wb = _wb;
            this.LI = new LocalInfo();
        }

        #endregion

        #region methods

        public void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.wb.ReadyState.Equals(WebBrowserReadyState.Complete))
            {
                Step_ReadAmedasInformation();
            }
        }

        public void Step_ReadAmedasInformation()
        {
            try
            {
                HtmlDocument doc = wb.Document;
                string tableId = "tbl_list";
                HtmlElement tbl_list = doc.GetElementById(tableId);

                if (tbl_list == null)
                {
                    // = "Can not find table list";
                    return;
                }

                HtmlElementCollection trs = tbl_list.GetElementsByTagName("tr");
                HtmlElementCollection time = trs[1].GetElementsByTagName("td");

                tableIndexNum = LI.returnTableIndex(SelectedLocal);

                xobj = new AmedasXml[trs.Count];

                for (int i = 0; i < trs.Count; i++)
                {
                    xobj[i] = new AmedasXml();

                    for (int j = 0; j < tableIndexNum; j++)
                    {

                        //--여름하고 겨울에는 교토의 환경변수 개수가 변한다--//
                        switch (j)
                        {
                            case 0:
                                xobj[i].ClockTime = trs[i].GetElementsByTagName("td")[j].InnerText;
                                break;

                            case 1:
                                xobj[i].Temperature = trs[i].GetElementsByTagName("td")[j].InnerText;
                                break;

                            case 2:
                                xobj[i].PrecipitationAmount = trs[i].GetElementsByTagName("td")[j].InnerText;
                                break;

                            case 3:
                                xobj[i].WindDirection = trs[i].GetElementsByTagName("td")[j].InnerText;
                                break;

                            case 4:
                                xobj[i].WindSpeed = trs[i].GetElementsByTagName("td")[j].InnerText;
                                break;

                            case 5:
                                xobj[i].SunshineHours = trs[i].GetElementsByTagName("td")[j].InnerText;
                                break;

                            //case 6:
                            //    xobj[i].DepthOfSnow = trs[i].GetElementsByTagName("td")[j].InnerText;
                            //    break;

                            case 6:
                                xobj[i].Humidity = trs[i].GetElementsByTagName("td")[j].InnerText;
                                break;

                            case 7:
                                xobj[i].Atmosphere = trs[i].GetElementsByTagName("td")[j].InnerText;
                                break;

                        }
                    }
                }

                this.SaveXmlFile();
            }
            catch (Exception err)
            {
                string error = err.Message + "\n" + err.Source;
            }
        }


        /// <summary>
        /// read xml  dialog
        /// </summary>
        /// <returns></returns>
        public string ReadXmlDialog()
        {
            string _fileName = null;

            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Title = "Read xml file";
            ofDialog.InitialDirectory = @"C:\Users\cho\Documents\Visual Studio 2010\Projects\ProjectData";
            ofDialog.Filter = "xml files (*.xml)|*.xml";
            ofDialog.FilterIndex = 1;
            ofDialog.RestoreDirectory = true;

            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _fileName = ofDialog.FileName;
                }
                catch (Exception ex)
                {
                    this.debugMsg = ex.Message;
                }
            }

            return _fileName;
        }

        /// <summary>
        /// save amedas data to xml file
        /// </summary>
        public void SaveXmlFile()
        {
            string xmlFileName = null;

            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.Title = "Save Amedas weather data to xml file";
            sfDialog.InitialDirectory = @"C:\Users\cho\Documents\Visual Studio 2010\Projects\ProjectData";
            sfDialog.Filter = "xml files (*.xml)|*.xml";
            sfDialog.FilterIndex = 1;
            sfDialog.RestoreDirectory = true;

            if (sfDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    xmlFileName = sfDialog.FileName;
                }
                catch (Exception ex)
                {
                    this.debugMsg = ex.Message;
                }
            }

            System.Xml.Serialization.XmlSerializer serializer1 =
                new System.Xml.Serialization.XmlSerializer(typeof(AmedasXml[]));
            System.IO.FileStream fs1 =
                new System.IO.FileStream(xmlFileName, System.IO.FileMode.Create);
            serializer1.Serialize(fs1, xobj);
            fs1.Close();
        }

        public void Step_MoveToAmedasPage(string address)
        {
            //amedas web address
            wb.Navigate(address);
        }

        public string AmedasAddressString(int SelectedIndex)
        {
            string address = null;
            switch (SelectedIndex + 1)
            {
                case 1:
                    //sonobe
                    address = LI.Sonobe;
                    break;

                case 2:
                    //kyoto
                    address = LI.Kyoto;
                    break;
            }
            return address;
        }

        #endregion
    }

}
