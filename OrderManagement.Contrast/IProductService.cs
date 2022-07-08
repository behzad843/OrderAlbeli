using OrderManagement.Model.Entities;
using OrderManagement.Model.Enum;
using OrderManagement.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Contrast
{
    public interface IProductService
    {
        Task<double> CalcProductSize(ProductTypeEnum productTypeId, int quanity);
    }
}
