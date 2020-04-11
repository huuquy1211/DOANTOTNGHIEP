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
        //public SelectUC selectUC;
        //public HomeUC ucHome;
        //public BoxSubMenuUC ucBoxSubMenu;
        //public Menu_GlobeUC ucMenu_Globe;

        //public ImageMissonUC ucImageMission;
        //public VideoMissionUC ucVideoMission;
        //public MenuUC ucMenu;

        public MainWindow()
        {
            InitializeComponent();
            //ucImageMission = new ImageMissonUC();
            //ucVideoMission = new VideoMissionUC();

            //ucMenu = new MenuUC();
            //ucHome = new HomeUC();
            //ucBoxSubMenu = new BoxSubMenuUC();
            //ucMenu_Globe = new Menu_GlobeUC();

            Global.Instance.WindowMain = this;

            //grdMain.Children.Remove(grdBoxSubMenuUC);
            //grdMain.Children.Remove(grdMenu_GlobeUC);
            //grdMain.Children.Remove(grdMenuUC);
            //grdMain.Children.Clear();
            //grdHomeUC.Children.Add(ucHome);
            //grdMain.Children.Add(grdHomeUC);

        }

        //public MainWindow(SelectUC ucSelect)
        //{
        //    InitializeComponent();
        //    selectUC = new SelectUC();
        //    this.selectUC = ucSelect;

        //    if(selectUC == SelectUC._menuUC)
        //    {
        //        grdMain.Children.Remove(grdBoxSubMenuUC);
        //        grdMain.Children.Remove(grdMenu_GlobeUC);
        //        grdMain.Children.Add(grdHomeUC);
        //        grdMain.Children.Add(grdMenuUC);
        //    }

        //}
    }
}
