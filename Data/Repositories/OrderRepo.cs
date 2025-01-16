using Microsoft.EntityFrameworkCore;

namespace AmazonSimulatorApp.Data.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            try
            {
                return _context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        public Order GetOrderById(int oid)
        {
            try
            {
                return _context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                    .FirstOrDefault(o => o.OID == oid);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        public IEnumerable<Order> GetOrderByUserId(int cid)
        {
            try
            {
                return _context.Orders
                    .Where(o => o.CID == cid)
                    .Include(o => o.Client)
                    .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        public void AddOrder(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        public void DeleteOrder(int oid)
        {
            try
            {
                var order = GetOrderById(oid);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                _context.Orders.Update(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }
    }
}
