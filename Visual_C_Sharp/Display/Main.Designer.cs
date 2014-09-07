namespace Display
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SteeringCheckBox = new System.Windows.Forms.CheckBox();
            this.NetworkCameraCheckBox = new System.Windows.Forms.CheckBox();
            this.DimagerCheckBox = new System.Windows.Forms.CheckBox();
            this.IntegratedCheckBox = new System.Windows.Forms.CheckBox();
            this.GpsCheckBox = new System.Windows.Forms.CheckBox();
            this.BodyCheckBox = new System.Windows.Forms.CheckBox();
            this.MvCheckBox = new System.Windows.Forms.CheckBox();
            this.LrfCheckBox = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SteeringCheckBox);
            this.groupBox1.Controls.Add(this.NetworkCameraCheckBox);
            this.groupBox1.Controls.Add(this.DimagerCheckBox);
            this.groupBox1.Controls.Add(this.GpsCheckBox);
            this.groupBox1.Controls.Add(this.BodyCheckBox);
            this.groupBox1.Controls.Add(this.MvCheckBox);
            this.groupBox1.Controls.Add(this.LrfCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Sensor Device";
            // 
            // SteeringCheckBox
            // 
            this.SteeringCheckBox.AutoSize = true;
            this.SteeringCheckBox.Location = new System.Drawing.Point(170, 41);
            this.SteeringCheckBox.Name = "SteeringCheckBox";
            this.SteeringCheckBox.Size = new System.Drawing.Size(100, 16);
            this.SteeringCheckBox.TabIndex = 10;
            this.SteeringCheckBox.Text = "Steering Wheel";
            this.SteeringCheckBox.UseVisualStyleBackColor = true;
            // 
            // NetworkCameraCheckBox
            // 
            this.NetworkCameraCheckBox.AutoSize = true;
            this.NetworkCameraCheckBox.Location = new System.Drawing.Point(170, 63);
            this.NetworkCameraCheckBox.Name = "NetworkCameraCheckBox";
            this.NetworkCameraCheckBox.Size = new System.Drawing.Size(109, 16);
            this.NetworkCameraCheckBox.TabIndex = 9;
            this.NetworkCameraCheckBox.Text = "Network Camera";
            this.NetworkCameraCheckBox.UseVisualStyleBackColor = true;
            // 
            // DimagerCheckBox
            // 
            this.DimagerCheckBox.AutoSize = true;
            this.DimagerCheckBox.Location = new System.Drawing.Point(170, 19);
            this.DimagerCheckBox.Name = "DimagerCheckBox";
            this.DimagerCheckBox.Size = new System.Drawing.Size(72, 16);
            this.DimagerCheckBox.TabIndex = 8;
            this.DimagerCheckBox.Text = "D-Imager";
            this.DimagerCheckBox.UseVisualStyleBackColor = true;
            // 
            // IntegratedCheckBox
            // 
            this.IntegratedCheckBox.AutoSize = true;
            this.IntegratedCheckBox.Checked = true;
            this.IntegratedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IntegratedCheckBox.Location = new System.Drawing.Point(7, 29);
            this.IntegratedCheckBox.Name = "IntegratedCheckBox";
            this.IntegratedCheckBox.Size = new System.Drawing.Size(155, 16);
            this.IntegratedCheckBox.TabIndex = 7;
            this.IntegratedCheckBox.Text = "Integrated Sensor Control";
            this.IntegratedCheckBox.UseVisualStyleBackColor = true;
            // 
            // GpsCheckBox
            // 
            this.GpsCheckBox.AutoSize = true;
            this.GpsCheckBox.Location = new System.Drawing.Point(7, 85);
            this.GpsCheckBox.Name = "GpsCheckBox";
            this.GpsCheckBox.Size = new System.Drawing.Size(141, 16);
            this.GpsCheckBox.TabIndex = 6;
            this.GpsCheckBox.Text = "GPS with Google Earth";
            this.GpsCheckBox.UseVisualStyleBackColor = true;
            // 
            // BodyCheckBox
            // 
            this.BodyCheckBox.AutoSize = true;
            this.BodyCheckBox.Location = new System.Drawing.Point(7, 63);
            this.BodyCheckBox.Name = "BodyCheckBox";
            this.BodyCheckBox.Size = new System.Drawing.Size(98, 16);
            this.BodyCheckBox.TabIndex = 5;
            this.BodyCheckBox.Text = "Combine Body";
            this.BodyCheckBox.UseVisualStyleBackColor = true;
            // 
            // MvCheckBox
            // 
            this.MvCheckBox.AutoSize = true;
            this.MvCheckBox.Location = new System.Drawing.Point(7, 41);
            this.MvCheckBox.Name = "MvCheckBox";
            this.MvCheckBox.Size = new System.Drawing.Size(102, 16);
            this.MvCheckBox.TabIndex = 4;
            this.MvCheckBox.Text = "Machine Vision";
            this.MvCheckBox.UseVisualStyleBackColor = true;
            // 
            // LrfCheckBox
            // 
            this.LrfCheckBox.AutoSize = true;
            this.LrfCheckBox.Location = new System.Drawing.Point(7, 19);
            this.LrfCheckBox.Name = "LrfCheckBox";
            this.LrfCheckBox.Size = new System.Drawing.Size(124, 16);
            this.LrfCheckBox.TabIndex = 3;
            this.LrfCheckBox.Text = "Laser Range Finder";
            this.LrfCheckBox.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 259);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(299, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(12, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(299, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.IntegratedCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 63);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ISCSP";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 294);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Name = "Main";
            this.Text = "Select Sensor";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox GpsCheckBox;
        private System.Windows.Forms.CheckBox BodyCheckBox;
        private System.Windows.Forms.CheckBox MvCheckBox;
        private System.Windows.Forms.CheckBox LrfCheckBox;
        private System.Windows.Forms.CheckBox IntegratedCheckBox;
        private System.Windows.Forms.CheckBox DimagerCheckBox;
        private System.Windows.Forms.CheckBox NetworkCameraCheckBox;
        private System.Windows.Forms.CheckBox SteeringCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

