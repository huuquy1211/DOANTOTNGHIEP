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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLearnEnlish.UserControls
{
    /// <summary>
    /// Interaction logic for ListActiveUC.xaml
    /// </summary>
    public partial class BoxSubMenuUC : UserControl
    {
        public static BoxSubMenuUC boxSubMenuUC = null;

        #region [Âm thanh các lable]
        MediaPlayer mplayer1 = new MediaPlayer();
        MediaPlayer mplayer2 = new MediaPlayer();
        MediaPlayer mplayer3 = new MediaPlayer();
        MediaPlayer mplayer4 = new MediaPlayer();
        MediaPlayer mplayer5 = new MediaPlayer();
        MediaPlayer mplayer6 = new MediaPlayer();
        MediaPlayer mplayer7 = new MediaPlayer(); //Âm thanh cho các nút
        #endregion
        #region [Khởi tạo Uri hình ảnh các Menu_Globe]
        Uri uriImg1;
        Uri uriImg2;
        Uri uriImg3;
        Uri uriImg4;
        Uri uriImg5;
        Uri uriImg6;
        Uri uriImg7;
        Uri uriImg8;
        Uri uriImgAs;
        Uri uriImgPhonics;
        #endregion
        SelectElementUC ButtonSelect;
        public BoxSubMenuUC()
        {
            boxSubMenuUC = this;
            InitializeComponent();

            #region [Âm thanh các unit]
            mplayer1.Open(new Uri(@"..\..\media\audio\global\Activity_1.mp3", UriKind.Relative));
            mplayer2.Open(new Uri(@"..\..\media\audio\global\Activity_2.mp3", UriKind.Relative));
            mplayer3.Open(new Uri(@"..\..\media\audio\global\Activity_3.mp3", UriKind.Relative));
            mplayer4.Open(new Uri(@"..\..\media\audio\global\Activity_4.mp3", UriKind.Relative));
            mplayer5.Open(new Uri(@"..\..\media\audio\global\Activity_5.mp3", UriKind.Relative));
            mplayer6.Open(new Uri(@"..\..\media\audio\global\Activity_6.mp3", UriKind.Relative));
            mplayer7.Open(new Uri(@"..\..\media\audio\global\Activity_9.mp3", UriKind.Relative));
            #endregion

            #region [Hình ảnh các Menu_Globe]
            uriImg1 = new Uri(@"\media\textures\global\Menu_Globe_U1.png", UriKind.Relative);
            uriImg2 = new Uri(@"\media\textures\global\Menu_Globe_U2.png", UriKind.Relative);
            uriImg3 = new Uri(@"\media\textures\global\Menu_Globe_U3.png", UriKind.Relative);
            uriImg4 = new Uri(@"\media\textures\global\Menu_Globe_U4.png", UriKind.Relative);
            uriImg5 = new Uri(@"\media\textures\global\Menu_Globe_U5.png", UriKind.Relative);
            uriImg6 = new Uri(@"\media\textures\global\Menu_Globe_U6.png", UriKind.Relative);
            uriImg7 = new Uri(@"\media\textures\global\Menu_Globe_U7.png", UriKind.Relative);
            uriImg8 = new Uri(@"\media\textures\global\Menu_Globe_U8.png", UriKind.Relative);
            uriImgAs = new Uri(@"\media\textures\global\Menu_Globe_U9.png", UriKind.Relative);
            uriImgPhonics = new Uri(@"\media\textures\global\Menu_Globe_U10.png", UriKind.Relative);
            #endregion

        }

        public void StopVoid()//Tắt âm thanh
        {
            //MenuUC.menuUC.StopVoid();

            //Tắt các âm khi mở menu
            //if (UC_MultipleChoice.uC_MultipleChoice != null)
            //{
            //    UC_MultipleChoice.uC_MultipleChoice.StopVoid();
            //}
            //if (UC_Matching.uC_Matching != null)
            //{
            //    UC_Matching.uC_Matching.StopVoid();
            //}

            if (MenuUC.menuUC != null)
            {
                MenuUC.menuUC.StopVoid();
            }


            mplayer1.Stop();
            mplayer2.Stop();
            mplayer3.Stop();
            mplayer4.Stop();
            mplayer5.Stop();
            mplayer6.Stop();
            mplayer7.Stop();

        }
        public void ChangeUnit(string NameBtn) // Đổi tiêu đề khi nhấn vào từng nút unit ở Menu
        {
            var nameBtn = NameBtn;

            if (nameBtn != "")
            {
                switch (nameBtn)
                {
                    case "imgBt_unit_1":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;//Nút nhấn là unit
                            lblTheme.Content = "My Class";
                            imgMenu_Globe_U.Source = new BitmapImage(uriImg1);//đổi hình ảnh menu globe
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;//Nút nhấn là unit
                            lblTheme.Content = "My Body";

                            imgMenu_Globe_U.Source = new BitmapImage(uriImg2);
                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;//Nút nhấn là unit
                            lblTheme.Content = "My Family";

                            imgMenu_Globe_U.Source = new BitmapImage(uriImg3);
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;//Nút nhấn là unit
                            lblTheme.Content = "My Toys";

                            imgMenu_Globe_U.Source = new BitmapImage(uriImg4);
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;//Nút nhấn là unit
                            lblTheme.Content = "My Lunch";

                            imgMenu_Globe_U.Source = new BitmapImage(uriImg5);
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;//Nút nhấn là unit
                            lblTheme.Content = "My Clothes";

                            imgMenu_Globe_U.Source = new BitmapImage(uriImg6);
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;//Nút nhấn là unit
                            lblTheme.Content = "Animals";

                            imgMenu_Globe_U.Source = new BitmapImage(uriImg7);
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;//Nút nhấn là unit
                            lblTheme.Content = "My World";

                            imgMenu_Globe_U.Source = new BitmapImage(uriImg8);
                            break;
                        }
                    case "imgBt_AS":
                        {
                            ButtonSelect = SelectElementUC._imgBt_AS;//Nút nhấn là As
                            lblTheme.Content = "Animated Stories";
                            lblActivity1.Content = "Unit 1: School Days";
                            lblActivity2.Content = "Unit 2: What Is This?";
                            lblActivity3.Content = "Unit 3: My Family";
                            lblActivity4.Content = "Unit 4: Dolhouse";
                            lblActivity5.Content = "Unit 5: A Suprise";
                            lblActivity6.Content = "Unit 6: Let's Play";
                            lblActivity7.Content = "Unit 7: Where's Lucy?";

                            imgMenu_Globe_U.Source = new BitmapImage(uriImgAs);
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            ButtonSelect = SelectElementUC._imgBt_Phonics;//Nút nhấn là phonics
                            lblTheme.Content = "Phonics";
                            lblActivity1.Content = "Activity 1: Concentration";
                            lblActivity2.Content = "Activity 2: Matching";
                            lblActivity3.Content = "Activity 3: Sorting";
                            lblActivity4.Content = "Activity 4: Look and Find";
                            lblActivity5.Content = "";
                            lblActivity6.Content = "";
                            lblActivity7.Content = "";

                            imgMenu_Globe_U.Source = new BitmapImage(uriImgPhonics);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        private void lblActivity_MouseEnter(object sender, MouseEventArgs e)
        {
            StopVoid();
            var nameTbl = sender as Label;

            if (nameTbl != null)
            {
                switch (nameTbl.Name)
                {
                    case "lblActivity1":
                        {
                            lblActivity1.Foreground = new SolidColorBrush(Colors.Red);//Đổi màu khi rê chuột vào lable
                            mplayer1.Play();//Phat âm lable
                            break;
                        }
                    case "lblActivity2":
                        {
                            lblActivity2.Foreground = new SolidColorBrush(Colors.Red);
                            mplayer2.Play();//Phat âm lable
                            break;
                        }
                    case "lblActivity3":
                        {
                            lblActivity3.Foreground = new SolidColorBrush(Colors.Red);
                            mplayer3.Play();//Phat âm lable
                            break;
                        }
                    case "lblActivity4":
                        {
                            lblActivity4.Foreground = new SolidColorBrush(Colors.Red);
                            mplayer4.Play();//Phat âm lable
                            break;
                        }
                    case "lblActivity5":
                        {
                            lblActivity5.Foreground = new SolidColorBrush(Colors.Red);
                            mplayer5.Play();//Phat âm lable
                            break;
                        }
                    case "lblActivity6":
                        {
                            lblActivity6.Foreground = new SolidColorBrush(Colors.Red);
                            mplayer6.Play();//Phat âm lable
                            break;
                        }
                    case "lblActivity7":
                        {
                            lblActivity7.Foreground = new SolidColorBrush(Colors.Red);
                            mplayer7.Play();//Phat âm lable
                            break;
                        }

                    default:
                        break;
                }
            }
        }
        private void lblActivity_MouseLeave(object sender, MouseEventArgs e)
        {
            StopVoid();
            var nameTbl = sender as Label;

            if (nameTbl != null)
            {
                switch (nameTbl.Name)
                {
                    case "lblActivity1":
                        {
                            lblActivity1.Foreground = new SolidColorBrush(Colors.Black);
                            break;
                        }
                    case "lblActivity2":
                        {
                            lblActivity2.Foreground = new SolidColorBrush(Colors.Black);
                            break;
                        }
                    case "lblActivity3":
                        {
                            lblActivity3.Foreground = new SolidColorBrush(Colors.Black);
                            break;
                        }
                    case "lblActivity4":
                        {
                            lblActivity4.Foreground = new SolidColorBrush(Colors.Black);
                            break;
                        }
                    case "lblActivity5":
                        {
                            lblActivity5.Foreground = new SolidColorBrush(Colors.Black);
                            break;
                        }
                    case "lblActivity6":
                        {
                            lblActivity6.Foreground = new SolidColorBrush(Colors.Black);
                            break;
                        }
                    case "lblActivity7":
                        {
                            lblActivity7.Foreground = new SolidColorBrush(Colors.Black);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        public void CallChangeActivity(string nameTbl, SelectElementUC ButtonIsSelect)
        {
            Global.Instance.WindowMain.grdPlacard.Children.Clear();
            Global.Instance.WindowMain.grdPlacard.Children.Add(new PlacardUC());
            PlacardUC.placardUC.ChangeActivity(nameTbl, ButtonIsSelect);

        }

        public void UnitUCActivity(Unit unit, string Activity)//Gọi các UC activity theo từng Unit khi MouseDown lable
        {
            //Xóa UC cũ
            Global.Instance.WindowMain.grdUC_Activity.Children.Clear();
            switch (Activity)
            {
                case "lblActivity1":
                    {
                        switch (Activity)
                        {
                            case "lblActivity1":
                                {
                                    //Add uc vào main
                                    UC_Concentration UC_Activity = new UC_Concentration(1);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity); //Gọi UC với đối số truyền vào là 1
                                    break;
                                }
                            case "lblActivity2":
                                {
                                    UC_Matching UC_Activity = new UC_Matching(1);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity3":
                                {
                                    //Add uc vào main
                                    UC_Sorting UC_Activity = new UC_Sorting(1);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity4":
                                {
                                    //Add uc vào main
                                    UC_MultipleChoice UC_Activity = new UC_MultipleChoice(1);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity5":
                                {
                                    //Add uc vào main
                                    UC_Painting UC_Activity = new UC_Painting(1);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity6":
                                {
                                    //Add uc vào main
                                    UC_StoryTime UC_Activity = new UC_StoryTime(1);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity7":
                                {
                                    //Add uc vào main
                                    UC_LookAndFind UC_Activity = new UC_LookAndFind(1);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case "lblActivity2":
                    {

                        switch (Activity)
                        {
                            case "lblActivity1":
                                {
                                    //Add uc vào main
                                    UC_Concentration UC_Activity = new UC_Concentration(2);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity); //Gọi UC với đối số truyền vào là 1
                                    break;
                                }
                            case "lblActivity2":
                                {
                                    //Add uc vào main

                                    UC_Matching UC_Activity = new UC_Matching(2);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity3":
                                {
                                    //Add uc vào main
                                    UC_Sorting UC_Activity = new UC_Sorting(2);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity4":
                                {
                                    //Add uc vào main
                                    UC_MultipleChoice UC_Activity = new UC_MultipleChoice(2);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity5":
                                {
                                    //Add uc vào main
                                    UC_Painting UC_Activity = new UC_Painting(2);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity6":
                                {
                                    //Add uc vào main
                                    UC_StoryTime UC_Activity = new UC_StoryTime(2);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity7":
                                {
                                    //Add uc vào main
                                    UC_LookAndFind UC_Activity = new UC_LookAndFind(2);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            default:
                                break;
                        }

                        break;
                    }
                case "lblActivity3":
                    {
                        switch (Activity)
                        {
                            case "lblActivity1":
                                {
                                    //Add uc vào main
                                    UC_Concentration UC_Activity = new UC_Concentration(3);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity); //Gọi UC với đối số truyền vào là 1
                                    break;
                                }
                            case "lblActivity2":
                                {
                                    //Add uc vào main

                                    UC_Matching UC_Activity = new UC_Matching(3);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity3":
                                {
                                    //Add uc vào main
                                    UC_Sorting UC_Activity = new UC_Sorting(3);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity4":
                                {
                                    //Add uc vào main
                                    UC_MultipleChoice UC_Activity = new UC_MultipleChoice(3);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity5":
                                {
                                    //Add uc vào main
                                    UC_Painting UC_Activity = new UC_Painting(3);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity6":
                                {
                                    //Add uc vào main
                                    UC_StoryTime UC_Activity = new UC_StoryTime(3);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity7":
                                {
                                    //Add uc vào main
                                    UC_LookAndFind UC_Activity = new UC_LookAndFind(3);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            default:
                                break;
                        }

                        break;
                    }
                case "lblActivity4":
                    {


                        switch (Activity)
                        {
                            case "lblActivity1":
                                {
                                    //Add uc vào main
                                    UC_Concentration UC_Activity = new UC_Concentration(4);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity); //Gọi UC với đối số truyền vào là 1
                                    break;
                                }
                            case "lblActivity2":
                                {
                                    //Add uc vào main

                                    UC_Matching UC_Activity = new UC_Matching(4);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity3":
                                {
                                    //Add uc vào main
                                    UC_Sorting UC_Activity = new UC_Sorting(4);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity4":
                                {
                                    //Add uc vào main
                                    UC_MultipleChoice UC_Activity = new UC_MultipleChoice(4);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity5":
                                {
                                    //Add uc vào main
                                    UC_Painting UC_Activity = new UC_Painting(4);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity6":
                                {
                                    //Add uc vào main
                                    UC_StoryTime UC_Activity = new UC_StoryTime(4);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity7":
                                {
                                    //Add uc vào main
                                    UC_LookAndFind UC_Activity = new UC_LookAndFind(4);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            default:
                                break;
                        }

                        break;
                    }
                case "lblActivity5":
                    {


                        switch (Activity)
                        {
                            case "lblActivity1":
                                {
                                    //Add uc vào main
                                    UC_Concentration UC_Activity = new UC_Concentration(5);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity); //Gọi UC với đối số truyền vào là 1
                                    break;
                                }
                            case "lblActivity2":
                                {
                                    //Add uc vào main

                                    UC_Matching UC_Activity = new UC_Matching(5);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity3":
                                {
                                    //Add uc vào main
                                    UC_Sorting UC_Activity = new UC_Sorting(5);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity4":
                                {
                                    //Add uc vào main
                                    UC_MultipleChoice UC_Activity = new UC_MultipleChoice(5);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity5":
                                {
                                    //Add uc vào main
                                    UC_Painting UC_Activity = new UC_Painting(5);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity6":
                                {
                                    //Add uc vào main
                                    UC_StoryTime UC_Activity = new UC_StoryTime(5);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                                case "lblActivity7":
                                {
                                    //Add uc vào main
                                    UC_LookAndFind UC_Activity = new UC_LookAndFind(5);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            default:
                                break;
                        }

                        break;
                    }
                case "lblActivity6":
                    {


                        switch (Activity)
                        {
                            case "lblActivity1":
                                {
                                    //Add uc vào main
                                    UC_Concentration UC_Activity = new UC_Concentration(6);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity); //Gọi UC với đối số truyền vào là 1
                                    break;
                                }
                            case "lblActivity2":
                                {
                                    //Add uc vào main

                                    UC_Matching UC_Activity = new UC_Matching(6);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity3":
                                {
                                    //Add uc vào main
                                    UC_Sorting UC_Activity = new UC_Sorting(6);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity4":
                                {
                                    //Add uc vào main
                                    UC_MultipleChoice UC_Activity = new UC_MultipleChoice(6);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity5":
                                {
                                    //Add uc vào main
                                    UC_Painting UC_Activity = new UC_Painting(6);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity6":
                                {
                                    //Add uc vào main
                                    UC_StoryTime UC_Activity = new UC_StoryTime(6);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity7":
                                {
                                    //Add uc vào main
                                    UC_LookAndFind UC_Activity = new UC_LookAndFind(6);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            default:
                                break;
                        }

                        break;
                    }
                case "lblActivity7":
                    {


                        switch (Activity)
                        {
                            case "lblActivity1":
                                {
                                    //Add uc vào main
                                    UC_Concentration UC_Activity = new UC_Concentration(7);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity); //Gọi UC với đối số truyền vào là 1
                                    break;
                                }
                            case "lblActivity2":
                                {
                                    //Add uc vào main

                                    UC_Matching UC_Activity = new UC_Matching(7);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity3":
                                {
                                    //Add uc vào main
                                    UC_Sorting UC_Activity = new UC_Sorting(7);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity4":
                                {
                                    //Add uc vào main
                                    UC_MultipleChoice UC_Activity = new UC_MultipleChoice(7);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity5":
                                {
                                    //Add uc vào main
                                    UC_Painting UC_Activity = new UC_Painting(7);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity6":
                                {
                                    //Add uc vào main
                                    UC_StoryTime UC_Activity = new UC_StoryTime(7);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity7":
                                {
                                    //Add uc vào main
                                    UC_LookAndFind UC_Activity = new UC_LookAndFind(7);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            default:
                                break;
                        }

                        break;
                    }
                case "lblActivity8":
                    {


                        switch (Activity)
                        {
                            case "lblActivity1":
                                {
                                    //Add uc vào main
                                    UC_Concentration UC_Activity = new UC_Concentration(8);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity); //Gọi UC với đối số truyền vào là 1
                                    break;
                                }
                            case "lblActivity2":
                                {
                                    //Add uc vào main

                                    UC_Matching UC_Activity = new UC_Matching(8);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity3":
                                {
                                    //Add uc vào main
                                    UC_Sorting UC_Activity = new UC_Sorting(8);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity4":
                                {
                                    //Add uc vào main
                                    UC_MultipleChoice UC_Activity = new UC_MultipleChoice(8);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity5":
                                {
                                    //Add uc vào main
                                    UC_Painting UC_Activity = new UC_Painting(8);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity6":
                                {
                                    //Add uc vào main
                                    UC_StoryTime UC_Activity = new UC_StoryTime(8);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            case "lblActivity7":
                                {
                                    //Add uc vào main
                                    UC_LookAndFind UC_Activity = new UC_LookAndFind(8);
                                    Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                                    break;
                                }
                            default:
                                break;
                        }

                        break;
                    }
                case "lblActivity9":
                    {
                        //Add uc vào main
                        UC_LookAndFind UC_Activity = new UC_LookAndFind((int)unit);
                        Global.Instance.WindowMain.grdUC_Activity.Children.Add(UC_Activity);
                        break;
                    }
                default:
                    break;
            }
        }
        private void lblActivity_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var nameTbl = sender as Label;

            if (nameTbl != null)
            {
                if (ButtonSelect == SelectElementUC._Bt_unit)//Nếu nút nhấn là Unit
                {

                    switch (nameTbl.Name)
                    {
                        case "lblActivity1":
                            {
                                Global.Instance.indexSelectActivity = 1;//Set index chọn lable activity
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                
                                break;
                            }
                        case "lblActivity2":
                            {
                                Global.Instance.indexSelectActivity = 2;//Set index chọn lable activity
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity3":
                            {
                                Global.Instance.indexSelectActivity = 3;//Set index chọn lable activity
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity4":
                            {
                                Global.Instance.indexSelectActivity = 4;//Set index chọn lable activity
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity5":
                            {
                                Global.Instance.indexSelectActivity = 5;//Set index chọn lable activity
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity6":
                            {
                                Global.Instance.indexSelectActivity = 6;//Set index chọn lable activity
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity7":
                            {
                                Global.Instance.indexSelectActivity = 7;//Set index chọn lable activity
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        default:
                            break;
                    }
                }
                else if (ButtonSelect == SelectElementUC._imgBt_AS)//Nếu nút nhấn là AS
                {
                    switch (nameTbl.Name)
                    {
                        case "lblActivity1":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity2":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity3":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity4":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity5":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity6":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity7":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity8":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        default:
                            break;
                    }
                }

                else if (ButtonSelect == SelectElementUC._imgBt_Phonics)//Nếu nút nhấn là Phonics
                {
                    switch (nameTbl.Name)
                    {
                        case "lblActivity1":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity2":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity3":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        case "lblActivity4":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);// Đổi placard theo unit 
                                UnitUCActivity(Global.Instance.UnitSelect, nameTbl.Name);//Gọi các UC activity của từng Unit
                                break;
                            }
                        default:
                            break;
                    }
                }

            }
        }
    }
}