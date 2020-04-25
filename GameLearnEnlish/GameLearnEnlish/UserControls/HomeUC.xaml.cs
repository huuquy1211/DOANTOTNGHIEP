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
        private BackgroudOpacityUC backgroudOpacity;
        MediaPlayer mplayer = new MediaPlayer();
        //public static SelectElementUC ButtonSelect;

        public HomeUC()
        {
            homeUC = this;
            InitializeComponent();

            grdHome.Visibility = Visibility.Visible;
            if (Global.Instance.ButtonMenuSelect == SelectElementUC._imgBt_unit_new)
            {
                ucMenu = new MenuUC();
                ucBoxSubMenu = new BoxSubMenuUC();
                ucMenu_Globe = new Menu_GlobeUC();
                backgroudOpacity = new BackgroudOpacityUC();

                Global.Instance.WindowMain.grdBackgroudOpacityUC.Children.Add(backgroudOpacity);//Khởi tạo UC BackgroudOpacityUC
                Global.Instance.WindowMain.grdMenuUC.Children.Add(ucMenu);
                Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Add(ucBoxSubMenu);
                Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Add(ucMenu_Globe);

                BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_unit_1");
                MenuUC.menuUC.IsVisibleButtonClick("imgBt_unit_1");
                Global.Instance.UnitSelect = Unit._unit1;
            }
        }

        private void imgbtnMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Global.Instance.WindowMain.grdBackgroudOpacityUC.Children.Add(backgroudOpacity);//Khởi tạo UC BackgroudOpacityUC
            Global.Instance.WindowMain.grdMenuUC.Children.Add(ucMenu);
            Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Add(ucBoxSubMenu);
            Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Add(ucMenu_Globe);

            switch (Global.Instance.ButtonMenuSelect)
            {
                //case SelectElementUC._imgBt_unit_new: //Khi mới mở menu lên
                //    {
                //        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_unit_1");
                //        MenuUC.menuUC.IsVisibleButtonClick("imgBt_unit_1");
                //        Global.Instance.UnitSelect = Unit._unit1;

                //        break;
                //    }
                case SelectElementUC._imgBt_unit_1:
                    {
                        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_unit_1");
                        MenuUC.menuUC.IsVisibleButtonClick("imgBt_unit_1");
                        grdBackGroud.Visibility = Visibility.Hidden;
                        break;
                    }
                case SelectElementUC._imgBt_unit_2:
                    {
                        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_unit_2");
                        MenuUC.menuUC.IsVisibleButtonClick("imgBt_unit_2");
                        break;
                    }
                case SelectElementUC._imgBt_unit_3:
                    {
                        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_unit_3");
                        MenuUC.menuUC.IsVisibleButtonClick("imgBt_unit_3");
                        break;
                    }
                case SelectElementUC._imgBt_unit_4:
                    {
                        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_unit_4");
                        MenuUC.menuUC.IsVisibleButtonClick("imgBt_unit_4");
                        break;
                    }
                case SelectElementUC._imgBt_unit_5:
                    {
                        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_unit_5");
                        MenuUC.menuUC.IsVisibleButtonClick("imgBt_unit_5");
                        break;
                    }
                case SelectElementUC._imgBt_unit_6:
                    {
                        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_unit_6");
                        MenuUC.menuUC.IsVisibleButtonClick("imgBt_unit_6");
                        break;
                    }
                case SelectElementUC._imgBt_unit_7:
                    {
                        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_unit_7");
                        MenuUC.menuUC.IsVisibleButtonClick("imgBt_unit_7");
                        break;
                    }
                case SelectElementUC._imgBt_unit_8:
                    {
                        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_unit_8");
                        MenuUC.menuUC.IsVisibleButtonClick("imgBt_unit_8");
                        break;
                    }
                case SelectElementUC._imgBt_AS:
                    {
                        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_AS");
                        MenuUC.menuUC.IsVisibleButtonClick("imgBt_AS");
                        break;
                    }
                case SelectElementUC._imgBt_Phonics:
                    {
                        BoxSubMenuUC.boxSubMenuUC.ChangeUnit("imgBt_Phonics");
                        MenuUC.menuUC.IsVisibleButtonClick("imgBt_Phonics");
                        break;
                    }

                default:
                    break;
            }


        }

        private void imgbtnHelp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ucBox_help = new Box_helpUC();
            Global.Instance.WindowMain.grdBox_helpUC.Children.Add(ucBox_help);
        }

        private void imgbtnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mplayer.Open(new Uri(@"..\..\media\audio\global\clickbutton.mp3", UriKind.Relative));
            mplayer.Play();
            ucExit_bg_box = new Exit_bg_boxUC();
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
        public void HiddenMenu()
        {
            Global.Instance.WindowMain.grdMenuUC.Children.Remove(ucMenu);
            Global.Instance.WindowMain.grdBackgroudOpacityUC.Children.Clear();
            Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Clear();
            Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Clear();
            Global.Instance.WindowMain.grdExit_bg_boxUC.Children.Clear();
        }

        private void imgbtnNext_MouseDown(object sender, MouseButtonEventArgs e)
        {

           
        }
        //private void grdBackGroud_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    //this.Current = Cursors.WaitCursor;
        //    grdBackGroud.Visibility = Visibility.Hidden;
        //    Global.Instance.WindowMain.grdMenuUC.Children.Remove(ucMenu);
        //    Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Clear();
        //    Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Clear();
        //    Global.Instance.WindowMain.grdExit_bg_boxUC.Children.Clear();
        //}
    }
}
