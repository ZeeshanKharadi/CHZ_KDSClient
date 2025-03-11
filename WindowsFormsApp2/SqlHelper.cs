using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCKDS
{
    public class SqlHelper
    {
        SqlConnection cnn;
        public SqlHelper(string connectionString)
        {
            cnn = new SqlConnection(connectionString);
        }

        public bool IsConnection
        {
            get
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                return true;
            }
        }
    }
}
