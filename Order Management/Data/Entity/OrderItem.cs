using System.ComponentModel.DataAnnotations;

namespace Order_Management.Data.Entity
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Discount Discount { get; set; }
        public int DiscountId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice {  get; set; }
    }
}
