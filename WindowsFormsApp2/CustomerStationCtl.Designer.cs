
namespace MCKDS
{
    partial class CustomerStationCtl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerStationCtl));
            this.panOrders = new MetroFramework.Controls.MetroPanel();
            this.OrderGrid = new MetroFramework.Controls.MetroGrid();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdOnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mCKDSDataSet3 = new MCKDS.MCKDSDataSet3();
            this.lblErrorMSG = new System.Windows.Forms.Label();
            this.tmRefreshScreen = new System.Windows.Forms.Timer(this.components);
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalOrder = new System.Windows.Forms.Label();
            this.TodayTime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblStationName = new System.Windows.Forms.Label();
            this.lblordercount = new System.Windows.Forms.Label();
            this.panTitle = new MetroFramework.Controls.MetroPanel();
            this.ordersTableAdapter = new MCKDS.MCKDSDataSet3TableAdapters.OrdersTableAdapter();
            this.panOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSDataSet3)).BeginInit();
            this.panTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panOrders
            // 
            this.panOrders.Controls.Add(this.OrderGrid);
            this.panOrders.Controls.Add(this.lblErrorMSG);
            this.panOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panOrders.HorizontalScrollbarBarColor = true;
            this.panOrders.HorizontalScrollbarHighlightOnWheel = false;
            this.panOrders.HorizontalScrollbarSize = 10;
            this.panOrders.Location = new System.Drawing.Point(20, 120);
            this.panOrders.Name = "panOrders";
            this.panOrders.Size = new System.Drawing.Size(1004, 338);
            this.panOrders.TabIndex = 0;
            this.panOrders.VerticalScrollbarBarColor = true;
            this.panOrders.VerticalScrollbarHighlightOnWheel = false;
            this.panOrders.VerticalScrollbarSize = 10;
            // 
            // OrderGrid
            // 
            this.OrderGrid.AllowUserToResizeRows = false;
            this.OrderGrid.AutoGenerateColumns = false;
            this.OrderGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OrderGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OrderGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.OrderGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.OrderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn,
            this.orderStateDataGridViewTextBoxColumn,
            this.orderNoDataGridViewTextBoxColumn,
            this.createdOnDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn});
            this.OrderGrid.DataSource = this.ordersBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.OrderGrid.EnableHeadersVisualStyles = false;
            this.OrderGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.OrderGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OrderGrid.Location = new System.Drawing.Point(745, 98);
            this.OrderGrid.Name = "OrderGrid";
            this.OrderGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.OrderGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.OrderGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrderGrid.Size = new System.Drawing.Size(240, 150);
            this.OrderGrid.TabIndex = 6;
            this.OrderGrid.Visible = false;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            // 
            // orderStateDataGridViewTextBoxColumn
            // 
            this.orderStateDataGridViewTextBoxColumn.DataPropertyName = "OrderState";
            this.orderStateDataGridViewTextBoxColumn.HeaderText = "OrderState";
            this.orderStateDataGridViewTextBoxColumn.Name = "orderStateDataGridViewTextBoxColumn";
            // 
            // orderNoDataGridViewTextBoxColumn
            // 
            this.orderNoDataGridViewTextBoxColumn.DataPropertyName = "OrderNo";
            this.orderNoDataGridViewTextBoxColumn.HeaderText = "OrderNo";
            this.orderNoDataGridViewTextBoxColumn.Name = "orderNoDataGridViewTextBoxColumn";
            // 
            // createdOnDataGridViewTextBoxColumn
            // 
            this.createdOnDataGridViewTextBoxColumn.DataPropertyName = "CreatedOn";
            this.createdOnDataGridViewTextBoxColumn.HeaderText = "CreatedOn";
            this.createdOnDataGridViewTextBoxColumn.Name = "createdOnDataGridViewTextBoxColumn";
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "Orders";
            this.ordersBindingSource.DataSource = this.mCKDSDataSet3;
            // 
            // mCKDSDataSet3
            // 
            this.mCKDSDataSet3.DataSetName = "MCKDSDataSet3";
            this.mCKDSDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblErrorMSG
            // 
            this.lblErrorMSG.AutoSize = true;
            this.lblErrorMSG.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMSG.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMSG.Location = new System.Drawing.Point(441, 265);
            this.lblErrorMSG.Name = "lblErrorMSG";
            this.lblErrorMSG.Size = new System.Drawing.Size(108, 42);
            this.lblErrorMSG.TabIndex = 4;
            this.lblErrorMSG.Text = "label2";
            this.lblErrorMSG.Visible = false;
            // 
            // tmRefreshScreen
            // 
            this.tmRefreshScreen.Interval = 5000;
            this.tmRefreshScreen.Tick += new System.EventHandler(this.tmRefreshScreen_Tick);
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel2.BackgroundImage")));
            this.metroPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(3, 2);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(87, 78);
            this.metroPanel2.TabIndex = 10;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 55);
            this.label1.TabIndex = 11;
            this.label1.Text = " ORDER STATUS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Selected Order: ";
            this.label2.Visible = false;
            // 
            // lblTotalOrder
            // 
            this.lblTotalOrder.AutoSize = true;
            this.lblTotalOrder.Location = new System.Drawing.Point(14, 83);
            this.lblTotalOrder.Name = "lblTotalOrder";
            this.lblTotalOrder.Size = new System.Drawing.Size(65, 13);
            this.lblTotalOrder.TabIndex = 13;
            this.lblTotalOrder.Text = "Total Orders";
            // 
            // TodayTime
            // 
            this.TodayTime.AutoSize = true;
            this.TodayTime.Location = new System.Drawing.Point(668, 83);
            this.TodayTime.Name = "TodayTime";
            this.TodayTime.Size = new System.Drawing.Size(30, 13);
            this.TodayTime.TabIndex = 14;
            this.TodayTime.Text = "Time";
            this.TodayTime.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(873, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStationName
            // 
            this.lblStationName.AutoSize = true;
            this.lblStationName.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationName.Location = new System.Drawing.Point(593, 43);
            this.lblStationName.Name = "lblStationName";
            this.lblStationName.Size = new System.Drawing.Size(184, 33);
            this.lblStationName.TabIndex = 5;
            this.lblStationName.Text = "lblstationname";
            // 
            // lblordercount
            // 
            this.lblordercount.AutoSize = true;
            this.lblordercount.Location = new System.Drawing.Point(85, 83);
            this.lblordercount.Name = "lblordercount";
            this.lblordercount.Size = new System.Drawing.Size(0, 13);
            this.lblordercount.TabIndex = 16;
            // 
            // panTitle
            // 
            this.panTitle.Controls.Add(this.lblordercount);
            this.panTitle.Controls.Add(this.lblStationName);
            this.panTitle.Controls.Add(this.button1);
            this.panTitle.Controls.Add(this.TodayTime);
            this.panTitle.Controls.Add(this.lblTotalOrder);
            this.panTitle.Controls.Add(this.label2);
            this.panTitle.Controls.Add(this.label1);
            this.panTitle.Controls.Add(this.metroPanel2);
            this.panTitle.HorizontalScrollbarBarColor = true;
            this.panTitle.HorizontalScrollbarHighlightOnWheel = false;
            this.panTitle.HorizontalScrollbarSize = 10;
            this.panTitle.Location = new System.Drawing.Point(19, 21);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(951, 96);
            this.panTitle.TabIndex = 14;
            this.panTitle.VerticalScrollbarBarColor = true;
            this.panTitle.VerticalScrollbarHighlightOnWheel = false;
            this.panTitle.VerticalScrollbarSize = 10;
            this.panTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panTitle_Paint);
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // CustomerStationCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 478);
            this.Controls.Add(this.panTitle);
            this.Controls.Add(this.panOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "CustomerStationCtl";
            this.Padding = new System.Windows.Forms.Padding(20, 120, 20, 20);
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomerStationCtl_FormClosing);
            this.Load += new System.EventHandler(this.CustomerStationCtl_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomerStationCtl_KeyPress);
            this.panOrders.ResumeLayout(false);
            this.panOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSDataSet3)).EndInit();
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panOrders;
        private System.Windows.Forms.Timer tmRefreshScreen;
   
        private System.Windows.Forms.Label lblErrorMSG;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOSIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderCompletionOnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lINENUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn visibleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDSOrderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn paidDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn onHoldDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextOrderStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn friedStationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pizzaStationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pastaStationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineDescription1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineDescription2DataGridViewTextBoxColumn;
        private MetroFramework.Controls.MetroGrid OrderGrid;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalOrder;
        private System.Windows.Forms.Label TodayTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblStationName;
        private System.Windows.Forms.Label lblordercount;
        private MetroFramework.Controls.MetroPanel panTitle;
        private MCKDSDataSet3 mCKDSDataSet3;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private MCKDSDataSet3TableAdapters.OrdersTableAdapter ordersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdOnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
    }
}