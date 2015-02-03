namespace Display
{
    partial class PanasonicLidarForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SerialDatabitsTxtBox = new System.Windows.Forms.TextBox();
            this.SerialBaudrateTxtBox = new System.Windows.Forms.TextBox();
            this.SerialPortTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.DebugTxtBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.FileIoCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.OneLineScanButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ScanModeComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DebugTickTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DebugFreqTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DebugAmaxTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DebugAminTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.zgcCartesianXZ = new ZedGraph.ZedGraphControl();
            this.zgcCartesianXY = new ZedGraph.ZedGraphControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.zgcLine2 = new ZedGraph.ZedGraphControl();
            this.zgcLine1 = new ZedGraph.ZedGraphControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ScanButton = new System.Windows.Forms.Button();
            this.zgcLine3 = new ZedGraph.ZedGraphControl();
            this.zgcLine4 = new ZedGraph.ZedGraphControl();
            this.zgcLine5 = new ZedGraph.ZedGraphControl();
            this.zgcLine6 = new ZedGraph.ZedGraphControl();
            this.zgcLine11 = new ZedGraph.ZedGraphControl();
            this.zgcLine10 = new ZedGraph.ZedGraphControl();
            this.zgcLine9 = new ZedGraph.ZedGraphControl();
            this.zgcLine8 = new ZedGraph.ZedGraphControl();
            this.zgcLine7 = new ZedGraph.ZedGraphControl();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SerialDatabitsTxtBox);
            this.groupBox1.Controls.Add(this.SerialBaudrateTxtBox);
            this.groupBox1.Controls.Add(this.SerialPortTxtBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial communication";
            // 
            // SerialDatabitsTxtBox
            // 
            this.SerialDatabitsTxtBox.BackColor = System.Drawing.Color.Yellow;
            this.SerialDatabitsTxtBox.Location = new System.Drawing.Point(94, 78);
            this.SerialDatabitsTxtBox.Name = "SerialDatabitsTxtBox";
            this.SerialDatabitsTxtBox.Size = new System.Drawing.Size(100, 19);
            this.SerialDatabitsTxtBox.TabIndex = 5;
            this.SerialDatabitsTxtBox.Text = "8";
            // 
            // SerialBaudrateTxtBox
            // 
            this.SerialBaudrateTxtBox.BackColor = System.Drawing.Color.Yellow;
            this.SerialBaudrateTxtBox.Location = new System.Drawing.Point(94, 53);
            this.SerialBaudrateTxtBox.Name = "SerialBaudrateTxtBox";
            this.SerialBaudrateTxtBox.Size = new System.Drawing.Size(100, 19);
            this.SerialBaudrateTxtBox.TabIndex = 4;
            this.SerialBaudrateTxtBox.Text = "115200";
            // 
            // SerialPortTxtBox
            // 
            this.SerialPortTxtBox.BackColor = System.Drawing.Color.Yellow;
            this.SerialPortTxtBox.Location = new System.Drawing.Point(94, 28);
            this.SerialPortTxtBox.Name = "SerialPortTxtBox";
            this.SerialPortTxtBox.Size = new System.Drawing.Size(100, 19);
            this.SerialPortTxtBox.TabIndex = 1;
            this.SerialPortTxtBox.Text = "COM10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "DataBits: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "BaudRate: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port: ";
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.Color.Yellow;
            this.ConnectButton.Location = new System.Drawing.Point(12, 693);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(250, 23);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "[1] Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.BackColor = System.Drawing.Color.Yellow;
            this.DisconnectButton.Location = new System.Drawing.Point(524, 693);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(250, 23);
            this.DisconnectButton.TabIndex = 2;
            this.DisconnectButton.Text = "[3] Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = false;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // DebugTxtBox
            // 
            this.DebugTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.DebugTxtBox.Location = new System.Drawing.Point(6, 18);
            this.DebugTxtBox.Name = "DebugTxtBox";
            this.DebugTxtBox.Size = new System.Drawing.Size(336, 186);
            this.DebugTxtBox.TabIndex = 3;
            this.DebugTxtBox.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(940, 675);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.OneLineScanButton);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(932, 615);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Setting";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.FileIoCheckListBox);
            this.groupBox4.Location = new System.Drawing.Point(6, 216);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 64);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File IO";
            // 
            // FileIoCheckListBox
            // 
            this.FileIoCheckListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileIoCheckListBox.FormattingEnabled = true;
            this.FileIoCheckListBox.Items.AddRange(new object[] {
            "Read",
            "Save "});
            this.FileIoCheckListBox.Location = new System.Drawing.Point(6, 27);
            this.FileIoCheckListBox.Name = "FileIoCheckListBox";
            this.FileIoCheckListBox.Size = new System.Drawing.Size(188, 28);
            this.FileIoCheckListBox.TabIndex = 7;
            // 
            // OneLineScanButton
            // 
            this.OneLineScanButton.BackColor = System.Drawing.Color.Yellow;
            this.OneLineScanButton.Location = new System.Drawing.Point(212, 286);
            this.OneLineScanButton.Name = "OneLineScanButton";
            this.OneLineScanButton.Size = new System.Drawing.Size(75, 23);
            this.OneLineScanButton.TabIndex = 5;
            this.OneLineScanButton.Text = "1 Line Scan";
            this.OneLineScanButton.UseVisualStyleBackColor = false;
            this.OneLineScanButton.Click += new System.EventHandler(this.OneLineScanButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.ScanModeComboBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 83);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LRF Setting";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Scan mode:";
            // 
            // ScanModeComboBox
            // 
            this.ScanModeComboBox.BackColor = System.Drawing.Color.Yellow;
            this.ScanModeComboBox.FormattingEnabled = true;
            this.ScanModeComboBox.Items.AddRange(new object[] {
            "Single(1 line, 0 deg)",
            "Dual Mode(2 line, 5 deg)",
            "Dual Mode(2 line, 10 deg)",
            "Dual Mode(2 line, 20 deg)",
            "Multi Mode(11 line, 5 deg)",
            "Multi Mode(11 line, 10 deg)",
            "Multi Mode(11 line, 20 deg)"});
            this.ScanModeComboBox.Location = new System.Drawing.Point(6, 46);
            this.ScanModeComboBox.Name = "ScanModeComboBox";
            this.ScanModeComboBox.Size = new System.Drawing.Size(188, 20);
            this.ScanModeComboBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DebugTickTxtBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.DebugFreqTxtBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.DebugAmaxTxtBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.DebugAminTxtBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.DebugTxtBox);
            this.groupBox2.Location = new System.Drawing.Point(212, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 274);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Received Message";
            // 
            // DebugTickTxtBox
            // 
            this.DebugTickTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.DebugTickTxtBox.Location = new System.Drawing.Point(242, 221);
            this.DebugTickTxtBox.Name = "DebugTickTxtBox";
            this.DebugTickTxtBox.Size = new System.Drawing.Size(100, 19);
            this.DebugTickTxtBox.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tick: ";
            // 
            // DebugFreqTxtBox
            // 
            this.DebugFreqTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.DebugFreqTxtBox.Location = new System.Drawing.Point(51, 221);
            this.DebugFreqTxtBox.Name = "DebugFreqTxtBox";
            this.DebugFreqTxtBox.Size = new System.Drawing.Size(100, 19);
            this.DebugFreqTxtBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "Freq: ";
            // 
            // DebugAmaxTxtBox
            // 
            this.DebugAmaxTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.DebugAmaxTxtBox.Location = new System.Drawing.Point(242, 246);
            this.DebugAmaxTxtBox.Name = "DebugAmaxTxtBox";
            this.DebugAmaxTxtBox.Size = new System.Drawing.Size(100, 19);
            this.DebugAmaxTxtBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "AMAX: ";
            // 
            // DebugAminTxtBox
            // 
            this.DebugAminTxtBox.BackColor = System.Drawing.Color.GreenYellow;
            this.DebugAminTxtBox.Location = new System.Drawing.Point(51, 246);
            this.DebugAminTxtBox.Name = "DebugAminTxtBox";
            this.DebugAminTxtBox.Size = new System.Drawing.Size(100, 19);
            this.DebugAminTxtBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "AMIN: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.zgcCartesianXZ);
            this.tabPage2.Controls.Add(this.zgcCartesianXY);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(932, 615);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cartesian Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // zgcCartesianXZ
            // 
            this.zgcCartesianXZ.Location = new System.Drawing.Point(462, 6);
            this.zgcCartesianXZ.Name = "zgcCartesianXZ";
            this.zgcCartesianXZ.ScrollGrace = 0D;
            this.zgcCartesianXZ.ScrollMaxX = 0D;
            this.zgcCartesianXZ.ScrollMaxY = 0D;
            this.zgcCartesianXZ.ScrollMaxY2 = 0D;
            this.zgcCartesianXZ.ScrollMinX = 0D;
            this.zgcCartesianXZ.ScrollMinY = 0D;
            this.zgcCartesianXZ.ScrollMinY2 = 0D;
            this.zgcCartesianXZ.Size = new System.Drawing.Size(450, 450);
            this.zgcCartesianXZ.TabIndex = 1;
            // 
            // zgcCartesianXY
            // 
            this.zgcCartesianXY.Location = new System.Drawing.Point(6, 6);
            this.zgcCartesianXY.Name = "zgcCartesianXY";
            this.zgcCartesianXY.ScrollGrace = 0D;
            this.zgcCartesianXY.ScrollMaxX = 0D;
            this.zgcCartesianXY.ScrollMaxY = 0D;
            this.zgcCartesianXY.ScrollMaxY2 = 0D;
            this.zgcCartesianXY.ScrollMinX = 0D;
            this.zgcCartesianXY.ScrollMinY = 0D;
            this.zgcCartesianXY.ScrollMinY2 = 0D;
            this.zgcCartesianXY.Size = new System.Drawing.Size(450, 450);
            this.zgcCartesianXY.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.zgcLine7);
            this.tabPage3.Controls.Add(this.zgcLine11);
            this.tabPage3.Controls.Add(this.zgcLine10);
            this.tabPage3.Controls.Add(this.zgcLine9);
            this.tabPage3.Controls.Add(this.zgcLine8);
            this.tabPage3.Controls.Add(this.zgcLine6);
            this.tabPage3.Controls.Add(this.zgcLine5);
            this.tabPage3.Controls.Add(this.zgcLine4);
            this.tabPage3.Controls.Add(this.zgcLine3);
            this.tabPage3.Controls.Add(this.zgcLine2);
            this.tabPage3.Controls.Add(this.zgcLine1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(932, 649);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Raw Data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // zgcLine2
            // 
            this.zgcLine2.Location = new System.Drawing.Point(3, 109);
            this.zgcLine2.Name = "zgcLine2";
            this.zgcLine2.ScrollGrace = 0D;
            this.zgcLine2.ScrollMaxX = 0D;
            this.zgcLine2.ScrollMaxY = 0D;
            this.zgcLine2.ScrollMaxY2 = 0D;
            this.zgcLine2.ScrollMinX = 0D;
            this.zgcLine2.ScrollMinY = 0D;
            this.zgcLine2.ScrollMinY2 = 0D;
            this.zgcLine2.Size = new System.Drawing.Size(450, 100);
            this.zgcLine2.TabIndex = 1;
            // 
            // zgcLine1
            // 
            this.zgcLine1.Location = new System.Drawing.Point(3, 3);
            this.zgcLine1.Name = "zgcLine1";
            this.zgcLine1.ScrollGrace = 0D;
            this.zgcLine1.ScrollMaxX = 0D;
            this.zgcLine1.ScrollMaxY = 0D;
            this.zgcLine1.ScrollMaxY2 = 0D;
            this.zgcLine1.ScrollMinX = 0D;
            this.zgcLine1.ScrollMinY = 0D;
            this.zgcLine1.ScrollMinY2 = 0D;
            this.zgcLine1.Size = new System.Drawing.Size(450, 100);
            this.zgcLine1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel10});
            this.statusStrip1.Location = new System.Drawing.Point(0, 719);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(964, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel1.Text = "[1]Timer count: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel2.Text = "0000";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(106, 17);
            this.toolStripStatusLabel3.Text = "[2]Time Stamp: ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel4.Text = "0000";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(128, 17);
            this.toolStripStatusLabel5.Text = "[3]Processing Time: ";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel6.Text = "[ms]";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel7.Text = "[4]Date: ";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(73, 17);
            this.toolStripStatusLabel8.Text = "0000/00/00";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel9.Text = "[5]Timer Interval: ";
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel10.Text = "0000";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Yellow;
            this.ExitButton.Location = new System.Drawing.Point(780, 693);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(172, 23);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "[4] Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSV files|*.csv|All files|*.*";
            // 
            // ScanButton
            // 
            this.ScanButton.BackColor = System.Drawing.Color.Yellow;
            this.ScanButton.Location = new System.Drawing.Point(268, 693);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(250, 23);
            this.ScanButton.TabIndex = 7;
            this.ScanButton.Text = "[2] Scan";
            this.ScanButton.UseVisualStyleBackColor = false;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // zgcLine3
            // 
            this.zgcLine3.Location = new System.Drawing.Point(3, 215);
            this.zgcLine3.Name = "zgcLine3";
            this.zgcLine3.ScrollGrace = 0D;
            this.zgcLine3.ScrollMaxX = 0D;
            this.zgcLine3.ScrollMaxY = 0D;
            this.zgcLine3.ScrollMaxY2 = 0D;
            this.zgcLine3.ScrollMinX = 0D;
            this.zgcLine3.ScrollMinY = 0D;
            this.zgcLine3.ScrollMinY2 = 0D;
            this.zgcLine3.Size = new System.Drawing.Size(450, 100);
            this.zgcLine3.TabIndex = 2;
            // 
            // zgcLine4
            // 
            this.zgcLine4.Location = new System.Drawing.Point(3, 321);
            this.zgcLine4.Name = "zgcLine4";
            this.zgcLine4.ScrollGrace = 0D;
            this.zgcLine4.ScrollMaxX = 0D;
            this.zgcLine4.ScrollMaxY = 0D;
            this.zgcLine4.ScrollMaxY2 = 0D;
            this.zgcLine4.ScrollMinX = 0D;
            this.zgcLine4.ScrollMinY = 0D;
            this.zgcLine4.ScrollMinY2 = 0D;
            this.zgcLine4.Size = new System.Drawing.Size(450, 100);
            this.zgcLine4.TabIndex = 3;
            // 
            // zgcLine5
            // 
            this.zgcLine5.Location = new System.Drawing.Point(3, 427);
            this.zgcLine5.Name = "zgcLine5";
            this.zgcLine5.ScrollGrace = 0D;
            this.zgcLine5.ScrollMaxX = 0D;
            this.zgcLine5.ScrollMaxY = 0D;
            this.zgcLine5.ScrollMaxY2 = 0D;
            this.zgcLine5.ScrollMinX = 0D;
            this.zgcLine5.ScrollMinY = 0D;
            this.zgcLine5.ScrollMinY2 = 0D;
            this.zgcLine5.Size = new System.Drawing.Size(450, 100);
            this.zgcLine5.TabIndex = 4;
            // 
            // zgcLine6
            // 
            this.zgcLine6.Location = new System.Drawing.Point(3, 533);
            this.zgcLine6.Name = "zgcLine6";
            this.zgcLine6.ScrollGrace = 0D;
            this.zgcLine6.ScrollMaxX = 0D;
            this.zgcLine6.ScrollMaxY = 0D;
            this.zgcLine6.ScrollMaxY2 = 0D;
            this.zgcLine6.ScrollMinX = 0D;
            this.zgcLine6.ScrollMinY = 0D;
            this.zgcLine6.ScrollMinY2 = 0D;
            this.zgcLine6.Size = new System.Drawing.Size(450, 100);
            this.zgcLine6.TabIndex = 5;
            // 
            // zgcLine11
            // 
            this.zgcLine11.Location = new System.Drawing.Point(459, 427);
            this.zgcLine11.Name = "zgcLine11";
            this.zgcLine11.ScrollGrace = 0D;
            this.zgcLine11.ScrollMaxX = 0D;
            this.zgcLine11.ScrollMaxY = 0D;
            this.zgcLine11.ScrollMaxY2 = 0D;
            this.zgcLine11.ScrollMinX = 0D;
            this.zgcLine11.ScrollMinY = 0D;
            this.zgcLine11.ScrollMinY2 = 0D;
            this.zgcLine11.Size = new System.Drawing.Size(450, 100);
            this.zgcLine11.TabIndex = 9;
            // 
            // zgcLine10
            // 
            this.zgcLine10.Location = new System.Drawing.Point(459, 321);
            this.zgcLine10.Name = "zgcLine10";
            this.zgcLine10.ScrollGrace = 0D;
            this.zgcLine10.ScrollMaxX = 0D;
            this.zgcLine10.ScrollMaxY = 0D;
            this.zgcLine10.ScrollMaxY2 = 0D;
            this.zgcLine10.ScrollMinX = 0D;
            this.zgcLine10.ScrollMinY = 0D;
            this.zgcLine10.ScrollMinY2 = 0D;
            this.zgcLine10.Size = new System.Drawing.Size(450, 100);
            this.zgcLine10.TabIndex = 8;
            // 
            // zgcLine9
            // 
            this.zgcLine9.Location = new System.Drawing.Point(459, 215);
            this.zgcLine9.Name = "zgcLine9";
            this.zgcLine9.ScrollGrace = 0D;
            this.zgcLine9.ScrollMaxX = 0D;
            this.zgcLine9.ScrollMaxY = 0D;
            this.zgcLine9.ScrollMaxY2 = 0D;
            this.zgcLine9.ScrollMinX = 0D;
            this.zgcLine9.ScrollMinY = 0D;
            this.zgcLine9.ScrollMinY2 = 0D;
            this.zgcLine9.Size = new System.Drawing.Size(450, 100);
            this.zgcLine9.TabIndex = 7;
            // 
            // zgcLine8
            // 
            this.zgcLine8.Location = new System.Drawing.Point(459, 109);
            this.zgcLine8.Name = "zgcLine8";
            this.zgcLine8.ScrollGrace = 0D;
            this.zgcLine8.ScrollMaxX = 0D;
            this.zgcLine8.ScrollMaxY = 0D;
            this.zgcLine8.ScrollMaxY2 = 0D;
            this.zgcLine8.ScrollMinX = 0D;
            this.zgcLine8.ScrollMinY = 0D;
            this.zgcLine8.ScrollMinY2 = 0D;
            this.zgcLine8.Size = new System.Drawing.Size(450, 100);
            this.zgcLine8.TabIndex = 6;
            // 
            // zgcLine7
            // 
            this.zgcLine7.Location = new System.Drawing.Point(459, 3);
            this.zgcLine7.Name = "zgcLine7";
            this.zgcLine7.ScrollGrace = 0D;
            this.zgcLine7.ScrollMaxX = 0D;
            this.zgcLine7.ScrollMaxY = 0D;
            this.zgcLine7.ScrollMaxY2 = 0D;
            this.zgcLine7.ScrollMinX = 0D;
            this.zgcLine7.ScrollMinY = 0D;
            this.zgcLine7.ScrollMinY2 = 0D;
            this.zgcLine7.Size = new System.Drawing.Size(450, 100);
            this.zgcLine7.TabIndex = 10;
            // 
            // PanasonicLidarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 741);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Name = "PanasonicLidarForm";
            this.Text = "Panasonic Laser Range Finder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SerialDatabitsTxtBox;
        private System.Windows.Forms.TextBox SerialBaudrateTxtBox;
        private System.Windows.Forms.TextBox SerialPortTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.RichTextBox DebugTxtBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ScanModeComboBox;
        private System.Windows.Forms.Button OneLineScanButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel10;
        private ZedGraph.ZedGraphControl zgcCartesianXZ;
        private ZedGraph.ZedGraphControl zgcCartesianXY;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox FileIoCheckListBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private ZedGraph.ZedGraphControl zgcLine2;
        private ZedGraph.ZedGraphControl zgcLine1;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.TextBox DebugAmaxTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DebugAminTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DebugFreqTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DebugTickTxtBox;
        private System.Windows.Forms.Label label8;
        private ZedGraph.ZedGraphControl zgcLine7;
        private ZedGraph.ZedGraphControl zgcLine11;
        private ZedGraph.ZedGraphControl zgcLine10;
        private ZedGraph.ZedGraphControl zgcLine9;
        private ZedGraph.ZedGraphControl zgcLine8;
        private ZedGraph.ZedGraphControl zgcLine6;
        private ZedGraph.ZedGraphControl zgcLine5;
        private ZedGraph.ZedGraphControl zgcLine4;
        private ZedGraph.ZedGraphControl zgcLine3;
    }
}