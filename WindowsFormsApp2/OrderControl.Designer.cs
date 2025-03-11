namespace MCKDS
{
    partial class crlOrder
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(crlOrder));
            this.panHeader = new System.Windows.Forms.Panel();
            this.lblOrderTime = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.panOrderType = new System.Windows.Forms.Panel();
            this.panOnHold = new System.Windows.Forms.Panel();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wbOrderDetails = new System.Windows.Forms.WebBrowser();
            this.CheckedPannel = new System.Windows.Forms.Panel();
            this.panelOrderRecall = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOrderSource = new System.Windows.Forms.Label();
            this.LateOrder = new System.Windows.Forms.Timer(this.components);
            this.panHeader.SuspendLayout();
            this.panOrderType.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHeader
            // 
            this.panHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.panHeader.Controls.Add(this.lblOrderTime);
            this.panHeader.Controls.Add(this.lblOrderNo);
            this.panHeader.Controls.Add(this.panOrderType);
            this.panHeader.Location = new System.Drawing.Point(3, 4);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(259, 52);
            this.panHeader.TabIndex = 0;
            this.panHeader.Click += new System.EventHandler(this.OrderCtl_Click);
            this.panHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panHeader_Paint);
            // 
            // lblOrderTime
            // 
            this.lblOrderTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTime.ForeColor = System.Drawing.SystemColors.Window;
            this.lblOrderTime.Location = new System.Drawing.Point(164, 3);
            this.lblOrderTime.Name = "lblOrderTime";
            this.lblOrderTime.Size = new System.Drawing.Size(92, 20);
            this.lblOrderTime.TabIndex = 0;
            this.lblOrderTime.Text = "Time";
            this.lblOrderTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblOrderTime.Click += new System.EventHandler(this.OrderCtl_Click);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNo.ForeColor = System.Drawing.SystemColors.Window;
            this.lblOrderNo.Location = new System.Drawing.Point(3, 3);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(69, 20);
            this.lblOrderNo.TabIndex = 0;
            this.lblOrderNo.Text = "Order #";
            this.lblOrderNo.Click += new System.EventHandler(this.OrderCtl_Click);
            // 
            // panOrderType
            // 
            this.panOrderType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panOrderType.AutoSize = true;
            this.panOrderType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.panOrderType.Controls.Add(this.panOnHold);
            this.panOrderType.Controls.Add(this.lblOrderType);
            this.panOrderType.Controls.Add(this.panel1);
            this.panOrderType.ForeColor = System.Drawing.Color.Black;
            this.panOrderType.Location = new System.Drawing.Point(-2, 25);
            this.panOrderType.Name = "panOrderType";
            this.panOrderType.Size = new System.Drawing.Size(261, 30);
            this.panOrderType.TabIndex = 2;
            this.panOrderType.Click += new System.EventHandler(this.OrderCtl_Click);
            // 
            // panOnHold
            // 
            this.panOnHold.BackColor = System.Drawing.Color.White;
            this.panOnHold.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panOnHold.BackgroundImage")));
            this.panOnHold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panOnHold.Location = new System.Drawing.Point(196, 2);
            this.panOnHold.Name = "panOnHold";
            this.panOnHold.Size = new System.Drawing.Size(30, 24);
            this.panOnHold.TabIndex = 4;
            this.panOnHold.Visible = false;
            // 
            // lblOrderType
            // 
            this.lblOrderType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOrderType.BackColor = System.Drawing.Color.Transparent;
            this.lblOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderType.ForeColor = System.Drawing.Color.Black;
            this.lblOrderType.Location = new System.Drawing.Point(34, 4);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(187, 20);
            this.lblOrderType.TabIndex = 2;
            this.lblOrderType.Text = "Order Type";
            this.lblOrderType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOrderType.Click += new System.EventHandler(this.OrderCtl_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(228, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 24);
            this.panel1.TabIndex = 3;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
         
            // wbOrderDetails
            // 
            this.wbOrderDetails.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.wbOrderDetails.Location = new System.Drawing.Point(2, 62);
            this.wbOrderDetails.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOrderDetails.Name = "wbOrderDetails";
            this.wbOrderDetails.ScrollBarsEnabled = false;
            this.wbOrderDetails.Size = new System.Drawing.Size(260, 266);
            this.wbOrderDetails.TabIndex = 1;
            this.wbOrderDetails.Url = new System.Uri("", System.UriKind.Relative);
            this.wbOrderDetails.WebBrowserShortcutsEnabled = false;
            // 
            // CheckedPannel
            // 
            this.CheckedPannel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckedPannel.BackColor = System.Drawing.Color.Transparent;
            this.CheckedPannel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckedPannel.BackgroundImage")));
            this.CheckedPannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CheckedPannel.Location = new System.Drawing.Point(64, 119);
            this.CheckedPannel.Name = "CheckedPannel";
            this.CheckedPannel.Size = new System.Drawing.Size(132, 125);
            this.CheckedPannel.TabIndex = 2;
            this.CheckedPannel.Visible = false;
            // 
            // panelOrderRecall
            // 
            this.panelOrderRecall.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelOrderRecall.BackColor = System.Drawing.Color.Transparent;
            this.panelOrderRecall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelOrderRecall.BackgroundImage")));
            this.panelOrderRecall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelOrderRecall.Location = new System.Drawing.Point(61, 122);
            this.panelOrderRecall.Name = "panelOrderRecall";
            this.panelOrderRecall.Size = new System.Drawing.Size(132, 71);
            this.panelOrderRecall.TabIndex = 3;
            this.panelOrderRecall.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lblOrderSource);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(2, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 17);
            this.panel2.TabIndex = 6;
            // 
            // lblOrderSource
            // 
            this.lblOrderSource.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOrderSource.BackColor = System.Drawing.Color.Transparent;
            this.lblOrderSource.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderSource.ForeColor = System.Drawing.Color.Black;
            this.lblOrderSource.Location = new System.Drawing.Point(17, 3);
            this.lblOrderSource.Name = "lblOrderSource";
            this.lblOrderSource.Size = new System.Drawing.Size(228, 10);
            this.lblOrderSource.TabIndex = 2;
            this.lblOrderSource.Text = "Order Source";
            this.lblOrderSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LateOrder
            // 
            this.LateOrder.Enabled = true;
            this.LateOrder.Interval = 200;
            this.LateOrder.Tick += new System.EventHandler(this.LateOrder_Tick);
            // 
            // crlOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(226)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelOrderRecall);
            this.Controls.Add(this.CheckedPannel);
            this.Controls.Add(this.panHeader);
            this.Controls.Add(this.wbOrderDetails);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "crlOrder";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(264, 323);
            this.Load += new System.EventHandler(this.crlOrder_Load);
            this.Click += new System.EventHandler(this.OrderCtl_Click);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OrderCtl_KeyPress);
            this.panHeader.ResumeLayout(false);
            this.panHeader.PerformLayout();
            this.panOrderType.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblOrderTime;
        private System.Windows.Forms.Panel panOrderType;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.WebBrowser wbOrderDetails;
        private System.Windows.Forms.Panel CheckedPannel;
        private System.Windows.Forms.Panel panelOrderRecall;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panOnHold;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOrderSource;
        private System.Windows.Forms.Timer LateOrder;
    }
}
