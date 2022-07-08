using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model.Models
{
    public class Error
    {
        public Error()
        {

        }
        public Error(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public Error(int errorCode)
        {
            ErrorCode = errorCode;
        }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
