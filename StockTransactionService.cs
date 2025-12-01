using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Billing_System;

public class StockTransactionService
{
    Connect connect = new Connect();
    Product product = new Product();

    // Add Stock Transaction
    public void AddStock(Stock_Transaction t)
    {
        try
        {


            connect.OpenConnection();
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Stock_Transaction 
              (ProductId, AdminId, SupplierId, TransactionType, Quantity, Note) 
              VALUES (@productId, @adminId, @supplierId, @type, @qty, @note)",
                  connect.conn))
            {
                cmd.Parameters.AddWithValue("@productId", t.ProductId);
                cmd.Parameters.AddWithValue("@adminId", t.AdminId);

                if (t.SupplierId == null)
                    cmd.Parameters.AddWithValue("@supplierId", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@supplierId", t.SupplierId);

                cmd.Parameters.AddWithValue("@type", t.TransactionType);
                cmd.Parameters.AddWithValue("@qty", t.Quantity);
                cmd.Parameters.AddWithValue("@note", (object)t.Note ?? DBNull.Value);
                cmd.ExecuteNonQuery();


                // Update Product Quantity
                SqlCommand cmd2 = new SqlCommand(@"
                    UPDATE Product SET Quantity = Quantity + @qty
                    WHERE ProductId = @pid",
                    connect.conn);

                cmd2.Parameters.AddWithValue("@pid", t.ProductId);
                cmd2.Parameters.AddWithValue("@qty", t.Quantity);
                cmd2.ExecuteNonQuery();

                connect.CloseConnection();
            }
        }catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    public void OutStock(Stock_Transaction t)
    {
        try
        {
            connect.OpenConnection();

            // Insert OUT transaction
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Stock_Transaction 
              (ProductId, AdminId, TransactionType, Quantity, Note) 
              VALUES (@productId, @adminId, @type, @qty, @note)",
                  connect.conn))
            {
                cmd.Parameters.AddWithValue("@productId", t.ProductId);
                cmd.Parameters.AddWithValue("@adminId", t.AdminId);
                cmd.Parameters.AddWithValue("@type", "OUT");
                cmd.Parameters.AddWithValue("@qty", t.Quantity);
                cmd.Parameters.AddWithValue("@note", (object)t.Note ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }

            // Update Product Quantity (subtract)
            using (SqlCommand cmd2 = new SqlCommand(@"
            UPDATE Product 
            SET Quantity = Quantity - @qty
            WHERE ProductId = @pid",
                connect.conn))
            {
                cmd2.Parameters.AddWithValue("@pid", t.ProductId);
                cmd2.Parameters.AddWithValue("@qty", t.Quantity);
                cmd2.ExecuteNonQuery();
            }

            connect.CloseConnection();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }


    // Update Stock Transaction
    public void UpdateStock(Stock_Transaction t)
    {
        using (SqlCommand cmd = new SqlCommand(
            @"UPDATE Stock_Transaction SET
                ProductId=@productId,
                AdminId=@adminId,
                SupplierId=@supplierId,
                TransactionType=@type,
                Quantity=@qty,
                Note=@note
              WHERE StockId=@id", connect.conn))
        {
            cmd.Parameters.AddWithValue("@id", t.StockId);
            cmd.Parameters.AddWithValue("@productId", t.ProductId);
            cmd.Parameters.AddWithValue("@adminId", t.AdminId);

            if (t.SupplierId == null)
                cmd.Parameters.AddWithValue("@supplierId", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@supplierId", t.SupplierId);

            cmd.Parameters.AddWithValue("@type", t.TransactionType);
            cmd.Parameters.AddWithValue("@qty", t.Quantity);
            cmd.Parameters.AddWithValue("@note", (object)t.Note ?? DBNull.Value);

            connect.OpenConnection();
            cmd.ExecuteNonQuery();
            connect.CloseConnection();
        }
    }

    // Delete Stock Transaction
    public void DeleteStock(int id)
    {
        using (SqlCommand cmd = new SqlCommand(
            @"DELETE FROM Stock_Transaction WHERE StockId=@id",
            connect.conn))
        {
            cmd.Parameters.AddWithValue("@id", id);

            connect.OpenConnection();
            cmd.ExecuteNonQuery();
            connect.CloseConnection();
        }
    }

    // Get All Stock
    public List<Stock_Transaction> GetAllStock()
    {
        List<Stock_Transaction> list = new List<Stock_Transaction>();

        using (SqlCommand cmd = new SqlCommand(
            "SELECT * FROM Stock_Transaction ORDER BY StockId DESC",
            connect.conn))
        {
            connect.OpenConnection();
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new Stock_Transaction
                {
                    StockId = (int)rd["StockId"],
                    ProductId = (int)rd["ProductId"],
                    AdminId = (int)rd["AdminId"],
                    SupplierId = rd["SupplierId"] == DBNull.Value ? null : (int?)rd["SupplierId"],
                    TransactionType = rd["TransactionType"].ToString(),
                    Quantity = (int)rd["Quantity"],
                    TransactionDate = (DateTime)rd["TransactionDate"],
                    Note = rd["Note"].ToString()
                });
            }
            connect.CloseConnection();
        }

        return list;
    }

    // Search by Product Name or Supplier Name (Optional)
    public List<Stock_Transaction> Search(string keyword)
    {
        List<Stock_Transaction> list = new List<Stock_Transaction>();

        using (SqlCommand cmd = new SqlCommand(
            @"SELECT ST.*
              FROM Stock_Transaction ST
              JOIN Product P ON ST.ProductId = P.ProductId
              LEFT JOIN Supplier S ON ST.SupplierId = S.SupplierId
              WHERE P.ProductName LIKE @key OR S.SupplierName LIKE @key
              ORDER BY ST.StockId DESC", connect.conn))
        {
            cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");

            connect.OpenConnection();
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new Stock_Transaction
                {
                    StockId = (int)rd["StockId"],
                    ProductId = (int)rd["ProductId"],
                    AdminId = (int)rd["AdminId"],
                    SupplierId = rd["SupplierId"] == DBNull.Value ? null : (int?)rd["SupplierId"],
                    TransactionType = rd["TransactionType"].ToString(),
                    Quantity = (int)rd["Quantity"],
                    TransactionDate = (DateTime)rd["TransactionDate"],
                    Note = rd["Note"].ToString()
                });
            }
            connect.CloseConnection();
        }

        return list;
    }
}
