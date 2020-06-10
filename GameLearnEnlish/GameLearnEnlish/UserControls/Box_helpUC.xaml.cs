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
    /// Interaction logic for Box_helpUC.xaml
    /// </summary>
    public partial class Box_helpUC : UserControl
    {
        public static Box_helpUC box_HelpUC = null;
        public Box_helpUC()
        {
            box_HelpUC = this;
            InitializeComponent();
            ChangeVideoActivity();
        }

        private void imgBt_help_close_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri uri = new Uri(@"\media\textures\global\Bt_help_close_over.png", UriKind.Relative);
            imgBt_help_close.Source = new BitmapImage(uri);
        }

        private void imgBt_help_close_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri uri = new Uri(@"\media\textures\global\Bt_help_close.png", UriKind.Relative);
            imgBt_help_close.Source = new BitmapImage(uri);
        }

        private void imgBt_help_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Global.Instance.WindowMain.grdBox_helpUC.Children.Remove(this);
        }

        public void ChangeVideoActivity()
        {
            switch (Global.Instance.ActivitySelect)
            {
                case SelectElementUC._activity1:
                    {
                        VideoHelp.Source = new Uri(@"..\..\media\video\1_Concentration.flv", UriKind.Relative);
                        VideoHelp.MediaEnded += VideoHelp_MediaEnded;
                        break;
                    }
                case SelectElementUC._activity2:
                    {
                        VideoHelp.Source = new Uri(@"..\..\media\video\2_Matching.flv", UriKind.Relative);
                        VideoHelp.MediaEnded += VideoHelp_MediaEnded;
                        break;
                    }
                case SelectElementUC._activity3:
                    {
                        VideoHelp.Source = new Uri(@"..\..\media\video\7_Sequence.flv", UriKind.Relative);
                        VideoHelp.MediaEnded += VideoHelp_MediaEnded;
                        break;
                    }
                case SelectElementUC._activity4:
                    {
                        VideoHelp.Source = new Uri(@"..\..\media\video\4_Multiple_choice.flv", UriKind.Relative);
                        VideoHelp.MediaEnded += VideoHelp_MediaEnded;
                        break;
                    }
                case SelectElementUC._activity5:
                    {
                        VideoHelp.Source = new Uri(@"..\..\media\video\5_Painting.flv", UriKind.Relative);
                        VideoHelp.MediaEnded += VideoHelp_MediaEnded;
                        break;
                    }
                case SelectElementUC._activity6:
                    {
                        VideoHelp.Source = new Uri(@"..\..\media\video\6_Story_time.flv", UriKind.Relative);
                        VideoHelp.MediaEnded += VideoHelp_MediaEnded;
                        break;
                    }
                case SelectElementUC._activity7:
                    {
                        VideoHelp.Source = new Uri(@"..\..\media\video\9_Look_find.flv", UriKind.Relative);
                        VideoHelp.MediaEnded += VideoHelp_MediaEnded;
                        break;
                    }

                default:
                    break;
            }
        }

        private void VideoHelp_MediaEnded(object sender, EventArgs e)
        {
            Global.Instance.WindowMain.grdBox_helpUC.Children.Clear();
        }
    }
}
