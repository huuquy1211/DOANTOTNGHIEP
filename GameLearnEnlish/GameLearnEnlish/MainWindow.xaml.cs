using GameLearnEnlish.Model;
using GameLearnEnlish.UserControls;
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

namespace GameLearnEnlish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HomeUC homeUC;
        //MenuUC menuUC;
        //BoxSubMenuUC boxSubMenuUC;
        //ListActiveUC listActive;
        //Menu_GlobeUC menu_GlobeUC;

        public MainWindow()
        {
            InitializeComponent();
            Global.Instance.WindowMain = this;
            homeUC = new HomeUC();
           
            grdHomeUC.Children.Add(homeUC);
            //grdMenuUC.Children.Add(menuUC);
            //grdBoxSubMenuUC.Children.Add(boxSubMenuUC);
            //grdListActiveUC.Children.Add(listActive);
            //grdMenu_GlobeUC.Children.Add(menu_GlobeUC);
        }
       
    }
}
