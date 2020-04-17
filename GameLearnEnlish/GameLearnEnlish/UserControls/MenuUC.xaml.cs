using GameLearnEnlish.Model;
using GameLearnEnlish.Utility;
using Microsoft.Win32;
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
    /// Interaction logic for MenuUC.xaml
    /// </summary>
    public partial class MenuUC : UserControl
    {
        public static MenuUC menuUC = null;
        public SelectElementUC ButtonSelect;

        OpenFileDialog openFileDialog = new OpenFileDialog();
        public MenuUC()
        {
            menuUC = this;
            InitializeComponent();
        }
        private void CallChangeUnit(string NameBtnImage)
        {
            Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Clear();
            Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Add(new Menu_GlobeUC());
            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(NameBtnImage);

            Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Clear();
            Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Add(new BoxSubMenuUC());
            BoxSubMenuUC.boxSubMenuUC.ChangeUnit(NameBtnImage);
        }

        public void IsVisibleButtonClick(string NameButton)
        {

            switch (NameButton)
            {
                case "imgBt_unit_1":
                    {
                        imgBt_unit_click_1.Visibility = Visibility.Visible;
                        imgBt_unit_click_2.Visibility = Visibility.Hidden;
                        imgBt_unit_click_3.Visibility = Visibility.Hidden;
                        imgBt_unit_click_4.Visibility = Visibility.Hidden;
                        imgBt_unit_click_5.Visibility = Visibility.Hidden;
                        imgBt_unit_click_6.Visibility = Visibility.Hidden;
                        imgBt_unit_click_7.Visibility = Visibility.Hidden;
                        imgBt_unit_click_8.Visibility = Visibility.Hidden;
                        imgBt_AS_click.Visibility = Visibility.Hidden;
                        imgBt_Phonics_click.Visibility = Visibility.Hidden;
                        CallChangeUnit(NameButton);
                        break;
                    }
                case "imgBt_unit_2":
                    {
                        imgBt_unit_click_1.Visibility = Visibility.Hidden;
                        imgBt_unit_click_2.Visibility = Visibility.Visible;
                        imgBt_unit_click_3.Visibility = Visibility.Hidden;
                        imgBt_unit_click_4.Visibility = Visibility.Hidden;
                        imgBt_unit_click_5.Visibility = Visibility.Hidden;
                        imgBt_unit_click_6.Visibility = Visibility.Hidden;
                        imgBt_unit_click_7.Visibility = Visibility.Hidden;
                        imgBt_unit_click_8.Visibility = Visibility.Hidden;
                        imgBt_AS_click.Visibility = Visibility.Hidden;
                        imgBt_Phonics_click.Visibility = Visibility.Hidden;
                        CallChangeUnit(NameButton);
                        break;
                    }
                case "imgBt_unit_3":
                    {
                        imgBt_unit_click_1.Visibility = Visibility.Hidden;
                        imgBt_unit_click_2.Visibility = Visibility.Hidden;
                        imgBt_unit_click_3.Visibility = Visibility.Visible;
                        imgBt_unit_click_4.Visibility = Visibility.Hidden;
                        imgBt_unit_click_5.Visibility = Visibility.Hidden;
                        imgBt_unit_click_6.Visibility = Visibility.Hidden;
                        imgBt_unit_click_7.Visibility = Visibility.Hidden;
                        imgBt_unit_click_8.Visibility = Visibility.Hidden;
                        imgBt_AS_click.Visibility = Visibility.Hidden;
                        imgBt_Phonics_click.Visibility = Visibility.Hidden;
                        CallChangeUnit(NameButton);
                        break;
                    }
                case "imgBt_unit_4":
                    {
                        imgBt_unit_click_1.Visibility = Visibility.Hidden;
                        imgBt_unit_click_2.Visibility = Visibility.Hidden;
                        imgBt_unit_click_3.Visibility = Visibility.Hidden;
                        imgBt_unit_click_4.Visibility = Visibility.Visible;
                        imgBt_unit_click_5.Visibility = Visibility.Hidden;
                        imgBt_unit_click_6.Visibility = Visibility.Hidden;
                        imgBt_unit_click_7.Visibility = Visibility.Hidden;
                        imgBt_unit_click_8.Visibility = Visibility.Hidden;
                        imgBt_AS_click.Visibility = Visibility.Hidden;
                        imgBt_Phonics_click.Visibility = Visibility.Hidden;
                        CallChangeUnit(NameButton);
                        break;
                    }
                case "imgBt_unit_5":
                    {
                        imgBt_unit_click_1.Visibility = Visibility.Hidden;
                        imgBt_unit_click_2.Visibility = Visibility.Hidden;
                        imgBt_unit_click_3.Visibility = Visibility.Hidden;
                        imgBt_unit_click_4.Visibility = Visibility.Hidden;
                        imgBt_unit_click_5.Visibility = Visibility.Visible;
                        imgBt_unit_click_6.Visibility = Visibility.Hidden;
                        imgBt_unit_click_7.Visibility = Visibility.Hidden;
                        imgBt_unit_click_8.Visibility = Visibility.Hidden;
                        imgBt_AS_click.Visibility = Visibility.Hidden;
                        imgBt_Phonics_click.Visibility = Visibility.Hidden;
                        CallChangeUnit(NameButton);
                        break;
                    }
                case "imgBt_unit_6":
                    {
                        imgBt_unit_click_1.Visibility = Visibility.Hidden;
                        imgBt_unit_click_2.Visibility = Visibility.Hidden;
                        imgBt_unit_click_3.Visibility = Visibility.Hidden;
                        imgBt_unit_click_4.Visibility = Visibility.Hidden;
                        imgBt_unit_click_5.Visibility = Visibility.Hidden;
                        imgBt_unit_click_6.Visibility = Visibility.Visible;
                        imgBt_unit_click_7.Visibility = Visibility.Hidden;
                        imgBt_unit_click_8.Visibility = Visibility.Hidden;
                        imgBt_AS_click.Visibility = Visibility.Hidden;
                        imgBt_Phonics_click.Visibility = Visibility.Hidden;
                        CallChangeUnit(NameButton);
                        break;
                    }
                case "imgBt_unit_7":
                    {
                        imgBt_unit_click_1.Visibility = Visibility.Hidden;
                        imgBt_unit_click_2.Visibility = Visibility.Hidden;
                        imgBt_unit_click_3.Visibility = Visibility.Hidden;
                        imgBt_unit_click_4.Visibility = Visibility.Hidden;
                        imgBt_unit_click_5.Visibility = Visibility.Hidden;
                        imgBt_unit_click_6.Visibility = Visibility.Hidden;
                        imgBt_unit_click_7.Visibility = Visibility.Visible;
                        imgBt_unit_click_8.Visibility = Visibility.Hidden;
                        imgBt_AS_click.Visibility = Visibility.Hidden;
                        imgBt_Phonics_click.Visibility = Visibility.Hidden;
                        CallChangeUnit(NameButton);
                        break;
                    }
                case "imgBt_unit_8":
                    {
                        imgBt_unit_click_1.Visibility = Visibility.Hidden;
                        imgBt_unit_click_2.Visibility = Visibility.Hidden;
                        imgBt_unit_click_3.Visibility = Visibility.Hidden;
                        imgBt_unit_click_4.Visibility = Visibility.Hidden;
                        imgBt_unit_click_5.Visibility = Visibility.Hidden;
                        imgBt_unit_click_6.Visibility = Visibility.Hidden;
                        imgBt_unit_click_7.Visibility = Visibility.Hidden;
                        imgBt_unit_click_8.Visibility = Visibility.Visible;
                        imgBt_AS_click.Visibility = Visibility.Hidden;
                        imgBt_Phonics_click.Visibility = Visibility.Hidden;
                        CallChangeUnit(NameButton);
                        break;
                    }
                case "imgBt_AS":
                    {
                        imgBt_unit_click_1.Visibility = Visibility.Hidden;
                        imgBt_unit_click_2.Visibility = Visibility.Hidden;
                        imgBt_unit_click_3.Visibility = Visibility.Hidden;
                        imgBt_unit_click_4.Visibility = Visibility.Hidden;
                        imgBt_unit_click_5.Visibility = Visibility.Hidden;
                        imgBt_unit_click_6.Visibility = Visibility.Hidden;
                        imgBt_unit_click_7.Visibility = Visibility.Hidden;
                        imgBt_unit_click_8.Visibility = Visibility.Hidden;
                        imgBt_AS_click.Visibility = Visibility.Visible;
                        imgBt_Phonics_click.Visibility = Visibility.Hidden;
                        CallChangeUnit(NameButton);
                        break;
                    }
                case "imgBt_Phonics":
                    {
                        imgBt_unit_click_1.Visibility = Visibility.Hidden;
                        imgBt_unit_click_2.Visibility = Visibility.Hidden;
                        imgBt_unit_click_3.Visibility = Visibility.Hidden;
                        imgBt_unit_click_4.Visibility = Visibility.Hidden;
                        imgBt_unit_click_5.Visibility = Visibility.Hidden;
                        imgBt_unit_click_6.Visibility = Visibility.Hidden;
                        imgBt_unit_click_7.Visibility = Visibility.Hidden;
                        imgBt_unit_click_8.Visibility = Visibility.Hidden;
                        imgBt_AS_click.Visibility = Visibility.Hidden;
                        imgBt_Phonics_click.Visibility = Visibility.Visible;
                        CallChangeUnit(NameButton);
                        break;
                    }
                default:
                    break;
            }
        }
        private void imgBt_unit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var nameBtn = sender as Image;
            MediaPlayer mplayer = new MediaPlayer();
            if (nameBtn != null)
            {
                switch (nameBtn.Name)
                {
                    case "imgBt_unit_1":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_1_over.png", UriKind.Relative);
                            imgBt_unit_1.Source = new BitmapImage(uri);
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_1;
                            mplayer.Open(new Uri(@"D:\STUDY\HOCTAP\HK_CUOI\DOANTOTNGHIEP\GameLearnEnlish\GameLearnEnlish\media\audio\global\BigF1_cdau_menu_U01.mp3", UriKind.Relative));
                            mplayer.Play();
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_2_over.png", UriKind.Relative);
                            imgBt_unit_2.Source = new BitmapImage(uri);
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_2;

                            mplayer.Open(new Uri(@"D:\STUDY\HOCTAP\HK_CUOI\DOANTOTNGHIEP\GameLearnEnlish\GameLearnEnlish\media\audio\global\BigF1_cdau_menu_U02.mp3", UriKind.Relative));
                            mplayer.Play();

                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_3_over.png", UriKind.Relative);
                            imgBt_unit_3.Source = new BitmapImage(uri);
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_3;

                            mplayer.Open(new Uri(@"D:\STUDY\HOCTAP\HK_CUOI\DOANTOTNGHIEP\GameLearnEnlish\GameLearnEnlish\media\audio\global\BigF1_cdau_menu_U03.mp3", UriKind.Relative));
                            mplayer.Play();
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_4_over.png", UriKind.Relative);
                            imgBt_unit_4.Source = new BitmapImage(uri);
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_4;

                            mplayer.Open(new Uri(@"D:\STUDY\HOCTAP\HK_CUOI\DOANTOTNGHIEP\GameLearnEnlish\GameLearnEnlish\media\audio\global\BigF1_cdau_menu_U04.mp3", UriKind.Relative));
                            mplayer.Play();
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_5_over.png", UriKind.Relative);
                            imgBt_unit_5.Source = new BitmapImage(uri);
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_5;

                            mplayer.Open(new Uri(@"D:\STUDY\HOCTAP\HK_CUOI\DOANTOTNGHIEP\GameLearnEnlish\GameLearnEnlish\media\audio\global\BigF1_cdau_menu_U05.mp3", UriKind.Relative));
                            mplayer.Play();
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_6_over.png", UriKind.Relative);
                            imgBt_unit_6.Source = new BitmapImage(uri);
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_6;

                            mplayer.Open(new Uri(@"D:\STUDY\HOCTAP\HK_CUOI\DOANTOTNGHIEP\GameLearnEnlish\GameLearnEnlish\media\audio\global\BigF1_cdau_menu_U06.mp3", UriKind.Relative));
                            mplayer.Play();
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_7_over.png", UriKind.Relative);
                            imgBt_unit_7.Source = new BitmapImage(uri);
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_7;

                            mplayer.Open(new Uri(@"D:\STUDY\HOCTAP\HK_CUOI\DOANTOTNGHIEP\GameLearnEnlish\GameLearnEnlish\media\audio\global\BigF1_cdau_menu_U07.mp3", UriKind.Relative));
                            mplayer.Play();
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_8_over.png", UriKind.Relative);
                            imgBt_unit_8.Source = new BitmapImage(uri);
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_8;

                            mplayer.Open(new Uri(@"D:\STUDY\HOCTAP\HK_CUOI\DOANTOTNGHIEP\GameLearnEnlish\GameLearnEnlish\media\audio\global\BigF1_cdau_menu_U08.mp3", UriKind.Relative));
                            mplayer.Play();
                            break;
                        }
                    case "imgBt_AS":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_AS_over.png", UriKind.Relative);
                            imgBt_AS.Source = new BitmapImage(uri);
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_AS;

                            mplayer.Open(new Uri(@"D:\STUDY\HOCTAP\HK_CUOI\DOANTOTNGHIEP\GameLearnEnlish\GameLearnEnlish\media\audio\global\BigF1_cdau_menu_U10.mp3", UriKind.Relative));
                            mplayer.Play();
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_Phonics_over.png", UriKind.Relative);
                            imgBt_Phonics.Source = new BitmapImage(uri);
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_Phonics;

                            mplayer.Open(new Uri(@"D:\STUDY\HOCTAP\HK_CUOI\DOANTOTNGHIEP\GameLearnEnlish\GameLearnEnlish\media\audio\global\BigF1_cdau_menu_U09.mp3", UriKind.Relative));
                            mplayer.Play();
                            break;
                        }
                    default:
                        break;
                }
            }

        }

        private void imgBt_unit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var nameBtn = sender as Image;

            if (nameBtn != null)
            {
                switch (nameBtn.Name)
                {
                    case "imgBt_unit_1":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_1.png", UriKind.Relative);
                            imgBt_unit_1.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_2.png", UriKind.Relative);
                            imgBt_unit_2.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_3.png", UriKind.Relative);
                            imgBt_unit_3.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_4.png", UriKind.Relative);
                            imgBt_unit_4.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_5.png", UriKind.Relative);
                            imgBt_unit_5.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_6.png", UriKind.Relative);
                            imgBt_unit_6.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_7.png", UriKind.Relative);
                            imgBt_unit_7.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_8.png", UriKind.Relative);
                            imgBt_unit_8.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_AS":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_AS.png", UriKind.Relative);
                            imgBt_AS.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_Phonics.png", UriKind.Relative);
                            imgBt_Phonics.Source = new BitmapImage(uri);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void imgBt_unit_MouseLeave(object sender, MouseEventArgs e)
        {
            var nameBtn = sender as Image;

            if (nameBtn != null)
            {
                switch (nameBtn.Name)
                {
                    case "imgBt_unit_1":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_1.png", UriKind.Relative);
                            imgBt_unit_1.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_2.png", UriKind.Relative);
                            imgBt_unit_2.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_3.png", UriKind.Relative);
                            imgBt_unit_3.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_4.png", UriKind.Relative);
                            imgBt_unit_4.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_5.png", UriKind.Relative);
                            imgBt_unit_5.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_6.png", UriKind.Relative);
                            imgBt_unit_6.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_7.png", UriKind.Relative);
                            imgBt_unit_7.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_8.png", UriKind.Relative);
                            imgBt_unit_8.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_AS":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_AS.png", UriKind.Relative);
                            imgBt_AS.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_Phonics.png", UriKind.Relative);
                            imgBt_Phonics.Source = new BitmapImage(uri);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void imgBt_unit_MouseEnter(object sender, MouseEventArgs e)
        {
          
            var nameBtn = sender as Image;

            if (nameBtn != null)
            {
                switch (nameBtn.Name)
                {
                    case "imgBt_unit_1":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_1_over.png", UriKind.Relative);
                            imgBt_unit_1.Source = new BitmapImage(uri);
                            imgBt_unit_1.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_2_over.png", UriKind.Relative);
                            imgBt_unit_2.Source = new BitmapImage(uri);
                            imgBt_unit_2.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_3_over.png", UriKind.Relative);
                            imgBt_unit_3.Source = new BitmapImage(uri);
                            imgBt_unit_3.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_4_over.png", UriKind.Relative);
                            imgBt_unit_4.Source = new BitmapImage(uri);
                            imgBt_unit_4.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_5_over.png", UriKind.Relative);
                            imgBt_unit_5.Source = new BitmapImage(uri);
                            imgBt_unit_5.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_6_over.png", UriKind.Relative);
                            imgBt_unit_6.Source = new BitmapImage(uri);
                            imgBt_unit_6.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_7_over.png", UriKind.Relative);
                            imgBt_unit_7.Source = new BitmapImage(uri);
                            imgBt_unit_7.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_unit_8_over.png", UriKind.Relative);
                            imgBt_unit_8.Source = new BitmapImage(uri);
                            imgBt_unit_8.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_AS":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_AS_over.png", UriKind.Relative);
                            imgBt_AS.Source = new BitmapImage(uri);
                            imgBt_AS.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            Uri uri = new Uri(@"\media\textures\global\Bt_Phonics_over.png", UriKind.Relative);
                            imgBt_Phonics.Source = new BitmapImage(uri);
                            imgBt_Phonics.Stretch = Stretch.Uniform;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
