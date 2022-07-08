using OrderManagement.Model.Entities;
using OrderManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Contrast
{
    public interface IOrderService
    {
        IQueryable<Order> GetAll();
        Task<BaseResponse<OrderDetailsResult>> GetById(long id);
        Task<BaseResponse<OrderResult>> Create(OrderListCreateRequest request);
        Task<double> CalcRequiredBinWidth(OrderListCreateRequest request);
    }
}
