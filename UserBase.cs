using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System
{

    public class User
    {
        private int _userId;
        private string _username;
        private string _fullName;
        private string _passwordHash;
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public string Sex { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int UserId
        {
            get => _userId;
            protected set => UserId = value;
        }

        public string Username
        {
            get => _username;
            set
            {
                if (value.Length < 4)
                    throw new Exception("Username must be at least 4 characters.");
                _username = value;
            }
        }

        public string PasswordHash
        {
            get => _passwordHash;
            set
            {
                if (value.Length < 6)
                    throw new Exception("Password must be at least 6 characters.");
                _passwordHash = value;
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Full name cannot be empty.");
                _fullName = value;
            }
        }
        // Polymorphism
        //public abstract void ShowRole();
    }
    


    //category
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Relationship
        public List<Product> Products { get; set; } = new List<Product>();
    }
    

    //Product
    public class Product
    {
        public int ProductId { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
    

    //customerOrder
    public class Customer_Order
    {
        public int OrderId { get; set; }

        // FK
        public int CustomerId { get; set; }
        //public User_Customer Customer { get; set; }

        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        // Relationship
        public List<Order_Item> Items { get; set; } = new List<Order_Item>();
        public Billing Billing { get; set; }
    }
    //Order Item
    public class Order_Item
    {
        public int OrderItemId { get; set; }

        // FK
        public int OrderId { get; set; }
        public Customer_Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
    //Billing
    public class Billing
    {
        public int BillingId { get; set; }

        public int OrderId { get; set; }
        public Customer_Order Order { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime BillingDate { get; set; }

        public Payment Payment { get; set; }
    }
    //Payment
    public class Payment
    {
        public int PaymentId { get; set; }

        public int BillingId { get; set; }
        public Billing Billing { get; set; }

        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? PaidDate { get; set; }
    }
    //Stock
    public class Stock_Transaction
    {
        public int StockId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int AdminId { get; set; }
        public int? SupplierId { get; set; }

        public string TransactionType { get; set; }  // IN / OUT
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Note { get; set; }
    }
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
    }








}
