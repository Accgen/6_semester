namespace SPP.Lab2.models
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SiteOwnerId { get; set; }
        public SiteOwner SiteOwner { get; set; }
        public Statistic Statistics { get; set; }
    }
}