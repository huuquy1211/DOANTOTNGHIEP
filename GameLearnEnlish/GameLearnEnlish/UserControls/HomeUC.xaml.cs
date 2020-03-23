using GameLearnEnlish.Model;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomeUC : UserControl
    {
        public HomeUC()
        {
            InitializeComponent();

            grdType.Visibility = Visibility.Hidden;
            grdHome.Visibility = Visibility.Visible;
        }

        private void imgbtnPlay_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdType.Visibility = Visibility.Visible;
            grdHome.Visibility = Visibility.Hidden;
        }

        private void grdImgMission_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CSGlobal.Instance.WindowMain.grdMain.Children.Clear();
            CSGlobal.Instance.WindowMain.grdMain.Children.Add(new ImageMissonUC());
        }

        private void grdVideoMission_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CSGlobal.Instance.WindowMain.grdMain.Children.Clear();
            CSGlobal.Instance.WindowMain.grdMain.Children.Add(new VideoMissionUC());
        }
    }
}
