using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Display
{
    partial class IntegratedForm
    {
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

                this._cgps = new FieldMap.Cgps(5, 1);

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

                //// Speedometer display
                //this.SpeedGauge.Value = this._vy446.fSpeed * 100.0;
                //this.SpeedometerLabel.Text = this._vy446.fSpeed.ToString("N3") + " [m/s]";

                //// compass display
                //this.CompassGauge.Value = this._vy446.gps_Compass;
                //this.CompassLabel.Text = this._vy446.gps_Compass.ToString("N1") + " [deg]";

                // Speedometer, Compass UI
                this.GaugeUserInterface(this._vy446.fSpeed, this._vy446.gps_Compass);
            }
        }

        /// <summary>
        /// Draw speed, compass information on the UI.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="compass"></param>
        private void GaugeUserInterface(double speed, double compass)
        {
            double converted_speed = speed * 100.0;

            if ((converted_speed > -100.0) && (converted_speed < 200.0))
            {
                // Speedometer display
                this.SpeedGauge.Value = converted_speed;
                this.SpeedometerLabel.Text = speed.ToString("N3") + " [m/s]";
            }

            if ((compass >= 0) && (compass <= 360))
            {
                // Compass display
                this.CompassGauge.Value = compass;
                this.CompassLabel.Text = compass.ToString("N1") + " [deg]";
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
    }
}
