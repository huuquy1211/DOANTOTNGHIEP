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
    /// Interaction logic for MenuUC.xaml
    /// </summary>
    public partial class MenuUC : UserControl
    {
        public MenuUC()
        {
            InitializeComponent();
        }

        private void imgBt_unit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var nameBtn = sender as Image;

            if (nameBtn != null)
            {
                switch (nameBtn.Name)
                {
                    case "imgBt_unit_1":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_1_over.png", UriKind.Relative);
                            imgBt_unit_1.Source = new BitmapImage(uri);
                            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(nameBtn.Name);
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_2_over.png", UriKind.Relative);
                            imgBt_unit_2.Source = new BitmapImage(uri);
                            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(nameBtn.Name);
                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_3_over.png", UriKind.Relative);
                            imgBt_unit_3.Source = new BitmapImage(uri);
                            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(nameBtn.Name);
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_4_over.png", UriKind.Relative);
                            imgBt_unit_4.Source = new BitmapImage(uri);
                            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(nameBtn.Name);
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_5_over.png", UriKind.Relative);
                            imgBt_unit_5.Source = new BitmapImage(uri);
                            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(nameBtn.Name);
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_6_over.png", UriKind.Relative);
                            imgBt_unit_6.Source = new BitmapImage(uri);
                            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(nameBtn.Name);
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_7_over.png", UriKind.Relative);
                            imgBt_unit_7.Source = new BitmapImage(uri);
                            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(nameBtn.Name);
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_8_over.png", UriKind.Relative);
                            imgBt_unit_8.Source = new BitmapImage(uri);
                            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(nameBtn.Name);
                            break;
                        }
                    case "imgBt_AS":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_AS_over.png", UriKind.Relative);
                            imgBt_AS.Source = new BitmapImage(uri);
                            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(nameBtn.Name);
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_Phonics_over.png", UriKind.Relative);
                            imgBt_Phonics.Source = new BitmapImage(uri);
                            Menu_GlobeUC.menu_GlobeUC.ChangeUnit(nameBtn.Name);
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
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_1.png", UriKind.Relative);
                            imgBt_unit_1.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_2.png", UriKind.Relative);
                            imgBt_unit_2.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_3.png", UriKind.Relative);
                            imgBt_unit_3.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_4.png", UriKind.Relative);
                            imgBt_unit_4.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_5.png", UriKind.Relative);
                            imgBt_unit_5.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_6.png", UriKind.Relative);
                            imgBt_unit_6.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_7.png", UriKind.Relative);
                            imgBt_unit_7.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_8.png", UriKind.Relative);
                            imgBt_unit_8.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_AS":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_AS.png", UriKind.Relative);
                            imgBt_AS.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_Phonics.png", UriKind.Relative);
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
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_1.png", UriKind.Relative);
                            imgBt_unit_1.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_2.png", UriKind.Relative);
                            imgBt_unit_2.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_3.png", UriKind.Relative);
                            imgBt_unit_3.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_4.png", UriKind.Relative);
                            imgBt_unit_4.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_5.png", UriKind.Relative);
                            imgBt_unit_5.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_6.png", UriKind.Relative);
                            imgBt_unit_6.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_7.png", UriKind.Relative);
                            imgBt_unit_7.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_8.png", UriKind.Relative);
                            imgBt_unit_8.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_AS":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_AS.png", UriKind.Relative);
                            imgBt_AS.Source = new BitmapImage(uri);
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_Phonics.png", UriKind.Relative);
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
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_1_over.png", UriKind.Relative);
                            imgBt_unit_1.Source = new BitmapImage(uri);
                            imgBt_unit_1.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_2":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_2_over.png", UriKind.Relative);
                            imgBt_unit_2.Source = new BitmapImage(uri);
                            imgBt_unit_2.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_3":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_3_over.png", UriKind.Relative);
                            imgBt_unit_3.Source = new BitmapImage(uri);
                            imgBt_unit_3.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_4":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_4_over.png", UriKind.Relative);
                            imgBt_unit_4.Source = new BitmapImage(uri);
                            imgBt_unit_4.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_5":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_5_over.png", UriKind.Relative);
                            imgBt_unit_5.Source = new BitmapImage(uri);
                            imgBt_unit_5.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_6":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_6_over.png", UriKind.Relative);
                            imgBt_unit_6.Source = new BitmapImage(uri);
                            imgBt_unit_6.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_7":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_7_over.png", UriKind.Relative);
                            imgBt_unit_7.Source = new BitmapImage(uri);
                            imgBt_unit_7.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_unit_8":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_unit_8_over.png", UriKind.Relative);
                            imgBt_unit_8.Source = new BitmapImage(uri);
                            imgBt_unit_8.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_AS":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_AS_over.png", UriKind.Relative);
                            imgBt_AS.Source = new BitmapImage(uri);
                            imgBt_AS.Stretch = Stretch.Uniform;
                            break;
                        }
                    case "imgBt_Phonics":
                        {
                            Uri uri = new Uri(@"\Images\Global\Bt_Phonics_over.png", UriKind.Relative);
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
