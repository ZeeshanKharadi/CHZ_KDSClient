using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCKDS
{

    public partial class KDSSystemSettings : Form
    {
        //private static crlOrder ActiveOrder;
        //int OrderStatusID = 0;
        public KDSSystemSettings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            string filepath = @"Settings.txt";

            //try
            //{
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                string commport = lines[3].Substring(2, lines[3].Length - 2);

                if (commport != "")
                {
                    cboPorts.Text = commport;

                    string[] ArrayComPortsNames = null;
                    int index = -1;
                    string ComPortName = null;

                    //Com Ports
                    ArrayComPortsNames = SerialPort.GetPortNames();
                    do
                    {
                        index += 1;
                        cboPorts.Items.Add(ArrayComPortsNames[index]);
                    } while (!((ArrayComPortsNames[index] == ComPortName) || (index == ArrayComPortsNames.GetUpperBound(0))));
                    Array.Sort(ArrayComPortsNames);

                    if (index == ArrayComPortsNames.GetUpperBound(0))
                    {
                        ComPortName = ArrayComPortsNames[0];
                    }
                }
                else
                {
                    string[] ArrayComPortsNames = null;
                    int index = -1;
                    string ComPortName = null;

                    //Com Ports
                    ArrayComPortsNames = SerialPort.GetPortNames();
                    do
                    {
                        index += 1;
                        cboPorts.Items.Add(ArrayComPortsNames[index]);

                    } while (!((ArrayComPortsNames[index] == ComPortName) || (index == ArrayComPortsNames.GetUpperBound(0))));
                    Array.Sort(ArrayComPortsNames);

                    if (index == ArrayComPortsNames.GetUpperBound(0))
                    {
                        ComPortName = ArrayComPortsNames[0];
                    }
                }
            }
            catch (Exception)
            {
            }


            // Settings
            cmbStations.Items.Add("Frying Station");
            cmbStations.Items.Add("Preparing Station");

            dbClass dbcls = new dbClass();
            string values = dbcls.GetConfiguration(3);

            char[] spearator = { ',' };
            String[] stationslist = values.Split(spearator);
            foreach (string station in stationslist)
            {
                if (station == "2")
                {
                    chkExpediteStation.Checked = true;
                }
                else if (station == "3")
                {
                    chkFOH2.Checked = true;
                }

                else if (station == "4")
                {
                    chkCustomerStation.Checked = true;
                }
            }


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MCKDSConnectionString"].ConnectionString);
            conn.Open();
            string Query = @"Select * from OrderTypes where Enable=1";
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chkOrderType.Items.Add(dt.Rows[i]["OrderType"].ToString());
                clbsyncorders.Items.Add(dt.Rows[i]["OrderType"].ToString());
            }
            conn.Close();


            if (File.Exists(filepath))
            {
                string[] lines = File.ReadAllLines(filepath);

                txtStationName.Text = lines[0].Substring(2, lines[0].Length - 2);
                cmbStations.SelectedText = lines[1].Substring(2, lines[1].Length - 2);
                //dk


                if (cmbStations.Text == "preparing station")
                {
                    cmbinitilizer.Text = "";
                }
                else
                {
                    cmbinitilizer.Text = lines[4].Substring(2, lines[4].Length - 2);
                }

            
                char[] spearator2 = { ',' };
                string[] channelslist = lines[2].Split(spearator2);


                foreach (string list in channelslist)
                {

                    if (list == "DINE IN")
                    {
                        chkOrderType.SetItemChecked(0, true);
                    }
                    else if (list == "TAKE AWAY")
                    {
                        chkOrderType.SetItemChecked(1, true);
                    }
                    else if (list == "DELIVERY")
                    {
                        chkOrderType.SetItemChecked(2, true);
                    }
                }
            }


            string values1 = dbcls.GetConfiguration(5);

            char[] spearator1 = { ',' };
            String[] stationslist1 = values1.Split(spearator1);
            foreach (string list in stationslist1)
            {
                if (list == "DINE IN")
                {
                    clbsyncorders.SetItemChecked(0, true);
                }
                else if (list == "TAKE AWAY")
                {
                    clbsyncorders.SetItemChecked(1, true);
                }
                else if (list == "DELIVERY")
                {
                    clbsyncorders.SetItemChecked(2, true);
                }
            }
            //
            if (cmbStations.Text == "Preparing Station")
            {
                cmbinitilizer.Enabled = true;
            }
            else
            {
                cmbinitilizer.Enabled = false;
                cmbinitilizer.Text = "";

            }

            //
            //}

            //catch (Exception)
            //{
            //    MessageBox.Show("Error Settings: Unable to Connect KDS Database Server.");
            //    //this.Close();
            //}
        }

        private void apply_Click(object sender, EventArgs e)
        {
            try
            {
                string values = "0,1";
                if (chkExpediteStation.Checked == true)
                {
                    values = "0,1,2";
                }
                if (chkCustomerStation.Checked == true)
                {
                    values = "0,1,3";
                }
                if (chkCustomerStation.Checked == true && chkExpediteStation.Checked == true)
                {
                    values = "0,1,2,3";
                }
                if (chkCustomerStation.Checked == true && chkExpediteStation.Checked == true && chkFOH2.Checked == true)
                {
                    values = "0,1,2,3,4";
                }
                dbClass DB = new dbClass();
                DB.UpdateConfiguration("3", values);

                string substr = values.Substring(values.Length - 1);

                DB.UpdateConfiguration("4", substr);

                string tmpStr = "";

                tmpStr = "1 " + txtStationName.Text + "\n";
                if (cmbStations.SelectedItem == null)
                {
                    tmpStr += "2 " + cmbStations.Text + "\n";
                }
                else
                {
                    tmpStr += "2 " + cmbStations.SelectedItem.ToString() + "\n";
                }

                if (chkOrderType.CheckedItems.Count > 0)
                {
                    foreach (string itemChecked in chkOrderType.CheckedItems)
                    {
                        tmpStr += itemChecked + ",";
                    }
                }

                else
                {
                    MessageBox.Show("Select atleast one channel");
                    return;
                }



                tmpStr += "\n4 ";
                tmpStr += cboPorts.Text;
                // Preparation station option set
                tmpStr += "\n5 ";
                tmpStr += cmbinitilizer.Text;
           




                string filepath = @"Settings.txt";
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }

                string syncorder = "";
                if (clbsyncorders.CheckedItems.Count > 0)
                {
                    foreach (string itemChecked in clbsyncorders.CheckedItems)
                    {
                        syncorder += itemChecked + ",";
                    }
                    DB.UpdateConfiguration("5", syncorder);
                }
                else
                {
                    MessageBox.Show("Select atleast one sync suspended order channel");
                    return;
                }

                if (cmbStations.Text == "FOH2")
                {
                    if (!File.Exists(filepath))
                    {
                        using (StreamWriter sw = File.CreateText(filepath))
                        {
                            sw.WriteLine(tmpStr);
                        }
                    }
                }
                else if (cmbStations.Text == "Expedite Station")
                {
                    if (!File.Exists(filepath))
                    {
                        using (StreamWriter sw = File.CreateText(filepath))
                        {
                            sw.WriteLine(tmpStr);
                        }
                    }
                }
                else if (cmbStations.Text == "Customer Station")
                {
                    if (!File.Exists(filepath))
                    {
                        using (StreamWriter sw = File.CreateText(filepath))
                        {
                            sw.WriteLine(tmpStr);
                        }
                    }
                }
                else if (cmbStations.Text == "Frying Station")
                {
                    if (!File.Exists(filepath))
                    {
                        using (StreamWriter sw = File.CreateText(filepath))
                        {
                            sw.WriteLine(tmpStr);
                        }
                    }
                }
                else if (cmbStations.Text == "Preparing Station")
                {
                    if (!File.Exists(filepath))
                    {
                        using (StreamWriter sw = File.CreateText(filepath))
                        {
                            sw.WriteLine(tmpStr);
                        }
                    }
                }
                else if (cmbStations.Text == "")
                {
                    MessageBox.Show("Please Select Station First");
                }

                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void cmbStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStations.Text == "Frying Station" || cmbStations.Text == "Preparing Station")
            {
                chkOrderType.Enabled = false;
            }
            else
            {
                chkOrderType.Enabled = true;
            }

            if (cmbStations.Text == "Preparing Station" || cmbStations.Text == "Frying Station")
            {
                cmbinitilizer.Enabled = true;
            }
            else
            {
                cmbinitilizer.Enabled = false;
                cmbinitilizer.Text = "";
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void chkExpediteStation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpediteStation.Checked == false)
            {
                cmbStations.Items.Remove("Expedite Station");
                cmbStations.Text = "";
                chkOrderType.Enabled = false;
            }
            else
            {
                cmbStations.Items.Add("Expedite Station");
            }
        }

        private void chkCustomerStation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpediteStation.Checked == false)
            {
                cmbStations.Items.Remove("Customer Station");
                cmbStations.Text = "";
                chkOrderType.Enabled = false;
            }
            else
            {
                cmbStations.Items.Add("Customer Station");
            }
        }
       
        private void btnconnect_Click(object sender, EventArgs e)
        {
            //string ServerName = "DESKTOP-6SR57CR";
            //string DBName = "MCKDS";
            //string Username = "KDS";
            //string password = "1234567";
            SqlConnection cnn;
            string connetionString = " Data Source=" + ServerName.Text + @";Initial Catalog=" + DBName.Text + ";User ID=" + Username.Text + ";Password=" + password.Text + ";Integrated Security=false;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }
        private void chkFOH2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFOH2.Checked == false)
            {
                cmbStations.Items.Remove("FOH2");
                cmbStations.Text = "";
                chkOrderType.Enabled = false;
            }
            else
            {
                cmbStations.Items.Add("FOH2");
            }
        }

        private void cmbinitilizer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbinitilizer.SelectedItem == "Pizza")
            {
                (this.Owner as KDSStartup).metroPizza.Enabled = true;
            }
            else
            {
                (this.Owner as KDSStartup).metroPizza.Enabled = false;
            }
        }



        //private void cmbinitilizer_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(cmbinitilizer.SelectedItem == "Pizza")
        //    {
        //        (this.Owner as KDSStartup).metroPizza.Enabled = true;
        //    }
        //    else
        //    {
        //        (this.Owner as KDSStartup).metroPizza.Enabled = false;
        //    }
        //}
    }
}
