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
    /// Interaction logic for BackgroudOpacityUC.xaml
    /// </summary>
    public partial class BackgroudOpacityUC : UserControl
    {
        public BackgroudOpacityUC()
        {
            InitializeComponent();
        }

        private void grdBackGroud_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Global.Instance.WindowMain.grdMenuUC.Children.Clear();
            Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Clear();
            Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Clear();
            Global.Instance.WindowMain.grdExit_bg_boxUC.Children.Clear();
            Global.Instance.WindowMain.grdBackgroudOpacityUC.Children.Clear();
        }
    }
}
