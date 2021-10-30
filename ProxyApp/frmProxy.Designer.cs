namespace ProxyApp
{
    partial class frmProxy
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
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.grpRunningIP = new System.Windows.Forms.GroupBox();
            this.lstRunningIP = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.rdoManualip = new System.Windows.Forms.RadioButton();
            this.rdoAPI = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBytesend = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtByteReceived = new System.Windows.Forms.TextBox();
            this.txtdownloadstring = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.rdoExcel = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTimedelay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLoopvalue = new System.Windows.Forms.TextBox();
            this.grpRunningIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(110, 157);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(155, 22);
            this.txtIPAddress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "PORT";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(345, 157);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(111, 22);
            this.txtPort.TabIndex = 2;
            // 
            // grpRunningIP
            // 
            this.grpRunningIP.Controls.Add(this.lstRunningIP);
            this.grpRunningIP.Location = new System.Drawing.Point(14, 259);
            this.grpRunningIP.Name = "grpRunningIP";
            this.grpRunningIP.Size = new System.Drawing.Size(607, 288);
            this.grpRunningIP.TabIndex = 4;
            this.grpRunningIP.TabStop = false;
            this.grpRunningIP.Text = "Running IP";
            // 
            // lstRunningIP
            // 
            this.lstRunningIP.FormattingEnabled = true;
            this.lstRunningIP.ItemHeight = 16;
            this.lstRunningIP.Location = new System.Drawing.Point(6, 22);
            this.lstRunningIP.Name = "lstRunningIP";
            this.lstRunningIP.Size = new System.Drawing.Size(601, 260);
            this.lstRunningIP.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(30, 553);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(170, 56);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(245, 553);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(170, 56);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // rdoManualip
            // 
            this.rdoManualip.AutoSize = true;
            this.rdoManualip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoManualip.Location = new System.Drawing.Point(20, 114);
            this.rdoManualip.Name = "rdoManualip";
            this.rdoManualip.Size = new System.Drawing.Size(133, 21);
            this.rdoManualip.TabIndex = 7;
            this.rdoManualip.Text = "Use Manual IP";
            this.rdoManualip.UseVisualStyleBackColor = true;
            this.rdoManualip.CheckedChanged += new System.EventHandler(this.choosetype_CheckedChanged);
            // 
            // rdoAPI
            // 
            this.rdoAPI.AutoSize = true;
            this.rdoAPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAPI.Location = new System.Drawing.Point(176, 114);
            this.rdoAPI.Name = "rdoAPI";
            this.rdoAPI.Size = new System.Drawing.Size(86, 21);
            this.rdoAPI.TabIndex = 8;
            this.rdoAPI.Text = "Use API";
            this.rdoAPI.UseVisualStyleBackColor = true;
            this.rdoAPI.CheckedChanged += new System.EventHandler(this.choosetype_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(30, 625);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(170, 56);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(62, 29);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(510, 22);
            this.txtURL.TabIndex = 11;
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(114, 689);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Byte Send";
            // 
            // txtBytesend
            // 
            this.txtBytesend.Location = new System.Drawing.Point(260, 680);
            this.txtBytesend.Multiline = true;
            this.txtBytesend.Name = "txtBytesend";
            this.txtBytesend.Size = new System.Drawing.Size(155, 34);
            this.txtBytesend.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(114, 729);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Byte Received";
            // 
            // txtByteReceived
            // 
            this.txtByteReceived.Location = new System.Drawing.Point(260, 720);
            this.txtByteReceived.Multiline = true;
            this.txtByteReceived.Name = "txtByteReceived";
            this.txtByteReceived.Size = new System.Drawing.Size(155, 34);
            this.txtByteReceived.TabIndex = 15;
            // 
            // txtdownloadstring
            // 
            this.txtdownloadstring.Location = new System.Drawing.Point(636, 1);
            this.txtdownloadstring.MaxLength = 3276700;
            this.txtdownloadstring.Multiline = true;
            this.txtdownloadstring.Name = "txtdownloadstring";
            this.txtdownloadstring.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtdownloadstring.Size = new System.Drawing.Size(1134, 750);
            this.txtdownloadstring.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Select Country";
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(135, 203);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(409, 24);
            this.cmbCountry.TabIndex = 19;
            // 
            // rdoExcel
            // 
            this.rdoExcel.AutoSize = true;
            this.rdoExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoExcel.Location = new System.Drawing.Point(300, 114);
            this.rdoExcel.Name = "rdoExcel";
            this.rdoExcel.Size = new System.Drawing.Size(100, 21);
            this.rdoExcel.TabIndex = 20;
            this.rdoExcel.Text = "Use Excel";
            this.rdoExcel.UseVisualStyleBackColor = true;
            this.rdoExcel.CheckedChanged += new System.EventHandler(this.choosetype_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(304, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "TimeDelay in Seconds";
            // 
            // txtTimedelay
            // 
            this.txtTimedelay.Location = new System.Drawing.Point(487, 71);
            this.txtTimedelay.Name = "txtTimedelay";
            this.txtTimedelay.Size = new System.Drawing.Size(111, 22);
            this.txtTimedelay.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Loop Value";
            // 
            // txtLoopvalue
            // 
            this.txtLoopvalue.Location = new System.Drawing.Point(130, 71);
            this.txtLoopvalue.Name = "txtLoopvalue";
            this.txtLoopvalue.Size = new System.Drawing.Size(155, 22);
            this.txtLoopvalue.TabIndex = 21;
            // 
            // frmProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1772, 761);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTimedelay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLoopvalue);
            this.Controls.Add(this.rdoExcel);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtdownloadstring);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtByteReceived);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBytesend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rdoAPI);
            this.Controls.Add(this.rdoManualip);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grpRunningIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIPAddress);
            this.Name = "frmProxy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proxy Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProxy_FormClosed);
            this.Load += new System.EventHandler(this.frmProxy_Load);
            this.grpRunningIP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.GroupBox grpRunningIP;
        private System.Windows.Forms.ListBox lstRunningIP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RadioButton rdoManualip;
        private System.Windows.Forms.RadioButton rdoAPI;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBytesend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtByteReceived;
        private System.Windows.Forms.TextBox txtdownloadstring;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.RadioButton rdoExcel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTimedelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLoopvalue;
    }
}

