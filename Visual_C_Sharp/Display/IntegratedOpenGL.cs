using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Display
{
    partial class IntegratedForm
    {
        private Algorithm.CropStand cropStand;
        private double backTmX { get; set; }
        private double backTmY { get; set; }
        private double backTmZ { get; set; }
        private double backHeading { get; set; }
        private double backSpeed { get; set; }
        private bool isFirstBodyTm { get; set; }
        //private bool isSaveLidarData { get; set; }
        private bool isHarvestMode { get; set; }
        private bool isBackward { get; set; }


        /// <summary>
        /// initialization of crop stand class
        /// </summary>
        /// <param name="_isLidar"></param>
        /// <param name="_isBody"></param>
        /// <param name="_isLidarOpenGL"></param>
        /// <param name="_isAuger"></param>
        /// <param name="_isAugerOpenGL"></param>
        private void InitializeCropStand(bool _isLidar, bool _isBody, bool _isLidarOpenGL, bool _isAuger, bool _isAugerOpenGL)
        {
            bool is_initialize = false;

            // for 3D Terrain Map on OpenGL form
            if ((_isLidar == true) && (_isBody == true) && (_isLidarOpenGL == true))
            {
                is_initialize = true;
            }

            // for 3D Grain Tank Map on OpenGL form
            if ((_isAuger == true) && (_isBody == true) && (_isAugerOpenGL == true))
            {
                is_initialize = true;
            }

            if (is_initialize == true)
            {
                this.cropStand = new Algorithm.CropStand(this.BodyModelComboBox.SelectedIndex);
                this.isFirstBodyTm = false;
                //this.isSaveLidarData = true; 
            }
        }

        /// <summary>
        /// Draw 3D Map using various sensors
        /// </summary>
        private void Draw3DMap()
        {
            // for draw 3D terrain Map on openGL
            if ((this.LidarAvailableCheckBox.Checked == true) && (this.BodyAvailableCheckBox.Checked == true) && (this.LidarOpenGlCheckBox.Checked == true))
            {
                this.Draw3DTerrainMap(this.isLidarData, this.isTmData);
            }

            // for draw 3D Grain Tank Map
            if ((this.AugerAvailableCheckBox.Checked == true) && (this.BodyAvailableCheckBox.Checked == true) && (this.AugerOpenGlCheckBox.Checked == true))
            {
                this.Draw3DGrainTankMap(this.isAugerLidarData, this.isTmData);
            }
        }

        /// <summary>
        /// ideal path count
        /// </summary>
        private int ideal_path_count = 0;

        /// <summary>
        /// Revised 2013-06-12
        /// Draw 3D Terrain Map on LidarOpenGL Form
        /// </summary>
        /// <param name="_lidar"></param>
        /// <param name="_tm"></param>
        private void Draw3DTerrainMap(bool _lidar, bool _tm)
        {
            if (_tm == true)
            {
                this.isFirstBodyTm = true;
            }

            if (_lidar == true && this.isFirstBodyTm == true)
            {
                if (_tm == true)
                {
                    if (this.BodyModelComboBox.SelectedIndex == 0)
                    {
                        // vy50 model
                        this.backHeading = this._vy50.gps_Heading;
                        this.backSpeed = this._vy50.d_Speed;

                        // Potentiometer neutral = 125
                        if (this._vy50.uc_MainPotentio < 125)
                        {
                            this.isBackward = true;
                        }
                        else
                        {
                            this.isBackward = false;
                        }
                    }

                    if (this.BodyModelComboBox.SelectedIndex == 1)
                    {
                        // Vy446 model
                        this.backHeading = this._vy446.gps_Compass;
                        //this.backHeading = this._vy446.compass;
                        this.backSpeed = this._vy446.fSpeed;

                        // Potentiometer neutral = 1405
                        if (this._vy446.AD_FEED_M < 1405)
                        {
                            this.isBackward = true;
                        }
                        else
                        {
                            this.isBackward = false;
                        }
                    }

                    this.backTmX = this.tmX;
                    this.backTmY = this.tmY;
                    this.backTmZ = this.tmZ;
                }
                else
                {
                    this.cropStand.NewTm(this.isBackward, this.backTmX, this.backTmY, this.backTmZ, this.backHeading, this.backSpeed, Convert.ToInt32(this.TimerIntervalTxtBox.Text));
                    this.backTmX = this.cropStand.NewTmX;
                    this.backTmY = this.cropStand.NewTmY;
                    this.backTmZ = this.cropStand.NewTmZ;
                }

                this.isHarvestMode = false;
                if ((this.BodyModelComboBox.SelectedIndex == 0) && (this._vy50.uc_HeaderPos < 100))
                {
                    this.isHarvestMode = true;
                }
                else if ((this.BodyModelComboBox.SelectedIndex == 1) && (this._vy446.AD_KARI_L < 650))
                {
                    this.isHarvestMode = true;
                }

                // send debug information to lidarForm
                this.lidarOpenGlForm.BodyInformation(this.readCount, this.backTmX, this.backTmY, this.backTmZ, this.backHeading, this.backSpeed);

                if (this.isHarvestMode == true)
                {
                    // initialization of ideal path
                    this.cropStand.QuadrantOfIdealPath(this.backHeading);
                    if (this.ideal_path_count != this.cropStand.ideal_path_count)
                    {
                        this.cropStand.CreateIdealPath(this.backTmX, this.backTmY, this.backHeading);
                        this.ideal_path_count = this.cropStand.ideal_path_count;
                    }

                    this.cropStand.CalculatePosition(this.sickLidar.cartesianList, this.backTmX, this.backTmY, this.backTmZ, this.backHeading);

                    // save cartesian lidar data
                    //if (this.isSaveLidarData == true)
                    //{
                    //    this.cropStand.SaveLidarData(this.sickLidar.cartesianList);
                    //    this.isSaveLidarData = false;
                    //}

                    // discriminate uncut crop and ground
                    this.cropStand.AddDiscriminatePoints(this.cropStand.result, this.drawGlIndex);

                    // calculate of Perpendicular distance between Header position and Extracted Ransac
                    this.cropStand.HeaderToRansacDistance(this.backTmX, this.backTmY);

                    // calculate perpendicular distance and angle of between Ideal path and Current Gps position
                    this.cropStand.IdealPathToGps(this.backTmX, this.backTmY);

                    // Ransac state debug
                    this.lidarOpenGlForm.RansacStateDebug(this.cropStand.is_ransac_start, this.cropStand.is_ransac_running, this.cropStand.is_ransac_end, this.cropStand.ran_distance_between_points);

                    // Ransac result debug
                    this.lidarOpenGlForm.RansacResultDebug(this.cropStand.ran_angle, this.cropStand.ran_distance, this.cropStand.ran_standard_distance, this.cropStand.ran_to_header_angle);

                    // add crop
                    this.lidarOpenGlForm.AddCrop(this.cropStand.result, this.drawGlIndex);

                    // add edge into OpenGlForm
                    this.lidarOpenGlForm.AddEdge(this.cropStand.ran_result, this.cropStand.is_ransac_running);

                    // add ideal path into OpenGlForm
                    this.lidarOpenGlForm.AddIdealPath(this.cropStand.ideal_path_result);

                    // ideal path to gps debug
                    this.lidarOpenGlForm.IdealToGpsResultDebug(this.cropStand.gps_distance, this.cropStand.gps_angle, this.cropStand.ideal_path_angle);
                }
                else
                {
                    this.cropStand.UnHarvestMode();
                }

                this.lidarOpenGlForm.GlUpdate();
            }
        }

        private double back_DT_AUG_MTR { get; set; }
        private double back_DT_AUG_CLD { get; set; }
        private bool is_save_auger_data = false;

        /// <summary>
        /// Revised 2014-01-24 by wonjae cho
        /// Draw 3D Grain Tank Map on AugerOpenGL Form
        /// </summary>
        /// <param name="_lidar"></param>
        /// <param name="_tm"></param>
        private void Draw3DGrainTankMap(bool _lidar, bool _tm)
        {
            if (_tm == true)
            {
                this.isFirstBodyTm = true;
            }

            if (_lidar == true && this.isFirstBodyTm == true)
            {
                if (_tm == true)
                {
                    if (this.BodyModelComboBox.SelectedIndex == 0)
                    {
                        // vy50 model
                        this.backHeading = this._vy50.gps_Heading;
                        this.backSpeed = this._vy50.d_Speed;

                        // Potentiometer neutral = 125
                        if (this._vy50.uc_MainPotentio < 125)
                        {
                            this.isBackward = true;
                        }
                        else
                        {
                            this.isBackward = false;
                        }
                    }

                    if (this.BodyModelComboBox.SelectedIndex == 1)
                    {
                        // Vy446 model
                        this.backHeading = this._vy446.gps_Compass;
                        //this.backHeading = this._vy446.compass;
                        this.backSpeed = this._vy446.fSpeed;

                        // Potentiometer neutral = 1405
                        if (this._vy446.AD_FEED_M < 1405)
                        {
                            this.isBackward = true;
                        }
                        else
                        {
                            this.isBackward = false;
                        }

                        this.back_DT_AUG_MTR = this._vy446.DT_AUG_MTR;
                        this.back_DT_AUG_CLD = this._vy446.DT_AUG_CLD;
                    }

                    this.backTmX = this.tmX;
                    this.backTmY = this.tmY;
                    this.backTmZ = this.tmZ;
                }
                else
                {
                    this.cropStand.NewTm(this.isBackward, this.backTmX, this.backTmY, this.backTmZ, this.backHeading, this.backSpeed, Convert.ToInt32(this.TimerIntervalTxtBox.Text));
                    this.backTmX = this.cropStand.NewTmX;
                    this.backTmY = this.cropStand.NewTmY;
                    this.backTmZ = this.cropStand.NewTmZ;
                }

                // send debug information to lidarForm
                this.augerOpenGlForm.BodyInformation(this.readCount, this.backTmX, this.backTmY, this.backTmZ, this.backHeading, this.backSpeed, this.back_DT_AUG_MTR, this.back_DT_AUG_CLD, this._vy446.AD_FEED_M);

                // Convert Hokuyo original data to 3D points in world coordinates system.
                this.augerOpenGlForm.ConvertLidarPoints(this._hokuyo.org_list_data, this._hokuyo.read_index_to_radian);

                // openGL form update
                this.is_save_auger_data = true;
                this.augerOpenGlForm.GlUpdate();
            }
            else
            {
                this.is_save_auger_data = false;
            }

            // save revised body position data to .txt file and Draw square in image
            this.augerOpenGlForm.SaveData(this.is_save_auger_data);
        }
    }
}
