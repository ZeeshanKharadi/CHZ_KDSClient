using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;
using System.Web.Configuration;

namespace MCKDS
{
    class dbClass
    {
        private const bool cSkipLargeOrder = false;
        public SqlConnection Sql_Connection()
        {
            SqlConnection cnn;
            String con_string = ConfigurationManager.ConnectionStrings["MCKDSConnectionString"].ConnectionString;

            cnn = new SqlConnection(con_string);
            try
            {
                cnn.Open();
                return cnn;
                //cnn.Close();
            }
            catch (Exception)
            {
                return cnn;
            }
        }

        // --bilal 
        public void ResetPizzaStation()
        {
            SqlConnection con = Sql_Connection();
            if(con.State == ConnectionState.Open)
            {
                string query = @"update PizzaStation_Tbl set InHand=null,TotalMade=null,TotalSold=null,Last4BatchShowWIthQtyAnfTime=null
                                ,Batch2=null,Batch3=null,BatchQty1=null,BatchQty2=null,BatchQty3=null";
                SqlCommand cmd = new SqlCommand(query, con);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    string updcountertable = "update CounterTable set counter_ = 0";
                    SqlCommand updcounter = new SqlCommand(updcountertable, con);
                    updcounter.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        // update day wise batch Status
        public void UpdateDayWiseBatchStatus()
        {
            SqlConnection con = Sql_Connection();
            string UpdateBatch = "update DayWiseBatchReset set _Status=1";
            SqlCommand cmd = new SqlCommand(UpdateBatch,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateDayWiseBatchStatus2()
        {
            SqlConnection con = Sql_Connection();
            string UpdateBatch = "update DayWiseBatchReset set _Status=0";
            SqlCommand cmd = new SqlCommand(UpdateBatch, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Reset Batch Entry Table
        public void ResetBatchEntryTable()
        {   
            SqlConnection con = Sql_Connection();
            string ResetBatchEntry = "SP_ResetBatchEntryTable";
            SqlCommand cmd = new SqlCommand(ResetBatchEntry, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }
        public void InsertIntoDayBatchWise()
        {
            SqlConnection con = Sql_Connection();
            string InsertQuery = "insert into DayWiseBatchReset (_Time,_Status)Values('7:00:00 AM',0)";
            SqlCommand cmd = new SqlCommand(InsertQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int GetBatchDayWiseRecord()
        {
            int Rowcount = 0;
            SqlConnection con = Sql_Connection();
            string DayBatchWise = "select * from DayWiseBatchReset";
            SqlDataAdapter _sqldataadapterv = new SqlDataAdapter(DayBatchWise, con);
            DataTable _datatable = new DataTable();
            _sqldataadapterv.Fill(_datatable);
            if (_datatable.Rows.Count > 0)
            {
                Rowcount = _datatable.Rows.Count;
            }
            con.Close();
            return Rowcount;
        }

        // 
        //---------------------------------------------------------------

        public DataSet GetOrdersLines(string pOrderid, string StationCatFilter)
        {
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {

                    //                String query = "select OrderID,OrderStatus,OrderType from [dbo].[Order] AS kds_order where kds_order.OrderStatus IN ('READY','INPROGRESS')";
                    //                String query = "SELECT Qty, (Orders.Details +' ('+ Orders.Type +')') AS Items FROM Orders WHERE (order='" + pOrderid + "');";
                    //String query = "SELECT Details FROM Orders where (order='68') ;" ;
                    // String query = "SELECT quantity Qty,  ItemName AS Items, OrderStatusID,Orderstate,LineDescription1,LineDescription2  FROM [Orders]  WHERE (orderid='" + pOrderid + "');";
                    String query = "SELECT quantity Qty,  ItemName + (CASE WHEN Orders.LineDescription1 != '' THEN '<br>'+Orders.LineDescription1 ELSE '' END +CASE WHEN Orders.LineDescription2 != '' THEN '<br>' + Orders.LineDescription2 ELSE '' END)   AS Items, OrderStatusID, Orderstate, LineDescription1, LineDescription2  FROM[Orders]  WHERE(orderid = '" + pOrderid + "' "+ StationCatFilter  + "and OrderStatusID <> 5);";

                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(sql_cmd);

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Orders");
                    return ds;
                }
                DataSet ds1 = new DataSet();
                return ds1;
            }
            catch (Exception)
            {
                DataSet ds1 = new DataSet();
                return ds1;
            }
        }

        public bool UpdateOrder(MCKDS.SmallOrderTile pActiveOrder)
        {
            string ordernumber = pActiveOrder.OrderNo.ToString();

            if (UpdateOrderStatusReady(ordernumber))
                return true;
            else
                return false;
        }


        public bool ReCallLastOrder(string pOrderid, int PreviousStation)
        {

            if (UpdateOrdertoPreviousStatus(pOrderid, PreviousStation))
                return true;
            else
                return false;
        }

        public bool BumpOrder(string pOrderid, int NextStation, string StationCateFilter)
        {

            if (UpdateOrdertoNextStatus(pOrderid, NextStation , StationCateFilter))
                return true;
            else
                return false;
        }

        private bool UpdateOrderStatusReady(string pOrderid)
        {
            int lastStationID = 3;
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    String query = "update [Orders] set Orderstate ='Ready' where ((orderID='" + pOrderid + "')and (orderstatusid=" + lastStationID + ")); ";

                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();


                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        private bool UpdateOrdertoPreviousStatus(string pOrderid, int PreviousStation)
        {
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    //String query = "  update [Orders] set Orderstatusid =Orderstatusid-1 where Orderstatusid>1 and Orderstatusid<4 and (orderID='" + pOrderid + "');";
                    // String query2 = "update orders set status ='Ready' where (Orderstatusid='" + LastStation + "');";

                    dbClass dbcls = new dbClass();
                    string value = dbcls.GetConfiguration(4);

                    String query = @"Update Orders SET OrderStatusID = '" + PreviousStation + @"'
                                     where Orderstatusid >= 1 and Orderstatusid <= 6 and (orderID='" + pOrderid + "')";

                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();

                    Thread.Sleep(2000);
                    UpdateOrderStatusReady(pOrderid);

                    string query2 = @"Update Orders SET OrderStatus = CASE 
                                     WHEN OrderStatusID = 1 THEN 'Preparation'
                                     WHEN OrderStatusID = 2 THEN 'Expeditor'
                                     WHEN OrderStatusID = 3 THEN 'FOH2'
                                     WHEN OrderStatusID = 4 THEN 'Customer'
                                     WHEN OrderStatusID = 5 THEN 'Delivered'
                                     WHEN OrderStatusID = 6 THEN 'Cancelled'
                                     END, 
                                     OrderState= CASE
                                     WHEN OrderStatusID in (0,1,2,3) THEN 'Preparing'
                                     WHEN OrderStatusID = 4 THEN 'Ready'
                                     WHEN OrderStatusID = 5 THEN 'Fulfilled'
                                     WHEN OrderStatusID = 6 THEN 'Cancelled'
                                     END
                                     where Orderstatusid >= 1 and Orderstatusid <= 5 and (orderID='" + pOrderid + "')";

                    SqlCommand sql_cmd2 = new SqlCommand(query2, sql_con);
                    sql_cmd2.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        private bool UpdateOrdertoNextStatus(string pOrderid, int NextStation, String pStationCatFilter)
        {
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    dbClass dbcls = new dbClass();
                    string value = dbcls.GetConfiguration(4);

                    String query = @"update [Orders] set Orderstatusid ='" + NextStation + "' where (orderID='" + pOrderid + "'"+ pStationCatFilter + ");";

                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();
                    Thread.Sleep(700);
                    UpdateOrderStatusReady(pOrderid);


                    string query2 = @"Update Orders SET OrderStatus = CASE 
                                     WHEN OrderStatusID = 1 THEN 'Preparation'
                                     WHEN OrderStatusID = 2 THEN 'Expeditor'
                                     WHEN OrderStatusID = 3 THEN 'FOH2'
                                     WHEN OrderStatusID = 4 THEN 'Customer'
                                     WHEN OrderStatusID = 5 THEN 'Delivered'
                                     WHEN OrderStatusID = 6 THEN 'Cancelled'
                                     END, 
                                     OrderState= CASE
                                     WHEN OrderStatusID in (0,1,2,3) THEN 'Preparing'
                                     WHEN OrderStatusID = 4 THEN 'Ready'
                                     WHEN OrderStatusID = 5 THEN 'Fulfilled'
                                     WHEN OrderStatusID = 6 THEN 'Cancelled'
                                     END
                                     where Orderstatusid >= 1 and Orderstatusid <= 5 and (orderID='" + pOrderid + "')";

                    SqlCommand sql_cmd2 = new SqlCommand(query2, sql_con);
                    sql_cmd2.ExecuteNonQuery();

                }
                OrderBumpLog((NextStation-1).ToString(), (NextStation-1).ToString(), pOrderid);
               

                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool UpdateOnHand(string pItemId, int pOnhand, int pCFried, int FryLog)
        {
            string itemNumber = pItemId;
            FryingLog(pItemId, FryLog);
            if (UpdateItemOnhand(itemNumber, pOnhand, pCFried))
                return true;
            else
                return false;
        }
        private bool UpdateItemOnhand(string pItemId, int Onhand, int CFried)
        {

            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    String query = "  update item set OnHandQuantity = " + Onhand + ", CFriedQuantity = " + CFried + "  where(ItemID = '" + pItemId + "');";
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error db:UpdateItemOnhand " + e.Message);
                //WriteErrorMessageLog("Error Db101: UpdateItemOnhand: " +e.Message);
                return false;
            }
        }
        private bool FryingLog(string pItemId, int FriedQty)
        {

            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    String query = "INSERT INTO itemTransLog ( ItemId, TransDate, Quantity, Description, OrderId)  VALUES ( '" + pItemId + "', GETDATE(), " + FriedQty + " ,'FriedItem','' );";
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error db: FryingLog " + e.Message);
                //WriteErrorMessageLog("Error Db101: UpdateItemOnhand: " +e.Message);
                return false;
            }

        }
        public bool SetMasterSyncOn()
        {
            return MasterSyncOn();
        }

        private bool MasterSyncOn()
        {
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    String query = "  update Configuration set Value = 1  where(ConfigurationID = 1);";
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error db:UpdateItemOnhand " + e.Message);
                //WriteErrorMessageLog("Error Db101: UpdateItemOnhand: " +e.Message);
                return false;
            }
        }
        public bool UpdateOrderStatustoPreparation(string FryingItemid, double NewFryingQty, double onHand)
        {
            double FriedQty = NewFryingQty;
            DataSet ds = GetOrdersLinesHavingFryingItems(FryingItemid);

            if (ds != null)
            {
                if (NewFryingQty >= 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        double cOrderQtySum = Convert.ToDouble(dt.Compute("Sum(Qty)", string.Empty));
                        double OnHandFryingQty = cOrderQtySum + onHand;

                        int i = 0;
                        while (i < dt.Rows.Count)
                        {
                            object OrderQTy = dt.Rows[i][3];
                            object OrderID = dt.Rows[i][0];
                            object LIneNum = dt.Rows[i][4];

                            double currentOrderQty = Convert.ToDouble(OrderQTy);
                            if (OnHandFryingQty >= currentOrderQty)
                            {
                                OnHandFryingQty -= currentOrderQty;
                                UpdateOrdertoPreparationStatus(OrderID.ToString(), Convert.ToDouble(LIneNum), FryingItemid);
                            }
                            else
                            {
                                if (!cSkipLargeOrder)
                                    return true;
                            }
                            i++;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        public DataSet GetOrdersLinesHavingFryingItems(string FryingItemid)
        {
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    String query = @"select  OrderID, orders.ItemID, FryingItem, sum(Orders.Quantity)*sum(BOM.Quantity) Qty,linenum
                                from Orders
                                inner join BOM on orders.ItemID = BOM.ItemId 
                                where OrderStatusID = 0
                                and BOM.FryingItem = '" + FryingItemid + @"'
                                GROUP by OrderID, orders.ItemID, FryingItem,CreatedOn,linenum";


                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(sql_cmd);

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Orders");
                    return ds;
                }
                DataSet ds1 = new DataSet();
                return ds1;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error db:UpdateOrdertoPreparationStatus " + e.Message);
                //WriteErrorMessageLog("Error Db101: UpdateItemOnhand: " +e.Message);
                return null;
            }
        }
        private bool UpdateOrdertoPreparationStatus(String pOrderid, double pLineNum, String pFryingItemID)
        {
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    //update ItemTransLog set FriedStatus = 1 where(Orderid = '0002000001-000038') and (linenum =1) and Itemid='ITM-002548';
                    String query0 = "update ItemTransLog set FriedStatus = 1  where(Orderid = '" + pOrderid + "') and (linenum=" + pLineNum + ") and Itemid='" + pFryingItemID + "' ;";
                    SqlCommand sql_cmd0 = new SqlCommand(query0, sql_con);
                    sql_cmd0.ExecuteNonQuery();


                    //Update orders set OrderStatusID = 0 , OrderStatus = 'Frying' where orders.OrderID = '0002000001-000038'  and orders.linenum = 2
                    //Update orders set OrderStatusID = 1, OrderStatus = 'Preparing'
                    //--select*
                    //from Orders join ItemTransLog ilog on orders.OrderID = ilog.OrderID and orders.linenum = ilog.linenum
                    //where orders.OrderID = '0002000001-000038'  and orders.linenum = 2 and
                    // ((select count(itemid) from ItemTransLog where OrderID = Orders.OrderID  and linenum = orders.linenum) - 
                    //(select count(itemid) from ItemTransLog where OrderID = orders.OrderID  and linenum = orders.linenum and friedstatus = 1) )= 0



                    String query = @"Update orders set OrderStatusID = 1 , OrderStatus = 'Preparation' ,OrderState='Preparing'
                                    from Orders join ItemTransLog ilog on orders.OrderID=ilog.OrderID and orders.linenum=ilog.linenum
                                    where orders.OrderID = '" + pOrderid + "'  and orders.linenum = " + pLineNum + @" and 
                                     ((select count(itemid) from ItemTransLog where OrderID = Orders.OrderID  and linenum = orders.linenum) -
                                    (select count(itemid) from ItemTransLog where OrderID = orders.OrderID  and linenum =orders.linenum and friedstatus=1) )=0";


                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error db:UpdateOrdertoPreparationStatus " + e.Message);
                //WriteErrorMessageLog("Error Db101: UpdateItemOnhand: " +e.Message);
                return false;
            }
        }

        public bool ResetComulativeFried()
        {
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    String query = @"Update Item 
                                 Set CFriedQuantity = 0, CurrentTimeSlot = CONCAT(ItemForecast.FromDate, ItemForecast.ToDate)
                                 FROM Item LEFT OUTER JOIN
                                 ItemForecast ON Item.ItemID = ItemForecast.ItemID AND ItemForecast.FromDate <= GETDATE() AND ItemForecast.ToDate >= GETDATE()
                                 where IsFried = 1 and(CurrentTimeSlot != CONCAT(ItemForecast.FromDate, ItemForecast.ToDate) OR CurrentTimeSlot is NULL)";

                    SqlCommand cmd = new SqlCommand(query, sql_con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    sql_con.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateConfiguration(string pKey, string pValue)
        {
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    string query = @"Update Configuration Set Value='" + pValue + @"' where configurationid='" + pKey + "'";
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error db:UpdateConfiguration " + e.Message);
                return false;
            }

        }
        public string GetConfiguration(int pConfigID)
        {
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    string query = @"Select value from Configuration where ConfigurationID=" + pConfigID;
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);

                    string ConfigValue = (string)sql_cmd.ExecuteScalar();

                    //SqlDataAdapter da = new SqlDataAdapter(sql_cmd);

                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "Configuration");
                    //string ConfigValue = "";
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    ConfigValue = ds.Tables[0].Rows[i][0].ToString();
                    //}

                    return ConfigValue;
                }
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error db:GetConfiguration " + pConfigID + " " + e.Message);
                return null;
            }

        }
        public int GetOrderStatusID(string OrderID, int pCurrentStation)
        {
            Int32 Value =0;
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    string query = @"Select OrderStatusID from Orders where OrderID='" + OrderID + "'  and OrderStatusID="+ pCurrentStation;
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    //Value =(Int32)sql_cmd.ExecuteScalar();
                    SqlDataReader dr = sql_cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        Value = int.Parse(dr["OrderStatusID"].ToString());
                    }
                   
                    return Value;
                }
                return Value;
            }
            catch (Exception)
            {
                return Value;
            }
        }
        //Preparation Time..
        public int GetOrderPreparationTime(string pStation)
        {
            Int32 Value = 0;
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    string query = @"Select PreparingTime from StationPreparingTime where Station='" + pStation + "'";
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);

                    Value = (Int32)sql_cmd.ExecuteScalar();
                    return Value;
                }
                return Value;
            }
            catch (Exception)
            {
                return Value;
            }
        }
        //insert data into OrderBumplogtable..
        private bool OrderBumpLog(string pStationID, string pStationName,string pOrderID)
        {

            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)

