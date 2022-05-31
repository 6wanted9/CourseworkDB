namespace CourseworkDB.Models.Orders
{
    public class OrderLineModel
    {
        public int ProductId { get; set; }

        public int Amount { get; set; }
        
        public int DemandAmount { get; set; }
        
        public int ProductionAmount { get; set; }
    }
}