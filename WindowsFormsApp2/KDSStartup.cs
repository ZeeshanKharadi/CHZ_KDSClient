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
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Threading;

namespace MCKDS
{
    public partial class KDSStartup : MetroFramework.Forms.MetroForm
    {

        private FryingStation fmFryingStation;
        private CustomerDisplayForm fmCustomerStation;
        private OrderGridForm fmPreparingStation;
        private OrderGridForm fmExpediteStation;
        private OrderGridForm fmFOH2;
        string FryingStation;
        String PreparingStation;
        string ExpediteStation;
        string CustomerStation;
        string FOH2;
        Thread t = new Thread(StartForm);

        public KDSStartup()
        {
            InitializeComponent();
        }
        public static void StartForm()
        {
            Application.Run(new SplashScreen());
        }

        private void KDSStartup_Load(object sender, EventArgs e)
        {
            //t.Start();
            InitializeTiles();
            //t.Abort();
            //this.Activate();
            //GetStations();
        }
        private void GetStations()
        {
            try
            {

                timer1.Enabled = false;
                lblError.Visible = false;
                FryingStation = ConfigurationManager.AppSettings["Frying"];
                PreparingStation = ConfigurationManager.AppSettings["Preparing"];
                ExpediteStation = ConfigurationManager.AppSettings["Expedite"];
                FOH2 = ConfigurationManager.AppSettings["FOH2"];
                CustomerStation = ConfigurationManager.AppSettings["Customer"];


                if (FryingStation == null)
                { tlFryingStation.Visible = false; }
                if (PreparingStation == null)
                { tlPreparingStation.Visible = false; }
                if (ExpediteStation == null)
                { tlExpediteStation.Visible = false; }
                if (CustomerStation == null)
                { tlCustomerStation.Visible = false; }
                if (FOH2 == null)
                { tlFOH2.Visible = false; }

                tlExpediteStation.Enabled = false;
                tlCustomerStation.Enabled = false;

                dbClass dbcls = new dbClass();
                string values = dbcls.GetConfiguration(3);

                char[] spearator = { ',' };

                String[] stationslist = values.Split(spearator);

                foreach (string station in stationslist)
                {
                    if (station == "2")
                    {
                        tlExpediteStation.Enabled = true;
                    }
                    else if (station == "3")
                    {
                        tlFOH2.Enabled = true;
                    }
                    else if (station == "4")
                    {
                        tlCustomerStation.Enabled = true;
                    }
                }

                string filepath = @"Settings.txt";
                if (File.Exists(filepath))
                {
                    string[] lines = File.ReadAllLines(filepath);
                    string line = lines[1].Substring(2, lines[1].Length - 2);

                    if (line == "Frying Station")
                    {
                        tlFryingStation_Click(tlFryingStation, EventArgs.Empty);
                    }
                    else if (line == "Preparing Station")
                    {
                        tlPreparingStation_Click(tlPreparingStation, EventArgs.Empty);
                    }
                    else if (line == "Expedite Station")
                    {
                        tlExpediteStation_Click(tlExpediteStation, EventArgs.Empty);
                    }
                    else if (line == "FOH2")
                    {
                        tlFOH2_Click(tlFOH2, EventArgs.Empty);
                    }
                    else if (line == "Customer Station")
                    {
                        tlCustomerStation_Click(tlCustomerStation, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Object reference not set to an instance of an object.")
                {
                    t.Abort();
                    SqlConnection cnn = new SqlConnection();

                    dbClass dbcls = new dbClass();
                    cnn = dbcls.Sql_Connection();
                    var server = cnn.DataSource;

                    if (server == "")
                    {
                        Connection f2 = new Connection();
                        f2.ShowDialog();
                        KDSStartup_Load(this, EventArgs.Empty);
                    }
                    else
                    {
                        lblError.Text = "Unable To Connect KDS Server.";
                        lblError.Visible = true;
                    }
                }
            }
        }
        public void InitializeTiles()
        {
            metroPizza.Enabled = false;
            metroPizza.UseCustomBackColor = true;
            metroPizza.BackColor = Color.FromArgb(255, 203, 4);

            tlCustomerStation.UseCustomBackColor = true;
            tlCustomerStation.BackColor = Color.FromArgb(255, 203, 4);
            tlExpediteStation.UseCustomBackColor = true;
            tlExpediteStation.BackColor = Color.FromArgb(255, 203, 4);
            tlFryingStation.UseCustomBackColor = true;
            tlFryingStation.BackColor = Color.FromArgb(255, 203, 4);
            tlPreparingStation.UseCustomBackColor = true;
            tlPreparingStation.BackColor = Color.FromArgb(255, 203, 4);
            tlMasterDataSync.UseCustomBackColor = true;
            tlMasterDataSync.BackColor = Color.FromArgb(255, 203, 4);
            tlSettings.UseCustomBackColor = true;
            tlSettings.BackColor = Color.FromArgb(255, 203, 4);
            tlFOH2.UseCustomBackColor = true;
            tlFOH2.BackColor = Color.FromArgb(255, 203, 4);

            metroPizza.TileTextFontSize = MetroTileTextSize.Medium;
            metroPizza.TileTextFontWeight = MetroTileTextWeight.Bold;

            tlCustomerStation.TileTextFontSize = MetroTileTextSize.Medium;
            tlCustomerStation.TileTextFontWeight = MetroTileTextWeight.Bold;
            tlExpediteStation.TileTextFontSize = MetroTileTextSize.Medium;
            tlExpediteStation.TileTextFontWeight = MetroTileTextWeight.Bold;
            tlFryingStation.TileTextFontSize = MetroTileTextSize.Medium;
            tlFryingStation.TileTextFontWeight = MetroTileTextWeight.Bold;
            tlPreparingStation.TileTextFontSize = MetroTileTextSize.Medium;
            tlPreparingStation.TileTextFontWeight = MetroTileTextWeight.Bold;
            tlMasterDataSync.TileTextFontSize = MetroTileTextSize.Medium;
            tlMasterDataSync.TileTextFontWeight = MetroTileTextWeight.Bold;
            tlSettings.TileTextFontSize = MetroTileTextSize.Medium;
            tlSettings.TileTextFontWeight = MetroTileTextWeight.Bold;
            tlFOH2.TileTextFontSize = MetroTileTextSize.Medium;
            tlFOH2.TileTextFontWeight = MetroTileTextWeight.Bold;

        }

        private void tlFryingStation_Click(object sender, EventArgs e)
        {

            if ((fmFryingStation == null) || (fmFryingStation.IsDisposed == true))
            {
                fmFryingStation = new FryingStation();
                //fmFryingStation.Show();
                fmFryingStation.WindowState = FormWindowState.Maximized;
                fmFryingStation.Focus();
                fmFryingStation.ShowDialog();
            }

            else
            {
                fmFryingStation.WindowState = FormWindowState.Maximized;
                fmFryingStation.Focus();
            }

        }

        private void tlCustomerStation_Click(object sender, EventArgs e)
        {

            if ((fmCustomerStation == null) || (fmCustomerStation.IsDisposed == true))
            {
                fmCustomerStation = new CustomerDisplayForm();

                fmCustomerStation.WindowState = FormWindowState.Maximized;
                fmCustomerStation.Focus();
                fmCustomerStation.ShowDialog();

            }

            else
            {
                fmCustomerStation.WindowState = FormWindowState.Maximized;
                fmCustomerStation.Focus();
            }

        }

        private void tlPreparingStation_Click(object sender, EventArgs e)
        {

            if ((fmPreparingStation == null) || (fmPreparingStation.IsDisposed == true))
            {
                fmPreparingStation = new OrderGridForm("MOH", 1); // Preparing Station
                fmPreparingStation.WindowState = FormWindowState.Maximized;
                fmPreparingStation.Focus();
                fmPreparingStation.ShowDialog();
            }
            else
            {
                fmPreparingStation.WindowState = FormWindowState.Maximized;
                fmPreparingStation.Focus();
            }
        }

        private void tlExpediteStation_Click(object sender, EventArgs e)
        {
            if ((fmExpediteStation == null) || (fmExpediteStation.IsDisposed == true))
            {
                fmExpediteStation = new OrderGridForm("ORDER ASSEMBLE", 2); // Expedite Station
                fmExpediteStation.WindowState = FormWindowState.Maximized;
                fmExpediteStation.Focus();
                fmExpediteStation.ShowDialog();
            }
            else
            {
                fmExpediteStation.WindowState = FormWindowState.Maximized;
                fmExpediteStation.Focus();
            }
        }
        private void tlMasterDataSync_Click(object sender, EventArgs e)
        {
            dbClass dbcls = new dbClass();
            dbcls.ResetPizzaStation();
            dbcls.ResetBatchEntryTable();
            dbcls.UpdateDayWiseBatchStatus();
            if (dbcls.SetMasterSyncOn()) 

                MessageBox.Show("Master Data Sync Started");
            else
                MessageBox.Show("Unable to Master Data Sync Started");
        }

        private void settings_Click(object sender, EventArgs e)
        {
            KDSSystemSettings form = new KDSSystemSettings();
            form.Owner = this;
            form.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetStations();
            //lblError.Visible = false;
        }

        private void tlFOH2_Click(object sender, EventArgs e)
        {
            if ((fmFOH2 == null) || (fmFOH2.IsDisposed == true))
            {
                // fmFOH2 = new OrderGridForm("Front of House - 2 (FOH2)"); // FOH2
                fmFOH2 = new OrderGridForm("DISPATCH", 3); // FOH2

                fmFOH2.WindowState = FormWindowState.Maximized;

                fmFOH2.Focus();
                fmFOH2.ShowDialog();
            }

            else
            {
                fmFOH2.WindowState = FormWindowState.Maximized;
                fmFOH2.Focus();
            }
        }

        // bilal 
        private void metroPizza_Click(object sender, EventArgs e)
        {
            dbClass db = new dbClass();
            PizzaStation ps = new PizzaStation();
            string timeNow = DateTime.Now.ToString("hh:mm:ss tt");
            try
            {
                string PizzaStationUpd = "";
                string updcountertable = "";
                SqlCommand updcounter;
                SqlCommand PizzaStationCmd;

                SqlConnection con = db.Sql_Connection();
                SqlCommand cmd = new SqlCommand("select * from TimeTable", con);
                SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.HasRows == true)
                //{
                //    dr.Read();
                //    if (DateTime.Parse(timeNow) >= DateTime.Parse(dr["StartTime"].ToString()) && DateTime.Parse(timeNow) <= DateTime.Parse(dr["EndTime"].ToString()))
                //    {
                //        PizzaStationUpd = @"update PizzaStation_Tbl set InHand = null,TotalSold = null,TotalMade = null, 
                //                                BatchEntry = null,Last4BatchShowWIthQtyAnfTime = null ,Batch2 = null,Batch3=null,
                //                                BatchQty1=null,BatchQty2=null,BatchQty3=null,BusinessDate=null";

                //        //MessageBox.Show("You Can Not Open Pizza Station Between" + dr["StartTime"] + "And" + dr["EndTime"]);
                //        dr.Close();
                //        PizzaStationCmd = new SqlCommand(PizzaStationUpd, con);
                //        if (PizzaStationCmd.ExecuteNonQuery() > 0)
                //        {
                //            updcountertable = "update CounterTable set counter_ = 0";
                //            updcounter = new SqlCommand(updcountertable, con);
                //            updcounter.ExecuteNonQuery();
                //        }
                //        ps.Owner = this;
                //        ps.Show();
                //    }
                //    else
                //    {
                //        ps.Owner = this;
                //        ps.Show();
                //    }
                //}
                con.Close();
            }
            catch (Exception ex)
            {
                //WriteToFile(ex.Message);
            }
            ps.Show();
        }
    }
}
