using Microsoft.EntityFrameworkCore;
using OrderManagement.Contrast;
using OrderManagement.Model.Entities;
using OrderManagement.Model.Enum;
using OrderManagement.Repository.Context;
using OrderManagement.Repository.GenericRepository;
using OrderManagement.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public class ProductService : IProductService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public IGenericRepository<Product> ProductRepository { get; set; }

        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> productRepository)
        {
            UnitOfWork = unitOfWork;
            ProductRepository = productRepository;
        }

        public async Task<double> CalcProductSize(ProductTypeEnum productType, int quanity)
        {
            var product = await ProductRepository.GetQuery().FirstOrDefaultAsync(c => c.Id == (int)productType);
            double result =  (int)Math.Ceiling((double)quanity / (double)product.StackSize) * product.Size;

            return result;
        }
    }
}
