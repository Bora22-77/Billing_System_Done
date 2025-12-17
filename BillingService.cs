using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System
{
    public class BillingService
    {
        private string connectionString = "your_connection_string_here";

        public void CreateBill(int orderId, decimal totalAmount)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "INSERT INTO Billing (OrderId, TotalAmount, CreatedDate) VALUES (@o, @t, GETDATE())";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@o", orderId);
            cmd.Parameters.AddWithValue("@t", totalAmount);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public DataTable GetBill(int orderId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM Billing WHERE OrderId = @id";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@id", orderId);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public void UpdateBill(int billId, decimal newAmount)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "UPDATE Billing SET TotalAmount = @amt WHERE BillId = @id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@amt", newAmount);
            cmd.Parameters.AddWithValue("@id", billId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteBill(int billId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "DELETE FROM Billing WHERE BillId = @id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", billId);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
