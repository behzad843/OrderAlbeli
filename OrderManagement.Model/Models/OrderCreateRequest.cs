using OrderManagement.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model.Models
{
    public class OrderCreateRequest
    {
        public ProductTypeEnum ProductId { get; set; }
        public int quanity { get; set; }
    }
}
