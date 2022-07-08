using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model.Models
{
    public class OrderDetailsResult
    {
        public List<OrderItemDetailResult> orderItemDetailResult { get; set; }
        public double RequiredBinWidth { get; set; }
    }
}
