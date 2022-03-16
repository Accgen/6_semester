using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.DataModels
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sourname { get; set; }
        public string Passport { get; set; }
        public string Telephone { get; set; }

        public List<Rate> Rates { get; set;} = new List<Rate> { };

    }
}
