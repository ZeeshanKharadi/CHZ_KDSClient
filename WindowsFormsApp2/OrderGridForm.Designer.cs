
namespace MCKDS
{
    partial class OrderGridForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderGridForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panOrders = new MetroFramework.Controls.MetroPanel();
            this.lblErrorMSG = new System.Windows.Forms.Label();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.orderNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdOnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HDSOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PizzaStation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PastaStation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FriedStation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mCKDSDataSetOrder1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mCKDSDataSetOrder1 = new MCKDS.MCKDSDataSetOrder();
            this.btnRefreshScreen = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrDataRefresh = new System.Windows.Forms.Timer(this.components);
            this.panTitle = new MetroFramework.Controls.MetroPanel();
            this.chkHideHoldOrders = new System.Windows.Forms.CheckBox();
            this.lblCustomStationName = new System.Windows.Forms.Label();
            this.TodayTime = new System.Windows.Forms.Label();
            this.lblTotalOrder = new System.Windows.Forms.Label();
            this.lblCurrentOrderNo = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroGrid2 = new MetroFramework.Controls.MetroGrid();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ordersTableAdapter = new MCKDS.MCKDSDataSetOrderTableAdapters.OrdersTableAdapter();
            this.PageNumTxt = new System.Windows.Forms.Label();
            this.panOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSDataSetOrder1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSDataSetOrder1)).BeginInit();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // panOrders
            // 
            this.panOrders.BackColor = System.Drawing.Color.Transparent;
            this.panOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panOrders.Controls.Add(this.lblErrorMSG);
            this.panOrders.Controls.Add(this.metroGrid1);
            this.panOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panOrders.HorizontalScrollbarBarColor = true;
            this.panOrders.HorizontalScrollbarHighlightOnWheel = false;
            this.panOrders.HorizontalScrollbarSize = 10;
            this.panOrders.Location = new System.Drawing.Point(20, 120);
            this.panOrders.Name = "panOrders";
            this.panOrders.Size = new System.Drawing.Size(1260, 648);
            this.panOrders.TabIndex = 0;
            this.panOrders.VerticalScrollbarBarColor = true;
            this.panOrders.VerticalScrollbarHighlightOnWheel = false;
            this.panOrders.VerticalScrollbarSize = 10;
            this.panOrders.Paint += new System.Windows.Forms.PaintEventHandler(this.panOrders_Paint);
            // 
            // lblErrorMSG
            // 
            this.lblErrorMSG.AutoSize = true;
            this.lblErrorMSG.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMSG.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMSG.Location = new System.Drawing.Point(509, 270);
            this.lblErrorMSG.Name = "lblErrorMSG";
            this.lblErrorMSG.Size = new System.Drawing.Size(108, 42);
            this.lblErrorMSG.TabIndex = 3;
            this.lblErrorMSG.Text = "label2";
            this.lblErrorMSG.Visible = false;
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToDeleteRows = false;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoGenerateColumns = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNoDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.createdOnDataGridViewTextBoxColumn,
            this.orderStatusDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.OrderTime,
            this.TransactionType,
            this.OrderSource,
            this.HDSOrderId,
            this.OrderState,
            this.NextOrderStatus,
            this.PizzaStation,
            this.PastaStation,
            this.FriedStation});
            this.metroGrid1.DataSource = this.ordersBindingSource;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle20;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(1060, 0);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.metroGrid1.RowHeadersVisible = false;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(165, 446);
            this.metroGrid1.TabIndex = 2;
            this.metroGrid1.Visible = false;
            // 
            // orderNoDataGridViewTextBoxColumn
            // 
            this.orderNoDataGridViewTextBoxColumn.DataPropertyName = "OrderNo";
            this.orderNoDataGridViewTextBoxColumn.HeaderText = "OrderNo";
            this.orderNoDataGridViewTextBoxColumn.Name = "orderNoDataGridViewTextBoxColumn";
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            // 
            // createdOnDataGridViewTextBoxColumn
            // 
            this.createdOnDataGridViewTextBoxColumn.DataPropertyName = "CreatedOn";
            this.createdOnDataGridViewTextBoxColumn.HeaderText = "CreatedOn";
            this.createdOnDataGridViewTextBoxColumn.Name = "createdOnDataGridViewTextBoxColumn";
            // 
            // orderStatusDataGridViewTextBoxColumn
            // 
            this.orderStatusDataGridViewTextBoxColumn.DataPropertyName = "OrderStatus";
            this.orderStatusDataGridViewTextBoxColumn.HeaderText = "OrderStatus";
            this.orderStatusDataGridViewTextBoxColumn.Name = "orderStatusDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrderID";
            this.dataGridViewTextBoxColumn2.HeaderText = "OrderID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // OrderTime
            // 
            this.OrderTime.DataPropertyName = "OrderTime";
            this.OrderTime.HeaderText = "OrderTime";
            this.OrderTime.Name = "OrderTime";
            this.OrderTime.ReadOnly = true;
            // 
            // TransactionType
            // 
            this.TransactionType.DataPropertyName = "TransactionType";
            this.TransactionType.HeaderText = "TransactionType";
            this.TransactionType.Name = "TransactionType";
            // 
            // OrderSource
            // 
            this.OrderSource.DataPropertyName = "OrderSource";
            this.OrderSource.HeaderText = "OrderSource";
            this.OrderSource.Name = "OrderSource";
            // 
            // HDSOrderId
            // 
            this.HDSOrderId.DataPropertyName = "HDSOrderId";
            this.HDSOrderId.HeaderText = "HDSOrderId";
            this.HDSOrderId.Name = "HDSOrderId";
            // 
            // OrderState
            // 
            this.OrderState.DataPropertyName = "OrderState";
            this.OrderState.HeaderText = "OrderState";
            this.OrderState.Name = "OrderState";
            // 
            // NextOrderStatus
            // 
            this.NextOrderStatus.DataPropertyName = "NextOrderStatus";
            this.NextOrderStatus.HeaderText = "NextOrderStatus";
            this.NextOrderStatus.Name = "NextOrderStatus";
            // 
            // PizzaStation
            // 
            this.PizzaStation.DataPropertyName = "PizzaStation";
            this.PizzaStation.HeaderText = "PizzaStation";
            this.PizzaStation.Name = "PizzaStation";
            // 
            // PastaStation
            // 
            this.PastaStation.DataPropertyName = "PastaStation";
            this.PastaStation.HeaderText = "PastaStation";
            this.PastaStation.Name = "PastaStation";
            // 
            // FriedStation
            // 
            this.FriedStation.DataPropertyName = "FriedStation";
            this.FriedStation.HeaderText = "FriedStation";
            this.FriedStation.Name = "FriedStation";
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "Orders";
            this.ordersBindingSource.DataSource = this.mCKDSDataSetOrder1BindingSource;
            // 
            // mCKDSDataSetOrder1BindingSource
            // 
            this.mCKDSDataSetOrder1BindingSource.DataSource = this.mCKDSDataSetOrder1;
            this.mCKDSDataSetOrder1BindingSource.Position = 0;
            // 
            // mCKDSDataSetOrder1
            // 
            this.mCKDSDataSetOrder1.DataSetName = "MCKDSDataSetOrder";
            this.mCKDSDataSetOrder1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnRefreshScreen
            // 
            this.btnRefreshScreen.Location = new System.Drawing.Point(1083, 34);
            this.btnRefreshScreen.Name = "btnRefreshScreen";
            this.btnRefreshScreen.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshScreen.TabIndex = 4;
            this.btnRefreshScreen.Text = "Refresh";
            this.btnRefreshScreen.UseSelectable = true;
            this.btnRefreshScreen.Visible = false;
            this.btnRefreshScreen.Click += new System.EventHandler(this.btnRefreshScreen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(724, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // tmrDataRefresh
            // 
            this.tmrDataRefresh.Interval = 3000;
            this.tmrDataRefresh.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.Transparent;
            this.panTitle.Controls.Add(this.PageNumTxt);
            this.panTitle.Controls.Add(this.chkHideHoldOrders);
            this.panTitle.Controls.Add(this.lblCustomStationName);
            this.panTitle.Controls.Add(this.TodayTime);
            this.panTitle.Controls.Add(this.lblTotalOrder);
            this.panTitle.Controls.Add(this.lblCurrentOrderNo);
            this.panTitle.Controls.Add(this.lblFormTitle);
            this.panTitle.Controls.Add(this.metroPanel2);
            this.panTitle.Controls.Add(this.metroGrid2);
            this.panTitle.HorizontalScrollbarBarColor = true;
            this.panTitle.HorizontalScrollbarHighlightOnWheel = false;
            this.panTitle.HorizontalScrollbarSize = 10;
            this.panTitle.Location = new System.Drawing.Point(23, 20);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(1051, 100);
            this.panTitle.TabIndex = 15;
            this.panTitle.VerticalScrollbarBarColor = true;
            this.panTitle.VerticalScrollbarHighlightOnWheel = false;
            this.panTitle.VerticalScrollbarSize = 10;
            // 
            // chkHideHoldOrders
            // 
            this.chkHideHoldOrders.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHideHoldOrders.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkHideHoldOrders.BackgroundImage")));
            this.chkHideHoldOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkHideHoldOrders.Location = new System.Drawing.Point(106, 72);
            this.chkHideHoldOrders.Name = "chkHideHoldOrders";
            this.chkHideHoldOrders.Size = new System.Drawing.Size(33, 28);
            this.chkHideHoldOrders.TabIndex = 17;
            this.chkHideHoldOrders.UseVisualStyleBackColor = true;
            this.chkHideHoldOrders.Visible = false;
            this.chkHideHoldOrders.CheckedChanged += new System.EventHandler(this.chkHideHoldOrders_CheckedChanged);
            // 
            // lblCustomStationName
            // 
            this.lblCustomStationName.AutoSize = true;
            this.lblCustomStationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomStationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(4)))));
            this.lblCustomStationName.Location = new System.Drawing.Point(589, 32);
            this.lblCustomStationName.Name = "lblCustomStationName";
            this.lblCustomStationName.Size = new System.Drawing.Size(48, 42);
            this.lblCustomStationName.TabIndex = 18;
            this.lblCustomStationName.Text = "...";
            this.lblCustomStationName.Visible = false;
            // 
            // TodayTime
            // 
            this.TodayTime.AutoSize = true;
            this.TodayTime.Location = new System.Drawing.Point(668, 81);
            this.TodayTime.Name = "TodayTime";
            this.TodayTime.Size = new System.Drawing.Size(30, 13);
            this.TodayTime.TabIndex = 14;
            this.TodayTime.Text = "Time";
            this.TodayTime.Visible = false;
            // 
            // lblTotalOrder
            // 
            this.lblTotalOrder.AutoSize = true;
            this.lblTotalOrder.Location = new System.Drawing.Point(14, 81);
            this.lblTotalOrder.Name = "lblTotalOrder";
            this.lblTotalOrder.Size = new System.Drawing.Size(65, 13);
            this.lblTotalOrder.TabIndex = 13;
            this.lblTotalOrder.Text = "Total Orders";
            // 
            // lblCurrentOrderNo
            // 
            this.lblCurrentOrderNo.AutoSize = true;
            this.lblCurrentOrderNo.Location = new System.Drawing.Point(338, 81);
            this.lblCurrentOrderNo.Name = "lblCurrentOrderNo";
            this.lblCurrentOrderNo.Size = new System.Drawing.Size(84, 13);
            this.lblCurrentOrderNo.TabIndex = 12;
            this.lblCurrentOrderNo.Text = "Selected Order: ";
            this.lblCurrentOrderNo.Visible = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(92, 23);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(285, 55);
            this.lblFormTitle.TabIndex = 11;
            this.lblFormTitle.Text = "KDS Station";
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
            // metroGrid2
            // 
            this.metroGrid2.AllowUserToResizeRows = false;
            this.metroGrid2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.metroGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid2.DefaultCellStyle = dataGridViewCellStyle23;
            this.metroGrid2.EnableHeadersVisualStyles = false;
            this.metroGrid2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid2.Location = new System.Drawing.Point(613, 205);
            this.metroGrid2.Name = "metroGrid2";
            this.metroGrid2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid2.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.metroGrid2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid2.Size = new System.Drawing.Size(128, 102);
            this.metroGrid2.TabIndex = 2;
            this.metroGrid2.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Order";
            this.dataGridViewTextBoxColumn6.HeaderText = "Order";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Type";
            this.dataGridViewTextBoxColumn7.HeaderText = "Type";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Created On";
            this.dataGridViewTextBoxColumn8.HeaderText = "Created On";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn9.HeaderText = "Status";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 769);
            this.panel1.TabIndex = 16;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // PageNumTxt
            // 
            this.PageNumTxt.AutoSize = true;
            this.PageNumTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PageNumTxt.Location = new System.Drawing.Point(923, 69);
            this.PageNumTxt.Name = "PageNumTxt";
            this.PageNumTxt.Size = new System.Drawing.Size(76, 25);
            this.PageNumTxt.TabIndex = 19;
            this.PageNumTxt.Text = "label2";
            // 
            // OrderGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1300, 788);
            this.Controls.Add(this.panTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefreshScreen);
            this.Controls.Add(this.panOrders);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "OrderGridForm";
            this.Padding = new System.Windows.Forms.Padding(20, 120, 20, 20);
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "KDS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderGridForm_FormClosing);
            this.Load += new System.EventHandler(this.OrderGridForm_Load);
            this.Shown += new System.EventHandler(this.OrderGridForm_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OrderGridForm_KeyPress);
            this.panOrders.ResumeLayout(false);
            this.panOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSDataSetOrder1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSDataSetOrder1)).EndInit();
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panOrders;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroButton btnRefreshScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrDataRefresh;
        private MetroFramework.Controls.MetroPanel panTitle;
        private System.Windows.Forms.Label TodayTime;
        private System.Windows.Forms.Label lblTotalOrder;
        private System.Windows.Forms.Label lblCurrentOrderNo;
        private System.Windows.Forms.Label lblFormTitle;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroGrid metroGrid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private MCKDSDataSetOrderTableAdapters.OrdersTableAdapter ordersTableAdapter;
        private MCKDSDataSetOrder mCKDSDataSetOrder1;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private System.Windows.Forms.BindingSource mCKDSDataSetOrder1BindingSource;
        private System.Windows.Forms.Label lblErrorMSG;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkHideHoldOrders;
        private System.Windows.Forms.Label lblCustomStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdOnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn HDSOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderState;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextOrderStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PizzaStation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PastaStation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FriedStation;
        private System.Windows.Forms.Label PageNumTxt;
    }
}