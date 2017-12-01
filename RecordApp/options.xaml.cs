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
    /// Interaction logic for options.xaml
    /// </summary>
    public partial class options : Page
    {
        DBConnection d = new DBConnection();

        public options()
        {
            InitializeComponent();
        }

        private void btnDelUsers_Click(object sender, RoutedEventArgs e)
        {
            /*  d.OpenConnection();
             d.ExecQueries("DELETE FROM gameInstance DELETE FROM game DELETE FROM players");
             d.CloseConnection(); */

            MessageBoxResult result = MessageBox.Show("Are you sure you wish to delete all user profiles? This will delete all users and corresponding game records", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    d.OpenConnection();
                    d.ExecQueries("DELETE FROM gameInstance DELETE FROM game DELETE FROM players");
                    d.CloseConnection();
                    break;
                case MessageBoxResult.No:

                    break;
                case MessageBoxResult.Cancel:

                    break;
            }



        }

        private void btnDelAll_Click(object sender, RoutedEventArgs e)
        {
            /* d.OpenConnection();
             d.ExecQueries("DELETE FROM gameInstance DELETE FROM game ");
             d.CloseConnection(); */
            MessageBoxResult result = MessageBox.Show("Are you sure you wish to delete all game records? User profiles will be retained", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    d.OpenConnection();
                    d.ExecQueries("DELETE FROM gameInstance DELETE FROM game ");
                    d.CloseConnection();
                    break;
                case MessageBoxResult.No:
                   
                    break;
                case MessageBoxResult.Cancel:
                    
                    break;
            }
        }

        private void btnToMain_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.Relative));
        }
    }
}
