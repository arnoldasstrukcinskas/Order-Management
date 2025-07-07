using Microsoft.EntityFrameworkCore;
using Order_Management.Data;
using Order_Management.Data.Entity;

namespace Order_Management.Services
{
    public class OrderServices
    {
        private AppDbContext _context;

        public OrderServices(AppDbContext context)
        {
            _context = context;
        }

        public Task<Order> CreateOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return Task.FromResult(newOrder);
        }

        public Task<List<Order>> GetAllOrders(string productName)
        {
            var allOrders = _context.Orders.ToList();
            return Task.FromResult(allOrders);
        }

        public Task<Order> GetOrderById(int orderId)
        {
            return _context.Orders.FirstOrDefaultAsync(order => order.Id == orderId); ;
        }
    }
}
