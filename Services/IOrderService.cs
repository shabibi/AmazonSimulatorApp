using AmazonSimulatorApp.Data.DTOs;

namespace AmazonSimulatorApp.Services
{
    public interface IOrderService
    {
        void DeleteOrder(int oid);
        IEnumerable<OrdersOutputOTD> GetAllOrders(int uid);
        OrdersOutputOTD GetOrderById(int oid, int uid);
        void PlaceOrder(List<OrderItemDTO> items, int uid);
    }
}