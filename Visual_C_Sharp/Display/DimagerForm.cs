using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;
using MachineVision;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Display
{
    public partial class DimagerForm : Form
    { 
        #region fields
        
        private MachineVision.Dimager dImager;
        private IplImage srcImg;
        
        #endregion

        #region constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public DimagerForm()
        {
            InitializeComponent();
            this.dImager = new Dimager();
            this.srcImg = new IplImage(160, 120, BitDepth.U8, 1);
        }
        
        #endregion

        #region methods

        /// <summary>
        /// 1. InitImageDriver()
        /// 2. Speedmode()
        /// 3. Freqmode()
        /// </summary>
        private void InitMachine()
        {         
            // 1. InitImageDriver
            int valImageDriver = this.dImager.D_InitImageDriver();

            if (valImageDriver == 0)
            {
                this.InitImageDriverTxtBox.Text = "Successed";
            }
            else
            {
                this.InitImageDriverTxtBox.Text = "Fail";
            }

            // 2. Speedmode
            int valSpeedmode = this.dImager.D_Speedmode();

            switch (valSpeedmode)
            {
                case 15:
                    this.SpeedmodeTxtBox.Text = "15fps";
                    break;

                case 20:
                    this.SpeedmodeTxtBox.Text = "20fps";
                    break;

                case 25:
                    this.SpeedmodeTxtBox.Text = "25fps";
                    break;

                case 30:
                    this.SpeedmodeTxtBox.Text = "30fps";
                    break;

                case 99:
                    this.SpeedmodeTxtBox.Text = "Fail";
                    break;
            }

            // 3. Freqmode
            int valFreqmode = this.dImager.D_Freqmode();

            switch (valFreqmode)
            {
                case 0:
                    this.FreqModeTxtBox.Text = "frequency 1";
                    break;

                case 1:
                    this.FreqModeTxtBox.Text = "frequency 2";
                    break;

                case 2:
                    this.FreqModeTxtBox.Text = "frequency 3";
                    break;

                case 3:
                    this.FreqModeTxtBox.Text = "Fail";
                    break;
            }
        }

        /// <summary>
        /// Image processing
        /// </summary>
        private void ImageProcessing()
        {
            this.ConvertDataToCvImg();
        }

        /// <summary>
        /// Convert raw data to openCV IplImage
        /// </summary>
        private void ConvertDataToCvImg()
        {
            this.dImager.D_GetImageKN();

            // ndat : Pointer of the grayscale image data acquiring buffer.
            unsafe 
            {
                byte* src = (byte*)srcImg.ImageData;
                for (int y = 0; y < 120; y++)
                {
                    int offset = srcImg.WidthStep * y;
                    for (int x = 0; x < 160; x++)
                    {
                        src[offset + x] = (byte)this.dImager.ndat[offset + x];
                    }
                }
            }

            this.pBoxIpl1.ImageIpl = this.srcImg;
        }

        /// <summary>
        /// timer 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            this.ImageProcessing();

            watch.Stop();
            this.toolStripStatusLabel2.Text =
                Convert.ToString(watch.Elapsed.TotalMilliseconds) + " milliseconds";
        }

        #endregion

        #region Events

        /// <summary>
        /// Run Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunButton_Click(object sender, EventArgs e)
        {
            this.InitMachine();
            this.timer1.Interval = Convert.ToInt32(this.IntervalTimeTxtBox.Text);
            this.timer1.Enabled = true;
        }

        /// <summary>
        /// End Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndButton_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled == true)
            {
                this.timer1.Enabled = false;
            }

            int value = this.dImager.D_FreeImageDriver();

            if (value == 0)
            {
                this.FreeImageTxtBox.Text = "Successed";
            }
            else
            {
                this.FreeImageTxtBox.Text = "Fail";
            }
        }

        #endregion
    }
}
