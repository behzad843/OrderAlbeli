using OrderManagement.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string ProductType  { get; set; }
        public double Size { get; set; }
        public int StackSize { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
