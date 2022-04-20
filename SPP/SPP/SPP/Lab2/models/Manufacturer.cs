using System;

namespace SPP.Lab2.models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}