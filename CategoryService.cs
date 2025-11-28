using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System
{
    public class CategoryService
    {
        Connect connect = new Connect();

        public void InsertCategory(Category c)
        {
            string query = "INSERT INTO Category (CategoryName) VALUES (@name)";

            using (SqlCommand cmd = new SqlCommand(query, connect.conn))
            {
                cmd.Parameters.AddWithValue("@name", c.CategoryName);
                connect.OpenConnection();
                cmd.ExecuteNonQuery();
            }
        }
        // UPDATE
        public void UpdateCategory(Category c)
        {
            
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Category SET CategoryName=@name WHERE CategoryId=@id", connect.conn))
            {
                connect.OpenConnection();
                cmd.Parameters.AddWithValue("@name", c.CategoryName);
                cmd.Parameters.AddWithValue("@id", c.CategoryId);
                connect.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            connect.CloseConnection();
        }

        // DELETE
        public void DeleteCategory(int categoryId)
        {
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Category WHERE  CategoryId=@id", connect.conn))
            {
                connect.OpenConnection();
                cmd.Parameters.AddWithValue("@id", categoryId);
               
                cmd.ExecuteNonQuery();
                connect.CloseConnection();
            }
            connect.CloseConnection() ;
        }

        // SEARCH
        public DataTable SearchCategories(string keyword)
        {
           
            using (SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Category WHERE CategoryName LIKE @keyword", connect.conn))
            {
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public List<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();

            string query = "SELECT * FROM Category";

            using (SqlCommand cmd = new SqlCommand(query, connect.conn))
            {
                connect.OpenConnection();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new Category
                    {
                        CategoryId = (int)dr["CategoryId"],
                        CategoryName = dr["CategoryName"].ToString()
                    });
                }
                connect.CloseConnection();
            }

            return list;
        }
    }
}
