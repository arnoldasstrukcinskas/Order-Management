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
        private OrderItemServices _orderItemServices;

        public OrderServices(AppDbContext context, ProductServices productService, DiscountService discountService, OrderItemServices orderItemServices)
        {
            _context = context;
            _productServices = productService;
            _discountService = discountService;
            _orderItemServices = orderItemServices;
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

        public async Task<List<Report>> CreateReportList()
        {
            List<Report> listOfReports = new List<Report>();
            var allOrderItems = await _orderItemServices.GetAllOrderItems();

            foreach (var orderItem in allOrderItems)
            {
                Report report = new Report();
                report.name = orderItem.Product.Name;
                report.numberOfOrders = orderItem.Quantity;
                report.discount = orderItem.Discount.Percentage;
                report.totalAmount = orderItem.TotalPrice;
                listOfReports.Add(report);
            }
            return listOfReports;
        }

        public async Task<List<Report>> GetFullReportList()
        {
            var listOfReports = await CreateReportList();

            for (int i = 0; i < listOfReports.Count; i++)
            {
                var currentReport = listOfReports[i];
                for (int j = i + 1; j < listOfReports.Count; j++)
                {
                    var nextReport = listOfReports[j];
                    if (currentReport.name.Equals(nextReport.name) && (currentReport.discount == nextReport.discount)) {
                    currentReport.totalAmount = currentReport.totalAmount + nextReport.totalAmount;

                    listOfReports.RemoveAt(j);
                    j--;
                    }
                }
            }
            return listOfReports;
        }

        public async Task<List<Report>> GetReportByName(string name)
        {
            var reports = await GetFullReportList();
            var newList = new List<Report>();

            foreach (var report in reports)
            {
                if((report.name.Equals(name)))
                {
                    newList.Add(report); 
                }
            }
            return newList;
        }

    }
}
