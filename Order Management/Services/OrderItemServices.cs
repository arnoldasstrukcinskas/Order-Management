using Microsoft.EntityFrameworkCore;
using Order_Management.Data;
using Order_Management.Data.Entity;
using Order_Management.Data.Interfaces;


namespace Order_Management.Services
{
    public class OrderItemServices : OrderItemServiceInterface
    {

            private AppDbContext _context;

            public OrderItemServices(AppDbContext context)
            {
                _context = context;
            }

            public Task<List<OrderItem>> GetAllOrderItems()
            {
                var allOrderITems = _context.OrderItem
                .Include(o  => o.Product)
                .Include(o => o.Discount)
                .ToList();
                return Task.FromResult(allOrderITems);
            }
        }
}
