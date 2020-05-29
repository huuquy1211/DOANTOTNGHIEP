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
    /// Interaction logic for UC_Painting.xaml
    /// </summary>
    public partial class UC_Painting : UserControl, INotifyPropertyChanged
    {
        private int Unit = 1;

        private Point BasePoint1 = new Point(80, 325);
        private Point BasePoint2 = new Point(205, 325);
        private Point BasePoint3 = new Point(355, 325);
        private Point BasePoint4 = new Point(490, 325);

        private Point BaseImage1 = new Point(80, 325);
        private Point BaseImage2 = new Point(205, 325);
        private Point BaseImage3 = new Point(355, 325);
        private Point BaseImage4 = new Point(490, 325);

        private double DeltaX1 = 0.0;
        private double DeltaY1 = 0.0;
        private double DeltaX2 = 0.0;
        private double DeltaY2 = 0.0;
        private double DeltaX3 = 0.0;
        private double DeltaY3 = 0.0;
        private double DeltaX4 = 0.0;
        private double DeltaY4 = 0.0;

        private bool moving = false;
        private Point PositionImage;

        private List<string> ListImage = new List<string>();
        private int[] ListImageColor; //mau cua 3 hinh anh
        private int[] ListImagePosition;

        private MediaPlayer mediaTitle = new MediaPlayer();
        private MediaPlayer mediaDescription = new MediaPlayer();

        private MediaPlayer mediaCorrect = new MediaPlayer();
        private MediaPlayer mediaInCorrect = new MediaPlayer();

        private MediaPlayer mediaVotay = new MediaPlayer();

        private MediaPlayer voice1 = new MediaPlayer();
        private MediaPlayer voice2 = new MediaPlayer();
        private MediaPlayer voice3 = new MediaPlayer();

        private Storyboard storyboardVisible1 = new Storyboard();
        private Storyboard storyboardVisible2 = new Storyboard();
        private Storyboard storyboardVisible3 = new Storyboard();

        private int Index = 0;

        #region
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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

        public double XPosition4
        {
            get { return BasePoint4.X + DeltaX4; }
        }
        public double YPosition4
        {
            get { return BasePoint4.Y + DeltaY4; }
        }

        private int score = 0;
        #endregion
        public UC_Painting(int unit)
        {
            Unit = unit;
            mediaTitle.Open(new Uri(@"..\..\media\audio\painting\title.mp3", UriKind.Relative));
            mediaTitle.MediaEnded += MediaTitle_MediaEnded;

            mediaDescription.Open(new Uri(@"..\..\media\audio\painting\description.mp3", UriKind.Relative));
            mediaDescription.MediaEnded += MediaDescription_MediaEnded;

            InitializeComponent();
            Create();
            mediaTitle.Play();

            VisibleImage(storyboardVisible1,"Pic1");
            VisibleImage(storyboardVisible2, "Pic2");
            VisibleImage(storyboardVisible3, "Pic3");

            this.DataContext = this;
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
            Thread.Sleep(1000);
            if (score == 3)
            {
                //ẩn main, hiện gif vỗ tay, phát âm thanh hoàn thành action
                Main.Visibility = Visibility.Hidden;
                Votay.Visibility = Visibility.Visible;
                mediaVotay.Play();
                score = 0;
            }
        }
        private void MediaVotay_MediaEnded(object sender, EventArgs e)
        {
            mediaVotay.Stop();
        }
        private void MediaDescription_MediaEnded(object sender, EventArgs e)
        {

            Main.Opacity = 1;

            voice1.Stop();
            voice2.Stop();
            voice3.Stop();

            Main.IsEnabled = false; //khóa màn hình khi phát âm thanh
            if (Index >= 3)
                return;

            switch (ListImagePosition[Index])
            {
                case 1:
                    voice1.Play();
                    break;
                case 2:
                    voice2.Play();
                    break;
                case 3:
                    voice3.Play();
                    break;
            }

        }
        private void MediaTitle_MediaEnded(object sender, EventArgs e)
        {
            mediaTitle.Stop();
            mediaDescription.Play();
        }
        public void Create()
        {
            score = 0;
            switch (Unit)
            {
                case 1:
                    {
                        ListImageColor = new int[] { 1, 1, 1 }; // do do do
                        ListImagePosition = new int[] { 3, 1, 2 };
                    }
                    break;
                case 2:
                    {
                        ListImageColor = new int[] { 2, 2, 1 }; // vang vang do, 3 1 2
                        ListImagePosition = new int[] { 3, 1, 2 };
                    }
                    break;
                case 3:
                    {
                        ListImageColor = new int[] { 1, 2, 3 }; //do vang xanhduong
                        ListImagePosition = new int[] { 2, 1, 3 };
                    }
                    break;
                case 4:
                    {
                        ListImageColor = new int[] { 3, 2, 4 };
                        ListImagePosition = new int[] { 3, 1, 2 };
                    }
                    break;
                case 5:
                    {
                        Image1.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act5\pot_red.png", UriKind.Relative));
                        Image2.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act5\pot_yellow.png", UriKind.Relative));
                        Image3.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act5\pot_orange.png", UriKind.Relative));
                        Image4.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act5\pot_purple.png", UriKind.Relative));

                        ListImageColor = new int[] { 1, 4, 3 };
                        ListImagePosition = new int[] { 3, 1, 2 };
                    }
                    break;
                case 6:
                    {
                        Image1.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act6\pot_brown.png", UriKind.Relative));
                        Image2.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act6\pot_pink.png", UriKind.Relative));
                        Image3.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act6\pot_orange.png", UriKind.Relative));
                        Image4.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act6\pot_purple.png", UriKind.Relative));

                        ListImageColor = new int[] { 2, 3, 1 };
                        ListImagePosition = new int[] { 2, 1, 3 };
                    }
                    break;
                case 7:
                    {
                        Image1.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act7\pot_brown.png", UriKind.Relative));
                        Image2.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act7\pot_orange.png", UriKind.Relative));
                        Image3.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act7\pot_black.png", UriKind.Relative));
                        Image4.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act7\pot_green.png", UriKind.Relative));

                        ListImageColor = new int[] { 3, 4, 2 };
                        ListImagePosition = new int[] { 2, 1, 3 };
                    }
                    break;
                case 8:
                    {
                        ListImageColor = new int[] { 1, 3, 4 };
                        ListImagePosition = new int[] { 2, 1, 3 };
                    }
                    break;
            }

            PicBG1.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act" + Unit + @"\img1.png", UriKind.Relative));
            PicBG2.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act" + Unit + @"\img2.png", UriKind.Relative));
            PicBG3.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act" + Unit + @"\img3.png", UriKind.Relative));


            mediaCorrect.Open(new Uri(@"..\..\media\audio\global\right.mp3", UriKind.Relative));
            mediaInCorrect.Open(new Uri(@"..\..\media\audio\global\wrong.mp3", UriKind.Relative));
            mediaVotay.Open(new Uri(@"..\..\media\audio\tiengvotay.mp3", UriKind.Relative));
            mediaVotay.MediaEnded += MediaVotay_MediaEnded;

            mediaCorrect.MediaEnded += MediaDescription_MediaEnded;
            mediaInCorrect.MediaEnded += MediaDescription_MediaEnded;


            voice1.Open(new Uri(@"..\..\media\audio\painting\act" + Unit + @"\sound1.mp3", UriKind.Relative));
            voice2.Open(new Uri(@"..\..\media\audio\painting\act" + Unit + @"\sound2.mp3", UriKind.Relative));
            voice3.Open(new Uri(@"..\..\media\audio\painting\act" + Unit + @"\sound3.mp3", UriKind.Relative));

            voice1.MediaEnded += voice_MediaEnded;
            voice2.MediaEnded += voice_MediaEnded;
            voice3.MediaEnded += voice_MediaEnded;
        }

        private void voice_MediaEnded(object sender, EventArgs e)
        {
            Main.IsEnabled = true;
        }

        private void Feast_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (moving || Index >= 3)
            {
                return;
            }
            Image l = e.Source as Image;
            if (l != null)
            {
                Point pointToWindow = Mouse.GetPosition(this);
                SetIndexForImage(GetImageColorByName(l.Name));
                GetImageColorByName(l.Name).CaptureMouse();
                moving = true;

                if (l.Name == "Image1")
                {
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 80;
                    PositionImage.Y -= 325;
                }
                else if (l.Name == "Image2")
                {
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 205;
                    PositionImage.Y -= 325;
                }
                else if (l.Name == "Image3")
                {

                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 355;
                    PositionImage.Y -= 325;
                }
                else if (l.Name == "Image4")
                {
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 490;
                    PositionImage.Y -= 325;
                }
            }
        }
        private void Feast_MouseMove(object sender, MouseEventArgs e)
        {

            if (moving)
            {
                Image l = e.Source as Image;
                Point p = e.GetPosition(null);
                MoveImageColor(l, p);
            }
        }

        public void ColorImage(Image img,string path)
        {
            img.Source = new BitmapImage(new Uri(path, UriKind.Relative));

            switch (img.Name)
            {
                case "Pic1":
                    {
                        storyboardVisible1.Begin(this);
                        Gif1.Visibility = Visibility.Visible;
                    }
                    break;
                case "Pic2":
                    {
                        storyboardVisible2.Begin(this);
                        Gif2.Visibility = Visibility.Visible;
                    }
                    break;
                case "Pic3":
                    {
                        storyboardVisible3.Begin(this);
                        Gif3.Visibility = Visibility.Visible;
                    }
                    break;
            }
        }

        private void Feast_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!moving || Index >= 3)
            {
                return;
            }

            moving = false;
            Image l = e.Source as Image;
            Point positionCorrect = new Point();

            l.ReleaseMouseCapture();
            if (l != null)
            {
                if (l.Name == "Image1")
                {
                    mediaCorrect.Stop();
                    mediaInCorrect.Stop();
                    if (ListImageColor[Index] == 1)//chọn đúng màu
                    {
                        Image image = new Image();
                        positionCorrect = GetPointCorrectAnswer(ListImagePosition[Index]);
                        image = GetPictureCorrectAnswer(ListImagePosition[Index]);

                        BasePoint1.X += DeltaX1;
                        BasePoint1.Y += DeltaY1;
                        DeltaX1 = 0.0;
                        DeltaY1 = 0.0;

                        //đúng vị trí
                        if ((((BasePoint1.X - 100) < positionCorrect.X) && (BasePoint1.X + 100) > positionCorrect.X) && (((BasePoint1.Y - 100) < positionCorrect.Y) && ((BasePoint1.Y + 100) > positionCorrect.Y))) 
                        {
                            Main.IsEnabled = false;
                            mediaCorrect.Play();

                            ColorImage(image, @"..\..\media\textures\painting\act" + Unit + @"\coloredimg" + ListImagePosition[Index] + ".png");

                            ResetImageColor(1);
                            Index++;
                            score++;
                            return;
                        }
                    }
                    //Chọn sai màu hoặc tô sai vị trí
                    ResetImageColor(1);
                    Main.IsEnabled = false;
                    mediaInCorrect.Play();
                }
                else if (l.Name == "Image2")
                {
                    if (ListImageColor[Index] == 2)//chọn đúng màu
                    {
                        Image image = new Image();
                        positionCorrect = GetPointCorrectAnswer(ListImagePosition[Index]);
                        image = GetPictureCorrectAnswer(ListImagePosition[Index]);

                        BasePoint2.X += DeltaX2;
                        BasePoint1.Y += DeltaY2;
                        DeltaX2 = 0.0;
                        DeltaY2 = 0.0;
                        if ((((BasePoint2.X - 100) < positionCorrect.X) && (BasePoint2.X + 100) > positionCorrect.X) && (((BasePoint2.Y - 100) < positionCorrect.Y) && ((BasePoint2.Y + 100) > positionCorrect.Y))) //đúng
                        {
                            Main.IsEnabled = false;
                            mediaCorrect.Play();
                            ColorImage(image, @"..\..\media\textures\painting\act" + Unit + @"\coloredimg" + ListImagePosition[Index] + ".png");

                            ResetImageColor(2);
                            Index++;
                            score++;
                            return;
                        }
                    }
                    //Chọn sai màu hoặc tô sai vị trí
                    ResetImageColor(2);
                    Main.IsEnabled = false;
                    mediaInCorrect.Play();
                }
                else if (l.Name == "Image3")
                {
                    if (ListImageColor[Index] == 3)//chọn đúng màu
                    {
                        Image image = new Image();
                        positionCorrect = GetPointCorrectAnswer(ListImagePosition[Index]);
                        image = GetPictureCorrectAnswer(ListImagePosition[Index]);

                        BasePoint3.X += DeltaX3;
                        BasePoint3.Y += DeltaY3;
                        DeltaX3 = 0.0;
                        DeltaY3 = 0.0;

                        if ((((BasePoint3.X - 100) < positionCorrect.X) && (BasePoint3.X + 100) > positionCorrect.X) && (((BasePoint3.Y - 100) < positionCorrect.Y) && ((BasePoint3.Y + 100) > positionCorrect.Y))) //đúng
                        {
                            Main.IsEnabled = false;
                            mediaCorrect.Play();
                            ColorImage(image, @"..\..\media\textures\painting\act" + Unit + @"\coloredimg" + ListImagePosition[Index] + ".png");
                            ResetImageColor(3);
                            Index++;
                            score++;
                            return;
                        }
                    }
                    //Chọn sai màu hoặc tô sai vị trí
                    ResetImageColor(3);
                    Main.IsEnabled = false;
                    mediaInCorrect.Play();
                }
                else if (l.Name == "Image4")
                {
                    if (ListImageColor[Index] == 4)//chọn đúng màu
                    {
                        Image image = new Image();
                        positionCorrect = GetPointCorrectAnswer(ListImagePosition[Index]);
                        image = GetPictureCorrectAnswer(ListImagePosition[Index]);

                        BasePoint4.X += DeltaX4;
                        BasePoint4.Y += DeltaY4;
                        DeltaX4 = 0.0;
                        DeltaY4 = 0.0;

                        if ((((BasePoint4.X - 100) < positionCorrect.X) && (BasePoint4.X + 100) > positionCorrect.X) && (((BasePoint4.Y - 100) < positionCorrect.Y) && ((BasePoint4.Y + 100) > positionCorrect.Y))) //đúng
                        {
                            Main.IsEnabled = false;
                            mediaCorrect.Play();
                            ColorImage(image, @"..\..\media\textures\painting\act" + Unit + @"\coloredimg" + ListImagePosition[Index] + ".png");
                            ResetImageColor(4);
                            Index++;
                            score++;
                            return;
                        }
                    }
                    //Chọn sai màu hoặc tô sai vị trí
                    ResetImageColor(4);
                    Main.IsEnabled = false;
                    mediaInCorrect.Play();
                }
            }
        }

        //Lấy ra vị trí pic cần tô màu theo yêu cầu hiện tại
        public Point GetPointCorrectAnswer(int index)
        {
            Point positionCorrect = new Point();
            switch (index)//lấy vị trí hình đáp án
            {
                case 1:
                    {
                        positionCorrect.X = Canvas.GetLeft(GridPic1);
                        positionCorrect.Y = Canvas.GetTop(GridPic1);
                    }
                    break;
                case 2:
                    {
                        positionCorrect.X = Canvas.GetLeft(GridPic2);
                        positionCorrect.Y = Canvas.GetTop(GridPic2);
                    }
                    break;
                case 3:
                    {
                        positionCorrect.X = Canvas.GetLeft(GridPic3);
                        positionCorrect.Y = Canvas.GetTop(GridPic3);
                    }
                    break;
            }
            return positionCorrect;
        }
        //Lấy ra pic cần tô màu theo yêu cầu hiện tại
        public Image GetPictureCorrectAnswer(int index)
        {
            Image picCorrect = new Image();
            switch (index)//lấy vị trí hình đáp án
            {
                case 1:
                    {
                        picCorrect = Pic1;
                    }
                    break;
                case 2:
                    {
                        picCorrect = Pic2;
                    }
                    break;
                case 3:
                    {
                        picCorrect = Pic3;
                    }
                    break;
            }
            return picCorrect;
        }

        //trả vị trí hộp màu về vị trí ban đầu
        public void ResetImageColor(int i)
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
                case 4:
                    {
                        DeltaX4 = 0;
                        DeltaY4 = 0;
                        BasePoint4.X = BaseImage4.X;
                        BasePoint4.Y = BaseImage4.Y;
                        RaisePropertyChanged("XPosition4");
                        RaisePropertyChanged("YPosition4");
                    }
                    break;
            }
        }


        //Cập nhật vị trí của hộp màu theo sự di chuyển của chuột
        public void MoveImageColor(Image l, Point p)
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
            else if (l.Name == "Image4")
            {
                DeltaX4 = p.X - BasePoint4.X - PositionImage.X;
                DeltaY4 = p.Y - BasePoint4.Y - PositionImage.Y;
                BasePoint4.X += DeltaX4;
                BasePoint4.Y += DeltaY4;
                RaisePropertyChanged("XPosition4");
                RaisePropertyChanged("YPosition4");
            }
        }
        public Image GetImageColorByName(string name)
        {
            switch (name)
            {
                case "Image1":
                    {
                        return Image1;
                    }
                case "Image2":
                    {
                        return Image2;
                    }
                case "Image3":
                    {
                        return Image3;
                    }
                case "Image4":
                    {
                        return Image4;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public void SetIndexForImage(Image img)
        {
            Panel.SetZIndex(Image4, 1004);
            Panel.SetZIndex(Image2, 1003);
            Panel.SetZIndex(Image1, 1002);
            Panel.SetZIndex(Image3, 1001);
            Panel.SetZIndex(Pic1, 1000);
            Panel.SetZIndex(Pic2, 999);
            Panel.SetZIndex(Pic3, 998);

            Panel.SetZIndex(img, 2000);
        }




    }
}
