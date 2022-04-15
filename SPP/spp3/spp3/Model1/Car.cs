using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spp3.Model1
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year_release { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public List<Rent> Rents { get; set; }

    }
}
