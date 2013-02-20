using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SickLidar;
using System.Diagnostics;

namespace IidaLabVy446
{
    public partial class LidarForm : Form
    {
        private SickLidar.Graph graph;
        private SickLidar.SickLidar sickLidar;
        private SickLidar.File lidarFile;

        //for read file
        private int readLidarCount { get; set; }

        /// <summary>
        /// basic constructor
        /// </summary>
        public LidarForm()
        {
            this.graph = new Graph();
            InitializeComponent();
            this.graph.CreateGraph(zg1);
        }

        /// <summary>
        /// connect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (this.ReadCheckBox.Checked == false)
            {
                this.sickLidar = new SickLidar.SickLidar(
                    this.HostTxtBox.Text,
                    Convert.ToInt32(this.PortTxtBox.Text),
                    this.SelectDeviceComBox.SelectedIndex,
                    Convert.ToInt32(this.ScalingFactorTxtBox.Text),
                    false
                    );

                if (this.SaveCheckBox.Checked == true)
                {
                    this.lidarFile = new File(this.SaveCheckBox.Checked, this.ReadCheckBox.Checked);
                }

            }
            else
            {
                this.sickLidar = new SickLidar.SickLidar(
                    this.SelectDeviceComBox.SelectedIndex,
                    Convert.ToInt32(this.ScalingFactorTxtBox.Text)
                       );

                this.lidarFile = new File(this.SaveCheckBox.Checked, this.ReadCheckBox.Checked);
            }

            this.SickTimer.Interval = Convert.ToInt32(this.IntervalTxtBox.Text);
            this.SickTimer.Enabled = true;
        }

        /// <summary>
        /// timer event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SickTimer_Tick(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            if (this.ReadCheckBox.Checked == false)
            {
                this.sickLidar.RequestScan();
                this.sickLidar.ConvertHexToPolar();
                this.sickLidar.ConvertPolarToCartesian();
                this.graph.UpdateGraph(this.sickLidar.cartesianList, zg1, false);

                if (this.SaveCheckBox.Checked == true)
                {
                    this.lidarFile.addDataForSave(this.sickLidar.orgList);
                }
            }
            else
            {
                if (this.lidarFile.readData.Length > this.readLidarCount)
                {
                    this.sickLidar.ConvertReadDataToPolar(this.readLidarCount, this.lidarFile.readData);
                    this.sickLidar.ConvertPolarToCartesian();
                    this.graph.UpdateGraph(this.sickLidar.cartesianList, zg1, false);
                    this.readLidarCount++;
                }
                else
                {
                    this.SickTimer.Enabled = false;
                }
            }

            watch.Stop();
            this.toolStripStatusLabel2.Text =
                Convert.ToString(watch.Elapsed.TotalMilliseconds) + " milliseconds";
        }

        /// <summary>
        /// disconnect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (this.ReadCheckBox.Checked == false)
            {
                if (this.SaveCheckBox.Checked == true)
                {
                    this.lidarFile.closeSave();
                }
                this.SickTimer.Enabled = false;
                this.sickLidar.DisconnectSocket();
            }
            else
            {
                this.SickTimer.Enabled = false;
            }
        }

        /// <summary>
        /// exit event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
