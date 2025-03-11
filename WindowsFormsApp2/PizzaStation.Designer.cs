
namespace MCKDS
{
    partial class PizzaStation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PizzaStation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.ITEMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAMEALIAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inHandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalMadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSoldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchEntryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pizzaStationTblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mCKDSBackUpDataSet6 = new MCKDS.MCKDSBackUpDataSet6();
            this.pizzaStation_TblTableAdapter = new MCKDS.MCKDSBackUpDataSet6TableAdapters.PizzaStation_TblTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pizzaStationTblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSBackUpDataSet6)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel1.BackgroundImage")));
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(13, 20);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(152, 100);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(188, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pizza Station";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToDeleteRows = false;
            this.metroGrid1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.metroGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.AutoGenerateColumns = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.ColumnHeadersHeight = 60;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEMID,
            this.NAMEALIAS,
            this.inHandDataGridViewTextBoxColumn,
            this.totalMadeDataGridViewTextBoxColumn,
            this.totalSoldDataGridViewTextBoxColumn,
            this.batchEntryDataGridViewTextBoxColumn,
            this.last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn,
            this.Batch2,
            this.Batch3});
            this.metroGrid1.DataSource = this.pizzaStationTblBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle4;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(13, 168);
            this.metroGrid1.MultiSelect = false;
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.metroGrid1.RowHeadersWidth = 9;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.metroGrid1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.metroGrid1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.metroGrid1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroGrid1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Silver;
            this.metroGrid1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gold;
            this.metroGrid1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.metroGrid1.RowTemplate.Height = 43;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(1284, 661);
            this.metroGrid1.TabIndex = 0;
            this.metroGrid1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_RowLeave);
            this.metroGrid1.SelectionChanged += new System.EventHandler(this.metroGrid1_SelectionChanged);
            this.metroGrid1.Enter += new System.EventHandler(this.metroGrid1_Enter);
            this.metroGrid1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metroGrid1_KeyUp);
            // 
            // ITEMID
            // 
            this.ITEMID.DataPropertyName = "ITEMID";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ITEMID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ITEMID.HeaderText = "ITEMID";
            this.ITEMID.MinimumWidth = 10;
            this.ITEMID.Name = "ITEMID";
            this.ITEMID.ReadOnly = true;
            this.ITEMID.Width = 120;
            // 
            // NAMEALIAS
            // 
            this.NAMEALIAS.DataPropertyName = "NAMEALIAS";
            this.NAMEALIAS.HeaderText = "Product";
            this.NAMEALIAS.Name = "NAMEALIAS";
            this.NAMEALIAS.ReadOnly = true;
            this.NAMEALIAS.Width = 250;
            // 
            // inHandDataGridViewTextBoxColumn
            // 
            this.inHandDataGridViewTextBoxColumn.DataPropertyName = "InHand";
            this.inHandDataGridViewTextBoxColumn.HeaderText = "InHand";
            this.inHandDataGridViewTextBoxColumn.Name = "inHandDataGridViewTextBoxColumn";
            this.inHandDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalMadeDataGridViewTextBoxColumn
            // 
            this.totalMadeDataGridViewTextBoxColumn.DataPropertyName = "TotalMade";
            this.totalMadeDataGridViewTextBoxColumn.HeaderText = "TotalMade";
            this.totalMadeDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.totalMadeDataGridViewTextBoxColumn.Name = "totalMadeDataGridViewTextBoxColumn";
            this.totalMadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalMadeDataGridViewTextBoxColumn.Width = 120;
            // 
            // totalSoldDataGridViewTextBoxColumn
            // 
            this.totalSoldDataGridViewTextBoxColumn.DataPropertyName = "TotalSold";
            this.totalSoldDataGridViewTextBoxColumn.HeaderText = "TotalSold";
            this.totalSoldDataGridViewTextBoxColumn.Name = "totalSoldDataGridViewTextBoxColumn";
            this.totalSoldDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalSoldDataGridViewTextBoxColumn.Width = 120;
            // 
            // batchEntryDataGridViewTextBoxColumn
            // 
            this.batchEntryDataGridViewTextBoxColumn.HeaderText = "BatchEntry";
            this.batchEntryDataGridViewTextBoxColumn.Name = "batchEntryDataGridViewTextBoxColumn";
            this.batchEntryDataGridViewTextBoxColumn.Width = 120;
            // 
            // last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn
            // 
            this.last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn.DataPropertyName = "Last4BatchShowWIthQtyAnfTime";
            this.last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn.HeaderText = "Batch 1";
            this.last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn.Name = "last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn";
            this.last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn.Width = 140;
            // 
            // Batch2
            // 
            this.Batch2.DataPropertyName = "Batch2";
            this.Batch2.HeaderText = "Batch2";
            this.Batch2.Name = "Batch2";
            this.Batch2.ReadOnly = true;
            this.Batch2.Width = 140;
            // 
            // Batch3
            // 
            this.Batch3.DataPropertyName = "Batch3";
            this.Batch3.HeaderText = "Batch3";
            this.Batch3.Name = "Batch3";
            this.Batch3.ReadOnly = true;
            this.Batch3.Width = 140;
            // 
            // pizzaStationTblBindingSource
            // 
            this.pizzaStationTblBindingSource.DataMember = "PizzaStation_Tbl";
            this.pizzaStationTblBindingSource.DataSource = this.mCKDSBackUpDataSet6;
            // 
            // mCKDSBackUpDataSet6
            // 
            this.mCKDSBackUpDataSet6.DataSetName = "MCKDSBackUpDataSet6";
            this.mCKDSBackUpDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pizzaStation_TblTableAdapter
            // 
            this.pizzaStation_TblTableAdapter.ClearBeforeFill = true;
            // 
            // PizzaStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 702);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroPanel1);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.KeyPreview = true;
            this.Name = "PizzaStation";
            this.Padding = new System.Windows.Forms.Padding(23, 120, 20, 20);
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PizzaStation_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PizzaStation_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pizzaStationTblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCKDSBackUpDataSet6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private MCKDSBackUpDataSet6 mCKDSBackUpDataSet6;
        private System.Windows.Forms.BindingSource pizzaStationTblBindingSource;
        private MCKDSBackUpDataSet6TableAdapters.PizzaStation_TblTableAdapter pizzaStation_TblTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAMEALIAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn inHandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSoldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchEntryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn last4BatchShowWIthQtyAnfTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch3;
    }
}