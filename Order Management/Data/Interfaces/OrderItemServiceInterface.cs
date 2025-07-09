using Order_Management.Data.Entity;

namespace Order_Management.Data.Interfaces
{
    public interface OrderItemServiceInterface
    {
        Task<List<OrderItem>> GetAllOrderItems();
    }
}
