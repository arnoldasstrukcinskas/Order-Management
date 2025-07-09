using Microsoft.AspNetCore.Mvc;
using Order_Management.Data.Entity;
using Order_Management.Data.Entity.DTO;
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
        public async Task<IActionResult> AddOrder(OrderDTO newOrderDTO)
        {
            var orderAdd = await _orderService.CreateOrder(newOrderDTO);

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
        /// Finds an order by id and deletes it.
        /// </summary>
        /// <param id="Enter order id">The id of the order to delete.</param>
        /// <returns>A deleted order object with ID, date, total amount and deleted items.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteProductByName(int id)
        {
            var foundOrder = await _orderService.GetOrderById(id);

            if (foundOrder != null)
            {
                _orderService.DeleteOrder(foundOrder);
                return Ok(foundOrder);
            }
            else
            {
                return BadRequest("Order not found!");
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

        /// <summary>
        /// Retrieves a report of discounted products from postgresql database.
        /// </summary>
        /// <param>Name of discounted product</param>
        /// <returns>Report with the products which was sold with specific discount and their parameters</returns>
        [HttpGet("report")]
        public async Task<IActionResult> GetDiscountReport(string productName)
        {
            var report = await _orderService.GetReportByName(productName);
       
            if (report != null)
            {
                return Ok(report);
            }
            else
            {
                return BadRequest("Could not generate a report, something wrong!");
            }
        }

        /// <summary>
        /// Retrieves a report of discounted products from postgresql database.
        /// </summary>
        /// <param>Name of discounted product</param>
        /// <returns>Report with the products which was sold with specific discount and their parameters</returns>
        [HttpGet("reports")]
        public async Task<IActionResult> GetFullReport()
        {
            var reports = await _orderService.GetFullReportList();

            if (reports != null)
            {
                return Ok(reports);
            }
            else
            {
                return BadRequest("Could not generate a report, something wrong!");
            }
        }

    }
}
