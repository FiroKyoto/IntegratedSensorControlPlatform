namespace Display
{
    partial class ClientMap
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
            this.GraphTargetPath = new ZedGraph.ZedGraphControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GraphTargetPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 437);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target path";
            // 
            // GraphTargetPath
            // 
            this.GraphTargetPath.Location = new System.Drawing.Point(6, 18);
            this.GraphTargetPath.Name = "GraphTargetPath";
            this.GraphTargetPath.ScrollGrace = 0D;
            this.GraphTargetPath.ScrollMaxX = 0D;
            this.GraphTargetPath.ScrollMaxY = 0D;
            this.GraphTargetPath.ScrollMaxY2 = 0D;
            this.GraphTargetPath.ScrollMinX = 0D;
            this.GraphTargetPath.ScrollMinY = 0D;
            this.GraphTargetPath.ScrollMinY2 = 0D;
            this.GraphTargetPath.Size = new System.Drawing.Size(448, 413);
            this.GraphTargetPath.TabIndex = 0;
            // 
            // ClientMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClientMap";
            this.Text = "Client map";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ZedGraph.ZedGraphControl GraphTargetPath;
    }
}