using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement.Model.Entities;
using OrderManagement.Model.Enum;

namespace OrderManagement.Map
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.ProductType).HasMaxLength(25).IsRequired();
            entityBuilder.Property(t => t.Size).IsRequired();
            entityBuilder.Property(t => t.StackSize).IsRequired();
        }
    }
}
