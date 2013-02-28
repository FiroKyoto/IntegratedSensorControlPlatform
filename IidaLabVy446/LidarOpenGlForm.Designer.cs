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
            this.label1 = new System.Windows.Forms.Label();
            this.GlReadCntTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GlCurCntTxtBox = new System.Windows.Forms.TextBox();
            this.GlTmXTxtBox = new System.Windows.Forms.TextBox();
            this.GlTmYTxtBox = new System.Windows.Forms.TextBox();
            this.GlTmZTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GlElapsedTxtBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox2.Controls.Add(this.GlElapsedTxtBox);
            this.groupBox2.Controls.Add(this.label6);
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
            this.groupBox2.Size = new System.Drawing.Size(204, 293);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Debug";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Read Count: ";
            // 
            // GlReadCntTxtBox
            // 
            this.GlReadCntTxtBox.Location = new System.Drawing.Point(92, 32);
            this.GlReadCntTxtBox.Name = "GlReadCntTxtBox";
            this.GlReadCntTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlReadCntTxtBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Crop Cnt: ";
            // 
            // GlCurCntTxtBox
            // 
            this.GlCurCntTxtBox.Location = new System.Drawing.Point(92, 57);
            this.GlCurCntTxtBox.Name = "GlCurCntTxtBox";
            this.GlCurCntTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlCurCntTxtBox.TabIndex = 3;
            // 
            // GlTmXTxtBox
            // 
            this.GlTmXTxtBox.Location = new System.Drawing.Point(92, 82);
            this.GlTmXTxtBox.Name = "GlTmXTxtBox";
            this.GlTmXTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmXTxtBox.TabIndex = 4;
            // 
            // GlTmYTxtBox
            // 
            this.GlTmYTxtBox.Location = new System.Drawing.Point(92, 107);
            this.GlTmYTxtBox.Name = "GlTmYTxtBox";
            this.GlTmYTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmYTxtBox.TabIndex = 5;
            // 
            // GlTmZTxtBox
            // 
            this.GlTmZTxtBox.Location = new System.Drawing.Point(92, 132);
            this.GlTmZTxtBox.Name = "GlTmZTxtBox";
            this.GlTmZTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlTmZTxtBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tm X: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tm Y: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tm Z: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Elapsed Time: ";
            // 
            // GlElapsedTxtBox
            // 
            this.GlElapsedTxtBox.Location = new System.Drawing.Point(92, 157);
            this.GlElapsedTxtBox.Name = "GlElapsedTxtBox";
            this.GlElapsedTxtBox.Size = new System.Drawing.Size(100, 19);
            this.GlElapsedTxtBox.TabIndex = 11;
            // 
            // LidarOpenGlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 555);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "LidarOpenGlForm";
            this.Text = "3D Crop Stand (with LRF and GPS)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
    }
}