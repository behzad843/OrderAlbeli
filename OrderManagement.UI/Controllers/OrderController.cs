using Microsoft.AspNetCore.Mvc;
using OrderManagement.Contrast;
using OrderManagement.Model.Models;

namespace OrderManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderService OrderService { get; set; }

        public OrderController(IOrderService orderService)
        {
            OrderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderListCreateRequest request)
        { 
            var result = await OrderService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get(long OrderID)
        {
            var result = await OrderService.GetById(OrderID);
            return Ok(result);
        }

    }
}
