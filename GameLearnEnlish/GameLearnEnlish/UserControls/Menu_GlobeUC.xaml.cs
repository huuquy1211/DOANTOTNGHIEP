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
    /// Interaction logic for Menu_GlobeUC.xaml
    /// </summary>
    public partial class Menu_GlobeUC : UserControl
    {
        public static Menu_GlobeUC menu_GlobeUC = null;
        public Menu_GlobeUC()
        {
            menu_GlobeUC = this;
            InitializeComponent();
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
                            Uri uri = new Uri(@"\Images\Global\Menu_Globe_U1.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            Uri uri = new Uri(@"\Images\Global\Menu_Globe_U2.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            Uri uri = new Uri(@"\Images\Global\Menu_Globe_U3.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            Uri uri = new Uri(@"\Images\Global\Menu_Globe_U4.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            Uri uri = new Uri(@"\Images\Global\Menu_Globe_U5.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            Uri uri = new Uri(@"\Images\Global\Menu_Globe_U6.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            Uri uri = new Uri(@"\Images\Global\Menu_Globe_U7.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            Uri uri = new Uri(@"\Images\Global\Menu_Globe_U8.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_AS":
                        {
                            Uri uri = new Uri(@"\Images\Global\Menu_Globe_U9.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            Uri uri = new Uri(@"\Images\Global\Menu_Globe_U10.png", UriKind.Relative);
                            imgMenu_Globe_U.Source = new BitmapImage(uri);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
