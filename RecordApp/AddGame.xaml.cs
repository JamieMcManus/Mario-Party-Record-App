using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public recordsDBEntities db = new recordsDBEntities();

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
            int p1ID = Convert.ToInt32(dbPlayer1.SelectedValue);
            int p2ID = Convert.ToInt32(dbPlayer2.SelectedValue);
            int p3ID = Convert.ToInt32(dbPlayer3.SelectedValue);
            int p4ID = Convert.ToInt32(dbPlayer4.SelectedValue);

            DBConnection conect = new DBConnection();
            conect.OpenConnection();
            //conect.AddGame()
            conect.AddGame(p1ID, Convert.ToInt32(txtP1Star.Text), Convert.ToInt32(txtP1Coin.Text), p2ID, Convert.ToInt32(txtP2Star.Text), Convert.ToInt32(txtP2Coin.Text), p3ID, Convert.ToInt32(txtP3Star.Text), Convert.ToInt32(txtP3Coin.Text), p4ID, Convert.ToInt32(txtP4Star.Text), Convert.ToInt32(txtP4Coin.Text));
            conect.CloseConnection();

            //Return to home page
            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.Relative));

        }

        private void dbPlayer1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void dbPlayer2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void dbPlayer3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void dbPlayer4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void txtP1Star_TextChanged(object sender, TextChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void txtP2Star_TextChanged(object sender, TextChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void txtP3Star_TextChanged(object sender, TextChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void txtP4Star_TextChanged(object sender, TextChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void txtP1Coin_TextChanged(object sender, TextChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void txtP2Coin_TextChanged(object sender, TextChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void txtP3Coin_TextChanged(object sender, TextChangedEventArgs e)
        {
            verifyGameInfo();
        }

        private void txtP4Coin_TextChanged(object sender, TextChangedEventArgs e)
        {
            verifyGameInfo();
            NumCheck(txtP4Coin.Text);
        }
        public void NumCheck(string input)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
           if (!regex.IsMatch(input))
            {
                btnAddGame.IsEnabled = true;
            }
           else
            {
                btnAddGame.IsEnabled = false;
            }
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
            var Query = from c in db.players
                        select c;
            InitializeComponent();

            dbPlayer1.ItemsSource = Query.ToList();
            dbPlayer1.DisplayMemberPath = "username";
            dbPlayer1.SelectedValuePath = "playerId";

            dbPlayer2.ItemsSource = Query.ToList();
            dbPlayer2.DisplayMemberPath = "username";
            dbPlayer2.SelectedValuePath = "playerId";

            dbPlayer3.ItemsSource = Query.ToList();
            dbPlayer3.DisplayMemberPath = "username";
            dbPlayer3.SelectedValuePath = "playerId";

            dbPlayer4.ItemsSource = Query.ToList();
            dbPlayer4.DisplayMemberPath = "username";
            dbPlayer4.SelectedValuePath = "playerId";

            
        }

        private void txtP1Star_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //limit input to numeric only
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
