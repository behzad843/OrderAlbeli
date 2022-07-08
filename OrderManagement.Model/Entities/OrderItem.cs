using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model.Entities
{
    public class OrderItem
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
