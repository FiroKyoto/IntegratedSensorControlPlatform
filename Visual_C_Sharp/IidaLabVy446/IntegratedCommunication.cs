using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IidaLabVy446
{
    partial class IntegratedForm
    {
        private Communication.Connect connect;
        private Communication.File tcpFile;

        /// <summary>
        /// Initialize Lidar For Client
        /// </summary>
        private void InitializeLidarForClient()
        {
            this.isIniLidarInfo = false;

            this.graph = new SickLidar.Graph();
            this.graph.CreateGraph(zg1, zg3);

            this.sickLidar = new SickLidar.SickLidar(
                this.LidarSelectComboBox.SelectedIndex,
                Convert.ToDouble(this.LidarScalingTxtBox.Text)
                   );

            // openGl display
            if (this.LidarOpenGlCheckBox.Checked == true)
            {
                this.isOpenGL = true;
                this.lidarOpenGlForm = new LidarOpenGlForm(this.BodyModelComboBox.SelectedIndex);
                this.lidarOpenGlForm.Show();
            }
        }

        /// <summary>
        /// Lidar play for client
        /// </summary>
        private void LidarPlayForClient()
        {
            this.isLidarData = false;

            this.LidarInitializeInformation();

            if (this.tcpFile.lidarData.Count == this.sickLidar.dataLength)
            {
                this.sickLidar.ConvertTcpDataToPolar(this.tcpFile.lidarData);
                this.sickLidar.ConvertPolarToCartesian();
                //this.LidarPlaySplitAndMerge();
                this.graph.UpdateGraph(this.sickLidar.cartesianList, zg1, zg3, this.isOpenGL);

                if (this.isOpenGL == true)
                {
                    List<double> perpendicular =
                        this.cropStand.CalculatePerpendicular(this.sickLidar.cartesianList, sickLidar.lidarProfile);
                    this.graph.CutEdgePerpendicularGraph(perpendicular, zg1, this.isOpenGL);
                    this.drawGlIndex = (int)perpendicular[8];
                }

                this.isLidarData = true;

                this.toolStripStatusLabel4.Text = Convert.ToString(this.tcpFile.lidarReadCount);
            }
        }

        /// <summary>
        /// Initialize Combine Body For Client
        /// </summary>
        private void InitializeCombineForClient()
        {
            if (this.BodyModelComboBox.SelectedIndex == 0)
            {
                this._vy50 = new CombineBody.Vy50();
            }

            if (this.BodyModelComboBox.SelectedIndex == 1)
            {
                this._vy446 = new CombineBody.Vy446();
            }

            if (this.BodyWgs84ToCartesianCheckBox.Checked == true)
            {
                this.offLineInit = false;
                this.offLineMapX = 0.0;
                this.offLineMapY = 0.0;

                this._cgps = new FieldMap.Cgps(5, 1);

                this._offLineGraph = new FieldMap.Graph();
                this._offLineGraph.CreateGraph(zg2);
            }
        }

        /// <summary>
        /// Combine Play For Client
        /// </summary>
        private void CombinePlayForClient()
        {
            this.isTmData = false;

            if (this.BodyModelComboBox.SelectedIndex == 0 && this.tcpFile.bodyData.Count == 82)
            {
                this.CombineVy50Info(this.tcpFile.bodyData);
                this.Vy50_ReadCnt_TxtBox.Text = Convert.ToString(this.tcpFile.bodyReadCount);
            }

            if (this.BodyModelComboBox.SelectedIndex == 1 && this.tcpFile.bodyData.Count == 142)
            {
                this.CombineVy446Info(this.tcpFile.bodyData);
            }
        }

        /// <summary>
        /// Communication Connect
        /// </summary>
        private void CommunicationConnect()
        {
            if (this.TcpIpClientCheckBox.Checked == true)
            {
                this.InitializeLidarForClient();
                this.InitializeCombineForClient();
            }

            this.connect = new Communication.Connect(
                this.TcpIpServerCheckBox.Checked,
                this.TcpIpClientCheckBox.Checked,
                this.TcpIpServerIpTxtBox.Text,
                Convert.ToInt32(this.TcpIpPortTxtBox.Text)
                );

            this.tcpFile = new Communication.File();

            this.TcpIpClientIpTxtBox.Text = this.connect.debugMsg;
        }

        /// <summary>
        /// Communication Play
        /// </summary>
        private void CommunicationPlay()
        {
            if (this.TcpIpServerCheckBox.Checked == true)
            {
                this.tcpFile.sendCmdToClient = this.lidarData + " " + this.combineData;
                this.connect.ServerSendDataToClient(this.tcpFile.sendCmdToClient);
            }

            if (this.TcpIpClientCheckBox.Checked == true)
            {
                this.connect.ClientReceiveDataFromServer();

                this.tcpFile.DivideStringData(
                    this.connect.receivedData,
                    this.sickLidar.dataLength,
                    this.BodyModelComboBox.SelectedIndex
                    );

                if (this.tcpFile.lidarData != null)
                {
                    this.LidarPlayForClient();
                }

                if (this.tcpFile.bodyData != null)
                {
                    this.CombinePlayForClient();
                }
            }
        }
    }
}
