using System.Collections.Generic;

namespace SPP.Lab2.models
{
    public class SiteOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DnsId { get; set; }
        public ICollection<Site> Sites { get; set; }
        public DNS DNS { get; set; }
    }
}