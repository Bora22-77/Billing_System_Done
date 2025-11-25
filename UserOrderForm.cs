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
    public partial class UserOrderForm : Form
    {
        public UserOrderForm()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserDashboard userDashboard = new UserDashboard();
            userDashboard.Show();
            this.Close();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            BillingUserForm billinguserform = new BillingUserForm();
            billinguserform.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBuy_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
