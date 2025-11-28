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
    public partial class Signup : Form
    {
        public static List<User> AllUsers = new List<User>();
        public Signup()
        {
            InitializeComponent();
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.ShowDialog();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            
            string Username = txt_user.Text;
            string Password = txt_pass.Text;
            string Cpassword= txt_cpass.Text;
            string Fullname=txt_fname.Text;
            string Phone = txt_pnumber.Text;
            string Email = txt_email.Text;
            string Address= txt_address.Text;
            DateTime Dob = DateTime.Parse(txt_dob.Text);
            string Sex = cob_sex.Text;
            string Role = cbo_role.Text;

            
            User user = new User();
            user.Username = Username;
            user.PasswordHash = Password;
            user.Email = Email;
            user.Address = Address;
            user.Role = Role;
            user.Phone = Phone;
            user.DoB=Dob;
            user.Sex = Sex;

            try
            {
                 Connect connect = new Connect();
                if (Password == Cpassword)
                {
                   
                    connect.OpenConnection();
                    string addUsers = "INSERT INTO Users(Username,PasswordHash,FullName,Phone,Email,Address,DoB,Sex,Role)" + "values(@username,@passwordHash,@fullName,@phone,@email,@address,@doB,@sex,@role)";
                    using (SqlCommand cmd = new SqlCommand(addUsers, connect.conn)) {
                        cmd.Parameters.AddWithValue("@username", Username);
                        cmd.Parameters.AddWithValue("@passwordHash", Password);
                        cmd.Parameters.AddWithValue("@fullname", Fullname);
                        cmd.Parameters.AddWithValue("@phone", Phone);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@address", Address);
                        cmd.Parameters.AddWithValue("@dob", Dob);
                        cmd.Parameters.AddWithValue("@sex", Sex);
                        cmd.Parameters.AddWithValue("@role", Role);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Password don't match");
                }
                connect.CloseConnection();
                Form1 form = new Form1();
                form.Show();
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
