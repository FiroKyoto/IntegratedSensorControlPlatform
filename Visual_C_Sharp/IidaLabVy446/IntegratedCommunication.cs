using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;
using Joystick;

namespace IidaLabVy446
{
    partial class IntegratedForm
    {
        private Communication.Connect connect;
        private Communication.File tcpFile;
        private Joystick.G27 g27;

        private int remote_client_flag = 0;

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

            if (this.TcpIpWheelControlCheckBox.Checked == true)
            {
                this.g27 = new G27();
                this.g27.Start(this);

                this.ClientDebugTxtBox.AppendText("名称: " + this.g27.joystick.DeviceInformation.ProductName + Environment.NewLine);
                this.ClientDebugTxtBox.AppendText("軸の数: " + this.g27.joystick.Caps.NumberAxes + Environment.NewLine);
                this.ClientDebugTxtBox.AppendText("ボタンの数: " + this.g27.joystick.Caps.NumberButtons + Environment.NewLine);
                this.ClientDebugTxtBox.AppendText("PoVハットの数: " + this.g27.joystick.Caps.NumberPointOfViews + Environment.NewLine);
            }
        }

        /// <summary>
        /// Create command data for control of vy446
        /// </summary>
        /// <returns></returns>
        private string CreateCommandForVy446(bool _is_wheel)
        {
            int buzzer = 0;
            int red_lamp = 0;

            if (_is_wheel == true)
            {
                Communication.File.CmdFromClient wheel_command =
                    this.tcpFile.DivideWheelData(
                        this.g27.Controller().ToString(),
                        this.remote_client_flag,
                        Convert.ToInt32(this.ClientHstNumericUpDown.Value),
                        Convert.ToInt32(this.ClientSteerNumericUpDown.Value),
                        Convert.ToInt32(this.ClientHeaderNumericUpDown.Value)
                    );

                this.remote_client_flag = wheel_command.flag;
                this.ClientHstNumericUpDown.Value = wheel_command.hst;
                this.ClientSteerNumericUpDown.Value = wheel_command.steer;
                this.ClientHeaderNumericUpDown.Value = wheel_command.header;
                buzzer = wheel_command.buzzer;
                red_lamp = wheel_command.red_lamp;

                if (wheel_command.buzzer == 1)
                {
                    this.ClientBuzzerTxtBox.Text = "on";
                }
                else
                {
                    this.ClientBuzzerTxtBox.Text = "off";
                }

                if (wheel_command.red_lamp == 1)
                {
                    this.ClientRedLampTxtBox.Text = "on";
                }
                else
                {
                    this.ClientRedLampTxtBox.Text = "off";
                }

                if (this.remote_client_flag == 0)
                {
                    this.ClientControlFlagTxtBox.Text = "Initialize";
                    this.remote_client_flag = 0;
                    this.ClientHstNumericUpDown.Value = 1405;
                    this.ClientSteerNumericUpDown.Value = 430;
                    this.ClientHeaderNumericUpDown.Value = 650;
                    this.ClientBuzzerTxtBox.Text = "off";
                    this.ClientRedLampTxtBox.Text = "off";
                }
                else
                {
                    this.ClientControlFlagTxtBox.Text = "Sending";
                }
            }

            string command = null;
            command =
                Convert.ToString(this.remote_client_flag) + " " +
                Convert.ToString(this.ClientHstNumericUpDown.Value) + " " +
                Convert.ToString(this.ClientSteerNumericUpDown.Value) + " " +
                Convert.ToString(this.ClientHeaderNumericUpDown.Value) + " " +
                Convert.ToString(buzzer) + " " +
                Convert.ToString(red_lamp);

            return command;
        }

