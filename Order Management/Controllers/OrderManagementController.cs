using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Order_Management.Data;
using Order_Management.Services;

namespace Order_Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderManagementController : ControllerBase
    {
        private OrderManagerServices _productService;

        public OrderManagementController(OrderManagerServices productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Adds product to postgreSql database.
        /// </summary>
        /// <returns>Added product object with ID, name, description, and price.</returns>
        [HttpPost(Name = "addProduct")]
        public async Task<IActionResult> AddProduct(Product newProduct)
        {
            var productAddTask = await _productService.CreateProduct(newProduct);

            if(productAddTask != null)
            {
                return Ok("Product added succesfully!");
            } 
            else
            {
                return BadRequest("Failed to add Product");
            }
        }

        /// <summary>
        /// Retrieves a product by its name from the order management system.
        /// </summary>
        /// <param name="Enter product name">The name of the product to retrieve.</param>
        /// <returns>A product object with ID, name, description, and price.</returns>
        [HttpGet(Name = "getProductById")]
        public async Task<IActionResult> GetProductByName(string productName)
        {
            var foundProduct = await _productService.GetProductByName(productName);

            if (foundProduct != null)
            {
                return Ok(foundProduct);
            }
            else {
                return BadRequest("Product not found!");
            }
        }
    }
}
