using AmazonSimulatorApp.Data.Repositories;
using AmazonSimulatorApp.Data;
using AmazonSimulatorApp.Data.DTOs;

namespace AmazonSimulatorApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IProductRepo _productRepo;
        private readonly IOrderDetailRepo _orderDetailRepo;

        public OrderService(IOrderRepo orderRepo, IProductRepo productRepo, IOrderDetailRepo orderDetailRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _orderDetailRepo = orderDetailRepo;
        }

        // Get all orders for a user
        public IEnumerable<OrdersOutputOTD> GetAllOrders(int uid)
        {
            var orders = _orderRepo.GetOrderByUserId(uid);
            if (!orders.Any())
                throw new InvalidOperationException($"No orders found for user ID {uid}.");

            return orders.Select(order => new OrdersOutputOTD
            {
                OrderId = order.OID,
                ClientName = order.Client.User.Name,
                TotalAmount = order.TotalAmount,
                OrderItems = _orderDetailRepo.GetOrderDetailsByOrderId(order.OID)
                    .Select(od => new OrderItemDTO
                    {
                        ProductName = od.Product.Name,
                        Quantity = od.Quantity,
                        Price = od.Product.Price
                    }).ToList()
            });
        }

        // Get specific order details
        public OrdersOutputOTD GetOrderById(int oid, int uid)
        {
            var order = _orderRepo.GetOrderById(oid);
            if (order == null || order.Client.CID != uid)
                throw new InvalidOperationException($"Order not found or access denied.");

            return new OrdersOutputOTD
            {
                OrderId = order.OID,
                ClientName = order.Client.User.Name,
                TotalAmount = order.TotalAmount,
                OrderItems = _orderDetailRepo.GetOrderDetailsByOrderId(order.OID)
                    .Select(od => new OrderItemDTO
                    {
                        ProductName = od.Product.Name,
                        Quantity = od.Quantity,
                        Price = od.Product.Price
                    }).ToList()
            };
        }

        // Place an order
        public void PlaceOrder(List<OrderItemDTO> items, int uid)
        {
            if (!items.Any())
                throw new InvalidOperationException("Order must contain at least one item.");

            decimal totalOrderPrice = 0;
            var order = new Order { CID = uid, Date = DateTime.Now, TotalAmount = 0 };
            _orderRepo.AddOrder(order);

            foreach (var item in items)
            {
                var product = _productRepo.GetProductByName(item.ProductName);
                if (product == null)
                    throw new InvalidOperationException($"Product {item.ProductName} not found.");

                if (product.Stock < item.Quantity)
                    throw new InvalidOperationException($"Insufficient stock for product {item.ProductName}.");

                var totalPrice = product.Price * item.Quantity;
                totalOrderPrice += totalPrice;

                // Update stock
                product.Stock -= item.Quantity;
                _productRepo.UpdateProduct(product);

                // Add order details
                var orderDetail = new OrderDetail
                {
                    OID = order.OID,
                    PID = product.PID,
                    Quantity = item.Quantity
                };
                _orderDetailRepo.AddOrderDetail(orderDetail);
            }

            // Update order total
            order.TotalAmount = totalOrderPrice;
            _orderRepo.UpdateOrder(order);
        }

        // Delete an order
        public void DeleteOrder(int oid)
        {
            var order = _orderRepo.GetOrderById(oid);
            if (order == null)
                throw new KeyNotFoundException($"Order with ID {oid} not found.");

            _orderRepo.DeleteOrder(oid);
        }
    }
}
