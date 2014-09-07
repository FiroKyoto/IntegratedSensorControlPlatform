using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Display
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.LrfCheckBox.Checked == true)
            {
                LidarForm lidarForm = new LidarForm();
                lidarForm.Show();
            }

            if (this.MvCheckBox.Checked == true)
            {
                VisionForm visionForm = new VisionForm();
                visionForm.Show();
            }

            if (this.DimagerCheckBox.Checked == true)
            {
                DimagerForm dImagerForm = new DimagerForm();
                dImagerForm.Show();
            }

            if (this.IntegratedCheckBox.Checked == true)
            {
                IntegratedForm integratedForm = new IntegratedForm();
                integratedForm.Show();
            }

            if (this.BodyCheckBox.Checked == true)
            {
                BodyForm bodyForm = new BodyForm();
                bodyForm.Show();
            }

            if (this.NetworkCameraCheckBox.Checked == true)
            {
                NetworkCamera networkCamera = new NetworkCamera();
                networkCamera.Show();
            }

            if (this.SteeringCheckBox.Checked == true)
            {
                SteeringForm steeringForm = new SteeringForm();
                steeringForm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("q"))
            {
                this.Close();
            }

            if (e.KeyChar == Convert.ToChar("i"))
            {
                IntegratedForm integratedForm = new IntegratedForm();
                integratedForm.Show();
            }
        }
    }
}
