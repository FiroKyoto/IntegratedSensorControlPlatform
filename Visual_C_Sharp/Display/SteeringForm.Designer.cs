namespace Display
{
    partial class SteeringForm
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
            this.Startbutton = new System.Windows.Forms.Button();
            this.LogTxtBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ControlTxtBox = new System.Windows.Forms.TextBox();
            this.RunControlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Startbutton
            // 
            this.Startbutton.BackColor = System.Drawing.Color.Yellow;
            this.Startbutton.Location = new System.Drawing.Point(12, 300);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(499, 23);
            this.Startbutton.TabIndex = 0;
            this.Startbutton.Text = "Start";
            this.Startbutton.UseVisualStyleBackColor = false;
            this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click);
            // 
            // LogTxtBox
            // 
            this.LogTxtBox.Location = new System.Drawing.Point(12, 12);
            this.LogTxtBox.Multiline = true;
            this.LogTxtBox.Name = "LogTxtBox";
            this.LogTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTxtBox.Size = new System.Drawing.Size(223, 168);
            this.LogTxtBox.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ControlTxtBox
            // 
            this.ControlTxtBox.Location = new System.Drawing.Point(241, 12);
            this.ControlTxtBox.Multiline = true;
            this.ControlTxtBox.Name = "ControlTxtBox";
            this.ControlTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ControlTxtBox.Size = new System.Drawing.Size(270, 168);
            this.ControlTxtBox.TabIndex = 2;
            // 
            // RunControlButton
            // 
            this.RunControlButton.Location = new System.Drawing.Point(12, 329);
            this.RunControlButton.Name = "RunControlButton";
            this.RunControlButton.Size = new System.Drawing.Size(499, 23);
            this.RunControlButton.TabIndex = 3;
            this.RunControlButton.Text = "Run Control Panel";
            this.RunControlButton.UseVisualStyleBackColor = true;
            this.RunControlButton.Click += new System.EventHandler(this.RunControlButton_Click);
            // 
            // SteeringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 372);
            this.Controls.Add(this.RunControlButton);
            this.Controls.Add(this.ControlTxtBox);
            this.Controls.Add(this.LogTxtBox);
            this.Controls.Add(this.Startbutton);
            this.Name = "SteeringForm";
            this.Text = "Logitech G27 Steering Wheel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Startbutton;
        private System.Windows.Forms.TextBox LogTxtBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox ControlTxtBox;
        private System.Windows.Forms.Button RunControlButton;
    }
}