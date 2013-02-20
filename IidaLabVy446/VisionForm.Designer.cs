namespace IidaLabVy446
{
    partial class VisionForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ReadAviCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveAviCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IntervalTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MachineVisionTimer = new System.Windows.Forms.Timer(this.components);
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ZgcGraph1 = new ZedGraph.ZedGraphControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CutEdgeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ImageFlipCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.pBoxIpl3 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.pBoxIpl2 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.pBoxIpl4 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.SaveButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl3)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl2)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl4)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1032, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(127, 17);
            this.toolStripStatusLabel1.Text = "Total Elapsed Time: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel2.Text = "milliseconds";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel5.Text = "Read Count: ";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel6.Text = "cnt";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(107, 17);
            this.toolStripStatusLabel3.Text = "Debug Message: ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel4.Text = "Message";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pBoxIpl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 264);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capture";
            // 
            // pBoxIpl1
            // 
            this.pBoxIpl1.Location = new System.Drawing.Point(6, 18);
            this.pBoxIpl1.Name = "pBoxIpl1";
            this.pBoxIpl1.Size = new System.Drawing.Size(320, 240);
            this.pBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxIpl1.TabIndex = 0;
            this.pBoxIpl1.TabStop = false;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(688, 522);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReadAviCheckBox);
            this.groupBox2.Controls.Add(this.SaveAviCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(866, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 44);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File I/O";
            // 
            // ReadAviCheckBox
            // 
            this.ReadAviCheckBox.AutoSize = true;
            this.ReadAviCheckBox.Location = new System.Drawing.Point(61, 18);
            this.ReadAviCheckBox.Name = "ReadAviCheckBox";
            this.ReadAviCheckBox.Size = new System.Drawing.Size(50, 16);
            this.ReadAviCheckBox.TabIndex = 1;
            this.ReadAviCheckBox.Text = "Read";
            this.ReadAviCheckBox.UseVisualStyleBackColor = true;
            // 
            // SaveAviCheckBox
            // 
            this.SaveAviCheckBox.AutoSize = true;
            this.SaveAviCheckBox.Location = new System.Drawing.Point(6, 18);
            this.SaveAviCheckBox.Name = "SaveAviCheckBox";
            this.SaveAviCheckBox.Size = new System.Drawing.Size(49, 16);
            this.SaveAviCheckBox.TabIndex = 0;
            this.SaveAviCheckBox.Text = "Save";
            this.SaveAviCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.IntervalTxtBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(688, 282);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 45);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Setting";
            // 
            // IntervalTxtBox
            // 
            this.IntervalTxtBox.Location = new System.Drawing.Point(61, 15);
            this.IntervalTxtBox.Name = "IntervalTxtBox";
            this.IntervalTxtBox.Size = new System.Drawing.Size(100, 19);
            this.IntervalTxtBox.TabIndex = 1;
            this.IntervalTxtBox.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interval: ";
            // 
            // MachineVisionTimer
            // 
            this.MachineVisionTimer.Tick += new System.EventHandler(this.MachineVisionTimer_Tick);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(769, 522);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 6;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(946, 522);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ZgcGraph1
            // 
            this.ZgcGraph1.Location = new System.Drawing.Point(6, 18);
            this.ZgcGraph1.Name = "ZgcGraph1";
            this.ZgcGraph1.ScrollGrace = 0D;
            this.ZgcGraph1.ScrollMaxX = 0D;
            this.ZgcGraph1.ScrollMaxY = 0D;
            this.ZgcGraph1.ScrollMaxY2 = 0D;
            this.ZgcGraph1.ScrollMinX = 0D;
            this.ZgcGraph1.ScrollMinY = 0D;
            this.ZgcGraph1.ScrollMinY2 = 0D;
            this.ZgcGraph1.Size = new System.Drawing.Size(320, 240);
            this.ZgcGraph1.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ZgcGraph1);
            this.groupBox4.Location = new System.Drawing.Point(688, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(333, 264);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Histogram";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CutEdgeCheckBox);
            this.groupBox5.Location = new System.Drawing.Point(688, 333);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(172, 44);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Algorithm";
            // 
            // CutEdgeCheckBox
            // 
            this.CutEdgeCheckBox.AutoSize = true;
            this.CutEdgeCheckBox.Location = new System.Drawing.Point(8, 18);
            this.CutEdgeCheckBox.Name = "CutEdgeCheckBox";
            this.CutEdgeCheckBox.Size = new System.Drawing.Size(86, 16);
            this.CutEdgeCheckBox.TabIndex = 0;
            this.CutEdgeCheckBox.Text = "Is Cut-Edge";
            this.CutEdgeCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ImageFlipCheckBox);
            this.groupBox6.Location = new System.Drawing.Point(866, 333);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(155, 44);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Image Flip";
            // 
            // ImageFlipCheckBox
            // 
            this.ImageFlipCheckBox.AutoSize = true;
            this.ImageFlipCheckBox.Location = new System.Drawing.Point(8, 18);
            this.ImageFlipCheckBox.Name = "ImageFlipCheckBox";
            this.ImageFlipCheckBox.Size = new System.Drawing.Size(56, 16);
            this.ImageFlipCheckBox.TabIndex = 0;
            this.ImageFlipCheckBox.Text = "Is Flip";
            this.ImageFlipCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.pBoxIpl3);
            this.groupBox7.Location = new System.Drawing.Point(12, 282);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(332, 263);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Normalization Scheme";
            // 
            // pBoxIpl3
            // 
            this.pBoxIpl3.Location = new System.Drawing.Point(6, 18);
            this.pBoxIpl3.Name = "pBoxIpl3";
            this.pBoxIpl3.Size = new System.Drawing.Size(320, 240);
            this.pBoxIpl3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxIpl3.TabIndex = 13;
            this.pBoxIpl3.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Location = new System.Drawing.Point(688, 383);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(333, 133);
            this.groupBox8.TabIndex = 13;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Debug";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(112, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(150, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Lateral Offset: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lateral Threshold: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "milliseconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Elapsed Time: ";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.pBoxIpl2);
            this.groupBox9.Location = new System.Drawing.Point(350, 12);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(332, 264);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Inverse Perspective Mapping";
            // 
            // pBoxIpl2
            // 
            this.pBoxIpl2.Location = new System.Drawing.Point(6, 18);
            this.pBoxIpl2.Name = "pBoxIpl2";
            this.pBoxIpl2.Size = new System.Drawing.Size(320, 240);
            this.pBoxIpl2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxIpl2.TabIndex = 0;
            this.pBoxIpl2.TabStop = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.pBoxIpl4);
            this.groupBox10.Location = new System.Drawing.Point(350, 282);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(332, 263);
            this.groupBox10.TabIndex = 14;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Result";
            // 
            // pBoxIpl4
            // 
            this.pBoxIpl4.Location = new System.Drawing.Point(6, 18);
            this.pBoxIpl4.Name = "pBoxIpl4";
            this.pBoxIpl4.Size = new System.Drawing.Size(320, 240);
            this.pBoxIpl4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxIpl4.TabIndex = 13;
            this.pBoxIpl4.TabStop = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(850, 522);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save Data";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // VisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 579);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "VisionForm";
            this.Text = "VisionForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl3)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl2)).EndInit();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private OpenCvSharp.UserInterface.PictureBoxIpl pBoxIpl1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ReadAviCheckBox;
        private System.Windows.Forms.CheckBox SaveAviCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox IntervalTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer MachineVisionTimer;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button ExitButton;
        private ZedGraph.ZedGraphControl ZgcGraph1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox CutEdgeCheckBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox ImageFlipCheckBox;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.GroupBox groupBox7;
        private OpenCvSharp.UserInterface.PictureBoxIpl pBoxIpl3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox9;
        private OpenCvSharp.UserInterface.PictureBoxIpl pBoxIpl2;
        private System.Windows.Forms.GroupBox groupBox10;
        private OpenCvSharp.UserInterface.PictureBoxIpl pBoxIpl4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SaveButton;
    }
}