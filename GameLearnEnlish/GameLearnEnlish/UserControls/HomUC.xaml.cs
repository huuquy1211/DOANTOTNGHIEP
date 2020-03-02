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

namespace GameLearnEnlish.UserControls
{
    /// <summary>
    /// Interaction logic for HomUC.xaml
    /// </summary>
    public partial class HomUC : UserControl
    {
        public HomUC()
        {
            InitializeComponent();
        }

        private void btnPlay_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BitmapImage image = new BitmapImage(new Uri("../Images/play.png", UriKind.Relative));
            btnPlay.Source = image;
            //MapUC mapUC = new MapUC();
            //this.Visibility = Visibility.Hidden;
            //mapUC.Visibility = Visibility.Visible;
        }

        private void btnPlay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage image = new BitmapImage(new Uri("../Images/playhover.png", UriKind.Relative));
            btnPlay.Source = image;
        }
    }
}
