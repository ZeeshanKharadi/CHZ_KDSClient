using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.OleDb;
using System.Threading;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Configuration;

namespace MCKDS
{
    public partial class OrderGridForm : MetroFramework.Forms.MetroForm
    {
        dbClass dbcls = new dbClass();
        public enum ScreenSize { Screen2x3 = 6, Screen2x4 = 8 }
        public const int NoOfOrders = 8;
        public crlOrder[] ScreenDisplayOrder;
        private static crlOrder ActiveOrderCtl;
        private clsCOMDataReader ComDataRead;
        private string LastBumpedOrderId;

        string CurrentStationOrdersChannel;
        String CurrentStationType;
        int CurrentStation;
        int NextStation = 0;
        int PreviousStation = 0;
        int OrderStatusID = 0;
        public bool HideHoldOrder;
        public bool OrderPaging = false;
        int ThirdScreenOrderCount = 0;
        int NextOrder = 0;

        private string _stationtxt = "";
        public OrderGridForm()
        {
            InitializeComponent();
        }
        public OrderGridForm(String FormName, int stationid)
        {
            InitializeComponent();
            this.Text = FormName;
            this.lblFormTitle.Text = FormName;
            CurrentStation = stationid;
        }

        private void OrderGridForm_Load(object sender, EventArgs e)
        {
            try
            {
                PageNumTxt.Text = "Page No : " + "1";
                // CurrentStation = 1;
                // TODO: This line of code loads data into the 'mCKDSDataSetOrder1.Orders' table. You can move, or remove it, as needed.
                this.ordersTableAdapter.Fill(this.mCKDSDataSetOrder1.Orders);

                //if (this.Text == "Middle of House (MOH)") // preparation Station
                if (CurrentStation == 1) // preparation Station
                {
                    CurrentStation = 1;
                    LoadCurrentStationType();

                    //LoadCurrentStationOrdersType();


                    //chkHideHoldOrders.Visible = true;

                    ordersTableAdapter.Adapter.SelectCommand.CommandText = GetMOHQuery();
                    this.ordersTableAdapter.Fill(this.mCKDSDataSetOrder1.Orders);
                }
                else if (CurrentStation == 2)// Expedite Station
                {
                    CurrentStation = 2;
                    LoadCurrentStationOrdersType();
                    //LoadCurrentStationType();
                    chkHideHoldOrders.Visible = true;
                    ordersTableAdapter.Adapter.SelectCommand.CommandText = GetFOHQuery();
                    this.ordersTableAdapter.Fill(this.mCKDSDataSetOrder1.Orders);
                }
                else if (CurrentStation == 3) // Expedite2 Station FOh2
                {
                    CurrentStation = 3;
                    LoadCurrentStationOrdersType();
                    // LoadCurrentStationType();
                    chkHideHoldOrders.Visible = false;
                    ordersTableAdapter.Adapter.SelectCommand.CommandText = GetFOH2Query();
                    this.ordersTableAdapter.Fill(this.mCKDSDataSetOrder1.Orders);
                }
                createOrderControls();
                PopulateOrder();
                //Fullscreen();
                //SetActiveOrdderCtl(ScreenDisplayOrder[0]);

                ComDataRead = new clsCOMDataReader();
                ComDataRead.OpenPort();
                ComDataRead.comDataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comdata_read);
                tmrDataRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                ErrorMessageHandler("Unable to Connect KDS Server", ex);
            }

