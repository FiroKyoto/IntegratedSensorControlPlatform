namespace Display
{
    partial class DimagerForm
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
            this.pBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.InitImageDriverTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.SpeedmodeTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EndButton = new System.Windows.Forms.Button();
            this.FreeImageTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FreqModeTxtBox = new System.Windows.Forms.TextBox();
            this.IntervalTimeTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBoxIpl1
            // 
            this.pBoxIpl1.Location = new System.Drawing.Point(12, 12);
            this.pBoxIpl1.Name = "pBoxIpl1";
            this.pBoxIpl1.Size = new System.Drawing.Size(320, 240);
            this.pBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxIpl1.TabIndex = 0;
            this.pBoxIpl1.TabStop = false;
            // 
            // InitImageDriverTxtBox
            // 
            this.InitImageDriverTxtBox.BackColor = System.Drawing.Color.Yellow;
            this.InitImageDriverTxtBox.Location = new System.Drawing.Point(493, 12);
            this.InitImageDriverTxtBox.Name = "InitImageDriverTxtBox";
            this.InitImageDriverTxtBox.Size = new System.Drawing.Size(100, 19);
            this.InitImageDriverTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Initialize Image Driver:";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(437, 226);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 3;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // SpeedmodeTxtBox
            // 
            this.SpeedmodeTxtBox.BackColor = System.Drawing.Color.Yellow;
            this.SpeedmodeTxtBox.Location = new System.Drawing.Point(493, 37);
            this.SpeedmodeTxtBox.Name = "SpeedmodeTxtBox";
            this.SpeedmodeTxtBox.Size = new System.Drawing.Size(100, 19);
            this.SpeedmodeTxtBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Speedmode: ";
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(518, 226);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(75, 23);
            this.EndButton.TabIndex = 6;
            this.EndButton.Text = "End";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // FreeImageTxtBox
            // 
            this.FreeImageTxtBox.BackColor = System.Drawing.Color.Yellow;
            this.FreeImageTxtBox.Location = new System.Drawing.Point(493, 201);
            this.FreeImageTxtBox.Name = "FreeImageTxtBox";
            this.FreeImageTxtBox.Size = new System.Drawing.Size(100, 19);
            this.FreeImageTxtBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Free Image: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Freqmode: ";
            // 
            // FreqModeTxtBox
            // 
            this.FreqModeTxtBox.BackColor = System.Drawing.Color.Yellow;
            this.FreqModeTxtBox.Location = new System.Drawing.Point(493, 62);
            this.FreqModeTxtBox.Name = "FreqModeTxtBox";
            this.FreqModeTxtBox.Size = new System.Drawing.Size(100, 19);
            this.FreqModeTxtBox.TabIndex = 10;
            // 
            // IntervalTimeTxtBox
            // 
            this.IntervalTimeTxtBox.BackColor = System.Drawing.Color.YellowGreen;
            this.IntervalTimeTxtBox.Location = new System.Drawing.Point(493, 176);
            this.IntervalTimeTxtBox.Name = "IntervalTimeTxtBox";
            this.IntervalTimeTxtBox.Size = new System.Drawing.Size(100, 19);
            this.IntervalTimeTxtBox.TabIndex = 11;
            this.IntervalTimeTxtBox.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Interval: ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 276);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(605, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(94, 17);
            this.toolStripStatusLabel1.Text = "Elapsed Time: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel2.Text = "milliseconds";
            // 
            // DimagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 298);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IntervalTimeTxtBox);
            this.Controls.Add(this.FreqModeTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FreeImageTxtBox);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SpeedmodeTxtBox);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InitImageDriverTxtBox);
            this.Controls.Add(this.pBoxIpl1);
            this.Name = "DimagerForm";
            this.Text = "DimagerForm";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pBoxIpl1;
        private System.Windows.Forms.TextBox InitImageDriverTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.TextBox SpeedmodeTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.TextBox FreeImageTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FreqModeTxtBox;
        private System.Windows.Forms.TextBox IntervalTimeTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}