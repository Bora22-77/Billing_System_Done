using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Billing_System
{
    public partial class Login : Form
    {
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();
        SupplierService supplierservice = new SupplierService();
        StockTransactionService StockTransactionService = new StockTransactionService();
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

        private void LoadSupplierList()
        {
            lv_supplier.Items.Clear();
            

            var suppliers = supplierservice.GetAll();

            foreach (var s in suppliers)
            {
                ListViewItem item = new ListViewItem(s.SupplierId.ToString());
                item.Tag = s.SupplierId;

                item.SubItems.Add(s.SupplierName);
                item.SubItems.Add(s.Phone);
                item.SubItems.Add(s.Email);
                item.SubItems.Add(s.Address);
                item.SubItems.Add(s.ContactPerson);

                lv_supplier.Items.Add(item);
            }
        }
        private void LoadSupplierCombo()
        {
            var list = supplierservice.GetAll();

            cbo_supplier_stock.DataSource = list;
            cbo_supplier_stock.DisplayMember = "SupplierName";
            cbo_supplier_stock.ValueMember = "SupplierId";
        }
        private void LoadStockList()
        {
            lv_stock.Items.Clear();
            var list = StockTransactionService.GetAllStock();

            foreach (var s in list)
            {
                ListViewItem item = new ListViewItem(s.StockId.ToString());
                item.Tag = s.StockId;
                item.SubItems.Add(s.ProductId.ToString());
                item.SubItems.Add(s.TransactionType);
                item.SubItems.Add(s.Quantity.ToString());
                item.SubItems.Add(s.Note);
                item.SubItems.Add(s.SupplierId?.ToString());
                item.SubItems.Add(s.TransactionDate.ToString("yyyy-MM-dd"));
                lv_stock.Items.Add(item);
            }
        }

        private void LoadProductCombo()
        {
            var list = productService.GetAllProducts();

            cbo_product_stock.DataSource = list;
            cbo_product_stock.DisplayMember = "ProductName";
            cbo_product_stock.ValueMember = "ProductId";
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
            LoadSupplierList();
            LoadSupplierCombo();
            LoadProductCombo();
            LoadSupplierCombo();
            LoadStockList();
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

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_supplier_Click(object sender, EventArgs e)
        {
            Supplier s = new Supplier
            {
                SupplierName = txt_supplier_name.Text,
                Phone = txt_supplier_phone.Text,
                Email = txt_supplier_email.Text,
                Address = txt_supplier_address.Text,
                ContactPerson = txt_supplier_contactperson.Text
            };

            supplierservice.Insert(s);
            LoadSupplierList();
            MessageBox.Show("Supplier Added!");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
               txt_supplier_name.Clear();
               txt_supplier_phone.Clear();
               txt_supplier_email.Clear();
               txt_supplier_address.Clear();
               txt_supplier_contactperson.Clear();
        }

        private void btn_update_supplier_Click(object sender, EventArgs e)
        {
            if (lv_supplier.SelectedItems.Count == 0) return;

            int id = (int)lv_supplier.SelectedItems[0].Tag;

            Supplier s = new Supplier
            {
                SupplierId = id,
                SupplierName=txt_supplier_name.Text,
                Phone = txt_supplier_phone.Text,
                Email = txt_supplier_email.Text,
                Address = txt_supplier_address.Text,
                ContactPerson = txt_supplier_contactperson.Text
            };

            supplierservice.Update(s);
            LoadSupplierList();
            MessageBox.Show("Supplier Updated!");
        }

        private void btn_delete_supplier_Click(object sender, EventArgs e)
        {
            if (lv_supplier.SelectedItems.Count == 0) return;

            int id = (int)lv_supplier.SelectedItems[0].Tag;

            supplierservice.Delete(id);
            LoadSupplierList();
            MessageBox.Show("Supplier Deleted!");
        }

        private void btn_search_supplier_Click(object sender, EventArgs e)
        {
            var suppliers = supplierservice.Search(txt_search_supplier.Text);

            lv_supplier.Items.Clear();

            foreach (var s in suppliers)
            {
                ListViewItem item = new ListViewItem(s.SupplierId.ToString());
                item.Tag = s.SupplierId;

                item.SubItems.Add(s.SupplierName);
                item.SubItems.Add(s.Phone);
                item.SubItems.Add(s.Email);
                item.SubItems.Add(s.Address);
                item.SubItems.Add(s.ContactPerson);

                lv_supplier.Items.Add(item);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadSupplierList();
        }

        private void lv_supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_supplier.SelectedItems.Count > 0)
            {
                ListViewItem selected = lv_supplier.SelectedItems[0];
                txt_supplier_name.Text = selected.SubItems[1].Text;
                txt_supplier_phone.Text = selected.SubItems[2].Text;
                txt_supplier_email.Text = selected.SubItems[3].Text;
                txt_supplier_address.Text = selected.SubItems[4].Text;
                txt_supplier_contactperson.Text = selected.SubItems[5].Text;
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_type.Text == "IN")
                cbo_supplier_stock.Enabled = true;
            else
                cbo_supplier_stock.Enabled = false; // OUT does not need supplier
        }

        private void btn_savestock_Click(object sender, EventArgs e)
        {
            Stock_Transaction st = new Stock_Transaction
            {
                ProductId = (int)cbo_product_stock.SelectedValue,
                AdminId = Form1.LoggedUserId,    // <-- USE THIS   // you already have this in your system
                TransactionType = cbo_type.Text,
                Quantity = int.Parse(txt_qty_stock.Text),
                Note = txt_note.Text
            };


            // Supplier only for IN transactions
            if (st.TransactionType == "IN")
                st.SupplierId = (int)cbo_supplier_stock.SelectedValue;
            else
                st.SupplierId = null;

            StockTransactionService.AddStock(st);
            MessageBox.Show("Stock Transaction added!");
            LoadStockList();
            LoadProductList();
        }

        private void view_stock_Click(object sender, EventArgs e)
        {
            LoadStockList();
        }

        private void btn_outstock_Click(object sender, EventArgs e)
        {
            Stock_Transaction st = new Stock_Transaction
            {
                ProductId = (int)cbo_product_stock.SelectedValue,
                AdminId = Form1.LoggedUserId,    // <-- USE THIS   // you already have this in your system
                TransactionType = cbo_type.Text,
                Quantity = int.Parse(txt_qty_stock.Text),
                Note = txt_note.Text
            };


            // Supplier only for IN transactions
            if (st.TransactionType == "OUT")
                st.SupplierId = (int)cbo_supplier_stock.SelectedValue;
            else
                st.SupplierId = null;

            StockTransactionService.OutStock(st);
            MessageBox.Show("Stock Transaction outed!");
            LoadStockList();
            LoadProductList();
        }
    }
}
