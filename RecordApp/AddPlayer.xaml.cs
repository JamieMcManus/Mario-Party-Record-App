using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for AddPlayer.xaml
    /// </summary>
    public partial class AddPlayer : Page
    {
        public AddPlayer()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // add new player
            // var username = new SqlParameter("@username",txtName.Text);

            /* player p = new player();
             p.username = txtName.Text;
             DateTime d =  DateTime.Today;
             p.joinedOn = d;
             p.imagePath = ddlSelectImage.SelectedItem.ToString();
             recordsDBEntities db = new recordsDBEntities();
             db.spNewUser(txtName.Text, ddlSelectImage.SelectedItem.ToString());
             // return to home page
            
            DBConnection db = new DBConnection();
            db.OpenConnection();
            db.AddPlayer(txtName.Text, ddlSelectImage.SelectedValue.ToString());
            db.CloseConnection();
             */
            ComboBoxItem ComboItem = (ComboBoxItem)ddlSelectImage.SelectedItem;
            string path = ComboItem.Content.ToString();
            DBentityAccess addUser = new DBentityAccess();
            addUser.AddPlayer(txtName.Text, path);
            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.Relative));


        }

        private void btnToMain_Click(object sender, RoutedEventArgs e)
        {

            


            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.Relative));
        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "Enter Name")
            {
                txtName.Clear();
            }
            
        }
         private void validatePlayerInfo()
        {
            if ( txtName.Text.Length > 4 && ddlSelectImage.SelectedItem !=null && txtName.Text!="Enter Name")
            {
                btnAddPlayer.IsEnabled = true;
            }

            
            else
            {
               btnAddPlayer.IsEnabled = false;
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text != "Enter Name")
            {
                validatePlayerInfo();
            }
            


        }

        private void ddlSelectImage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            validatePlayerInfo();

            ComboBoxItem ComboItem = (ComboBoxItem)ddlSelectImage.SelectedItem;
            string name = @"\images\" + ComboItem.Content.ToString()+".png";
            string source = @"\images\" + ddlSelectImage.SelectionBoxItem.ToString();
            image.Source = new BitmapImage(new Uri(name, UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            btnAddPlayer.IsEnabled = false;
        }
    }
}
