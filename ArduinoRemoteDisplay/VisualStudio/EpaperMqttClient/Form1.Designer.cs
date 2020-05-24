namespace EpaperMqtt
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
            this.labelBroker = new System.Windows.Forms.Label();
            this.textBoxBrokerServer = new System.Windows.Forms.TextBox();
            this.labelUserID = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxMqttPass = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxBrokerPort = new System.Windows.Forms.TextBox();
            this.textBoxINTopic = new System.Windows.Forms.TextBox();
            this.labelPubTopic = new System.Windows.Forms.Label();
            this.comboBoxPortSetect = new System.Windows.Forms.ComboBox();
            this.labelSerialPort = new System.Windows.Forms.Label();
            this.labelSSID = new System.Windows.Forms.Label();
            this.textBoxSSID = new System.Windows.Forms.TextBox();
            this.labelWiFipass = new System.Windows.Forms.Label();
            this.textBoxSSIDPASS = new System.Windows.Forms.TextBox();
            this.groupBoxWiFIconnect = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.buttonConnectWifi = new System.Windows.Forms.Button();
            this.labelClientID = new System.Windows.Forms.Label();
            this.textBoxMqttClient = new System.Windows.Forms.TextBox();
            this.textBoxOUTTopic = new System.Windows.Forms.TextBox();
            this.labelOutTopic = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonTopicUpdata = new System.Windows.Forms.Button();
            this.labelTXdata = new System.Windows.Forms.Label();
            this.textBoxTXdata = new System.Windows.Forms.TextBox();
            this.buttonTX = new System.Windows.Forms.Button();
            this.labelRX = new System.Windows.Forms.Label();
            this.textBoxRXdata = new System.Windows.Forms.TextBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBoxRXtopic = new System.Windows.Forms.TextBox();
            this.labelInTopic = new System.Windows.Forms.Label();
            this.groupBoxTW = new System.Windows.Forms.GroupBox();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.groupBoxWiFIconnect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxTW.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelBroker
            // 
            this.labelBroker.AutoSize = true;
            this.labelBroker.Location = new System.Drawing.Point(31, 35);
            this.labelBroker.Name = "labelBroker";
            this.labelBroker.Size = new System.Drawing.Size(38, 13);
            this.labelBroker.TabIndex = 2;
            this.labelBroker.Text = "Broker";
            // 
            // textBoxBrokerServer
            // 
            this.textBoxBrokerServer.Location = new System.Drawing.Point(96, 35);
            this.textBoxBrokerServer.Name = "textBoxBrokerServer";
            this.textBoxBrokerServer.Size = new System.Drawing.Size(149, 20);
            this.textBoxBrokerServer.TabIndex = 5;
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(31, 71);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(40, 13);
            this.labelUserID.TabIndex = 10;
            this.labelUserID.Text = "UserID";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(96, 64);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(149, 20);
            this.textBoxUserID.TabIndex = 11;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(24, 98);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 12;
            this.labelPassword.Text = "Passowrd";
            // 
            // textBoxMqttPass
            // 
            this.textBoxMqttPass.Location = new System.Drawing.Point(96, 90);
            this.textBoxMqttPass.Name = "textBoxMqttPass";
            this.textBoxMqttPass.Size = new System.Drawing.Size(149, 20);
            this.textBoxMqttPass.TabIndex = 13;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(34, 123);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 14;
            this.labelPort.Text = "Port";
            // 
            // textBoxBrokerPort
            // 
            this.textBoxBrokerPort.Location = new System.Drawing.Point(96, 116);
            this.textBoxBrokerPort.Name = "textBoxBrokerPort";
            this.textBoxBrokerPort.Size = new System.Drawing.Size(149, 20);
            this.textBoxBrokerPort.TabIndex = 15;
            // 
            // textBoxINTopic
            // 
            this.textBoxINTopic.Location = new System.Drawing.Point(113, 19);
            this.textBoxINTopic.Name = "textBoxINTopic";
            this.textBoxINTopic.Size = new System.Drawing.Size(154, 20);
            this.textBoxINTopic.TabIndex = 16;
            this.textBoxINTopic.TextChanged += new System.EventHandler(this.textBoxINTopic_TextChanged);
            // 
            // labelPubTopic
            // 
            this.labelPubTopic.AutoSize = true;
            this.labelPubTopic.Location = new System.Drawing.Point(18, 22);
            this.labelPubTopic.Name = "labelPubTopic";
            this.labelPubTopic.Size = new System.Drawing.Size(89, 13);
            this.labelPubTopic.TabIndex = 17;
            this.labelPubTopic.Text = "InComming Topic";
            // 
            // comboBoxPortSetect
            // 
            this.comboBoxPortSetect.FormattingEnabled = true;
            this.comboBoxPortSetect.Location = new System.Drawing.Point(91, 89);
            this.comboBoxPortSetect.Name = "comboBoxPortSetect";
            this.comboBoxPortSetect.Size = new System.Drawing.Size(164, 21);
            this.comboBoxPortSetect.TabIndex = 22;
            // 
            // labelSerialPort
            // 
            this.labelSerialPort.AutoSize = true;
            this.labelSerialPort.Location = new System.Drawing.Point(16, 92);
            this.labelSerialPort.Name = "labelSerialPort";
            this.labelSerialPort.Size = new System.Drawing.Size(54, 13);
            this.labelSerialPort.TabIndex = 23;
            this.labelSerialPort.Text = "Serial port";
            // 
            // labelSSID
            // 
            this.labelSSID.AutoSize = true;
            this.labelSSID.Location = new System.Drawing.Point(18, 35);
            this.labelSSID.Name = "labelSSID";
            this.labelSSID.Size = new System.Drawing.Size(32, 13);
            this.labelSSID.TabIndex = 24;
            this.labelSSID.Text = "SSID";
            // 
            // textBoxSSID
            // 
            this.textBoxSSID.Location = new System.Drawing.Point(91, 32);
            this.textBoxSSID.Name = "textBoxSSID";
            this.textBoxSSID.Size = new System.Drawing.Size(164, 20);
            this.textBoxSSID.TabIndex = 25;
            // 
            // labelWiFipass
            // 
            this.labelWiFipass.AutoSize = true;
            this.labelWiFipass.Location = new System.Drawing.Point(17, 58);
            this.labelWiFipass.Name = "labelWiFipass";
            this.labelWiFipass.Size = new System.Drawing.Size(53, 13);
            this.labelWiFipass.TabIndex = 26;
            this.labelWiFipass.Text = "Password";
            // 
            // textBoxSSIDPASS
            // 
            this.textBoxSSIDPASS.Location = new System.Drawing.Point(91, 58);
            this.textBoxSSIDPASS.Name = "textBoxSSIDPASS";
            this.textBoxSSIDPASS.Size = new System.Drawing.Size(164, 20);
            this.textBoxSSIDPASS.TabIndex = 27;
            // 
            // groupBoxWiFIconnect
            // 
            this.groupBoxWiFIconnect.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.groupBoxWiFIconnect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxWiFIconnect.Controls.Add(this.labelWiFipass);
            this.groupBoxWiFIconnect.Controls.Add(this.labelSerialPort);
            this.groupBoxWiFIconnect.Controls.Add(this.textBoxSSID);
            this.groupBoxWiFIconnect.Controls.Add(this.comboBoxPortSetect);
            this.groupBoxWiFIconnect.Controls.Add(this.textBoxSSIDPASS);
            this.groupBoxWiFIconnect.Controls.Add(this.labelSSID);
            this.groupBoxWiFIconnect.Location = new System.Drawing.Point(294, 23);
            this.groupBoxWiFIconnect.Name = "groupBoxWiFIconnect";
            this.groupBoxWiFIconnect.Size = new System.Drawing.Size(273, 189);
            this.groupBoxWiFIconnect.TabIndex = 28;
            this.groupBoxWiFIconnect.TabStop = false;
            this.groupBoxWiFIconnect.Text = "Connect to network";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(291, 365);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(80, 13);
            this.labelStatus.TabIndex = 32;
            this.labelStatus.Text = "Connect Status";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(402, 365);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(164, 20);
            this.textBoxStatus.TabIndex = 32;
            // 
            // buttonConnectWifi
            // 
            this.buttonConnectWifi.Location = new System.Drawing.Point(491, 402);
            this.buttonConnectWifi.Name = "buttonConnectWifi";
            this.buttonConnectWifi.Size = new System.Drawing.Size(75, 23);
            this.buttonConnectWifi.TabIndex = 28;
            this.buttonConnectWifi.Text = "Connect";
            this.buttonConnectWifi.UseVisualStyleBackColor = true;
            this.buttonConnectWifi.Click += new System.EventHandler(this.buttonConnectWifi_Click);
            // 
            // labelClientID
            // 
            this.labelClientID.AutoSize = true;
            this.labelClientID.Location = new System.Drawing.Point(30, 146);
            this.labelClientID.Name = "labelClientID";
            this.labelClientID.Size = new System.Drawing.Size(47, 13);
            this.labelClientID.TabIndex = 29;
            this.labelClientID.Text = "Client ID";
            // 
            // textBoxMqttClient
            // 
            this.textBoxMqttClient.Location = new System.Drawing.Point(96, 143);
            this.textBoxMqttClient.Name = "textBoxMqttClient";
            this.textBoxMqttClient.Size = new System.Drawing.Size(149, 20);
            this.textBoxMqttClient.TabIndex = 30;
            // 
            // textBoxOUTTopic
            // 
            this.textBoxOUTTopic.Location = new System.Drawing.Point(113, 45);
            this.textBoxOUTTopic.Name = "textBoxOUTTopic";
            this.textBoxOUTTopic.Size = new System.Drawing.Size(154, 20);
            this.textBoxOUTTopic.TabIndex = 31;
            this.textBoxOUTTopic.TextChanged += new System.EventHandler(this.textBoxOUTTopic_TextChanged);
            // 
            // labelOutTopic
            // 
            this.labelOutTopic.AutoSize = true;
            this.labelOutTopic.Location = new System.Drawing.Point(28, 48);
            this.labelOutTopic.Name = "labelOutTopic";
            this.labelOutTopic.Size = new System.Drawing.Size(80, 13);
            this.labelOutTopic.TabIndex = 32;
            this.labelOutTopic.Text = "Outgoing Topic";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.textBoxBrokerServer);
            this.groupBox1.Controls.Add(this.textBoxUserID);
            this.groupBox1.Controls.Add(this.textBoxMqttPass);
            this.groupBox1.Controls.Add(this.textBoxBrokerPort);
            this.groupBox1.Controls.Add(this.labelBroker);
            this.groupBox1.Controls.Add(this.labelClientID);
            this.groupBox1.Controls.Add(this.textBoxMqttClient);
            this.groupBox1.Controls.Add(this.labelUserID);
            this.groupBox1.Controls.Add(this.labelPassword);
            this.groupBox1.Controls.Add(this.labelPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 189);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect Mqtt Server";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.buttonTopicUpdata);
            this.groupBox2.Controls.Add(this.textBoxINTopic);
            this.groupBox2.Controls.Add(this.textBoxOUTTopic);
            this.groupBox2.Controls.Add(this.labelPubTopic);
            this.groupBox2.Controls.Add(this.labelOutTopic);
            this.groupBox2.Location = new System.Drawing.Point(294, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 110);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Topic";
            // 
            // buttonTopicUpdata
            // 
            this.buttonTopicUpdata.Location = new System.Drawing.Point(170, 81);
            this.buttonTopicUpdata.Name = "buttonTopicUpdata";
            this.buttonTopicUpdata.Size = new System.Drawing.Size(75, 23);
            this.buttonTopicUpdata.TabIndex = 31;
            this.buttonTopicUpdata.Text = "Updata";
            this.buttonTopicUpdata.UseVisualStyleBackColor = true;
            this.buttonTopicUpdata.Click += new System.EventHandler(this.buttonTopicUpdata_Click);
            // 
            // labelTXdata
            // 
            this.labelTXdata.AutoSize = true;
            this.labelTXdata.Location = new System.Drawing.Point(6, 26);
            this.labelTXdata.Name = "labelTXdata";
            this.labelTXdata.Size = new System.Drawing.Size(42, 13);
            this.labelTXdata.TabIndex = 32;
            this.labelTXdata.Text = "TXdata";
            // 
            // textBoxTXdata
            // 
            this.textBoxTXdata.Location = new System.Drawing.Point(51, 19);
            this.textBoxTXdata.Name = "textBoxTXdata";
            this.textBoxTXdata.Size = new System.Drawing.Size(138, 20);
            this.textBoxTXdata.TabIndex = 34;
            // 
            // buttonTX
            // 
            this.buttonTX.Location = new System.Drawing.Point(193, 21);
            this.buttonTX.Name = "buttonTX";
            this.buttonTX.Size = new System.Drawing.Size(52, 23);
            this.buttonTX.TabIndex = 32;
            this.buttonTX.Text = "TX";
            this.buttonTX.UseVisualStyleBackColor = true;
            this.buttonTX.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelRX
            // 
            this.labelRX.AutoSize = true;
            this.labelRX.Location = new System.Drawing.Point(2, 73);
            this.labelRX.Name = "labelRX";
            this.labelRX.Size = new System.Drawing.Size(43, 13);
            this.labelRX.TabIndex = 36;
            this.labelRX.Text = "RXdata";
            // 
            // textBoxRXdata
            // 
            this.textBoxRXdata.Location = new System.Drawing.Point(51, 73);
            this.textBoxRXdata.Name = "textBoxRXdata";
            this.textBoxRXdata.Size = new System.Drawing.Size(137, 20);
            this.textBoxRXdata.TabIndex = 37;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(192, 43);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(53, 23);
            this.buttonRefresh.TabIndex = 38;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // textBoxRXtopic
            // 
            this.textBoxRXtopic.Location = new System.Drawing.Point(51, 45);
            this.textBoxRXtopic.Name = "textBoxRXtopic";
            this.textBoxRXtopic.Size = new System.Drawing.Size(138, 20);
            this.textBoxRXtopic.TabIndex = 39;
            // 
            // labelInTopic
            // 
            this.labelInTopic.AutoSize = true;
            this.labelInTopic.Location = new System.Drawing.Point(2, 50);
            this.labelInTopic.Name = "labelInTopic";
            this.labelInTopic.Size = new System.Drawing.Size(46, 13);
            this.labelInTopic.TabIndex = 40;
            this.labelInTopic.Text = "In Topic";
            // 
            // groupBoxTW
            // 
            this.groupBoxTW.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxTW.Controls.Add(this.textBoxRXdata);
            this.groupBoxTW.Controls.Add(this.textBoxRXtopic);
            this.groupBoxTW.Controls.Add(this.textBoxTXdata);
            this.groupBoxTW.Controls.Add(this.labelInTopic);
            this.groupBoxTW.Controls.Add(this.buttonTX);
            this.groupBoxTW.Controls.Add(this.buttonRefresh);
            this.groupBoxTW.Controls.Add(this.labelTXdata);
            this.groupBoxTW.Controls.Add(this.labelRX);
            this.groupBoxTW.Location = new System.Drawing.Point(12, 218);
            this.groupBoxTW.Name = "groupBoxTW";
            this.groupBoxTW.Size = new System.Drawing.Size(264, 121);
            this.groupBoxTW.TabIndex = 41;
            this.groupBoxTW.TabStop = false;
            this.groupBoxTW.Text = "Test windows";
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Location = new System.Drawing.Point(21, 402);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(350, 23);
            this.progressBarStatus.TabIndex = 42;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(108, 365);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(109, 20);
            this.textBoxIP.TabIndex = 43;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(12, 368);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(58, 13);
            this.labelIP.TabIndex = 44;
            this.labelIP.Text = "IP Address";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 449);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.progressBarStatus);
            this.Controls.Add(this.groupBoxTW);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.buttonConnectWifi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxWiFIconnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBoxWiFIconnect.ResumeLayout(false);
            this.groupBoxWiFIconnect.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxTW.ResumeLayout(false);
            this.groupBoxTW.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBroker;
        private System.Windows.Forms.TextBox textBoxBrokerServer;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxMqttPass;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxBrokerPort;
        private System.Windows.Forms.TextBox textBoxINTopic;
        private System.Windows.Forms.Label labelPubTopic;
        private System.Windows.Forms.ComboBox comboBoxPortSetect;
        private System.Windows.Forms.Label labelSerialPort;
        private System.Windows.Forms.Label labelSSID;
        private System.Windows.Forms.TextBox textBoxSSID;
        private System.Windows.Forms.Label labelWiFipass;
        private System.Windows.Forms.TextBox textBoxSSIDPASS;
        private System.Windows.Forms.GroupBox groupBoxWiFIconnect;
        private System.Windows.Forms.Button buttonConnectWifi;
        private System.Windows.Forms.Label labelClientID;
        private System.Windows.Forms.TextBox textBoxMqttClient;
        private System.Windows.Forms.TextBox textBoxOUTTopic;
        private System.Windows.Forms.Label labelOutTopic;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonTopicUpdata;
        private System.Windows.Forms.Label labelTXdata;
        private System.Windows.Forms.TextBox textBoxTXdata;
        private System.Windows.Forms.Button buttonTX;
        private System.Windows.Forms.Label labelRX;
        private System.Windows.Forms.TextBox textBoxRXdata;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBoxRXtopic;
        private System.Windows.Forms.Label labelInTopic;
        private System.Windows.Forms.GroupBox groupBoxTW;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label labelIP;
    }
}

