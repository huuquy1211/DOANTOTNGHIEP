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
    /// Interaction logic for Exit_bg_boxUC.xaml
    /// </summary>
    public partial class Exit_bg_boxUC : UserControl
    {

        public Exit_bg_boxUC()
        {
            InitializeComponent();
        }

        private void imgbtnExit_bt_yes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Global.Instance.WindowMain.Close();
        }

        private void imgbtnExit_bt_no_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomeUC.homeUC.IsEnabledGridToolbarMenu(SelectElementUC._isEnable);
            Global.Instance.WindowMain.grdExit_bg_boxUC.Children.Remove(this);
        }
    }
}
