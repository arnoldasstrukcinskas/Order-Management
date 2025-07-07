using Order_Management.Data.Entity;

namespace Order_Management.Data.Interfaces
{
    public interface DiscountServiceInterface
    {
        Task<Discount> CreateDiscount(Discount discount);
        Task<Discount> UpdateDiscount(string discountName, Discount updatedDiscount);
        Task<Discount> DeleteDiscount(Discount discount);
        Task<Discount> GetDiscountByName(string productName);
    }
}