                {
                    String query = "INSERT INTO OrderBumpLog ( StationID, StationName, OrderID, BumpTimeStamp)  VALUES ( '" + pStationID + "','"+ pStationName + "', '" + pOrderID + "' ,getdate() );";
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    sql_cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error db: FryingLog " + e.Message);
                //WriteErrorMessageLog("Error Db101: UpdateItemOnhand: " +e.Message);
                return false;
            }

        }
        public int GetTransactionType(string OrderID, int pCurrentStation)
        {
            Int32 Value = 0;
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    string query = @"Select TransactionType from Orders where OrderID='" + OrderID + "' and OrderStatusID = "+ pCurrentStation;
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);
                    Value = (Int32)sql_cmd.ExecuteScalar();
                    return Value;
                }
                return Value;
            }
            catch (Exception)
            {
                return Value;
            }
        }
        public string GetOrderState(string OrderID, int pCurrentStation)
        {
            string Value = "";
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    string query = @"Select OrderState from Orders where OrderID='" + OrderID + "' and OrderStatusID = "+ pCurrentStation;
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);

                    Value = (string)sql_cmd.ExecuteScalar();

                    return Value;
                }
                return Value;
            }
            catch (Exception)
            {
                return Value;
            }
        }
        public bool ResetBlinkingOrders()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool  GetOrderPreparated(string pOrderid)
        {
            bool Value = false;
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    string query = @"select count( *)-sum(case when  OrderStatusID=2 then 1 else 0 end)  PendingItems
                                    from orders 
                                    where orderid='"+ pOrderid + "' and orderstatusid<3";
                    SqlCommand sql_cmd = new SqlCommand(query, sql_con);

                    int PendingItem = (int)sql_cmd.ExecuteScalar();
                    if (PendingItem == 0) return true;
                    
                }
                return Value;
            }
            catch (Exception)
            {
                return Value;
            }
        }
        public int GetOrderPreparationMaxTime(string OrderId)
        {
            Int32 Value = 0;
            try
            {
                SqlConnection sql_con = Sql_Connection();
                if (sql_con.State == ConnectionState.Open)
                {
                    string getquery = @"select max(PreparationTime) OrderPrepartionTime from (
                                    select  case when ord.PizzaStation=1 then   (select preparingtime  from StationPreparingTime where Station=  'Pizza')
                                     else case when ord.PastaStation=1 then (select preparingtime  from StationPreparingTime where Station=  'pasta') 
                                     else case when  ord.friedstation=1 then  (select preparingtime  from StationPreparingTime where Station=  'Sandwich') end end end PreparationTime
                                    from Orders ord where OrderID='" + OrderId + "' ) MOPTimeb";
                    SqlCommand sql_cmd = new SqlCommand(getquery, sql_con);

                    Value = (Int32)sql_cmd.ExecuteScalar();
                    return Value;
                }
                return Value;
            }
            catch (Exception)
            {
                return Value;
            }
        }
       

    }
}
