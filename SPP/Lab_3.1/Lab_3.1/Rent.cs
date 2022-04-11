using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._1
{
    public class Rent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }


        public int RateId { get; set; }
        public Rate Rate { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
