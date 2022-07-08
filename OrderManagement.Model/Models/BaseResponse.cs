using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model.Models
{
    public class BaseResponse<T>
    {
        public BaseResponse() => Errors = new List<Error>();

        public bool HasError => Errors.Any();
        public List<Error> Errors { get; set; }
        public T Result { get; set; }
    }
}
