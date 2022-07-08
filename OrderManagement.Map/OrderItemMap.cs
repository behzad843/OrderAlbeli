using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Model.Entities;

namespace OrderManagement.Map
{
    public class OrderItemMap
    {
        public OrderItemMap(EntityTypeBuilder<OrderItem> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.ProductId).IsRequired();
            entityBuilder.Property(t => t.Quantity).IsRequired();
            entityBuilder.Property(t => t.OrderId).IsRequired();
        }
    }
}
