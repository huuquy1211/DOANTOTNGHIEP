using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for UC_Sorting.xaml
    /// </summary>
    public partial class UC_Sorting : UserControl, INotifyPropertyChanged
    {
        private int Unit = 1;

        string Path = @"..\..\media";

        const int left = 25;
        private Point BasePoint1 = new Point(2 * left, 5 * left);
        private Point BasePoint2 = new Point(10 * left, 5 * left);
        private Point BasePoint3 = new Point(18 * left, 5 * left);

        private Point BaseImage1 = new Point(2 * left, 5 * left);
        private Point BaseImage2 = new Point(10 * left, 5 * left);
        private Point BaseImage3 = new Point(18 * left, 5 * left);

        private double DeltaX1 = 0.0;
        private double DeltaY1 = 0.0;
        private double DeltaX2 = 0.0;
        private double DeltaY2 = 0.0;
        private double DeltaX3 = 0.0;
        private double DeltaY3 = 0.0;

        private bool moving = false;
        private Point PositionImage;


        private List<string> ListImgWord = new List<string>();//danh sách hình ảnh của từ
        private List<int> ListImgSort = new List<int>();//vị trí của 3 bức ảnh để xếp vào box.
        private List<string> ListVoid = new List<string>();//danh sách âm thanh của từ

        private MediaPlayer mediaTitle = new MediaPlayer();
        private MediaPlayer mediaDescription = new MediaPlayer();

        private MediaPlayer mediaCorrect = new MediaPlayer();
        private MediaPlayer mediaInCorrect = new MediaPlayer();
        private MediaPlayer mediaVoid1 = new MediaPlayer();
        private MediaPlayer mediaVoid2 = new MediaPlayer();
        private MediaPlayer mediaVoid3 = new MediaPlayer();

        private MediaPlayer mediaVotay = new MediaPlayer();

        private Storyboard storyboardVisible1 = new Storyboard();
        private Storyboard storyboardVisible2 = new Storyboard();
        private Storyboard storyboardVisible3 = new Storyboard();
        private int score = 0;

        public int Left
        {
            get { return left; }
        }
        public double XPosition1
        {
            get { return BasePoint1.X + DeltaX1; }
        }
        public double YPosition1
        {
            get { return BasePoint1.Y + DeltaY1; }
        }
        public double XPosition2
        {
            get { return BasePoint2.X + DeltaX2; }
        }
        public double YPosition2
        {
            get { return BasePoint2.Y + DeltaY2; }
        }
        public double XPosition3
        {
            get { return BasePoint3.X + DeltaX3; }
        }
        public double YPosition3
        {
            get { return BasePoint3.Y + DeltaY3; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public UC_Sorting(int unit)
        {
            Unit = unit;
            mediaTitle.Open(new Uri(@"..\..\media\audio\sorting\title.mp3", UriKind.Relative));
            mediaTitle.MediaEnded += MediaTitle_MediaEnded;

            mediaDescription.Open(new Uri(@"..\..\media\audio\sequence\description.mp3", UriKind.Relative));
            mediaDescription.MediaEnded += MediaDescription_MediaEnded;


            InitializeComponent();

            mediaTitle.Play();
            Create();
            this.DataContext = this;
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


        public void Create()
        {
            Random rd = new Random();
            while (ListImgSort.Count < 3)
            {
                int i = rd.Next(1, 1000) % 3 + 1;
                if (ListImgSort.Count == 0)
                {
                    ListImgSort.Add(i);
                }
                else
                {
                    if (ListImgSort.Exists(x => x == i) == false)
                    {
                        ListImgSort.Add(i);
                    }
                }
            }

            //set image
            for (int i = 0; i < 3; i++)
            {
                if (ListImgSort[i] == 1)
                {
                    ListImgWord.Add(Path + @"\textures\sequence\act" + Unit + @"\img" + 1 + @".png");
                    ListVoid.Add(Path + @"\audio\sequence\act" + Unit + @"\sound" + 1 + @".mp3");
                }
                if (ListImgSort[i] == 2)
                {
                    ListImgWord.Add(Path + @"\textures\sequence\act" + Unit + @"\img" + 2 + @".png");
                    ListVoid.Add(Path + @"\audio\sequence\act" + Unit + @"\sound" + 2 + @".mp3");
                }
                if (ListImgSort[i] == 3)
                {
                    ListImgWord.Add(Path + @"\textures\sequence\act" + Unit + @"\img" + 3 + @".png");
                    ListVoid.Add(Path + @"\audio\sequence\act" + Unit + @"\sound" + 3 + @".mp3");
                }
            }
            //khởi tạo âm thanh
            mediaCorrect.Open(new Uri(Path + @"\audio\matching\right.mp3", UriKind.Relative));
            mediaInCorrect.Open(new Uri(Path + @"\audio\matching\wrong.mp3", UriKind.Relative));
            mediaVoid1.Open(new Uri(ListVoid[0], UriKind.Relative));
            mediaVoid2.Open(new Uri(ListVoid[1], UriKind.Relative));
            mediaVoid3.Open(new Uri(ListVoid[2], UriKind.Relative));

            mediaVotay.Open(new Uri(@"..\..\media\audio\tiengvotay.mp3", UriKind.Relative));
            mediaVotay.MediaEnded += MediaVotay_MediaEnded;
            Image1.Source = new BitmapImage(new Uri(ListImgWord[0], UriKind.Relative));
            Image2.Source = new BitmapImage(new Uri(ListImgWord[1], UriKind.Relative));
            Image3.Source = new BitmapImage(new Uri(ListImgWord[2], UriKind.Relative));

            //set hinh anh trong box (sẽ visible khi kéo ảnh vào đúng box)
            ImageBase1.Source = new BitmapImage(new Uri(Path + @"\textures\sequence\act" + Unit + @"\img" + 1 + @".png", UriKind.Relative));
            ImageBase2.Source = new BitmapImage(new Uri(Path + @"\textures\sequence\act" + Unit + @"\img" + 2 + @".png", UriKind.Relative));
            ImageBase3.Source = new BitmapImage(new Uri(Path + @"\textures\sequence\act" + Unit + @"\img" + 3 + @".png", UriKind.Relative));


            //set storyboard
            VisibleImage(storyboardVisible1, "ImageBase1");
            VisibleImage(storyboardVisible2, "ImageBase2");
            VisibleImage(storyboardVisible3, "ImageBase3");
        }

        private void MediaVotay_MediaEnded(object sender, EventArgs e)
        {
            mediaVotay.Stop();
        }

        public void VisibleImage(Storyboard storyBoard, string name)
        {
            var myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0;
            myDoubleAnimation.To = 1;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            myDoubleAnimation.AutoReverse = false;
            storyBoard.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            storyBoard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));
            storyBoard.Completed += StoryBoard_Completed; ; //sau khi hình hiển thị thì ẩn luôn gif ánh sáng.
        }
        private void StoryBoard_Completed(object sender, EventArgs e)
        {
            Gif1.Visibility = Visibility.Hidden;
            Gif2.Visibility = Visibility.Hidden;
            Gif3.Visibility = Visibility.Hidden;
            Thread.Sleep(1500);
            if (score == 3)
            {
                //ẩn main, hiện gif vỗ tay, phát âm thanh hoàn thành action
                Main.Visibility = Visibility.Hidden;
                Votay.Visibility = Visibility.Visible;
                mediaVotay.Play();
                score = 0;
            }
        }
        public void SetIndexImage(Grid gridImg)
        {
            Panel.SetZIndex(GridImg1, 1000);
            Panel.SetZIndex(GridImg2, 999);
            Panel.SetZIndex(GridImg3, 998);
            Panel.SetZIndex(gridImg, 2000);
        }
        private void Feast_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (moving)
            {
                return;
            }
            Image l = e.Source as Image;
            if (l != null)
            {
                if (l.Name == "Image1")
                {
                    SetIndexImage(GridImg1);
                    Image1.CaptureMouse();
                    moving = true;
                    Point pointToWindow = Mouse.GetPosition(this);
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 2 * left;
                    PositionImage.Y -= 5 * left;
                }
                else if (l.Name == "Image2")
                {
                    SetIndexImage(GridImg2);
                    Image2.CaptureMouse();
                    moving = true;
                    Point pointToWindow = Mouse.GetPosition(this);
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 10 * left;
                    PositionImage.Y -= 5 * left;
                }
                else if (l.Name == "Image3")
                {
                    SetIndexImage(GridImg3);
                    Image3.CaptureMouse();
                    moving = true;
                    Point pointToWindow = Mouse.GetPosition(this);
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 18 * left;
                    PositionImage.Y -= 5 * left;
                }
            }
        }
 
        private void Feast_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                Image l = e.Source as Image;
                Point p = e.GetPosition(null);

                UpdatePositionImageCap(l, p);
            }
        }
        //Cập nhật vị trí hình ảnh đang giữ theo vị trí di chuyển của chuột
        public void UpdatePositionImageCap(Image l, Point p)
        {
            if (l.Name == "Image1")
            {
                DeltaX1 = p.X - BasePoint1.X - PositionImage.X;
                DeltaY1 = p.Y - BasePoint1.Y - PositionImage.Y;

                RaisePropertyChanged("XPosition1");
                RaisePropertyChanged("YPosition1");
            }
            else if (l.Name == "Image2")
            {
                DeltaX2 = p.X - BasePoint2.X - PositionImage.X;
                DeltaY2 = p.Y - BasePoint2.Y - PositionImage.Y;
                BasePoint2.X += DeltaX2;
                BasePoint2.Y += DeltaY2;
                RaisePropertyChanged("XPosition2");
                RaisePropertyChanged("YPosition2");
            }
            else if (l.Name == "Image3")
            {
                DeltaX3 = p.X - BasePoint3.X - PositionImage.X;
                DeltaY3 = p.Y - BasePoint3.Y - PositionImage.Y;
                BasePoint3.X += DeltaX3;
                BasePoint3.Y += DeltaY3;
                RaisePropertyChanged("XPosition3");
                RaisePropertyChanged("YPosition3");
            }
        }


        private void Feast_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image l = e.Source as Image;
            Point p = new Point();
            if (l != null)
            {
                mediaCorrect.Stop();
                mediaInCorrect.Stop();
                mediaVoid1.Stop();
                mediaVoid2.Stop();
                mediaVoid3.Stop();
                if (l.Name == "Image1")
                {
                    p = GetPositionAnswer(ListImgSort[0]);

                    Image1.ReleaseMouseCapture();
                    BasePoint1.X += DeltaX1;
                    BasePoint1.Y += DeltaY1;
                    DeltaX1 = 0.0;
                    DeltaY1 = 0.0;
                    moving = false;
                    if ((((BasePoint1.X - 100) < p.X) && (BasePoint1.X + 100) > p.X) && (((BasePoint1.Y - 100) < p.Y) && ((BasePoint1.Y + 100) > p.Y)))
                    {
                        GridImg1.Visibility = Visibility.Hidden;
                        PutImageToCorrectPosition(ListImgSort[0]);
                        score++;
                        mediaCorrect.Play();
                    }
                    else
                    {
                        ResetImagePosition(1);
                        mediaInCorrect.Play();
                    }
                }
                else if (l.Name == "Image2")
                {
                    p = GetPositionAnswer(ListImgSort[1]);

                    Image2.ReleaseMouseCapture();
                    BasePoint2.X += DeltaX2;
                    BasePoint2.Y += DeltaY2;
                    DeltaX2 = 0.0;
                    DeltaY2 = 0.0;
                    moving = false;

                    if ((((BasePoint2.X - 100) < p.X) && (BasePoint2.X + 100) > p.X) && (((BasePoint2.Y - 100) < p.Y) && ((BasePoint2.Y + 100) > p.Y)))
                    {
                        GridImg2.Visibility = Visibility.Hidden;
                        PutImageToCorrectPosition(ListImgSort[1]);
                        score++;
                        mediaCorrect.Play();
                    }
                    else
                    {
                        ResetImagePosition(2);
                        mediaInCorrect.Play();
                    }
                }
                else if (l.Name == "Image3")
                {
                    p = GetPositionAnswer(ListImgSort[2]);

                    Image3.ReleaseMouseCapture();
                    BasePoint3.X += DeltaX3;
                    BasePoint3.Y += DeltaY3;
                    DeltaX3 = 0.0;
                    DeltaY3 = 0.0;
                    moving = false;
                    if ((((BasePoint3.X - 100) < p.X) && (BasePoint3.X + 100) > p.X) && (((BasePoint3.Y - 100) < p.Y) && ((BasePoint3.Y + 100) > p.Y)))
                    {
                        GridImg3.Visibility = Visibility.Hidden;
                        PutImageToCorrectPosition(ListImgSort[2]);
                        score++;
                        mediaCorrect.Play();
                    }
                    else
                    {
                        ResetImagePosition(3);
                        mediaInCorrect.Play();
                    }
                }
            }
        }
        //lấy vị trí của box cần phải đặt hình ảnh vào theo yêu cầu
        public Point GetPositionAnswer(int index)
        {
            Point p = new Point();
            switch (index)
            {
                case 1:
                    {
                        p.X = Canvas.GetLeft(GridBox1);
                        p.Y = Canvas.GetTop(GridBox1);
                    }
                    break;
                case 2:
                    {
                        p.X = Canvas.GetLeft(GridBox2);
                        p.Y = Canvas.GetTop(GridBox2);
                    }
                    break;
                case 3:
                    {
                        p.X = Canvas.GetLeft(GridBox3);
                        p.Y = Canvas.GetTop(GridBox3);
                    }
                    break;
            }
            return p;
        }

        //Set vị trí cho image khi xếp đúng vị trí
        public void PutImageToCorrectPosition(int index)
        {
            if (index == 1)
            {
                storyboardVisible1.Begin(this);
                Gif1.Visibility = Visibility.Visible;
            }
            else
            if (index == 2)
            {
                storyboardVisible2.Begin(this);
                Gif2.Visibility = Visibility.Visible;
            }
            else
            if (index == 3)
            {
                storyboardVisible3.Begin(this);
                Gif3.Visibility = Visibility.Visible;
            }
        }
        //Reset vị trí của ảnh khi xếp sai
        public void ResetImagePosition(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        DeltaX1 = 0;
                        DeltaY1 = 0;
                        BasePoint1.X = BaseImage1.X;
                        BasePoint1.Y = BaseImage1.Y;
                        RaisePropertyChanged("XPosition1");
                        RaisePropertyChanged("YPosition1");
                    }
                    break;
                case 2:
                    {
                        DeltaX2 = 0;
                        DeltaY2 = 0;
                        BasePoint2.X = BaseImage2.X;
                        BasePoint2.Y = BaseImage2.Y;
                        RaisePropertyChanged("XPosition2");
                        RaisePropertyChanged("YPosition2");
                    }
                    break;
                case 3:
                    {
                        DeltaX3 = 0;
                        DeltaY3 = 0;
                        BasePoint3.X = BaseImage3.X;
                        BasePoint3.Y = BaseImage3.Y;
                        RaisePropertyChanged("XPosition3");
                        RaisePropertyChanged("YPosition3");
                    }
                    break;
            }
        }
        private void VoidImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image l = e.Source as Image;
            if (l != null)
            {
                mediaCorrect.Stop();
                mediaInCorrect.Stop();
                mediaVoid1.Stop();
                mediaVoid2.Stop();
                mediaVoid3.Stop();
                if (l.Name == "ImageVoid1")
                {
                    mediaVoid1.Play();
                }
                else if (l.Name == "ImageVoid2")
                {
                    mediaVoid2.Play();
                }
                else if (l.Name == "ImageVoid3")
                {
                    mediaVoid3.Play();
                }
            }
        }
    }
}
