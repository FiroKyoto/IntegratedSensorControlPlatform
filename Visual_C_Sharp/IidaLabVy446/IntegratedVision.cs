using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IidaLabVy446
{
    partial class IntegratedForm
    {
        private MachineVision.File mvFile;
        private Algorithm.ObjectDetection objectDetection;

        /// <summary>
        /// Machine Vision Connect
        /// </summary>
        private void MachineVisionConnect()
        {
            this.mvFile = new MachineVision.File(
               this.VisionSaveCheckBox.Checked,
               this.VisionReadCheckBox.Checked,
               Convert.ToInt32(this.TimerIntervalTxtBox.Text)
               );

            // object detection
            if (this.VisionObjectDetectionCheckBox.Checked == true)
            {
                this.objectDetection = new Algorithm.ObjectDetection();
            }
        }

        /// <summary>
        /// Machine Vision Play
        /// </summary>
        private void MachineVisionPlay()
        {
            if (this.mvFile.cap.QueryFrame() != null)
            {
                if (this.VisionSaveCheckBox.Checked == true)
                {
                    this.mvFile.VideoWriter(this.mvFile.cap.QueryFrame(), this.readCount);
                }

                // object detection
                if (this.VisionObjectDetectionCheckBox.Checked == true)
                {
                    //this.objectDetection.OpticalFlowLK(this.mvFile.cap.QueryFrame());
                    this.objectDetection.OpticalFlowPyramidalLK(this.mvFile.cap.QueryFrame());
                    this.pBoxIpl1.ImageIpl = this.objectDetection.dstImg;
                }
                else
                {
                    this.pBoxIpl1.ImageIpl = this.mvFile.cap.QueryFrame();
                }
            }
            else
            {
                this.toolStripStatusLabel4.Text = "Cannot read image from QueryFrame";
                //this.MachineVisionTimer.Enabled = false;
                //this.mvFile.Dispose();
            }
        }
    }
}
