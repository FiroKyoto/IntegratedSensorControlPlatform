
namespace SickLidar
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class File
    {
        /// <summary>
        /// gets or sets debug message
        /// </summary>
        public string debugMsg { get; set; }

        /// <summary>
        /// gets or sets file name
        /// </summary>
        private string filename { get; set; }

        /// <summary>
        /// Save Measured Lrf Data to txt file
        /// </summary>
        private StreamWriter measuredLrfData;

        /// <summary>
        /// read lidar data of string array type from txt file 
        /// </summary>
        public string[] readData;

        /// <summary>
        /// basic constructor
        /// </summary>
        public File(bool save, bool read) 
        {
            if (save == true)
            {
                this.filename = this.SaveLidarDialog();
                this.measuredLrfData = new StreamWriter(this.filename);
            }

            if (read == true)
            {
                this.readData = this.ReadLidarDialog();
            }
        }

        /// <summary>
        /// save file dialog
        /// </summary>
        /// <returns></returns>
        private string SaveLidarDialog()
        {
            string fileName = null;

            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.Title = "Save lidar data to txt file";
            sfDialog.InitialDirectory = @"C:\Users\cho\Documents\Visual Studio 2010\Projects\ProjectData";
            sfDialog.Filter = "txt files (*.txt)|*.txt";
            sfDialog.FilterIndex = 1;
            sfDialog.RestoreDirectory = true;

            if (sfDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = sfDialog.FileName;
                }
                catch (Exception ex)
                {
                    this.debugMsg = ex.Message;
                }
            }

            return fileName;
        }

        /// <summary>
        /// add data for save data to txt file
        /// </summary>
        /// <param name="data"></param>
        public void addDataForSave(List<int> data)
        {
            string dataStr = null;

            for (int i = 0; i < data.Count; i++)
            {
                if (i == (data.Count - 1))
                {
                    dataStr += data[i];
                }
                else
                {
                    dataStr += data[i] + " ";
                }
            }

            this.measuredLrfData.WriteLine(dataStr);
        }

        /// <summary>
        /// close the save file
        /// </summary>
        public void closeSave()
        {
            this.measuredLrfData.Close();
        }

        /// <summary>
        /// read file dialog
        /// </summary>
        /// <returns></returns>
        private string[] ReadLidarDialog()
        {
            Stream myStream = null;

            OpenFileDialog ofDialog = new OpenFileDialog();
            List<string> savedData = new List<string>();
            string[] dataLines;

            ofDialog.Title = "Read Lidar data from txt file";
            ofDialog.InitialDirectory = @"C:\Users\cho\Documents\Visual Studio 2010\Projects\ProjectData";
            ofDialog.Filter = "txt files (*.txt)|*.txt";
            ofDialog.FilterIndex = 1;
            ofDialog.RestoreDirectory = true;

            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ofDialog.OpenFile()) != null)
                    {
                        using (StreamReader sr = new StreamReader(myStream))
                        {
                            string line;

                            while ((line = sr.ReadLine()) != null)
                            {
                                savedData.Add(line);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.debugMsg = ex.Message;
                }
            }

            dataLines = savedData.ToArray();

            return dataLines;
        }

    }
}
