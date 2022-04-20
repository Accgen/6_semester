using System.Collections.Generic;

namespace SPP.Lab2.models
{
    public class OrderSummary
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public ICollection<Product> Product { get; set; }
        public int Count { get; set; }
        public Order Order { get; set; }
    }
}