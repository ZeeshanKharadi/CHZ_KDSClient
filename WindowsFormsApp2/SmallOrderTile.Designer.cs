
namespace MCKDS
{
    partial class SmallOrderTile
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
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.lblSelectionTitle = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.lblOrderStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStatus.Location = new System.Drawing.Point(0, 99);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(174, 50);
            this.lblOrderStatus.TabIndex = 6;
            this.lblOrderStatus.Text = "Preparing";
            this.lblOrderStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOrderStatus.Click += new System.EventHandler(this.OrderCtl_Click);
            // 
            // lblSelectionTitle
            // 
            this.lblSelectionTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.lblSelectionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectionTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSelectionTitle.Name = "lblSelectionTitle";
            this.lblSelectionTitle.Size = new System.Drawing.Size(174, 3);
            this.lblSelectionTitle.TabIndex = 7;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.lblOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNo.ForeColor = System.Drawing.Color.White;
            this.lblOrderNo.Location = new System.Drawing.Point(0, 0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(168, 96);
            this.lblOrderNo.TabIndex = 5;
            this.lblOrderNo.Text = "9999";
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblOrderNo.Click += new System.EventHandler(this.OrderCtl_Click);
            // 
            // SmallOrderTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblSelectionTitle);
            this.Controls.Add(this.lblOrderStatus);
            this.Controls.Add(this.lblOrderNo);
            this.Name = "SmallOrderTile";
            this.Size = new System.Drawing.Size(174, 149);
            this.UseCustomBackColor = true;
            this.Click += new System.EventHandler(this.OrderCtl_Click);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OrderCtl_KeyPress);
            this.Resize += new System.EventHandler(this.SmallOrderTile_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.Label lblSelectionTitle;
        private System.Windows.Forms.Label lblOrderNo;
    }
}
