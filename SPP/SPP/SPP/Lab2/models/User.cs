using System.Collections.Generic;

namespace SPP.Lab2.models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Statistic> Statistic { get; set; }
        public int StatisticId { get; set; }
    }
}