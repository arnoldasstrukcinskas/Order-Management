using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace Order_Management.Data.Entity
{
    public class Discount
    {
        [Key]
        private int Id { get; set; }
        private int Percentage { get; set; }
        private int MinimumQuantity { get; set; }
        private List<OrderItem> OrderItems { get; set; }
    }
}
