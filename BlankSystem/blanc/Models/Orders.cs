using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blanc.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int TableNumber { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }

}
