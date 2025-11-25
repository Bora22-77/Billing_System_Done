using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System
{
    public  class Connect
    {
        public  SqlConnection conn = new SqlConnection("Server=localhost\\DBMGM;Database=DSFinal;Trusted_connection=True;");
        public  void OpenConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public  void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
