
using Order_Management.Data.Entity;
using Order_Management.Data.Entity.DTO;

namespace Order_Management.Data.Interfaces
{
    public interface OrderServiceInterface
    {
        Task<Order> CreateOrder(OrderDTO newOrderDTO);
        Task<Order> DeleteOrderById(int id);
        Task<Order> GetAllOrders();
        Task<Order> DeleteOrder(Order foundOrder);
    }
}
