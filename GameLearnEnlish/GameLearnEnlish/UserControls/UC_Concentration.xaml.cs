using BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private readonly string VoiceCorrect = @"..\..\media\audio\concentration\correct.mp3";//âm khi chọn 2 thẻ giống giau
        private readonly string VoiceInCorrect = @"..\..\media\audio\concentration\wrong.mp3";//âm khi chọn 2 thẻ khác nhau
        private readonly string LinkImgCloseCard = @"..\..\media\textures\concentration\card_back.png";

        private List<Data.Word> lstWord = new List<Data.Word>();

        private List<string> ListImgWord = new List<string>();//danh sách hình ảnh của từ
        private List<int> ListImgSort = new List<int>();//vị trí của 3 bức ảnh.
        private List<string> ListVoiceWord;//danh sách âm thanh của từ

        private bool[] hasOpened; // false: hình đang úp, true: hình đang mở
        private bool isOpen; // đang thực chạy hiệu ứng lật hình
        public int numImageClick;//vị trí hình vừa chọn

        private int ImgClick_1 = 0;//vị trí hình chọn thứ 1
        private int ImgClick_2 = 0;//vị trí hình chọn thứ 2

        #region 
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

        private Storyboard storyboardHidden1 = new Storyboard();
        private Storyboard storyboardHidden2 = new Storyboard();
        private Storyboard storyboardHidden3 = new Storyboard();
        private Storyboard storyboardHidden4 = new Storyboard();
        private Storyboard storyboardHidden5 = new Storyboard();
        private Storyboard storyboardHidden6 = new Storyboard();

        private MediaPlayer mediaPlayerVoid1 = new MediaPlayer();
        private MediaPlayer mediaPlayerVoid2 = new MediaPlayer();
        private MediaPlayer mediaPlayerVoid3 = new MediaPlayer();

        private MediaPlayer mediaPlayerVoiceCorrect = new MediaPlayer();
        private MediaPlayer mediaPlayerVoiceInCorrect = new MediaPlayer();

        private MediaPlayer mediaTitle = new MediaPlayer();
        private MediaPlayer mediaDescription = new MediaPlayer();

        private MediaPlayer mediaVotay = new MediaPlayer();

        private int Score = 0;
        #endregion



        public UC_Concentration(int unit)
        {
            Unit = unit;

            mediaTitle.Open(new Uri(@"..\..\media\audio\concentration\title.mp3", UriKind.Relative));
            mediaTitle.MediaEnded += MediaTitle_MediaEnded;

            mediaDescription.Open(new Uri(@"..\..\media\audio\concentration\description.mp3", UriKind.Relative));
            mediaDescription.MediaEnded += MediaDescription_MediaEnded;

            InitializeComponent();
            mediaTitle.Play();
            CreateImgAndVoice(Unit);
            AddStoryboard();

        }

        public void Init()
        {

        }
        public void AddStoryboard()
        {
            #region {thêm storyboard lật hình và sự kiện mouseDown}
            ThuNho(myStoryboard1, "MyImage1");
            PhongTo(myStoryboard2, "MyImage1");
            ThuNho(myStoryboard3, "MyImage2");
            PhongTo(myStoryboard4, "MyImage2");
            ThuNho(myStoryboard5, "MyImage3");
            PhongTo(myStoryboard6, "MyImage3");
            ThuNho(myStoryboard7, "MyImage4");
            PhongTo(myStoryboard8, "MyImage4");
            ThuNho(myStoryboard9, "MyImage5");
            PhongTo(myStoryboard10, "MyImage5");
            ThuNho(myStoryboard11, "MyImage6");
            PhongTo(myStoryboard12, "MyImage6");

            HiddenImage(storyboardHidden1, "MyImage1");
            HiddenImage(storyboardHidden2, "MyImage2");
            HiddenImage(storyboardHidden3, "MyImage3");
            HiddenImage(storyboardHidden4, "MyImage4");
            HiddenImage(storyboardHidden5, "MyImage5");
            HiddenImage(storyboardHidden6, "MyImage6");


            MyImage1.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            MyImage2.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            MyImage3.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            MyImage4.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            MyImage5.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            MyImage6.MouseDown += new MouseButtonEventHandler(Image_MouseDown);
            #endregion
        }
        // sự kiện khi phát hết âm thanh tiêu đề
        private void MediaTitle_MediaEnded(object sender, EventArgs e)
        {
            mediaTitle.Stop();
            mediaDescription.Play();
        }
        // sự kiện khi phát hết âm thanh mô tả activity
        private void MediaDescription_MediaEnded(object sender, EventArgs e)
        {
            Main.IsEnabled = true;
            Main.Opacity = 1;
        }

        //Khởi tạo vị trí các bức hình và file âm thanh
        public void CreateImgAndVoice(int Unit)
        {
            Score = 0;
            ListImgWord.Clear();
            ListImgSort.Clear();
            hasOpened = new bool[6] { false, false, false, false, false, false };
            isOpen = false;

            lstWord = new WordBLL().GetWordsOfUnit(Unit);

            #region media
            //ListVoiceWord = new List<string>()
            //    {@"..\..\media\audio\concentration\act"+Unit+@"\sound1.mp3",
            //     @"..\..\media\audio\concentration\act"+Unit+@"\sound2.mp3",
            //     @"..\..\media\audio\concentration\act"+Unit+@"\sound3.mp3"};

            ListVoiceWord = new List<string>() { lstWord[0].Voice, lstWord[1].Voice, lstWord[2].Voice };



            mediaPlayerVoid1.Open(new Uri(ListVoiceWord[0], UriKind.Relative));
            mediaPlayerVoid2.Open(new Uri(ListVoiceWord[1], UriKind.Relative));
            mediaPlayerVoid3.Open(new Uri(ListVoiceWord[2], UriKind.Relative));
            mediaPlayerVoiceCorrect.Open(new Uri(VoiceCorrect, UriKind.Relative));
            mediaPlayerVoiceInCorrect.Open(new Uri(VoiceInCorrect, UriKind.Relative));

            mediaVotay.Open(new Uri(@"..\..\media\audio\tiengvotay.mp3", UriKind.Relative));
            mediaVotay.MediaEnded += MediaVotay_MediaEnded;
            #endregion

            string pathLinkImg = @"..\..\media\textures\concentration\act" + Unit;
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
                            ListImgWord.Add(lstWord[rand-1].Image);
                            ListImgSort.Add(rand);
                            num[rand - 1]++;
                            temp = true;
                        }
                    }
                }
            }
        }
        private void MediaVotay_MediaEnded(object sender, EventArgs e)
        {
            mediaVotay.Stop();
        }
        public void PlayVoice(int i)
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
                    mediaPlayerVoiceCorrect.Play();
                    break;
                case 5:
                    mediaPlayerVoiceInCorrect.Play();
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
                mediaPlayerVoiceCorrect.Stop();
                mediaPlayerVoiceInCorrect.Stop();
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
                BeginStoryBoard1(numImageClick);
            }
        }

        public void BeginStoryBoard1(int index)
        {
            switch (index)
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
        public void BeginStoryboard2(int index)
        {
            switch (index)
            {
                case 1:
                    {
                        myStoryboard2.Begin(this);
                    }
                    break;
                case 2:
                    {
                        myStoryboard4.Begin(this);
                    }
                    break;
                case 3:
                    {
                        myStoryboard6.Begin(this);
                    }
                    break;
                case 4:
                    {
                        myStoryboard8.Begin(this);
                    }
                    break;
                case 5:
                    {
                        myStoryboard10.Begin(this);
                    }
                    break;
                case 6:
                    {
                        myStoryboard12.Begin(this);
                    }
                    break;
            }
        }

        #region {Khởi tạo story board}
        //tạo sb làm ẩn hình ảnh khi chọn đúng 2 hình giống nhau
        public void HiddenImage(Storyboard storyBoard, string name)
        {
            var myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1;
            myDoubleAnimation.To = 0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            myDoubleAnimation.AutoReverse = false;

            storyBoard.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            storyBoard.Children.Add(myDoubleAnimation);

            Storyboard.SetTargetName(myDoubleAnimation, name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));

            storyBoard.Completed += StoryBoard_Completed; //sau khi hình bị ẩn đi thì ẩn luôn cả gif ánh sáng.
        }
        public void ThuNho(Storyboard storyBoard, string name)
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
        public void PhongTo(Storyboard storyBoard, string name)
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
        #endregion

        private void StoryBoard_Completed(object sender, EventArgs e)
        {
            Gif1.Visibility = Visibility.Hidden;
            Gif2.Visibility = Visibility.Hidden;
            Gif3.Visibility = Visibility.Hidden;
            Gif4.Visibility = Visibility.Hidden;
            Gif5.Visibility = Visibility.Hidden;
            Gif6.Visibility = Visibility.Hidden;

            if (Score == 3)
            {
                //ẩn main, hiện gif vỗ tay, phát âm thanh hoàn thành action
                Main.Visibility = Visibility.Hidden;
                Votay.Visibility = Visibility.Visible;
                mediaVotay.Play();

                Score = 0;
            }
        }
        //thu nhỏ hình 
        public void StoryBoard_1_Completed(object sender, EventArgs e)
        {
            if (hasOpened[numImageClick - 1] == false)
            {
                ChangeImageSource(GetImageByIndex(numImageClick), ListImgWord[numImageClick - 1]);
                PlayVoice(ListImgSort[numImageClick - 1]);
            }
            else
            {
                GetImageByIndex(numImageClick).Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
            }
            BeginStoryboard2(numImageClick);
        }
        //Lật hình xong thì kiểm tra đáp án
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
                    ShowGifCorrect(ImgClick_1);
                    ShowGifCorrect(ImgClick_2);

                    PlayVoice(4);//phát âm báo chính xác
                    //ẩn 2 hình đi
                    VisibleImageCorrect(ImgClick_1, ImgClick_2);
                    Score++;
                }
                else
                if (CheckImg() == 0)
                {
                    PlayVoice(5);//phát âm báo không chính xác
                    //úp 2 hình lại
                    Thread.Sleep(1000);
                    GetImageByIndex(ImgClick_1).Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                    hasOpened[ImgClick_1 - 1] = false;

                    GetImageByIndex(ImgClick_2).Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                    hasOpened[ImgClick_2 - 1] = false;
                }
                else
                {
                    GetImageByIndex(ImgClick_1).Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                    hasOpened[ImgClick_1 - 1] = false;
                    GetImageByIndex(ImgClick_2).Source = new BitmapImage(new Uri(LinkImgCloseCard, UriKind.Relative));
                    hasOpened[ImgClick_2 - 1] = false;
                }
                ImgClick_1 = 0;
                ImgClick_2 = 0;
            }
        }
        //ẩn 2 hình ảnh giống nhau
        public void VisibleImageCorrect(int index1, int index2)
        {
            GetStoryboardHiddenCardByIndexImage(index1).Begin(this);
            GetStoryboardHiddenCardByIndexImage(index2).Begin(this);
        }
        public void ShowGifCorrect(int index)
        {
            switch (index)
            {
                case 1:
                    {
                        Gif1.Visibility = Visibility.Visible;
                    }
                    break;
                case 2:
                    {
                        Gif2.Visibility = Visibility.Visible;
                    }
                    break;
                case 3:
                    {
                        Gif3.Visibility = Visibility.Visible;
                    }
                    break;
                case 4:
                    {
                        Gif4.Visibility = Visibility.Visible;
                    }
                    break;
                case 5:
                    {
                        Gif5.Visibility = Visibility.Visible;
                    }
                    break;
                case 6:
                    {
                        Gif6.Visibility = Visibility.Visible;
                    }
                    break;
            }
        }

        public void ChangeImageSource(Image img, string path)
        {
            img.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }


        public Storyboard GetStoryboardHiddenCardByIndexImage(int index)
        {
            switch (index)
            {
                case 1:
                    {
                        return storyboardHidden1;
                    }
                case 2:
                    {
                        return storyboardHidden2;
                    }
                case 3:
                    {
                        return storyboardHidden3;
                    }
                case 4:
                    {
                        return storyboardHidden4;
                    }
                case 5:
                    {
                        return storyboardHidden5;
                    }
                case 6:
                    {
                        return storyboardHidden6;
                    }
                default:
                    return null;
            }
        }
        public Image GetImageByIndex(int index)
        {
            switch (index)
            {
                case 1:
                    {
                        return Image1;
                    }
                case 2:
                    {
                        return Image2;
                    }
                case 3:
                    {
                        return Image3;
                    }
                case 4:
                    {
                        return Image4;
                    }
                case 5:
                    {
                        return Image5;
                    }
                case 6:
                    {
                        return Image6;
                    }
                default:
                    return null;
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
