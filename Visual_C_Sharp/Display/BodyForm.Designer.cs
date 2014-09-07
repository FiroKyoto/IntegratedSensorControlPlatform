namespace Display
{
    partial class BodyForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PortTxtBox = new System.Windows.Forms.TextBox();
            this.DataBitsTxtBox = new System.Windows.Forms.TextBox();
            this.BaudRateTxtBox = new System.Windows.Forms.TextBox();
            this.LogTxtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.IntervalTxtBox = new System.Windows.Forms.TextBox();
            this.BodyTimer = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "DataBits: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "BaudRate: ";
            // 
            // PortTxtBox
            // 
            this.PortTxtBox.Location = new System.Drawing.Point(89, 19);
            this.PortTxtBox.Name = "PortTxtBox";
            this.PortTxtBox.Size = new System.Drawing.Size(100, 19);
            this.PortTxtBox.TabIndex = 3;
            this.PortTxtBox.Text = "COM5";
            // 
            // DataBitsTxtBox
            // 
            this.DataBitsTxtBox.Location = new System.Drawing.Point(89, 44);
            this.DataBitsTxtBox.Name = "DataBitsTxtBox";
            this.DataBitsTxtBox.Size = new System.Drawing.Size(100, 19);
            this.DataBitsTxtBox.TabIndex = 4;
            this.DataBitsTxtBox.Text = "8";
            // 
            // BaudRateTxtBox
            // 
            this.BaudRateTxtBox.Location = new System.Drawing.Point(89, 73);
            this.BaudRateTxtBox.Name = "BaudRateTxtBox";
            this.BaudRateTxtBox.Size = new System.Drawing.Size(100, 19);
            this.BaudRateTxtBox.TabIndex = 5;
            this.BaudRateTxtBox.Text = "38400";
            // 
            // LogTxtBox
            // 
            this.LogTxtBox.Location = new System.Drawing.Point(207, 19);
            this.LogTxtBox.Multiline = true;
            this.LogTxtBox.Name = "LogTxtBox";
            this.LogTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTxtBox.Size = new System.Drawing.Size(278, 172);
            this.LogTxtBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(96, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Interval: ";
            // 
            // IntervalTxtBox
            // 
            this.IntervalTxtBox.Location = new System.Drawing.Point(89, 104);
            this.IntervalTxtBox.Name = "IntervalTxtBox";
            this.IntervalTxtBox.Size = new System.Drawing.Size(100, 19);
            this.IntervalTxtBox.TabIndex = 10;
            this.IntervalTxtBox.Text = "100";
            // 
            // BodyTimer
            // 
            this.BodyTimer.Tick += new System.EventHandler(this.BodyTimer_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Calculate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BodyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 272);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.IntervalTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LogTxtBox);
            this.Controls.Add(this.BaudRateTxtBox);
            this.Controls.Add(this.DataBitsTxtBox);
            this.Controls.Add(this.PortTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BodyForm";
            this.Text = "BodyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PortTxtBox;
        private System.Windows.Forms.TextBox DataBitsTxtBox;
        private System.Windows.Forms.TextBox BaudRateTxtBox;
        private System.Windows.Forms.TextBox LogTxtBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IntervalTxtBox;
        private System.Windows.Forms.Timer BodyTimer;
        private System.Windows.Forms.Button button3;
    }
}