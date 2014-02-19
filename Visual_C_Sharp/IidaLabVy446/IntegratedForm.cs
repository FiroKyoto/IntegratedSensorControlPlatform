using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using SickLidar;
using ZedGraph;
using OpenCvSharp;
using MachineVision;
using CombineBody;
using FieldMap;
using System.Xml;
using Amedas;
using Algorithm;
using Communication;

namespace IidaLabVy446
{
    public partial class IntegratedForm : Form
    {
        #region Shared Fields

        //for read file
        private int readCount { get; set; }

        #endregion

        #region Constructor

        public IntegratedForm()
        {
            InitializeComponent();
            
            // for key event
            this.KeyPreview = true;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Connect Method
        /// </summary>
        private void ConnectMethod()
        {
            this.readCount = 0;
            this.statusStrip1.BackColor = Color.OrangeRed;

            if (this.TcpIpClientCheckBox.Checked == false)
            {
                if (this.LidarAvailableCheckBox.Checked == true)
                {
                    this.LidarConnect();
                }

                if (this.BodyAvailableCheckBox.Checked == true)
                {
                    this.CombineBodyConnect();
                }

                if (this.VisionAvailableCheckBox.Checked == true)
                {
                    this.MachineVisionConnect();
                }

                if (this.AugerAvailableCheckBox.Checked == true)
                {
                    this.AugerConnect();
                }

                // check for crop stand
                this.InitializeCropStand(
                    this.LidarAvailableCheckBox.Checked,
                    this.BodyAvailableCheckBox.Checked,
                    this.LidarOpenGlCheckBox.Checked,
                    this.AugerAvailableCheckBox.Checked,
                    this.AugerOpenGlCheckBox.Checked
                    );

                this.IntegratedTimer.Interval = Convert.ToInt32(this.TimerIntervalTxtBox.Text);
                this.IntegratedTimer.Enabled = true;
            }

            if (this.TcpIpClientCheckBox.Checked == true)
            {
                // check for crop stand
                this.InitializeCropStand(
                    this.LidarAvailableCheckBox.Checked,
                    this.BodyAvailableCheckBox.Checked,
                    this.LidarOpenGlCheckBox.Checked,
                    this.AugerAvailableCheckBox.Checked,
                    this.AugerOpenGlCheckBox.Checked
                    );
            }

            if (this.TcpIpIsAvailableCheckBox.Checked == true)
            {
                this.CommunicationConnect();
                this.CommunicationTimer.Interval = Convert.ToInt32(this.TimerIntervalTxtBox.Text);
                this.CommunicationTimer.Enabled = true;
            }

        }

        /// <summary>
        /// connect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.ConnectMethod();
        }

        /// <summary>
        /// Disconnect Method
        /// </summary>
        private void DisconnectMethod()
        {
            this.statusStrip1.BackColor = Color.Transparent;

            if (this.IntegratedTimer.Enabled == true)
            {
                this.IntegratedTimer.Enabled = false;

                if (this.LidarAvailableCheckBox.Checked == true)
                {
                    if (this.LidarReadCheckBox.Checked == false)
                    {
                        if (this.LidarSaveCheckBox.Checked == true)
                        {
                            this.lidarFile.closeSave();
                        }

                        this.sickLidar.DisconnectSocket();
                    }
                }

                if (this.VisionAvailableCheckBox.Checked == true)
                {
                    this.mvFile.Dispose();
                }

                if (this.BodyAvailableCheckBox.Checked == true)
                {
                    if (this.BodyReadCheckBox.Checked == false)
                    {
                        if (this.BodySaveCheckBox.Checked == true)
                        {
                            this._bodyFile.closeSave();
                        }

                        //if (this.LidarHeaderControlCheckBox.Checked == true)
                        //{
                        //    this.CombineBodyHeaderControl(true, false);
                        //}
                        
                        this._bodySerialConnect.Dispose();
                    }
                    else
                    {
                        if (this.BodyGeMapCheckBox.Checked == true)
                        {
                            this._drawMap.Dispose(this.GeWebBrowser);
                        }
                    }
                }

                if (this.AugerAvailableCheckBox.Checked == true)
                {
                    this.AugerDisconnect();
                }
            }
            else
            {
            }

            if (this.CommunicationTimer.Enabled == true)
            {
                this.CommunicationTimer.Enabled = false;

                if (this.TcpIpIsAvailableCheckBox.Checked == true)
                {
                    if (this.TcpIpClientCheckBox.Checked == true)
                    {
                        this.connect.ClientDispose();
                    }

                    if (this.TcpIpServerCheckBox.Checked == true)
                    {
                        this.connect.ServerDispose();
                    }
                }
            }
            else
            {
            }
        }

