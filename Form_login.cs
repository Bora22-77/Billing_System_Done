using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Billing_System
{
    public partial class Form1 : Form
    {
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }


        public static string Username;
        public static string Password;
        public static int LoggedUserId;
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
            
            string Username = txt_username.Text;
            string Password = txt_password.Text;

            User user = new User();
            user.Username = Username;
            user.PasswordHash = Password.ToString();

            Connect connect = new Connect();
            string hashedPassword = HashPassword(Password.ToString());

            if (txt_username.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Please enter both username and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
            try
            {
                connect.OpenConnection();
                string filterUsers = "SELECT * FROM Users WHERE Username=@username AND PasswordHash=@passwordhash";
                SqlCommand cmd = new SqlCommand(filterUsers,connect.conn);
                cmd.Parameters.AddWithValue("@username", Username);
                cmd.Parameters.AddWithValue("@passwordhash", Password);
                //int result =(int)cmd.ExecuteScalar();
                //int result = cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();

               if (reader.Read())
                {
                    string fullName = reader["FullName"].ToString();
                    string role = reader["Role"].ToString();
                    MessageBox.Show($"Welcome {fullName} ({role})!");
                    if (role == "Admin")
                    {
                        LoggedUserId = int.Parse(reader["UserId"].ToString());   // <-- PUT HERE
                        Login login = new Login();
                        login.Show();
                        this.Hide();
                        login.FormClosed += (s, args) => Application.Exit();

                    }
                    else if (role == "Customer")
                    {
                        UserDashboard login = new UserDashboard();
                        login.Show();
                        
                    }


                }
                else
                {
                    MessageBox.Show("Invalid username or password!" , "Don't have any account?", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                }
               connect.CloseConnection();
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
