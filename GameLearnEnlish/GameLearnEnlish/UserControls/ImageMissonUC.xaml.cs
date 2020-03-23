using GameLearnEnlish.Model;
using GameLearnEnlish.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MissonUC.xaml
    /// </summary>
    public partial class ImageMissonUC : UserControl
    {
        public bool IsEndPage = true;//Là trang cuối
        public ImageMissonUC()
        {
            InitializeComponent();
            VisibleGrid(grdCategory);
            //VisibleGrid(grdCompleteMission);
            //Thread t = new Thread(() =>
            //{
            //    for (int i = 1; i < 8; i++)
            //    {
            //        Thread.Sleep(1000);                    
            //        Application.Current.Dispatcher.Invoke(() =>
            //        {
            //            tabctrMission.SelectedIndex = i;
            //        });
            //    }
            //});
            //t.Start();           
        }

        private void imgCompleteMission_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BitmapImage image = new BitmapImage(new Uri("../Images/System/chestout.png", UriKind.Relative));
            imgCompleteMission.Source = image;
        }

        public void VisibleGrid( Grid grdName)
        {
            grdCategory.Visibility = Visibility.Hidden;
            grdMission1.Visibility = Visibility.Hidden;
            grdMission2.Visibility = Visibility.Hidden;
            grdMission3.Visibility = Visibility.Hidden;
            grdMission4.Visibility = Visibility.Hidden;
            grdMission5.Visibility = Visibility.Hidden;
            grdMission6.Visibility = Visibility.Hidden;

            grdName.Visibility = Visibility.Visible;
        }

        public void HiddenGrid()
        {
            grdCategory.Visibility = Visibility.Hidden;
            grdMission1.Visibility = Visibility.Hidden;
            grdMission2.Visibility = Visibility.Hidden;
            grdMission3.Visibility = Visibility.Hidden;
            grdMission4.Visibility = Visibility.Hidden;
            grdMission5.Visibility = Visibility.Hidden;
            grdMission6.Visibility = Visibility.Hidden;
        }


        private void grdAnimals_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsEndPage = false;
            VisibleGrid(grdMission1);
        }
        private void grdClothes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsEndPage = false;
            VisibleGrid(grdMission2);
        }

        private void grdFood_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsEndPage = false;
            VisibleGrid(grdMission3);
        }

        private void grdJobs_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsEndPage = false;
            VisibleGrid(grdMission4);
        }

        private void grdComputer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsEndPage = false;
            VisibleGrid(grdMission5);
        }

        private void grdSports_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsEndPage = false;
            VisibleGrid(grdMission6);
        }

        private void grdMusic_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsEndPage = false;
            VisibleGrid(grdMission6);
        }

        private void grdNature_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsEndPage = false;
            VisibleGrid(grdMission6);
        }

        private void imgBack_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsEndPage == true)
            {
                CSGlobal.Instance.WindowMain.grdMain.Children.Clear();
                CSGlobal.Instance.WindowMain.grdMain.Children.Add(new HomeUC());
            }
            else
            {
                VisibleGrid(grdCategory);
                IsEndPage = true;
            }
            

        }
    }
}
