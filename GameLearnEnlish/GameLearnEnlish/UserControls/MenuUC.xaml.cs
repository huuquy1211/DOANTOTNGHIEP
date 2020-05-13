using GameLearnEnlish.Model;
using GameLearnEnlish.Utility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

        #region [Khởi tạo âm thanh các unit]
        private MediaPlayer mplayer1 = new MediaPlayer();
        private MediaPlayer mplayer2 = new MediaPlayer();
        private MediaPlayer mplayer3 = new MediaPlayer();
        private MediaPlayer mplayer4 = new MediaPlayer();
        private MediaPlayer mplayer5 = new MediaPlayer();
        private MediaPlayer mplayer6 = new MediaPlayer();
        private MediaPlayer mplayer7 = new MediaPlayer();
        private MediaPlayer mplayer8 = new MediaPlayer();
        private MediaPlayer mplayerAs = new MediaPlayer();

        private MediaPlayer mplayerPhonics = new MediaPlayer(); //Âm thanh cho các nút
        #endregion

        #region [Khởi tạo Uri hình ảnh các unit]
        private Uri uriImg1;
        private Uri uriImg2;
        private Uri uriImg3;
        private Uri uriImg4;
        private Uri uriImg5;
        private Uri uriImg6;
        private Uri uriImg7;
        private Uri uriImg8;
        private Uri uriImgAs;
        private Uri uriImgPhonics;
        #endregion

        public MenuUC()
        {
            menuUC = this;
            InitializeComponent();
            StopVoid();//Tắt âm thanh
            #region [Âm thanh các unit]
            mplayer1.Open(new Uri(@"..\..\media\audio\global\BigF1_cdau_menu_U01.mp3", UriKind.Relative));
            mplayer2.Open(new Uri(@"..\..\media\audio\global\BigF1_cdau_menu_U02.mp3", UriKind.Relative));
            mplayer3.Open(new Uri(@"..\..\media\audio\global\BigF1_cdau_menu_U03.mp3", UriKind.Relative));
            mplayer4.Open(new Uri(@"..\..\media\audio\global\BigF1_cdau_menu_U04.mp3", UriKind.Relative));
            mplayer5.Open(new Uri(@"..\..\media\audio\global\BigF1_cdau_menu_U05.mp3", UriKind.Relative));
            mplayer6.Open(new Uri(@"..\..\media\audio\global\BigF1_cdau_menu_U06.mp3", UriKind.Relative));
            mplayer7.Open(new Uri(@"..\..\media\audio\global\BigF1_cdau_menu_U07.mp3", UriKind.Relative));
            mplayer8.Open(new Uri(@"..\..\media\audio\global\BigF1_cdau_menu_U08.mp3", UriKind.Relative));
            mplayerAs.Open(new Uri(@"..\..\media\audio\global\BigF1_cdau_menu_U10.mp3", UriKind.Relative));
            mplayerPhonics.Open(new Uri(@"..\..\media\audio\global\BigF1_cdau_menu_U09.mp3", UriKind.Relative));
            #endregion

            #region [Hình ảnh các unit]
            uriImg1 = new Uri(@"\media\textures\global\Bt_unit_1_over.png", UriKind.Relative);
            uriImg2 = new Uri(@"\media\textures\global\Bt_unit_2_over.png", UriKind.Relative);
            uriImg3 = new Uri(@"\media\textures\global\Bt_unit_3_over.png", UriKind.Relative);
            uriImg4 = new Uri(@"\media\textures\global\Bt_unit_4_over.png", UriKind.Relative);
            uriImg5 = new Uri(@"\media\textures\global\Bt_unit_5_over.png", UriKind.Relative);
            uriImg6 = new Uri(@"\media\textures\global\Bt_unit_6_over.png", UriKind.Relative);
            uriImg7 = new Uri(@"\media\textures\global\Bt_unit_7_over.png", UriKind.Relative);
            uriImg8 = new Uri(@"\media\textures\global\Bt_unit_8_over.png", UriKind.Relative);
            uriImgAs = new Uri(@"\media\textures\global\Bt_unit_10_over.png", UriKind.Relative);
            uriImgPhonics = new Uri(@"\media\textures\global\Bt_unit_9_over.png", UriKind.Relative);
            #endregion
        }

        public void StopVoid()//Tắt âm thanh
        {
            ////Tắt các âm khi mở menu
            //if (UC_MultipleChoice.uC_MultipleChoice != null)
            //{
            //    UC_MultipleChoice.uC_MultipleChoice.StopVoid();
            //}
            //if (UC_Matching.uC_Matching != null)
            //{
            //    UC_Matching.uC_Matching.StopVoid();
            //}
            //if (UC_Description.uC_Description != null)
            //{
            //    UC_Description.uC_Description.StopVoid();
            //}
            mplayer1.Stop();
            mplayer2.Stop();
            mplayer3.Stop();
            mplayer4.Stop();
            mplayer5.Stop();
            mplayer6.Stop();
            mplayer7.Stop();
            mplayer8.Stop();
            mplayerAs.Stop();
            mplayerPhonics.Stop();
        }
        private void CallChangeUnit(string NameBtnImage)//Đổi unit bên menu_globe và các activity bên boxsub
        {
            Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Clear();
            Global.Instance.WindowMain.grdMenu_GlobeUC.Children.Add(new Menu_GlobeUC());
            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(NameBtnImage);//Đổi unit cho menu_globe

            Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Clear();
            Global.Instance.WindowMain.grdBoxSubMenuUC.Children.Add(new BoxSubMenuUC());
            BoxSubMenuUC.boxSubMenuUC.ChangeUnit(NameBtnImage);//Đổi các lable activity cho boxsubmenu
        }

        public void IsVisibleButtonClick(string NameButton) //Hiện nút khi được click
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
                        CallChangeUnit(NameButton);//Đổi Unit
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
            StopVoid();//Tắt âm thanh tất cả các unit trước khi nhấn vào
            var nameBtn = sender as Image;
            
            if (nameBtn != null)
            {
                switch (nameBtn.Name)
                {
                    case "imgBt_unit_1":
                        {
                            imgBt_unit_1.Source = new BitmapImage(uriImg1);//Hiển thị hình ảnh over
                            IsVisibleButtonClick(nameBtn.Name);//Hiện nút khi được nhấn
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_1;//Nút trên menu được click là nút nào
                            Global.Instance.UnitSelect = Unit._unit1;//Unit nào được chọn
                            mplayer1.Play();//Phát âm thanh của unit

                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            imgBt_unit_2.Source = new BitmapImage(uriImg2);//Hiển thị hình ảnh over
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_2;//Nút trên menu được click là nút nào
                            Global.Instance.UnitSelect = Unit._unit2;//Unit nào được chọn
                            mplayer2.Play();//Phát âm thanh của unit

                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            imgBt_unit_3.Source = new BitmapImage(uriImg3);//Hiển thị hình ảnh over
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_3;//Nút trên menu được click là nút nào
                            Global.Instance.UnitSelect = Unit._unit3;//Unit nào được chọn

                            mplayer3.Play();//Phát âm thanh của unit
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            imgBt_unit_4.Source = new BitmapImage(uriImg4);//Hiển thị hình ảnh over
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_4;//Nút trên menu được click là nút nào
                            Global.Instance.UnitSelect = Unit._unit4;//Unit nào được chọn

                            mplayer4.Play();//Phát âm thanh của unit
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            imgBt_unit_5.Source = new BitmapImage(uriImg5);//Hiển thị hình ảnh over
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_5;//Nút trên menu được click là nút nào
                            Global.Instance.UnitSelect = Unit._unit5;//Unit nào được chọn

                            mplayer5.Play();//Phát âm thanh của unit
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            imgBt_unit_6.Source = new BitmapImage(uriImg6);//Hiển thị hình ảnh over
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_6;//Nút trên menu được click là nút nào
                            Global.Instance.UnitSelect = Unit._unit6;//Unit nào được chọn

                            mplayer6.Play();//Phát âm thanh của unit
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            imgBt_unit_7.Source = new BitmapImage(uriImg7);//Hiển thị hình ảnh over
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_7;//Nút trên menu được click là nút nào
                            Global.Instance.UnitSelect = Unit._unit7;//Unit nào được chọn

                            mplayer7.Play();//Phát âm thanh của unit
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            imgBt_unit_8.Source = new BitmapImage(uriImg8);//Hiển thị hình ảnh over
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_unit_8;//Nút trên menu được click là nút nào
                            Global.Instance.UnitSelect = Unit._unit8;//Unit nào được chọn

                            mplayer8.Play();//Phát âm thanh của unit
                            break;
                        }
                    case "imgBt_AS":
                        {
                            imgBt_AS.Source = new BitmapImage(uriImgAs);//Hiển thị hình ảnh over
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_AS;//Nút trên menu được click là nút nào
                            Global.Instance.UnitSelect = Unit._AS;//Unit nào được chọn

                            mplayerAs.Play();//Phát âm thanh của unit
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            imgBt_Phonics_click.Source = new BitmapImage(uriImgPhonics);//Hiển thị hình ảnh over
                            IsVisibleButtonClick(nameBtn.Name);
                            Global.Instance.ButtonMenuSelect = SelectElementUC._imgBt_Phonics;//Nút trên menu được click là nút nào
                            Global.Instance.UnitSelect = Unit._Phonics;//Unit nào được chọn

                            mplayerPhonics.Play();//Phát âm thanh của unit
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
