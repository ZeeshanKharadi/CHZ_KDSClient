using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCKDS
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            if (ServerName.Text == "")
            {
                MessageBox.Show("KDS Server Name can not be null.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            //string ServerName = "MAISON-11282906";
            string DBName = "MCKDS";
            string Username = "KDS";
            string password = "1234567";
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", ServerName.Text, DBName, Username, password);

            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("MCKDSConnectionString", connectionString);
                }

                connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", ServerName.Text, DBName, Username, password);

                helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("MCKDS.Properties.Settings.MCKDSConnectionString", connectionString);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Connect KDS Server." + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Environment.Exit(1);
        }
    }
}
