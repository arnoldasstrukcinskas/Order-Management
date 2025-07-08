using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Order_Management.Data;
using Order_Management.Data.Entity;
using Order_Management.Data.Entity.DTO;
using Order_Management.Data.Interfaces;

namespace Order_Management.Services
{
    public class OrderServices
    {
        private AppDbContext _context;
        private ProductServices _productServices;
        private DiscountService _discountService;

        public OrderServices(AppDbContext context, ProductServices productService, DiscountService discountService)
        {
            _context = context;
            _productServices = productService;
            _discountService = discountService;
        }

        public async Task<Order> CreateOrder(OrderDTO newOrderDTO)
        {
            Order newOrder = new Order();
            newOrder.OrderDate = DateTime.UtcNow;
            newOrder.ItemsInOrder = await addItemsToOrder(newOrderDTO, newOrder);
            newOrder.TotalAmount = totalAmount(newOrder.ItemsInOrder);

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
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

        private double totalAmount(List<OrderItem> Items)
        {
            double totalAmount = 0;
            foreach (var item in Items)
            {
                totalAmount = totalAmount + item.TotalPrice;
            }
            return totalAmount;
        }

        private async Task<Discount> checkDiscount(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                return null;
            }

            var discount = await _discountService.GetDiscountByQuantity(orderItem.Quantity);
            
            if(discount == null)
            {
                discount = await _discountService.GetDiscountByName("Default");
            }

            return discount;
        }

        private async Task<List<OrderItem>> addItemsToOrder(OrderDTO newOrderDTO, Order newOrder)
        {
            List<OrderItem> items = new List<OrderItem>();
            for(int item = 0; item < newOrderDTO.Items.Count; item++)
            {
                var itemDto = newOrderDTO.Items[item];
                var orderItem = new OrderItem();
                orderItem.OrderId = newOrder.Id;
                Product product = await _productServices.GetProductByName(itemDto.itemName);
                orderItem.ProductId = product.Id;
                orderItem.Quantity = itemDto.quantity;
                orderItem.UnitPrice = product.Price;
                Discount discount = await checkDiscount(orderItem);
                orderItem.DiscountId = discount.Id;
                orderItem.TotalPrice = (orderItem.Quantity * product.Price) * (1 - (discount.Percentage / 100.0));
                items.Add(orderItem);
            }
            return items;
        }

        public Task<Order> DeleteOrder(Order foundOrder)
        {
            _context.Orders.Remove(foundOrder);
            _context.SaveChangesAsync();
            return Task.FromResult(foundOrder);
        }
    }
}
