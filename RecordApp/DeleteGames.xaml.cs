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
using System.Windows.Shapes;

namespace RecordApp
{
    /// <summary>
    /// Interaction logic for DeleteGames.xaml
    /// </summary>
    public partial class DeleteGames : Window
    {
        DBConnection d = new DBConnection();

        public DeleteGames()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            d.OpenConnection();
            d.ExecQueries("DELETE FROM gameInstance DELETE FROM game ");
            d.CloseConnection();

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
