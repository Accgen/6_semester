using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.DataModels
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year_release { get; set; }

        public List<Provider> ProviderList { get; set; } = new List<Provider>();    
    }
}
