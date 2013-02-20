
namespace IidaLabVy446
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using OpenCvSharp;
    using MachineVision;
    using Algorithm;

    public partial class VisionForm : Form
    {
        #region fields
        
        /// <summary>
        /// using cut-edge
        /// </summary>
        private Algorithm.Eaef eaef;

        /// <summary>
        /// using file I/O
        /// </summary>
        private MachineVision.File mvFile;

        /// <summary>
        /// gets or sets read count of timer
        /// </summary>
        private int readCnt { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public VisionForm()
        {
            InitializeComponent();
        }

        #endregion

        #region event

        /// <summary>
        /// timer event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MachineVisionTimer_Tick(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            if (this.mvFile.cap.QueryFrame() != null)
            {
                if (this.CutEdgeCheckBox.Checked == true)
                {
                    this.eaef.Run(this.mvFile.cap.QueryFrame(), ZgcGraph1);
                    this.pBoxIpl1.ImageIpl = this.mvFile.cap.QueryFrame();
                    this.pBoxIpl2.ImageIpl = this.eaef.ipmImg;
                    this.pBoxIpl3.ImageIpl = this.eaef.norImg;
                    this.pBoxIpl4.ImageIpl = this.eaef.dstImg;
                    this.label5.Text = Convert.ToString(this.eaef.lateralThreshold);
                    this.label7.Text = Convert.ToString(this.eaef.lateralDistance) + " m";
                    this.label8.Text = this.eaef.lateralOffset;
                }
                else
                {
                    this.pBoxIpl1.ImageIpl = this.mvFile.cap.QueryFrame();
                }

                if (this.SaveAviCheckBox.Checked == true)
                {
                    this.mvFile.writer.WriteFrame(this.mvFile.cap.QueryFrame());
                }
            }
            else
            {
                this.toolStripStatusLabel4.Text = "Cannot read image from QueryFrame";
                this.MachineVisionTimer.Enabled = false;
                this.mvFile.Dispose();
            }

            // count debug
            //this.toolStripStatusLabel6.Text = Convert.ToString(this.readCnt);
            this.readCnt++;

            watch.Stop();

            // total elapsed time
            this.toolStripStatusLabel2.Text =
                Convert.ToString(watch.Elapsed.TotalMilliseconds) + " milliseconds";

            // algorithm elapsed time
            if (this.CutEdgeCheckBox.Checked == true)
            {
                this.label3.Text =
                    Convert.ToString(this.eaef.elapsedTime) + " milliseconds";
            }
        }

        /// <summary>
        /// connect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.readCnt = 0;

            this.mvFile = new MachineVision.File(
                this.SaveAviCheckBox.Checked,
                this.ReadAviCheckBox.Checked,
                Convert.ToInt32(this.IntervalTxtBox.Text)
                );

            if (this.CutEdgeCheckBox.Checked == true)
            {
                this.eaef = new Eaef(ZgcGraph1);
            }

            this.MachineVisionTimer.Interval = Convert.ToInt32(this.IntervalTxtBox.Text);
            this.MachineVisionTimer.Enabled = true;
        }

        /// <summary>
        /// disconnect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (this.MachineVisionTimer.Enabled == true)
            {
                this.MachineVisionTimer.Enabled = false;
                this.mvFile.Dispose();
            }
        }

        /// <summary>
        /// save event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.eaef.SaveData();
        }

        /// <summary>
        /// Exit event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (this.CutEdgeCheckBox.Checked == true)
            {
                this.eaef.Dispose();
            } 
            this.Close();
        }

        #endregion


    }
}
