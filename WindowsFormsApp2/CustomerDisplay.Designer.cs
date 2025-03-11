
namespace MCKDS
{
    partial class CustomerDisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDisplayForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pPreparing = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.mgPreparing = new MetroFramework.Controls.MetroGrid();
            this.orderNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mCKDSDataSet1 = new MCKDS.MCKDSDataSet1();
            this.mgReady = new MetroFramework.Controls.MetroGrid();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mCKDSOrderDataCompleted = new MCKDS.MCKDSOrderDataCompleted();
            this.lblErrorMSG = new System.Windows.Forms.Label();
            this.tmRefreshScreen = new System.Windows.Forms.Timer(this.components);
            this.ordersTableAdapter1 = new MCKDS.MCKDSOrderDataCompletedTableAdapters.OrdersTableAdapter();
            this.lblStationName = new System.Windows.Forms.Label();
            this.ordersTableAdapter = new MCKDS.MCKDSDataSet1TableAdapters.OrdersTableAdapter();
            this.panBottom = new System.Windows.Forms.Panel();
            this.pPreparing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgPreparing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgReady)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSOrderDataCompleted)).BeginInit();
            this.SuspendLayout();
            // 
            // pPreparing
            // 
            this.pPreparing.BackColor = System.Drawing.Color.Transparent;
            this.pPreparing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pPreparing.Controls.Add(this.label1);
            this.pPreparing.Location = new System.Drawing.Point(23, 63);
            this.pPreparing.Name = "pPreparing";
            this.pPreparing.Size = new System.Drawing.Size(500, 50);
            this.pPreparing.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 50);
            this.label1.TabIndex = 15;
            this.label1.Text = "Preparing...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(845, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 50);
            this.label2.TabIndex = 16;
            this.label2.Text = "Please Collect";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(620, 33);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(126, 125);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // mgPreparing
            // 
            this.mgPreparing.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.mgPreparing.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mgPreparing.AutoGenerateColumns = false;
            this.mgPreparing.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mgPreparing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mgPreparing.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.mgPreparing.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mgPreparing.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mgPreparing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mgPreparing.ColumnHeadersVisible = false;
            this.mgPreparing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNoDataGridViewTextBoxColumn});
            this.mgPreparing.DataSource = this.ordersBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgPreparing.DefaultCellStyle = dataGridViewCellStyle4;
            this.mgPreparing.Enabled = false;
            this.mgPreparing.EnableHeadersVisualStyles = false;
            this.mgPreparing.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mgPreparing.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mgPreparing.Location = new System.Drawing.Point(168, 120);
            this.mgPreparing.MultiSelect = false;
            this.mgPreparing.Name = "mgPreparing";
            this.mgPreparing.ReadOnly = true;
            this.mgPreparing.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mgPreparing.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.mgPreparing.RowHeadersVisible = false;
            this.mgPreparing.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.mgPreparing.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.mgPreparing.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.mgPreparing.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 36.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mgPreparing.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.mgPreparing.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.mgPreparing.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.mgPreparing.RowTemplate.Height = 51;
            this.mgPreparing.RowTemplate.ReadOnly = true;
            this.mgPreparing.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mgPreparing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mgPreparing.ShowCellErrors = false;
            this.mgPreparing.ShowCellToolTips = false;
            this.mgPreparing.ShowEditingIcon = false;
            this.mgPreparing.ShowRowErrors = false;
            this.mgPreparing.Size = new System.Drawing.Size(173, 450);
            this.mgPreparing.TabIndex = 5;
            this.mgPreparing.TabStop = false;
            this.mgPreparing.UseCustomBackColor = true;
            this.mgPreparing.UseCustomForeColor = true;
            // 
            // orderNoDataGridViewTextBoxColumn
            // 
            this.orderNoDataGridViewTextBoxColumn.DataPropertyName = "OrderNo";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.orderNoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.orderNoDataGridViewTextBoxColumn.HeaderText = "OrderNo";
            this.orderNoDataGridViewTextBoxColumn.Name = "orderNoDataGridViewTextBoxColumn";
            this.orderNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderNoDataGridViewTextBoxColumn.Width = 400;
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "Orders";
            this.ordersBindingSource.DataSource = this.mCKDSDataSet1;
            // 
            // mCKDSDataSet1
            // 
            this.mCKDSDataSet1.DataSetName = "MCKDSDataSet1";
            this.mCKDSDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mgReady
            // 
            this.mgReady.AllowUserToAddRows = false;
            this.mgReady.AllowUserToDeleteRows = false;
            this.mgReady.AllowUserToResizeColumns = false;
            this.mgReady.AllowUserToResizeRows = false;
            this.mgReady.AutoGenerateColumns = false;
            this.mgReady.BackgroundColor = System.Drawing.Color.White;
            this.mgReady.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mgReady.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.mgReady.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mgReady.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.mgReady.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mgReady.ColumnHeadersVisible = false;
            this.mgReady.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Image,
            this.dataGridViewTextBoxColumn1,
            this.OrderID});
            this.mgReady.DataSource = this.ordersBindingSource1;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgReady.DefaultCellStyle = dataGridViewCellStyle10;
            this.mgReady.EnableHeadersVisualStyles = false;
            this.mgReady.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mgReady.GridColor = System.Drawing.Color.White;
            this.mgReady.Location = new System.Drawing.Point(975, 119);
            this.mgReady.MultiSelect = false;
            this.mgReady.Name = "mgReady";
            this.mgReady.ReadOnly = true;
            this.mgReady.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(197)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(197)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(197)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mgReady.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.mgReady.RowHeadersVisible = false;
            this.mgReady.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.mgReady.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.mgReady.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 36.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mgReady.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.mgReady.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.mgReady.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.mgReady.RowTemplate.Height = 45;
            this.mgReady.RowTemplate.ReadOnly = true;
            this.mgReady.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mgReady.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mgReady.ShowCellErrors = false;
            this.mgReady.ShowCellToolTips = false;
            this.mgReady.ShowEditingIcon = false;
            this.mgReady.ShowRowErrors = false;
            this.mgReady.Size = new System.Drawing.Size(228, 10);
            this.mgReady.StandardTab = true;
            this.mgReady.TabIndex = 0;
            this.mgReady.UseCustomBackColor = true;
            this.mgReady.UseCustomForeColor = true;
            this.mgReady.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mgReady_CellContentClick);
            this.mgReady.SelectionChanged += new System.EventHandler(this.mgReady_SelectionChanged);
            this.mgReady.DoubleClick += new System.EventHandler(this.mgReady_DoubleClick);
            this.mgReady.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomerDisplayForm_KeyPress);
            // 
            // Image
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.NullValue = null;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black;
            this.Image.DefaultCellStyle = dataGridViewCellStyle8;
            this.Image.Frozen = true;
            this.Image.HeaderText = "Image";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderNo";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn1.HeaderText = "OrderNo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 400;
            // 
            // OrderID
            // 
            this.OrderID.DataPropertyName = "OrderID";
            this.OrderID.HeaderText = "OrderID";
            this.OrderID.Name = "OrderID";
            this.OrderID.ReadOnly = true;
            this.OrderID.Visible = false;
            // 
            // ordersBindingSource1
            // 
            this.ordersBindingSource1.DataMember = "Orders";
            this.ordersBindingSource1.DataSource = this.mCKDSOrderDataCompleted;
            // 
            // mCKDSOrderDataCompleted
            // 
            this.mCKDSOrderDataCompleted.DataSetName = "MCKDSOrderDataCompleted";
            this.mCKDSOrderDataCompleted.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblErrorMSG
            // 
            this.lblErrorMSG.AutoSize = true;
            this.lblErrorMSG.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorMSG.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMSG.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMSG.Location = new System.Drawing.Point(562, 369);
            this.lblErrorMSG.Name = "lblErrorMSG";
            this.lblErrorMSG.Size = new System.Drawing.Size(227, 42);
            this.lblErrorMSG.TabIndex = 11;
            this.lblErrorMSG.Text = "Error Message";
            this.lblErrorMSG.Visible = false;
            // 
            // tmRefreshScreen
            // 
            this.tmRefreshScreen.Interval = 3000;
            this.tmRefreshScreen.Tick += new System.EventHandler(this.tmRefreshScreen_Tick);
            // 
            // ordersTableAdapter1
            // 
            this.ordersTableAdapter1.ClearBeforeFill = true;
            // 
            // lblStationName
            // 
            this.lblStationName.AutoSize = true;
            this.lblStationName.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationName.Location = new System.Drawing.Point(3, 7);
            this.lblStationName.Name = "lblStationName";
            this.lblStationName.Size = new System.Drawing.Size(0, 45);
            this.lblStationName.TabIndex = 12;
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // panBottom
            // 
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 614);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(1360, 154);
            this.panBottom.TabIndex = 10;
            this.panBottom.Visible = false;
            // 
            // CustomerDisplayForm
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 768);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panBottom);
            this.Controls.Add(this.lblStationName);
            this.Controls.Add(this.lblErrorMSG);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pPreparing);
            this.Controls.Add(this.mgReady);
            this.Controls.Add(this.mgPreparing);
            this.DisplayHeader = false;
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerDisplayForm";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.ShowIcon = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Customer Display";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.CustomerDisplayForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomerDisplayForm_FormClosing);
            this.Load += new System.EventHandler(this.CustomerDisplay_Load);
            this.Enter += new System.EventHandler(this.CustomerDisplayForm_Enter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomerDisplayForm_KeyPress);
            this.pPreparing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgPreparing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgReady)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSOrderDataCompleted)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pPreparing;
        private System.Windows.Forms.PictureBox pictureBox3;
        private MetroFramework.Controls.MetroGrid mgPreparing;
        private MCKDSDataSet1 mCKDSDataSet1;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private MCKDSDataSet1TableAdapters.OrdersTableAdapter ordersTableAdapter;
        private MetroFramework.Controls.MetroGrid mgReady;
        private MCKDSOrderDataCompleted mCKDSOrderDataCompleted;
        private System.Windows.Forms.BindingSource ordersBindingSource1;
        private MCKDSOrderDataCompletedTableAdapters.OrdersTableAdapter ordersTableAdapter1;
        private System.Windows.Forms.Label lblErrorMSG;
        private System.Windows.Forms.Timer tmRefreshScreen;
        private System.Windows.Forms.Label lblStationName;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderID;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}