using Microsoft.AspNetCore.Mvc;
using Order_Management.Data.Entity;
using Order_Management.Services;

namespace Order_Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : ControllerBase
    {
        private DiscountService _discountService;
        public DiscountController(DiscountService discountService) {
            _discountService = discountService;
        }

        /// <summary>
        /// Adds Discount to postgreSql database.
        /// </summary>
        /// <returns>Added discount object with ID, percentage and minimum quantity.</returns>
        [HttpPost]
        public async Task<IActionResult> AddDiscount(Discount newDiscount)
        {
            var discountAdd = await _discountService.CreateDiscount(newDiscount);

            if (discountAdd != null)
            {
                return Ok(discountAdd);
            }
            else
            {
                return BadRequest("Failed to add Discount");
            }
        }

        /// <summary>
        /// Updates discounts name, percentage and minimum quanttyti.
        /// </summary>
        /// <returns>Updated discount object with name, percentage, minimum quantity.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(string discountName, Discount updatedDiscount)
        {
            var discountUpdate = await _discountService.UpdateDiscount(discountName, updatedDiscount);

            if (discountUpdate != null)
            {
                return Ok(discountUpdate);
            }
            else
            {
                return BadRequest("Failed to update Discount");
            }
        }

        /// <summary>
        /// Deletes Discount from postgreSql database.
        /// </summary>
        /// <returns>A deleted from databse, discount object.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscount(string discountName)
        {
            var discountDelete = await _discountService.GetDiscountByName(discountName);

            if (discountDelete != null)
            {
                _discountService.DeleteDiscount(discountDelete);
                return Ok(discountDelete);
            }
            else
            {
                return BadRequest("Failed to delete Discount");
            }
        }
    }
}
