using System.Collections.Generic;

namespace SPP.Lab2.models
{
    public class DNS
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SiteOwner> SiteOwners { get; set; }
    }
}