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
        public static HomeUC homeUC = null;
        private MenuUC ucMenu;
        private BoxSubMenuUC ucBoxSubMenu;
        private Menu_GlobeUC ucMenu_Globe;
        private Box_helpUC ucBox_help;
        private Exit_bg_boxUC ucExit_bg_box;

        public HomeUC()
        {
            homeUC = this;
            InitializeComponent();
            ucMenu = new MenuUC();
            ucBoxSubMenu = new BoxSubMenuUC();
            ucMenu_Globe = new Menu_GlobeUC();
            ucBox_help = new Box_helpUC();
            ucExit_bg_box = new Exit_bg_boxUC();

            grdHome.Visibility = Visibility.Visible;
            grdBackGroud.Visibility = Visibility.Hidden;
        }

        private void imgbtnPlay_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdHome.Visibility = Visibility.Hidden;
        }

        private void imgbtnMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            

            grdBackGroud.Visibility = Visibility.Visible;
            //CSGlobal.Instance.WindowMain.grdMain.Children.Clear();
            Global.Instance.WindowMain.grdMenuUC.Children.Add(ucMenu);
            Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Add(ucBoxSubMenu);
            Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Add(ucMenu_Globe);
        }

        private void imgbtnHelp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Global.Instance.WindowMain.grdBox_helpUC.Children.Add(ucBox_help);
        }

        private void imgbtnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {

            grdToolbarMenu.IsEnabled = false;
            Global.Instance.WindowMain.grdExit_bg_boxUC.Children.Add(ucExit_bg_box);
        }

       
        public void IsEnabledGridToolbarMenu(SelectElementUC selectElementUC)
        {
            if (selectElementUC == SelectElementUC._notEnable)
            {
                grdToolbarMenu.IsEnabled = false;
            }
            else if (selectElementUC == SelectElementUC._isEnable)
                grdToolbarMenu.IsEnabled = true;
        }
        private void grdBackGroud_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.Current = Cursors.WaitCursor;
            grdBackGroud.Visibility = Visibility.Hidden;
            Global.Instance.WindowMain.grdMenuUC.Children.Remove(ucMenu);
            Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Remove(ucBoxSubMenu);
            Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Remove(ucMenu_Globe);
            Global.Instance.WindowMain.grdExit_bg_boxUC.Children.Remove(ucExit_bg_box);
        }
    }
}
