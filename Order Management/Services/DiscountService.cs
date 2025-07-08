using Microsoft.EntityFrameworkCore;
using Order_Management.Data;
using Order_Management.Data.Entity;
using Order_Management.Data.Interfaces;

namespace Order_Management.Services
{
    public class DiscountService : DiscountServiceInterface
    {

        private AppDbContext _context;

        public DiscountService(AppDbContext context)
        {
            _context = context;
        }
        public Task<Discount> CreateDiscount(Discount discount)
        {
            _context.Discounts.Add(discount);
            _context.SaveChanges();
            return Task.FromResult(discount);
        }


        public Task<Discount> DeleteDiscount(Discount discount)
        {
            _context.Discounts.Remove(discount);
            _context.SaveChangesAsync();
            return Task.FromResult(discount);
        }

        public Task<Discount> GetDiscountByName(string discountName)
        {
            return _context.Discounts.FirstOrDefaultAsync(x => x.Name == discountName);
        }

        public Task<Discount> GetDiscountByQuantity(int quantity)
        {
            return _context.Discounts.FirstOrDefaultAsync(x => x.MinimumQuantity == quantity);
        }

        public async Task<Discount> UpdateDiscount(string discountName, Discount updatedDiscount)
        {
            var discountForUpdate = await GetDiscountByName(discountName);
            
            if (discountForUpdate == null)
            {
                return discountForUpdate;
            }

            discountForUpdate.Name = updatedDiscount.Name;
            discountForUpdate.Percentage = updatedDiscount.Percentage;
            discountForUpdate.MinimumQuantity = updatedDiscount.MinimumQuantity;

            await _context.SaveChangesAsync();
            return discountForUpdate;

        }
    }
}
