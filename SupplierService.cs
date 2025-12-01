using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Billing_System;

public class SupplierService
{
   Connect connect = new Connect();
    // GET ALL
    public List<Supplier> GetAll()
    {
        List<Supplier> list = new List<Supplier>();

       
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Supplier ORDER BY SupplierName", connect.conn))
        {
            connect.OpenConnection();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Supplier
                {
                    SupplierId = (int)dr["SupplierId"],
                    SupplierName = dr["SupplierName"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    Email = dr["Email"].ToString(),
                    Address = dr["Address"].ToString(),
                    ContactPerson = dr["ContactPerson"].ToString()
                });
            }
        }
        connect.CloseConnection();
        return list;
    }

    // INSERT
    public void Insert(Supplier s)
    {
        
        using (SqlCommand cmd = new SqlCommand(
            @"INSERT INTO Supplier (SupplierName, Phone, Email, Address, ContactPerson)
              VALUES (@name, @phone, @email, @address, @contact)", connect.conn))
        {
            cmd.Parameters.AddWithValue("@name", s.SupplierName);
            cmd.Parameters.AddWithValue("@phone", (object)s.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@email", (object)s.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@address", (object)s.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@contact", (object)s.ContactPerson ?? DBNull.Value);

            connect.OpenConnection();
            cmd.ExecuteNonQuery();
            connect.CloseConnection();
        }
    }

    // UPDATE
    public void Update(Supplier s)
    {
        
        using (SqlCommand cmd = new SqlCommand(
            @"UPDATE Supplier 
              SET SupplierName=@suppliername, Phone=@phone, Email=@email,
                  Address=@address, ContactPerson=@contact
              WHERE SupplierId=@id", connect.conn))
        {
            connect.OpenConnection();
            cmd.Parameters.AddWithValue("@id", s.SupplierId);
            cmd.Parameters.AddWithValue("@suppliername", s.SupplierName);
            cmd.Parameters.AddWithValue("@phone", (object)s.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@email", (object)s.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@address", (object)s.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@contact", (object)s.ContactPerson ?? DBNull.Value);

            
            cmd.ExecuteNonQuery();
            connect.CloseConnection();
        }
    }

    // DELETE
    public void Delete(int supplierId)
    {
       
        using (SqlCommand cmd = new SqlCommand(
            "DELETE FROM Supplier WHERE SupplierId=@id", connect.conn))
        {
            cmd.Parameters.AddWithValue("@id", supplierId);
            connect.OpenConnection();
            cmd.ExecuteNonQuery();
        }
    }

    // SEARCH
    public List<Supplier> Search(string text)
    {
        List<Supplier> list = new List<Supplier>();

       
        using (SqlCommand cmd = new SqlCommand(
            @"SELECT * FROM Supplier 
              WHERE SupplierName LIKE @q OR Phone LIKE @q OR Email LIKE @q", connect.conn))
        {
            cmd.Parameters.AddWithValue("@q", "%" + text + "%");

            connect.OpenConnection();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Supplier
                {
                    SupplierId = (int)dr["SupplierId"],
                    SupplierName = dr["SupplierName"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    Email = dr["Email"].ToString(),
                    Address = dr["Address"].ToString(),
                    ContactPerson = dr["ContactPerson"].ToString()
                });
            }
            connect.CloseConnection();
        }
        
        return list;
       

    }
}
