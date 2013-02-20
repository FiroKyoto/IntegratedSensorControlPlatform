namespace IidaLabVy446
{
    partial class LidarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.HostTxtBox = new System.Windows.Forms.TextBox();
            this.PortTxtBox = new System.Windows.Forms.TextBox();
            this.SelectDeviceComBox = new System.Windows.Forms.ComboBox();
            this.IntervalTxtBox = new System.Windows.Forms.TextBox();
            this.ScalingFactorTxtBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SaveCheckBox = new System.Windows.Forms.CheckBox();
            this.ReadCheckBox = new System.Windows.Forms.CheckBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SickTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "To set the static ip address(192.168.0.100) on your pc, click control panel";
            // 
            // zg1
            // 
            this.zg1.Location = new System.Drawing.Point(6, 18);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(400, 300);
            this.zg1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ip Address: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.zg1);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 326);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ScalingFactorTxtBox);
            this.groupBox2.Controls.Add(this.IntervalTxtBox);
            this.groupBox2.Controls.Add(this.SelectDeviceComBox);
            this.groupBox2.Controls.Add(this.PortTxtBox);
            this.groupBox2.Controls.Add(this.HostTxtBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(433, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 155);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Setting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "TCP Port: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Select Device: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Interval: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Scaling Factor: ";
            // 
            // HostTxtBox
            // 
            this.HostTxtBox.Location = new System.Drawing.Point(102, 15);
            this.HostTxtBox.Name = "HostTxtBox";
            this.HostTxtBox.Size = new System.Drawing.Size(100, 19);
            this.HostTxtBox.TabIndex = 7;
            this.HostTxtBox.Text = "192.168.0.1";
            // 
            // PortTxtBox
            // 
            this.PortTxtBox.Location = new System.Drawing.Point(102, 40);
            this.PortTxtBox.Name = "PortTxtBox";
            this.PortTxtBox.Size = new System.Drawing.Size(100, 19);
            this.PortTxtBox.TabIndex = 8;
            this.PortTxtBox.Text = "2111";
            // 
            // SelectDeviceComBox
            // 
            this.SelectDeviceComBox.FormattingEnabled = true;
            this.SelectDeviceComBox.Items.AddRange(new object[] {
            "LMS111",
            "LMS511"});
            this.SelectDeviceComBox.Location = new System.Drawing.Point(102, 66);
            this.SelectDeviceComBox.Name = "SelectDeviceComBox";
            this.SelectDeviceComBox.Size = new System.Drawing.Size(100, 20);
            this.SelectDeviceComBox.TabIndex = 9;
            // 
            // IntervalTxtBox
            // 
            this.IntervalTxtBox.Location = new System.Drawing.Point(102, 92);
            this.IntervalTxtBox.Name = "IntervalTxtBox";
            this.IntervalTxtBox.Size = new System.Drawing.Size(100, 19);
            this.IntervalTxtBox.TabIndex = 10;
            this.IntervalTxtBox.Text = "100";
            // 
            // ScalingFactorTxtBox
            // 
            this.ScalingFactorTxtBox.Location = new System.Drawing.Point(102, 119);
            this.ScalingFactorTxtBox.Name = "ScalingFactorTxtBox";
            this.ScalingFactorTxtBox.Size = new System.Drawing.Size(100, 19);
            this.ScalingFactorTxtBox.TabIndex = 11;
            this.ScalingFactorTxtBox.Text = "2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ReadCheckBox);
            this.groupBox3.Controls.Add(this.SaveCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(433, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 50);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File I/O";
            // 
            // SaveCheckBox
            // 
            this.SaveCheckBox.AutoSize = true;
            this.SaveCheckBox.Location = new System.Drawing.Point(9, 18);
            this.SaveCheckBox.Name = "SaveCheckBox";
            this.SaveCheckBox.Size = new System.Drawing.Size(49, 16);
            this.SaveCheckBox.TabIndex = 0;
            this.SaveCheckBox.Text = "Save";
            this.SaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReadCheckBox
            // 
            this.ReadCheckBox.AutoSize = true;
            this.ReadCheckBox.Location = new System.Drawing.Point(102, 18);
            this.ReadCheckBox.Name = "ReadCheckBox";
            this.ReadCheckBox.Size = new System.Drawing.Size(50, 16);
            this.ReadCheckBox.TabIndex = 1;
            this.ReadCheckBox.Text = "Read";
            this.ReadCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(434, 251);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 6;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(515, 251);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 7;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(434, 280);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 362);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(653, 23);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(95, 18);
            this.toolStripStatusLabel1.Text = "Elapsed Time: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(78, 18);
            this.toolStripStatusLabel2.Text = "milliseconds";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(108, 18);
            this.toolStripStatusLabel3.Text = "Debug Message: ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(58, 18);
            this.toolStripStatusLabel4.Text = "Message";
            // 
            // SickTimer
            // 
            this.SickTimer.Tick += new System.EventHandler(this.SickTimer_Tick);
            // 
            // LidarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 385);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "LidarForm";
            this.Text = "Lidar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ScalingFactorTxtBox;
        private System.Windows.Forms.TextBox IntervalTxtBox;
        private System.Windows.Forms.ComboBox SelectDeviceComBox;
        private System.Windows.Forms.TextBox PortTxtBox;
        private System.Windows.Forms.TextBox HostTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ReadCheckBox;
        private System.Windows.Forms.CheckBox SaveCheckBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Timer SickTimer;
    }
}