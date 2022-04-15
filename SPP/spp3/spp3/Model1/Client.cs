using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spp3.Model1
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sourname { get; set; }
        public string Passport { get; set; }

        private List<Car> Cars { get; set; }
    }
}
