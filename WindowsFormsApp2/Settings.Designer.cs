namespace MCKDS
{
    partial class KDSSystemSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KDSSystemSettings));
            this.apply = new System.Windows.Forms.Button();
            this.mckdsDataSet1 = new MCKDS.MCKDSDataSet();
            this.cancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Settings = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbinitilizer = new System.Windows.Forms.ComboBox();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOrderType = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.panelstoresettings = new System.Windows.Forms.Panel();
            this.chkFOH2 = new System.Windows.Forms.CheckBox();
            this.lblsyncorders = new System.Windows.Forms.Label();
            this.clbsyncorders = new System.Windows.Forms.CheckedListBox();
            this.chkfryingStation = new System.Windows.Forms.CheckBox();
            this.lblStoreSettings = new System.Windows.Forms.Label();
            this.chkPreparingStation = new System.Windows.Forms.CheckBox();
            this.chkExpediteStation = new System.Windows.Forms.CheckBox();
            this.chkCustomerStation = new System.Windows.Forms.CheckBox();
            this.Database = new System.Windows.Forms.TabPage();
            this.lblpass = new System.Windows.Forms.Label();
            this.lbluser = new System.Windows.Forms.Label();
            this.lblDB = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.DBName = new System.Windows.Forms.TextBox();
            this.ServerName = new System.Windows.Forms.TextBox();
            this.btnconnect = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.lblports = new System.Windows.Forms.Label();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mckdsDataSet1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Settings.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelstoresettings.SuspendLayout();
            this.Database.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(226, 381);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(73, 23);
            this.apply.TabIndex = 4;
            this.apply.Text = "OK";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // mckdsDataSet1
            // 
            this.mckdsDataSet1.DataSetName = "MCKDSDataSet";
            this.mckdsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(307, 381);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Settings);
            this.tabControl1.Controls.Add(this.Database);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(411, 367);
            this.tabControl1.TabIndex = 6;
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.panel2);
            this.Settings.Controls.Add(this.panelstoresettings);
            this.Settings.Location = new System.Drawing.Point(4, 22);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Settings.Size = new System.Drawing.Size(403, 341);
            this.Settings.TabIndex = 0;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbinitilizer);
            this.panel2.Controls.Add(this.txtStationName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chkOrderType);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbStations);
            this.panel2.Location = new System.Drawing.Point(31, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 171);
            this.panel2.TabIndex = 6;
            // 
            // cmbinitilizer
            // 
            this.cmbinitilizer.FormattingEnabled = true;
            this.cmbinitilizer.Items.AddRange(new object[] {
            "Pizza",
            "Pasta",
            "Sandwich"});
            this.cmbinitilizer.Location = new System.Drawing.Point(43, 116);
            this.cmbinitilizer.Name = "cmbinitilizer";
            this.cmbinitilizer.Size = new System.Drawing.Size(113, 21);
            this.cmbinitilizer.TabIndex = 7;
            this.cmbinitilizer.SelectedIndexChanged += new System.EventHandler(this.cmbinitilizer_SelectedIndexChanged);
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(43, 90);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(113, 20);
            this.txtStationName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Channels";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stations";
            // 
            // chkOrderType
            // 
            this.chkOrderType.CheckOnClick = true;
            this.chkOrderType.FormattingEnabled = true;
            this.chkOrderType.Location = new System.Drawing.Point(198, 64);
            this.chkOrderType.Name = "chkOrderType";
            this.chkOrderType.Size = new System.Drawing.Size(123, 94);
            this.chkOrderType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Station Settings";
            // 
            // cmbStations
            // 
            this.cmbStations.FormattingEnabled = true;
            this.cmbStations.Location = new System.Drawing.Point(43, 64);
            this.cmbStations.Name = "cmbStations";
            this.cmbStations.Size = new System.Drawing.Size(113, 21);
            this.cmbStations.TabIndex = 1;
            this.cmbStations.SelectedIndexChanged += new System.EventHandler(this.cmbStations_SelectedIndexChanged);
            // 
            // panelstoresettings
            // 
            this.panelstoresettings.Controls.Add(this.chkFOH2);
            this.panelstoresettings.Controls.Add(this.lblsyncorders);
            this.panelstoresettings.Controls.Add(this.clbsyncorders);
            this.panelstoresettings.Controls.Add(this.chkfryingStation);
            this.panelstoresettings.Controls.Add(this.lblStoreSettings);
            this.panelstoresettings.Controls.Add(this.chkPreparingStation);
            this.panelstoresettings.Controls.Add(this.chkExpediteStation);
            this.panelstoresettings.Controls.Add(this.chkCustomerStation);
            this.panelstoresettings.Location = new System.Drawing.Point(31, 6);
            this.panelstoresettings.Name = "panelstoresettings";
            this.panelstoresettings.Size = new System.Drawing.Size(345, 157);
            this.panelstoresettings.TabIndex = 5;
            // 
            // chkFOH2
            // 
            this.chkFOH2.AutoSize = true;
            this.chkFOH2.Location = new System.Drawing.Point(17, 104);
            this.chkFOH2.Name = "chkFOH2";
            this.chkFOH2.Size = new System.Drawing.Size(54, 17);
            this.chkFOH2.TabIndex = 12;
            this.chkFOH2.Text = "FOH2";
            this.chkFOH2.UseVisualStyleBackColor = true;
            this.chkFOH2.CheckedChanged += new System.EventHandler(this.chkFOH2_CheckedChanged);
            // 
            // lblsyncorders
            // 
            this.lblsyncorders.AutoSize = true;
            this.lblsyncorders.Location = new System.Drawing.Point(199, 4);
            this.lblsyncorders.Name = "lblsyncorders";
            this.lblsyncorders.Size = new System.Drawing.Size(122, 13);
            this.lblsyncorders.TabIndex = 11;
            this.lblsyncorders.Text = "Sync Suspended Orders";
            // 
            // clbsyncorders
            // 
            this.clbsyncorders.CheckOnClick = true;
            this.clbsyncorders.FormattingEnabled = true;
            this.clbsyncorders.Location = new System.Drawing.Point(201, 20);
            this.clbsyncorders.Name = "clbsyncorders";
            this.clbsyncorders.Size = new System.Drawing.Size(120, 94);
            this.clbsyncorders.TabIndex = 10;
            // 
            // chkfryingStation
            // 
            this.chkfryingStation.AutoSize = true;
            this.chkfryingStation.Checked = true;
            this.chkfryingStation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkfryingStation.Enabled = false;
            this.chkfryingStation.Location = new System.Drawing.Point(17, 35);
            this.chkfryingStation.Name = "chkfryingStation";
            this.chkfryingStation.Size = new System.Drawing.Size(90, 17);
            this.chkfryingStation.TabIndex = 0;
            this.chkfryingStation.Text = "Frying Station";
            this.chkfryingStation.UseVisualStyleBackColor = true;
            // 
            // lblStoreSettings
            // 
            this.lblStoreSettings.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreSettings.Location = new System.Drawing.Point(13, 4);
            this.lblStoreSettings.Name = "lblStoreSettings";
            this.lblStoreSettings.Size = new System.Drawing.Size(171, 28);
            this.lblStoreSettings.TabIndex = 0;
            this.lblStoreSettings.Text = "Store Settings";
            // 
            // chkPreparingStation
            // 
            this.chkPreparingStation.AutoSize = true;
            this.chkPreparingStation.Checked = true;
            this.chkPreparingStation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreparingStation.Enabled = false;
            this.chkPreparingStation.Location = new System.Drawing.Point(17, 58);
            this.chkPreparingStation.Name = "chkPreparingStation";
            this.chkPreparingStation.Size = new System.Drawing.Size(107, 17);
            this.chkPreparingStation.TabIndex = 0;
            this.chkPreparingStation.Text = "Praparing Station";
            this.chkPreparingStation.UseVisualStyleBackColor = true;
            // 
            // chkExpediteStation
            // 
            this.chkExpediteStation.AutoSize = true;
            this.chkExpediteStation.Location = new System.Drawing.Point(17, 81);
            this.chkExpediteStation.Name = "chkExpediteStation";
            this.chkExpediteStation.Size = new System.Drawing.Size(103, 17);
            this.chkExpediteStation.TabIndex = 0;
            this.chkExpediteStation.Text = "Expedite Station";
            this.chkExpediteStation.UseVisualStyleBackColor = true;
            this.chkExpediteStation.CheckedChanged += new System.EventHandler(this.chkExpediteStation_CheckedChanged);
            // 
            // chkCustomerStation
            // 
            this.chkCustomerStation.AutoSize = true;
            this.chkCustomerStation.Location = new System.Drawing.Point(17, 127);
            this.chkCustomerStation.Name = "chkCustomerStation";
            this.chkCustomerStation.Size = new System.Drawing.Size(106, 17);
            this.chkCustomerStation.TabIndex = 0;
            this.chkCustomerStation.Text = "Customer Station";
            this.chkCustomerStation.UseVisualStyleBackColor = true;
            this.chkCustomerStation.CheckedChanged += new System.EventHandler(this.chkCustomerStation_CheckedChanged);
            // 
            // Database
            // 
            this.Database.Controls.Add(this.lblpass);
            this.Database.Controls.Add(this.lbluser);
            this.Database.Controls.Add(this.lblDB);
            this.Database.Controls.Add(this.lblServer);
            this.Database.Controls.Add(this.password);
            this.Database.Controls.Add(this.Username);
            this.Database.Controls.Add(this.DBName);
            this.Database.Controls.Add(this.ServerName);
            this.Database.Controls.Add(this.btnconnect);
            this.Database.Location = new System.Drawing.Point(4, 22);
            this.Database.Name = "Database";
            this.Database.Padding = new System.Windows.Forms.Padding(3);
            this.Database.Size = new System.Drawing.Size(403, 341);
            this.Database.TabIndex = 1;
            this.Database.Text = "DB Configurations";
            this.Database.UseVisualStyleBackColor = true;
            // 
            // lblpass
            // 
            this.lblpass.AutoSize = true;
            this.lblpass.Location = new System.Drawing.Point(75, 118);
            this.lblpass.Name = "lblpass";
            this.lblpass.Size = new System.Drawing.Size(53, 13);
            this.lblpass.TabIndex = 8;
            this.lblpass.Text = "Password";
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.Location = new System.Drawing.Point(76, 92);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(60, 13);
            this.lbluser.TabIndex = 7;
            this.lbluser.Text = "User Name";
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Location = new System.Drawing.Point(76, 66);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(57, 13);
            this.lblDB.TabIndex = 6;
            this.lblDB.Text = "Data Base";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(76, 40);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(38, 13);
            this.lblServer.TabIndex = 5;
            this.lblServer.Text = "Server";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(142, 118);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(141, 20);
            this.password.TabIndex = 4;
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(142, 92);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(141, 20);
            this.Username.TabIndex = 3;
            // 
            // DBName
            // 
            this.DBName.Location = new System.Drawing.Point(142, 66);
            this.DBName.Name = "DBName";
            this.DBName.Size = new System.Drawing.Size(141, 20);
            this.DBName.TabIndex = 2;
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(142, 40);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(141, 20);
            this.ServerName.TabIndex = 1;
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(210, 153);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(75, 23);
            this.btnconnect.TabIndex = 0;
            this.btnconnect.Text = "Connect";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lblports);
            this.tabPage1.Controls.Add(this.cboPorts);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(403, 341);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Comm Port";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Note: Re-Open the screen after changing COM port.";
            // 
            // lblports
            // 
            this.lblports.AutoSize = true;
            this.lblports.Location = new System.Drawing.Point(64, 21);
            this.lblports.Name = "lblports";
            this.lblports.Size = new System.Drawing.Size(31, 13);
            this.lblports.TabIndex = 32;
            this.lblports.Text = "Ports";
            // 
            // cboPorts
            // 
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(127, 21);
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(121, 21);
            this.cboPorts.TabIndex = 26;
            // 
            // KDSSystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 417);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.apply);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KDSSystemSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mckdsDataSet1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Settings.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelstoresettings.ResumeLayout(false);
            this.panelstoresettings.PerformLayout();
            this.Database.ResumeLayout(false);
            this.Database.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MCKDSDataSet mckdsDataSet1;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.TabPage Database;
        private System.Windows.Forms.Panel panelstoresettings;
        private System.Windows.Forms.CheckBox chkfryingStation;
        private System.Windows.Forms.Label lblStoreSettings;
        private System.Windows.Forms.CheckBox chkPreparingStation;
        private System.Windows.Forms.CheckBox chkExpediteStation;
        private System.Windows.Forms.CheckBox chkCustomerStation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkOrderType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox DBName;
        private System.Windows.Forms.TextBox ServerName;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cboPorts;
        private System.Windows.Forms.Label lblports;
        private System.Windows.Forms.Label lblsyncorders;
        private System.Windows.Forms.CheckedListBox clbsyncorders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbinitilizer;
        private System.Windows.Forms.CheckBox chkFOH2;
    }
}