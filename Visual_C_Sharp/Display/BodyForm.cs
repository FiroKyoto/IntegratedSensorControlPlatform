using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CombineBody;

namespace Display
{
    public partial class BodyForm : Form
    {
        private CombineBody.SerialConnect serialConnect;

        public BodyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.serialConnect = new CombineBody.SerialConnect(
                this.PortTxtBox.Text,
                Convert.ToInt32(this.BaudRateTxtBox.Text),
                Convert.ToInt32(this.DataBitsTxtBox.Text)
                );

            this.BodyTimer.Interval = Convert.ToInt32(this.IntervalTxtBox.Text);
            this.BodyTimer.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.BodyTimer.Enabled == true)
            {
                this.BodyTimer.Enabled = false;
                this.serialConnect.Dispose();
            }

            this.Close();
        }

        private void BodyTimer_Tick(object sender, EventArgs e)
        {
            this.serialConnect.DataReceived();
            this.LogTxtBox.Text = this.serialConnect.resultStr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //byte[] bytes = new byte[4];
            //bytes[0] = 55;
            //bytes[1] = 105;
            //bytes[2] = 63;
            //bytes[3] = 65;

            //this.LogTxtBox.Text = Convert.ToString(BitConverter.ToSingle(bytes, 0));

            //byte a = 0xff ^ 0x40;
            byte a = (byte)(32768 & 0x00ff);
            this.LogTxtBox.Text = Convert.ToString(a);
        }
    }
}
