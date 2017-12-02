using System;
using System.Collections.Generic;
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
    /// Interaction logic for PlayerInfo.xaml
    /// </summary>
    public partial class PlayerInfo : Page
    {
        recordsDBEntities db = new recordsDBEntities();
        public int ID;
        public PlayerInfo(int id)
        {
            InitializeComponent();
            ID = id;
            
        }

        private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
           
        }

        private void btnToMain_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.Relative));
        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //populate with player info from ID passed in

           
            string query = "select p.imagePath, SUM(g.coins) as Coins ,sum(g.stars) as Stars ,p.username From players as p JOIN gameInstance as g ON p.playerId = g.playerId WHERE p.playerId = " +ID +" Group by p.imagePath,p.username";
           
            DBConnection d = new DBConnection();
            d.OpenConnection();
            SqlDataReader read= d.DataReader(query);
            int wins = d.GetWins(ID);
            
            while (read.Read())
            {
                lblPlayerName.Content = read["username"].ToString();
                lblWinCount.Content = wins;
                lblStarCount.Content = read["Stars"].ToString();
                lblCoinCount.Content = read["Coins"].ToString();
                string img = read["imagePath"].ToString();

                string name = @"\images\" + img + ".png";

                profileImage.Source = new BitmapImage(new Uri(name, UriKind.Relative));
                
            }
           
              
                d.CloseConnection();

        }
    }
}
