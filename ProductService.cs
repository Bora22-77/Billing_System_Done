using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System
{
    public class ProductService
    {
        Connect connect = new Connect();

        public void InsertProduct(Product p)
        {
            string query = @"INSERT INTO Product (CategoryId, ProductName, Price, Quantity, Description)
                         VALUES (@CategoryId, @Name, @Price, @Qty, @Desc)";

            connect.OpenConnection();

            using (SqlCommand cmd = new SqlCommand(query, connect.conn))
            {
                cmd.Parameters.AddWithValue("@CategoryId", p.CategoryId);
                cmd.Parameters.AddWithValue("@Name", p.ProductName);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Qty", p.Quantity);
                cmd.Parameters.AddWithValue("@Desc", p.Description);


                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateProduct(Product p)
        {
                string query = @"UPDATE Product SET CategoryId=@CategoryId, ProductName=@ProductName,
                                 Price=@Price, Quantity=@Quantity, Description=@Description
                                 WHERE ProductId=@ProductId";
            connect.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, connect.conn))
                {
                    cmd.Parameters.AddWithValue("@ProductId", p.ProductId);
                    cmd.Parameters.AddWithValue("@CategoryId", p.CategoryId);
                    cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                    cmd.Parameters.AddWithValue("@Price", p.Price);
                    cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
                    cmd.Parameters.AddWithValue("@Description", p.Description);
                    cmd.ExecuteNonQuery();
                connect.CloseConnection();
                }
        }

        public void DeleteProduct(int productId)
        {
                
                string query = "DELETE FROM Product WHERE ProductId=@ProductId";
            connect.OpenConnection();
            using (SqlCommand cmd = new SqlCommand(query, connect.conn))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.ExecuteNonQuery();
                connect.CloseConnection() ;
                }
            
        }
        public DataTable SearchProducts(string keyword)
        {
                
                string query = @"SELECT * FROM Product 
                         WHERE ProductName LIKE @keyword OR Description LIKE @keyword";
            connect.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, connect.conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                //connect.CloseConnection();
                }
        }


        public List<Product> GetAllProducts()
        {
            Connect connect = new Connect();
            List<Product> list = new List<Product>();


            connect.OpenConnection();

            string query = @"
            SELECT 
                p.ProductId,
                p.ProductName,
                p.Price,
                p.Quantity,
                p.Description,
                p.CategoryId,
                c.CategoryName
            FROM Product p
            JOIN Category c ON p.CategoryId = c.CategoryId
        ";

            SqlCommand cmd = new SqlCommand(query, connect.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product p = new Product
                {
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Price = reader.GetDecimal(2),
                    Quantity = reader.GetInt32(3),
                    Description = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    CategoryId = reader.GetInt32(5),

                    Category = new Category
                    {
                        CategoryId = reader.GetInt32(5),
                        CategoryName = reader.GetString(6)
                    }
                };

                list.Add(p);
            }
            return list;
        }

    }
}
