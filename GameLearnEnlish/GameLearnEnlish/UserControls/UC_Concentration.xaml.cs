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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLearnEnlish.UserControls
{
    /// <summary>
    /// Interaction logic for UC_Concentration.xaml
    /// </summary>
    public partial class UC_Concentration : UserControl
    {
        private int Unit = 1;//Unit

        private readonly string VoidCorrect = @"..\..\media\audio\concentration\correct.mp3";//âm khi chọn 2 thẻ giống giau
        private readonly string VoidInCorrect = @"..\..\media\audio\concentration\wrong.mp3";//âm khi chọn 2 thẻ khác nhau

        private readonly string LinkImgCloseCard = @"..\..\media\textures\concentration\card_back.png";
        private List<string> ListImgWord = new List<string>();//danh sách hình ảnh của từ
        private List<int> ListImgSort = new List<int>();//vị trí của 3 bức ảnh.
        private List<string> ListVoidWord;//danh sách âm thanh của từ

        private bool[] hasOpened; // false: hình đang úp, true: hình đang mở
        private bool isOpen; // đang thực chạy hiệu ứng lật hình
        public int numImageClick;//vị trí hình vừa chọn

        private int ImgClick_1 = 0;//vị trí hình chọn thứ 1
        private int ImgClick_2 = 0;//vị trí hình chọn thứ 2


        private Storyboard myStoryboard1 = new Storyboard();
        private Storyboard myStoryboard2 = new Storyboard();
        private Storyboard myStoryboard3 = new Storyboard();
        private Storyboard myStoryboard4 = new Storyboard();
        private Storyboard myStoryboard5 = new Storyboard();
        private Storyboard myStoryboard6 = new Storyboard();
        private Storyboard myStoryboard7 = new Storyboard();
        private Storyboard myStoryboard8 = new Storyboard();
        private Storyboard myStoryboard9 = new Storyboard();
        private Storyboard myStoryboard10 = new Storyboard();
        private Storyboard myStoryboard11 = new Storyboard();
        private Storyboard myStoryboard12 = new Storyboard();

        private MediaPlayer mediaPlayerVoid1 = new MediaPlayer();
        private MediaPlayer mediaPlayerVoid2 = new MediaPlayer();
        private MediaPlayer mediaPlayerVoid3 = new MediaPlayer();

        private MediaPlayer mediaPlayerVoidCorrect = new MediaPlayer();
        private MediaPlayer mediaPlayerVoiInCorrect = new MediaPlayer();

        private MediaPlayer mediaTitle = new MediaPlayer();
        private MediaPlayer mediaDescription = new MediaPlayer();

        private int Score;

        public UC_Concentration(int unit)
        {
            Unit = unit;
            mediaTitle.Open(new Uri(@"..\..\media\audio\concentration\title.mp3", UriKind.Relative));
            mediaTitle.MediaEnded += MediaTitle_MediaEnded;

            mediaDescription.Open(new Uri(@"..\..\media\audio\concentration\description.mp3", UriKind.Relative));
            mediaDescription.MediaEnded += MediaDescription_MediaEnded;


            InitializeComponent();

            mediaTitle.Play();

            CreateListImg(unit);


            #region thêm storyboard lật hình và sự kiện mouseDown theo Unit truyền vào
            ThuNho(myStoryboard1, "MyImage1", Unit);
            PhongTo(myStoryboard2, "MyImage1", Unit);
            ThuNho(myStoryboard3, "MyImage2", Unit);
            PhongTo(myStoryboard4, "MyImage2", Unit);
            ThuNho(myStoryboard5, "MyImage3", Unit);
            PhongTo(myStoryboard6, "MyImage3", Unit);
            ThuNho(myStoryboard7, "MyImage4", Unit);
            PhongTo(myStoryboard8, "MyImage4", Unit);
            ThuNho(myStoryboard9, "MyImage5", Unit);
            PhongTo(myStoryboard10, "MyImage5", Unit);
            ThuNho(myStoryboard11, "MyImage6", Unit);
            PhongTo(myStoryboard12, "MyImage6", Unit);

            MyImage1.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            MyImage2.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            MyImage3.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            MyImage4.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            MyImage5.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            MyImage6.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            #endregion

        }
        private void MediaDescription_MediaEnded(object sender, EventArgs e)
        {
            Main.IsEnabled = true;
            Main.Opacity = 1;
        }

        private void MediaTitle_MediaEnded(object sender, EventArgs e)
        {
            mediaTitle.Stop();
            mediaDescription.Play();
        }

        //Khởi tạo vị trí các bức hình
        public void CreateListImg(int Unit)
        {
            Score = 0;
            ListImgWord.Clear();
            ListImgSort.Clear();
            hasOpened = new bool[6] { false, false, false, false, false, false };
            isOpen = false;

            #region media
            ListVoidWord = new List<string>()
        {@"..\..\media\audio\concentration\act"+Unit+@"\sound1.mp3",
         @"..\..\media\audio\concentration\act"+Unit+@"\sound2.mp3",
         @"..\..\media\audio\concentration\act"+Unit+@"\sound3.mp3"};
            mediaPlayerVoid1.Open(new Uri(ListVoidWord[0], UriKind.Relative));
            mediaPlayerVoid2.Open(new Uri(ListVoidWord[1], UriKind.Relative));
            mediaPlayerVoid3.Open(new Uri(ListVoidWord[2], UriKind.Relative));
            mediaPlayerVoidCorrect.Open(new Uri(VoidCorrect, UriKind.Relative));
            mediaPlayerVoiInCorrect.Open(new Uri(VoidInCorrect, UriKind.Relative));
            #endregion

            string pathLinkImg = @"..\..\media\textures\matching\act" + Unit;
            Random rd = new Random();
            int[] num = new int[3] { 0, 0, 0 };
            int rand = 0;
            for (int i = 1; i <= 6; i++)
            {
                bool temp = false;
                while (temp == false)
                {
                    rand = (rd.Next(1, 1000) % 3) + 1;
                    if (rand <= 3 && rand >= 1)
                    {
                        if (num[rand - 1] < 2)
                        {
                            ListImgWord.Add(pathLinkImg + @"\img" + rand + ".png");
                            ListImgSort.Add(rand);
                            num[rand - 1]++;
                            temp = true;
                        }
                    }
                }
            }
        }
        public void PlayMp3(int i)
        {
            switch (i)
            {
                case 1:
                    mediaPlayerVoid1.Play();
                    break;
                case 2:
                    mediaPlayerVoid2.Play();
                    break;
                case 3:
                    mediaPlayerVoid3.Play();
                    break;
                case 4:
                    mediaPlayerVoidCorrect.Play();
                    break;
                case 5:
                    mediaPlayerVoiInCorrect.Play();
                    break;
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isOpen == false)
            {
                #region stop media
                mediaPlayerVoid1.Stop();
                mediaPlayerVoid2.Stop();
                mediaPlayerVoid3.Stop();
                mediaPlayerVoidCorrect.Stop();
                mediaPlayerVoiInCorrect.Stop();
                #endregion

                //lấy vị trí hình ảnh vừa chọn
                numImageClick = int.Parse(((Border)sender).Name[7].ToString());
                isOpen = true;//gán cờ đang xử lý sự kiện lật ảnh, không nhận thêm sự kiện lật ảnh khác khi chưa kết thúc
                if (numImageClick >= 1 && numImageClick <= 6)
                {
                    //gán vị trí hình ảnh cho 1 trong 2 hình ảnh dùng để so sánh
                    if (ImgClick_1 == 0)
                    {
                        ImgClick_1 = numImageClick;
                    }
                    else
                    {
                        ImgClick_2 = numImageClick;
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi rồi nha, lo sửa đi!!!");
                    return;
                }
                switch (numImageClick)
                {
                    case 1:
                        {
                            myStoryboard1.Begin(this);
                            break;
                        }

                    case 2:
                        {
                            myStoryboard3.Begin(this);
                            break;
                        }
                    case 3:
                        {
                            myStoryboard5.Begin(this);
                            break;
                        }
                    case 4:
                        {
                            myStoryboard7.Begin(this);
                            break;
                        }
                    case 5:
                        {
                            myStoryboard9.Begin(this);
                            break;
                        }
                    case 6:
                        {
                            myStoryboard11.Begin(this);
                            break;
                        }
                }
            }
        }


        public void ThuNho(Storyboard storyBoard, string name, int num)
        {
            var myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 200;
            myDoubleAnimation.To = 0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            myDoubleAnimation.AutoReverse = false;

            storyBoard.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            storyBoard.Children.Add(myDoubleAnimation);

            Storyboard.SetTargetName(myDoubleAnimation, name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));

            storyBoard.Completed += new EventHandler(StoryBoard_1_Completed);
        }
        public void PhongTo(Storyboard storyBoard, string name, int num)
        {
            var myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0;
            myDoubleAnimation.To = 200;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            myDoubleAnimation.AutoReverse = false;

            storyBoard.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            storyBoard.Children.Add(myDoubleAnimation);

            Storyboard.SetTargetName(myDoubleAnimation, name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
            storyBoard.Completed += new EventHandler(StoryBoard_2_Completed);
        }

        public void StoryBoard_1_Completed(object sender, EventArgs e)
        {
            switch (numImageClick)
            {
                case 1:
                    {
                        if (hasOpened[numImageClick - 1] == false)
                        {
                            Image1.Source = new BitmapImage(new Uri(ListImgWord[0], UriKind.Relative));
                            PlayMp3(ListImgSort[numImageClick - 1]);
                        }
                        else
                        {
                            Image1.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                        }
                        myStoryboard2.Begin(this);
                    }
                    break;
                case 2:
                    {
                        if (hasOpened[numImageClick - 1] == false)
                        {
                            Image2.Source = new BitmapImage(new Uri(ListImgWord[1], UriKind.Relative));
                            PlayMp3(ListImgSort[numImageClick - 1]);
                        }
                        else
                        {
                            Image2.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                        }
                        myStoryboard4.Begin(this);
                    }
                    break;
                case 3:
                    {
                        if (hasOpened[numImageClick - 1] == false)
                        {
                            Image3.Source = new BitmapImage(new Uri(ListImgWord[2], UriKind.Relative));
                            PlayMp3(ListImgSort[numImageClick - 1]);
                        }
                        else
                        {
                            Image3.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                        }
                        myStoryboard6.Begin(this);
                    }
                    break;
                case 4:
                    {
                        if (hasOpened[numImageClick - 1] == false)
                        {
                            Image4.Source = new BitmapImage(new Uri(ListImgWord[3], UriKind.Relative));
                            PlayMp3(ListImgSort[numImageClick - 1]);
                        }
                        else
                        {
                            Image4.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                        }
                        myStoryboard8.Begin(this);
                    }
                    break;
                case 5:
                    {
                        if (hasOpened[numImageClick - 1] == false)
                        {
                            Image5.Source = new BitmapImage(new Uri(ListImgWord[4], UriKind.Relative));
                            PlayMp3(ListImgSort[numImageClick - 1]);
                        }
                        else
                        {
                            Image5.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                        }
                        myStoryboard10.Begin(this);
                    }
                    break;
                case 6:
                    {
                        if (hasOpened[numImageClick - 1] == false)
                        {
                            Image6.Source = new BitmapImage(new Uri(ListImgWord[5], UriKind.Relative));
                            PlayMp3(ListImgSort[numImageClick - 1]);
                        }
                        else
                        {
                            Image6.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                        }
                        myStoryboard12.Begin(this);
                    }
                    break;
            }

            //phát âm thanh của hình ảnh vừa chọn
            // PlayMp3(ListImgSort[numImageClick - 1]);

        }

        public void StoryBoard_2_Completed(object sender, EventArgs e)
        {
            if (isOpen == true)
            {
                isOpen = false;
            }
            else
            {
                isOpen = true;
            }

            if (hasOpened[numImageClick - 1] == true)
            {
                hasOpened[numImageClick - 1] = false;
            }
            else
            {
                hasOpened[numImageClick - 1] = true;
            }

            if (ImgClick_1 != 0 && ImgClick_2 != 0)
            {
                if (CheckImg() == 1)
                {
                    PlayMp3(4);//phát âm báo chính xác
                    //ẩn 2 hình đi
                    switch (ImgClick_1)
                    {
                        case 1:
                            {
                                GridImg1.Visibility = Visibility.Hidden;
                            }
                            break;
                        case 2:
                            {
                                GridImg2.Visibility = Visibility.Hidden;
                            }
                            break;
                        case 3:
                            {
                                GridImg3.Visibility = Visibility.Hidden;
                            }
                            break;
                        case 4:
                            {
                                GridImg4.Visibility = Visibility.Hidden;
                            }
                            break;
                        case 5:
                            {
                                GridImg5.Visibility = Visibility.Hidden;
                            }
                            break;
                        case 6:
                            {
                                GridImg6.Visibility = Visibility.Hidden;
                            }
                            break;
                    }
                    switch (ImgClick_2)
                    {
                        case 1:
                            {
                                GridImg1.Visibility = Visibility.Hidden;
                            }
                            break;
                        case 2:
                            {
                                GridImg2.Visibility = Visibility.Hidden;
                            }
                            break;
                        case 3:
                            {
                                GridImg3.Visibility = Visibility.Hidden;
                            }
                            break;
                        case 4:
                            {
                                GridImg4.Visibility = Visibility.Hidden;
                            }
                            break;
                        case 5:
                            {
                                GridImg5.Visibility = Visibility.Hidden;
                            }
                            break;
                        case 6:
                            {
                                GridImg6.Visibility = Visibility.Hidden;
                            }
                            break;
                    }
                    Score++;
                    if (Score == 3)
                    {
                        Thread.Sleep(1000);
                        //phát âm thanh hoàn thành action

                        Score = 0;
                    }
                }
                else
                if (CheckImg() == 0)
                {
                    PlayMp3(5);//phát âm báo không chính xác
                    //úp 2 hình lại
                    Thread.Sleep(1000);
                    switch (ImgClick_1)
                    {
                        case 1:
                            {
                                Image1.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                        case 2:
                            {
                                Image2.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                        case 3:
                            {
                                Image3.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                        case 4:
                            {
                                Image4.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                        case 5:
                            {
                                Image5.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                        case 6:
                            {
                                Image6.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                    }
                    switch (ImgClick_2)
                    {
                        case 1:
                            {
                                Image1.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                        case 2:
                            {
                                Image2.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                        case 3:
                            {
                                Image3.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                        case 4:
                            {
                                Image4.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                        case 5:
                            {
                                Image5.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                        case 6:
                            {
                                Image6.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                    }
                }
                else
                {
                    switch (ImgClick_1)
                    {
                        case 1:
                            {
                                Image1.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                        case 2:
                            {
                                Image2.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                        case 3:
                            {
                                Image3.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                        case 4:
                            {
                                Image4.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                        case 5:
                            {
                                Image5.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                        case 6:
                            {
                                Image6.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_1 - 1] = false;
                            }
                            break;
                    }
                    switch (ImgClick_2)
                    {
                        case 1:
                            {
                                Image1.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                        case 2:
                            {
                                Image2.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                        case 3:
                            {
                                Image3.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                        case 4:
                            {
                                Image4.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                        case 5:
                            {
                                Image5.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                        case 6:
                            {
                                Image6.Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                                hasOpened[ImgClick_2 - 1] = false;
                            }
                            break;
                    }
                }
                ImgClick_1 = 0;
                ImgClick_2 = 0;
            }
        }

        public int CheckImg()
        {
            if (ImgClick_1 == ImgClick_2)
            {
                ImgClick_1 = 0;
                ImgClick_2 = 0;
                return 2;
            }
            if (ListImgSort[ImgClick_1 - 1] == ListImgSort[ImgClick_2 - 1])
                return 1;
            else
                return 0;
        }
    }
}
