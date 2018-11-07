namespace MqttOpenHabPcControl
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbLoginRequired = new System.Windows.Forms.CheckBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbMqttProtocol3_1_1 = new System.Windows.Forms.RadioButton();
            this.rdbMqttProtocol3_1 = new System.Windows.Forms.RadioButton();
            this.nudBrokerPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrokerAdress = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckbTLS_SSL = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPathToCertificate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSearchScript = new System.Windows.Forms.Button();
            this.txtFriendlyName = new System.Windows.Forms.TextBox();
            this.txtScriptFolder = new System.Windows.Forms.TextBox();
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ckbAutostart = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrokerPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbLoginRequired);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(206, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 139);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MQTT Login";
            // 
            // ckbLoginRequired
            // 
            this.ckbLoginRequired.AutoSize = true;
            this.ckbLoginRequired.Location = new System.Drawing.Point(6, 19);
            this.ckbLoginRequired.Name = "ckbLoginRequired";
            this.ckbLoginRequired.Size = new System.Drawing.Size(93, 17);
            this.ckbLoginRequired.TabIndex = 6;
            this.ckbLoginRequired.Text = "Login required";
            this.ckbLoginRequired.UseVisualStyleBackColor = true;
            this.ckbLoginRequired.CheckedChanged += new System.EventHandler(this.ckbLoginRequired_CheckedChanged);
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(6, 55);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(188, 20);
            this.txtUser.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(6, 108);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(188, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // rdbMqttProtocol3_1_1
            // 
            this.rdbMqttProtocol3_1_1.AutoSize = true;
            this.rdbMqttProtocol3_1_1.Checked = true;
            this.rdbMqttProtocol3_1_1.Location = new System.Drawing.Point(9, 103);
            this.rdbMqttProtocol3_1_1.Name = "rdbMqttProtocol3_1_1";
            this.rdbMqttProtocol3_1_1.Size = new System.Drawing.Size(125, 17);
            this.rdbMqttProtocol3_1_1.TabIndex = 4;
            this.rdbMqttProtocol3_1_1.TabStop = true;
            this.rdbMqttProtocol3_1_1.Text = "MQTT-Protocol 3.1.1";
            this.rdbMqttProtocol3_1_1.UseVisualStyleBackColor = true;
            // 
            // rdbMqttProtocol3_1
            // 
            this.rdbMqttProtocol3_1.AutoSize = true;
            this.rdbMqttProtocol3_1.Location = new System.Drawing.Point(9, 80);
            this.rdbMqttProtocol3_1.Name = "rdbMqttProtocol3_1";
            this.rdbMqttProtocol3_1.Size = new System.Drawing.Size(116, 17);
            this.rdbMqttProtocol3_1.TabIndex = 3;
            this.rdbMqttProtocol3_1.Text = "MQTT-Protocol 3.1";
            this.rdbMqttProtocol3_1.UseVisualStyleBackColor = true;
            // 
            // nudBrokerPort
            // 
            this.nudBrokerPort.Location = new System.Drawing.Point(101, 43);
            this.nudBrokerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudBrokerPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrokerPort.Name = "nudBrokerPort";
            this.nudBrokerPort.Size = new System.Drawing.Size(93, 20);
            this.nudBrokerPort.TabIndex = 2;
            this.nudBrokerPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adress";
            // 
            // txtBrokerAdress
            // 
            this.txtBrokerAdress.Location = new System.Drawing.Point(51, 17);
            this.txtBrokerAdress.Name = "txtBrokerAdress";
            this.txtBrokerAdress.Size = new System.Drawing.Size(143, 20);
            this.txtBrokerAdress.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.rdbMqttProtocol3_1_1);
            this.groupBox2.Controls.Add(this.rdbMqttProtocol3_1);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.nudBrokerPort);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtBrokerAdress);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 229);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MQTT Broker";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckbTLS_SSL);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.txtPathToCertificate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(0, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 95);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MQTT Security";
            // 
            // ckbTLS_SSL
            // 
            this.ckbTLS_SSL.AutoSize = true;
            this.ckbTLS_SSL.Location = new System.Drawing.Point(9, 19);
            this.ckbTLS_SSL.Name = "ckbTLS_SSL";
            this.ckbTLS_SSL.Size = new System.Drawing.Size(93, 17);
            this.ckbTLS_SSL.TabIndex = 10;
            this.ckbTLS_SSL.Text = "Use TLS/SSL";
            this.ckbTLS_SSL.UseVisualStyleBackColor = true;
            this.ckbTLS_SSL.CheckedChanged += new System.EventHandler(this.ckbTLS_SSL_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(345, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(55, 22);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPathToCertificate
            // 
            this.txtPathToCertificate.Enabled = false;
            this.txtPathToCertificate.Location = new System.Drawing.Point(9, 59);
            this.txtPathToCertificate.Name = "txtPathToCertificate";
            this.txtPathToCertificate.Size = new System.Drawing.Size(336, 20);
            this.txtPathToCertificate.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Path to X509 Certificate";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckbAutostart);
            this.groupBox4.Controls.Add(this.btnSearchScript);
            this.groupBox4.Controls.Add(this.txtFriendlyName);
            this.groupBox4.Controls.Add(this.txtScriptFolder);
            this.groupBox4.Controls.Add(this.txtGuid);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(12, 247);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(406, 141);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PC Settings";
            // 
            // btnSearchScript
            // 
            this.btnSearchScript.Location = new System.Drawing.Point(345, 114);
            this.btnSearchScript.Name = "btnSearchScript";
            this.btnSearchScript.Size = new System.Drawing.Size(55, 22);
            this.btnSearchScript.TabIndex = 15;
            this.btnSearchScript.Text = "Search";
            this.btnSearchScript.UseVisualStyleBackColor = true;
            this.btnSearchScript.Click += new System.EventHandler(this.btnSearchScript_Click);
            // 
            // txtFriendlyName
            // 
            this.txtFriendlyName.Location = new System.Drawing.Point(187, 45);
            this.txtFriendlyName.Name = "txtFriendlyName";
            this.txtFriendlyName.Size = new System.Drawing.Size(213, 20);
            this.txtFriendlyName.TabIndex = 15;
            // 
            // txtScriptFolder
            // 
            this.txtScriptFolder.Location = new System.Drawing.Point(9, 115);
            this.txtScriptFolder.Name = "txtScriptFolder";
            this.txtScriptFolder.Size = new System.Drawing.Size(336, 20);
            this.txtScriptFolder.TabIndex = 14;
            // 
            // txtGuid
            // 
            this.txtGuid.Location = new System.Drawing.Point(187, 19);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.ReadOnly = true;
            this.txtGuid.Size = new System.Drawing.Size(213, 20);
            this.txtGuid.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Path to Scriptfolder";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "ID";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(290, 394);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(128, 44);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Save and Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ckbAutostart
            // 
            this.ckbAutostart.AutoSize = true;
            this.ckbAutostart.Location = new System.Drawing.Point(187, 71);
            this.ckbAutostart.Name = "ckbAutostart";
            this.ckbAutostart.Size = new System.Drawing.Size(147, 17);
            this.ckbAutostart.TabIndex = 15;
            this.ckbAutostart.Text = "Start on Windows Startup";
            this.ckbAutostart.UseVisualStyleBackColor = true;
            this.ckbAutostart.CheckedChanged += new System.EventHandler(this.ckbAutostart_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrokerPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrokerAdress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nudBrokerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.CheckBox ckbLoginRequired;
        private System.Windows.Forms.RadioButton rdbMqttProtocol3_1_1;
        private System.Windows.Forms.RadioButton rdbMqttProtocol3_1;
        private System.Windows.Forms.CheckBox ckbTLS_SSL;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPathToCertificate;
        private System.Windows.Forms.TextBox txtFriendlyName;
        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearchScript;
        private System.Windows.Forms.TextBox txtScriptFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ckbAutostart;
    }
}

