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
    public partial class Login : Form
    {
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();   
        public Login()
        {
            InitializeComponent();
            
        }
        //////////////Method////////////////
        private void LoadCategoryList()
        {
            lv_category.Items.Clear();

            var list = categoryService.GetAllCategories();

            foreach (var c in list)
            {
                ListViewItem item = new ListViewItem(c.CategoryId.ToString());
                item.Tag = c.CategoryId; // <-- FIX (You forgot this)

                item.SubItems.Add(c.CategoryName);

                lv_category.Items.Add(item);
            }
        }


        ////
        private void LoadCategoryCombo()
        {
            var list = categoryService.GetAllCategories();

            cbo_category_product.DataSource = list;
            cbo_category_product.DisplayMember = "CategoryName";
            cbo_category_product.ValueMember = "CategoryId";

            if (list.Count > 0)
                cbo_category_product.SelectedIndex = 0;  // ← FIX (set first category)
        }
        /////
        private void LoadProductList()
        {
            lv_product.Items.Clear();

            var list = productService.GetAllProducts();

            foreach (var p in list)
            {
                ListViewItem item = new ListViewItem(p.ProductId.ToString());
                item.SubItems.Add(p.ProductName);
                item.SubItems.Add(p.Price.ToString());
                item.SubItems.Add(p.Quantity.ToString());
                item.SubItems.Add(p.Description);
                item.SubItems.Add(p.CategoryId.ToString());        // Index 5 (Correct)
                item.SubItems.Add(p.Category.CategoryName);        // Index 6 (For display only)

                item.Tag = p.ProductId;

                lv_product.Items.Add(item);
            }
        }




        private void LoadFormIntoTab(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_product_Click(object sender, EventArgs e)
        {

        }

        private void btn_order_Click(object sender, EventArgs e)
        {

        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            
        }

        private void tabConstrol1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tab_product_Click(object sender, EventArgs e)
        {

        }

        private void tab_order_Click(object sender, EventArgs e)
        {

        }

        private void tab_payment_Click(object sender, EventArgs e)
        {       

        }

        private void Login_Load(object sender, EventArgs e)
        {
            LoadCategoryList();  // tab 1
            LoadCategoryCombo(); // tab 2
            LoadProductList();   // tab 2
        }

        private void tab_stock_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender,EventArgs e)
        {
            if (cbo_category_product.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_productname.Text))
            {
                MessageBox.Show("Product name is required.");
                return;
            }

            if (!decimal.TryParse(txt_price.Text, out decimal price))
            {
                MessageBox.Show("Invalid price value.");
                return;
            }

            if (!int.TryParse(txt_quantity.Text, out int qty))
            {
                MessageBox.Show("Invalid quantity value.");
                return;
            }

            Product p = new Product
            {
                CategoryId = Convert.ToInt32(cbo_category_product.SelectedValue),
                ProductName = txt_productname.Text.Trim(),
                Price = price,
                Quantity = qty,
                Description = txt_discr.Text.Trim()
            };

            productService.InsertProduct(p);

            MessageBox.Show("Product Added!");
            LoadProductList();

        }

        private void tab_order_item_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_category_Click(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService();
            Category c = new Category
            {
                CategoryName = txt_categoryname_category.Text
            };

            categoryService.InsertCategory(c);

            MessageBox.Show("Category Added!");

            LoadCategoryList();
            LoadCategoryCombo();   // refresh for product tab
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lv_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_product.SelectedItems.Count > 0)
            {
                ListViewItem selected = lv_product.SelectedItems[0];
                txt_productname.Text = selected.SubItems[1].Text;
                txt_price.Text = selected.SubItems[2].Text;
                txt_quantity.Text = selected.SubItems[3].Text;
                txt_discr.Text = selected.SubItems[4].Text;
                cbo_category_product.SelectedValue = Convert.ToInt32(selected.SubItems[5].Text);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txt_productname.Clear();
            txt_price.Clear();
            txt_quantity.Clear();
            txt_discr.Clear();
            LoadProductList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lv_product.SelectedItems.Count > 0)
            {
                ListViewItem selected = lv_product.SelectedItems[0];
                int productId = Convert.ToInt32(selected.Tag); // use Tag for ProductId

                Product p = new Product
                {
                    ProductId = productId,
                    CategoryId = (int)cbo_category_product.SelectedValue,
                    ProductName = txt_productname.Text,
                    Price = decimal.Parse(txt_price.Text),
                    Quantity = int.Parse(txt_quantity.Text),
                    Description = txt_discr.Text.Trim()
                };

                productService.UpdateProduct(p);
                LoadProductList();
                MessageBox.Show("Product updated!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lv_product.SelectedItems.Count > 0)
            {
                ListViewItem selected = lv_product.SelectedItems[0];
                int productId = Convert.ToInt32(selected.Tag);

                productService.DeleteProduct(productId);
                LoadProductList();
                MessageBox.Show("Product deleted!");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string keyword = txt_search_product.Text;
            DataTable dt = productService.SearchProducts(keyword);

            lv_product.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["ProductId"].ToString());
                item.Tag = row["ProductId"];
                item.SubItems.Add(row["ProductName"].ToString());
                item.SubItems.Add(row["Price"].ToString());
                item.SubItems.Add(row["Quantity"].ToString());
                item.SubItems.Add(row["Description"].ToString());
                item.SubItems.Add(row["CategoryId"].ToString());

                lv_product.Items.Add(item);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txt_categoryid_caregory.Clear();
            txt_categoryname_category.Clear();
        }

        private void btn_update_category_Click(object sender, EventArgs e)
        {
            if (lv_category.SelectedItems.Count == 0)
                return;

            ListViewItem item = lv_category.SelectedItems[0];
            int categoryId = (int)item.Tag;

            Category c = new Category
            {
                CategoryId = categoryId,
                CategoryName = txt_categoryname_category.Text,
               
            };

            categoryService.UpdateCategory(c);
            LoadCategoryList();
            MessageBox.Show("Category Updated!");
        }

        private void btn_delete_category_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_category.SelectedItems.Count == 0)
                    return;

                int categoryId = (int)lv_category.SelectedItems[0].Tag;

                categoryService.DeleteCategory(categoryId);
                LoadCategoryList();
                MessageBox.Show("Category Deleted!");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_search_category_Click(object sender, EventArgs e)
        {
            DataTable dt = categoryService.SearchCategories(txt_search_category.Text);

            lv_category.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["CategoryId"].ToString());
                item.Tag = row["CategoryId"];
                item.SubItems.Add(row["CategoryName"].ToString());
               

                lv_category.Items.Add(item);
            }
        }

        private void lv_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_category.SelectedItems.Count > 0)
            {
                var item = lv_category.SelectedItems[0];
                txt_categoryname_category.Text = item.SubItems[1].Text;
            }
        }

        private void btn_view_category_Click(object sender, EventArgs e)
        {
            LoadCategoryList();
        }
    }
}
