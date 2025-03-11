using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace MCKDS
{
    // bilal 
    public partial class PizzaStation : MetroFramework.Forms.MetroForm
    {
        string ItemIdColumn;
        string batchWithDatetime = string.Empty;
        DataGridViewCell[] columns = new DataGridViewCell[6];
        dbClass db = new dbClass();
        // connection string
        string cs = ConfigurationManager.ConnectionStrings["MCKDSConnectionString"].ConnectionString;
        string[] Dates = new string[2];
        int iCurrentRowIndx;
        int RowCount = 0;
        string Inhand = "";
        string TotalSold = "";
        dbClass dbcls = new dbClass();
        DataTable PS_DataTable;
        int i = 0;
        public PizzaStation()
        {
            InitializeComponent();
            //////// ---------------
            System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
            MyTimer.Interval = (1 * 60 * 200); // 1 mins
            MyTimer.Tick += new EventHandler(times);
            MyTimer.Start();
            ////-------------
        }

        private void times(object sender, EventArgs e)
        {
            DateTime t1 = DateTime.Parse("6:10:00.000");
            DateTime t2 = DateTime.Parse("6:18:00.000");
            DateTime now = DateTime.Now;
            string FetchPizzaStationQuery = "";
            SqlCommand cmd;
            SqlDataReader dr;
            int counter = 0;
            string query = "";
            ResetBatchEntryTable();
            if (t1 <= now)
            {
                this.pizzaStation_TblTableAdapter.Fill(this.mCKDSBackUpDataSet6.PizzaStation_Tbl);
            }
           
        }
        // insert into day batch wise

      
      

        public void ResetBatchEntryTable()
        {
            int row = db.GetBatchDayWiseRecord();
            if(row > 0)
            {
                SqlConnection con = db.Sql_Connection();
                string CurrentTime = DateTime.Now.ToString("hh:mm:ss tt");

                DateTime ctime = DateTime.Parse(CurrentTime);

                string DBTime = "";
                bool _status = false;
                string GetResetBatchTime = "select * from DayWiseBatchReset";
                SqlDataAdapter sda = new SqlDataAdapter(GetResetBatchTime, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DateTime cDBTime;

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    DBTime = dr["_Time"].ToString();
                    cDBTime = DateTime.Parse(DBTime);
                    _status = bool.Parse(dr["_Status"].ToString());
                    if (ctime > cDBTime && _status == false)
                    {
                        string ResetBatchEntry = "SP_ResetBatchEntryTable";
                        SqlCommand cmd = new SqlCommand(ResetBatchEntry, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        dbcls.UpdateDayWiseBatchStatus();
                        dbcls.ResetPizzaStation();
                    }
                    else if (ctime < cDBTime && _status == true)
                    {
                        dbcls.UpdateDayWiseBatchStatus2();
                    }
                }
                con.Close();
            }
            else
            {
                db.InsertIntoDayBatchWise();
            }
        }
        private void PizzaStation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mCKDSBackUpDataSet6.PizzaStation_Tbl' table. You can move, or remove it, as needed.
            this.pizzaStation_TblTableAdapter.Fill(this.mCKDSBackUpDataSet6.PizzaStation_Tbl);
            Text = "";
            label2.Text = DateTime.Now.Day + " " + DateTime.Now.ToString("MMM,yyyy");
            label3.Text = DateTime.Now.ToString("dddd");

            //return;
        }

        private DataTable GetPizzaStationTable()
        {
            string query = "";
            try
            {
                SqlConnection con = dbcls.Sql_Connection();
                query = "select * from PizzaStation_Tbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    return dt;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
            return null;
        } 

        public void updateCounterTable(int counter, int CounterId)
        {
            try
            {
                string UpdateCounterQuery = "";
                SqlCommand CounterTblCmd;
                SqlConnection con = db.Sql_Connection();
                UpdateCounterQuery = "update CounterTable set counter_ = @counter where CountId = @counterid";
                CounterTblCmd = new SqlCommand(UpdateCounterQuery, con);
                CounterTblCmd.Parameters.AddWithValue("@counter", counter);
                CounterTblCmd.Parameters.AddWithValue("@counterid", CounterId);
                CounterTblCmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //--------------------------------------------------------

        // Insert Data In Pizza Log Table 
        public void InsertRecordInPizzaLog(dynamic[] LogFields, string[] BusinessDateTimeToLogs, Int64 EntryNum)
        {
            SqlConnection con = db.Sql_Connection();
            SqlCommand cmd;
            // Get Batch Day + value

                string InsertPizzaLog = @"insert into PizzaStationLog_Tbl 
                                      values(@ItemId,@ItemName,@InHand,@TotalMade,@TotalSold,
                                      @BatchEntry,@BatchQty1WithDT1,@BatchQty1WithDT2,
                                      @BatchQty1WithDT3,@BatchQty1,@BatchQty2,@BatchQty3,@BusinessDateTime,@BusinessDateTime2,@EntryNum)";

                cmd = new SqlCommand(InsertPizzaLog, con);
                cmd.Parameters.AddWithValue("@ItemId", LogFields[0]);
                cmd.Parameters.AddWithValue("@ItemName", LogFields[1]);
                cmd.Parameters.AddWithValue("@InHand", LogFields[2]);
                cmd.Parameters.AddWithValue("@TotalMade", LogFields[3]);
                cmd.Parameters.AddWithValue("@TotalSold", LogFields[4]);
                cmd.Parameters.AddWithValue("@BatchEntry", LogFields[5]);
                cmd.Parameters.AddWithValue("@BatchQty1WithDT1", LogFields[6]);
                cmd.Parameters.AddWithValue("@BatchQty1WithDT2", LogFields[7]);
                cmd.Parameters.AddWithValue("@BatchQty1WithDT3", LogFields[8]);
                cmd.Parameters.AddWithValue("@BatchQty1", LogFields[9]);
                cmd.Parameters.AddWithValue("@BatchQty2", LogFields[10]);
                cmd.Parameters.AddWithValue("@BatchQty3", LogFields[11]);
                cmd.Parameters.AddWithValue("@BusinessDateTime", Convert.ToDateTime(BusinessDateTimeToLogs[0]));
                cmd.Parameters.AddWithValue("@BusinessDateTime2", Convert.ToDateTime(BusinessDateTimeToLogs[1]));
                cmd.Parameters.AddWithValue("@EntryNum", EntryNum);
               
                cmd.ExecuteNonQuery();
            con.Close();
        }

        public string[] CheckBusinessDateTime()
        {
            DateTime date3 = Convert.ToDateTime("12:00:00 AM");
            DateTime StoreOnTime = Convert.ToDateTime("7:00:00 AM");
            DateTime StoreOffTime = Convert.ToDateTime("3:00:00 AM");

            if (Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss tt")) >= StoreOnTime)
            {
                if (StoreOffTime <= Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss tt")))
                {
                    Dates[0] = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt").ToString();
                    Dates[1] = DateTime.Now.ToString("MM/dd/yyyy").ToString();
                }
            }
            else if (Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss tt")) >= date3 && Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss tt")) <= StoreOffTime)
            {
                Dates[0] = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("hh:mm:ss tt"); //DateTime.Now.ToString("MM/").ToString() + (DateTime.Now.Day - 1) + DateTime.Now.ToString("/yyyy hh:mm:ss tt").ToString();
                Dates[1] = DateTime.Today.AddDays(-1).ToString("MM/dd/yyyy").ToString(); //DateTime.Now.ToString("MM/").ToString() + (DateTime.Now.Day - 1) + DateTime.Now.ToString("/yyyy").ToString();
            }
            else
            {
                Dates[0] = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt").ToString();
                Dates[1] = DateTime.Now.ToString("MM/dd/yyyy").ToString();
            }
            return Dates;
        }
        // BatchEntry Number Table working Fetch Records 
        public Int64 GetBatchEntryNum(int RecNo)
        {
            Int64 BatchEntryNum = 0;
            try
            {
                string query = "";
                SqlConnection con = db.Sql_Connection();
                if (con.State == ConnectionState.Open)
                {
                    query = "select * from BatchEmtryNumber_Table where RecNo = @RecNo";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@RecNo", RecNo);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        dr.Read();
                        BatchEntryNum = int.Parse(dr.GetValue(1).ToString());
                    }
                }
                con.Close();
                return BatchEntryNum;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return BatchEntryNum;
        }
        //-----------------------------------------------------------------------------

        // Update Batch Entry Table
        public void UpdateBatchEntryTable(Int64 EntryNum, int recno)
        {
            SqlConnection con = db.Sql_Connection();
            EntryNum++;
            string UpdBatchTbl = "update BatchEmtryNumber_Table set BatchEntryNumber = @EntryNum where RecNo = @recno";
            SqlCommand cmd = new SqlCommand(UpdBatchTbl, con);
            cmd.Parameters.AddWithValue("@EntryNum", EntryNum);
            cmd.Parameters.AddWithValue("@recno", recno);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int MinusBatchQty1(string itemid)
        {
            int Qty = 0;
            SqlConnection con = db.Sql_Connection();
            string query = "select * from PizzaStation_Tbl where itemid = @itemid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@itemid", itemid);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                dr.Read();
                Qty = int.Parse(dr["BatchQty1"].ToString());
            }
            return Qty;
        }

        public int MinusBatchQty2(string itemid)
        {
            int Qty = 0;
            SqlConnection con = db.Sql_Connection();
            string query = "select * from PizzaStation_Tbl where itemid = @itemid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@itemid", itemid);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Qty = int.Parse(dr["BatchQty2"].ToString());
            }
            return Qty;
        }
        public int MinusBatchQty3(string itemid)
        {
            int Qty = 0;
            SqlConnection con = db.Sql_Connection();
            string query = "select * from PizzaStation_Tbl where itemid = @itemid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@itemid", itemid);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Qty = int.Parse(dr["BatchQty3"].ToString());
            }
            return Qty;
        }

        public void UpdateDataInBatchFields(int BatchQtyField, string itemid)
        {
            string[] DatesArray = new string[2];
            string BusinessDateTime;
            string BusinessDate;
            dynamic[] Logs = new dynamic[12];
            string FetchCounterQuery = "";

            string FetchPizzaStationQuery = "";
            SqlCommand PizzaStationCmd;
            string updatePizzaStationQuery = "";
            int counter;
            int counterId;
            batchWithDatetime = BatchQtyField.ToString() + " | " + DateTime.Now.ToString("hh:mm tt");
            DatesArray = CheckBusinessDateTime();

            BusinessDateTime = DatesArray[0]; // businesssdatetime
            BusinessDate = DatesArray[1]; // only business date 
            Int64 EntryNum = 0;

            int remainingBatchQtyValue = 0;
            int GetBatch1Value         = 0;
            int getrowcount = 0;
            try
            {
                    SqlConnection con = db.Sql_Connection();
                    if (itemid == "ITM-000001")
                    {
                        FetchCounterQuery = "select * from counterTable where CountId = 1 ";
                    }
                    else if (itemid == "ITM-001331")
                    {
                        FetchCounterQuery = "select * from counterTable where CountId = 2 ";
                    }
                    else if (itemid == "ITM-001332")
                    {
                        FetchCounterQuery = "select * from counterTable where CountId = 3 ";
                    }
                    else if (itemid == "ITM-001333")
                    {
                        FetchCounterQuery = "select * from counterTable where CountId = 4 ";
                    }
                    else if (itemid == "ITM-001334")
                    {
                        FetchCounterQuery = "select * from counterTable where CountId = 5 ";
                    }
                    else if (itemid == "ITM-001335")
                    {
                        FetchCounterQuery = "select * from counterTable where CountId = 6 "; 
                    }
                    else if (itemid == "ITM-001340")
                    {
                        FetchCounterQuery = "select * from counterTable where CountId = 7 ";
                    }
                    else if (itemid == "ITM-001341")
                    {
                        FetchCounterQuery = "select * from counterTable where CountId = 8 ";
                    }
                    else if (itemid == "ITM-001344")
                    {
                        FetchCounterQuery = "select * from counterTable where CountId = 9 ";
                    }
                    else if (itemid == "ITM-001345")
                    {
                        FetchCounterQuery = "select * from counterTable where CountId = 10 ";
                    }
                    SqlCommand CounterCmd = new SqlCommand(FetchCounterQuery, con);
                    SqlDataReader dr = CounterCmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        dr.Read();
                        counter = int.Parse(dr.GetValue(1).ToString());
                        counterId = int.Parse(dr.GetValue(0).ToString());
                        if (counter == 0 && BatchQtyField < 0)
                        {
                            GetBatch1Value = MinusBatchQty3(itemid);
                            remainingBatchQtyValue = GetBatch1Value - Math.Abs(BatchQtyField);

                            batchWithDatetime = remainingBatchQtyValue.ToString() + " | " + DateTime.Now.ToString("hh:mm");
                            con.Close();
                            // update pizza station table 
                            updatePizzaStationQuery = "update PizzaStation_Tbl set Batch3 = @batchqty , BatchQty3 = BatchQty3 + @batchqty3 , BusinessDate = @bussinessDateTime where ItemId = @itemid";
                            PizzaStationCmd = new SqlCommand(updatePizzaStationQuery, con);
                            PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty", batchWithDatetime);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty3", BatchQtyField);
                            PizzaStationCmd.Parameters.AddWithValue("@bussinessDateTime", Convert.ToDateTime(BusinessDateTime));
                            con.Open();
                            int upd = PizzaStationCmd.ExecuteNonQuery();
                            if (upd > 0)
                            {
                                con.Close();
                                FetchPizzaStationQuery = "select * from PizzaStation_Tbl where itemid = @itemid";
                                PizzaStationCmd = new SqlCommand(FetchPizzaStationQuery, con);
                                PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                                con.Open();
                                SqlDataReader dr3 = PizzaStationCmd.ExecuteReader();
                                if (dr3.HasRows == true)
                                {
                                    dr3.Read();
                                    // put data in batch 2 column 
                                    metroGrid1.CurrentRow.Cells[8].Value = dr3.GetValue(7);
                                    //updateCounterTable(0, counterId);
                                    for (int i = 0; i < Logs.Length; i++)
                                    {
                                        switch (i)
                                        {
                                            case 0: Logs[i] = dr3["ItemId"].ToString(); break;
                                            case 1:
                                                Logs[i] = metroGrid1.CurrentRow.Cells[1].Value;
                                                break;
                                            case 2:
                                                Logs[i] = dr3.GetValue(1); // inhand
                                                break;
                                            case 3:
                                                Logs[i] = dr3.GetValue(2); // total made 
                                                break;
                                            case 4:
                                                Logs[i] = dr3.GetValue(3); // total sold
                                                break;
                                            case 5:
                                                Logs[i] = BatchQtyField;
                                                break;
                                            case 6:
                                                Logs[i] = dr3.GetValue(5); // batch qty1 date time 
                                                break;
                                            case 7:
                                                Logs[i] = dr3.GetValue(6); // batch qty2 date time
                                                break;
                                            case 8:
                                                Logs[i] = dr3.GetValue(7); // batch qty3 date time
                                                break;
                                            case 9:
                                                Logs[i] = dr3.GetValue(8); // batch qty1
                                                break;
                                            case 10:
                                                Logs[i] = dr3.GetValue(9); // batch qty2
                                                break;
                                            default:
                                                Logs[i] = dr3.GetValue(10); // batch qty3
                                                break;
                                        }
                                    }
                                    if (itemid == "ITM-000001")
                                    {
                                        EntryNum = this.GetBatchEntryNum(1);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 1);
                                    }
                                    else if (itemid == "ITM-001331")
                                    {
                                        EntryNum = this.GetBatchEntryNum(2);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 2);
                                    }
                                    else if (itemid == "ITM-001332")
                                    {
                                        EntryNum = this.GetBatchEntryNum(3);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 3);
                                    }
                                    else if (itemid == "ITM-001333")
                                    {

                                        EntryNum = this.GetBatchEntryNum(4);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 4);

                                    }
                                    else if (itemid == "ITM-001334")
                                    {
                                        EntryNum = this.GetBatchEntryNum(5);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 5);
                                    }
                                    else if (itemid == "ITM-001335")
                                    {
                                        EntryNum = this.GetBatchEntryNum(6);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 6);
                                    }
                                    else if (itemid == "ITM-001340")
                                    {
                                        EntryNum = this.GetBatchEntryNum(7);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 7);
                                    }
                                    else if (itemid == "ITM-001341")
                                    {
                                        EntryNum = this.GetBatchEntryNum(8);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 8);

                                    }
                                    else if (itemid == "ITM-001344")
                                    {
                                        EntryNum = this.GetBatchEntryNum(9);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 9);

                                    }
                                    else if (itemid == "ITM-001345")
                                    {
                                        EntryNum = this.GetBatchEntryNum(10);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 10);
                                    }
                                }
                            }
                            else
                            {
                                metroGrid1.CurrentRow.Cells[6].Value = 2;
                            }
                        }
                        else if (counter == 0)
                        {
                            con.Close();

                            updatePizzaStationQuery = @"update PizzaStation_Tbl set Last4BatchShowWIthQtyAnfTime = @batchqty , BatchQty1 = @batchqty1 ,  BusinessDate = @bussinessDateTime  where ItemId = @itemid";
                            PizzaStationCmd = new SqlCommand(updatePizzaStationQuery, con);
                            //  BusinessDate = @bussinessDateTime
                            PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty", batchWithDatetime);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty1", BatchQtyField);
                            PizzaStationCmd.Parameters.AddWithValue("@bussinessDateTime", Convert.ToDateTime(BusinessDateTime));
                            con.Open();
                            int upd = PizzaStationCmd.ExecuteNonQuery();
                            if (upd > 0)
                            {
                                con.Close();
                                FetchPizzaStationQuery = "select * from PizzaStation_Tbl where itemid = @itemid";
                                PizzaStationCmd = new SqlCommand(FetchPizzaStationQuery, con);
                                PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                                con.Open();
                                SqlDataReader dr3 = PizzaStationCmd.ExecuteReader();
                                if (dr3.HasRows == true)
                                {
                                    dr3.Read();
                                    // put data in batch 1 column 
                                    metroGrid1.CurrentRow.Cells[6].Value = dr3.GetValue(5);
                                    updateCounterTable(1, counterId);
                                    for (int i = 0; i < Logs.Length; i++)
                                    {
                                        switch (i)
                                        {
                                            case 0: Logs[i] = dr3["ItemId"].ToString(); break;
                                            case 1:
                                                Logs[i] = metroGrid1.CurrentRow.Cells[1].Value;
                                                break;
                                            case 2:
                                                Logs[i] = dr3.GetValue(1); // inhand
                                                break;
                                            case 3:
                                                Logs[i] = dr3.GetValue(2); // total made 
                                                break;
                                            case 4:
                                                Logs[i] = dr3.GetValue(3); // total sold
                                                break;
                                            case 5:
                                                Logs[i] = BatchQtyField;
                                                break;
                                            case 6:
                                                Logs[i] = dr3.GetValue(5); // batch qty1 date time 
                                                break;
                                            case 7:
                                                Logs[i] = dr3.GetValue(6); // batch qty2 date time
                                                break;
                                            case 8:
                                                Logs[i] = dr3.GetValue(7); // batch qty3 date time
                                                break;
                                            case 9:
                                                Logs[i] = dr3.GetValue(8); // batch qty1
                                                break;
                                            case 10:
                                                Logs[i] = dr3.GetValue(9); // batch qty2
                                                break;
                                            default:
                                                Logs[i] = dr3.GetValue(10); // batch qty3
                                                break;
                                        }
                                    }
                                    if (itemid == "ITM-000001")
                                    {
                                        EntryNum = this.GetBatchEntryNum(1);
                                        this.UpdateBatchEntryTable(EntryNum, 1);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001331")
                                    {
                                        EntryNum = this.GetBatchEntryNum(2);
                                        this.UpdateBatchEntryTable(EntryNum, 2);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001332")
                                    {
                                        EntryNum = this.GetBatchEntryNum(3);
                                        this.UpdateBatchEntryTable(EntryNum, 3);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001333")
                                    {
                                        EntryNum = this.GetBatchEntryNum(4);
                                        this.UpdateBatchEntryTable(EntryNum, 4);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001334")
                                    {
                                        EntryNum = this.GetBatchEntryNum(5);
                                        this.UpdateBatchEntryTable(EntryNum, 5);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001335")
                                    {
                                        EntryNum = this.GetBatchEntryNum(6);
                                        this.UpdateBatchEntryTable(EntryNum, 6);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001340")
                                    {
                                        EntryNum = this.GetBatchEntryNum(7);
                                        this.UpdateBatchEntryTable(EntryNum, 7);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001341")
                                    {
                                        EntryNum = this.GetBatchEntryNum(8);
                                        this.UpdateBatchEntryTable(EntryNum, 8);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001344")
                                    {
                                        EntryNum = this.GetBatchEntryNum(9);
                                        this.UpdateBatchEntryTable(EntryNum, 9);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001345")
                                    {
                                        EntryNum = this.GetBatchEntryNum(10);
                                        this.UpdateBatchEntryTable(EntryNum, 10);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                }
                            }
                            // update pizza station table 

                            else
                            {
                                metroGrid1.CurrentRow.Cells[6].Value = 2;
                            }
                        }
                        else if (counter == 1 && BatchQtyField < 0)
                        {
                            GetBatch1Value = MinusBatchQty1(itemid);
                            remainingBatchQtyValue = GetBatch1Value - Math.Abs(BatchQtyField);

                            batchWithDatetime = remainingBatchQtyValue.ToString() + " | " + DateTime.Now.ToString("hh:mm");
                            con.Close();
                            // update pizza station table 

                            updatePizzaStationQuery = @"update PizzaStation_Tbl set Last4BatchShowWIthQtyAnfTime = @batchqty , BatchQty1 = BatchQty1 + @batchqty1 ,  BusinessDate = @bussinessDateTime  where ItemId = @itemid";
                            PizzaStationCmd = new SqlCommand(updatePizzaStationQuery, con);
                            //  BusinessDate = @bussinessDateTime
                            PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty", batchWithDatetime);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty1", BatchQtyField);
                            PizzaStationCmd.Parameters.AddWithValue("@bussinessDateTime", Convert.ToDateTime(BusinessDateTime));
                            con.Open();
                            int upd = PizzaStationCmd.ExecuteNonQuery();
                            if (upd > 0)
                            {
                                con.Close();
                                FetchPizzaStationQuery = "select * from PizzaStation_Tbl where itemid = @itemid";
                                PizzaStationCmd = new SqlCommand(FetchPizzaStationQuery, con);
                                PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                                con.Open();
                                SqlDataReader dr3 = PizzaStationCmd.ExecuteReader();
                                if (dr3.HasRows == true)
                                {
                                    dr3.Read();
                                    // put data in batch 1 column 
                                    metroGrid1.CurrentRow.Cells[6].Value = dr3.GetValue(5);
                                    //updateCounterTable(1, counterId);
                                    for (int i = 0; i < Logs.Length; i++)
                                    {
                                        switch (i)
                                        {
                                            case 0: Logs[i] = dr3["ItemId"].ToString(); break;
                                            case 1:
                                                Logs[i] = metroGrid1.CurrentRow.Cells[1].Value;
                                                break;
                                            case 2:
                                                Logs[i] = dr3.GetValue(1); // inhand
                                                break;
                                            case 3:
                                                Logs[i] = dr3.GetValue(2); // total made 
                                                break;
                                            case 4:
                                                Logs[i] = dr3.GetValue(3); // total sold
                                                break;
                                            case 5:
                                                Logs[i] = BatchQtyField;
                                                break;
                                            case 6:
                                                Logs[i] = dr3.GetValue(5); // batch qty1 date time 
                                                break;
                                            case 7:
                                                Logs[i] = dr3.GetValue(6); // batch qty2 date time
                                                break;
                                            case 8:
                                                Logs[i] = dr3.GetValue(7); // batch qty3 date time
                                                break;
                                            case 9:
                                                Logs[i] = dr3.GetValue(8); // batch qty1
                                                break;
                                            case 10:
                                                Logs[i] = dr3.GetValue(9); // batch qty2
                                                break;
                                            default:
                                                Logs[i] = dr3.GetValue(10); // batch qty3
                                                break;
                                        }
                                    }
                                    if (itemid == "ITM-000001")
                                    {
                                        EntryNum = this.GetBatchEntryNum(1);
                                        this.UpdateBatchEntryTable(EntryNum, 1);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001331")
                                    {
                                        EntryNum = this.GetBatchEntryNum(2);
                                        this.UpdateBatchEntryTable(EntryNum, 2);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001332")
                                    {
                                        EntryNum = this.GetBatchEntryNum(3);
                                        this.UpdateBatchEntryTable(EntryNum, 3);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001333")
                                    {
                                        EntryNum = this.GetBatchEntryNum(4);
                                        this.UpdateBatchEntryTable(EntryNum, 4);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001334")
                                    {
                                        EntryNum = this.GetBatchEntryNum(5);
                                        this.UpdateBatchEntryTable(EntryNum, 5);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001335")
                                    {
                                        EntryNum = this.GetBatchEntryNum(6);
                                        this.UpdateBatchEntryTable(EntryNum, 6);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001340")
                                    {
                                        EntryNum = this.GetBatchEntryNum(7);
                                        this.UpdateBatchEntryTable(EntryNum, 7);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001341")
                                    {
                                        EntryNum = this.GetBatchEntryNum(8);
                                        this.UpdateBatchEntryTable(EntryNum, 8);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001344")
                                    {
                                        EntryNum = this.GetBatchEntryNum(9);
                                        this.UpdateBatchEntryTable(EntryNum, 9);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001345")
                                    {
                                        EntryNum = this.GetBatchEntryNum(10);
                                        this.UpdateBatchEntryTable(EntryNum, 10);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                }
                            }
                            else
                            {
                                metroGrid1.CurrentRow.Cells[6].Value = 2;
                            }
                        }
                        else if (counter == 1)
                        {
                            con.Close();
                            // update pizza station table 
                            updatePizzaStationQuery = "update PizzaStation_Tbl set Batch2 = @batchqty , BatchQty2 = @batchqty2 , BusinessDate=@bussinessDateTime where ItemId = @itemid";
                            PizzaStationCmd = new SqlCommand(updatePizzaStationQuery, con);
                            PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty", batchWithDatetime);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty2", BatchQtyField);
                            PizzaStationCmd.Parameters.AddWithValue("@bussinessDateTime", Convert.ToDateTime(BusinessDateTime));

                            con.Open();
                            int upd = PizzaStationCmd.ExecuteNonQuery();
                            if (upd > 0)
                            {
                                con.Close();
                                FetchPizzaStationQuery = "select * from PizzaStation_Tbl where itemid = @itemid";
                                PizzaStationCmd = new SqlCommand(FetchPizzaStationQuery, con);
                                PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                                con.Open();
                                SqlDataReader dr3 = PizzaStationCmd.ExecuteReader();
                                if (dr3.HasRows == true)
                                {
                                    dr3.Read();
                                    // put data in batch 2 column 
                                    metroGrid1.CurrentRow.Cells[7].Value = dr3.GetValue(6);
                                    updateCounterTable(2, counterId);
                                    for (int i = 0; i < Logs.Length; i++)
                                    {
                                        switch (i)
                                        {
                                            case 0: Logs[i] = dr3["ItemId"].ToString(); break;
                                            case 1:
                                                Logs[i] = metroGrid1.CurrentRow.Cells[1].Value;
                                                break;
                                            case 2:
                                                Logs[i] = dr3.GetValue(1); // inhand
                                                break;
                                            case 3:
                                                Logs[i] = dr3.GetValue(2); // total made 
                                                break;
                                            case 4:
                                                Logs[i] = dr3.GetValue(3); // total sold
                                                break;
                                            case 5:
                                                Logs[i] = BatchQtyField;
                                                break;
                                            case 6:
                                                Logs[i] = dr3.GetValue(5); // batch qty1 date time 
                                                break;
                                            case 7:
                                                Logs[i] = dr3.GetValue(6); // batch qty2 date time
                                                break;
                                            case 8:
                                                Logs[i] = dr3.GetValue(7); // batch qty3 date time
                                                break;
                                            case 9:
                                                Logs[i] = dr3.GetValue(8); // batch qty1
                                                break;
                                            case 10:
                                                Logs[i] = dr3.GetValue(9); // batch qty2
                                                break;
                                            default:
                                                Logs[i] = dr3.GetValue(10); // batch qty3
                                                break;
                                        }
                                    }
                                    if (itemid == "ITM-000001")
                                    {
                                        EntryNum = this.GetBatchEntryNum(1);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 1);
                                    }
                                    else if (itemid == "ITM-001331")
                                    {
                                        EntryNum = this.GetBatchEntryNum(2);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 2);
                                    }
                                    else if (itemid == "ITM-001332")
                                    {
                                        EntryNum = this.GetBatchEntryNum(3);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 3);
                                    }
                                    else if (itemid == "ITM-001333")
                                    {
                                        EntryNum = this.GetBatchEntryNum(4);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 4);
                                    }
                                    else if (itemid == "ITM-001334")
                                    {
                                        EntryNum = this.GetBatchEntryNum(5);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 5);
                                    }
                                    else if (itemid == "ITM-001335")
                                    {
                                        EntryNum = this.GetBatchEntryNum(6);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 6);
                                    }
                                    else if (itemid == "ITM-001340")
                                    {
                                        EntryNum = this.GetBatchEntryNum(7);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 7);
                                    }
                                    else if (itemid == "ITM-001341")
                                    {
                                        EntryNum = this.GetBatchEntryNum(8);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 8);
                                    }
                                    else if (itemid == "ITM-001344")
                                    {
                                        EntryNum = this.GetBatchEntryNum(9);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 9);
                                    }
                                    else if (itemid == "ITM-001345")
                                    {
                                        EntryNum = this.GetBatchEntryNum(10);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 10);
                                    }
                                }
                            }
                            else
                            {
                                metroGrid1.CurrentRow.Cells[6].Value = 2;
                            }
                        }
                        else if (counter == 2 && BatchQtyField < 0)
                        {
                            GetBatch1Value = MinusBatchQty2(itemid);
                            remainingBatchQtyValue = GetBatch1Value - Math.Abs(BatchQtyField);

                            batchWithDatetime = remainingBatchQtyValue.ToString() + " | " + DateTime.Now.ToString("hh:mm");
                            con.Close();
                            // update pizza station table 
                            updatePizzaStationQuery = @"update PizzaStation_Tbl set Batch2 = @batchqty , BatchQty2 = BatchQty2 + @batchqty2 ,  BusinessDate = @bussinessDateTime  where ItemId = @itemid";
                            PizzaStationCmd = new SqlCommand(updatePizzaStationQuery, con);
                            //  BusinessDate = @bussinessDateTime
                            PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty", batchWithDatetime);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty2", BatchQtyField);
                            PizzaStationCmd.Parameters.AddWithValue("@bussinessDateTime", Convert.ToDateTime(BusinessDateTime));
                            con.Open();
                            int upd = PizzaStationCmd.ExecuteNonQuery();
                            if (upd > 0)
                            {
                                con.Close();
                                FetchPizzaStationQuery = "select * from PizzaStation_Tbl where itemid = @itemid";
                                PizzaStationCmd = new SqlCommand(FetchPizzaStationQuery, con);
                                PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                                con.Open();
                                SqlDataReader dr3 = PizzaStationCmd.ExecuteReader();
                                if (dr3.HasRows == true)
                                {
                                    dr3.Read();
                                    // put data in batch 1 column 
                                    metroGrid1.CurrentRow.Cells[7].Value = dr3.GetValue(6);
                                    //updateCounterTable(1, counterId);
                                    for (int i = 0; i < Logs.Length; i++)
                                    {
                                        switch (i)
                                        {
                                            case 0: Logs[i] = dr3["ItemId"].ToString(); break;
                                            case 1:
                                                Logs[i] = metroGrid1.CurrentRow.Cells[1].Value;
                                                break;
                                            case 2:
                                                Logs[i] = dr3.GetValue(1); // inhand
                                                break;
                                            case 3:
                                                Logs[i] = dr3.GetValue(2); // total made 
                                                break;
                                            case 4:
                                                Logs[i] = dr3.GetValue(3); // total sold
                                                break;
                                            case 5:
                                                Logs[i] = BatchQtyField;
                                                break;
                                            case 6:
                                                Logs[i] = dr3.GetValue(5); // batch qty1 date time 
                                                break;
                                            case 7:
                                                Logs[i] = dr3.GetValue(6); // batch qty2 date time
                                                break;
                                            case 8:
                                                Logs[i] = dr3.GetValue(7); // batch qty3 date time
                                                break;
                                            case 9:
                                                Logs[i] = dr3.GetValue(8); // batch qty1
                                                break;
                                            case 10:
                                                Logs[i] = dr3.GetValue(9); // batch qty2
                                                break;
                                            default:
                                                Logs[i] = dr3.GetValue(10); // batch qty3
                                                break;
                                        }
                                    }
                                    if (itemid == "ITM-000001")
                                    {
                                        EntryNum = this.GetBatchEntryNum(1);
                                        this.UpdateBatchEntryTable(EntryNum, 1);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001331")
                                    {
                                        EntryNum = this.GetBatchEntryNum(2);
                                        this.UpdateBatchEntryTable(EntryNum, 2);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001332")
                                    {
                                        EntryNum = this.GetBatchEntryNum(3);
                                        this.UpdateBatchEntryTable(EntryNum, 3);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001333")
                                    {
                                        EntryNum = this.GetBatchEntryNum(4);
                                        this.UpdateBatchEntryTable(EntryNum, 4);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001334")
                                    {
                                        EntryNum = this.GetBatchEntryNum(5);
                                        this.UpdateBatchEntryTable(EntryNum, 5);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001335")
                                    {
                                        EntryNum = this.GetBatchEntryNum(6);
                                        this.UpdateBatchEntryTable(EntryNum, 6);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001340")
                                    {
                                            EntryNum = this.GetBatchEntryNum(7);
                                            this.UpdateBatchEntryTable(EntryNum, 7);
                                            InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001341")
                                    {
                                        EntryNum = this.GetBatchEntryNum(8);
                                        this.UpdateBatchEntryTable(EntryNum, 8);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001344")
                                    {
                                        EntryNum = this.GetBatchEntryNum(9);
                                        this.UpdateBatchEntryTable(EntryNum, 9);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                    else if (itemid == "ITM-001345")
                                    {
                                        EntryNum = this.GetBatchEntryNum(10);
                                        this.UpdateBatchEntryTable(EntryNum, 10);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                    }
                                }
                            }
                            else
                            {
                                metroGrid1.CurrentRow.Cells[6].Value = 2;
                            }
                        }
                        else if (counter == 2)
                        {
                            con.Close();

                            // update pizza station table 
                            updatePizzaStationQuery = "update PizzaStation_Tbl set Batch3 = @batchqty , BatchQty3 = @batchqty3 , BusinessDate = @bussinessDateTime where ItemId = @itemid";
                            PizzaStationCmd = new SqlCommand(updatePizzaStationQuery, con);
                            PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty", batchWithDatetime);
                            PizzaStationCmd.Parameters.AddWithValue("@batchqty3", BatchQtyField);
                            PizzaStationCmd.Parameters.AddWithValue("@bussinessDateTime", Convert.ToDateTime(BusinessDateTime));
                            con.Open();
                            int upd = PizzaStationCmd.ExecuteNonQuery();
                            if (upd > 0)
                            {
                                con.Close();
                                FetchPizzaStationQuery = "select * from PizzaStation_Tbl where itemid = @itemid";
                                PizzaStationCmd = new SqlCommand(FetchPizzaStationQuery, con);
                                PizzaStationCmd.Parameters.AddWithValue("@itemid", itemid);
                                con.Open();
                                SqlDataReader dr3 = PizzaStationCmd.ExecuteReader();
                                if (dr3.HasRows == true)
                                {
                                    dr3.Read();
                                    // put data in batch 2 column 
                                    metroGrid1.CurrentRow.Cells[8].Value = dr3.GetValue(7);
                                    updateCounterTable(0, counterId);
                                    for (int i = 0; i < Logs.Length; i++)
                                    {
                                        switch (i)
                                        {
                                            case 0: Logs[i] = dr3["ItemId"].ToString(); break;
                                            case 1:
                                                Logs[i] = metroGrid1.CurrentRow.Cells[1].Value;
                                                break;
                                            case 2:
                                                Logs[i] = dr3.GetValue(1); // inhand
                                                break;
                                            case 3:
                                                Logs[i] = dr3.GetValue(2); // total made 
                                                break;
                                            case 4:
                                                Logs[i] = dr3.GetValue(3); // total sold
                                                break;
                                            case 5:
                                                Logs[i] = BatchQtyField;
                                                break;
                                            case 6:
                                                Logs[i] = dr3.GetValue(5); // batch qty1 date time 
                                                break;
                                            case 7:
                                                Logs[i] = dr3.GetValue(6); // batch qty2 date time
                                                break;
                                            case 8:
                                                Logs[i] = dr3.GetValue(7); // batch qty3 date time
                                                break;
                                            case 9:
                                                Logs[i] = dr3.GetValue(8); // batch qty1
                                                break;
                                            case 10:
                                                Logs[i] = dr3.GetValue(9); // batch qty2
                                                break;
                                            default:
                                                Logs[i] = dr3.GetValue(10); // batch qty3
                                                break;
                                        }
                                    }
                                    if (itemid == "ITM-000001")
                                    {

                                        EntryNum = this.GetBatchEntryNum(1);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 1);

                                    }
                                    else if (itemid == "ITM-001331")
                                    {

                                        EntryNum = this.GetBatchEntryNum(2);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 2);

                                    }
                                    else if (itemid == "ITM-001332")
                                    {

                                        EntryNum = this.GetBatchEntryNum(3);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 3);

                                    }
                                    else if (itemid == "ITM-001333")
                                    {

                                        EntryNum = this.GetBatchEntryNum(4);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 4);

                                    }
                                    else if (itemid == "ITM-001334")
                                    {

                                        EntryNum = this.GetBatchEntryNum(5);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 5);

                                    }
                                    else if (itemid == "ITM-001335")
                                    {

                                        EntryNum = this.GetBatchEntryNum(6);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 6);

                                    }
                                    else if (itemid == "ITM-001340")
                                    {

                                        EntryNum = this.GetBatchEntryNum(7);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 7);

                                    }
                                    else if (itemid == "ITM-001341")
                                    {

                                        EntryNum = this.GetBatchEntryNum(8);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 8);

                                    }
                                    else if (itemid == "ITM-001344")
                                    {

                                        EntryNum = this.GetBatchEntryNum(9);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 9);

                                    }
                                    else if (itemid == "ITM-001345")
                                    {

                                        EntryNum = this.GetBatchEntryNum(10);
                                        InsertRecordInPizzaLog(Logs, DatesArray, EntryNum);
                                        this.UpdateBatchEntryTable(EntryNum, 10);

                                    }
                                    //con.Close();
                                }
                            }
                            else
                            {
                                metroGrid1.CurrentRow.Cells[6].Value = 2;
                            }
                        }
                    }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RefreshGrid(DataGridViewCell inhand, DataGridViewCell totalmade, string itemid)
        {
            try
            {
                SqlConnection con = db.Sql_Connection();
                string Get = "select * from PizzaStation_Tbl where itemid=@itemid";
                SqlCommand FetchRowcmd = new SqlCommand(Get, con);
                FetchRowcmd.Parameters.AddWithValue("@itemid", itemid);
                SqlDataReader dr = FetchRowcmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    dr.Read();
                    inhand.Value = dr.GetValue(1);
                    totalmade.Value = dr.GetValue(2);
                }
                else
                {

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateBatchQty(string itemid, DataGridViewCell[] cell)
        {
            string UpDateBatchQtyQuery;
            SqlCommand UpdateCmd;
            // Update data in a pizza station table 
            SqlConnection con = db.Sql_Connection();
            // Current row check 
            string ExistQuery = "select * from PizzaStation_Tbl Where itemid = @ItemId";
            SqlCommand cmd2 = new SqlCommand(ExistQuery, con);
            cmd2.Parameters.AddWithValue("@ItemId", itemid);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                
                if (dr.GetValue(1).ToString() != "" && dr.GetValue(2).ToString() != "")
                {
                    con.Close();
                    UpDateBatchQtyQuery = "update PizzaStation_Tbl set InHand = InHand + @inhand , TotalMade = TotalMade + @TotalMade  where ItemId = @ItemId";
                    UpdateCmd = new SqlCommand(UpDateBatchQtyQuery, con);
                    UpdateCmd.Parameters.AddWithValue("@ItemId", itemid); // Item Id
                    UpdateCmd.Parameters.AddWithValue("@inhand", cell[0].Value); // Inhand
                    UpdateCmd.Parameters.AddWithValue("@TotalMade", cell[1].Value); // totalmade
                    con.Open();
                    if (UpdateCmd.ExecuteNonQuery() > 0)
                    {
                        this.RefreshGrid(cell[0], cell[1], itemid);
                    }
                    else
                    {

                    }
                }
                else
                {
                    con.Close();
                    UpDateBatchQtyQuery = "update PizzaStation_Tbl set InHand = @inhand , TotalMade = @TotalMade where ItemId = @ItemId";
                    UpdateCmd = new SqlCommand(UpDateBatchQtyQuery, con);
                    UpdateCmd.Parameters.AddWithValue("@ItemId", itemid); // Item Id
                    UpdateCmd.Parameters.AddWithValue("@inhand", cell[0].Value); // Inhand
                    UpdateCmd.Parameters.AddWithValue("@TotalMade", cell[1].Value); // totalmade
                    con.Open();
                    if (UpdateCmd.ExecuteNonQuery() > 0)
                    {
                        this.RefreshGrid(cell[0], cell[1], itemid);
                    }
                    else
                    {

                    }
                }
            }
            con.Close();
        }
        public void UpateBatchEntry()
        {
            int BatchQty = 0;
            int getrowcount = 0;
            if ((metroGrid1.CurrentRow.Cells[5].EditedFormattedValue != ""))
            {
                BatchQty = int.Parse(metroGrid1.CurrentRow.Cells[5].EditedFormattedValue.ToString());
                if (BatchQty <= 0 || BatchQty > 0)
                {
                    this.ItemIdColumn = metroGrid1.CurrentRow.Cells[0].Value.ToString();
                    columns[0] = metroGrid1.CurrentRow.Cells[2];// onhand quantity 
                    columns[1] = metroGrid1.CurrentRow.Cells[3];
                    columns[2] = metroGrid1.CurrentRow.Cells[5];
                    columns[0].Value = BatchQty;
                    columns[1].Value = BatchQty;
                    this.UpdateBatchQty(this.ItemIdColumn, columns);
                    this.UpdateDataInBatchFields(BatchQty, this.ItemIdColumn);
                    metroGrid1.RefreshEdit();
                }
            }
        }
        private void metroGrid1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {    
            this.UpateBatchEntry();
            metroGrid1.CurrentRow.Cells[5].Value = "";
        }
        private void metroGrid1_KeyUp(object sender, KeyEventArgs e)
        {}

        private void TakeInput(string pInput)
        {
            object curValue = metroGrid1.Rows[iCurrentRowIndx].Cells[5].Value;

            if (curValue != null)
            {
                 string newValue = curValue.ToString() + pInput;
                 metroGrid1.Rows[iCurrentRowIndx].Cells[5].Value = newValue;
            }
            else
                metroGrid1.Rows[iCurrentRowIndx].Cells[5].Value = pInput;
        }

        private void InvokeKeyPress(Char pKeyPressed)
        {
            TakeInput(pKeyPressed.ToString());
        }

        private void PizzaStation_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyMapping(e.KeyChar);
        }
        public void KeyMapping(char inputkey)
        {
            switch (inputkey)
            {
                case 'a':
                case '1':
                    InvokeKeyPress('1');
                    break;
                case 'b':
                case '5':
                    InvokeKeyPress('5');
                    break;
                case 'c':
                case '2':
                    InvokeKeyPress('2');
                    break;
                case 'd':
                case '6':
                    InvokeKeyPress('6');
                    break;
                case 'e':
                case '3':
                    InvokeKeyPress('3');
                    break;
                case 'f':
                case '7':
                    InvokeKeyPress('7');
                    break;
                case 'g':
                case '4':
                    InvokeKeyPress('4');
                    break;
                case 'h':
                case '8':
                    InvokeKeyPress('8');
                    break;
                case 'i':
                case '0':
                    InvokeKeyPress('0');
                    break;
                case 'j':
                    InvokeKeyPress('9');
                    break;
                case 'k':
                case '+':
                    metroGrid1.Focus();
                    SendKeys.Send("{UP}");
                    break;
                case '-':
                    InvokeKeyPress('-');
                    break;

                case 'l':
                case (char)Keys.Back:
                    metroGrid1.Focus();
                    SendKeys.Send("{DOWN}");
                    break;
                case 'm':
                    break;
                case 'n':
                case (char)Keys.Enter:
                    this.UpateBatchEntry();
                    metroGrid1.CurrentRow.Cells[5].Value = "";
                    break;
                case 'o':
                    break;
                case 'p':
                    break;
                default:
                    break;
            }
        }

        private void metroGrid1_Enter(object sender, EventArgs e)
        {
            string itemid = "";
            if (metroGrid1.CurrentRow.Cells[5].EditedFormattedValue != "")
            {
                itemid = metroGrid1.CurrentRow.Cells[0].EditedFormattedValue.ToString();
                if (itemid == "ITM-001345")
                {
                    metroGrid1.CurrentRow.Cells[5].Value = "";
                }
            }
        }
        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (metroGrid1.CurrentRow != null)
                {
                    iCurrentRowIndx = metroGrid1.SelectedRows[0].Index;
                }
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KDSStartup obj = new KDSStartup();
            this.Hide();
            obj.Show();
        }
    }
}
