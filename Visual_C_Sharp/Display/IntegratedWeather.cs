using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Xml;

namespace Display
{
    partial class IntegratedForm
    {
        private Amedas.Amedas ad;

        /// <summary>
        /// Save Amedas data to Xml file
        /// </summary>
        private void AmedasSaveDataToXml()
        {
            this.ad = new Amedas.Amedas(this.AmedasWebBrowser);
            this.ad.SelectedLocal = this.AmedasComBox.SelectedIndex;
            this.ad.Step_MoveToAmedasPage(this.ad.AmedasAddressString(this.AmedasComBox.SelectedIndex));
            this.AmedasWebBrowser.DocumentCompleted += this.ad.webBrowser_DocumentCompleted;
        }

        /// <summary>
        /// Grid Amedas xml data
        /// </summary>
        private void AmedasXmlToGrid()
        {
            string fileName = this.ad.ReadXmlDialog();

            XmlReader xmlFile;
            xmlFile = XmlReader.Create(fileName, new XmlReaderSettings());
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);
            dataGridView1.DataSource = ds.Tables["AmedasXml"];
        }
    }
}
