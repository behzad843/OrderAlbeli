using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Map;
using OrderManagement.Model.Entities;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Model.Enum;

namespace OrderManagement.Repository.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProductMap(modelBuilder.Entity<Product>());
            new OrderMap(modelBuilder.Entity<Order>());
            new OrderItemMap(modelBuilder.Entity<OrderItem>());
        }
    }
}
