namespace IidaLabVy446
{
    partial class LidarOpenGlForm
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
            this.glControl1 = new OpenTK.GLControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GlBodySpeedTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GlTmZTxtBox = new System.Windows.Forms.TextBox();
            this.GlTmYTxtBox = new System.Windows.Forms.TextBox();
            this.GlTmXTxtBox = new System.Windows.Forms.TextBox();
            this.GlCurCntTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GlReadCntTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GlBodyHeadingTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GlElapsedTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.GlRanPosY2TxtBox = new System.Windows.Forms.TextBox();
            this.GlRanPosX2TxtBox = new System.Windows.Forms.TextBox();
            this.GlRanPosY1TxtBox = new System.Windows.Forms.TextBox();
            this.GlRanPosX1TxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GlAvgCropHgtTxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.GlSteerOperationTxtBox = new System.Windows.Forms.TextBox();
            this.GlSteerCmdTxtBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.GlRanStandDistanceTxtBox = new System.Windows.Forms.TextBox();
            this.GlRanDistanceTxtBox = new System.Windows.Forms.TextBox();
            this.GlRanHeadingTxtBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.GlRanStartTxtBox = new System.Windows.Forms.TextBox();
            this.GlRanEndTxtBox = new System.Windows.Forms.TextBox();
            this.GlIsRanTxtBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.GlHstCmdTxtBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(6, 18);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(500, 500);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.glControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 526);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OpenGL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GlBodySpeedTxtBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.GlTmZTxtBox);
            this.groupBox2.Controls.Add(this.GlTmYTxtBox);
            this.groupBox2.Controls.Add(this.GlTmXTxtBox);
            this.groupBox2.Controls.Add(this.GlCurCntTxtBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.GlReadCntTxtBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(534, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 176);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Body Information";
            // 
            // GlBodySpeedTxtBox
            // 
            this.GlBodySpeedTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlBodySpeedTxtBox.Location = new System.Drawing.Point(92, 143);
            this.GlBodySpeedTxtBox.Name = "GlBodySpeedTxtBox";
            this.GlBodySpeedTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlBodySpeedTxtBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "Speed: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tm Z: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tm Y: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tm X: ";
            // 
            // GlTmZTxtBox
            // 
            this.GlTmZTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlTmZTxtBox.Location = new System.Drawing.Point(92, 118);
            this.GlTmZTxtBox.Name = "GlTmZTxtBox";
            this.GlTmZTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmZTxtBox.TabIndex = 6;
            // 
            // GlTmYTxtBox
            // 
            this.GlTmYTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlTmYTxtBox.Location = new System.Drawing.Point(92, 93);
            this.GlTmYTxtBox.Name = "GlTmYTxtBox";
            this.GlTmYTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmYTxtBox.TabIndex = 5;
            // 
            // GlTmXTxtBox
            // 
            this.GlTmXTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlTmXTxtBox.Location = new System.Drawing.Point(92, 68);
            this.GlTmXTxtBox.Name = "GlTmXTxtBox";
            this.GlTmXTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmXTxtBox.TabIndex = 4;
            // 
            // GlCurCntTxtBox
            // 
            this.GlCurCntTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlCurCntTxtBox.Location = new System.Drawing.Point(92, 43);
            this.GlCurCntTxtBox.Name = "GlCurCntTxtBox";
            this.GlCurCntTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlCurCntTxtBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Crop Cnt: ";
            // 
            // GlReadCntTxtBox
            // 
            this.GlReadCntTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlReadCntTxtBox.Location = new System.Drawing.Point(92, 18);
            this.GlReadCntTxtBox.Name = "GlReadCntTxtBox";
            this.GlReadCntTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlReadCntTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Read Count: ";
            // 
            // GlBodyHeadingTxtBox
            // 
            this.GlBodyHeadingTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlBodyHeadingTxtBox.Location = new System.Drawing.Point(92, 18);
            this.GlBodyHeadingTxtBox.Name = "GlBodyHeadingTxtBox";
            this.GlBodyHeadingTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlBodyHeadingTxtBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Body Heading: ";
            // 
            // GlElapsedTxtBox
            // 
            this.GlElapsedTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlElapsedTxtBox.Location = new System.Drawing.Point(836, 482);
            this.GlElapsedTxtBox.Name = "GlElapsedTxtBox";
            this.GlElapsedTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlElapsedTxtBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(750, 485);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Elapsed Time: ";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Yellow;
            this.ExitButton.Location = new System.Drawing.Point(534, 507);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(414, 23);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "CLOSE FORM";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(6, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "SAVE DATA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.GlRanPosY2TxtBox);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.GlRanPosX2TxtBox);
            this.groupBox3.Controls.Add(this.GlRanPosY1TxtBox);
            this.groupBox3.Controls.Add(this.GlRanPosX1TxtBox);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.GlAvgCropHgtTxtBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(744, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 176);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save Information";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "Edge posY2: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "Edge posX2: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "Edge posY1: ";
            // 
            // GlRanPosY2TxtBox
            // 
            this.GlRanPosY2TxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanPosY2TxtBox.Location = new System.Drawing.Point(92, 114);
            this.GlRanPosY2TxtBox.Name = "GlRanPosY2TxtBox";
            this.GlRanPosY2TxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanPosY2TxtBox.TabIndex = 6;
            // 
            // GlRanPosX2TxtBox
            // 
            this.GlRanPosX2TxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanPosX2TxtBox.Location = new System.Drawing.Point(92, 89);
            this.GlRanPosX2TxtBox.Name = "GlRanPosX2TxtBox";
            this.GlRanPosX2TxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanPosX2TxtBox.TabIndex = 5;
            // 
            // GlRanPosY1TxtBox
            // 
            this.GlRanPosY1TxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanPosY1TxtBox.Location = new System.Drawing.Point(92, 64);
            this.GlRanPosY1TxtBox.Name = "GlRanPosY1TxtBox";
            this.GlRanPosY1TxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanPosY1TxtBox.TabIndex = 4;
            // 
            // GlRanPosX1TxtBox
            // 
            this.GlRanPosX1TxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanPosX1TxtBox.Location = new System.Drawing.Point(92, 39);
            this.GlRanPosX1TxtBox.Name = "GlRanPosX1TxtBox";
            this.GlRanPosX1TxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanPosX1TxtBox.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "Edge posX1: ";
            // 
            // GlAvgCropHgtTxtBox
            // 
            this.GlAvgCropHgtTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlAvgCropHgtTxtBox.Location = new System.Drawing.Point(92, 14);
            this.GlAvgCropHgtTxtBox.Name = "GlAvgCropHgtTxtBox";
            this.GlAvgCropHgtTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlAvgCropHgtTxtBox.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "Crop Hgt(Avg): ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.GlHstCmdTxtBox);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.GlSteerOperationTxtBox);
            this.groupBox4.Controls.Add(this.GlSteerCmdTxtBox);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.GlBodyHeadingTxtBox);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.GlRanStandDistanceTxtBox);
            this.groupBox4.Controls.Add(this.GlRanDistanceTxtBox);
            this.groupBox4.Controls.Add(this.GlRanHeadingTxtBox);
            this.groupBox4.Location = new System.Drawing.Point(534, 300);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 201);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Steering Information";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 146);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 12);
            this.label21.TabIndex = 18;
            this.label21.Text = "Operation: ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 17;
            this.label20.Text = "Steer Cmd: ";
            // 
            // GlSteerOperationTxtBox
            // 
            this.GlSteerOperationTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlSteerOperationTxtBox.Location = new System.Drawing.Point(92, 143);
            this.GlSteerOperationTxtBox.Name = "GlSteerOperationTxtBox";
            this.GlSteerOperationTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlSteerOperationTxtBox.TabIndex = 16;
            // 
            // GlSteerCmdTxtBox
            // 
            this.GlSteerCmdTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlSteerCmdTxtBox.Location = new System.Drawing.Point(92, 118);
            this.GlSteerCmdTxtBox.Name = "GlSteerCmdTxtBox";
            this.GlSteerCmdTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlSteerCmdTxtBox.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 12);
            this.label17.TabIndex = 7;
            this.label17.Text = "Average Dist: ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 12);
            this.label16.TabIndex = 6;
            this.label16.Text = "Current Dist: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 12);
            this.label15.TabIndex = 5;
            this.label15.Text = "Ran Heading: ";
            // 
            // GlRanStandDistanceTxtBox
            // 
            this.GlRanStandDistanceTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanStandDistanceTxtBox.Location = new System.Drawing.Point(92, 93);
            this.GlRanStandDistanceTxtBox.Name = "GlRanStandDistanceTxtBox";
            this.GlRanStandDistanceTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanStandDistanceTxtBox.TabIndex = 4;
            // 
            // GlRanDistanceTxtBox
            // 
            this.GlRanDistanceTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanDistanceTxtBox.Location = new System.Drawing.Point(92, 68);
            this.GlRanDistanceTxtBox.Name = "GlRanDistanceTxtBox";
            this.GlRanDistanceTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanDistanceTxtBox.TabIndex = 3;
            // 
            // GlRanHeadingTxtBox
            // 
            this.GlRanHeadingTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanHeadingTxtBox.Location = new System.Drawing.Point(92, 43);
            this.GlRanHeadingTxtBox.Name = "GlRanHeadingTxtBox";
            this.GlRanHeadingTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanHeadingTxtBox.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 12);
            this.label19.TabIndex = 11;
            this.label19.Text = "Ran End: ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 12);
            this.label18.TabIndex = 10;
            this.label18.Text = "Ran Start: ";
            // 
            // GlRanStartTxtBox
            // 
            this.GlRanStartTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanStartTxtBox.Location = new System.Drawing.Point(92, 18);
            this.GlRanStartTxtBox.Name = "GlRanStartTxtBox";
            this.GlRanStartTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanStartTxtBox.TabIndex = 9;
            // 
            // GlRanEndTxtBox
            // 
            this.GlRanEndTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanEndTxtBox.Location = new System.Drawing.Point(92, 68);
            this.GlRanEndTxtBox.Name = "GlRanEndTxtBox";
            this.GlRanEndTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanEndTxtBox.TabIndex = 8;
            // 
            // GlIsRanTxtBox
            // 
            this.GlIsRanTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlIsRanTxtBox.Location = new System.Drawing.Point(92, 43);
            this.GlIsRanTxtBox.Name = "GlIsRanTxtBox";
            this.GlIsRanTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlIsRanTxtBox.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "Ran Running: ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.GlRanStartTxtBox);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.GlIsRanTxtBox);
            this.groupBox5.Controls.Add(this.GlRanEndTxtBox);
            this.groupBox5.Location = new System.Drawing.Point(534, 194);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(204, 100);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RANSAC State";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 171);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 12);
            this.label22.TabIndex = 19;
            this.label22.Text = "HST Cmd: ";
            // 
            // GlHstCmdTxtBox
            // 
            this.GlHstCmdTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlHstCmdTxtBox.Location = new System.Drawing.Point(92, 168);
            this.GlHstCmdTxtBox.Name = "GlHstCmdTxtBox";
            this.GlHstCmdTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlHstCmdTxtBox.TabIndex = 20;
            // 
            // LidarOpenGlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 555);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GlElapsedTxtBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Name = "LidarOpenGlForm";
            this.Text = "3D terrain map (using LRF, RTK-GPS, GPS compass )";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox GlElapsedTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GlTmZTxtBox;
        private System.Windows.Forms.TextBox GlTmYTxtBox;
        private System.Windows.Forms.TextBox GlTmXTxtBox;
        private System.Windows.Forms.TextBox GlCurCntTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GlReadCntTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GlBodySpeedTxtBox;
        private System.Windows.Forms.TextBox GlBodyHeadingTxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox GlRanPosY2TxtBox;
        private System.Windows.Forms.TextBox GlRanPosX2TxtBox;
        private System.Windows.Forms.TextBox GlRanPosY1TxtBox;
        private System.Windows.Forms.TextBox GlRanPosX1TxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox GlAvgCropHgtTxtBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox GlRanStandDistanceTxtBox;
        private System.Windows.Forms.TextBox GlRanDistanceTxtBox;
        private System.Windows.Forms.TextBox GlRanHeadingTxtBox;
        private System.Windows.Forms.TextBox GlIsRanTxtBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox GlRanStartTxtBox;
        private System.Windows.Forms.TextBox GlRanEndTxtBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox GlSteerCmdTxtBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox GlSteerOperationTxtBox;
        private System.Windows.Forms.TextBox GlHstCmdTxtBox;
        private System.Windows.Forms.Label label22;
    }
}