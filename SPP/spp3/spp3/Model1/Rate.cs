using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spp3.Model1
{
    public class Rate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
                
        public List<Rent> Rents { get; set; }
    }
}
