using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System
{
    public partial class Signup : Form
    {
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
            MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
