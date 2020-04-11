using GameLearnEnlish.Utility;
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
    /// Interaction logic for Box_helpUC.xaml
    /// </summary>
    public partial class Box_helpUC : UserControl
    {
        public Box_helpUC()
        {
            InitializeComponent();
        }

        private void imgBt_help_close_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri uri = new Uri(@"\Images\Global\Bt_help_close_over.png", UriKind.Relative);
            imgBt_help_close.Source = new BitmapImage(uri);
        }

        private void imgBt_help_close_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri uri = new Uri(@"\Images\Global\Bt_help_close.png", UriKind.Relative);
            imgBt_help_close.Source = new BitmapImage(uri);
        }

        private void imgBt_help_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Global.Instance.WindowMain.grdBox_helpUC.Children.Remove(this);
        }
    }
}
