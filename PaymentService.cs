using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System
{
    public class PaymentService
    {
        private string connectionString = "your_connection_string_here";

        public void MakePayment(int billId, decimal amount, string method)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = @"
            INSERT INTO Payments (BillId, Amount, Method, PaymentDate)
            VALUES (@b, @a, @m, GETDATE())";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@b", billId);
            cmd.Parameters.AddWithValue("@a", amount);
            cmd.Parameters.AddWithValue("@m", method);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public DataTable GetPayment(int billId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM Payments WHERE BillId = @id";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@id", billId);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
