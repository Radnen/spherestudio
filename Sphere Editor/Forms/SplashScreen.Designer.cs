namespace Sphere_Editor.Forms
{
    partial class SplashScreen
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
            this.StatusLabel = new System.Windows.Forms.Label();
            this.OpacityTimer = new System.Windows.Forms.Timer(this.components);
            this.VersionLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.Black;
            this.StatusLabel.Location = new System.Drawing.Point(12, 248);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(193, 40);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Loading... 0%";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpacityTimer
            // 
            this.OpacityTimer.Interval = 25;
            this.OpacityTimer.Tick += new System.EventHandler(this.OpacityTimer_Tick);
            // 
            // VersionLabel
            // 
            this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.Location = new System.Drawing.Point(256, 288);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(212, 23);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = "Version";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.BackColor = System.Drawing.Color.Transparent;
            this.AuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorLabel.Location = new System.Drawing.Point(260, 265);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(208, 23);
            this.AuthorLabel.TabIndex = 3;
            this.AuthorLabel.Text = "Author";
            this.AuthorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 320);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.StatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.Shown += new System.EventHandler(this.SplashScreen_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Timer OpacityTimer;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label AuthorLabel;
    }
}