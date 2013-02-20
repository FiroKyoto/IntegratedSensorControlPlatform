
namespace CombineBody
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Windows.Forms;

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
        /// Save Measured Body Data to txt file
        /// </summary>
        private StreamWriter measuredBodyData;

        /// <summary>
        /// gets or sets current count of read data
        /// </summary>
        public int currentCount { get; set; }

        /// <summary>
        /// read combine body data of string array type from txt file 
        /// </summary>
        public string[] readData;

        /// <summary>
        /// basic constructor
        /// </summary>
        public File(bool save, bool read)
        {
            if (save == true)
            {
                this.filename = this.SaveBodyDialog();
                this.measuredBodyData = new StreamWriter(this.filename);
            }

            if (read == true)
            {
                this.readData = this.ReadBodyDialog();
                this.currentCount = 0;
            }
        }

        /// <summary>
        /// add data for save data to txt file
        /// </summary>
        /// <param name="data"></param>
        public void addDataForSave(List<int> data, int readCount)
        {
            string dataStr = readCount + " ";

            if ((data.Count == 142 || data.Count == 82) && data[0] == 205 && data[data.Count - 1] == 10)
            {
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

                this.measuredBodyData.WriteLine(dataStr);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// close the save file
        /// </summary>
        public void closeSave()
        {
            this.measuredBodyData.Close();
        }

        /// <summary>
        /// save file dialog
        /// </summary>
        /// <returns></returns>
        private string SaveBodyDialog()
        {
            string fileName = null;

            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.Title = "Save Combine Body data to txt file";
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
        /// read file dialog
        /// </summary>
        /// <returns></returns>
        private string[] ReadBodyDialog()
        {
            Stream myStream = null;

            OpenFileDialog ofDialog = new OpenFileDialog();
            List<string> savedData = new List<string>();
            string[] dataLines;

            ofDialog.Title = "Read Combine Body data from txt file";
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

        /// <summary>
        /// read command data from string array data
        /// </summary>
        /// <param name="_readCount"></param>
        /// <param name="_readData"></param>
        /// <returns></returns>
        public List<int> ReadCommandData(int _readCount, string[] _readData)
        {
            List<int> result = new List<int>();

            if (this.currentCount < _readData.Length)
            {
                string[] lineArr = _readData[this.currentCount].Split(' ');

                if (_readCount == Convert.ToInt32(lineArr[0]))
                {
                    for (int i = 1; i < lineArr.Length; i++)
                    {
                        int val = Convert.ToInt32(lineArr[i]);
                        result.Add(val);
                    }

                    this.currentCount++;
                }                
            }

            return result;
        }

    }
}
