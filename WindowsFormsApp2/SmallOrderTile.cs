using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Drawing.Text;

namespace MCKDS
{
    public partial class SmallOrderTile : MetroFramework.Controls.MetroUserControl
    {
        public event EventHandler OrderCtlClick;
        public event KeyPressEventHandler OrderCtleKeyPressed;
        public string OrderID;

        public SmallOrderTile()
        {
            InitializeComponent();
            SmallOrderTileResizeFont();


        }
        public String OrderStatus
        {
            get
            {
                return lblOrderStatus.Text;
            }
            set
            {
                lblOrderStatus.Text = value;
                if (value == "Ready")
                {
                    lblOrderNo.BackColor = Color.FromArgb(163, 8, 12);
                    lblOrderNo.ForeColor = Color.White;
                    lblOrderStatus.BackColor = Color.Lime;
                    lblOrderStatus.ForeColor = Color.FromArgb(0, 0, 0);
                }
                else
                {
                    lblOrderNo.BackColor = Color.FromArgb(163, 8, 12);
                    lblOrderNo.ForeColor = Color.White;
                    lblOrderStatus.BackColor = Color.FromArgb(245, 212, 183);
                    lblOrderStatus.ForeColor = Color.Black;
                }


            }
        }
        public void SelectedOrder(Boolean status)
        {

            Color tempColor = lblOrderNo.BackColor;
            Color tempFont = lblOrderNo.ForeColor;
            //this.BorderStyle = BorderStyle.FixedSingle;
            lblOrderNo.BackColor = lblOrderStatus.BackColor;
            lblOrderNo.ForeColor = lblOrderStatus.ForeColor;
            lblOrderStatus.BackColor = tempColor;
            lblOrderStatus.ForeColor = tempFont;


        }
        public String OrderNo
        {
            get
            {
                return lblOrderNo.Text;
            }
            set
            {
                lblOrderNo.Text = value;
                string Length = lblOrderNo.Text.Substring(Math.Max(0, lblOrderNo.Text.Length - 4));
                lblOrderNo.Text = Length;

                if (Convert.ToInt32(Length) >= 4)
                {
                    int fsize = (int)Math.Round(this.Size.Width / 4.5, 0);
                    int fsizeStatus = (int)Math.Round(this.Size.Width / 7.5, 0);
                    lblOrderNo.Font = new Font(lblOrderNo.Font.Name, fsize);
                    lblOrderStatus.Font = new Font(lblOrderStatus.Font.Name, fsizeStatus);
                }
                else
                {
                    int fsize = (int)Math.Round(this.Size.Width / 3.8, 0);
                    int fsizeStatus = (int)Math.Round(this.Size.Width / 7.5, 0);
                    lblOrderNo.Font = new Font(lblOrderNo.Font.Name, fsize);
                    lblOrderStatus.Font = new Font(lblOrderStatus.Font.Name, fsizeStatus);
                }
            }
        }


        private void SmallOrderTile_Resize(object sender, EventArgs e)
        {
            SmallOrderTileResizeFont();
        }
        private void SmallOrderTileResizeFont()
        {
            //int fsize = (int)Math.Round(this.Size.Width / 3.8, 0);
            //int fsizeStatus = (int)Math.Round(this.Size.Width / 7.5, 0);
            //lblOrderNo.Font = new Font(lblOrderNo.Font.Name, fsize);
            //lblOrderStatus.Font = new Font(lblOrderStatus.Font.Name, fsizeStatus);


            //if (lblOrderStatus.Text == "Cancelled")
            //    lblOrderNo.Font = new Font(lblOrderNo.Font.Name, fsize, FontStyle.Strikeout);

        }

        protected void OrderCtl_Click(object sender, EventArgs e)
        {
            //MetroFramework.Controls.MetroUserControl selectedControl = sender as MetroFramework.Controls.MetroUserControl;

            //this.BorderStyle = BorderStyle.Fixed3D;
            //bubble the event up to the parent
            if (this.OrderCtlClick != null)
                this.OrderCtlClick(this, e);


        }
        protected void OrderCtl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //bubble the event up to the parent
            if (this.OrderCtleKeyPressed != null)
                this.OrderCtleKeyPressed(this, e);
        }
    }
}
