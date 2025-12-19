using Microsoft.AspNetCore.Mvc;
using OmniPos.Application.Common;
using OmniPos.Application.DTOs;
using OmniPos.Application.Orders.Commands;
using OmniPos.Application.Orders.Queries;
using OmniPos.Server.Models;

namespace OmniPos.Server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController(Dispatcher dispatcher) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var order = await dispatcher.DispatchAsync(new GetOrderQuery() { OrderId = id });
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderModel order)
        {
            var command = new CreateOrderCommand
            {
                PaymentMethod = order.PaymentMethod,
                Items = order.Items.Select(i => new OrderItemDTO
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };

            try
            {

                var orderId = await dispatcher.DispatchAsync(command);

                return Ok(new { id = orderId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
