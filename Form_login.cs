using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System
{
    public partial class Form1 : Form
    {
        public static string Username;
        public static string Password;
        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            Signup obj = new Signup();
            obj.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            
            Username = txt_username.Text;
            Password = txt_password.Text;
            User_Admin user_admin = new User_Admin();
            user_admin.Username = Username;
            user_admin.PasswordHash = Password;
            Connect connect = new Connect();
            
            
            if (txt_username.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Please enter both username and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                connect.OpenConnection();
                string filterAdmin = "SELECT COUNT(*) FROM User_Admin WHERE Username=@username AND PasswordHash=@passwordhash";
                SqlCommand cmdAdmin = new SqlCommand(filterAdmin,connect.conn);
                cmdAdmin.Parameters.AddWithValue("@username", Username);
                cmdAdmin.Parameters.AddWithValue("@passwordhash", Password);
                int resultAdmin =(int)cmdAdmin.ExecuteScalar();

                string filterCustomer = "SELECT COUNT(*) FROM User_Customer WHERE Username=@username AND PasswordHash=@passwordhash";
                SqlCommand cmdCustomer = new SqlCommand(filterCustomer, connect.conn);
                cmdCustomer.Parameters.AddWithValue("@username", Username);
                cmdCustomer.Parameters.AddWithValue("@passwordhash", Password);
                int resultCustomer = (int)cmdCustomer.ExecuteScalar();
                
                if (resultAdmin >0)
                { 
                    Login login = new Login();
                    login.Show();
                }
                if (resultCustomer >0 )
                { 
                   UserDashboard login = new UserDashboard();
                   login.Show();
                }
                else
                {
                    MessageBox.Show("Please SignUp an account!!","Don't have any account",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk);
                }
                     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

             
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
