using BLL;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLearnEnlish.UserControls
{
    /// <summary>
    /// Interaction logic for UC_LookAndFind.xaml
    /// </summary>
    /// 
    public partial class UC_LookAndFind : UserControl
    {
        public static UC_LookAndFind uC_LookAndFind = null;
        private int Unit = 1;
        private int CountAnswer = 0;//Số câu hỏi

        private List<Data.LookAndFind> lstWord = new List<Data.LookAndFind>();

        private readonly string VoidCorrect = @"..\..\media\audio\global\right.mp3";//âm khi chọn đúng
        private MediaPlayer mediaPlayerVoidCorrect = new MediaPlayer();//Âm thanh câu trả lời đúng
        private MediaPlayer mediaPlayerVoiceDescription = new MediaPlayer();//Khởi tạo âm Description


        private readonly string VoiceTitle = @"..\..\media\audio\lookandfind\title.mp3";//âm thanh title
        private MediaPlayer mediaPlayerVoidStart = new MediaPlayer();//Khởi tạo //âm thanh title


        private string TextDescription = "Look and find. Click on each chair you see.";//Nội dung Description


        private string VoiceDescription = @"..\..\media\audio\lookandfind\act1\description.mp3";//âm description

        private List<string> ListUriImgObj;//danh sách hình ảnh cần tìm
        private string UriImgCover;//danh sách hình ảnh cover


        private DropShadowBitmapEffect myDropShadowEffect;//Bóng đổ
        private Color myShadowColor; // Màu bóng đổ



        public UC_LookAndFind(int unit)
        {
            uC_LookAndFind = this;
            InitializeComponent();
            Unit = unit;
            CreateListImg(Unit);//Khởi tạo hình ảnh activity
            SetDropShadowEffect(); //Tạo bóng đỏ cho hình

            try
            {
                //Phat âm thanh title
                mediaPlayerVoidStart.Open(new Uri(VoiceTitle, UriKind.Relative));//Âm thanh title
                mediaPlayerVoidStart.Stop();
                mediaPlayerVoidStart.Play();
                //Gọi UC Description
                Global.Instance.WindowMain.grdUC_Description.Children.Clear();
                Global.Instance.WindowMain.grdUC_Description.Children.Add(new UC_Description());
                UC_Description.uC_Description.CallTextDescription(TextDescription);

                //Âm thanh Description
                mediaPlayerVoiceDescription.Open(new Uri(VoiceDescription, UriKind.Relative));
                mediaPlayerVoiceDescription.Stop();
                NotEnableQuestionAndAnswer();//Ẩn các hình ảnh khi phát âm
                Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    this.Dispatcher.Invoke(() =>
                    {
                        //Phát âm thanh Description
                        mediaPlayerVoiceDescription.Play();
                    });
                }).ContinueWith((task) =>
                {
                    Thread.Sleep(5000);
                    FinishStartApp(); //Khởi động xong
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Không thao tác khi đang khởi động
        public void NotEnableQuestionAndAnswer()
        {
            this.Dispatcher.Invoke(() =>
            {
                this.Cursor = Cursors.No;
                imgObj1.IsEnabled = false;
                imgObj2.IsEnabled = false;
                imgObj3.IsEnabled = false;

            });

        }
        // khởi động xong //Hiện các câu trả lời và câu hỏi
        public void FinishStartApp()
        {
            this.Dispatcher.Invoke(() =>
            {
                this.Cursor = Cursors.Arrow;
                imgObj1.IsEnabled = true;
                imgObj2.IsEnabled = true;
                imgObj3.IsEnabled = true;

            });
        }

        //Tắt âm thanh
        public void StopVoid()//Tắt âm thanh
        {
            mediaPlayerVoidCorrect.Stop();
            mediaPlayerVoiceDescription.Stop();
            mediaPlayerVoidStart.Stop();
        }

        //Tạo bóng đỏ cho hình
        private void SetDropShadowEffect()
        {
            myDropShadowEffect = new DropShadowBitmapEffect();
            // Set the color of the shadow to Black.
            myShadowColor = new Color();
            myShadowColor.ScA = 1;
            myShadowColor.ScB = 5;
            myShadowColor.ScG = 5;
            myShadowColor.ScR = 5;
            myDropShadowEffect.Color = myShadowColor;

            // Set the direction of where the shadow is cast to 320 degrees.
            myDropShadowEffect.Direction = 0;

            // Set the depth of the shadow being cast.
            myDropShadowEffect.ShadowDepth = 5;

            // Set the shadow softness to the maximum (range of 0-1).
            myDropShadowEffect.Softness = 10;
            // Set the shadow opacity to half opaque or in other words - half transparent.
            // The range is 0-1.
            myDropShadowEffect.Opacity = 0.5;
        }
        private void CreateListImg(int Unit)
        {
            try
            {
                lstWord = new LookAndFindBLL().GetLookAndFinds(Unit);
                //Âm thanh Description
                VoiceDescription = @"..\..\media\audio\lookandfind\act"+ Unit + @"\description.mp3";//âm description

                //Hình cover
                UriImgCover = @"..\..\media\textures\lookandfind\act" + Unit + @"\cover.png";

                //Hình ảnh chọn
                //ListUriImgObj = new List<string>() {
                //@"..\..\media\textures\lookandfind\act"+ Unit + @"\obj1.png",
                //@"..\..\media\textures\lookandfind\act"+ Unit + @"\obj2.png",
                //@"..\..\media\textures\lookandfind\act"+ Unit + @"\obj3.png"};

                ListUriImgObj = new List<string>() { lstWord[0].Image, lstWord[1].Image, lstWord[2].Image };

                imgCover.Source = new BitmapImage(new Uri(UriImgCover, UriKind.Relative));
                imgObj1.Source = new BitmapImage(new Uri(ListUriImgObj[0], UriKind.Relative));
                imgObj2.Source = new BitmapImage(new Uri(ListUriImgObj[1], UriKind.Relative));
                imgObj3.Source = new BitmapImage(new Uri(ListUriImgObj[2], UriKind.Relative));

                //Vị trí của hình cần tìm
                switch (Unit)
                {
                    case 1:
                        {
                            //Text title
                            TextDescription = "Look and fine. Click on each chair you see";
                            //Set tọa độ hình 
                            Canvas.SetLeft(imgObj1, 290.0);
                            Canvas.SetTop(imgObj1, 60.0);


                            Canvas.SetLeft(imgObj2, 600.0);
                            Canvas.SetTop(imgObj2, 305.0);

                            Canvas.SetLeft(imgObj3, 100.0);
                            Canvas.SetTop(imgObj3, 320.0);

                            break;
                        }
                    case 2:
                        {
                            //Text title
                            TextDescription = "Look and fine. Click on each bee you see";
                            //Set tọa độ hình 
                            Canvas.SetLeft(imgObj1, 650.0);
                            Canvas.SetTop(imgObj1, 20.0);

                            Canvas.SetLeft(imgObj2, 250.0);
                            Canvas.SetTop(imgObj2, 160.0);

                            Canvas.SetLeft(imgObj3, 120.0);
                            Canvas.SetTop(imgObj3, 340.0);
                            break;
                        }
                    case 3:
                        {
                            //Text title
                            TextDescription = "Look and fine. Click on each blue crayon you see";
                            //Set tọa độ hình 
                            Canvas.SetLeft(imgObj1, 450.0);
                            Canvas.SetTop(imgObj1, 250.0);

                            Canvas.SetLeft(imgObj2, 240.0);
                            Canvas.SetTop(imgObj2, 85.0);

                            Canvas.SetLeft(imgObj3, 130.0);
                            Canvas.SetTop(imgObj3, 230.0);
                            break;
                        }
                    case 4:
                        {
                            //Text title
                            TextDescription = "Look and fine. Click on each butterfly you see";
                            //Set tọa độ hình 
                            Canvas.SetLeft(imgObj1, 450.0);
                            Canvas.SetTop(imgObj1, 250.0);

                            Canvas.SetLeft(imgObj2, 240.0);
                            Canvas.SetTop(imgObj2, 85.0);

                            Canvas.SetLeft(imgObj3, 130.0);
                            Canvas.SetTop(imgObj3, 230.0);
                            break;
                        }
                    case 5:
                        {
                            //Text title
                            TextDescription = "Look and fine. Click on each red rectangle you see";
                            //Set tọa độ hình 
                            Canvas.SetLeft(imgObj1, 650.0);
                            Canvas.SetTop(imgObj1, 155.0);

                            Canvas.SetLeft(imgObj2, 450.0);
                            Canvas.SetTop(imgObj2, 320.0);

                            Canvas.SetLeft(imgObj3, 120.0);
                            Canvas.SetTop(imgObj3, 120.0);
                            break;
                        }
                    case 6:
                        {
                            //Text title
                            TextDescription = "Look and fine. Click on each toy car you see";

                            //Set tọa độ hình 
                            Canvas.SetLeft(imgObj1, 370.0);
                            Canvas.SetTop(imgObj1, 200.0);

                            Canvas.SetLeft(imgObj2, 160.0);
                            Canvas.SetTop(imgObj2, 400.0);

                            Canvas.SetLeft(imgObj3, 86.0);
                            Canvas.SetTop(imgObj3, 170.0);
                            break;
                        }
                    case 7:
                        {
                            //Text title
                            TextDescription = "Look and fine. Click on each white bird you see";

                            //Set tọa độ hình 
                            Canvas.SetLeft(imgObj1, 620.0);
                            Canvas.SetTop(imgObj1, 40.0);

                            Canvas.SetLeft(imgObj2, 300.0);
                            Canvas.SetTop(imgObj2, 80.0);

                            Canvas.SetLeft(imgObj3, 270.0);
                            Canvas.SetTop(imgObj3, 180.0);
                            break;
                        }
                    case 8:
                        {
                            //Text title
                            TextDescription = "Look and fine. Click on each cat you see";
                            //Set tọa độ hình 
                            Canvas.SetLeft(imgObj1, 420.0);
                            Canvas.SetTop(imgObj1, 200.0);

                            Canvas.SetLeft(imgObj2, 240.0);
                            Canvas.SetTop(imgObj2, 125.0);

                            Canvas.SetLeft(imgObj3, 100.0);
                            Canvas.SetTop(imgObj3, 280.0);
                            break;
                        }

                    default:
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        #region [Xử lý khi nhấn vào hình cần tìm]
        private void imgObj1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                imgObj1.IsEnabled = false;
                StopVoid();//Tắt âm thanh
                mediaPlayerVoidCorrect.Open(new Uri(VoidCorrect, UriKind.Relative));
                mediaPlayerVoidCorrect.Play();//Phát âm trả lời đúng
                imgObj1.BitmapEffect = myDropShadowEffect;//Dổ bóng khi chọn đúng
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void imgObj2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                imgObj2.IsEnabled = false;
                StopVoid();//Tắt âm thanh
                mediaPlayerVoidCorrect.Open(new Uri(VoidCorrect, UriKind.Relative));
                mediaPlayerVoidCorrect.Play();//Phát âm trả lời đúng
                imgObj2.BitmapEffect = myDropShadowEffect;//Dổ bóng khi chọn đúng
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void imgObj3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                imgObj3.IsEnabled = false;
                StopVoid();//Tắt âm thanh
                mediaPlayerVoidCorrect.Open(new Uri(VoidCorrect, UriKind.Relative));
                mediaPlayerVoidCorrect.Play();//Phát âm trả lời đúng
                imgObj3.BitmapEffect = myDropShadowEffect;//Đổ bóng khi chọn đúng
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

    }
}
