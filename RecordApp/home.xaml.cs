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
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : Page
    {
        public home()
        {
            InitializeComponent();
        }

        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AddGame.xaml", UriKind.Relative));
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AddPlayer.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("PlayerInfo.xaml", UriKind.Relative));
        }
    }
}
