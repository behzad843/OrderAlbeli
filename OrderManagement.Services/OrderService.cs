using Microsoft.EntityFrameworkCore;
using OrderManagement.Contrast;
using OrderManagement.Model.Entities;
using OrderManagement.Model.Enum;
using OrderManagement.Model.Models;
using OrderManagement.Repository.GenericRepository;
using OrderManagement.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public IGenericRepository<Order> OrderRepository { get; set; }
        public IGenericRepository<OrderItem> OrderItemRepository { get; set; }
        public IProductService ProductService { get; set; }

        public OrderService(IUnitOfWork unitOfWork, IGenericRepository<Order> orderRepository, IGenericRepository<OrderItem> orderItemRepository, IProductService productService)
        {
            UnitOfWork = unitOfWork;
            OrderRepository = orderRepository;
            OrderItemRepository = orderItemRepository;
            ProductService = productService;
        }

        public IQueryable<Order> GetAll()
        {
            return OrderRepository.GetQuery().Include(c => c.OrderItems).ThenInclude(c => c.Product);
        }

        public async Task<BaseResponse<OrderDetailsResult>> GetById(long id)
        {
            var response = new BaseResponse<OrderDetailsResult>();

            try
            {
                var result = await GetAll().FirstOrDefaultAsync(c => c.Id == id);

                if(result == null)
                    response.Errors.Add(new Error() { ErrorMessage = "OrderID not exists" });

                List<OrderItemDetailResult> orderItems = new List<OrderItemDetailResult>();
                foreach (var item in result.OrderItems)
                {
                    var orderItemDetail = new OrderItemDetailResult()
                    {
                        productType = item.Product.ProductType,
                        quantity = item.Quantity
                    };
                    orderItems.Add(orderItemDetail);
                }

                response.Result = new OrderDetailsResult()
                {
                    orderItemDetailResult = orderItems,
                    RequiredBinWidth = result.RequiredBinWidth
                };
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error() { ErrorMessage = ex.Message });
            }

            return response;
        }

        public async Task<BaseResponse<OrderResult>> Create(OrderListCreateRequest request)
        {
            var response = new BaseResponse<OrderResult>();

            try
            {
                List<OrderItem> orderItems = new List<OrderItem>();
                foreach (var item in request.orderRequest)
                {
                    var orderItem = new OrderItem()
                    {
                        ProductId = (int)item.ProductId,
                        Quantity = item.quanity
                    };
                    orderItems.Add(orderItem);
                }

                var result = await OrderRepository.Create(new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderItems = orderItems,
                    RequiredBinWidth = await CalcRequiredBinWidth(request)
                });

                await UnitOfWork.SaveChanges();

                response.Result = new OrderResult()
                {
                    Id = result.Id,
                    RequiredBandWidth = result.RequiredBinWidth
                };

            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error() { ErrorMessage = ex.Message });

            }

            return response;
        }

        public async Task<double> CalcRequiredBinWidth(OrderListCreateRequest request)
        {
            double result = 0;

            foreach(var item in request.orderRequest.ToList())
            {
                double binWith = await CalkProductSize(item.ProductId, item.quanity);
                result += binWith;
            }

            return (double)result;
        }

        private async Task<double> CalkProductSize(ProductTypeEnum productType, int quanity)
        {
            return  await ProductService.CalcProductSize(productType, quanity);
        }
    }
}
