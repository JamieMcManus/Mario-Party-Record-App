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
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        public double Progress
        {
            get { return progressBar.Value; }
            set { progressBar.Value = value; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            imageBox.Source= new BitmapImage(new Uri(@"/images/splash.jpg", UriKind.Relative));
            //txbTitle.Style = (Style) FindResource("MarioPartyFonts");
        }
    }
}
