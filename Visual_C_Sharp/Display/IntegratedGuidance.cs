using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Display
{
    partial class IntegratedForm
    {
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

                // autonomous mode run debug - harvesting and 3D terrain mapping
                //this.lidarOpenGlForm.Vy446AutonomousModeCheckDebug(this.Vy446_AutonomousMode_CheckBox.Checked);

                if (this.Vy446_AutonomousMode_CheckBox.Checked == true)
                {
                    // autonomous harvesting
                    //this.Vy446ForwardHarvesting();

                    // autonomous auger detection
                    //this.Vy446AugerDetection();
                }

                // if simulation test checkbox is checked
                // then serial port cannot communication.
                if (this.Vy446_SimulationTest_CheckBox.Checked == false)
                {
                    this.CombineVy446CmdSend();
                }
            }

            // VY50
            if ((_bodyModelNum == 0) && (_isVy50RobotMode == true))
            {
            }
        }

        /// <summary>
        /// Revised 2014-02-25 by wonjae cho
        /// Autonomous auger detection
        /// </summary>
        private void Vy446AugerDetection()
        {
            this.Vy446AugerInitialization();

            this.Vy446AugerMove();
        }

        private bool is_auger_initialize = false;
        
        /// <summary>
        /// true is forward and false is backward.
        /// </summary>
        private bool is_auger_forward_and_backward { get; set; }

        /// <summary>
        /// Revised 2014-02-25
        /// Initialize auger detection
        /// </summary>
        private void Vy446AugerInitialization()
        {
            if (this.is_auger_initialize == false)
            {
                // karitaka maximum value is 680.
                this.vy446_usCmdKaritaka = Convert.ToUInt16(680);

                // forward on - Vy446_DEBUG_INI_TRAVEL_SPEED_TxtBox.text
                this.vy446_usCmdHst = Convert.ToUInt16(this.Vy446_CMD_HST_TxtBox.Text);

                if (this.vy446_usCmdHst > 1405)
                {
                    this.is_auger_forward_and_backward = true;
                    
                    // debug message
                    this.augerOpenGlForm.SteeringInformation("Forward");
                }
                else
                {
                    this.is_auger_forward_and_backward = false;

                    // debug message
                    this.augerOpenGlForm.SteeringInformation("Backward");
                }

                // set steer nuetral
                this.vy446_usCmdSteer = Convert.ToUInt16(430);

                this.is_auger_initialize = true;
            }
        }

        private const double auger_travel_range = 5.0;
        private const double auger_target_range = 0.15;
        private bool is_auger_move_stop = false;
        private bool is_final_auger_detection = false;
        //private double auger_sim_to_real = 100.0;

        /// <summary>
        /// Revised 2013-02-25
        /// Autonomous auger move to target position
        /// </summary>
        private void Vy446AugerMove()
        {
            double travel_distance = this.augerOpenGlForm.TravelDistance();

            if (this.is_final_auger_detection == true)
            {
                // move stop
                this.vy446_usCmdHst = Convert.ToUInt16(1405);

                // move auger
                this.vy446_m_ucFgAugerAutoPos = true;
                this.vy446_usCmdLRPos = this.augerOpenGlForm.usCmdLRPos;
                this.vy446_usCmdUDPos = this.augerOpenGlForm.usCmdUDPos;

                // debug message
                this.augerOpenGlForm.SteeringInformation("Auger Move");
            }
            else
            {
                if ((this.is_auger_move_stop == true) && (this.augerOpenGlForm.is_grain_tank_detection == true))
                {
                    double auger_distance = this.augerOpenGlForm.DistanceBetweenTargetAndCurrentOfAuger();

                    if (auger_distance > auger_target_range)
                    {
                        //this.auger_sim_to_real = auger_distance;
                        double reverse_speed = 0.0;

                        if (this.is_auger_forward_and_backward == true)
                        {
                            // backward
                            reverse_speed = 1200;

                            // debug message
                            this.augerOpenGlForm.SteeringInformation("Backward");
                        }
                        else
                        {
                            // forward
                            reverse_speed = 1525;

                            // debug message
                            this.augerOpenGlForm.SteeringInformation("Forward");
                        }

                        this.vy446_usCmdHst = Convert.ToUInt16(reverse_speed);

                    }
                    else
                    {
                        this.is_final_auger_detection = true;
                    }

                }

                if ((travel_distance > auger_travel_range) && (this.is_auger_move_stop == false))
                {
                    // move stop
                    this.vy446_usCmdHst = Convert.ToUInt16(1405);

                    // debug message
                    this.augerOpenGlForm.SteeringInformation("Stop");

                    // grain tank detection
                    this.augerOpenGlForm.DrawSquareInImage();

                    this.is_auger_move_stop = true;
                }
            }
        }

        /// <summary>
        /// Revised 2013-09-30
        /// Forward Harvesting of Vy446
        /// </summary>
        private void Vy446ForwardHarvesting()
        {
            // device setup
            this.Vy446InitializationDevice();

            // header control
            this.Vy446HeaderControl();

            // forward steer control
            if (this.is_forward_steer_start == true)
            {
                this.Vy446ForwardSteerControl();
            }
        }

        /// <summary>
        /// if forward steer count is 20 then excute forwardsteering method.
        /// </summary>
        private int forward_steer_start_count = 0;

        /// <summary>
        /// Revised 2013-09-30
        /// Vy446 Initialization Device for forward harvesting control
        /// </summary>
        private void Vy446InitializationDevice()
        {
            // for header control
            // initialization of header position, karitori and karitakasa state
            if (this.isIniHeader == false)
            {
                // header position
                this.iniHeaderPos = Convert.ToUInt16(this.Vy446_DEBUG_INI_HEADER_POS_TxtBox.Text);
                this.vy446_usCmdKaritaka = this.iniHeaderPos;

                // karitori on
                this.vy446_KaritoriRadio = true;

                // karitakasa on
                this.vy446_m_ucFgKaritakaPosCtrl = true;

                // convert true state
                this.isIniHeader = true;
            }

            if (this.forward_steer_start_count < 20)
            {
                this.is_forward_steer_start = false;
                this.forward_steer_start_count++;
            }
            else
            {
                this.is_forward_steer_start = true;
            }

            // for forward speed and steer control
            // initialization of forward steer start state
            if (this.is_forward_steer_start == true)
            {
                // forward on - Vy446_DEBUG_INI_TRAVEL_SPEED_TxtBox.text
                this.forward_Speed = Convert.ToDouble(this.Vy446_DEBUG_INI_TRAVEL_SPEED_TxtBox.Text);
                this.vy446_usCmdHst = this._vy446.SetHstCmd(forward_Speed);

                // set steer nuetral
                this.vy446_usCmdSteer = Convert.ToUInt16(430);
            }
        }

        /// <summary>
        /// Revised 2013-10-04
        /// Vy446 Header Control Method
        /// Karitori, Karitakasa radios must be convert true state.
        /// </summary>
        private void Vy446HeaderControl()
        {
            // header control
            if (this.Vy446_IS_AUTO_HEADER_CONTROL_CHECKBOX.Checked == true)
            {
                this.cropStand.HeaderControl(this.sickLidar.cartesianList, this.drawGlIndex, 1, this.iniHeaderPos, this.backTmX, this.backTmY);
                this.vy446_usCmdKaritaka = this.cropStand.header_potentiometer;
            }
            else
            {
                this.vy446_usCmdKaritaka = this.iniHeaderPos;
            }

            // end of crop
            if (this.cropStand.is_ransac_end == true)
            {
                this.vy446_usCmdKaritaka = Convert.ToUInt16(680);
                this.cropStand.DisposeHeader();
            }

            // header control debug
            this.lidarOpenGlForm.HeaderControlDebug(this.vy446_usCmdKaritaka, this.cropStand.karitaka_start_distance, this.cropStand.karitaka_end_distance, this.cropStand.avgGndHgt);
            this.Vy446_isHeaderControl_TxtBox.Text = Convert.ToString(this.cropStand.isHeaderControl);
            this.Vy446_HeaderPotentiometer_TxtBox.Text = Convert.ToString(this.vy446_usCmdKaritaka);
        }

        /// <summary>
        /// gets or sets forward speed
        /// </summary>
        private double forward_Speed { get; set; }

        /// <summary>
        /// gets or sets is forward steer start state
        /// </summary>
        private bool is_forward_steer_start = false;

        /// <summary>
        /// gets or sets is vy446 operator on
        /// </summary>
        private bool is_vy446_operator_on { get; set; }

        /// <summary>
        /// Revised 2013-09-19
        /// Vy446 forward control method
        /// </summary>
        private void Vy446ForwardSteerControl()
        {
            if ((this._vy446.SW_CLUTCH & 0x03) == 0)
            {
                // 作業機がオフ
                this.is_vy446_operator_on = false;
            }
            else
            {
                // 作業機がオン
                this.is_vy446_operator_on = true;
            }

            // steering
            this.cropStand.Vy446ForwardSteer(this.backHeading, this.forward_Speed, this.is_vy446_operator_on);

            // 操舵量コマンド：左操舵最大(250)，中立(430)，右操舵最大(660)
            this.vy446_usCmdSteer = this.cropStand.vy446_usCmdSteer;

            // end of crop
            if (this.cropStand.is_ransac_end == true)
            {
                // forward off - speed is zero and steer is neutral
                this.vy446_usCmdHst = this._vy446.SetHstCmd(0.1);
                this.vy446_usCmdSteer = Convert.ToUInt16(430);
                this.cropStand.forward_steer_debug_msg = "0";
            }

            // forward steering debug message
            this.lidarOpenGlForm.ForwardSteerDebug(false, true, this.vy446_usCmdSteer, this.vy446_usCmdHst, this.cropStand.forward_steer_debug_msg);

            // debug message
            this.Vy446_DEBUG_HST_TxtBox.Text = Convert.ToString(this.vy446_usCmdHst);
            this.Vy446_DEBUG_SOKO_TxtBox.Text = Convert.ToString(this.vy446_usCmdSteer);
        }
    }
}
