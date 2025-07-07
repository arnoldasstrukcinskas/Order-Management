using Microsoft.AspNetCore.Mvc;
using Order_Management.Data.Entity;
using Order_Management.Services;

namespace Order_Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderManagementController : ControllerBase
    {
        public OrderServices _orderService;
        public OrderManagementController(OrderServices orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Adds Order to postgreSql database.
        /// </summary>
        /// <returns>Added order object with ID, percentage and minimum quantity.</returns>
        [HttpPost]
        public async Task<IActionResult> AddOrder(Order newOrder)
        {
            var orderAdd = await _orderService.CreateOrder(newOrder);

            if (orderAdd != null)
            {
                return Ok(orderAdd);
            }
            else
            {
                return BadRequest("Failed to add order");
            }
        }


        /// <summary>
        /// Gets order from postgreSql database.
        /// </summary>
        /// <returns>Order object with ID, date, total amount and items in it.</returns>
        [HttpGet("single")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var orderGet = await _orderService.GetOrderById(id);

            if (orderGet != null)
            {
                return Ok(orderGet);
            }
            else
            {
                return BadRequest("Failed to get order");
            }
        }

        /// <summary>
        /// Retrieves all orders from postgresql database.
        /// </summary>
        /// <param>No parameters</param>
        /// <returns>Orders with their id's, time when created, itemd in order and total amounts.</returns>
        [HttpGet("multiple")]
        public async Task<IActionResult> GetAllOrders(string productName)
        {
            var allOrders = await _orderService.GetAllOrders(productName);

            if (allOrders != null)
            {
                return Ok(allOrders);
            }
            else
            {
                return BadRequest("Order list is empty!");
            }
        }

    }
}
