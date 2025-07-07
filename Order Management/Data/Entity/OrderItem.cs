using System.ComponentModel.DataAnnotations;

namespace Order_Management.Data.Entity
{
    public class OrderItem
    {
        [Key]
        private int Id { get; set; }
        private Order Order { get; set; }
        private int OrderId { get; set; }
        private Product Product { get; set; }
        private int ProductId { get; set; }
        private Discount Discount { get; set; }
        private int DiscountId { get; set; }
        private int Quantity { get; set; }
        private decimal UnitPrice { get; set; }
        private decimal TotalPrice {  get; set; }
    }
}
