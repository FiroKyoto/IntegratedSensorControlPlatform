using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectInput;
using Joystick;

namespace Display
{
    public partial class SteeringForm : Form
    {
        #region fields

        private Joystick.G27 g27;

        #endregion

        #region constructor

        public SteeringForm()
        {
            InitializeComponent();
        }
        
        #endregion

        private void Startbutton_Click(object sender, EventArgs e)
        {
            this.g27 = new G27();
            this.g27.Start(this);

            this.LogTxtBox.AppendText("名称: " + this.g27.joystick.DeviceInformation.ProductName + Environment.NewLine);
            this.LogTxtBox.AppendText("軸の数: " + this.g27.joystick.Caps.NumberAxes + Environment.NewLine);
            this.LogTxtBox.AppendText("ボタンの数: " + this.g27.joystick.Caps.NumberButtons + Environment.NewLine);
            this.LogTxtBox.AppendText("PoVハットの数: " + this.g27.joystick.Caps.NumberPointOfViews + Environment.NewLine);

            this.timer1.Interval = 100;
            this.timer1.Enabled = true;
        }

        private void RunControlButton_Click(object sender, EventArgs e)
        {
            if (this.g27.joystick != null)
            {
                this.g27.joystick.RunControlPanel();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ControlTxtBox.Text = this.g27.Controller().ToString();
        }
    }
}
