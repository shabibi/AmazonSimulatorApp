
namespace AmazonSimulatorApp.Data.DTOs
{
    public class OrdersOutputOTD
    {
        public int OrderId { get; set; }
        public string ClientName { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}