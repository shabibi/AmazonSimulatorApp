
namespace AmazonSimulatorApp.Data.Repositories
{
    public interface IOrderRepo
    {
        void AddOrder(Order order);
        void DeleteOrder(int oid);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int oid);
        IEnumerable<Order> GetOrderByUserId(int cid);
        void UpdateOrder(Order order);
    }
}