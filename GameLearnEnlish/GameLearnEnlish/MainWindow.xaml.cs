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
        public SelectUC selectUC = new SelectUC();
        public HomeUC ucHome = new HomeUC();
        public ImageMissonUC ucImageMission = new ImageMissonUC();
        public VideoMissionUC ucVideoMission = new VideoMissionUC();

        public MainWindow()
        {
            InitializeComponent();
            CSGlobal.Instance.WindowMain = this;
            grdMain.Children.Remove(ucImageMission);
            grdMain.Children.Remove(ucVideoMission);
            grdMain.Children.Add(ucHome);
        }

        public MainWindow(SelectUC ucSelect)
        {
            InitializeComponent();
            this.selectUC = ucSelect;
            if(selectUC == SelectUC._imageMissionUC)
            {
                grdMain.Children.Remove(ucVideoMission);
                grdMain.Children.Remove(ucHome);
                grdMain.Children.Add(ucImageMission);
            }
            else if(selectUC == SelectUC._videoMissionUC)
            {
                grdMain.Children.Remove(ucImageMission);
                grdMain.Children.Remove(ucHome);
                grdMain.Children.Add(ucVideoMission);
            }
            else if (selectUC == SelectUC._homeUC)
            {
                grdMain.Children.Remove(ucImageMission);
                grdMain.Children.Remove(ucHome);
                grdMain.Children.Add(ucImageMission);
            }

        }
    }
}
