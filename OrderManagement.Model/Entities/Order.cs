using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double RequiredBinWidth { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