        /// <summary>
        /// disconnect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            this.DisconnectMethod();
        }

        /// <summary>
        /// Exit event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Communication Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommunicationTimer_Tick(object sender, EventArgs e)
        {
            if (this.TcpIpIsAvailableCheckBox.Checked == true)
            {
                if (this.TcpIpClientCheckBox.Checked == true)
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();

                    this.CommunicationPlay();

                    // for Draw 3D Map on OpenGL 
                    this.Draw3DMap();

                    watch.Stop();
                    this.toolStripStatusLabel2.Text =
                        Convert.ToString(watch.Elapsed.TotalMilliseconds) + " milliseconds";
                }
                else
                {
                    this.CommunicationPlay();
                }
            }
        }

        /// <summary>
        /// Hardware Timer Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntegratedTimer_Tick(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            if (this.VisionAvailableCheckBox.Checked == true)
            {
                this.MachineVisionPlay();
            }

            if (this.LidarAvailableCheckBox.Checked == true)
            {
                this.LidarPlay();
            }

            if (this.BodyAvailableCheckBox.Checked == true)
            {
                this.CombineBodyPlay();
            }

            if (this.AugerAvailableCheckBox.Checked == true)
            {
                this.AugerPlay();
            }

            // for Draw 3D Map on OpenGL
            this.Draw3DMap();

            // Guidance Method
            this.GuidanceRun(this.Vy50_ROBOTMODE_CheckBox.Checked, this.Vy446_RobotMode_CheckBox.Checked, this.BodyModelComboBox.SelectedIndex);

            this.readCount++;

            watch.Stop();
            this.toolStripStatusLabel2.Text =
                Convert.ToString(watch.Elapsed.TotalMilliseconds) + " milliseconds";
            this.toolStripStatusLabel4.Text = Convert.ToString(this.readCount);
        }

        /// <summary>
        /// amedas weather - save event button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AmedasSaveButton_Click(object sender, EventArgs e)
        {
            this.AmedasSaveDataToXml();
        }

        /// <summary>
        /// amedas weather - show event button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AmedasShowButton_Click(object sender, EventArgs e)
        {
            this.AmedasXmlToGrid();
        }

        /// <summary>
        /// Send command to combine ecu event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vy50_SendData_Button_Click(object sender, EventArgs e)
        {
            this.CombineVy50CmdSend();
        }

        /// <summary>
        /// Set command to Combine ECU event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vy446_SendData_Button_Click(object sender, EventArgs e)
        {
            //this.CombineVy446CmdSend();
            this.CombineVy446ManualSetCommand();
        }

        /// <summary>
        /// If you press the key then event is excute.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntegratedForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ASCII value of escape key is 27.
            // toolStripStatusLabel4.Text = "Escape";

            if (e.KeyChar == Convert.ToChar("c"))
            {
                this.ConnectMethod();
            }

            if (e.KeyChar == Convert.ToChar("d"))
            {
                this.DisconnectMethod();
            }

            if (e.KeyChar == Convert.ToChar("q"))
            {
                this.Close();
            }
        }

        /// <summary>
        /// Initialize WebBrowser event for google earth 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BodyGeMapCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            // for google earth
            this._drawMap = new FieldMap.DrawMap(this.GeWebBrowser);
            this.toolStripStatusLabel4.Text = this._drawMap.debugMsg;
        }

        #endregion

    }
}
