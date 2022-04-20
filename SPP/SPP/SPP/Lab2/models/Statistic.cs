using System.Collections.Generic;

namespace SPP.Lab2.models
{
    public class Statistic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SiteId { get; set; }
        public int AverageUserTime { get; set; }
        public ICollection<User> Users { get; set; }
        public Site Site { get; set; }
    }
}