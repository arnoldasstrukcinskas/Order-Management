using System.ComponentModel.DataAnnotations;

namespace Order_Management.Data.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount {  get; set; }
    }
}
