using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace Order_Management.Data.Entity
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }
        public int MinimumQuantity { get; set; }
    }
}
