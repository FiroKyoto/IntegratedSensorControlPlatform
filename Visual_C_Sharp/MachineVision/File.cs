

namespace MachineVision
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenCvSharp;

    public class File : IDisposable
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
        /// Capture from camera
        /// </summary>
        public CvCapture cap;

        /// <summary>
        /// Write from captured jpg image
        /// </summary>
        public CvVideoWriter writer;

        /// <summary>
        /// basic constructor
        /// </summary>
        public File(bool _save, bool _read, int _interval) 
        {
            if (_read == false)
            {
                if (_save == true)
                {
                    double fps = (double)1000 / _interval;

                    this.writer = new CvVideoWriter(
                        this.saveMachineVisionDialog(),
                        FourCC.MJPG,
                        fps,
                        new CvSize(640, 480)
                        );
                }

                this.cap = CvCapture.FromCamera(CaptureDevice.DShow, 0);
            }
            else
            {
                this.cap = CvCapture.FromFile(this.readMachineVisionDialog());
            }
        }

        /// <summary>
        /// save file dialog
        /// </summary>
        /// <returns></returns>
        private string saveMachineVisionDialog()
        {
            string _fileName = null;

            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.Title = "Save data from jpg or avi file";
            sfDialog.InitialDirectory = @"C:\Users\cho\Documents\Visual Studio 2010\Projects\ProjectData";
            sfDialog.Filter = "jpg files (*.jpg)|*.jpg|avi files (*.avi)|*.avi";
            sfDialog.FilterIndex = 2;
            sfDialog.RestoreDirectory = true;

            if (sfDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _fileName = sfDialog.FileName;
                }
                catch (Exception ex)
                {
                    this.debugMsg = ex.Message;
                }
            }

            return _fileName;
        }

        /// <summary>
        /// read image or avi using dialog
        /// </summary>
        /// <returns></returns>
        private string readMachineVisionDialog()
        {
            string _fileName = null;

            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Title = "Read image or avi file";
            ofDialog.InitialDirectory = @"C:\Users\cho\Documents\Visual Studio 2010\Projects\ProjectData";
            ofDialog.Filter = "jpg files (*.jpg)|*.jpg|avi files (*.avi)|*.avi";
            ofDialog.FilterIndex = 2;
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
        /// Video writer
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="frames"></param>
        public void VideoWriter(IplImage frame, int frames)
        {
            CvFont font = new CvFont(FontFace.HersheyComplex, 0.5, 0.5);
            string str = string.Format("{0}[Frame]", frames);
            frame.PutText(str, new CvPoint(10, 20), font, new CvColor(255, 0, 0));
            this.writer.WriteFrame(frame);
        }

        /// <summary>
        /// dispose
        /// </summary>
        public void Dispose()
        {
            if (this.cap != null)
            {
                this.cap.Dispose();
            }

            if (this.writer != null)
            {
                this.writer.Dispose();
            }
        }

    }
}
