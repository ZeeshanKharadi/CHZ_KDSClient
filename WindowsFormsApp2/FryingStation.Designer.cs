
namespace MCKDS
{
    partial class FryingStation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FryingStation));
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedtoFry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CumulativeFriedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnHand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FriedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.friedItemDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cFriedQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mCKDSDataSet = new MCKDS.MCKDSDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.CurRow = new System.Windows.Forms.Label();
            this.CurrentTimePeriod = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmRefreshScreen = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblErrorMSG = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.itemTableAdapter1 = new MCKDS.MCKDSDataSetTableAdapters.ItemTableAdapter();
            this.tableAdapterManager1 = new MCKDS.MCKDSDataSetOrderTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToDeleteRows = false;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoGenerateColumns = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeight = 60;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.Unit,
            this.NeedtoFry,
            this.CumulativeFriedQty,
            this.OnHand,
            this.FriedQty,
            this.ItemId,
            this.friedItemDataGridViewCheckBoxColumn,
            this.cFriedQtyDataGridViewTextBoxColumn});
            this.metroGrid1.DataSource = this.itemBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle5;
            this.metroGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(23, 120);
            this.metroGrid1.MultiSelect = false;
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.metroGrid1.RowHeadersVisible = false;
            this.metroGrid1.RowHeadersWidth = 9;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.RowTemplate.Height = 43;
            this.metroGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(1257, 353);
            this.metroGrid1.TabIndex = 0;
            this.metroGrid1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_RowLeave);
            this.metroGrid1.SelectionChanged += new System.EventHandler(this.metroGrid1_SelectionChanged);
            this.metroGrid1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Grid_KeyPress);
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "PRODUCT";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 275;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "UOM";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 200;
            // 
            // NeedtoFry
            // 
            this.NeedtoFry.DataPropertyName = "NeedtoFry";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NeedtoFry.DefaultCellStyle = dataGridViewCellStyle2;
            this.NeedtoFry.HeaderText = "NEED";
            this.NeedtoFry.Name = "NeedtoFry";
            this.NeedtoFry.ReadOnly = true;
            this.NeedtoFry.ToolTipText = "Need to Fry item in current period";
            this.NeedtoFry.Visible = false;
            this.NeedtoFry.Width = 200;
            // 
            // CumulativeFriedQty
            // 
            this.CumulativeFriedQty.DataPropertyName = "CFriedQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CumulativeFriedQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.CumulativeFriedQty.HeaderText = "COOKED";
            this.CumulativeFriedQty.Name = "CumulativeFriedQty";
            this.CumulativeFriedQty.ReadOnly = true;
            this.CumulativeFriedQty.ToolTipText = "Cumulative Fried Qty in current Period";
            this.CumulativeFriedQty.Width = 220;
            // 
            // OnHand
            // 
            this.OnHand.DataPropertyName = "OnHand";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OnHand.DefaultCellStyle = dataGridViewCellStyle4;
            this.OnHand.HeaderText = "IN HAND";
            this.OnHand.Name = "OnHand";
            this.OnHand.ReadOnly = true;
            // 
            // FriedQty
            // 
            this.FriedQty.HeaderText = "FRIED";
            this.FriedQty.Name = "FriedQty";
            this.FriedQty.ToolTipText = "Currently Fried Quantity";
            this.FriedQty.Width = 230;
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.HeaderText = "ItemId";
            this.ItemId.Name = "ItemId";
            this.ItemId.Visible = false;
            // 
            // friedItemDataGridViewCheckBoxColumn
            // 
            this.friedItemDataGridViewCheckBoxColumn.DataPropertyName = "FriedItem";
            this.friedItemDataGridViewCheckBoxColumn.HeaderText = "FriedItem";
            this.friedItemDataGridViewCheckBoxColumn.Name = "friedItemDataGridViewCheckBoxColumn";
            this.friedItemDataGridViewCheckBoxColumn.Visible = false;
            // 
            // cFriedQtyDataGridViewTextBoxColumn
            // 
            this.cFriedQtyDataGridViewTextBoxColumn.DataPropertyName = "CFriedQty";
            this.cFriedQtyDataGridViewTextBoxColumn.HeaderText = "CFriedQty";
            this.cFriedQtyDataGridViewTextBoxColumn.Name = "cFriedQtyDataGridViewTextBoxColumn";
            this.cFriedQtyDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataMember = "Item";
            this.itemBindingSource.DataSource = this.mCKDSDataSet;
            // 
            // mCKDSDataSet
            // 
            this.mCKDSDataSet.DataSetName = "MCKDSDataSet";
            this.mCKDSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 55);
            this.label1.TabIndex = 6;
            this.label1.Text = "Frying Station";
            // 
            // CurRow
            // 
            this.CurRow.AutoSize = true;
            this.CurRow.Location = new System.Drawing.Point(788, 103);
            this.CurRow.Name = "CurRow";
            this.CurRow.Size = new System.Drawing.Size(63, 13);
            this.CurRow.TabIndex = 7;
            this.CurRow.Text = "CurrentRow";
            this.CurRow.Visible = false;
            // 
            // CurrentTimePeriod
            // 
            this.CurrentTimePeriod.AutoSize = true;
            this.CurrentTimePeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTimePeriod.Location = new System.Drawing.Point(916, 101);
            this.CurrentTimePeriod.Name = "CurrentTimePeriod";
            this.CurrentTimePeriod.Size = new System.Drawing.Size(138, 16);
            this.CurrentTimePeriod.TabIndex = 8;
            this.CurrentTimePeriod.Text = "CurrentTimePeriod";
            this.CurrentTimePeriod.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmRefreshScreen
            // 
            this.tmRefreshScreen.Enabled = true;
            this.tmRefreshScreen.Interval = 10000;
            this.tmRefreshScreen.Tick += new System.EventHandler(this.tmRefreshScreen_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(381, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Visible = false;
            // 
            // lblErrorMSG
            // 
            this.lblErrorMSG.AutoSize = true;
            this.lblErrorMSG.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMSG.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMSG.Location = new System.Drawing.Point(483, 364);
            this.lblErrorMSG.Name = "lblErrorMSG";
            this.lblErrorMSG.Size = new System.Drawing.Size(108, 42);
            this.lblErrorMSG.TabIndex = 10;
            this.lblErrorMSG.Text = "label2";
            this.lblErrorMSG.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(152, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Day";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel1.BackgroundImage")));
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(11, 12);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(87, 78);
            this.metroPanel1.TabIndex = 5;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // itemTableAdapter1
            // 
            this.itemTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = MCKDS.MCKDSDataSetOrderTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // FryingStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 493);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblErrorMSG);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CurrentTimePeriod);
            this.Controls.Add(this.CurRow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroGrid1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FryingStation";
            this.Padding = new System.Windows.Forms.Padding(23, 120, 20, 20);
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderGridForm_FormClosing);
            this.Load += new System.EventHandler(this.FryingStation_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FringStationForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CurRow;
        private System.Windows.Forms.Label CurrentTimePeriod;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer tmRefreshScreen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private MCKDSDataSetTableAdapters.ItemTableAdapter itemTableAdapter1;
        private MCKDSDataSet mCKDSDataSet;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.Label lblErrorMSG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MCKDSDataSetOrderTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeedtoFry;
        private System.Windows.Forms.DataGridViewTextBoxColumn CumulativeFriedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn OnHand;
        private System.Windows.Forms.DataGridViewTextBoxColumn FriedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn friedItemDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFriedQtyDataGridViewTextBoxColumn;
    }
}