        /// <summary>
        /// Apply command received client to vy446
        /// </summary>
        /// <param name="_harvester_command"></param>
        private void ApplyCmdReceivedClientToVy446(Communication.File.CmdFromClient _harvester_command)
        {
            if (_harvester_command.flag == 0)
            {
                this.ServerControlFlagTxtBox.Text = "Initialize";
            }
            else if (_harvester_command.flag == 1)
            {
                this.ServerControlFlagTxtBox.Text = "Receiving";
            }

            if (this.BodyAvailableCheckBox.Checked == true && this.BodyReadCheckBox.Checked == false)
            {
                this.CombineVy446DefaultCommand();
                this.vy446_usCmdHst = Convert.ToUInt16(_harvester_command.hst);
                this.vy446_usCmdSteer = Convert.ToUInt16(_harvester_command.steer);
                this.vy446_m_ucFgKaritakaPosCtrl = true;
                this.vy446_usCmdKaritaka = Convert.ToUInt16(_harvester_command.header);

                if (_harvester_command.buzzer == 1)
                {
                    this.vy446_m_ucFgBuzzer = true;
                }
                else
                {
                    this.vy446_m_ucFgBuzzer = false;
                }

                if (_harvester_command.red_lamp == 1)
                {
                    this.vy446_RedLampChk = true;
                }
                else
                {
                    this.vy446_RedLampChk = false;
                }

                this.CombineVy446CmdSend();
            }

            this.ServerHstDebugTxtBox.Text = Convert.ToString(_harvester_command.hst);
            this.ServerSteerDebugTxtBox.Text = Convert.ToString(_harvester_command.steer);
            this.ServerHeaderDebugTxtBox.Text = Convert.ToString(_harvester_command.header);

            if (_harvester_command.buzzer == 1)
            {
                this.ServerBuzzerTxtBox.Text = "on";
            }
            else
            {
                this.ServerBuzzerTxtBox.Text = "off";
            }

            if (_harvester_command.red_lamp == 1)
            {
                this.ServerRedLampTxtBox.Text = "on";
            }
            else
            {
                this.ServerRedLampTxtBox.Text = "off";
            }
     
        }

        /// <summary>
        /// Merge sensors data of server
        /// </summary>
        private void MergeSensorsDataOfServer()
        {
            this.tcpFile.sendCmdToClient = null;

            // Add start of file flag
            this.tcpFile.sendCmdToClient += "<SOF>" + " ";

            // Add sensors flag
            if (this.LidarAvailableCheckBox.Checked == true)
            {
                this.tcpFile.sendCmdToClient += "1" + " ";
            }
            else
            {
                this.tcpFile.sendCmdToClient += "0" + " ";
            }

            if (this.BodyAvailableCheckBox.Checked == true)
            {
                this.tcpFile.sendCmdToClient += "1" + " ";
            }
            else
            {
                this.tcpFile.sendCmdToClient += "0" + " ";
            }

            // Add sensors data
            if (this.LidarAvailableCheckBox.Checked == true)
            {
                this.tcpFile.sendCmdToClient += this.lidarData + " ";
            }
            else
            {
                this.tcpFile.sendCmdToClient += "NULL" + " ";
            }

            if (this.BodyAvailableCheckBox.Checked == true)
            {
                this.tcpFile.sendCmdToClient += this.combineData + " ";
            }
            else
            {
                this.tcpFile.sendCmdToClient += "NULL" + " ";
            }

            // Add end of file flag
            this.tcpFile.sendCmdToClient += "<EOF>";
        }

        /// <summary>
        /// Communication Play
        /// </summary>
        private void CommunicationPlay()
        {
            if (this.TcpIpServerCheckBox.Checked == true)
            {
                if (this.connect.client.Connected == true)
                {
                    // Server - send command data to client.
                    this.MergeSensorsDataOfServer();
                    this.connect.ServerSendDataToClient(this.tcpFile.sendCmdToClient);

                    // Server - received data from client.
                    this.connect.ServerReceivedDataFromClient();
                    //this.RemoteReceivedReadCntTxtBox.Text = this.connect.received_data_from_client;
                    Communication.File.CmdFromClient harvester_command =
                        this.tcpFile.DivideCmdDataReceivedFromClient(this.connect.received_data_from_client);

                    this.ApplyCmdReceivedClientToVy446(harvester_command);
                }
            }

            if (this.TcpIpClientCheckBox.Checked == true)
            {
                if (this.connect.server.Connected == true)
                {
                    // client - received data from server.
                    this.connect.ClientReceiveDataFromServer();

                    this.tcpFile.DivideStringData(
                        this.connect.received_data_from_server,
                        this.sickLidar.dataLength,
                        this.BodyModelComboBox.SelectedIndex
                        );

                    if (this.tcpFile.lidar_flag == true)
                    {
                        this.LidarPlayForClient();
                    }

                    if (this.tcpFile.body_flag == true)
                    {
                        this.CombinePlayForClient();
                    }

                    // client - send command data to server.
                    string harvester_command = this.CreateCommandForVy446(this.TcpIpWheelControlCheckBox.Checked);
                    this.connect.ClientSendDataToServer(harvester_command);
                }
            }
        }
    }
}
