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
    /// Interaction logic for AddGame.xaml
    /// </summary>
    public partial class AddGame : Page
    {
        public AddGame()
        {
            InitializeComponent();
        }

        private void btnToMain_Click(object sender, RoutedEventArgs e)
        {
            // next page
            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.Relative));
        }

        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            //Check if all info entered
            
            
            //Create new Game

            //Return to home page
            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.Relative));

        }
    }
}
