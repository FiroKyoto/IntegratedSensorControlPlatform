namespace Display
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
            this.components = new System.ComponentModel.Container();
            this.glControl1 = new OpenTK.GLControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.GlAutoModeTxtBox = new System.Windows.Forms.TextBox();
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
            this.GlBodyHeadingTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.GlElapsedTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.GlSaveStateTxtBox = new System.Windows.Forms.TextBox();
            this.GlSaveDataCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.GlHeaderRanHeadingTxtBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.GlRanStandDistanceTxtBox = new System.Windows.Forms.TextBox();
            this.GlRanDistanceTxtBox = new System.Windows.Forms.TextBox();
            this.GlRanHeadingTxtBox = new System.Windows.Forms.TextBox();
            this.GlGpsHeadingTxtBox = new System.Windows.Forms.TextBox();
            this.GlHstCmdTxtBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.GlGpsDistanceTxtBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.GlSteerOperationTxtBox = new System.Windows.Forms.TextBox();
            this.GlSteerCmdTxtBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.GlRanStartTxtBox = new System.Windows.Forms.TextBox();
            this.GlRanEndTxtBox = new System.Windows.Forms.TextBox();
            this.GlIsRanTxtBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.GlHeaderAvgGndHgtTxtBox = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.GlHeaderEndDistanceTxtBox = new System.Windows.Forms.TextBox();
            this.GlHeaderStartDistanceTxtBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.GlHeaderPoteniometerTxtBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.zgc1 = new ZedGraph.ZedGraphControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.GlHarvestDistanceTxtBox = new System.Windows.Forms.TextBox();
            this.GlHarvestTimesTxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.GlIdealHeadingTxtBox = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.GlBodyHeaderPotentiometerTxtBox = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(6, 3);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(496, 483);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GlBodyHeaderPotentiometerTxtBox);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.GlAutoModeTxtBox);
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
            this.groupBox2.Controls.Add(this.GlBodyHeadingTxtBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(534, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 255);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Body Information";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(7, 21);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(62, 12);
            this.label26.TabIndex = 17;
            this.label26.Text = "AutoMode: ";
            // 
            // GlAutoModeTxtBox
            // 
            this.GlAutoModeTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlAutoModeTxtBox.Location = new System.Drawing.Point(92, 18);
            this.GlAutoModeTxtBox.Name = "GlAutoModeTxtBox";
            this.GlAutoModeTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlAutoModeTxtBox.TabIndex = 16;
            // 
            // GlBodySpeedTxtBox
            // 
            this.GlBodySpeedTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlBodySpeedTxtBox.Location = new System.Drawing.Point(92, 168);
            this.GlBodySpeedTxtBox.Name = "GlBodySpeedTxtBox";
            this.GlBodySpeedTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlBodySpeedTxtBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "Speed: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tm Z: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tm Y: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tm X: ";
            // 
            // GlTmZTxtBox
            // 
            this.GlTmZTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlTmZTxtBox.Location = new System.Drawing.Point(92, 143);
            this.GlTmZTxtBox.Name = "GlTmZTxtBox";
            this.GlTmZTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmZTxtBox.TabIndex = 6;
            // 
            // GlTmYTxtBox
            // 
            this.GlTmYTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlTmYTxtBox.Location = new System.Drawing.Point(92, 118);
            this.GlTmYTxtBox.Name = "GlTmYTxtBox";
            this.GlTmYTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmYTxtBox.TabIndex = 5;
            // 
            // GlTmXTxtBox
            // 
            this.GlTmXTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlTmXTxtBox.Location = new System.Drawing.Point(92, 93);
            this.GlTmXTxtBox.Name = "GlTmXTxtBox";
            this.GlTmXTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmXTxtBox.TabIndex = 4;
            // 
            // GlCurCntTxtBox
            // 
            this.GlCurCntTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlCurCntTxtBox.Location = new System.Drawing.Point(92, 68);
            this.GlCurCntTxtBox.Name = "GlCurCntTxtBox";
            this.GlCurCntTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlCurCntTxtBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Crop Cnt: ";
            // 
            // GlReadCntTxtBox
            // 
            this.GlReadCntTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlReadCntTxtBox.Location = new System.Drawing.Point(92, 43);
            this.GlReadCntTxtBox.Name = "GlReadCntTxtBox";
            this.GlReadCntTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlReadCntTxtBox.TabIndex = 1;
            // 
            // GlBodyHeadingTxtBox
            // 
            this.GlBodyHeadingTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlBodyHeadingTxtBox.Location = new System.Drawing.Point(92, 193);
            this.GlBodyHeadingTxtBox.Name = "GlBodyHeadingTxtBox";
            this.GlBodyHeadingTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlBodyHeadingTxtBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Read Count: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Azimuth: ";
            // 
            // GlElapsedTxtBox
            // 
            this.GlElapsedTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlElapsedTxtBox.Location = new System.Drawing.Point(836, 506);
            this.GlElapsedTxtBox.Name = "GlElapsedTxtBox";
            this.GlElapsedTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlElapsedTxtBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(750, 509);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Elapsed Time: ";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Yellow;
            this.ExitButton.Location = new System.Drawing.Point(12, 536);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(936, 23);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "CLOSE FORM";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.GlSaveStateTxtBox);
            this.groupBox3.Controls.Add(this.GlSaveDataCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(744, 428);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 72);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save data";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "Save State: ";
            // 
            // GlSaveStateTxtBox
            // 
            this.GlSaveStateTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlSaveStateTxtBox.Location = new System.Drawing.Point(92, 43);
            this.GlSaveStateTxtBox.Name = "GlSaveStateTxtBox";
            this.GlSaveStateTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlSaveStateTxtBox.TabIndex = 1;
            // 
            // GlSaveDataCheckBox
            // 
            this.GlSaveDataCheckBox.AutoSize = true;
            this.GlSaveDataCheckBox.Location = new System.Drawing.Point(6, 20);
            this.GlSaveDataCheckBox.Name = "GlSaveDataCheckBox";
            this.GlSaveDataCheckBox.Size = new System.Drawing.Size(143, 16);
            this.GlSaveDataCheckBox.TabIndex = 0;
            this.GlSaveDataCheckBox.Text = "Is Save data to Txt file";
            this.GlSaveDataCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.GlHeaderRanHeadingTxtBox);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.GlRanStandDistanceTxtBox);
            this.groupBox4.Controls.Add(this.GlRanDistanceTxtBox);
            this.groupBox4.Controls.Add(this.GlRanHeadingTxtBox);
            this.groupBox4.Location = new System.Drawing.Point(744, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 123);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RANSAC Information";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 12);
            this.label13.TabIndex = 26;
            this.label13.Text = "Azimuth H2R:";
            // 
            // GlHeaderRanHeadingTxtBox
            // 
            this.GlHeaderRanHeadingTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlHeaderRanHeadingTxtBox.Location = new System.Drawing.Point(92, 93);
            this.GlHeaderRanHeadingTxtBox.Name = "GlHeaderRanHeadingTxtBox";
            this.GlHeaderRanHeadingTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlHeaderRanHeadingTxtBox.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 7;
            this.label17.Text = "Avg. H2R: ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 12);
            this.label16.TabIndex = 6;
            this.label16.Text = "Header2Ran: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 12);
            this.label15.TabIndex = 5;
            this.label15.Text = "Azimuth Ran: ";
            // 
            // GlRanStandDistanceTxtBox
            // 
            this.GlRanStandDistanceTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanStandDistanceTxtBox.Location = new System.Drawing.Point(92, 43);
            this.GlRanStandDistanceTxtBox.Name = "GlRanStandDistanceTxtBox";
            this.GlRanStandDistanceTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanStandDistanceTxtBox.TabIndex = 4;
            // 
            // GlRanDistanceTxtBox
            // 
            this.GlRanDistanceTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanDistanceTxtBox.Location = new System.Drawing.Point(92, 18);
            this.GlRanDistanceTxtBox.Name = "GlRanDistanceTxtBox";
            this.GlRanDistanceTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanDistanceTxtBox.TabIndex = 3;
            // 
            // GlRanHeadingTxtBox
            // 
            this.GlRanHeadingTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlRanHeadingTxtBox.Location = new System.Drawing.Point(92, 68);
            this.GlRanHeadingTxtBox.Name = "GlRanHeadingTxtBox";
            this.GlRanHeadingTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlRanHeadingTxtBox.TabIndex = 2;
            // 
            // GlGpsHeadingTxtBox
            // 
            this.GlGpsHeadingTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlGpsHeadingTxtBox.Location = new System.Drawing.Point(90, 43);
            this.GlGpsHeadingTxtBox.Name = "GlGpsHeadingTxtBox";
            this.GlGpsHeadingTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlGpsHeadingTxtBox.TabIndex = 24;
            // 
            // GlHstCmdTxtBox
            // 
            this.GlHstCmdTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlHstCmdTxtBox.Location = new System.Drawing.Point(90, 68);
            this.GlHstCmdTxtBox.Name = "GlHstCmdTxtBox";
            this.GlHstCmdTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlHstCmdTxtBox.TabIndex = 20;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 71);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 12);
            this.label22.TabIndex = 19;
            this.label22.Text = "HST Cmd: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 12);
            this.label12.TabIndex = 23;
            this.label12.Text = "Azimuth GPS: ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(4, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 12);
            this.label21.TabIndex = 18;
            this.label21.Text = "Operation: ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 17;
            this.label20.Text = "Steer Cmd: ";
            // 
            // GlGpsDistanceTxtBox
            // 
            this.GlGpsDistanceTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlGpsDistanceTxtBox.Location = new System.Drawing.Point(90, 18);
            this.GlGpsDistanceTxtBox.Name = "GlGpsDistanceTxtBox";
            this.GlGpsDistanceTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlGpsDistanceTxtBox.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "IdealPath2Gps: ";
            // 
            // GlSteerOperationTxtBox
            // 
            this.GlSteerOperationTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlSteerOperationTxtBox.Location = new System.Drawing.Point(90, 43);
            this.GlSteerOperationTxtBox.Name = "GlSteerOperationTxtBox";
            this.GlSteerOperationTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlSteerOperationTxtBox.TabIndex = 16;
            // 
            // GlSteerCmdTxtBox
            // 
            this.GlSteerCmdTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlSteerCmdTxtBox.Location = new System.Drawing.Point(90, 18);
            this.GlSteerCmdTxtBox.Name = "GlSteerCmdTxtBox";
            this.GlSteerCmdTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlSteerCmdTxtBox.TabIndex = 15;
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
            this.groupBox5.Location = new System.Drawing.Point(534, 273);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(204, 100);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RANSAC State";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.GlHeaderAvgGndHgtTxtBox);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.GlHeaderEndDistanceTxtBox);
            this.groupBox6.Controls.Add(this.GlHeaderStartDistanceTxtBox);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.GlHeaderPoteniometerTxtBox);
            this.groupBox6.Location = new System.Drawing.Point(534, 379);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(204, 121);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Header State";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(7, 96);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(75, 12);
            this.label29.TabIndex = 7;
            this.label29.Text = "Avg. GndHgt: ";
            // 
            // GlHeaderAvgGndHgtTxtBox
            // 
            this.GlHeaderAvgGndHgtTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlHeaderAvgGndHgtTxtBox.Location = new System.Drawing.Point(92, 93);
            this.GlHeaderAvgGndHgtTxtBox.Name = "GlHeaderAvgGndHgtTxtBox";
            this.GlHeaderAvgGndHgtTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlHeaderAvgGndHgtTxtBox.TabIndex = 6;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 71);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(55, 12);
            this.label28.TabIndex = 5;
            this.label28.Text = "End Dist: ";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(7, 46);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 12);
            this.label27.TabIndex = 4;
            this.label27.Text = "Start Dist: ";
            // 
            // GlHeaderEndDistanceTxtBox
            // 
            this.GlHeaderEndDistanceTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlHeaderEndDistanceTxtBox.Location = new System.Drawing.Point(92, 68);
            this.GlHeaderEndDistanceTxtBox.Name = "GlHeaderEndDistanceTxtBox";
            this.GlHeaderEndDistanceTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlHeaderEndDistanceTxtBox.TabIndex = 3;
            // 
            // GlHeaderStartDistanceTxtBox
            // 
            this.GlHeaderStartDistanceTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlHeaderStartDistanceTxtBox.Location = new System.Drawing.Point(92, 43);
            this.GlHeaderStartDistanceTxtBox.Name = "GlHeaderStartDistanceTxtBox";
            this.GlHeaderStartDistanceTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlHeaderStartDistanceTxtBox.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 12);
            this.label23.TabIndex = 1;
            this.label23.Text = "Potentiometer: ";
            // 
            // GlHeaderPoteniometerTxtBox
            // 
            this.GlHeaderPoteniometerTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlHeaderPoteniometerTxtBox.Location = new System.Drawing.Point(92, 18);
            this.GlHeaderPoteniometerTxtBox.Name = "GlHeaderPoteniometerTxtBox";
            this.GlHeaderPoteniometerTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlHeaderPoteniometerTxtBox.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(516, 518);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.glControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(508, 492);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "3D map using OpenGL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.zgc1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(508, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Traceability";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // zgc1
            // 
            this.zgc1.Location = new System.Drawing.Point(6, 6);
            this.zgc1.Name = "zgc1";
            this.zgc1.ScrollGrace = 0D;
            this.zgc1.ScrollMaxX = 0D;
            this.zgc1.ScrollMaxY = 0D;
            this.zgc1.ScrollMaxY2 = 0D;
            this.zgc1.ScrollMinX = 0D;
            this.zgc1.ScrollMinY = 0D;
            this.zgc1.ScrollMinY2 = 0D;
            this.zgc1.Size = new System.Drawing.Size(496, 480);
            this.zgc1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.GlHarvestDistanceTxtBox);
            this.groupBox1.Controls.Add(this.GlHarvestTimesTxtBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(744, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 69);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Harvest State";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 46);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 12);
            this.label24.TabIndex = 3;
            this.label24.Text = "Distance: ";
            // 
            // GlHarvestDistanceTxtBox
            // 
            this.GlHarvestDistanceTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlHarvestDistanceTxtBox.Location = new System.Drawing.Point(92, 43);
            this.GlHarvestDistanceTxtBox.Name = "GlHarvestDistanceTxtBox";
            this.GlHarvestDistanceTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlHarvestDistanceTxtBox.TabIndex = 2;
            // 
            // GlHarvestTimesTxtBox
            // 
            this.GlHarvestTimesTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlHarvestTimesTxtBox.Location = new System.Drawing.Point(92, 18);
            this.GlHarvestTimesTxtBox.Name = "GlHarvestTimesTxtBox";
            this.GlHarvestTimesTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlHarvestTimesTxtBox.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "Harvest Times: ";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.GlIdealHeadingTxtBox);
            this.groupBox7.Controls.Add(this.GlGpsDistanceTxtBox);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.GlGpsHeadingTxtBox);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Location = new System.Drawing.Point(744, 141);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(204, 100);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Ideal Path Information";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 71);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 12);
            this.label25.TabIndex = 26;
            this.label25.Text = "Azimuth Ideal: ";
            // 
            // GlIdealHeadingTxtBox
            // 
            this.GlIdealHeadingTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlIdealHeadingTxtBox.Location = new System.Drawing.Point(90, 68);
            this.GlIdealHeadingTxtBox.Name = "GlIdealHeadingTxtBox";
            this.GlIdealHeadingTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlIdealHeadingTxtBox.TabIndex = 25;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.GlSteerCmdTxtBox);
            this.groupBox8.Controls.Add(this.GlSteerOperationTxtBox);
            this.groupBox8.Controls.Add(this.GlHstCmdTxtBox);
            this.groupBox8.Controls.Add(this.label20);
            this.groupBox8.Controls.Add(this.label22);
            this.groupBox8.Controls.Add(this.label21);
            this.groupBox8.Location = new System.Drawing.Point(744, 247);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(204, 100);
            this.groupBox8.TabIndex = 17;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Steering State";
            // 
            // GlBodyHeaderPotentiometerTxtBox
            // 
            this.GlBodyHeaderPotentiometerTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GlBodyHeaderPotentiometerTxtBox.Location = new System.Drawing.Point(92, 218);
            this.GlBodyHeaderPotentiometerTxtBox.Name = "GlBodyHeaderPotentiometerTxtBox";
            this.GlBodyHeaderPotentiometerTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlBodyHeaderPotentiometerTxtBox.TabIndex = 19;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 221);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 12);
            this.label30.TabIndex = 18;
            this.label30.Text = "Header: ";
            // 
            // LidarOpenGlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 567);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GlElapsedTxtBox);
            this.Controls.Add(this.label6);
            this.Name = "LidarOpenGlForm";
            this.Text = "3D terrain map (using LRF, RTK-GPS, GPS compass )";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
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
        private System.Windows.Forms.GroupBox groupBox3;
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
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox GlHeaderPoteniometerTxtBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl zgc1;
        private System.Windows.Forms.CheckBox GlSaveDataCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox GlSaveStateTxtBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox GlHarvestTimesTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox GlGpsDistanceTxtBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox GlGpsHeadingTxtBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox GlHeaderRanHeadingTxtBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox GlHarvestDistanceTxtBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox GlIdealHeadingTxtBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox GlAutoModeTxtBox;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox GlHeaderEndDistanceTxtBox;
        private System.Windows.Forms.TextBox GlHeaderStartDistanceTxtBox;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox GlHeaderAvgGndHgtTxtBox;
        private System.Windows.Forms.TextBox GlBodyHeaderPotentiometerTxtBox;
        private System.Windows.Forms.Label label30;
    }
}