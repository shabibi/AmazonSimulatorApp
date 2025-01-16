
namespace AmazonSimulatorApp.Data.Repositories
{
    public interface IOrderDetailRepo
    {
        void AddOrderDetail(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetAllOrderDetails();
        List<OrderDetail> GetOrderDetailsByOrderId(int oid);
    }
}