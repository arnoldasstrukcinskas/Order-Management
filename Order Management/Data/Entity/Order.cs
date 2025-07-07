using System.ComponentModel.DataAnnotations;

namespace Order_Management.Data.Entity
{
    public class Order
    {
        [Key]
        private int OrderId { get; set; }
        private DateTime OrderDate { get; set; }
        private double TotalAmount {  get; set; }
    }
}
