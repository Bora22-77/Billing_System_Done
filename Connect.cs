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


    //Option 2 to connectdatabase
    public class Database
    {
        private static Database instance;
        private string connectionString = @"Server=localhost\\DBMGM;Database=DSFinal;Trusted_connection=True;";

        private Database() { }

        public static Database Instance
        {
            get
            {
                if (instance == null)
                    instance = new Database();
                return instance;
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
