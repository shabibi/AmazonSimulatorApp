﻿namespace AmazonSimulatorApp.Data.DTOs
{
    public class OrderItemDTO
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}