            //give me 5 mins

        }
        public void comdata_read(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            try
            {
                SerialPort sp = (SerialPort)sender;
                string value = sp.ReadExisting();

                KeyPressEventArgs ke = new KeyPressEventArgs(value[0]);
                this.Invoke(new Action(() => this.OnKeyPress(ke)));
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        private void SetActiveOrdderCtl(crlOrder pOrderCtl)
        {
            if (pOrderCtl.OrderNo != null)
            {
                SetDeactiveOrdderCtl();
                ActiveOrderCtl = pOrderCtl;

                ActiveOrderCtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;


                //ActiveOrderCtl.SelectedOrder(true);
                ActiveOrderCtl.Focus();
                lblCurrentOrderNo.Text = "Selected Order" + ActiveOrderCtl.OrderNo;

            }

        }
        private void SetActiveOrdderCtl(int pOrderIndex)
        {
            int Oindex = pOrderIndex;
            if ((Oindex >= 0) & (ScreenDisplayOrder[Oindex].Visible == true))
            {

                crlOrder currentOrder = ScreenDisplayOrder[Oindex];
                if (currentOrder.OrderNo != null)
                {
                    SetDeactiveOrdderCtl();
                    ActiveOrderCtl = currentOrder;

                    ActiveOrderCtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;


                    //ActiveOrderCtl.SelectedOrder(true);
                    ActiveOrderCtl.Focus();
                    lblCurrentOrderNo.Text = "Selected Order" + ActiveOrderCtl.OrderNo;
                }
            }
        }
        private string getOrderLines(string OrderId)
        {
            try
            {
                dbClass dbcls = new dbClass();
                DataSet d = dbcls.GetOrdersLines(OrderId, getStationCatFilter());
                return ConvertOrderdetailsToHTML(d.Tables[0]);
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        private void SetDeactiveOrdderCtl()
        {

            if ((ActiveOrderCtl != null) && (ActiveOrderCtl.OrderNo != null))
            {
                // ActiveOrderCtl.SelectedOrder(true);
                ActiveOrderCtl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }

        }
        private void OrderGridForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyMapping(e.KeyChar);
        }
        public void KeyMapping(char inputkey)
        {
            switch (inputkey)
            {
                case 'a':
                case '1':
                    SetActiveOrdderCtl(0);
                    break;
                case 'b':
                case '5':
                    SetActiveOrdderCtl(4);
                    break;
                case 'c':
                case '2':
                    SetActiveOrdderCtl(1);
                    break;
                case 'd':
                case '6':
                    SetActiveOrdderCtl(5);
                    break;
                case 'e':
                case '3':
                    SetActiveOrdderCtl(2);
                    break;
                case 'f':
                case '7':
                    SetActiveOrdderCtl(6);
                    break;
                case 'g':
                case '4':
                    SetActiveOrdderCtl(3);
                    break;
                case 'h':
                case '8':
                    SetActiveOrdderCtl(7);
                    break;
                case 'i':
                    break;
                case 'j':
                    if ((ActiveOrderCtl != null) && (ActiveOrderCtl.Tag != null) && (ActiveOrderCtl.Tag != ""))
                    {
                        if ((ScreenDisplayOrder.Length - 1 > (int)ActiveOrderCtl.Tag) &
                            (metroGrid1.RowCount - 1 > (int)ActiveOrderCtl.Tag))
                            SetActiveOrdderCtl(ScreenDisplayOrder[(int)ActiveOrderCtl.Tag + 1]);
                        else
                            SetActiveOrdderCtl(ScreenDisplayOrder[0]);

                    }
                    break;
                case 'k':
                    // case '8':
                    chkHideHoldOrders.Checked = !chkHideHoldOrders.Checked;
                    RefreshScreen();
                    break;
                case 'l':
                    break;
                case 'm':
                case '9':
                    RecallLastbumpOrder();
                    break;
                case 'n':
                case (char)Keys.Enter:
                    bumpActiveOrder();

                    break;
                case 'o':
                case (char)Keys.Left:
                case '/':
                    if ((ActiveOrderCtl != null) && (ActiveOrderCtl.Tag != null) && (ActiveOrderCtl.Tag != "") && ((int)ActiveOrderCtl.Tag > 0))

                        SetActiveOrdderCtl(ScreenDisplayOrder[(int)ActiveOrderCtl.Tag - 1]);
                    else
                        if (metroGrid1.RowCount > ScreenDisplayOrder.Length)
                        SetActiveOrdderCtl(ScreenDisplayOrder[ScreenDisplayOrder.Length - 1]);
                    else
                        SetActiveOrdderCtl(ScreenDisplayOrder[metroGrid1.RowCount - 1]);

                    break;
                case 'p':
                case (char)Keys.Right:
                case '*':
                    if ((ActiveOrderCtl != null) && (ActiveOrderCtl.Tag != null) && (ActiveOrderCtl.Tag != ""))
                    {
                        if ((ScreenDisplayOrder.Length - 1 > (int)ActiveOrderCtl.Tag) &
                            (metroGrid1.RowCount - 1 > (int)ActiveOrderCtl.Tag))
                            SetActiveOrdderCtl(ScreenDisplayOrder[(int)ActiveOrderCtl.Tag + 1]);
                        else
                            SetActiveOrdderCtl(ScreenDisplayOrder[0]);
                    }
                    break;
                case (char)Keys.PageDown:
                    //case '*':
                    OrderPaging = !OrderPaging;
                    PageNumTxt.Text = ("Page No : " + 2);
                    // bilal 
                    if (NextOrder == 8)
                    {
                        NextOrder = 8 * 2;
                        OrderPaging = true;
                        PageNumTxt.Text = ("Page No : " + 3);
                    }
                    else if (NextOrder == 16)
                    {
                        NextOrder = 0;
                        OrderPaging = false;
                        PageNumTxt.Text = ("Page No : " + 1);
                    }
                    //-----------------------------------
                    RefreshScreen();
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
            if (keyData == Keys.Divide)
            {
                KeyMapping((char)keyData);

                return true;
            }
            if (keyData == Keys.Multiply)
            {
                KeyMapping((char)keyData);

                return true;
            }
            if (keyData == Keys.NumPad1)
            {
                KeyMapping('1');



                return true;
            }
            if (keyData == Keys.NumPad2)
            {
                KeyMapping('2');



                return true;
            }
            if (keyData == Keys.NumPad3)
            {
                KeyMapping('3');



                return true;
            }
            if (keyData == Keys.NumPad4)
            {
                KeyMapping('4');



                return true;
            }
            if (keyData == Keys.NumPad5)
            {
                KeyMapping('5');



                return true;
            }
            if (keyData == Keys.NumPad6)
            {
                KeyMapping('6');



                return true;
            }
            if (keyData == Keys.NumPad7)
            {
                KeyMapping('7');


                return true;
            }
            if (keyData == Keys.NumPad8)
            {
                KeyMapping('8');
                return true;
            }

            if (keyData == Keys.NumPad9)
            {
                KeyMapping('9');
                return true;
            }

            if (keyData == Keys.Enter)
            {
                KeyMapping((char)Keys.Enter);
                return true;
            }

            if (keyData == Keys.PageDown)
            {
                KeyMapping((char)Keys.PageDown);
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
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
        private void Form2_Resize(object sender, EventArgs e)
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

        private void createOrderControls()
        {
            ScreenDisplayOrder = new crlOrder[NoOfOrders];
            const int OrderPadding = 25;
            int counter = 0;
            int posX = OrderPadding;
            int posY = 0;

            int _ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //int _ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int _ScreenHeight = 786;

            int height = (_ScreenHeight / 2) - 75;
            int width = (_ScreenWidth / 4) - 75;

            if (width < 266)
                width = 266;

            // MessageBox.Show(" Screen Width:" + _ScreenWidth + " ScrHeight:" + _ScreenHeight + " OrderHeight: " + height + " OrderWidth" + width);


            while (counter < NoOfOrders)
            {
                ScreenDisplayOrder[counter] = new crlOrder();

                ScreenDisplayOrder[counter].BorderStyle = System.Windows.Forms.BorderStyle.None;
                ScreenDisplayOrder[counter].Tag = counter + 1;
                ScreenDisplayOrder[counter].Height = height;
                ScreenDisplayOrder[counter].Width = width;

                ScreenDisplayOrder[counter].Left = posX;
                ScreenDisplayOrder[counter].Top = posY;

                panOrders.Controls.Add(ScreenDisplayOrder[counter]);
                posX = posX + ScreenDisplayOrder[counter].Width + OrderPadding;
                if ((counter + 1) % 4 == 0)
                {
                    posX = OrderPadding;
                    posY += height + OrderPadding;
                }

                ScreenDisplayOrder[counter].OrderCtlClick += new System.EventHandler(ctlOrderButtonHandler);
                ScreenDisplayOrder[counter].OrderCtleKeyPressed += new System.Windows.Forms.KeyPressEventHandler(OrderGridForm_KeyPress);
                ScreenDisplayOrder[counter].BumpOrderClick += new System.EventHandler(ctlOrderBumClickHandler);
                //ScreenDisplayOrder[counter].Click += new System.EventHandler(ctlOrderButtonHandler);
                //ScreenDisplayOrder[counter].Paint += new System.Windows.Forms.PaintEventHandler(OrderCtl_Paint);
                //ScreenDisplayOrder[counter].KeyPress += new System.Windows.Forms.KeyPressEventHandler(OrderGridForm_KeyPress);
                counter++;
            }
        }
        private void ctlOrderButtonHandler(object sender, EventArgs e)
        {
            //SetActiveOrdderCtl((crlOrder)sender);

            crlOrder OCtl = (crlOrder)sender;
            if ((ActiveOrderCtl != null) && (OCtl.Tag != ActiveOrderCtl.Tag))
            {
                SetActiveOrdderCtl(OCtl);
            }
        }
        private void ctlOrderBumClickHandler(object sender, EventArgs e)
        {
            crlOrder OCtl = (crlOrder)sender;
            if ((OCtl.Tag != null))
            {
                SetActiveOrdderCtl(OCtl);
                bumpActiveOrder();
            }
        }

        //// bilal section start ------------------------------------------------------------------------------------------------------ 
        //private int GetMohAndFohCount(string StationText)
        //{
        //    try
        //    {
        //        SqlConnection con = dbcls.Sql_Connection();
        //        string query = ""; 
        //        int Count = 0;
        //        if (StationText == "MOH")
        //        {
        //            query = "select COUNT( distinct OrderNo) OrderCount from Orders where OrderStatusID = 1";
        //        }
        //        else if (StationText == "ORDER ASSEMBLE")
        //        {
        //            query = "select COUNT( distinct OrderNo) OrderCount from Orders where OrderStatusID in(1,2)";
        //        }
        //        SqlDataAdapter sda = new SqlDataAdapter(query, con);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            Count = int.Parse(dt.Rows[0].ItemArray[0].ToString());
        //            return Count;
        //            //foreach ( DataRow value in dt.Rows )
        //            //{
        //            //    MessageBox.Show(value.ItemArray[0] + " ");
        //            //}
        //        }
        //        else
        //        {
        //            return Count;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + "");
        //    }
        //    return 0; 
        //    //
        //}

        private void ReFillMetroGrid(string StationText)
        {
            SqlConnection con = dbcls.Sql_Connection();
            string query = "";
            if (StationText == "MOH")
            {
                if (CurrentStationType == "Pizza")
                {
                    query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time , CONVERT(varchar(8),DATEADD(SECOND,DATEDIFF(SECOND, MIN(CreatedOn), GETDATE()), 0), 114) AS OrderTime 
                              from Orders where OrderStatusID = 1 and PizzaStation = 1 group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                }
                else if (CurrentStationType == "Pasta")
                {
                    query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time , CONVERT(varchar(8),DATEADD(SECOND,DATEDIFF(SECOND, MIN(CreatedOn), GETDATE()), 0), 114) AS OrderTime 
                              from Orders where OrderStatusID = 1 and PastaStation = 1 group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                }
                else if (CurrentStationType == "Sandwich")
                {
                    query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time , CONVERT(varchar(8),DATEADD(SECOND,DATEDIFF(SECOND, MIN(CreatedOn), GETDATE()), 0), 114) AS OrderTime 
                              from Orders where OrderStatusID = 1 and FriedStation = 1 group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                }
            }
            else if (StationText == "ORDER ASSEMBLE")
            {
                query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time , CONVERT(varchar(8),DATEADD(SECOND,DATEDIFF(SECOND, MIN(CreatedOn), GETDATE()), 0), 114) AS OrderTime
                          from Orders where OrderStatusID in(1,2) group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                //if (CurrentStationType == "Pizza")
                //{
                //    query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time from Orders where OrderStatusID in(1,2) and PizzaStation = 1
                //            group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                //}
                //else if (CurrentStationType == "Pasta")
                //{
                //    query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time from Orders where OrderStatusID in(1,2) and PastaStation = 1
                //            group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                //}
                //else if (CurrentStationType == "Sandwich")
                //{
                //    query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time from Orders where OrderStatusID in(1,2) and FriedStation = 1
                //            group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                //}
            }
            else if (StationText == "DISPATCH")
            {
                _stationtxt = StationText;
                query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time from Orders where OrderStatusID <= 3
                            group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                //if (CurrentStationType == "Pizza")
                //{
                //    query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time from Orders where OrderStatusID = 3 and PizzaStation = 1
                //            group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                //}
                //else if (CurrentStationType == "Pasta")
                //{
                //    query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time from Orders where OrderStatusID = 3 and PastaStation = 1
                //            group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                //}
                //else if (CurrentStationType == "Sandwich")
                //{
                //    query = @"select OrderID,OrderNo,OrderSource,CAST(createdon as time) time from Orders where OrderStatusID = 3 and FriedStation = 1
                //            group by OrderID,OrderNo ,OrderSource,CAST(createdon as time)";
                //}
            }

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                metroGrid1.DataSource = dt;
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    metroGrid1.Rows[index].Cells[0].Value = dt.Rows[index].ItemArray[0].ToString();
                    metroGrid1.Rows[index].Cells[1].Value = dt.Rows[index].ItemArray[1].ToString();
                    metroGrid1.Rows[index].Cells[2].Value = dt.Rows[index].ItemArray[2].ToString();
                    metroGrid1.Rows[index].Cells[3].Value = dt.Rows[index].ItemArray[3].ToString();
                }
            }
            else
            {
                metroGrid1.DataSource = dt;
            }
        }
        private string GetOrderType(string orderid)
        {
            string OrderTypeValue = "";
            SqlConnection con = dbcls.Sql_Connection();
            string query = "select OrderType from Orders where OrderId =@OrderId";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@OrderId", orderid);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                OrderTypeValue = dt.Rows[0].ItemArray[0].ToString();
            }
            return OrderTypeValue;
        }

        private string GetOrderStatus(string OrderId, string StationText)
        {
            string OrderStatus = "";
            SqlConnection con = dbcls.Sql_Connection();
            string query = "";
            if (StationText == "ORDER ASSEMBLE")
            {
                query = "select OrderStatus from Orders where OrderId =@OrderId and OrderStatusId = 1";
            }
            else
            {
                query = "select OrderStatus from Orders where OrderId =@OrderId";
            }

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@OrderId", OrderId);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr.ItemArray[0].ToString() == "Preparation")
                    {
                        OrderStatus = dr.ItemArray[0].ToString();
                    }

                }
            }
            return OrderStatus;
        }

        private DataTable GetLastBumpOrderId(string OrderId)
        {
            SqlConnection con = dbcls.Sql_Connection();
            SqlDataAdapter sda = new SqlDataAdapter("select OrderStatus,OrderStatusId from Orders where OrderId = @orderid", con);
            sda.SelectCommand.Parameters.AddWithValue("@orderid", OrderId);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        private string GetPreparingOrder(string OrderId)
        {
            string OrderStatusPrepare = "";
            try
            {
                SqlConnection con = dbcls.Sql_Connection();
                SqlDataAdapter sda = new SqlDataAdapter("select OrderStatus,OrderStatusId from Orders where OrderId = @orderid", con);
                sda.SelectCommand.Parameters.AddWithValue("@orderid", OrderId);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr.ItemArray[0].ToString() == "Preparation")
                        {
                            OrderStatusPrepare = dr.ItemArray[0].ToString();
                        }
                    }
                }
                return OrderStatusPrepare;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "");
            }
            return null;
        }

        private void ThirdScreenViewOrders(int thirdscreen)
        {
            int i = 0;
            string OrderId = "";
            string OrderNo = "";
            string time = "";
            string OrderSourceValue = "";
            string OrderType = "";
            for (int i1 = thirdscreen; i1 < metroGrid1.Rows.Count; i1++)
            // for (int i1 = NextOrder; i1 < count; i1++)
            {
                DataGridViewRow row = metroGrid1.Rows[i1];

                if (i < (4))
                {
                    //string TransactionT = row.Cells[6].Value.ToString();
                    ////if (this.Text == "Front of House (FOH)") // Expedite Station
                    //// bilal 
                    //if (this.Text == "ORDER ASSEMBLE")
                    //{
                    //    bool SuspendedOrderHold = false; //Forcefully Suspending Order
                    //    if (TransactionT == "36" && SuspendedOrderHold)
                    //    {
                    //        ScreenDisplayOrder[i].SetOrderOnHold = true;
                    //    }
                    //    else
                    //    {
                    //        ScreenDisplayOrder[i].SetOrderOnHold = false;
                    //    }
                    //}
                    //Order ID mapping
                    // comment do uncomment 
                    //DataGridViewCell OrderID = row.Cells[0];
                    //ScreenDisplayOrder[i].OrderID = row.Cells[4].Value.ToString();
                    //ScreenDisplayOrder[i].OrderNo = row.Cells[4].Value.ToString(); 
                    // -----------------------------------------------------------------

                    // bilal 
                    DataGridViewCell OrderIdCell = row.Cells[0]; // order id 
                    OrderId = OrderIdCell.Value.ToString(); // get order id 
                    DataGridViewCell OrderNoCell = row.Cells[1]; // order no 
                    OrderNo = OrderNoCell.Value.ToString(); // get order no 
                    ScreenDisplayOrder[i].OrderID = OrderId;
                    ScreenDisplayOrder[i].OrderNo = OrderNo;
                    //----------------------------------------------------------
                    //dgvc.Value.ToString();

                    //  DataGridViewCell OrderType = row.Cells[1];
                    //  ScreenDisplayOrder[i].OrderType = OrderType.Value.ToString();

                    // get order type 
                    //bilal -------
                    OrderType = GetOrderType(OrderId);
                    ScreenDisplayOrder[i].OrderType = OrderType;
                    //----------------------------------------------

                    var orderstatus = GetOrderStatus(OrderId, this.Text);

                    //if (row.Cells[2].Value != null)
                    //        ScreenDisplayOrder[i].OrderSource = getOrderSource(row.Cells[2].Value.ToString());
                    // bilal 
                    if (row.Cells[2].Value != null)
                        ScreenDisplayOrder[i].OrderSource = row.Cells[2].Value.ToString(); /* getOrderSource(row.Cells[2].Value.ToString());*/
                    //-----------------------------------------------------------------
                    //if (row.Cells[3].Value != null)
                    if (orderstatus != null)
                    {
                        //var orderstatus = row.Cells[3].Value.ToString();
                        //var orderstatusid = row.Cells[3].Value.ToString();
                        if (orderstatus == "Preparation" && (CurrentStation == 2 || CurrentStation == 3))
                        {
                            ScreenDisplayOrder[i].OrderBumpEnabled = false;
                            ScreenDisplayOrder[i].SetOrderOnHold = false;
                        }
                        else if (orderstatus == "Expeditor" && CurrentStation == 3)
                        {
                            ScreenDisplayOrder[i].OrderBumpEnabled = false;
                            //ScreenDisplayOrder[i].SetOrderOnHold = false;
                        }
                        else if (orderstatus == "Frying" && CurrentStation == 3)
                        {
                            ScreenDisplayOrder[i].OrderBumpEnabled = false;
                            //ScreenDisplayOrder[i].SetOrderOnHold = false;
                        }
                        else if (orderstatus == "Frying" && CurrentStation == 1)
                        {
                            ScreenDisplayOrder[i].OrderBumpEnabled = false;
                            //ScreenDisplayOrder[i].SetOrderOnHold = false;
                        }

                        else if (getOrderPreparedCompleted(ScreenDisplayOrder[i].OrderID) && CurrentStation == 2)
                        {
                            ScreenDisplayOrder[i].OrderBumpEnabled = true;
                            ScreenDisplayOrder[i].SetOrderOnHold = false;
                        }
                        else
                        {
                            ScreenDisplayOrder[i].OrderBumpEnabled = true;
                        }
                    }

                    // bilal 
                    //DataGridViewCell OrderTime = row.Cells[3];
                    //string dt = Convert.ToDateTime(OrderTime.Value).ToLongDateString();
                    /*
                     DataGridViewCell TimeCell = row.Cells[3];
                     time = TimeCell.Value.ToString();
                    */                                //----------------------------------------

                    //ScreenDisplayOrder[i].OrderTime = GetOrderTime(Convert.ToDateTime(OrderTime.Value.ToString())) + " min";



                    ScreenDisplayOrder[i].OrderTime = row.Cells[5].Value.ToString();

                    ScreenDisplayOrder[i].OrderBumped = false;
                    ScreenDisplayOrder[i].Enabled = true;
                    //if (getOrderLines(row.Cells[0].Value.ToString()) != null)
                    //{
                    //    ScreenDisplayOrder[i].Visible = true;
                    //}
                    //else
                    //{
                    //    ScreenDisplayOrder[i].Visible = false;
                    //}
                    ScreenDisplayOrder[i].Tag = i;
                    //orderPreparation time..

                    //ScreenDisplayOrder[i].OrderPreparationTimeLimt = getorderPreparationTime((bool)row.Cells["PizzaStation"].Value, (bool)row.Cells["PastaStation"].Value, (bool) row.Cells["FriedStation"].Value);
                    ScreenDisplayOrder[i].OrderPreparationTimeLimt = getorderPreparationMaxTime(ScreenDisplayOrder[i].OrderID);

                    //var status = row.Cells[10].Value.ToString();

                    //if (status == "1" || status == "0")
                    //    ScreenDisplayOrder[i].SetOrderBlink = true;


                    //else
                    //{
                    //    ScreenDisplayOrder[i].SetOrderBlink = false;
                    //}
                    // 
                    ScreenDisplayOrder[i].OrderDetails = getOrderLines(row.Cells[0].Value.ToString());
                    ScreenDisplayOrder[i].Visible = true;
                    //if ( ScreenDisplayOrder[i].OrderDetails != null)
                    //{
                    //    ScreenDisplayOrder[i].Visible = true;
                    //}
                    //else
                    //{
                    //    ScreenDisplayOrder[i].Visible = false;
                    //}
                    i++;
                }
            }


        }


        //------------------------------------ bilal section end 

        public void PopulateOrder()
        {
            // bilal 
            int count = 0;
            string OrderId = "";
            string OrderNo = "";
            string time = "";
            string OrderSourceValue = "";
            string OrderType = "";
            //-----------------end bilal section 
            //int OrderPage=NoOfOrders* Page;

            int i = 0; // int NextOrder = 0;
            if (OrderPaging)
            {
                if (metroGrid1.Rows.Count < 8)
                {
                    OrderPaging = false; return;
                }
                else
                {
                    if (NextOrder == 16)
                    {
                        NextOrder = 16;
                        //PageNumTxt.Text += "3";
                        //PageNumTxt.Text = ("Page No : " + 3);
                    }
                    else
                    {
                        NextOrder = 8;
                        //PageNumTxt.Text = ("Page No : " + 2);
                    }
                    //ThirdScreenOrderCount = 0;
                }
            }
            if (ScreenDisplayOrder == null) return;

            //if (ActiveOrderCtl != null)
            //    lblCurrentOrderNo.Text = "Selected Order " + ActiveOrderCtl.OrderNo;

            // bilal 
            //count = GetMohAndFohCount(this.Text);
            //MessageBox.Show(metroGrid1.Rows.Count + "");
            //for(int rowIndex = 0; rowIndex < metroGrid1.Rows.Count; rowIndex++)
            //{
            //    DataGridViewRow row = metroGrid1.Rows[rowIndex];

            //    DataGridViewCell OrderIdCell = metroGrid1.Rows[rowIndex].Cells[0]; // order id 
            //    OrderId = OrderIdCell.Value.ToString(); // get order id 
            //    DataGridViewCell OrderNoCell = metroGrid1.Rows[rowIndex].Cells[1]; // order no 
            //    OrderNo = OrderNoCell.Value.ToString(); // get order no 
            //    DataGridViewCell OrderSourcecell = metroGrid1.Rows[rowIndex].Cells[2]; // order source 
            //    OrderSourceValue = OrderSourcecell.Value.ToString(); // get order source

            //    DataGridViewCell TimeCell = metroGrid1.Rows[rowIndex].Cells[3]; // time 
            //    time = TimeCell.Value.ToString(); // get time
            //    OrderType = GetOrderType(OrderId);

            //    //MessageBox.Show("Order Id" + " " + metroGrid1.Rows[rowIndex].Cells[0].Value.ToString() + "\n" + 
            //    //                "Order No" + " " + metroGrid1.Rows[rowIndex].Cells[1].Value.ToString() + "\n" +
            //    //                "Order Source" +" "+ metroGrid1.Rows[rowIndex].Cells[2].Value.ToString() + "\n" + 
            //    //                "Time" + " " + metroGrid1.Rows[rowIndex].Cells[3].Value.ToString());
            //}
            // bilal
            ReFillMetroGrid(this.Text);
            //if (metroGrid1.Rows.Count == 1)
            //{
            //}
            //else
            //{

            //}
            lblTotalOrder.Text = "Total Orders " + metroGrid1.Rows.Count;  //GetMohAndFohCount(this.Text);  
            if (NextOrder == 0) //start 8 order 
            {
                for (int i1 = NextOrder; i1 < metroGrid1.Rows.Count; i1++)
                // for (int i1 = NextOrder; i1 < count; i1++)
                {
                    DataGridViewRow row = metroGrid1.Rows[i1];

                    if (i < (NoOfOrders))
                    {
                        //string TransactionT = row.Cells[6].Value.ToString();
                        ////if (this.Text == "Front of House (FOH)") // Expedite Station
                        //// bilal 
                        //if (this.Text == "ORDER ASSEMBLE")
                        //{
                        //    bool SuspendedOrderHold = false; //Forcefully Suspending Order
                        //    if (TransactionT == "36" && SuspendedOrderHold)
                        //    {
                        //        ScreenDisplayOrder[i].SetOrderOnHold = true;
                        //    }
                        //    else
                        //    {
                        //        ScreenDisplayOrder[i].SetOrderOnHold = false;
                        //    }
                        //}
                        //Order ID mapping
                        // comment do uncomment 
                        //DataGridViewCell OrderID = row.Cells[0];
                        //ScreenDisplayOrder[i].OrderID = row.Cells[4].Value.ToString();
                        //ScreenDisplayOrder[i].OrderNo = row.Cells[4].Value.ToString(); 
                        // -----------------------------------------------------------------

                        // bilal 
                        DataGridViewCell OrderIdCell = row.Cells[0]; // order id 
                        OrderId = OrderIdCell.Value.ToString(); // get order id 
                        DataGridViewCell OrderNoCell = row.Cells[1]; // order no 
                        OrderNo = OrderNoCell.Value.ToString(); // get order no 
                        ScreenDisplayOrder[i].OrderID = OrderId;
                        ScreenDisplayOrder[i].OrderNo = OrderNo;
                        //----------------------------------------------------------
                        //dgvc.Value.ToString();

                        //  DataGridViewCell OrderType = row.Cells[1];
                        //  ScreenDisplayOrder[i].OrderType = OrderType.Value.ToString();

                        // get order type 
                        //bilal -------
                        OrderType = GetOrderType(OrderId);
                        ScreenDisplayOrder[i].OrderType = OrderType;
                        //----------------------------------------------

                        var orderstatus = GetOrderStatus(OrderId, this.Text);

                        //if (row.Cells[2].Value != null)
                        //        ScreenDisplayOrder[i].OrderSource = getOrderSource(row.Cells[2].Value.ToString());
                        // bilal 
                        if (row.Cells[2].Value != null)
                            ScreenDisplayOrder[i].OrderSource = row.Cells[2].Value.ToString(); /* getOrderSource(row.Cells[2].Value.ToString());*/
                        //-----------------------------------------------------------------
                        //if (row.Cells[3].Value != null)
                        if (orderstatus != null)
                        {
                            //var orderstatus = row.Cells[3].Value.ToString();
                            //var orderstatusid = row.Cells[3].Value.ToString();
                            if (orderstatus == "Preparation" && (CurrentStation == 2 || CurrentStation == 3))
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else if (orderstatus == "Expeditor" && CurrentStation == 3)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                //ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else if (orderstatus == "Frying" && CurrentStation == 3)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                //ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else if (orderstatus == "Frying" && CurrentStation == 1)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                //ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }

                            else if (getOrderPreparedCompleted(ScreenDisplayOrder[i].OrderID) && CurrentStation == 2)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = true;
                                ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = true;
                            }
                        }

                        // bilal 
                        //DataGridViewCell OrderTime = row.Cells[2];
                        //string dt = Convert.ToDateTime(OrderTime.Value).ToLongDateString();
                        //DataGridViewCell TimeCell = row.Cells[3]; // time 
                        //time = TimeCell.Value.ToString();

                        // get time
                        //----------------------------------------

                        //ScreenDisplayOrder[i].OrderTime = GetOrderTime(Convert.ToDateTime(OrderTime.Value.ToString())) + " min";



                        //ScreenDisplayOrder[i].OrderTime = row.Cells[5].Value.ToString();
                        //if (ScreenDisplayOrder[i] != null && row?.Cells?[5]?.Value != null)
                        //{
                        //    ScreenDisplayOrder[i].OrderTime = row.Cells[5].Value.ToString();
                        //}

                        if (_stationtxt == "DISPATCH")
                        {
                            ScreenDisplayOrder[i].OrderTime = row.Cells[3].Value.ToString();
                        }
                        else
                        {
                            ScreenDisplayOrder[i].OrderTime = row.Cells[5].Value.ToString();
                        }



                        ScreenDisplayOrder[i].OrderBumped = false;
                        ScreenDisplayOrder[i].Enabled = true;
                        //if (getOrderLines(row.Cells[0].Value.ToString()) != null)
                        //{
                        //    ScreenDisplayOrder[i].Visible = true;
                        //}
                        //else
                        //{
                        //    ScreenDisplayOrder[i].Visible = false;
                        //}
                        ScreenDisplayOrder[i].Tag = i;
                        //orderPreparation time..

                        //ScreenDisplayOrder[i].OrderPreparationTimeLimt = getorderPreparationTime((bool)row.Cells["PizzaStation"].Value, (bool)row.Cells["PastaStation"].Value, (bool) row.Cells["FriedStation"].Value);
                        ScreenDisplayOrder[i].OrderPreparationTimeLimt = getorderPreparationMaxTime(ScreenDisplayOrder[i].OrderID);

                        //var status = row.Cells[10].Value.ToString();

                        //if (status == "1" || status == "0")
                        //    ScreenDisplayOrder[i].SetOrderBlink = true;


                        //else
                        //{
                        //    ScreenDisplayOrder[i].SetOrderBlink = false;
                        //}
                        // 
                        ScreenDisplayOrder[i].OrderDetails = getOrderLines(row.Cells[0].Value.ToString());
                        ScreenDisplayOrder[i].Visible = true;
                        //if ( ScreenDisplayOrder[i].OrderDetails != null)
                        //{
                        //    ScreenDisplayOrder[i].Visible = true;
                        //}
                        //else
                        //{
                        //    ScreenDisplayOrder[i].Visible = false;
                        //}
                        i++;
                    }
                }
            }
            else if (NextOrder == 8) // next 8 orders
            {
                for (int i1 = NextOrder; i1 < metroGrid1.Rows.Count; i1++)
                // for (int i1 = NextOrder; i1 < count; i1++)
                {
                    DataGridViewRow row = metroGrid1.Rows[i1];

                    if (i < (NoOfOrders))
                    {
                        //string TransactionT = row.Cells[6].Value.ToString();
                        ////if (this.Text == "Front of House (FOH)") // Expedite Station
                        //// bilal 
                        //if (this.Text == "ORDER ASSEMBLE")
                        //{
                        //    bool SuspendedOrderHold = false; //Forcefully Suspending Order
                        //    if (TransactionT == "36" && SuspendedOrderHold)
                        //    {
                        //        ScreenDisplayOrder[i].SetOrderOnHold = true;
                        //    }
                        //    else
                        //    {
                        //        ScreenDisplayOrder[i].SetOrderOnHold = false;
                        //    }
                        //}
                        //Order ID mapping
                        // comment do uncomment 
                        //DataGridViewCell OrderID = row.Cells[0];
                        //ScreenDisplayOrder[i].OrderID = row.Cells[4].Value.ToString();
                        //ScreenDisplayOrder[i].OrderNo = row.Cells[4].Value.ToString(); 
                        // -----------------------------------------------------------------

                        // bilal 
                        DataGridViewCell OrderIdCell = row.Cells[0]; // order id 
                        OrderId = OrderIdCell.Value.ToString(); // get order id 
                        DataGridViewCell OrderNoCell = row.Cells[1]; // order no 
                        OrderNo = OrderNoCell.Value.ToString(); // get order no 
                        ScreenDisplayOrder[i].OrderID = OrderId;
                        ScreenDisplayOrder[i].OrderNo = OrderNo;
                        //----------------------------------------------------------
                        //dgvc.Value.ToString();

                        //  DataGridViewCell OrderType = row.Cells[1];
                        //  ScreenDisplayOrder[i].OrderType = OrderType.Value.ToString();

                        // get order type 
                        //bilal -------
                        OrderType = GetOrderType(OrderId);
                        ScreenDisplayOrder[i].OrderType = OrderType;
                        //----------------------------------------------

                        var orderstatus = GetOrderStatus(OrderId, this.Text);

                        //if (row.Cells[2].Value != null)
                        //        ScreenDisplayOrder[i].OrderSource = getOrderSource(row.Cells[2].Value.ToString());
                        // bilal 
                        if (row.Cells[2].Value != null)
                            ScreenDisplayOrder[i].OrderSource = row.Cells[2].Value.ToString(); /* getOrderSource(row.Cells[2].Value.ToString());*/
                        //-----------------------------------------------------------------
                        //if (row.Cells[3].Value != null)
                        if (orderstatus != null)
                        {
                            //var orderstatus = row.Cells[3].Value.ToString();
                            //var orderstatusid = row.Cells[3].Value.ToString();
                            if (orderstatus == "Preparation" && (CurrentStation == 2 || CurrentStation == 3))
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else if (orderstatus == "Expeditor" && CurrentStation == 3)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                //ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else if (orderstatus == "Frying" && CurrentStation == 3)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                //ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else if (orderstatus == "Frying" && CurrentStation == 1)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                //ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }

                            else if (getOrderPreparedCompleted(ScreenDisplayOrder[i].OrderID) && CurrentStation == 2)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = true;
                                ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = true;
                            }
                        }

                        // bilal 
                        //DataGridViewCell OrderTime = row.Cells[2];
                        //string dt = Convert.ToDateTime(OrderTime.Value).ToLongDateString();
                        DataGridViewCell TimeCell = row.Cells[3]; // time 
                        time = TimeCell.Value.ToString(); // get time
                                                          //----------------------------------------

                        //ScreenDisplayOrder[i].OrderTime = GetOrderTime(Convert.ToDateTime(OrderTime.Value.ToString())) + " min";



                        ScreenDisplayOrder[i].OrderTime = row.Cells[4].Value.ToString();

                        ScreenDisplayOrder[i].OrderBumped = false;
                        ScreenDisplayOrder[i].Enabled = true;
                        //if (getOrderLines(row.Cells[0].Value.ToString()) != null)
                        //{
                        //    ScreenDisplayOrder[i].Visible = true;
                        //}
                        //else
                        //{
                        //    ScreenDisplayOrder[i].Visible = false;
                        //}
                        ScreenDisplayOrder[i].Tag = i;
                        //orderPreparation time..

                        //ScreenDisplayOrder[i].OrderPreparationTimeLimt = getorderPreparationTime((bool)row.Cells["PizzaStation"].Value, (bool)row.Cells["PastaStation"].Value, (bool) row.Cells["FriedStation"].Value);
                        ScreenDisplayOrder[i].OrderPreparationTimeLimt = getorderPreparationMaxTime(ScreenDisplayOrder[i].OrderID);

                        //var status = row.Cells[10].Value.ToString();

                        //if (status == "1" || status == "0")
                        //    ScreenDisplayOrder[i].SetOrderBlink = true;


                        //else
                        //{
                        //    ScreenDisplayOrder[i].SetOrderBlink = false;
                        //}
                        // 
                        ScreenDisplayOrder[i].OrderDetails = getOrderLines(row.Cells[0].Value.ToString());
                        ScreenDisplayOrder[i].Visible = true;
                        //if ( ScreenDisplayOrder[i].OrderDetails != null)
                        //{
                        //    ScreenDisplayOrder[i].Visible = true;
                        //}
                        //else
                        //{
                        //    ScreenDisplayOrder[i].Visible = false;
                        //}
                        i++;
                    }
                }
            }
            else if (NextOrder == 16) // third next orders
            {
                for (int i1 = NextOrder; i1 < metroGrid1.Rows.Count; i1++)
                // for (int i1 = NextOrder; i1 < count; i1++)
                {
                    DataGridViewRow row = metroGrid1.Rows[i1];

                    if (i < (NoOfOrders))
                    {
                        //string TransactionT = row.Cells[6].Value.ToString();
                        ////if (this.Text == "Front of House (FOH)") // Expedite Station
                        //// bilal 
                        //if (this.Text == "ORDER ASSEMBLE")
                        //{
                        //    bool SuspendedOrderHold = false; //Forcefully Suspending Order
                        //    if (TransactionT == "36" && SuspendedOrderHold)
                        //    {
                        //        ScreenDisplayOrder[i].SetOrderOnHold = true;
                        //    }
                        //    else
                        //    {
                        //        ScreenDisplayOrder[i].SetOrderOnHold = false;
                        //    }
                        //}
                        //Order ID mapping
                        // comment do uncomment 
                        //DataGridViewCell OrderID = row.Cells[0];
                        //ScreenDisplayOrder[i].OrderID = row.Cells[4].Value.ToString();
                        //ScreenDisplayOrder[i].OrderNo = row.Cells[4].Value.ToString(); 
                        // -----------------------------------------------------------------

                        // bilal 
                        DataGridViewCell OrderIdCell = row.Cells[0]; // order id 
                        OrderId = OrderIdCell.Value.ToString(); // get order id 
                        DataGridViewCell OrderNoCell = row.Cells[1]; // order no 
                        OrderNo = OrderNoCell.Value.ToString(); // get order no 
                        ScreenDisplayOrder[i].OrderID = OrderId;
                        ScreenDisplayOrder[i].OrderNo = OrderNo;
                        //----------------------------------------------------------
                        //dgvc.Value.ToString();

                        //  DataGridViewCell OrderType = row.Cells[1];
                        //  ScreenDisplayOrder[i].OrderType = OrderType.Value.ToString();

                        // get order type 
                        //bilal -------
                        OrderType = GetOrderType(OrderId);
                        ScreenDisplayOrder[i].OrderType = OrderType;
                        //----------------------------------------------

                        var orderstatus = GetOrderStatus(OrderId, this.Text);

                        //if (row.Cells[2].Value != null)
                        //        ScreenDisplayOrder[i].OrderSource = getOrderSource(row.Cells[2].Value.ToString());
                        // bilal 
                        if (row.Cells[2].Value != null)
                            ScreenDisplayOrder[i].OrderSource = row.Cells[2].Value.ToString(); /* getOrderSource(row.Cells[2].Value.ToString());*/
                        //-----------------------------------------------------------------
                        //if (row.Cells[3].Value != null)
                        if (orderstatus != null)
                        {
                            //var orderstatus = row.Cells[3].Value.ToString();
                            //var orderstatusid = row.Cells[3].Value.ToString();
                            if (orderstatus == "Preparation" && (CurrentStation == 2 || CurrentStation == 3))
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else if (orderstatus == "Expeditor" && CurrentStation == 3)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                //ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else if (orderstatus == "Frying" && CurrentStation == 3)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                //ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else if (orderstatus == "Frying" && CurrentStation == 1)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = false;
                                //ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }

                            else if (getOrderPreparedCompleted(ScreenDisplayOrder[i].OrderID) && CurrentStation == 2)
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = true;
                                ScreenDisplayOrder[i].SetOrderOnHold = false;
                            }
                            else
                            {
                                ScreenDisplayOrder[i].OrderBumpEnabled = true;
                            }
                        }

                        // bilal 
                        //DataGridViewCell OrderTime = row.Cells[2];
                        //string dt = Convert.ToDateTime(OrderTime.Value).ToLongDateString();
                        DataGridViewCell TimeCell = row.Cells[3]; // time 
                        time = TimeCell.Value.ToString(); // get time
                                                          //----------------------------------------

                        //ScreenDisplayOrder[i].OrderTime = GetOrderTime(Convert.ToDateTime(OrderTime.Value.ToString())) + " min";



                        ScreenDisplayOrder[i].OrderTime = time; //row.Cells[5].Value.ToString();

                        ScreenDisplayOrder[i].OrderBumped = false;
                        ScreenDisplayOrder[i].Enabled = true;
                        //if (getOrderLines(row.Cells[0].Value.ToString()) != null)
                        //{
                        //    ScreenDisplayOrder[i].Visible = true;
                        //}
                        //else
                        //{
                        //    ScreenDisplayOrder[i].Visible = false;
                        //}
                        ScreenDisplayOrder[i].Tag = i;
                        //orderPreparation time..

                        //ScreenDisplayOrder[i].OrderPreparationTimeLimt = getorderPreparationTime((bool)row.Cells["PizzaStation"].Value, (bool)row.Cells["PastaStation"].Value, (bool) row.Cells["FriedStation"].Value);
                        ScreenDisplayOrder[i].OrderPreparationTimeLimt = getorderPreparationMaxTime(ScreenDisplayOrder[i].OrderID);

                        //var status = row.Cells[10].Value.ToString();

                        //if (status == "1" || status == "0")
                        //    ScreenDisplayOrder[i].SetOrderBlink = true;


                        //else
                        //{
                        //    ScreenDisplayOrder[i].SetOrderBlink = false;
                        //}
                        // 
                        ScreenDisplayOrder[i].OrderDetails = getOrderLines(row.Cells[0].Value.ToString());
                        ScreenDisplayOrder[i].Visible = true;
                        //if ( ScreenDisplayOrder[i].OrderDetails != null)
                        //{
                        //    ScreenDisplayOrder[i].Visible = true;
                        //}
                        //else
                        //{
                        //    ScreenDisplayOrder[i].Visible = false;
                        //}
                        i++;
                    }
                }
            }




            // foreach (DataGridViewRow row in metroGrid1.Rows)


            for (int j = i; j < NoOfOrders; j++)
            {
                ScreenDisplayOrder[j].Visible = false;
                ScreenDisplayOrder[j].Tag = "";

            }


            // MessageBox.Show("Data: " + OrderDetails);
        }

        private string getOrderSource(String pOrderSource)
        {
            string OrderDetails = pOrderSource;
            string[] OrderSourcedetails = pOrderSource.Split(';');
            if (OrderSourcedetails.Length > 1)
            {
                string TPID = OrderSourcedetails[1].Replace("ThirdPartyOrder:", "");
                string TP = OrderSourcedetails[2].Replace("Source: ", "");
                OrderDetails = TP + ":" + TPID;
            }
            return OrderDetails;
        }
        public static string ConvertOrderdetailsToHTML(DataTable dt)
        {
            string OrderScource = "";
            string State = "";
            string html = @"<table style=font-family:Calibri;font-size:14px;>";
            html += "<b>" + OrderScource + "</b>";
            //add header row
            html += "<tr style=font-weight:bold;>";
            for (int i = 0; i < 2; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                State = dt.Rows[i][3].ToString();
                if (State == "Cancelled")
                {
                    html += @"<tr style=text-decoration:line-through;vertical-align:top;>";
                    for (int j = 0; j < 2; j++)
                        html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                    html += "</tr>";
                }
                else
                {
                    if ((int)dt.Rows[i]["OrderStatusid"] >= 2)
                        html += "<tr  style=color:Green;vertical-align:top; >";
                    else
                        html += "<tr style=vertical-align:top;>";

                    for (int j = 0; j < 2; j++)
                        html += "<td >" + dt.Rows[i][j].ToString() + "</td>";
                    html += "</tr>";
                }
            }
            html += "</table>";
            return html;
        }
        private String GetOrderTime(DateTime pOrderTime)
        {

            String OrderTime;
            OrderTime = Math.Round(DateTime.Now.Subtract(pOrderTime).TotalMinutes, 2).ToString();

            OrderTime = OrderTime.Replace(".", ":");
            return OrderTime;

        }
        public void RefreshScreen()
        {
            dbClass dbcls = new dbClass();

            if (ReFillGrid())
            {
                PopulateOrder();
                bool orderstate = dbcls.ResetBlinkingOrders();
            }
        }

        private void bumpActiveOrder()
        {
            string PrepareStatus = "";
            if (ActiveOrderCtl != null)
            {
                dbClass dbcls = new dbClass();
                OrderStatusID = dbcls.GetOrderStatusID(ActiveOrderCtl.OrderID, CurrentStation);
                if ((CurrentStation == 2 && OrderStatusID == 1) || (CurrentStation == 3 && OrderStatusID == 2) || (CurrentStation == 3 && OrderStatusID == 1) || (CurrentStation == 3 && OrderStatusID == 0))
                {
                    return;
                }

                string orderstate = dbcls.GetOrderState(ActiveOrderCtl.OrderID, CurrentStation);

                if (orderstate != "Cancelled")
                { OrderStatusID = dbcls.GetOrderStatusID(ActiveOrderCtl.OrderID, CurrentStation); }
                else { OrderStatusID = 6; }
                int TransactionType = dbcls.GetTransactionType(ActiveOrderCtl.OrderID, CurrentStation);
                //Suspending Order Routing option addes
                if (TransactionType == 2 || TransactionType == 36 || TransactionType == 33)
                {
                    //bilal 
                    //ActiveOrderCtl.OrderBumped = true;

                    if (orderstate != "Cancelled")
                    { OrderStatusID = dbcls.GetOrderStatusID(ActiveOrderCtl.OrderID, CurrentStation); }
                    else { OrderStatusID = 6; }

                    string values = dbcls.GetConfiguration(3);
                    char[] spearator = { ',' };
                    // bilal 
                    string[] stationslist = values.Split(spearator);
                    NextStation = GetNextStation(stationslist, OrderStatusID);


                    // bilal 
                    PrepareStatus = this.GetPreparingOrder(ActiveOrderCtl.OrderID);
                    if (PrepareStatus == "Preparation" && this.Text != "ORDER ASSEMBLE")
                    {
                        ActiveOrderCtl.OrderBumped = true;

                        if (dbcls.BumpOrder(ActiveOrderCtl.OrderID, NextStation, getStationCatFilter()))
                        {
                            //int milliseconds = 100;
                            //Thread.Sleep(milliseconds);
                            LastBumpedOrderId = ActiveOrderCtl.OrderID;
                            if (metroGrid1.Rows.Count == 1 && this.Text == "MOH")
                            {
                                //DataTable data = this.GetLastBumpOrderId(LastBumpedOrderId);
                                //if (data.Rows.Count > 0)
                                //{
                                //    MessageBox.Show(data.Rows[0].ItemArray[0].ToString() + " " + data.Rows[0].ItemArray[0].ToString());

                                //}
                                this.ReFillMetroGrid(this.Text);
                                //MessageBox.Show( metroGrid1.Rows.Count + "");
                            }
                            this.RefreshScreen();
                        }
                        else
                        {
                            MessageBox.Show("Message: Unable to update");
                        }
                    }
                    if (PrepareStatus != "Preparation" && this.Text == "ORDER ASSEMBLE")
                    {
                        ActiveOrderCtl.OrderBumped = true;

                        if (dbcls.BumpOrder(ActiveOrderCtl.OrderID, NextStation, getStationCatFilter()))
                        {
                            //int milliseconds = 100;
                            //Thread.Sleep(milliseconds);
                            LastBumpedOrderId = ActiveOrderCtl.OrderID;

                            this.RefreshScreen();
                        }
                        else
                        {
                            MessageBox.Show("Message: Unable to update");
                        }
                    }
                    if (PrepareStatus != "Preparation" && this.Text == "DISPATCH")
                    {
                        ActiveOrderCtl.OrderBumped = true;

                        if (dbcls.BumpOrder(ActiveOrderCtl.OrderID, NextStation, getStationCatFilter()))
                        {
                            //int milliseconds = 100;
                            //Thread.Sleep(milliseconds);
                            LastBumpedOrderId = ActiveOrderCtl.OrderID;

                            this.RefreshScreen();
                        }
                        else
                        {
                            MessageBox.Show("Message: Unable to update");
                        }
                    }

                }

                else if (TransactionType == 36 && OrderStatusID == 1)
                {
                    ActiveOrderCtl.OrderBumped = true;

                    if (orderstate != "Cancelled")
                    { OrderStatusID = dbcls.GetOrderStatusID(ActiveOrderCtl.OrderID, CurrentStation); }
                    else { OrderStatusID = 6; }
                    string values = dbcls.GetConfiguration(3);
                    char[] spearator = { ',' };
                    string[] stationslist = values.Split(spearator);
                    NextStation = GetNextStation(stationslist, OrderStatusID);

                    if (dbcls.BumpOrder(ActiveOrderCtl.OrderID, NextStation, getStationCatFilter()))
                    {
                        int milliseconds = 700;
                        Thread.Sleep(milliseconds);
                        LastBumpedOrderId = ActiveOrderCtl.OrderID;
                        this.RefreshScreen();
                    }
                    else
                    {
                        MessageBox.Show("Message: Unable to update");
                    }
                }
                else if (TransactionType == 36 && orderstate == "Cancelled")
                {
                    ActiveOrderCtl.OrderBumped = true;
                    string values = dbcls.GetConfiguration(3);
                    char[] spearator = { ',' };
                    string[] stationslist = values.Split(spearator);

                    NextStation = GetNextStation(stationslist, 5);

                    if (dbcls.BumpOrder(ActiveOrderCtl.OrderID, NextStation, getStationCatFilter()))
                    {
                        int milliseconds = 700;
                        Thread.Sleep(milliseconds);
                        LastBumpedOrderId = ActiveOrderCtl.OrderID;
                        this.RefreshScreen();
                    }
                    else
                    {
                        MessageBox.Show("Message: Unable to update");
                    }
                }
                else
                {

                }
            }
        }
        private void RecallLastbumpOrder()
        {
            if (LastBumpedOrderId != null)
            {
                //ActiveOrderCtl.OrderRecall = true;

                dbClass dbcls = new dbClass();
                OrderStatusID = dbcls.GetOrderStatusID(LastBumpedOrderId, CurrentStation);
                string values = dbcls.GetConfiguration(3);
                char[] spearator = { ',' };
                string[] stationslist = values.Split(spearator);

                PreviousStation = GetPreviousStation(stationslist, OrderStatusID);

                if (dbcls.ReCallLastOrder(LastBumpedOrderId, PreviousStation))
                {
                    int milliseconds = 100;
                    Thread.Sleep(milliseconds);
                    LastBumpedOrderId = null;
                    this.RefreshScreen();

                }
                else
                {
                    MessageBox.Show("Message: Unable to recall Last Order");
                }
            }

        }
        private void btnRefreshScreen_Click(object sender, EventArgs e)
        {
            //RefreshScreen();

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            RefreshScreen();
        }
        private void OrderGridForm_Shown(object sender, EventArgs e)
        {
            RefreshScreen();
            if (ScreenDisplayOrder != null)
                SetActiveOrdderCtl(ScreenDisplayOrder[0]);

        }
        private void OrderGridForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ComDataRead != null)
                ComDataRead.close();
            this.Dispose(true);

        }

        private bool ReFillGrid()
        {
            try
            {
                if (this.Text == "MOH")
                {
                    //ReFillMetroGrid(this.Text);
                    PopulateOrder();
                }
                if (this.Text == "Front of House (FOH)") // Expedite Station
                {
                    ordersTableAdapter.Adapter.SelectCommand.CommandText = GetFOHQuery();
                    //ReFillMetroGrid();
                }
                if (this.Text == "Front of House - 2 (FOH2)") // Expedite Station foh2
                {
                    ordersTableAdapter.Adapter.SelectCommand.CommandText = GetFOH2Query();
                }

                this.ordersTableAdapter.Fill(this.mCKDSDataSetOrder1.Orders);
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

        public int GetNextStation(string[] Values, int CurrentStationID)
        {
            try
            {
                int NS = CurrentStationID + 1;
                // bilal 
                NextStation = NS; //Convert.ToInt32(Values[NS]);
                return NextStation;
            }
            catch (Exception)
            {
                return NextStation = 4;
            }
        }

        public int GetPreviousStation(string[] Values, int OrderStatus)
        {
            try
            {
                int NS = OrderStatus - 1;
                if (NS >= 1)
                {
                    //NS = NS - 1;
                    PreviousStation = Convert.ToInt32(Values[NS]);
                }
                return PreviousStation;
            }
            catch (Exception)
            {
                return PreviousStation;
            }
        }


        private void chkHideHoldOrders_CheckedChanged(object sender, EventArgs e)
        {
            HideHoldOrder = chkHideHoldOrders.Checked;
            SetHoldImage();

            RefreshScreen();
        }
        private void LoadCurrentStationType()
        {
            string tmpStr = "";
            CurrentStationType = "";
            string StationName = "";

            string filepath = @"Settings.txt";
            if (File.Exists(filepath))
            {
                string[] lines = File.ReadAllLines(filepath);
                StationName = lines[0].Substring(2, lines[0].Length - 2);
                lblCustomStationName.Text = StationName;

                lblCustomStationName.Visible = false;
                if (StationName != "")
                    lblFormTitle.Text = StationName;

                CurrentStationType = lines[4].Substring(2, lines[4].Length - 2);

            }
        }

        private void LoadCurrentStationOrdersType()
        {
            string tmpStr = "";
            CurrentStationOrdersChannel = "";
            string StationName = "";
            string filepath = @"Settings.txt";
            if (File.Exists(filepath))
            {
                string[] lines = File.ReadAllLines(filepath);
                StationName = lines[0].Substring(2, lines[0].Length - 2);

                lblCustomStationName.Text = StationName;
                lblCustomStationName.Visible = true;

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
                CurrentStationOrdersChannel = tmpStr;
            }
        }


        private string GetFOHQuery()
        {
            string HideOnHoldOrdersQuery = "";
            string FOHQuery = "";

            if (HideHoldOrder)
            {
                HideOnHoldOrdersQuery = " and (isnull(OnHold,0) <>1)";
            }

            FOHQuery = @"SELECT Orderid, OrderType, MIN(TransactionType) as TransactionType, SUBSTRING(OrderSource, 0, 100) AS OrderSource, MIN(CreatedOn) as CreatedOn, OrderNo, CONVERT(varchar(8),
                         DATEADD(SECOND, DATEDIFF(SECOND, MIN(CreatedOn), GETDATE()), 0), 114) OrderTime ,OrderState,  MIN(NextOrderStatus) as NextOrderStatus,min(OrderStatusID)OrderStatusID,(select top 1 OrderStatus from OrderStatus t where t.OrderStatusId=min(Orders.OrderStatusId)) OrderStatus
                         FROM Orders WHERE OrderStatusid <= 2  " + HideOnHoldOrdersQuery + @"and OrderType in (" + CurrentStationOrdersChannel + @")
                         Group BY[Orderid], OrderType, OrderSource,  OrderNo, OrderState
                         ORDER BY MIN(CreatedOn)";
            return FOHQuery;

            //SELECT Orderid, OrderType, MIN(TransactionType) as TransactionType, SUBSTRING(OrderSource, 0, 100) AS OrderSource, MIN(CreatedOn) as CreatedOn, OrderStatus, OrderNo, CONVERT(varchar(8),
            //                DATEADD(SECOND, DATEDIFF(SECOND, MIN(CreatedOn), GETDATE()), 0), 114) OrderTime ,OrderState, OrderStatusID , MIN(NextOrderStatus) as NextOrderStatus
            //                FROM Orders WHERE OrderStatusid in (1, 2) " + HideOnHoldOrdersQuery + @"and OrderType in (" + CurrentStationOrdersChannel + @")
            //                Group BY[Orderid], OrderType, OrderSource, OrderStatus, OrderNo, OrderState, OrderStatusID, OrderStatusID
            //                ORDER BY MIN(CreatedOn)

        }
        //dk
        private string GetFOH2Query()
        {
            string HideOnHoldOrdersQuery = "";
            string FOH2Query = "";


            if (HideHoldOrder)
            {
                HideOnHoldOrdersQuery = " and (isnull(OnHold,0) <>1)";
            }

            FOH2Query = @"SELECT Orderid, OrderType, MIN(TransactionType) as TransactionType, SUBSTRING(OrderSource, 0, 100) AS OrderSource, MIN(CreatedOn) as CreatedOn, OrderNo, CONVERT(varchar(8),
                            DATEADD(SECOND, DATEDIFF(SECOND, MIN(CreatedOn), GETDATE()), 0), 114) OrderTime ,OrderState,  MIN(NextOrderStatus) as NextOrderStatus,min(OrderStatusID)OrderStatusID,(select top 1 OrderStatus from OrderStatus t where t.OrderStatusId=min(Orders.OrderStatusId)) OrderStatus
                            FROM Orders WHERE OrderStatusId<=3  " + HideOnHoldOrdersQuery + @"and OrderType in (" + CurrentStationOrdersChannel + @")
                            Group BY[Orderid], OrderType, OrderSource,  OrderNo, OrderState
                            ORDER BY MIN(CreatedOn)";
            return FOH2Query;

        }

        private string GetMOHQuery()
        {
            //routing to pizza ,Pasta,sandwich ..

            string MOHQuery = "";

            string StationCatFilter = getStationCatFilter();
            //MOHQuery = @"SELECT Orderid, OrderType, MIN(TransactionType) as TransactionType, SUBSTRING(OrderSource, 0, 100) AS OrderSource, MIN(CreatedOn) as CreatedOn, OrderStatus, OrderNo, CONVERT(varchar(8),
            //                DATEADD(SECOND, DATEDIFF(SECOND, MIN(CreatedOn), GETDATE()), 0), 114) OrderTime ,OrderState, OrderStatusID , MIN(NextOrderStatus) as NextOrderStatus ,PizzaStation, PastaStation,FriedStation,LineDescription1,LineDescription2
            //                FROM Orders WHERE OrderStatusid in (1,2) " + StationCatFilter + @"
            //                Group BY[Orderid], OrderType, OrderSource, OrderStatus, OrderNo, OrderState, OrderStatusID,PizzaStation, PastaStation,FriedStation,LineDescription1,LineDescription2
            //                ORDER BY MIN(CreatedOn)";

            MOHQuery = @"SELECT PreparingOrders.OrderID, PreparingOrders.OrderType, MIN(PreparingOrders.CreatedOn) AS CreatedOn, PreparingOrders.OrderNo,  CONVERT(varchar(8), DATEADD(SECOND,
                         DATEDIFF(SECOND, MIN(PreparingOrders.CreatedOn), GETDATE()), 0), 114) AS OrderTime, MIN(ord.TransactionType) AS TransactionType, SUBSTRING(ord.OrderSource, 0, 100) AS OrderSource,
						 ord.HDSOrderId,min(OrderStatusID)OrderStatusID,(select top 1 OrderStatus from OrderStatus t where t.OrderStatusId=min(Ord.OrderStatusId)) OrderStatus
 
                         ,MIN(ord.NextOrderStatus) AS NextOrderStatus
                            FROM(SELECT        OrderID, OrderType, MIN(CreatedOn) AS CreatedOn, OrderNo, COUNT(OrderID) AS itemCount,
                                                        (SELECT        COUNT(OrderID) AS preparingitemCount
                                                          FROM            Orders
                                                          WHERE(OrderID = ord.OrderID" + StationCatFilter + @")) AS OrdCount
                          FROM Orders AS ord
                          WHERE(OrderStatusID in( 0,1) " + StationCatFilter + @") 
                          GROUP BY OrderID, OrderType, OrderNo) AS PreparingOrders INNER JOIN
                         Orders AS ord ON ord.OrderID = PreparingOrders.OrderID
                            WHERE(PreparingOrders.itemCount = PreparingOrders.OrdCount) " + StationCatFilter + @" and (PizzaStation !='0' OR PastaStation!='0' OR FriedStation!='0' )  
                             GROUP BY PreparingOrders.OrderID, PreparingOrders.OrderType, PreparingOrders.OrderNo,  ord.OrderSource, ord.HDSOrderId,ord.OrderState
                            ORDER BY CreatedOn";
            return MOHQuery;

        }
        private string getStationCatFilter()
        {

            String StationCatFilter = "";

            if (CurrentStationType == "Pizza")
            {
                StationCatFilter = " and PizzaStation = 1";
            }
            else if (CurrentStationType == "Pasta")
            {
                StationCatFilter = " and PastaStation = 1";
            }
            if (CurrentStationType == "Sandwich")
            {
                StationCatFilter = " and FriedStation = 1";
            }
            if (CurrentStation == 1) //MOH only show the order lines having status 1 only
            {

                StationCatFilter += " and Orderstatusid in (0,1)";
            }
            else if (CurrentStation == 2) //FOH only show the order lines having status 2 or Less only
            {

                StationCatFilter += " and Orderstatusid<=2";
            }
            else if (CurrentStation == 3) //FOH2 only show the order lines having status 3 or less only
            {

                StationCatFilter += " and Orderstatusid <= 3";
            }


            return StationCatFilter;
        }

        //var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //var filename = Path.Combine(directory, "Images", "Pause_1.png");
        private void SetHoldImage()
        {
            if (HideHoldOrder)
            {

                ResourceManager rm = new ResourceManager("MCKDS.OrderGridForm", Assembly.GetExecutingAssembly());
                System.Drawing.Image myImage = (System.Drawing.Image)rm.GetObject("Pause_1");
                chkHideHoldOrders.BackgroundImage = myImage;
                chkHideHoldOrders.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                ResourceManager rm = new ResourceManager("MCKDS.OrderGridForm", Assembly.GetExecutingAssembly());
                System.Drawing.Image myImage = (System.Drawing.Image)rm.GetObject("Pause_2");
                chkHideHoldOrders.BackgroundImage = myImage;
                chkHideHoldOrders.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        //orderpreparationtime ..
        private int getorderPreparationTime(bool pPizza, bool pPasta, bool pSandwich)
        {
            try
            {
                dbClass clsdb = new dbClass();
                string orderProductCat = "";
                if (pPasta) orderProductCat = "Pizza";
                else if (pPizza) orderProductCat = "Pasta";
                else if (pSandwich) orderProductCat = "Sandwich";
                if (orderProductCat == "")
                    return clsdb.GetOrderPreparationTime(orderProductCat);

            }
            catch (Exception e) { }
            return 3;
        }

        public int getorderPreparationMaxTime(string Orderid)
        {
            try
            {
                dbClass clsdb = new dbClass();

                return clsdb.GetOrderPreparationMaxTime(Orderid);

            }
            catch (Exception e) { return 2; }


        }
        private bool getOrderPreparedCompleted(string pOrderid)
        {
            try
            {
                dbClass clsdb = new dbClass();

                return clsdb.GetOrderPreparated(pOrderid);

            }
            catch (Exception e) { return false; }

        }

        private void PopulateNextOrders()
        {
            PopulateOrder();

        }

        private void panOrders_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}