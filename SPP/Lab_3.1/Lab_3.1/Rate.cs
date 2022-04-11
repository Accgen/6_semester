using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._1
{
    public class Rate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public List<Rent> Rents { get; set; }
    }
}
