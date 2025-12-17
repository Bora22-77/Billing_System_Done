using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System
{
    public class OrderItemService
    {
        private string connectionString = "your_connection_string_here";

        public void AddOrderItem(int orderId, int productId, int qty, decimal price)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price) VALUES (@o, @p, @q, @pr)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@o", orderId);
            cmd.Parameters.AddWithValue("@p", productId);
            cmd.Parameters.AddWithValue("@q", qty);
            cmd.Parameters.AddWithValue("@pr", price);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public DataTable GetOrderItems(int orderId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM OrderItems WHERE OrderId = @id";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@id", orderId);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public void UpdateOrderItem(int orderItemId, int qty, decimal price)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "UPDATE OrderItems SET Quantity = @q, Price = @p WHERE OrderItemId = @id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", orderItemId);
            cmd.Parameters.AddWithValue("@q", qty);
            cmd.Parameters.AddWithValue("@p", price);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteOrderItem(int orderItemId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "DELETE FROM OrderItems WHERE OrderItemId = @id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", orderItemId);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
