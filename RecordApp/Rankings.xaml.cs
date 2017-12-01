using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecordApp
{
    /// <summary>
    /// Interaction logic for Rankings.xaml
    /// </summary>
    public partial class Rankings : Page
    {
        recordsDBEntities db = new recordsDBEntities();
        public Rankings()
        {
            InitializeComponent();
        }

        private void btnToMain_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.Relative));
        }

        private void btnAsc_Click(object sender, RoutedEventArgs e)
        {

            var query = from p in db.topPlayers
                        orderby p.Stars descending, p.Coins descending
                        select p;


            DGrankings.ItemsSource = query.ToList();
        }

        private void btnDesc_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in db.topPlayers
                        orderby p.Stars ascending, p.Coins ascending
                        select p;


            DGrankings.ItemsSource = query.ToList();


           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from p in db.topPlayers
                        orderby p.Stars descending, p.Coins descending
                        select p;


            DGrankings.ItemsSource = query.ToList();
        }
    }
}
