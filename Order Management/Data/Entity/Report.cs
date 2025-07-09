namespace Order_Management.Data.Entity
{
    public class Report
    {
        public string name {  get; set; }
        public int discount { get; set; }
        public int numberOfOrders { get; set; }
        public double totalAmount { get; set; }
    }
}
