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

        private void dbPlayer1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dbPlayer2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dbPlayer3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dbPlayer4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtP1Star_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtP2Star_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtP3Star_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtP4Star_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtP1Coin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtP2Coin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtP3Coin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtP4Coin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void verifyGameInfo()
        {
            if(dbPlayer1.SelectedItem==null || txtP1Coin.Text=="" || txtP1Star.Text == "")
            {
                btnAddGame.IsEnabled = false;
            }
            if (dbPlayer2.SelectedItem == null || txtP2Coin.Text == "" || txtP2Star.Text == "")
            {
                btnAddGame.IsEnabled = false;
            }
            if (dbPlayer3.SelectedItem == null || txtP3Coin.Text == "" || txtP3Star.Text == "")
            {
                btnAddGame.IsEnabled = false;
            }
            if (dbPlayer4.SelectedItem == null || txtP4Coin.Text == "" || txtP4Star.Text == "")
            {
                btnAddGame.IsEnabled = false;
            }
            else
            {
                btnAddGame.IsEnabled = true;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            btnAddGame.IsEnabled = false;
        }
    }
}
