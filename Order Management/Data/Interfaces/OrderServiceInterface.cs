
using Order_Management.Data.Entity;

namespace Order_Management.Data.Interfaces
{
    public interface OrderServiceInterface
    {
        Task<Order> CreateOrder(Order order);
        Task<Order> DeleteOrderById(int id);
        Task<Order> GetAllOrders();
    }
}
