using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace MCKDS
{
    public partial class CustomerStationCtl : MetroFramework.Forms.MetroForm
    {
        public SmallOrderTile[] ScreenDisplayOrder;
        private static SmallOrderTile ActiveOrderCtl;
        private clsCOMDataReader ComDataRead;

        public const int NoOfOrders = 24;
        public const int NoOfColums = 6;
        public const int NoOfRows = 4;
        public const int OrderSpaceHight = 60;
        public const int OrderSpaceWidth = 60;


        public CustomerStationCtl()
        {
            InitializeComponent();
        }

        private void CustomerStationCtl_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mCKDSDataSet3.Orders' table. You can move, or remove it, as needed.
           // this.ordersTableAdapter.Fill(this.mCKDSDataSet3.Orders);
            // TODO: This line of code loads data into the 'mCKDSDataSet2.Orders' table. You can move, or remove it, as needed.
            //this.ordersTableAdapter.Fill(this.mCKDSDataSet2.Orders);
            // TODO: This line of code loads data into the 'mCKDSDataSet1.Orders' table. You can move, or remove it, as needed.
           // this.ordersTableAdapter.Fill(this.mCKDSDataSetCustOrders.Orders);
            try
            {
                //// TODO: This line of code loads data into the 'mCKDSDataSetCustOrders.Orders' table. You can move, or remove it, as needed.
                //this.ordersTableAdapter.Fill(this.mCKDSDataSetCustOrders.Orders);
                //// TODO: This line of code loads data into the 'database1DataSet1.Orders' table. You can move, or remove it, as needed.
                this.ordersTableAdapter.Fill(this.mCKDSDataSet3.Orders);
                ReFillGrid();
                createOrderControls();
                poluateOrders();
                // Fullscreen();


                SetActiveOrdderCtl(ScreenDisplayOrder[0]);
                try
                {
                    /*---------Com Port Initialization --------------*/
                    ComDataRead = new clsCOMDataReader();
                    ComDataRead.OpenPort();
                    ComDataRead.comDataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comdata_read);
                    tmRefreshScreen.Enabled = true;
                }
                catch (Exception ex)
                {
                    ErrorMessageHandler("Unable to Open COM Port", ex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Unable to Connect to Database " + ex.Message);
            }
        }
        public void RefreshScreen()
        {

            ReFillGrid();
            poluateOrders();
        }
        public void comdata_read(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            try
            {
                SerialPort sp = (SerialPort)sender;
                string value = sp.ReadExisting();
                KeyMapping(value[0]);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void bumpActiveOrder()
        {
            int NextStation = 5;
            if (ActiveOrderCtl != null)
            {
                dbClass dbcls = new dbClass();

                if (ActiveOrderCtl.OrderStatus == "Ready")
                {

                    if (dbcls.BumpOrder(ActiveOrderCtl.OrderID, NextStation,""))
                    {
                        int milliseconds = 500;
                        Thread.Sleep(milliseconds);
                        this.RefreshScreen();

                    }
                    else
                    {
                        MessageBox.Show("Message: Unable to update");
                    }
                }
                else if (ActiveOrderCtl.OrderStatus == "Cancelled")
                {
                    if (dbcls.BumpOrder(ActiveOrderCtl.OrderID, NextStation,""))
                    {
                        int milliseconds = 500;
                        Thread.Sleep(milliseconds);
                        this.RefreshScreen();

                    }
                    else
                    {
                        MessageBox.Show("Message: Unable to update");
                    }
                }
            }
        }


        private void createOrderControls()
        {
            ScreenDisplayOrder = new SmallOrderTile[NoOfOrders];

            int counter = 0;
            int posX = 70;
            int posY = 20;
            //Generate tiles


            for (int i = 0; i < ScreenDisplayOrder.Length; i++)
            {
                ScreenDisplayOrder[i] = new SmallOrderTile();

            }
            //int _ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int _ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //int _ScreenWidth = 1280;
            int _ScreenHeight = 786;
            int height = (_ScreenHeight / NoOfRows) - 80;
            int width = (_ScreenWidth / NoOfColums) - 80;

            // MessageBox.Show(" Screen Width:" + _ScreenWidth + " ScrHeight:" + _ScreenHeight + " OrderHeight: " + height + " OrderWidth" + width);


            while (counter < NoOfOrders)
            {
                ScreenDisplayOrder[counter].Hide();
                ScreenDisplayOrder[counter].Tag = counter + 1;
                ScreenDisplayOrder[counter].Height = height;
                ScreenDisplayOrder[counter].Width = width;

                ScreenDisplayOrder[counter].Left = posX;
                ScreenDisplayOrder[counter].Top = posY;

                panOrders.Controls.Add(ScreenDisplayOrder[counter]);

                posX = posX + ScreenDisplayOrder[counter].Width + 40;
                if ((counter + 1) % NoOfColums == 0)
                {
                    posX = 70;
                    posY += height + 30;
                }

                ScreenDisplayOrder[counter].OrderCtlClick += new System.EventHandler(ctlOrderButtonHandler);
                ScreenDisplayOrder[counter].OrderCtleKeyPressed += new System.Windows.Forms.KeyPressEventHandler(ctlOrderKeyPressHandler);

                ScreenDisplayOrder[counter].Click += new System.EventHandler(ctlOrderButtonHandler);
                ScreenDisplayOrder[counter].DoubleClick += new System.EventHandler(ctlOrderDoubleClickHandler);
                ScreenDisplayOrder[counter].KeyPress += new System.Windows.Forms.KeyPressEventHandler(ctlOrderKeyPressHandler);

                counter++;
            }
        }

        private void ctlOrderKeyPressHandler(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("Message: " + sender.ToString()  +" Keypressed: " +e.KeyChar);
        }
        private void ctlOrderDoubleClickHandler(object sender, EventArgs e)
        {
            //op MessageBox.Show("Message: " + sender.ToString());
        }
        private void ctlOrderButtonHandler(object sender, EventArgs e)
        {
            //MessageBox.Show("Message: " + sender.ToString());


            SmallOrderTile selectedControl = sender as SmallOrderTile;
            SetActiveOrdderCtl(selectedControl);

        }
        struct clientRect
        {
            public Point location;
            public int width;
            public int height;
        };
        // this should be in the scope your class
        clientRect restore;
        bool fullscreen = false;
        private void CustomerStationForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                fullscreen = false;
                Fullscreen();

            }
        }
        void Fullscreen()
        {
            if (fullscreen == false)
            {
                this.restore.location = this.Location;
                this.restore.width = this.Width;
                this.restore.height = this.Height;
                this.TopMost = true;
                this.Location = new Point(0, 0);
                this.FormBorderStyle = FormBorderStyle.None;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
            }
            else
            {
                this.TopMost = false;
                this.Location = this.restore.location;
                this.Width = this.restore.width;
                this.Height = this.restore.height;
                // these are the two variables you may wish to change, depending
                // on the design of your form (WindowState and FormBorderStyle)
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
        public void poluateOrders()
        {
            int i = 0;
            foreach (DataGridViewRow row in OrderGrid.Rows)
            {
                if ((i < NoOfOrders) && (i + 1 < OrderGrid.Rows.Count))
                {
                    try
                    {
                        decimal Ordercount = Convert.ToDecimal(OrderGrid.Rows.Count.ToString()) - 1;
                        lblordercount.Text = Convert.ToString(Ordercount);
                        //Order ID mapping
                        ScreenDisplayOrder[i].OrderID = row.Cells[0].Value.ToString();
                        string OrderNo = row.Cells[2].Value.ToString();
                        if (OrderNo == "")
                            OrderNo = "00";
                        ScreenDisplayOrder[i].OrderNo = OrderNo;
                        ScreenDisplayOrder[i].OrderStatus = row.Cells[1].Value.ToString();
                        ScreenDisplayOrder[i].Tag = i;
                        ScreenDisplayOrder[i].Visible = true;

                        if (row.Cells[1].Value.ToString() == "Cancelled")
                        {
                            ScreenDisplayOrder[i].OrderStatus = row.Cells[1].Value.ToString();
                        }

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("error: " + exp.Message);
                    }
                }

                i++;

            }
            if (ActiveOrderCtl != null)
                ActiveOrderCtl.SelectedOrder(true);
            for (int j = i - 1; j < NoOfOrders; j++)
            {
                ScreenDisplayOrder[j].Visible = false;
                ScreenDisplayOrder[j].Tag = "";

            }

        }


        private void SetActiveOrdderCtl(SmallOrderTile SetActiveOrdderCtl)
        {

            if (SetActiveOrdderCtl.OrderNo != null)
            {
                SetDeactiveOrdderCtl();
                ActiveOrderCtl = SetActiveOrdderCtl;
                ActiveOrderCtl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                ActiveOrderCtl.SelectedOrder(true);
                ActiveOrderCtl.Focus();
                label2.Text = ActiveOrderCtl.OrderNo;



            }

        }
        private void SetDeactiveOrdderCtl()
        {

            if ((ActiveOrderCtl != null) && (ActiveOrderCtl.OrderNo != null))
            {
                ActiveOrderCtl.SelectedOrder(true);
                ActiveOrderCtl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }

        }

        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("error: Control Click Event");


            SmallOrderTile selectedControl = sender as SmallOrderTile;

            //selectedControl.cont
            //handle the event 
        }

        private void CustomerStationCtl_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyMapping(e.KeyChar);
        }


        public void KeyMapping(char inputkey)
        {
            switch (inputkey)
            {
                case 'a':
                    break;
                case 'b':
                    break;
                case 'c':
                    break;
                case 'd':
                    break;
                case 'e':
                    break;
                case 'f':
                    break;
                case 'g':
                    break;
                case 'h':
                    break;
                case 'i':
                    break;
                case 'j':
                    break;
                case 'k':
                    break;
                case 'l':
                    break;
                case 'm':
                    break;
                case 'n':
                    if (ActiveOrderCtl.Tag != null)
                        bumpActiveOrder();
                    break;
                case 'o':
                case (char)Keys.Left:
                    if ((int)ActiveOrderCtl.Tag > 0)
                        SetActiveOrdderCtl(ScreenDisplayOrder[(int)ActiveOrderCtl.Tag - 1]);
                    else
                         if (OrderGrid.RowCount > ScreenDisplayOrder.Length)
                        SetActiveOrdderCtl(ScreenDisplayOrder[ScreenDisplayOrder.Length - 1]);
                    else
                        SetActiveOrdderCtl(ScreenDisplayOrder[OrderGrid.RowCount - 2]);


                    break;
                case 'p':
                case (char)Keys.Right:
                    if ((ScreenDisplayOrder.Length - 1 > (int)ActiveOrderCtl.Tag) &
                            (OrderGrid.RowCount - 2 > (int)ActiveOrderCtl.Tag))
                        SetActiveOrdderCtl(ScreenDisplayOrder[(int)ActiveOrderCtl.Tag + 1]);
                    else
                        SetActiveOrdderCtl(ScreenDisplayOrder[0]);
                    break;

                case (char)Keys.Enter:
                    if (ActiveOrderCtl.Tag != null)
                        bumpActiveOrder();
                    break;
                default:
                    break;


            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                //MessageBox.Show("You pressed Up arrow key");
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                //MessageBox.Show("You pressed Down arrow key");
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                KeyMapping((char)keyData);

                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                KeyMapping((char)keyData);

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CustomerStationCtl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ComDataRead != null)
                ComDataRead.close();
            this.Dispose(true);
        }

        private void tmRefreshScreen_Tick(object sender, EventArgs e)
        {
            this.RefreshScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefreshScreen();
        }

        private bool ReFillGrid()
        {
            try
            {
                string StationName = "";
                string tmpStr = "";
                string PizzaStation = "";
                string filepath = @"Settings.txt";
                if (File.Exists(filepath))
                {
                    string[] lines = File.ReadAllLines(filepath);
                    StationName = lines[0].Substring(2, lines[0].Length - 2);
                    if (StationName != "")
                        lblStationName.Text = "(" + StationName + ")";
                    else
                        lblStationName.Text = "";

                    char[] spearator2 = { ',' };
                    string[] channelslist = lines[2].Split(spearator2);

                    foreach (string line in channelslist)
                    {
                        if (line == "DINE IN")
                        {
                            tmpStr += tmpStr != "" ? tmpStr = "'DINE IN'" : tmpStr = "'DINE IN'";
                        }
                        else if (line == "TAKE AWAY")
                        {
                            tmpStr += tmpStr != "" ? tmpStr = ",'TAKE AWAY'" : tmpStr = "'TAKE AWAY'";
                        }
                        else if (line == "DELIVERY")
                        {
                            tmpStr += tmpStr != "" ? tmpStr = ",'DELIVERY'" : tmpStr = "'DELIVERY'";
                        }
                        else if (line == "DRIVE THRU")
                        {
                            tmpStr += tmpStr != "" ? tmpStr = ",'DRIVE THRU'" : tmpStr = "'DRIVE THRU'";
                        }
                        else if (line == "EMPLOYEE MEAL")
                        {
                            tmpStr += tmpStr != "" ? tmpStr = ",'EMPLOYEE MEAL'" : tmpStr = "'EMPLOYEE MEAL'";
                        }
                    }
                }
                //add min(orderstatusid) dk
                string Query = @"SELECT DISTINCT OrderID,min(CreatedOn) CreatedOn, OrderType, OrderNo, OrderState,MIN(OrderStatusID) as OrderStatusID
                                  FROM Orders
                                  WHERE(OrderStatusID <> 5) and OrderType in (" + tmpStr + @")
                                   group by OrderID, OrderType, OrderNo, OrderState
                                  ORDER BY CreatedOn";

                //string Query = "SELECT DISTINCT [Orderid], OrderType, [CreatedOn], OrderStatus, OrderNo, CONVERT(varchar(8), DATEADD(SECOND, DATEDIFF(SECOND, CreatedOn, GETDATE()), 0), 114) OrderTime FROM Orders WHERE (OrderStatusid = 2) ORDER BY [CreatedOn]";
                ordersTableAdapter.Adapter.SelectCommand.CommandText = Query;
                this.ordersTableAdapter.Fill(this.mCKDSDataSet3.Orders);

                ClearMsgtoPanel();
                return true;
                
            }
            catch (System.Exception ex)
            {
                ErrorMessageHandler("Unable to Connect KDS Server", ex);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

        }


        private void ErrorMessageHandler(String Msg, Exception e)
        {
            //MessageBox.Show(Msg);
            WriteMsgtoPanel(Msg);
            //WritetoLogfile(Msg,e);
        }
        private void WriteMsgtoPanel(String Msg)
        {

            lblErrorMSG.Text = Msg;
            lblErrorMSG.Visible = true;
        }
        private void ClearMsgtoPanel()
        {
            lblErrorMSG.Text = "";
            lblErrorMSG.Visible = false;

        }

        private void OrderGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panTitle_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
