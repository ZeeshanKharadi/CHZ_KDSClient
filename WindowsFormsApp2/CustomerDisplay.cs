using System;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace MCKDS
{
    public partial class CustomerDisplayForm : MetroFramework.Forms.MetroForm
    {
        private clsCOMDataReader ComDataRead;
        private int iCurrentRowIndx;
        private string LastBumpOrderID;
        Thread AnimationGIF1;
        Thread AnimationGIF2;

        public const int NoOfOrders = 10;
        public CustomerDisplayForm()
        {
            InitializeComponent();
            //PlaceImages();
            ScreenComponentInitalization();
        }
        private void CustomerDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'mCKDSOrderDataCompleted.Orders' table. You can move, or remove it, as needed.
                this.ordersTableAdapter1.Fill(this.mCKDSOrderDataCompleted.Orders);
                // TODO: This line of code loads data into the 'mCKDSDataSet1.Orders' table. You can move, or remove it, as needed.
                this.ordersTableAdapter.Fill(this.mCKDSDataSet1.Orders);
                //Non Ready Orders
                ordersTableAdapter.Adapter.SelectCommand.CommandText = GetFilteredOrderQuery(false);
                this.ordersTableAdapter.Fill(this.mCKDSDataSet1.Orders);
                //Ready Orders
                ordersTableAdapter1.Adapter.SelectCommand.CommandText = GetFilteredOrderQuery(true);
                this.ordersTableAdapter1.Fill(this.mCKDSOrderDataCompleted.Orders);
                LoadBlankImage();
                SETGridHeight();



                tmRefreshScreen.Enabled = true;


            }
            catch (Exception ex)
            {
                ErrorMessageHandler("Unable to Connect KDS Server", ex);

            }
            LoadCOMPort();
        }

        private void LoadCOMPort()
        {
            try
            {
                ComDataRead = new clsCOMDataReader();
                ComDataRead.OpenPort();
                ComDataRead.comDataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comdata_read);
            }
            catch (Exception ex)
            {
                ErrorMessageHandler("Unable to Open COM Port", ex);

            }
        }
        private void mgReady_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (mgReady.CurrentRow != null)
                {

                    iCurrentRowIndx = mgReady.SelectedRows[0].Index;

                    if (mgReady.CurrentRow != null)
                        SetSelectedRow(iCurrentRowIndx);
                }
            }
            catch (Exception ex) { }
        }
        private void SetSelectedRow(int pIndex)
        {
            mgReady.CurrentCell = mgReady.Rows[pIndex].Cells[0];

        }

        private void GridRefresh()
        {

            int cIndex = iCurrentRowIndx;
            if (ReFillGrid())
            {
                try
                {
                    if (cIndex != 0)
                    {
                        //metroGrid1.CurrentRow.Index = iCurrentRowIndx;
                        mgReady.Rows[cIndex].Selected = true;
                        SetSelectedRow(cIndex);
                        iCurrentRowIndx = cIndex;
                    }
                }
                catch (Exception ex)
                {
                    iCurrentRowIndx = 0;
                }
            }

        }




        private bool ReFillGrid()
        {
            try
            {
                this.ordersTableAdapter1.Fill(this.mCKDSOrderDataCompleted.Orders);
                this.ordersTableAdapter.Fill(this.mCKDSDataSet1.Orders);

                SETGridHeight();
                LoadBlankImage();
                ClearMsgtoPanel();

                return true;
            }
            catch (System.Exception ex)
            {
                ErrorMessageHandler("Unable to Connect KDS Server", ex);
                return false;
            }

        }

        private void tmRefreshScreen_Tick(object sender, EventArgs e)
        {
            GridRefresh();

        }

        private void CustomerDisplayForm_KeyPress(object sender, KeyPressEventArgs e)
        {

            KeyMapping(e.KeyChar);

        }


        public void KeyMapping(char inputkey)
        {
            char KeyMappedData;

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
                    //InvokeKeyPress((Char)Keys.Up);
                    mgReady.Focus();
                    SendKeys.Send("{UP}");
                    break;
                case 'l':
                    //InvokeKeyPress((Char)Keys.Down);
                    mgReady.Focus();
                    SendKeys.Send("{DOWN}");
                    break;
                case 'm':
                    //RecallLastbumpOrder();
                    break;
                case 'n':
                case (char)Keys.Enter:
                case '-':
                    //Bump Order

                    bumpSelectedOrder();
                    break;
                case 'o':
                    break;
                case 'p':
                    break;
                default:
                    break;


            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //MessageBox.Show(keyData.ToString());
            ////capture up arrow key
            //if (keyData == Keys.Up)
            //{
            //    //MessageBox.Show("You pressed Up arrow key");
            //    return true;
            //}
            ////capture down arrow key
            //if (keyData == Keys.Down)
            //{
            //    //MessageBox.Show("You pressed Down arrow key");
            //    return true;
            //}
            //capture left arrow key
            //if (keyData == Keys.Left)
            //{
            //    KeyMapping((char)keyData);

            //    return true;
            //}
            //capture right arrow key
            //if (keyData == Keys.Enter)
            //{
            //    //KeyMapping((char)keyData);
            //    bumpSelectedOrder();

            //    return true;
            //}
            //if (keyData.ToString()=="-")
            //{
            //    //KeyMapping((char)keyData);
            //    bumpSelectedOrder();

            //    return true;
            //}
            return base.ProcessCmdKey(ref msg, keyData);

        }
        public void comdata_read(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            try
            {
                SerialPort sp = (SerialPort)sender;
                string value = sp.ReadExisting();

                KeyPressEventArgs ke = new KeyPressEventArgs(value[0]);
                //MessageBox.Show(ke.ToString());
                this.Invoke(new Action(() => this.OnKeyPress(ke)));
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }


        private void CustomerDisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ComDataRead != null)
                ComDataRead.close();
        }

        private void bumpSelectedOrder()
        {
            int NextStation = 4;
            if (iCurrentRowIndx >= 0)
            {
                if (mgReady.Rows.Count > 0)
                {
                    dbClass dbcls = new dbClass();
                    BumpImageShow();
                    if (dbcls.BumpOrder(getOrderID(iCurrentRowIndx), NextStation, ""))
                    {
                        int milliseconds = 200;
                        Thread.Sleep(milliseconds);
                        this.GridRefresh();

                    }
                    else
                    {
                        MessageBox.Show("Message: Unable to Bump Order");
                        int ms1 = 200;
                        Thread.Sleep(ms1);
                        SendKeys.SendWait("{Enter}");//or Esc


                        //ErrorMessageHandler("Unable to Bump Order",);
                    }
                }


            }
        }

        private string getOrderID(int pGridIndex)
        {
            // ((DataGridViewImageCell)gvFiles.Rows[row].Cells[1]).Value = Properties.Resources.Picture1

            return mgReady.Rows[pGridIndex].Cells["OrderID"].Value.ToString();

        }

        private string GetFilteredOrderQuery(bool isReady)
        {
            string OrderFilter;
            string SortingOrder;
            if (isReady)
            {
                OrderFilter = "OrderStatusID= 3";
                SortingOrder = "";
            }
            else
            {
                OrderFilter = "OrderStatusID not in (3,4)";
                SortingOrder = " desc";
            }
            string channelFilter = GetCurrScreenFilter();
            if (channelFilter != "")
                channelFilter = "and OrderType in (" + channelFilter + @")";
            else
                channelFilter = "";


            string Query = @"SELECT DISTINCT Top (8) right(OrderNo,4) OrderNo,OrderID, OrderType, OrderState, OrderStatus,OrderStatusID,min(CreatedOn) CreatedOn
                                  FROM Orders
                                  WHERE " + OrderFilter + @" " + channelFilter + @"
                                  Group by   OrderNo,OrderID, OrderType, OrderState, OrderStatus,OrderStatusID
                                  ORDER BY CreatedOn " + SortingOrder;
            //string Query = @"SELECT DISTINCT Top (8) right(OrderNo,4) OrderNo,OrderID, OrderType, OrderState, OrderStatus,OrderStatusID, CreatedOn
            //                      FROM Orders
            //                      WHERE " + OrderFilter + @" " + channelFilter + @"

            //                      ORDER BY CreatedOn " + SortingOrder;


            return Query;

        }

        private string GetCurrScreenFilter()
        {
            string StationName = "";
            string tmpStr = "";
            string filepath = @"Settings.txt";
            try
            {

                if (File.Exists(filepath))
                {
                    string[] lines = File.ReadAllLines(filepath);
                    StationName = lines[0].Substring(2, lines[0].Length - 2);
                    if (StationName != "")
                        lblStationName.Text = StationName;
                    else
                        lblStationName.Text = "";

                    char[] spearator2 = { ',' };
                    string[] channelslist = lines[2].Split(spearator2);

                    foreach (string line in channelslist)
                    {
                        if (line == "EAT IN")
                        {
                            tmpStr += tmpStr != "" ? tmpStr = "'EAT IN'" : tmpStr = "'EAT IN'";
                        }
                        else if (line == "EAT OUT")
                        {
                            tmpStr += tmpStr != "" ? tmpStr = ",'EAT OUT'" : tmpStr = "'EAT OUT'";
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
            }
            catch (System.Exception ex)
            {
                ErrorMessageHandler("Unable to read Screen Setting", ex);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return "";
            }
            return tmpStr;
        }
        private void SETGridHeight()
        {

            int _ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int h = 45; // GetNewXY(45, _ScreenHeight, false);

            int GridHeigh = (mgPreparing.RowCount - 0) * h;

            // if (GridHeigh>0 & GridHeigh<=450)
            mgPreparing.Height = GridHeigh;
            mgPreparing.BringToFront();


            int GridRHeigh = (mgReady.RowCount) * h;
            //mgReady.Font = mgPreparing.DefaultCellStyle.Font;
            // if (GridRHeigh > 0 & GridRHeigh <= 450)
            mgReady.Height = GridRHeigh;

            mgReady.BringToFront();
        }

        private void ScreenComponentInitalization()
        {

            int _ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int _ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            foreach (Control C in this.Controls)
            {

                C.Width = GetNewXY(C.Size.Width, _ScreenWidth, true);
                C.Height = GetNewXY(C.Size.Height, _ScreenHeight, false);

                C.Left = GetNewXY(C.Left, _ScreenWidth, true);
                C.Top = GetNewXY(C.Top, _ScreenHeight, false);

            }

        }

        private int GetNewXY(int cSize, int NewSize, bool xyFlag)
        {
            const int ScreenDesignwidth = 1366;
            const int ScreenDesignHeigh = 768;
            int DesignSize = (xyFlag) ? ScreenDesignwidth : ScreenDesignHeigh;
            int cNewSize = cSize;
            double ratio = Convert.ToDouble(cSize) / DesignSize;
            cNewSize = Convert.ToInt16(ratio * NewSize);


            return cNewSize;
        }

        private void ErrorMessageHandler(String Msg, Exception e)
        {
            WriteMsgtoPanel(Msg);
            //WritetoLogfile(Msg,e);
        }
        private void WriteMsgtoPanel(String Msg)
        {

            lblErrorMSG.Text = Msg;
            // lblErrorMSG.ForeColor=Color.FromArgb(50, Color.Red);
            lblErrorMSG.Visible = true;
        }
        private void ClearMsgtoPanel()
        {
            lblErrorMSG.Text = "";
            lblErrorMSG.Visible = false;

        }

        private void LoadBlankImage()
        {
            //for (int i = 0; i < mgReady.RowCount; i++)
            //    ((DataGridViewImageCell)mgReady.Rows[i].Cells["image"]).Value = global::MCKDS.Properties.Resources.BlankImageGrid;  //ResourceManager.GetObject("CIGif.gif");
        }
        private void BumpImageShow()
        {

            //tmRefreshScreen.Enabled = false;

           // ((DataGridViewImageCell)mgReady.Rows[iCurrentRowIndx].Cells[0]).Value = Properties.Resources.CheckedImageGreen;

            //drawGifImage();
            mgReady.Refresh();
            // int ms = 800;            Thread.Sleep(ms);
            //tmRefreshScreen.Enabled = true;
            //tmRefreshScreen.Start();
        }

        private void drawGifImage()
        {
            for (int i = 1; i < 10; i++)
            {
                int ms = 10;
                Thread.Sleep(ms);
                mgReady.InvalidateCell(0, iCurrentRowIndx);
                //mgReady.Rows[iCurrentRowIndx].Cells[0].Style.BackColor = Color.Red;
                mgReady.Refresh();
            }
        }

        private void mgReady_DoubleClick(object sender, EventArgs e)
        {
            KeyMapping('n');
        }

        private void mgReady_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustomerDisplayForm_Activated(object sender, EventArgs e)
        {
            mgReady.Focus();
        }

        private void CustomerDisplayForm_Enter(object sender, EventArgs e)
        {
            mgReady.Focus();
        }
    }
}