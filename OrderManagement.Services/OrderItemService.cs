using Microsoft.EntityFrameworkCore;
using OrderManagement.Contrast;
using OrderManagement.Model.Entities;
using OrderManagement.Repository.GenericRepository;
using OrderManagement.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public class OrderItemService : IOrderItemService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public IGenericRepository<OrderItem> OrderItemRepository { get; set; }

        public OrderItemService(IUnitOfWork unitOfWork, IGenericRepository<OrderItem> orderItemRepository)
        {
            UnitOfWork = unitOfWork;
            OrderItemRepository = orderItemRepository;
        }
    }
}
