using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Model.Entities;

namespace OrderManagement.Map
{
    public class OrderMap
    {
        public OrderMap(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.RequiredBinWidth).IsRequired();
            entityBuilder.Property(t => t.OrderDate).IsRequired();
        }
    }
}
