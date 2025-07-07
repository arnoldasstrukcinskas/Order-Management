using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Order_Management.Data.Entity;
using Order_Management.Services;

namespace Order_Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderManagementController : ControllerBase
    {
        private ProductServices _productService;

        public OrderManagementController(ProductServices productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Adds product to postgreSql database.
        /// </summary>
        /// <returns>Added product object with ID, name, description, and price.</returns>
        [HttpPost("add", Name = "addProduct")]
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
        [HttpGet("single", Name = "getProductByName")]
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

        /// <summary>
        /// Retrieves a products by their name from the order management system.
        /// </summary>
        /// <param name="Enter products name">The name of the products to retrieve.</param>
        /// <returns>A product objects with IDs, names, descriptions, and prices.</returns>
        [HttpGet("multiple", Name = "getProductsByName")]
        public async Task<IActionResult> GetProductsByName(string productName)
        {
            var foundProducts = await _productService.GetProductsByName(productName);

            if (foundProducts.Any())
            {
                return Ok(foundProducts);
            }
            else
            {
                return BadRequest("Products not found!");
            }
        }

        /// <summary>
        /// Finds a product by name and deletes it.
        /// </summary>
        /// <param name="Enter product name">The name of the product to delete.</param>
        /// <returns>A deleted product object with ID, name, description, and price.</returns>
        [HttpDelete("delete", Name = "deleteProductByName")]
        public async Task<IActionResult> DeleteProductByName(string productName)
        {
            var foundProduct = await _productService.GetProductByName(productName);

            if (foundProduct != null)
            {
                _productService.DeleteProducts(foundProduct);
                return Ok(foundProduct);
            }
            else
            {
                return BadRequest("Product not found!");
            }
        }
        }
    }
}
