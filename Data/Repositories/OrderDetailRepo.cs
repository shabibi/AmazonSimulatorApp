using Microsoft.EntityFrameworkCore;

namespace AmazonSimulatorApp.Data.Repositories
{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            try
            {
                return _context.OrderDetails.Include(od => od.Product).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int oid)
        {
            try
            {
                return _context.OrderDetails
                    .Where(od => od.OID == oid)
                    .Include(od => od.Product)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }
    }
}





