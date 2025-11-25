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
    public partial class BillingUserForm : Form
    {
        public BillingUserForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserOrderForm userOrderForm = new UserOrderForm();
            userOrderForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDashboard userDashboard = new UserDashboard();
            userDashboard.Show();
            this.Close();
        }
    }
}
