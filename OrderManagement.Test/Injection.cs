using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Contrast;
using OrderManagement.Model.Entities;
using OrderManagement.Repository.Context;
using OrderManagement.Repository.GenericRepository;
using OrderManagement.Repository.UnitOfWork;
using OrderManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Test
{
    public class TestEnvInjection : IDisposable
    {
        private ApplicationBuilder _applicationBuilder;
        private IServiceProvider _serviceProvider;
        public TestEnvInjection()
        {
            var _applicationBuilder = WebApplication.CreateBuilder();
            _applicationBuilder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_applicationBuilder.Configuration.GetConnectionString("DefaultConnection")));
            _applicationBuilder.Services.AddScoped(typeof(DbContext), typeof(ApplicationContext));
            _applicationBuilder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            _applicationBuilder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            _applicationBuilder.Services.AddScoped(typeof(IProductService), typeof(ProductService));
            _applicationBuilder.Services.AddScoped(typeof(IOrderItemService), typeof(OrderItemService));
            _applicationBuilder.Services.AddScoped(typeof(IOrderService), typeof(OrderService));
            _serviceProvider = _applicationBuilder.Services.BuildServiceProvider();
        }

        public IServiceProvider GetService()
        {
            return _serviceProvider;
        }
        public void Dispose()
        {
            _serviceProvider = null;
            _applicationBuilder = null;
        }
    }
}
