using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public  recordsDBEntities db = new recordsDBEntities();

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

       

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            var searched = from c in db.Games
                           
                           select new { c.dateAdded, c.gameID };
            //Set listbox to display results
            //lbxGames.ItemsSource = searched.ToList();

           
            InitializeComponent();

            lbxGames.ItemsSource = searched.ToList();
            lbxGames.DisplayMemberPath = "dateAdded";
            lbxGames.SelectedValuePath = "gameID";



        }

      
        private string GetDetails()
        {
            if (lbxPlayers.SelectedValue != null)
            {
                gameInstance selected = (gameInstance)lbxGames.SelectedItem;
                //Set textblock to display details
                return string.Format("  {0} Stars: {1} Coins: {2}", selected.player, selected.stars, selected.coins);
            }
            else
                return "";
        }

        private void lbxGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id=Convert.ToInt32(lbxGames.SelectedValue);
            var query = from c in db.gameInstances
                        join p in db.players on c.playerId equals p.playerId
                        where c.gameId == id
                        select new { Username=p.username, Stars=c.stars, Coins=c.coins, p.playerId};

            lbxPlayers.DataContext = query.ToList();
            string q = @"select p.username, c.stars,c.coins,p.playerId from gameInstance as c join players as p on c.playerId=p.playerId where c.gameId = '" + id +"'" ;
            DBConnection con = new DBConnection();
            con.OpenConnection();
            
            DataTable ds= con.ShowDataInGridView(q);
            con.CloseConnection();

           
            Binding matBinding = new Binding() { Source = ds.DefaultView };
            lbxPlayers.SetBinding(ListView.ItemsSourceProperty, matBinding); 
            







        }

        private void btnRankings_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Rankings.xaml", UriKind.Relative));
        }

      






        private void lbxPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var myListView = sender as ListView;
            if (myListView != null)
            {
                int ID = Convert.ToInt32(((DataRowView)lbxPlayers.SelectedValue)["playerId"]);
                this.NavigationService.Navigate(new PlayerInfo(ID));

               
            }
            
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("options.xaml", UriKind.Relative));
        }
    }
}
