namespace IidaLabVy446
{
    partial class AugerOpenGlForm
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
            this.glControl1 = new OpenTK.GLControl();
            this.label1 = new System.Windows.Forms.Label();
            this.GlAugerLengthTxtBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GlBodySpeedTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.GlBodyHeadingTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GlTmZTxtBox = new System.Windows.Forms.TextBox();
            this.GlTmYTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GlTmXTxtBox = new System.Windows.Forms.TextBox();
            this.GlReadCntTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.GlAugerSpoutZTxtBox = new System.Windows.Forms.TextBox();
            this.GlAugerSpoutYTxtBox = new System.Windows.Forms.TextBox();
            this.GlAugerSpoutXTxtBox = new System.Windows.Forms.TextBox();
            this.GlAugerOriginZTxtBox = new System.Windows.Forms.TextBox();
            this.GlAugerOriginYTxtBox = new System.Windows.Forms.TextBox();
            this.GlAugerOriginXTxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.GlRollTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.GlYawTxtBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.GlProcessingTimeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl1)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(6, 6);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(532, 479);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Auger Length: ";
            // 
            // GlAugerLengthTxtBox
            // 
            this.GlAugerLengthTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlAugerLengthTxtBox.Location = new System.Drawing.Point(89, 18);
            this.GlAugerLengthTxtBox.Name = "GlAugerLengthTxtBox";
            this.GlAugerLengthTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlAugerLengthTxtBox.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.GlBodySpeedTxtBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.GlBodyHeadingTxtBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.GlTmZTxtBox);
            this.groupBox2.Controls.Add(this.GlTmYTxtBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.GlTmXTxtBox);
            this.groupBox2.Controls.Add(this.GlReadCntTxtBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(572, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 172);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Combine Harvester Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Speed[m/s]: ";
            // 
            // GlBodySpeedTxtBox
            // 
            this.GlBodySpeedTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlBodySpeedTxtBox.Location = new System.Drawing.Point(89, 143);
            this.GlBodySpeedTxtBox.Name = "GlBodySpeedTxtBox";
            this.GlBodySpeedTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlBodySpeedTxtBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Azimuth[deg]: ";
            // 
            // GlBodyHeadingTxtBox
            // 
            this.GlBodyHeadingTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlBodyHeadingTxtBox.Location = new System.Drawing.Point(89, 118);
            this.GlBodyHeadingTxtBox.Name = "GlBodyHeadingTxtBox";
            this.GlBodyHeadingTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlBodyHeadingTxtBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tm Z[m]: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tm Y[m]: ";
            // 
            // GlTmZTxtBox
            // 
            this.GlTmZTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlTmZTxtBox.Location = new System.Drawing.Point(89, 93);
            this.GlTmZTxtBox.Name = "GlTmZTxtBox";
            this.GlTmZTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmZTxtBox.TabIndex = 7;
            // 
            // GlTmYTxtBox
            // 
            this.GlTmYTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlTmYTxtBox.Location = new System.Drawing.Point(89, 68);
            this.GlTmYTxtBox.Name = "GlTmYTxtBox";
            this.GlTmYTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmYTxtBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tm X[m]: ";
            // 
            // GlTmXTxtBox
            // 
            this.GlTmXTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlTmXTxtBox.Location = new System.Drawing.Point(89, 43);
            this.GlTmXTxtBox.Name = "GlTmXTxtBox";
            this.GlTmXTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmXTxtBox.TabIndex = 5;
            // 
            // GlReadCntTxtBox
            // 
            this.GlReadCntTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlReadCntTxtBox.Location = new System.Drawing.Point(89, 18);
            this.GlReadCntTxtBox.Name = "GlReadCntTxtBox";
            this.GlReadCntTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlReadCntTxtBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Read Count: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.GlAugerSpoutZTxtBox);
            this.groupBox3.Controls.Add(this.GlAugerSpoutYTxtBox);
            this.groupBox3.Controls.Add(this.GlAugerSpoutXTxtBox);
            this.groupBox3.Controls.Add(this.GlAugerOriginZTxtBox);
            this.groupBox3.Controls.Add(this.GlAugerOriginYTxtBox);
            this.groupBox3.Controls.Add(this.GlAugerOriginXTxtBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.GlRollTxtBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.GlYawTxtBox);
            this.groupBox3.Controls.Add(this.GlAugerLengthTxtBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(572, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 320);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Auger Information";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 221);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 12);
            this.label15.TabIndex = 18;
            this.label15.Text = "Spout Z: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "Spout Y: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 12);
            this.label13.TabIndex = 16;
            this.label13.Text = "Spout X: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 12);
            this.label12.TabIndex = 15;
            this.label12.Text = "Origin Z: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "Origin Y: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "Origin X: ";
            // 
            // GlAugerSpoutZTxtBox
            // 
            this.GlAugerSpoutZTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlAugerSpoutZTxtBox.Location = new System.Drawing.Point(89, 218);
            this.GlAugerSpoutZTxtBox.Name = "GlAugerSpoutZTxtBox";
            this.GlAugerSpoutZTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlAugerSpoutZTxtBox.TabIndex = 12;
            // 
            // GlAugerSpoutYTxtBox
            // 
            this.GlAugerSpoutYTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlAugerSpoutYTxtBox.Location = new System.Drawing.Point(89, 193);
            this.GlAugerSpoutYTxtBox.Name = "GlAugerSpoutYTxtBox";
            this.GlAugerSpoutYTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlAugerSpoutYTxtBox.TabIndex = 11;
            // 
            // GlAugerSpoutXTxtBox
            // 
            this.GlAugerSpoutXTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlAugerSpoutXTxtBox.Location = new System.Drawing.Point(89, 168);
            this.GlAugerSpoutXTxtBox.Name = "GlAugerSpoutXTxtBox";
            this.GlAugerSpoutXTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlAugerSpoutXTxtBox.TabIndex = 10;
            // 
            // GlAugerOriginZTxtBox
            // 
            this.GlAugerOriginZTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlAugerOriginZTxtBox.Location = new System.Drawing.Point(89, 143);
            this.GlAugerOriginZTxtBox.Name = "GlAugerOriginZTxtBox";
            this.GlAugerOriginZTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlAugerOriginZTxtBox.TabIndex = 9;
            // 
            // GlAugerOriginYTxtBox
            // 
            this.GlAugerOriginYTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlAugerOriginYTxtBox.Location = new System.Drawing.Point(89, 118);
            this.GlAugerOriginYTxtBox.Name = "GlAugerOriginYTxtBox";
            this.GlAugerOriginYTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlAugerOriginYTxtBox.TabIndex = 8;
            // 
            // GlAugerOriginXTxtBox
            // 
            this.GlAugerOriginXTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlAugerOriginXTxtBox.Location = new System.Drawing.Point(89, 93);
            this.GlAugerOriginXTxtBox.Name = "GlAugerOriginXTxtBox";
            this.GlAugerOriginXTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlAugerOriginXTxtBox.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "Roll[deg]: ";
            // 
            // GlRollTxtBox
            // 
            this.GlRollTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRollTxtBox.Location = new System.Drawing.Point(89, 68);
            this.GlRollTxtBox.Name = "GlRollTxtBox";
            this.GlRollTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRollTxtBox.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "Yaw[deg]: ";
            // 
            // GlYawTxtBox
            // 
            this.GlYawTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlYawTxtBox.Location = new System.Drawing.Point(89, 43);
            this.GlYawTxtBox.Name = "GlYawTxtBox";
            this.GlYawTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlYawTxtBox.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 520);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.glControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(546, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "3D Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.zg1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(546, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2D Lidar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // zg1
            // 
            this.zg1.Location = new System.Drawing.Point(6, 6);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(534, 234);
            this.zg1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(12, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(760, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.GlProcessingTimeStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(787, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(117, 17);
            this.toolStripStatusLabel1.Text = "Processing Speed: ";
            // 
            // GlProcessingTimeStatusLabel
            // 
            this.GlProcessingTimeStatusLabel.Name = "GlProcessingTimeStatusLabel";
            this.GlProcessingTimeStatusLabel.Size = new System.Drawing.Size(41, 17);
            this.GlProcessingTimeStatusLabel.Text = "[m/s]";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pBoxIpl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(546, 494);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Top View Image";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pBoxIpl1
            // 
            this.pBoxIpl1.Location = new System.Drawing.Point(3, 3);
            this.pBoxIpl1.Name = "pBoxIpl1";
            this.pBoxIpl1.Size = new System.Drawing.Size(400, 400);
            this.pBoxIpl1.TabIndex = 0;
            this.pBoxIpl1.TabStop = false;
            // 
            // AugerOpenGlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 600);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "AugerOpenGlForm";
            this.Text = "3D Grain Tank Map";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GlAugerLengthTxtBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox GlReadCntTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GlTmXTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GlTmZTxtBox;
        private System.Windows.Forms.TextBox GlTmYTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GlBodyHeadingTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox GlBodySpeedTxtBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox GlYawTxtBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox GlRollTxtBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox GlAugerSpoutZTxtBox;
        private System.Windows.Forms.TextBox GlAugerSpoutYTxtBox;
        private System.Windows.Forms.TextBox GlAugerSpoutXTxtBox;
        private System.Windows.Forms.TextBox GlAugerOriginZTxtBox;
        private System.Windows.Forms.TextBox GlAugerOriginYTxtBox;
        private System.Windows.Forms.TextBox GlAugerOriginXTxtBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel GlProcessingTimeStatusLabel;
        private System.Windows.Forms.TabPage tabPage3;
        private OpenCvSharp.UserInterface.PictureBoxIpl pBoxIpl1;
    }
}