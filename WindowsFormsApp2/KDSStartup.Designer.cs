
namespace MCKDS
{
    partial class KDSStartup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KDSStartup));
            this.tlFryingStation = new MetroFramework.Controls.MetroTile();
            this.tlPreparingStation = new MetroFramework.Controls.MetroTile();
            this.tlExpediteStation = new MetroFramework.Controls.MetroTile();
            this.tlCustomerStation = new MetroFramework.Controls.MetroTile();
            this.tlMasterDataSync = new MetroFramework.Controls.MetroTile();
            this.tlSettings = new MetroFramework.Controls.MetroTile();
            this.lblError = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tlFOH2 = new MetroFramework.Controls.MetroTile();
            this.metroPizza = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // tlFryingStation
            // 
            this.tlFryingStation.ActiveControl = null;
            this.tlFryingStation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.tlFryingStation.Location = new System.Drawing.Point(144, 232);
            this.tlFryingStation.Name = "tlFryingStation";
            this.tlFryingStation.Size = new System.Drawing.Size(145, 135);
            this.tlFryingStation.TabIndex = 0;
            this.tlFryingStation.Text = " FRYING STATION";
            this.tlFryingStation.TileImage = ((System.Drawing.Image)(resources.GetObject("tlFryingStation.TileImage")));
            this.tlFryingStation.UseSelectable = true;
            this.tlFryingStation.Click += new System.EventHandler(this.tlFryingStation_Click);
            // 
            // tlPreparingStation
            // 
            this.tlPreparingStation.ActiveControl = null;
            this.tlPreparingStation.Location = new System.Drawing.Point(313, 232);
            this.tlPreparingStation.Name = "tlPreparingStation";
            this.tlPreparingStation.Size = new System.Drawing.Size(145, 135);
            this.tlPreparingStation.TabIndex = 0;
            this.tlPreparingStation.Text = "Middle of House";
            this.tlPreparingStation.UseSelectable = true;
            this.tlPreparingStation.Click += new System.EventHandler(this.tlPreparingStation_Click);
            // 
            // tlExpediteStation
            // 
            this.tlExpediteStation.ActiveControl = null;
            this.tlExpediteStation.Location = new System.Drawing.Point(487, 232);
            this.tlExpediteStation.Name = "tlExpediteStation";
            this.tlExpediteStation.Size = new System.Drawing.Size(145, 135);
            this.tlExpediteStation.TabIndex = 0;
            this.tlExpediteStation.Text = " ORDER ASSEMBLE";
            this.tlExpediteStation.UseSelectable = true;
            this.tlExpediteStation.Click += new System.EventHandler(this.tlExpediteStation_Click);
            // 
            // tlCustomerStation
            // 
            this.tlCustomerStation.ActiveControl = null;
            this.tlCustomerStation.Location = new System.Drawing.Point(487, 391);
            this.tlCustomerStation.Name = "tlCustomerStation";
            this.tlCustomerStation.Size = new System.Drawing.Size(145, 135);
            this.tlCustomerStation.TabIndex = 0;
            this.tlCustomerStation.Text = " ORDER STATUS";
            this.tlCustomerStation.UseSelectable = true;
            this.tlCustomerStation.Click += new System.EventHandler(this.tlCustomerStation_Click);
            // 
            // tlMasterDataSync
            // 
            this.tlMasterDataSync.ActiveControl = null;
            this.tlMasterDataSync.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.tlMasterDataSync.Location = new System.Drawing.Point(661, 232);
            this.tlMasterDataSync.Name = "tlMasterDataSync";
            this.tlMasterDataSync.Size = new System.Drawing.Size(145, 135);
            this.tlMasterDataSync.TabIndex = 5;
            this.tlMasterDataSync.Text = "Master Data Sync";
            this.tlMasterDataSync.TileImage = ((System.Drawing.Image)(resources.GetObject("tlMasterDataSync.TileImage")));
            this.tlMasterDataSync.UseSelectable = true;
            this.tlMasterDataSync.Click += new System.EventHandler(this.tlMasterDataSync_Click);
            // 
            // tlSettings
            // 
            this.tlSettings.ActiveControl = null;
            this.tlSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.tlSettings.Location = new System.Drawing.Point(144, 391);
            this.tlSettings.Name = "tlSettings";
            this.tlSettings.Size = new System.Drawing.Size(145, 135);
            this.tlSettings.TabIndex = 6;
            this.tlSettings.Text = "Settings";
            this.tlSettings.TileImage = ((System.Drawing.Image)(resources.GetObject("tlSettings.TileImage")));
            this.tlSettings.UseSelectable = true;
            this.tlSettings.Click += new System.EventHandler(this.settings_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Calibri", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(203, 180);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(86, 38);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "Label";
            this.lblError.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel2.BackgroundImage")));
            this.metroPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(230, 45);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(594, 101);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel1.BackgroundImage")));
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(48, 17);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(137, 129);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // tlFOH2
            // 
            this.tlFOH2.ActiveControl = null;
            this.tlFOH2.Location = new System.Drawing.Point(313, 391);
            this.tlFOH2.Name = "tlFOH2";
            this.tlFOH2.Size = new System.Drawing.Size(145, 135);
            this.tlFOH2.TabIndex = 8;
            this.tlFOH2.Text = " DISPATCH";
            this.tlFOH2.UseSelectable = true;
            this.tlFOH2.Click += new System.EventHandler(this.tlFOH2_Click);
            // 
            // metroPizza
            // 
            this.metroPizza.ActiveControl = null;
            this.metroPizza.Location = new System.Drawing.Point(661, 391);
            this.metroPizza.Name = "metroPizza";
            this.metroPizza.Size = new System.Drawing.Size(145, 135);
            this.metroPizza.TabIndex = 9;
            this.metroPizza.Text = "MetroPizza";
            this.metroPizza.UseSelectable = true;
            this.metroPizza.Click += new System.EventHandler(this.metroPizza_Click);
            // 
            // KDSStartup
            // 
            this.ClientSize = new System.Drawing.Size(925, 566);
            this.Controls.Add(this.metroPizza);
            this.Controls.Add(this.tlFOH2);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.tlSettings);
            this.Controls.Add(this.tlMasterDataSync);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.tlCustomerStation);
            this.Controls.Add(this.tlExpediteStation);
            this.Controls.Add(this.tlPreparingStation);
            this.Controls.Add(this.tlFryingStation);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KDSStartup";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Load += new System.EventHandler(this.KDSStartup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile tlFryingStation;
        private MetroFramework.Controls.MetroTile tlPreparingStation;
        private MetroFramework.Controls.MetroTile tlExpediteStation;
        private MetroFramework.Controls.MetroTile tlCustomerStation;
        private MetroFramework.Controls.MetroTile tlMasterDataSync;
        private MetroFramework.Controls.MetroTile tlSettings;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile tlFOH2;
        public MetroFramework.Controls.MetroTile metroPizza;
    }
}