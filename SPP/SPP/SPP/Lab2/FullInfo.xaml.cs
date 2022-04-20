using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SPP.Lab2.DB;
using SPP.Lab2.models;

namespace SPP.Lab2
{
    public partial class FullInfo : Window
    {
        private IRepository<Client> _clientRepository { get; set; }
        private IRepository<SiteOwner> _SiteOwnerRepository { get; set; }
        private IRepository<Site> _SiteRepository { get; set; }
        public static DataGrid dataGrid;
        private int Id { get; set; }

        public FullInfo(IRepository<Client> clientRepository,
            int id, IRepository<SiteOwner> siteOwnerRepository,
            IRepository<Site> siteRepository)
        {
            InitializeComponent();
            _clientRepository = clientRepository;
            _SiteOwnerRepository = siteOwnerRepository;
            _SiteRepository = siteRepository;
            Id = id;
            Load();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var info = _SiteOwnerRepository
                .GetAll().ToList().FirstOrDefault(owner => owner.DnsId == Id);

            if (info == null)
            {
                info = new SiteOwner
                {
                    Name = "test",
                    DnsId = Id
                };
                _SiteOwnerRepository.Create(info);
            }

            var addSite = new AddSite(_SiteRepository, info.Id, _SiteOwnerRepository);
            addSite.ShowDialog();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Hide();
            mainWindow.Show();
        }
        // private void FullInfoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        // {
        //     var id = ((Info)FullInfoDataGrid.SelectedItem).Id;
        //     MessageBox.Show(id.ToString());
        // }
        private void Load()
        {
            var info = _SiteOwnerRepository
                                        .Include(owner => owner.Sites,
                                                owner => owner.DNS)
                                        .ToList().FirstOrDefault(owner => owner.DnsId == Id);

            var list = new List<Info>();
            if (info != null)
            {
                list = info.Sites.Select(owner => new Info
                {
                    Name = info.Name,
                    SiteName = owner.Name
                }).ToList();
            }

            FullInfoDataGrid.ItemsSource = list;
            dataGrid = FullInfoDataGrid;
        }
    }
}