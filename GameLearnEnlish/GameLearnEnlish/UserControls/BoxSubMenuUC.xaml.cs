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
       

        SelectElementUC ButtonSelect;
        public BoxSubMenuUC()
        {
            boxSubMenuUC = this;
            InitializeComponent();
            AnimationBoxSubMenuUC();
        }

        private void AnimationBoxSubMenuUC()
        {
            //Storyboard storyboard = new Storyboard();
            //DoubleAnimation doubleAnimation = new DoubleAnimation();
            //doubleAnimation.From = 0;
            //doubleAnimation.To = 1;
            //doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            //storyboard.Children.Add(doubleAnimation);
            //Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Grid.OpacityProperty));
            //Storyboard.SetTargetName(doubleAnimation, grdBox_sub_menu.Name);
            //storyboard.Begin(this);
        }
        public void ChangeUnit(string NameBtn)
        {
            var nameBtn = NameBtn;

            if (nameBtn != "")
            {
                switch (nameBtn)
                {
                    case "imgBt_unit_1":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;
                            lblTheme.Content = "My Class";
                            Uri uri = new Uri(@"\media\textures\global\Menu_Globe_U1.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;
                            lblTheme.Content = "My Body";
                            Uri uri = new Uri(@"\media\textures\global\Menu_Globe_U2.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;
                            lblTheme.Content = "My Family";
                            Uri uri = new Uri(@"\media\textures\global\Menu_Globe_U3.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;
                            lblTheme.Content = "My Toys";
                            Uri uri = new Uri(@"\media\textures\global\Menu_Globe_U4.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;
                            lblTheme.Content = "My Lunch";
                            Uri uri = new Uri(@"\media\textures\global\Menu_Globe_U5.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;
                            lblTheme.Content = "My Clothes";
                            Uri uri = new Uri(@"\media\textures\global\Menu_Globe_U6.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;
                            lblTheme.Content = "Animals";
                            Uri uri = new Uri(@"\media\textures\global\Menu_Globe_U7.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            ButtonSelect = SelectElementUC._Bt_unit;
                            lblTheme.Content = "My World";
                            Uri uri = new Uri(@"\media\textures\global\Menu_Globe_U8.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_AS":
                        {
                            ButtonSelect = SelectElementUC._imgBt_AS;
                            lblTheme.Content = "Animated Stories";
                            lblActivity1.Content = "Unit 1: School Days";
                            lblActivity2.Content = "Unit 2: What Is This?";
                            lblActivity3.Content = "Unit 3: My Family";
                            lblActivity4.Content = "Unit 4: Dolhouse";
                            lblActivity5.Content = "Unit 5: A Suprise";
                            lblActivity6.Content = "Unit 6: Let's Play";
                            lblActivity7.Content = "Unit 7: Where's Lucy?";
                            lblActivity8.Content = "Unit 8: Hospital";
                            lblActivity9.Content = "";
                            Uri uri = new Uri(@"\media\textures\global\Menu_Globe_U9.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            ButtonSelect = SelectElementUC._imgBt_Phonics;
                            lblTheme.Content = "Phonics";
                            lblActivity1.Content = "Activity 1: Concentration";
                            lblActivity2.Content = "Activity 2: Matching";
                            lblActivity3.Content = "Activity 3: Sorting";
                            lblActivity4.Content = "Activity 4: Look and Find";
                            lblActivity5.Content = "";
                            lblActivity6.Content = "";
                            lblActivity7.Content = "";
                            lblActivity8.Content = "";
                            lblActivity9.Content = "";
                            Uri uri = new Uri(@"\media\textures\global\Menu_Globe_U10.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        private void lblActivity_MouseEnter(object sender, MouseEventArgs e)
        {
            var nameTbl = sender as Label;

            if (nameTbl != null)
            {
                switch (nameTbl.Name)
                {
                    case "lblActivity1":
                        {
                            lblActivity1.Foreground = new SolidColorBrush(Colors.Red);
                            break;
                        }
                    case "lblActivity2":
                        {
                            lblActivity2.Foreground = new SolidColorBrush(Colors.Red);
                            break;
                        }
                    case "lblActivity3":
                        {
                            lblActivity3.Foreground = new SolidColorBrush(Colors.Red);
                            break;
                        }
                    case "lblActivity4":
                        {
                            lblActivity4.Foreground = new SolidColorBrush(Colors.Red);
                            break;
                        }
                    case "lblActivity5":
                        {
                            lblActivity5.Foreground = new SolidColorBrush(Colors.Red);
                            break;
                        }
                    case "lblActivity6":
                        {
                            lblActivity6.Foreground = new SolidColorBrush(Colors.Red);
                            break;
                        }
                    case "lblActivity7":
                        {
                            lblActivity7.Foreground = new SolidColorBrush(Colors.Red);
                            break;
                        }
                    case "lblActivity8":
                        {
                            lblActivity8.Foreground = new SolidColorBrush(Colors.Red);
                            break;
                        }
                    case "lblActivity9":
                        {
                            lblActivity9.Foreground = new SolidColorBrush(Colors.Red);
                            break;
                        }


                    default:
                        break;
                }
            }
        }
        private void lblActivity_MouseLeave(object sender, MouseEventArgs e)
        {
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
                    case "lblActivity8":
                        {
                            lblActivity8.Foreground = new SolidColorBrush(Colors.Black);
                            break;
                        }
                    case "lblActivity9":
                        {
                            lblActivity9.Foreground = new SolidColorBrush(Colors.Black);
                            break;
                        }


                    default:
                        break;
                }
            }
        }

        private void CallChangeActivity(string nameTbl, SelectElementUC ButtonIsSelect)
        {
            Global.Instance.WindowMain.grdPlacard.Children.Clear();
            Global.Instance.WindowMain.grdPlacard.Children.Add(new PlacardUC());
            PlacardUC.placardUC.ChangeActivity(nameTbl, ButtonIsSelect);
            
        }
        private void lblActivity_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var nameTbl = sender as Label;

            if (nameTbl != null)
            {
                if (ButtonSelect == SelectElementUC._Bt_unit)
                {
                    switch (nameTbl.Name)
                    {
                        case "lblActivity1":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity2":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity3":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity4":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity5":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity6":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity7":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity8":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity9":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }


                        default:
                            break;
                    }
                }
                else if (ButtonSelect == SelectElementUC._imgBt_AS)
                {
                    switch (nameTbl.Name)
                    {
                        case "lblActivity1":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity2":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity3":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity4":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity5":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity6":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity7":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity8":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        default:
                            break;
                    }
                }
                else if (ButtonSelect == SelectElementUC._imgBt_Phonics)
                {
                    switch (nameTbl.Name)
                    {
                        case "lblActivity1":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity2":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity3":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
                                break;
                            }
                        case "lblActivity4":
                            {
                                CallChangeActivity(nameTbl.Name, ButtonSelect);
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
