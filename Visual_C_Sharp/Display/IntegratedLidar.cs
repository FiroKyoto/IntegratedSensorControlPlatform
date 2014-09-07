using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Display
{
    partial class IntegratedForm
    {
        private SickLidar.Graph graph;
        private SickLidar.SickLidar sickLidar;
        private SickLidar.File lidarFile;
        private LidarOpenGlForm lidarOpenGlForm;

        /// <summary>
        /// gets or sets is openGL?
        /// </summary>
        private bool isOpenGL { get; set; }

        /// <summary>
        /// gets or sets index of discriminate between ground and uncut crop
        /// </summary>
        private int drawGlIndex { get; set; }

        /// <summary>
        /// gets or sets initialize lidar info
        /// </summary>
        private bool isIniLidarInfo { get; set; }

        /// <summary>
        /// gets or sets measured lidar data
        /// </summary>
        private bool isLidarData { get; set; }

        /// <summary>
        /// gets or sets lidar data of string type
        /// </summary>
        private string lidarData { get; set; }

        /// <summary>
        /// Initialize Lidar Sensor
        /// </summary>
        private void LidarConnect()
        {
            this.isIniLidarInfo = false;

            this.graph = new SickLidar.Graph();
            this.graph.CreateGraph(zg1, zg3);

            if (this.LidarReadCheckBox.Checked == false)
            {
                this.sickLidar = new SickLidar.SickLidar(
                    this.LidarHostTxtBox.Text,
                    Convert.ToInt32(this.LidarPortTxtBox.Text),
                    this.LidarSelectComboBox.SelectedIndex,
                    Convert.ToDouble(this.LidarScalingTxtBox.Text),
                    false
                    );

                if (this.LidarSaveCheckBox.Checked == true)
                {
                    this.lidarFile = new SickLidar.File(
                        this.LidarSaveCheckBox.Checked,
                        this.LidarReadCheckBox.Checked
                        );
                }

            }
            else
            {
                this.sickLidar = new SickLidar.SickLidar(
                    this.LidarSelectComboBox.SelectedIndex,
                    Convert.ToDouble(this.LidarScalingTxtBox.Text)
                       );

                this.lidarFile = new SickLidar.File(
                    this.LidarSaveCheckBox.Checked,
                    this.LidarReadCheckBox.Checked
                    );
            }

            // openGl display
            if (this.LidarOpenGlCheckBox.Checked == true)
            {
                this.isOpenGL = true;
                this.lidarOpenGlForm = new LidarOpenGlForm(this.BodyModelComboBox.SelectedIndex);
                this.lidarOpenGlForm.Show();
            }
        }

        /// <summary>
        /// Revised 2013-06-13
        /// Play Lidar Sensor
        /// </summary>
        private void LidarPlay()
        {
            this.isLidarData = false;

            if (this.LidarReadCheckBox.Checked == false)
            {
                this.sickLidar.RequestScan();
                this.sickLidar.ConvertHexToPolar();
                this.sickLidar.ConvertPolarToCartesian();
                this.graph.UpdateGraph(this.sickLidar.cartesianList, zg1, zg3, this.isOpenGL);

                // revised 2013-06-13
                if (this.isOpenGL == true)
                {
                    List<double> perpendicular =
                        this.cropStand.CalculatePerpendicular(this.sickLidar.cartesianList, sickLidar.lidarProfile);
                    this.graph.CutEdgePerpendicularGraph(perpendicular, zg1, this.isOpenGL);
                    this.drawGlIndex = (int)perpendicular[8];
                }

                this.isLidarData = true;

                if (this.LidarSaveCheckBox.Checked == true)
                {
                    this.lidarFile.addDataForSave(this.sickLidar.orgList);
                }
            }
            else
            {
                if (this.lidarFile.readData.Length > this.readCount)
                {
                    this.sickLidar.ConvertReadDataToPolar(this.readCount, this.lidarFile.readData);
                    this.sickLidar.ConvertPolarToCartesian();
                    this.graph.UpdateGraph(this.sickLidar.cartesianList, zg1, zg3, this.isOpenGL);

                    if (this.isOpenGL == true)
                    {
                        List<double> perpendicular =
                            this.cropStand.CalculatePerpendicular(this.sickLidar.cartesianList, sickLidar.lidarProfile);
                        this.graph.CutEdgePerpendicularGraph(perpendicular, zg1, this.isOpenGL);
                        this.drawGlIndex = (int)perpendicular[8];
                    }

                    this.isLidarData = true;
                    //this.readCount++;
                }
                else
                {
                    //this.SickTimer.Enabled = false;
                }
            }

            this.LidarInitializeInformation();

            // server mode
            if (this.TcpIpServerCheckBox.Checked == true)
            {
                this.lidarData = this.tcpFile.AddToString(this.readCount, this.sickLidar.orgList);
            }
        }

        /// <summary>
        /// initialize device information
        /// </summary>
        private void LidarInitializeInformation()
        {
            if (this.isIniLidarInfo == false)
            {
                this.LidarDeviceInfoLengthTxtBox.Text = Convert.ToString(this.sickLidar.dataLength);
                this.LidarDeviceInfoResolutionTxtBox.Text = Convert.ToString(this.sickLidar.steps);
                this.LidarDeviceInfoStartAngleTxtBox.Text = Convert.ToString(this.sickLidar.startAngle);
                this.isIniLidarInfo = true;
            }
        }
    }
}
