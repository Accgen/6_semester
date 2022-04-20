using System.Collections.Generic;
using System.Linq;
using System.Windows;
using SPP.Lab2.DB;
using SPP.Lab2.models;

namespace SPP.Lab2
{
    public partial class AddSite : Window
    {
        private IRepository<Site> _repository { get; set; }
        private IRepository<SiteOwner> _SiteOwnerRepository { get; set; }
        private int Id { get; set; }
        public AddSite(IRepository<Site> repository, int id, IRepository<SiteOwner> siteOwnerRepository)
        {
            InitializeComponent();
            _repository = repository;
            Id = id;
            _SiteOwnerRepository = siteOwnerRepository;
        }
        
        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            var site = new Site
            {
                Name = nameTextBox.Text,
                SiteOwnerId = Id
            };
            
            _repository.Create(site);
            Load(); 
            Hide();
        }
        private void Load()
        {
            var info = _SiteOwnerRepository
                .Include(owner => owner.Sites,
                    owner => owner.DNS)
                .ToList().FirstOrDefault(owner => owner.Id == Id);

            var list = new List<Info>();
            if (info != null)
            {
                list = info.Sites.Select(owner => new Info
                {
                    Name = info.Name,
                    SiteName = owner.Name
                }).ToList();
            }
            
            FullInfo.dataGrid.ItemsSource = list;
        }
    }
}