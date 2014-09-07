using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace Display
{
    partial class IntegratedForm
    {
        /// <summary>
        /// hokuyo lidar sensor
        /// </summary>
        private SickLidar.Hokuyo _hokuyo;

        /// <summary>
        /// hokuyo lidar sensor graph
        /// </summary>
        private SickLidar.Graph _hokuyo_graph;

        /// <summary>
        /// hokuyo lidar sensor I/O
        /// </summary>
        private SickLidar.File _hokuyo_file;

        /// <summary>
        /// gets or sets measured data of mounted auger lidar
        /// </summary>
        private bool isAugerLidarData { get; set; }

        /// <summary>
        /// 3d-imager (made by panasonic)
        /// </summary>
        private MachineVision.Dimager dImager;

        /// <summary>
        /// 3d-imager save and read
        /// </summary>
        private MachineVision.File dImager_io;

        /// <summary>
        /// depth image of 3d-imager
        /// </summary>
        private IplImage dImager_depth_image;

        /// <summary>
        /// gets or sets Connected dImager Driver
        /// </summary>
        private int dImager_Driver { get; set; }

        /// <summary>
        /// 3D grain tank model
        /// </summary>
        private AugerOpenGlForm augerOpenGlForm;

        /// <summary>
        /// initialization of 3d-imager
        /// </summary>
        private void Panasonic3DImagerConnect()
        {
            this.dImager = new MachineVision.Dimager();
            this.dImager_depth_image = new IplImage(160, 120, BitDepth.U8, 3);

            // 1. InitImageDriver
            this.dImager_Driver = this.dImager.D_InitImageDriver();
            if (this.dImager_Driver == 0)
            {
                this.DImagerIniDriverTxtBox.Text = "Successed";
            }
            else
            {
                this.DImagerIniDriverTxtBox.Text = "Fail";
            }

            // 2. Speedmode
            int valSpeedmode = this.dImager.D_Speedmode();
            switch (valSpeedmode)
            {
                case 15:
                    this.DImagerSpeedModeTxtBox.Text = "15fps";
                    break;

                case 20:
                    this.DImagerSpeedModeTxtBox.Text = "20fps";
                    break;

                case 25:
                    this.DImagerSpeedModeTxtBox.Text = "25fps";
                    break;

                case 30:
                    this.DImagerSpeedModeTxtBox.Text = "30fps";
                    break;

                case 99:
                    this.DImagerSpeedModeTxtBox.Text = "Fail";
                    break;
            }

            // 3. Freqmode
            int valFreqmode = this.dImager.D_Freqmode();
            switch (valFreqmode)
            {
                case 0:
                    this.DImagerFreqModeTxtBox.Text = "frequency 1";
                    break;

                case 1:
                    this.DImagerFreqModeTxtBox.Text = "frequency 2";
                    break;

                case 2:
                    this.DImagerFreqModeTxtBox.Text = "frequency 3";
                    break;

                case 3:
                    this.DImagerFreqModeTxtBox.Text = "Fail";
                    break;
            }
        }

        /// <summary>
        /// Convert raw data of 3d-imager to openCV IplImage
        /// </summary>
        private void ConvertDImagerDataToCvImg()
        {
            this.dImager.D_GetImageKN();

            // ndat : Pointer of the grayscale image data acquiring buffer.
            // kdat : Pointer of the range image data acquiring buffer.
            unsafe
            {
                byte* src = (byte*)dImager_depth_image.ImageData;
                for (int y = 0; y < dImager_depth_image.Height; y++)
                {
                    int k_offset = dImager_depth_image.Width * y;
                    for (int x = 0; x < dImager_depth_image.Width; x++)
                    {
                        int offset = (dImager_depth_image.WidthStep * y) + (x * 3);
                        src[offset + 0] = (byte)this.dImager.kdat[k_offset + x];
                        src[offset + 1] = (byte)this.dImager.kdat[k_offset + x];
                        src[offset + 2] = (byte)this.dImager.kdat[k_offset + x];
                    }
                }
            }
        }

        /// <summary>
        /// Auger mounted device connect method - hokuyo lidar sensor and 3D-Imager
        /// Revised 2013-10-16 by wonjae cho
        /// </summary>
        private void AugerConnect()
        {
            this._hokuyo_graph = new SickLidar.Graph();
            this._hokuyo_graph.CreateHokuyoGraph(zg4, "Hokuyo Lidar", "X(mm)", "Y(mm)");

            if (this.AugerReadCheckBox.Checked == false)
            {
                // lidar sensor connect
                if (this.AugerLidarCheckBox.Checked == true)
                {
                    this._hokuyo = new SickLidar.Hokuyo(this.AugerLidarComboBox.SelectedIndex, 19200);

                    // if hokuyo sensor connected then save data to txt file 
                    if ((this.AugerSaveCheckBox.Checked == true) && (this._hokuyo.is_connected_sensor == true))
                    {
                        this._hokuyo_file = new SickLidar.File(this.AugerSaveCheckBox.Checked, this.AugerReadCheckBox.Checked);
                    }
                }
                else
                {
                }

                // 3d-imager sensor connect
                if (this.AugerDImagerCheckBox.Checked == true)
                {
                    this.Panasonic3DImagerConnect();

                    // if 3d-imager sensor connected then save data to mpeg format
                    if ((this.AugerSaveCheckBox.Checked == true) && (this.dImager_Driver == 0))
                    {
                        this.dImager_io = new MachineVision.File();
                        this.dImager_io.InitializeDImagerIO(this.AugerSaveCheckBox.Checked, this.AugerReadCheckBox.Checked, Convert.ToInt32(this.TimerIntervalTxtBox.Text));
                    }
                }
                else
                {
                }
            }
            else
            {
                if (this.AugerLidarCheckBox.Checked == true)
                {
                    this._hokuyo = new SickLidar.Hokuyo();
                    this._hokuyo_file = new SickLidar.File(this.AugerSaveCheckBox.Checked, this.AugerReadCheckBox.Checked);
                }

                if (this.AugerDImagerCheckBox.Checked == true)
                {
                    this.dImager_io = new MachineVision.File();
                    this.dImager_io.InitializeDImagerIO(this.AugerSaveCheckBox.Checked, this.AugerReadCheckBox.Checked, Convert.ToInt32(this.TimerIntervalTxtBox.Text));
                }
            }

            // Auger OpenGL form
            if (this.AugerOpenGlCheckBox.Checked == true)
            {
                this.augerOpenGlForm = new AugerOpenGlForm(this.BodyModelComboBox.SelectedIndex, this.AugerReadCheckBox.Checked);
                this.augerOpenGlForm.Show();
            }
        }

        /// <summary>
        /// Auger play method
        /// Revised 2013-10-16 by wonjae cho
        /// </summary>
        private void AugerPlay()
        {
            this.isAugerLidarData = false;

            if (this.AugerReadCheckBox.Checked == false)
            {
                if ((this.AugerLidarCheckBox.Checked == true) && (this._hokuyo.is_connected_sensor == true))
                {
                    this._hokuyo.ReceivedData();
                    this._hokuyo_graph.UpdateHokuyoGraph(this._hokuyo.cartesian_data, zg4);

                    // add data to txt file
                    if (this.AugerSaveCheckBox.Checked == true)
                    {
                        this._hokuyo_file.addDataForSave(this._hokuyo.org_list_data);
                    }

                    this.isAugerLidarData = true;
                }

                if ((this.AugerDImagerCheckBox.Checked == true) && (this.dImager_Driver == 0))
                {
                    this.ConvertDImagerDataToCvImg();
                    this.DImagerDepthPboxIpl.ImageIpl = this.dImager_depth_image;

                    // add image to mpeg
                    if (this.AugerSaveCheckBox.Checked == true)
                    {
                        this.dImager_io.DImagerWriter(this.dImager_depth_image);
                    }
                }
            }
            else
            {
                if ((this.AugerLidarCheckBox.Checked == true) && (this._hokuyo_file.readData.Length > this.readCount))
                {
                    this._hokuyo.ConvertReadData(this.readCount, this._hokuyo_file.readData);
                    this._hokuyo_graph.UpdateHokuyoGraph(this._hokuyo.cartesian_data, zg4);

                    this.isAugerLidarData = true;
                }

                if ((this.AugerDImagerCheckBox.Checked == true) && (this.dImager_io.cap.QueryFrame() != null))
                {
                    this.DImagerDepthPboxIpl.ImageIpl = this.dImager_io.cap.QueryFrame();
                }
            }
        }

        /// <summary>
        /// Auger disconnect method
        /// </summary>
        private void AugerDisconnect()
        {
            if (this.AugerReadCheckBox.Checked == false)
            {
                if ((this.AugerLidarCheckBox.Checked == true) && (this._hokuyo.is_connected_sensor == true))
                {
                    if (this.AugerSaveCheckBox.Checked == true)
                    {
                        this._hokuyo_file.closeSave();
                    }

                    this._hokuyo.Disconnect();
                }

                if ((this.AugerDImagerCheckBox.Checked == true) && (this.dImager_Driver == 0))
                {
                    if (this.AugerSaveCheckBox.Checked == true)
                    {
                        this.dImager_io.Dispose();
                    }

                    int value = this.dImager.D_FreeImageDriver();
                    if (value == 0)
                    {
                        this.DImagerIniDriverTxtBox.Text = "Successed Disconnect";
                    }
                    else
                    {
                        this.DImagerIniDriverTxtBox.Text = "Fail Disconnect";
                    }
                }
            }
            else
            {
                if (this.AugerDImagerCheckBox.Checked == true)
                {
                    this.dImager_io.Dispose();
                }
            }
        }
    }
}
