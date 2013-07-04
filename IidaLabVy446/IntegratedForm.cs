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

        #region Laser Range Finder

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

        #endregion

        #region Machine Vision

        private MachineVision.File mvFile;

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

                this.pBoxIpl1.ImageIpl = this.mvFile.cap.QueryFrame();
            }
            else
            {
                this.toolStripStatusLabel4.Text = "Cannot read image from QueryFrame";
                //this.MachineVisionTimer.Enabled = false;
                //this.mvFile.Dispose();
            }
        }

        #endregion

        #region Combine Body

        private CombineBody.SerialConnect _bodySerialConnect;
        private CombineBody.File _bodyFile;
        private CombineBody.Vy50 _vy50;
        private CombineBody.Vy446 _vy446;
        private FieldMap.Cgps _cgps;
        private FieldMap.Graph _offLineGraph;
        private FieldMap.DrawMap _drawMap;

        /// <summary>
        /// combine data of string type
        /// </summary>
        private string combineData { get; set; }

        private bool offLineInit { get; set; }
        private double offLineMapX { get; set; }
        private double offLineMapY { get; set; }

        /// <summary>
        /// Transverse Mecartor 
        /// </summary>
        private double tmX { get; set; }
        private double tmY { get; set; }
        private double tmZ { get; set; }
        private bool isTmData { get; set; }

        /// <summary>
        /// 1. ロボットモード切替のチェック取得
        /// </summary>
        private bool vy446_m_iRobotMode { get; set; }

        /// <summary>
        /// 2. 刈取クラッチのラジオボタン取得
        /// </summary>
        private bool vy446_KaritoriRadio { get; set; }

        /// <summary>
        /// 3. 作業機クラッチのラジオボタン取得
        /// </summary>
        private bool vy446_SagyokiRadio { get; set; }

        /// <summary>
        /// 4. クラッチオフのラジオボタン取得
        /// </summary>
        private bool vy446_SagyokiOffRadio { get; set; }

        /// <summary>
        /// 5. 強制掻込スイッチ
        /// </summary>
        private bool vy446_m_ucFgKakikomi { get; set; }

        /// <summary>
        /// 6. 倒伏刈スイッチ
        /// </summary>
        private bool vy446_m_ucFgTofuku { get; set; }

        /// <summary>
        /// 7. 湿田スイッチ
        /// </summary>
        private bool vy446_m_ucFgSitsuden { get; set; }

        /// <summary>
        /// 8. エンジン停止
        /// </summary>
        private bool vy446_m_ucFgEngineStop { get; set; }

        /// <summary>
        /// 9. 警告音のチェック取得
        /// </summary>
        private bool vy446_Buzzer2Chk { get; set; }

        /// <summary>
        /// 10. 黄ランプのチェック取得
        /// </summary>
        private bool vy446_YellowLampChk { get; set; }

        /// <summary>
        /// 11. 赤ランプのチェック取得
        /// </summary>
        private bool vy446_RedLampChk { get; set; }

        /// <summary>
        /// 12. 刈り高さ目標値
        /// </summary>
        private bool vy446_m_ucFgKaritakaPosCtrl { get; set; }

        /// <summary>
        /// 13. ブザーのチェック取得
        /// </summary>
        private bool vy446_m_ucFgBuzzer { get; set; }

        /// <summary>
        /// 14. ハザードのチェック取得
        /// </summary>
        private bool vy446_m_ucFgHazard { get; set; }

        /// <summary>
        /// 15. オーガ自動収納のチェック取得
        /// </summary>
        private bool vy446_m_ucFgAugerHomePos { get; set; }

        /// <summary>
        /// 16. オーガ自動位置決めのチェック取得
        /// </summary>
        private bool vy446_m_ucFgAugerAutoPos { get; set; }

        /// <summary>
        /// 17. オーガクラッチのチェック取得
        /// </summary>
        private bool vy446_m_ucFgAugerClutch { get; set; }

        /// <summary>
        /// 1. 操舵量コマンド：左操舵最大(250)，中立(430)，右操舵最大(660)
        /// </summary>
        private ushort vy446_usCmdSteer { get; set; }

        /// <summary>
        /// 2. HST_CMD(主変速HSTレバー):前進最大(2450), 中立(1405), 後進最大(360)
        /// </summary>
        private ushort vy446_usCmdHst { get; set; }

        /// <summary>
        /// 3. 排出オーガ左右旋回目標値
        /// </summary>
        private ushort vy446_usCmdLRPos { get; set; }

        /// <summary>
        /// 4. 排出オーガ上下旋回コマンド
        /// </summary>
        private ushort vy446_usCmdUDPos { get; set; }

        /// <summary>
        /// 5. 刈り高さ目標値
        /// </summary>
        private ushort vy446_usCmdKaritaka { get; set; }

        /// <summary>
        /// Connect Combine Body using RS-232C
        /// </summary>
        private void CombineBodyConnect()
        {
            if (this.BodyReadCheckBox.Checked == false)
            {
                this._bodySerialConnect = new CombineBody.SerialConnect(
                    this.BodyPortTxtBox.Text,
                    Convert.ToInt32(this.BodyBaudRateTxtBox.Text),
                    Convert.ToInt32(this.BodyDatabitsTxtBox.Text)
                    );

                if (this.BodySaveCheckBox.Checked == true)
                {
                    this._bodyFile = new CombineBody.File(
                        this.BodySaveCheckBox.Checked,
                        this.BodyReadCheckBox.Checked
                        );
                } 
            }
            else
            {
                this._bodyFile = new CombineBody.File(
                    this.BodySaveCheckBox.Checked,
                    this.BodyReadCheckBox.Checked
                    );
            }

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

                this._cgps = new Cgps(5, 1);

                this._offLineGraph = new FieldMap.Graph();
                this._offLineGraph.CreateGraph(zg2);
            }
        }

        /// <summary>
        /// Combine body play
        /// </summary>
        private void CombineBodyPlay()
        {
            this.isTmData = false;

            if (this.BodyReadCheckBox.Checked == false)
            {
                this._bodySerialConnect.DataReceived();

                if (this.BodySaveCheckBox.Checked == true)
                {
                    this._bodyFile.addDataForSave(this._bodySerialConnect.orgList, this.readCount);
                }

                if (this.BodyModelComboBox.SelectedIndex == 0)
                {
                    this.CombineVy50Info(this._bodySerialConnect.orgList);
                }

                if (this.BodyModelComboBox.SelectedIndex == 1)
                {
                    this.CombineVy446Info(this._bodySerialConnect.orgList);
                }

                // server mode
                if (this.TcpIpServerCheckBox.Checked == true)
                {
                    this.combineData = this.tcpFile.AddToString(this.readCount, this._bodySerialConnect.orgList);
                }
            }
            else
            {
                List<int> cmdData = this._bodyFile.ReadCommandData(this.readCount, this._bodyFile.readData);

                if (this.BodyModelComboBox.SelectedIndex == 0 && cmdData.Count == 82)
                {
                    this.CombineVy50Info(cmdData);
                }

                if (this.BodyModelComboBox.SelectedIndex == 1 && cmdData.Count == 142)
                {
                    this.CombineVy446Info(cmdData);
                }

                // server mode
                if (this.TcpIpServerCheckBox.Checked == true)
                {
                    this.combineData = this.tcpFile.AddToString(this.readCount, cmdData);
                }
            }
        }

        /// <summary>
        /// Convert received data from body to infromation of combine VY446
        /// </summary>
        /// <param name="data">received data from combine body</param>
        private void CombineVy446Info(List<int> data)
        {
            bool isReceived = this._vy446.TokenData(data);

            if (isReceived == true)
            {
                this.Vy446_ReadCnt_TxtBox.Text = Convert.ToString(this.readCount);

                // 傾斜センサ--ok
                this.Vy446_AD_SUI_K_TxtBox.Text = Convert.ToString(this._vy446.AD_SUI_K);

                // 左シリンダポテンショ--ok
                this.Vy446_AD_SUI_L_TxtBox.Text = Convert.ToString(this._vy446.AD_SUI_L);

                // 右シリンダポテンショ--ok
                this.Vy446_AD_SUI_R_TxtBox.Text = Convert.ToString(this._vy446.AD_SUI_R);

                // 主変速ポテンショ--ok
                this.Vy446_DT_HST_TxtBox.Text = Convert.ToString(this._vy446.AD_FEED_M);

                // 操向ポテンショ--ok
                this.Vy446_DT_SOKO_TxtBox.Text = Convert.ToString(this._vy446.AD_SOKO_A);

                // フィーダ回転数 - revised 2013-05-30
                this.Vy446_feed_rpm_TxtBox.Text = Convert.ToString(this._vy446.fFeed_Rpm);

                // エンジン回転数 - revised 2013-05-30
                this.Vy446_rpm_TxtBox.Text = Convert.ToString(this._vy446.fRpm);

                // ミッション速度 - revised 2013-05-30
                this.Vy446_speed_TxtBox.Text = Convert.ToString(this._vy446.fSpeed);

                // 排出オーガの左右旋回ポテンショ--ok
                this.Vy446_AUGER_MTR_TxtBox.Text = Convert.ToString(this._vy446.DT_AUG_MTR);

                // 排出オーガの上下旋回ポテンショ--ok
                this.Vy446_AUGER_CLD_TxtBox.Text = Convert.ToString(this._vy446.DT_AUG_CLD);

                // 刈高さポテンショ--ok
                this.Vy446_RESERVE_B_TxtBox.Text = Convert.ToString(this._vy446.AD_KARI_L);

                // FUEL - revised 2013-05-30
                this.Vy446_AD_FUEL_TxtBox.Text = Convert.ToString(this._vy446.AD_FUEL);

                // Start Stop Flag - revised 2013-05-30
                this.Vy446_STARTSTOPFLAG_TxtBox.Text = Convert.ToString(this._vy446.m_ucStartStopFlag);

                // RTK-GPS and GPS Compass
                this.Vy446_avilability_TxtBox.Text = Convert.ToString(this._vy446.avilability);
                this.Vy446_compass_TxtBox.Text = Convert.ToString(this._vy446.compass);
                this.Vy446_gps_Altitude_TxtBox.Text = Convert.ToString(this._vy446.gps_Altitude);
                this.Vy446_gps_compass_TxtBox.Text = Convert.ToString(this._vy446.gps_Compass);
                this.Vy446_gps_Latitude_TxtBox.Text = Convert.ToString(this._vy446.gps_Latitude);
                this.Vy446_gps_Longitude_TxtBox.Text = Convert.ToString(this._vy446.gps_Longitude);
                this.Vy446_gps_Quality_TxtBox.Text = Convert.ToString(this._vy446.gps_Quality);
                this.Vy446_gps_Sv_TxtBox.Text = Convert.ToString(this._vy446.gps_Sv);
                this.Vy446_gps_Utc_TxtBox.Text = Convert.ToString(this._vy446.gps_Utc);
                this.Vy446_heading_TxtBox.Text = Convert.ToString(this._vy446.heading);
                this.Vy446_pitch_TxtBox.Text = Convert.ToString(this._vy446.pitch);
                this.Vy446_roll_TxtBox.Text = Convert.ToString(this._vy446.roll);

                if (this.BodyGeMapCheckBox.Checked == true)
                {
                    this.CombineGoogleMap(this._vy446.gps_Latitude, this._vy446.gps_Longitude);
                }

                if (this.BodyWgs84ToCartesianCheckBox.Checked == true)
                {
                    this.CombineOffLineMap(this._vy446.gps_Latitude, this._vy446.gps_Longitude, this._vy446.gps_Altitude);
                }
            }
        }


        /// <summary>
        /// Convert received data from body to infromation of combine VY50
        /// </summary>
        /// <param name="data">received data from combine body</param>
        private void CombineVy50Info(List<int> data)
        {
            bool isReveived = this._vy50.TokenData(data);

            if (isReveived == true)
            {
                this.Vy50_ReadCnt_TxtBox.Text = Convert.ToString(this.readCount);

                this.Vy50_d_EngineRpm_TxtBox.Text = Convert.ToString(this._vy50.d_EngineRpm);
                this.Vy50_d_FeederSpd_TxtBox.Text = Convert.ToString(this._vy50.d_FeederSpd);
                this.Vy50_d_Speed_TxtBox.Text = Convert.ToString(this._vy50.d_Speed);

                this.Vy50_gps_Altitude_TxtBox.Text = Convert.ToString(this._vy50.gps_Altitude);
                this.Vy50_gps_Heading_TxtBox.Text = Convert.ToString(this._vy50.gps_Heading);
                this.Vy50_gps_Latitude_TxtBox.Text = Convert.ToString(this._vy50.gps_Latitude);
                this.Vy50_gps_Longitude_TxtBox.Text = Convert.ToString(this._vy50.gps_Longitude);
                this.Vy50_gps_Quality_TxtBox.Text = Convert.ToString(this._vy50.gps_Quality);
                this.Vy50_gps_Sv_TxtBox.Text = Convert.ToString(this._vy50.gps_Sv);
                this.Vy50_gps_Utc_TxtBox.Text = Convert.ToString(this._vy50.gps_Utc);

                this.Vy50_uc_FinPos_TxtBox.Text = Convert.ToString(this._vy50.uc_FinPos);
                this.Vy50_uc_HeaderPos_TxtBox.Text = Convert.ToString(this._vy50.uc_HeaderPos);
                this.Vy50_uc_MacAir_TxtBox.Text = Convert.ToString(this._vy50.uc_MacAir);
                this.Vy50_uc_MainPotentio_TxtBox.Text = Convert.ToString(this._vy50.uc_MainPotentio);
                this.Vy50_uc_RcvFinPos_TxtBox.Text = Convert.ToString(this._vy50.uc_RcvFinPos);
                this.Vy50_uc_SteerPotentio_TxtBox.Text = Convert.ToString(this._vy50.uc_SteerPotentio);
                this.Vy50_us_AdLeftCylinder_TxtBox.Text = Convert.ToString(this._vy50.us_AdLeftCylinder);
                this.Vy50_us_AdRightCylinder_TxtBox.Text = Convert.ToString(this._vy50.us_AdRightCylinder);
                this.Vy50_us_AdSuihei_TxtBox.Text = Convert.ToString(this._vy50.us_AdSuihei);
                this.Vy50_us_LRPos_TxtBox.Text = Convert.ToString(this._vy50.us_LRPos);
                this.Vy50_us_UDPos_TxtBox.Text = Convert.ToString(this._vy50.us_UDPos);

                if (this.BodyGeMapCheckBox.Checked == true)
                {
                    this.CombineGoogleMap(this._vy50.gps_Latitude, this._vy50.gps_Longitude);
                }

                if (this.BodyWgs84ToCartesianCheckBox.Checked == true)
                {
                    this.CombineOffLineMap(this._vy50.gps_Latitude, this._vy50.gps_Longitude, this._vy50.gps_Altitude);
                }

            }
        }
        
        /// <summary>
        /// Manual Set Command For Vy446
        /// </summary>
        private void CombineVy446ManualSetCommand()
        {
            // 1. ロボットモード切替のチェック取得 - ok
            if (this.Vy446_RobotMode_CheckBox.Checked == true)
            {
                //this._vy446.m_iRobotMode = true;
                this.vy446_m_iRobotMode = true;
            }
            else
            {
                //this._vy446.m_iRobotMode = false;
                this.vy446_m_iRobotMode = false;
            }

            // 2. 刈取クラッチのラジオボタン取得 - ok
            if (this.Vy446_KARITORI_CheckBox.Checked == true)
            {
                //this._vy446.KaritoriRadio = true;
                this.vy446_KaritoriRadio = true;
            }
            else
            {
                //this._vy446.KaritoriRadio = false;
                this.vy446_KaritoriRadio = false;
            }

            // 3. 作業機クラッチのラジオボタン取得 - ok
            if (this.Vy446_SAGYOKI_ON_CheckBox.Checked == true)
            {
                //this._vy446.SagyokiRadio = true;
                this.vy446_SagyokiRadio = true;
            }
            else
            {
                //this._vy446.SagyokiRadio = false;
                this.vy446_SagyokiRadio = false;
            }

            // 4. クラッチオフのラジオボタン取得 - ok
            if (this.Vy446_SAGYOKI_OFF_CheckBox.Checked == true)
            {
                //this._vy446.SagyokiOffRadio = true;
                this.vy446_SagyokiOffRadio = true;
            }
            else
            {
                //this._vy446.SagyokiOffRadio = false;
                this.vy446_SagyokiOffRadio = false;
            }

            // 5. 強制掻込スイッチ - ok
            if (this.Vy446_FgKakikomi_CheckBox.Checked == true)
            {
                //this._vy446.m_ucFgKakikomi = true;
                this.vy446_m_ucFgKakikomi = true;
            }
            else
            {
                //this._vy446.m_ucFgKakikomi = false;
                this.vy446_m_ucFgKakikomi = false;
            }

            // 6. 倒伏刈スイッチ - ok
            if (this.Vy446_FgTofuku_CheckBox.Checked == true)
            {
                //this._vy446.m_ucFgTofuku = true;
                this.vy446_m_ucFgTofuku = true;
            }
            else
            {
                //this._vy446.m_ucFgTofuku = false;
                this.vy446_m_ucFgTofuku = false;
            }

            // 7. 湿田スイッチ - ok
            if (this.Vy446_FgSitsuden_CheckBox.Checked == true)
            {
                //this._vy446.m_ucFgSitsuden = true;
                this.vy446_m_ucFgSitsuden = true;
            }
            else
            {
                //this._vy446.m_ucFgSitsuden = false;
                this.vy446_m_ucFgSitsuden = false;
            }

            // 8. エンジン停止 - ok
            if (this.Vy446_ENGINE_STOP_CheckBox.Checked == true)
            {
                //this._vy446.m_ucFgEngineStop = true;
                this.vy446_m_ucFgEngineStop = true;
            }
            else
            {
                //this._vy446.m_ucFgEngineStop = false;
                this.vy446_m_ucFgEngineStop = false;
            }

            // 9. 警告音のチェック取得 - ok
            if (this.Vy446_BUZZER2_CheckBox.Checked == true)
            {
                //this._vy446.Buzzer2Chk = true;
                this.vy446_Buzzer2Chk = true;
            }
            else
            {
                //this._vy446.Buzzer2Chk = false;
                this.vy446_Buzzer2Chk = false;
            }

            // 10. 黄ランプのチェック取得 - ok
            if (this.Vy446_YELLOW_LAMP_CheckBox.Checked == true)
            {
                //this._vy446.YellowLampChk = true;
                this.vy446_YellowLampChk = true;
            }
            else
            {
                //this._vy446.YellowLampChk = false;
                this.vy446_YellowLampChk = false;
            }

            // 11. 赤ランプのチェック取得 - ok
            if (this.Vy446_RED_LAMP_CheckBox.Checked == true)
            {
                //this._vy446.RedLampChk = true;
                this.vy446_RedLampChk = true;
            }
            else
            {
                //this._vy446.RedLampChk = false;
                this.vy446_RedLampChk = false;
            }

            // 12. 刈り高さ目標値 - ok
            if (this.Vy446_KARITAKA_CheckBox.Checked == true)
            {
                //this._vy446.m_ucFgKaritakaPosCtrl = true;
                this.vy446_m_ucFgKaritakaPosCtrl = true;
            }
            else
            {
                //this._vy446.m_ucFgKaritakaPosCtrl = false;
                this.vy446_m_ucFgKaritakaPosCtrl = false;
            }

            // 13. ブザーのチェック取得 - ok
            if (this.Vy446_BUZZER_CheckBox.Checked == true)
            {
                //this._vy446.m_ucFgBuzzer = true;
                this.vy446_m_ucFgBuzzer = true;
            }
            else
            {
                //this._vy446.m_ucFgBuzzer = false;
                this.vy446_m_ucFgBuzzer = false;
            }

            // 14. ハザードのチェック取得 - ok
            if (this.Vy446_HAZARD_CheckBox.Checked == true)
            {
                //this._vy446.m_ucFgHazard = true;
                this.vy446_m_ucFgHazard = true;
            }
            else
            {
                //this._vy446.m_ucFgHazard = false;
                this.vy446_m_ucFgHazard = false;
            }

            // 15. オーガ自動収納のチェック取得 - ok
            if (this.Vy446_AUTO_RETURN_CheckBox.Checked == true)
            {
                //this._vy446.m_ucFgAugerHomePos = true;
                this.vy446_m_ucFgAugerHomePos = true;
            }
            else
            {
                //this._vy446.m_ucFgAugerHomePos = false;
                this.vy446_m_ucFgAugerHomePos = false;
            }

            // 16. オーガ自動位置決めのチェック取得 - ok
            if (this.Vy446_AUTOPOS_CheckBox.Checked == true)
            {
                //this._vy446.m_ucFgAugerAutoPos = true;
                this.vy446_m_ucFgAugerAutoPos = true;
            }
            else
            {
                //this._vy446.m_ucFgAugerAutoPos = false;
                this.vy446_m_ucFgAugerAutoPos = false;
            }

            // 17. オーガクラッチのチェック取得 - ok
            if (this.Vy446_CLUTCH_CheckBox.Checked == true)
            {
                //this._vy446.m_ucFgAugerClutch = true;
                this.vy446_m_ucFgAugerClutch = true;
            }
            else
            {
                //this._vy446.m_ucFgAugerClutch = false;
                this.vy446_m_ucFgAugerClutch = false;
            }

            // 1. 操舵量コマンド：左操舵最大(250)，中立(430)，右操舵最大(660) - ok
            //this._vy446.usCmdSteer = Convert.ToUInt16(this.Vy446_CMD_SOKO_TxtBox.Text);
            this.vy446_usCmdSteer = Convert.ToUInt16(this.Vy446_CMD_SOKO_TxtBox.Text);

            // 2. HST_CMD(主変速HSTレバー):前進最大(2450), 中立(1405), 後進最大(360) - ok
            //this._vy446.usCmdHst = Convert.ToUInt16(this.Vy446_CMD_HST_TxtBox.Text);
            //this.vy446_usCmdHst = Convert.ToUInt16(this.Vy446_CMD_HST_TxtBox.Text);
            this.vy446_usCmdHst = this._vy446.SetHstCmd(Convert.ToDouble(this.Vy446_CMD_TravelSpeed_TxtBox.Text));
            this.Vy446_DEBUG_HST_TxtBox.Text = Convert.ToString(this.vy446_usCmdHst);

            // 3. 排出オーガ左右旋回目標値
            //this._vy446.usCmdLRPos = Convert.ToUInt16(this.Vy446_CMD_AUGER_MTR_TxtBox.Text);
            this.vy446_usCmdLRPos = Convert.ToUInt16(this.Vy446_CMD_AUGER_MTR_TxtBox.Text);

            // 4. 排出オーガ上下旋回コマンド
            //this._vy446.usCmdUDPos = Convert.ToUInt16(this.Vy446_CMD_AUGER_CLD_TxtBox.Text);
            this.vy446_usCmdUDPos = Convert.ToUInt16(this.Vy446_CMD_AUGER_CLD_TxtBox.Text);

            // 5. 刈り高さ目標値
            //this._vy446.usCmdKaritaka = Convert.ToUInt16(this.Vy446_CMD_KARITAKA_TxtBox.Text);
            this.vy446_usCmdKaritaka = Convert.ToUInt16(this.Vy446_CMD_KARITAKA_TxtBox.Text);
        }

        /// <summary>
        /// Vy446 Default Command Parameters
        /// </summary>
        private void CombineVy446DefaultCommand()
        {
            // 1. ロボットモード切替のチェック取得 - ok
            this.vy446_m_iRobotMode = true;

            // 2. 刈取クラッチのラジオボタン取得 - ok
            this.vy446_KaritoriRadio = false;

            // 3. 作業機クラッチのラジオボタン取得 - ok
            this.vy446_SagyokiRadio = false;

            // 4. クラッチオフのラジオボタン取得 - ok
            this.vy446_SagyokiOffRadio = false;

            // 5. 強制掻込スイッチ - ok
            this.vy446_m_ucFgKakikomi = false;

            // 6. 倒伏刈スイッチ - ok
            this.vy446_m_ucFgTofuku = false;

            // 7. 湿田スイッチ - ok
            this.vy446_m_ucFgSitsuden = false;

            // 8. エンジン停止 - ok
            this.vy446_m_ucFgEngineStop = false;

            // 9. 警告音のチェック取得 - ok
            this.vy446_Buzzer2Chk = false;

            // 10. 黄ランプのチェック取得 - ok
            this.vy446_YellowLampChk = false;

            // 11. 赤ランプのチェック取得 - ok
            this.vy446_RedLampChk = false;

            // 12. 刈り高さ目標値 - ok
            this.vy446_m_ucFgKaritakaPosCtrl = false;

            // 13. ブザーのチェック取得 - ok
            this.vy446_m_ucFgBuzzer = false;

            // 14. ハザードのチェック取得 - ok
            this.vy446_m_ucFgHazard = false;

            // 15. オーガ自動収納のチェック取得 - ok
            this.vy446_m_ucFgAugerHomePos = false;

            // 16. オーガ自動位置決めのチェック取得 - ok
            this.vy446_m_ucFgAugerAutoPos = false;

            // 17. オーガクラッチのチェック取得 - ok
            this.vy446_m_ucFgAugerClutch = false;

            // 1. 操舵量コマンド：左操舵最大(250)，中立(430)，右操舵最大(660) - ok
            this.vy446_usCmdSteer = Convert.ToUInt16(430);

            // 2. HST_CMD(主変速HSTレバー):前進最大(2450), 中立(1405), 後進最大(360) - ok
            this.vy446_usCmdHst = Convert.ToUInt16(1405);

            // 3. 排出オーガ左右旋回目標値
            this.vy446_usCmdLRPos = Convert.ToUInt16(92);

            // 4. 排出オーガ上下旋回コマンド
            this.vy446_usCmdUDPos = Convert.ToUInt16(753);

            // 5. 刈り高さ目標値
            this.vy446_usCmdKaritaka = Convert.ToUInt16(680); 
        }

        /// <summary>
        /// command data send to combine Vy446 ECU using serial
        /// </summary>
        private void CombineVy446CmdSend()
        {
            // 1. ロボットモード切替のチェック取得
            this._vy446.m_iRobotMode = this.vy446_m_iRobotMode;

            // 2. 刈取クラッチのラジオボタン取得
            this._vy446.KaritoriRadio = this.vy446_KaritoriRadio;

            // 3. 作業機クラッチのラジオボタン取得
            this._vy446.SagyokiRadio = this.vy446_SagyokiRadio;

            // 4. クラッチオフのラジオボタン取得
            this._vy446.SagyokiOffRadio = this.vy446_SagyokiOffRadio;

            // 5. 強制掻込スイッチ
            this._vy446.m_ucFgKakikomi = this.vy446_m_ucFgKakikomi;

            // 6. 倒伏刈スイッチ
            this._vy446.m_ucFgTofuku = this.vy446_m_ucFgTofuku;

            // 7. 湿田スイッチ
            this._vy446.m_ucFgSitsuden = this.vy446_m_ucFgSitsuden;

            // 8. エンジン停止
            this._vy446.m_ucFgEngineStop = this.vy446_m_ucFgEngineStop;

            // 9. 警告音のチェック取得
            this._vy446.Buzzer2Chk = this.vy446_Buzzer2Chk;

            // 10. 黄ランプのチェック取得
            this._vy446.YellowLampChk = this.vy446_YellowLampChk;

            // 11. 赤ランプのチェック取得
            this._vy446.RedLampChk = this.vy446_RedLampChk;

            // 12. 刈り高さ目標値
            this._vy446.m_ucFgKaritakaPosCtrl = this.vy446_m_ucFgKaritakaPosCtrl;

            // 13. ブザーのチェック取得
            this._vy446.m_ucFgBuzzer = this.vy446_m_ucFgBuzzer;

            // 14. ハザードのチェック取得
            this._vy446.m_ucFgHazard = this.vy446_m_ucFgHazard;

            // 15. オーガ自動収納のチェック取得
            this._vy446.m_ucFgAugerHomePos = this.vy446_m_ucFgAugerHomePos;

            // 16. オーガ自動位置決めのチェック取得
            this._vy446.m_ucFgAugerAutoPos = this.vy446_m_ucFgAugerAutoPos;

            // 17. オーガクラッチのチェック取得
            this._vy446.m_ucFgAugerClutch = this.vy446_m_ucFgAugerClutch;


            // 1. 操舵量コマンド：左操舵最大(250)，中立(430)，右操舵最大(660)
            this._vy446.usCmdSteer = this.vy446_usCmdSteer;

            // 2. HST_CMD(主変速HSTレバー):前進最大(2450), 中立(1405), 後進最大(360)
            this._vy446.usCmdHst = this.vy446_usCmdHst;

            // 3. 排出オーガ左右旋回目標値
            this._vy446.usCmdLRPos = this.vy446_usCmdLRPos;

            // 4. 排出オーガ上下旋回コマンド
            this._vy446.usCmdUDPos = this.vy446_usCmdUDPos;

            // 5. 刈り高さ目標値
            this._vy446.usCmdKaritaka = this.vy446_usCmdKaritaka;

            // write cmd
            this._vy446.SendCmdEcu();

            // data send
            this._bodySerialConnect.DataWrite(this._vy446.ucCmdBuf);
        }

        /// <summary>
        /// command data send to combine Vy50 ECU using serial
        /// </summary>
        private void CombineVy50CmdSend()
        {
            this._vy50.m_iCtrlMode = true;

            // ロボットモード切替のチェック取得
            if (this.Vy50_ROBOTMODE_CheckBox.Checked == true)
            {
                this._vy50.RobotModeChk = true;
            }
            else
            {
                this._vy50.RobotModeChk = false;
            }

            // 作業機クラッチのチェック取得
            if (this.Vy50_SAGYOUKI_CheckBox.Checked == true)
            {
                this._vy50.SagyoukiChk = true;
            }
            else
            {
                this._vy50.SagyoukiChk = false;
            }

            // 刈取クラッチのチェック取得
            if (this.Vy50_KARITORI_CheckBox.Checked == true)
            {
                this._vy50.KaritoriChk = true;
            }
            else
            {
                this._vy50.KaritoriChk = false;
            }

            // 刈高ポジコン取部昇降ラジオボタン取得
            if (this.Vy50_KARITAKASA_CheckBox.Checked == true)
            {
                this._vy50.KaritakaChk = true;
            }
            else
            {
                this._vy50.KaritakaChk = false;
            }

            // 強制掻込スイッチのチェック取得
            if (this.Vy50_KAKIKOMI_CheckBox.Checked == true)
            {
                this._vy50.KakikomiChk = true;
            }
            else
            {
                this._vy50.KakikomiChk = false;
            }

            // 倒伏スイッチのチェック取得
            if (this.Vy50_TOFUKU_CheckBox.Checked == true)
            {
                this._vy50.TofukuChk = true;
            }
            else
            {
                this._vy50.TofukuChk = false;
            }

            // 湿田スイッチのチェック取得
            if (this.Vy50_SHITUDEN_CheckBox.Checked == true)
            {
                this._vy50.ShitudenChk = true;
            }
            else
            {
                this._vy50.ShitudenChk = false;
            }

            // 排出オーガクラッチのチェック取得
            if (this.Vy50_AUGER_CheckBox.Checked == true)
            {
                this._vy50.AugerChk = true;
            }
            else
            {
                this._vy50.AugerChk = false;
            }

            // 排出オーガ自動位置決めのチェック取得
            if (this.Vy50_AUGERPOS_CheckBox.Checked == true)
            {
                this._vy50.AugerPosChk = true;
            }
            else
            {
                this._vy50.AugerPosChk = false;
            }

            // 排出オーガ収納スイッチのチェック取得
            if (this.Vy50_AUGERHOME_CheckBox.Checked == true)
            {
                this._vy50.AugerHomeChk = true;
            }
            else
            {
                this._vy50.AugerHomeChk = false;
            }

            // 左右水平制御のチェック取得
            if (this.Vy50_SUIHEI_CheckBox.Checked == true)
            {
                this._vy50.SuiheiChk = true;
            }
            else
            {
                this._vy50.SuiheiChk = false;
            }

            // 左シリンダ制御のチェック取得
            if (this.Vy50_CMDLEFTCYLINDER_CheckBox.Checked == true)
            {
                this._vy50.LeftCylinderChk = true;
            }
            else
            {
                this._vy50.LeftCylinderChk = false;
            }

            // 右シリンダ制御のチェック取得
            if (this.Vy50_CMDRIGHTCYLINDER_CheckBox.Checked == true)
            {
                this._vy50.RightCylinderChk = true;
            }
            else
            {
                this._vy50.RightCylinderChk = false;
            }

            // 左ウィンカスイッチのチェック取得
            if (this.Vy50_LEFTWINKER_CheckBox.Checked == true)
            {
                this._vy50.LeftWinkerChk = true;
            }
            else
            {
                this._vy50.LeftWinkerChk = false;
            }

            // 右ウィンカスイッチのチェック取得
            if (this.Vy50_RIGHTWINKER_CheckBox.Checked == true)
            {
                this._vy50.RightWinkerChk = true;
            }
            else
            {
                this._vy50.RightWinkerChk = false;
            }

            // ハザードスイッチのチェック取得
            if (this.Vy50_HAZARD_CheckBox.Checked == true)
            {
                this._vy50.HazardChk = true;
            }
            else
            {
                this._vy50.HazardChk = false;
            }

            // ブザースイッチのチェック取得
            if (this.Vy50_BUZZER_CheckBox.Checked == true)
            {
                this._vy50.BuzzerChk = true;
            }
            else
            {
                this._vy50.BuzzerChk = false;
            }

            // エンジン停止スイッチのチェックの取得
            if (this.Vy50_ENGINESTOP_CheckBox.Checked == true)
            {
                this._vy50.EngineStopChk = true;
            }
            else
            {
                this._vy50.EngineStopChk = false;
            }

            // ブザーのチェック取得
            if (this.Vy50_BUZZERPATLITE_CheckBox.Checked == true)
            {
                this._vy50.BuzzerPatliteChk = true;
            }
            else
            {
                this._vy50.BuzzerPatliteChk = false;
            }

            // 黄色ランプのチェック取得
            if (this.Vy50_YELLOWPATLITE_CheckBox.Checked == true)
            {
                this._vy50.YellowPatliteChk = true;
            }
            else
            {
                this._vy50.YellowPatliteChk = false;
            }

            // 赤色ランプのチェック取得
            if (this.Vy50_REDPATLITE_CheckBox.Checked == true)
            {
                this._vy50.RedPatliteChk = true;
            }
            else
            {
                this._vy50.RedPatliteChk = false;
            }

            // 操舵量指令値(0-255)
            this._vy50.uc_CmdSteer = Convert.ToByte(this.Vy50_CMDSTEERPOTENTIO_TxtBox.Text);

            // 主変速指令値の取得
            this._vy50.us_HstCmd = Convert.ToUInt16(this.Vy50_HSTCMD_TxtBox.Text);

            // 刈高さポジコン指令値(0-255)
            this._vy50.uc_CmdKaritakasa = Convert.ToByte(this.Vy50_KARITAKASA_TxtBox.Text);

            // フィン開度指令値(0-255)
            this._vy50.uc_CmdFinPos = Convert.ToByte(this.Vy50_CMDFINPOS_TxtBox.Text);

            // 排出オーガ左右旋回関節目標値(0-1023)
            this._vy50.us_CmdLRPos = Convert.ToUInt16(this.Vy50_CMDLRPOS_TxtBox.Text);

            // 排出オーガ上下旋回関節目標値(0-1023)
            this._vy50.us_CmdUDPos = Convert.ToUInt16(this.Vy50_CMDUDPOS_TxtBox.Text);

            // 左右傾斜の目標値(0-1023)
            this._vy50.us_CmdSuihei = Convert.ToUInt16(this.Vy50_CMDSUIHEI_TxtBox.Text);

            // 左シリンダの目標値(0-1023)
            this._vy50.us_CmdLeftCylinder = Convert.ToUInt16(this.Vy50_CMDLEFTCYLINDER_TxtBox.Text);

            // 右シリンダの目標値(0-1023)
            this._vy50.us_CmdRightCylinder = Convert.ToUInt16(this.Vy50_CMDRIGHTCYLINDER_TxtBox.Text);

            // write cmd
            this._vy50.SendCmdWrite();

            // data send
            this._bodySerialConnect.DataWrite(this._vy50.ucCmdBuf);
        }

        /// <summary>
        /// draw on the map using google earth
        /// </summary>
        /// <param name="_lat"></param>
        /// <param name="_lng"></param>
        private void CombineGoogleMap(double _lat, double _lng)
        {
            if (this.BodyGeMapCheckBox.Checked == true)
            {
                if (this._drawMap.IsInitialize == false)
                {
                    this._drawMap.CreateLookAt(_lat, _lng, 0, 200);
                    this._drawMap.IsInitialize = true;
                }

                this._drawMap.ReceiveGpsData(_lat, _lng);
            }
        }

        /// <summary>
        /// Draw on the zedGraph of Cartesian coordinates
        /// </summary>
        /// <param name="_lat"></param>
        /// <param name="_lon"></param>
        /// <param name="_alt"></param>
        private void CombineOffLineMap(double _lat, double _lon, double _alt)
        {
            this._cgps.w84toxyh(_lat, _lon, _alt);

            if (this.offLineInit == false)
            {
                this.offLineMapX = this._cgps.result.x;
                this.offLineMapY = this._cgps.result.y;
                this.offLineInit = true;
            }

            this.tmY = this.offLineMapX - this._cgps.result.x;
            this.tmX = this.offLineMapY - this._cgps.result.y;
            this.tmZ = this._cgps.result.c;

            this._offLineGraph.AddDataToGraph(zg2, this.tmX, this.tmY);

            this.BodyWgs84ToCartesianX_TxtBox.Text = Convert.ToString(this.tmX);
            this.BodyWgs84ToCartesianY_TxtBox.Text = Convert.ToString(this.tmY);
            this.BodyWgs84ToCartesianZ_TxtBox.Text = Convert.ToString(this.tmZ);

            this.isTmData = true;
        }

        #endregion

        #region Amedas Weather

        private Amedas.Amedas ad;

        /// <summary>
        /// Save Amedas data to Xml file
        /// </summary>
        private void AmedasSaveDataToXml()
        {
            this.ad = new Amedas.Amedas(this.AmedasWebBrowser);
            this.ad.SelectedLocal = this.AmedasComBox.SelectedIndex;
            this.ad.Step_MoveToAmedasPage(this.ad.AmedasAddressString(this.AmedasComBox.SelectedIndex));
            this.AmedasWebBrowser.DocumentCompleted += this.ad.webBrowser_DocumentCompleted;
        }

        /// <summary>
        /// Grid Amedas xml data
        /// </summary>
        private void AmedasXmlToGrid()
        {
            string fileName = this.ad.ReadXmlDialog();

            XmlReader xmlFile;
            xmlFile = XmlReader.Create(fileName, new XmlReaderSettings());
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);
            dataGridView1.DataSource = ds.Tables["AmedasXml"];
        }

        #endregion

        #region Communication

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

                this._cgps = new Cgps(5, 1);

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

        #endregion

        #region Constructor

        public IntegratedForm()
        {
            InitializeComponent();
            
            // for key event
            this.KeyPreview = true;
        }

        #endregion

        #region Draw 3D CropStand state on OpenGL
        
        private Algorithm.CropStand cropStand;
        private double backTmX { get; set; }
        private double backTmY { get; set; }
        private double backTmZ { get; set; }
        private double backHeading { get; set; }
        private double backSpeed { get; set; }
        private bool isFirstBodyTm { get; set; }
        //private bool isSaveLidarData { get; set; }
        private bool isHarvestMode { get; set; }

        /// <summary>
        /// initialization of crop stand class
        /// </summary>
        /// <param name="_isLidar"></param>
        /// <param name="_isBody"></param>
        /// <param name="_isOpenGl"></param>
        private void InitializeCropStand(bool _isLidar, bool _isBody, bool _isOpenGl)
        {
            if ((_isLidar == true) && (_isBody == true) && (_isOpenGl == true))
            {
                this.cropStand = new CropStand(this.BodyModelComboBox.SelectedIndex);
                this.isFirstBodyTm = false;
                //this.isSaveLidarData = true;
            }
        }

        /// <summary>
        /// Revised 2013-06-12
        /// Draw Crop stand on OpenGL
        /// </summary>
        /// <param name="_lidar"></param>
        /// <param name="_tm"></param>
        private void DrawCropStand(bool _lidar, bool _tm)
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
                    }

                    if (this.BodyModelComboBox.SelectedIndex == 1)
                    {
                        // Vy446 model
                        this.backHeading = this._vy446.gps_Compass;
                        //this.backHeading = this._vy446.compass;
                        this.backSpeed = this._vy446.fSpeed;
                    }

                    this.backTmX = this.tmX;
                    this.backTmY = this.tmY;
                    this.backTmZ = this.tmZ;
                }
                else
                {
                    this.cropStand.NewTm(this.backTmX, this.backTmY, this.backTmZ, this.backHeading, this.backSpeed, Convert.ToInt32(this.TimerIntervalTxtBox.Text));
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
                    this.cropStand.CalculatePosition(this.sickLidar.cartesianList, this.backTmX, this.backTmY, this.backTmZ, this.backHeading);

                    // save cartesian lidar data
                    //if (this.isSaveLidarData == true)
                    //{
                    //    this.cropStand.SaveLidarData(this.sickLidar.cartesianList);
                    //    this.isSaveLidarData = false;
                    //}

                    // discriminate uncut crop and ground
                    this.cropStand.AddDiscriminatePoints(this.cropStand.result, this.drawGlIndex);

                    // calculate of Perpendicular distance between GPS xy position and Extracted Ransac
                    this.cropStand.GpsToRansacDistance(this.backTmX, this.backTmY);

                    // processing debug on OpenGlForm
                    this.lidarOpenGlForm.ProcessingDebug(this.cropStand.isRan, this.cropStand.ran_angle, this.cropStand.ran_distance, this.cropStand.ran_standard_distance);

                    // add crop
                    this.lidarOpenGlForm.AddCrop(this.cropStand.result, this.drawGlIndex);

                    // add edge into OpenGlForm
                    this.lidarOpenGlForm.AddEdge(this.cropStand.ran_result, this.cropStand.isRan);
                }
                else
                {
                    this.cropStand.UnHarvestMode();
                }

                this.lidarOpenGlForm.GlUpdate();
            }
        }

        #endregion

        #region Guidance - Autonomous and Manual mode

        /// <summary>
        /// is Default Command of Vy446
        /// </summary>
        private bool isDefaultCmdVy446 = false;

        /// <summary>
        /// is initialization of header position
        /// </summary>
        private bool isIniHeader = false;

        /// <summary>
        /// initialization of header position
        /// </summary>
        private ushort iniHeaderPos { get; set; }

        /// <summary>
        /// Revised 2013-06-12
        /// Guidance Method for Combine Robot
        /// </summary>
        /// <param name="_isVy50RobotMode"></param>
        /// <param name="_isVy446RobotMode"></param>
        /// <param name="_bodyModelNum"></param>
        private void GuidanceRun(bool _isVy50RobotMode, bool _isVy446RobotMode, int _bodyModelNum)
        {
            // VY446
            if ((_bodyModelNum == 1) && (_isVy446RobotMode == true))
            {
                if (this.isDefaultCmdVy446 == false)
                {
                    this.CombineVy446DefaultCommand();
                    this.isDefaultCmdVy446 = true;
                }

                // autonomous mode run
                if (this.Vy446_AutonomousMode_CheckBox.Checked == true)
                {
                    // header control
                    this.Vy446HeaderControl();

                    // forward control
                    this.Vy446ForwardControl();
                }

                this.CombineVy446CmdSend();
            }

            // VY50
            if ((_bodyModelNum == 0) && (_isVy50RobotMode == true))
            { 
            }
        }

        /// <summary>
        /// Revised 2013-06-12
        /// Vy446 Header Control Method
        /// Karitori, Karitakasa radios must be convert true state.
        /// </summary>
        private void Vy446HeaderControl()
        { 
            // initialization of header position, karitori and karitakasa state
            if (this.isIniHeader == false)
            {
                // header position
                this.iniHeaderPos = Convert.ToUInt16(this.Vy446_DEBUG_INI_HEADER_POS_TxtBox.Text);
                
                // karitori on
                this.vy446_KaritoriRadio = true;

                // karitakasa on
                this.vy446_m_ucFgKaritakaPosCtrl = true;

                // convert true state
                this.isIniHeader = true;
            }

            // header control
            this.cropStand.HeaderControl(this.sickLidar.cartesianList, this.drawGlIndex, 1, this.iniHeaderPos);
            this.vy446_usCmdKaritaka = this.cropStand.header_potentiometer;

            // header control debug
            this.Vy446_isHeaderControl_TxtBox.Text = Convert.ToString(this.cropStand.isHeaderControl);
            this.Vy446_HeaderPotentiometer_TxtBox.Text = Convert.ToString(this.vy446_usCmdKaritaka);
        }

        /// <summary>
        /// Vy446 forward control method
        /// </summary>
        private void Vy446ForwardControl()
        {
            if (this.cropStand.isHeaderControl == true)
            {
                // forward on - Vy446_DEBUG_INI_TRAVEL_SPEED_TxtBox.text
                double forward_Speed = Convert.ToDouble(this.Vy446_DEBUG_INI_TRAVEL_SPEED_TxtBox.Text);
                this.vy446_usCmdHst = this._vy446.SetHstCmd(forward_Speed);

                // steering
                this.cropStand.Vy446ForwardSteer(this.backHeading);

                // 操舵量コマンド：左操舵最大(250)，中立(430)，右操舵最大(660)
                this.vy446_usCmdSteer = this.cropStand.vy446_usCmdSteer;
            }
            else
            {
                // forward off - nuetral
                this.vy446_usCmdHst = this._vy446.SetHstCmd(0.1);
            }

            // debug message
            this.Vy446_DEBUG_HST_TxtBox.Text = Convert.ToString(this.vy446_usCmdHst);
            this.Vy446_DEBUG_SOKO_TxtBox.Text = Convert.ToString(this.vy446_usCmdSteer);
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Connect Method
        /// </summary>
        private void ConnectMethod()
        {
            this.readCount = 0;

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

                // check for crop stand
                this.InitializeCropStand(
                    this.LidarAvailableCheckBox.Checked,
                    this.BodyAvailableCheckBox.Checked,
                    this.LidarOpenGlCheckBox.Checked
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
                    this.LidarOpenGlCheckBox.Checked
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

                    // for crop stand
                    if ((this.LidarAvailableCheckBox.Checked == true) && (this.BodyAvailableCheckBox.Checked == true) && (this.LidarOpenGlCheckBox.Checked == true))
                    {
                        this.DrawCropStand(this.isLidarData, this.isTmData);
                    }

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

            // for crop stand
            if ((this.LidarAvailableCheckBox.Checked == true) && (this.BodyAvailableCheckBox.Checked == true) && (this.LidarOpenGlCheckBox.Checked == true))
            {
                this.DrawCropStand(this.isLidarData, this.isTmData);
            }

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
