using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System
{
    public class CartItem
    {
        public int ProductId;
        public string ProductName;
        public int Qty;
        public double Price;
    }

    public class ShoppingCart
    {
        public LinkedList<CartItem> Items = new LinkedList<CartItem>();

        public void AddItem(int productId, string name, int qty, double price)
        {
            Items.AddLast(new CartItem
            {
                ProductId = productId,
                ProductName = name,
                Qty = qty,
                Price = price
            });
        }

        public double GetTotal()
        {
            double total = 0;
            foreach (var i in Items)
                total += i.Qty * i.Price;

            return total;
        }
    }

}
