using System;

namespace SPP.Lab2.models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public decimal TotalSum { get; set; }
        public Client Client { get; set; }
        public OrderSummary OrderSummary { get; set; }
    }
}