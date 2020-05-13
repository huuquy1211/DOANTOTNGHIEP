using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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
            Image1.Source = new BitmapImage(new Uri(ListImgWord[0], UriKind.Relative));
            Image2.Source = new BitmapImage(new Uri(ListImgWord[1], UriKind.Relative));
            Image3.Source = new BitmapImage(new Uri(ListImgWord[2], UriKind.Relative));

            //set hinh anh trong box (sẽ visible khi kéo ảnh vào đúng box)
            ImageBase1.Source = new BitmapImage(new Uri(Path + @"\textures\sequence\act" + Unit + @"\img" + 1 + @".png", UriKind.Relative));
            ImageBase2.Source = new BitmapImage(new Uri(Path + @"\textures\sequence\act" + Unit + @"\img" + 2 + @".png", UriKind.Relative));
            ImageBase3.Source = new BitmapImage(new Uri(Path + @"\textures\sequence\act" + Unit + @"\img" + 3 + @".png", UriKind.Relative));

            //set vị trí của box
            //Canvas.SetLeft(GridBox1, BaseImage1.X);
            //Canvas.SetLeft(GridBox2, BaseImage2.X);
            //Canvas.SetLeft(GridBox3, BaseImage3.X);
            //Canvas.SetTop(GridBox1, BaseImage1.Y + 100);
            //Canvas.SetTop(GridBox2, BaseImage2.Y + 100);
            //Canvas.SetTop(GridBox3, BaseImage3.Y + 100);


            //khởi tạo âm thanh
            mediaCorrect.Open(new Uri(Path + @"\audio\matching\right.mp3", UriKind.Relative));
            mediaInCorrect.Open(new Uri(Path + @"\audio\matching\wrong.mp3", UriKind.Relative));
            mediaVoid1.Open(new Uri(ListVoid[0], UriKind.Relative));
            mediaVoid2.Open(new Uri(ListVoid[1], UriKind.Relative));
            mediaVoid3.Open(new Uri(ListVoid[2], UriKind.Relative));
        }

        private void Feast_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(moving)
            { return; }    
            Image l = e.Source as Image;
            if (l != null)
            {
                if (l.Name == "Image1")
                {
                    Panel.SetZIndex(GridImg1, 1000);
                    Panel.SetZIndex(GridImg2, 999);
                    Panel.SetZIndex(GridImg3, 998);
                    Image1.CaptureMouse();
                    moving = true;
                    Point pointToWindow = Mouse.GetPosition(this);
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 2 * left;
                    PositionImage.Y -= 5 * left;

                }
                else if (l.Name == "Image2")
                {
                    Panel.SetZIndex(GridImg2, 1555);
                    Panel.SetZIndex(GridImg1, 999);
                    Panel.SetZIndex(GridImg3, 998);
                    Image2.CaptureMouse();
                    moving = true;
                    Point pointToWindow = Mouse.GetPosition(this);
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 10 * left;
                    PositionImage.Y -= 5 * left;
                }
                else if (l.Name == "Image3")
                {
                    Panel.SetZIndex(GridImg3, 1555);
                    Panel.SetZIndex(GridImg2, 999);
                    Panel.SetZIndex(GridImg1, 998);
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
        }
        private void Feast_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image l = e.Source as Image;
            double x = 0;
            double y = 0;
            if (l != null)
            {
                if (l.Name == "Image1")
                {

                    if (ListImgSort[0] == 1)
                    {
                        x = Canvas.GetLeft(GridBox1);
                        y = Canvas.GetTop(GridBox1);
                    }
                    if (ListImgSort[0] == 2)
                    {
                        x = Canvas.GetLeft(GridBox2);
                        y = Canvas.GetTop(GridBox2);
                    }
                    if (ListImgSort[0] == 3)
                    {
                        x = Canvas.GetLeft(GridBox3);
                        y = Canvas.GetTop(GridBox3);
                    }

                    Image1.ReleaseMouseCapture();
                    BasePoint1.X += DeltaX1;
                    BasePoint1.Y += DeltaY1;
                    DeltaX1 = 0.0;
                    DeltaY1 = 0.0;
                    moving = false;
                    if ((((BasePoint1.X - 100) < x) && (BasePoint1.X + 100) > x) && (((BasePoint1.Y - 100) < y) && ((BasePoint1.Y + 100) > y)))
                    {
                        GridImg1.Visibility = Visibility.Hidden;
                        if (ListImgSort[0] == 1)
                        {
                            ImageBase1.Visibility = Visibility.Visible;
                        }
                        if (ListImgSort[0] == 2)
                        {
                            ImageBase2.Visibility = Visibility.Visible;
                        }
                        if (ListImgSort[0] == 3)
                        {
                            ImageBase3.Visibility = Visibility.Visible;
                        }
                        mediaCorrect.Stop();
                        mediaInCorrect.Stop();
                        mediaVoid1.Stop();
                        mediaVoid2.Stop();
                        mediaVoid3.Stop();
                        mediaCorrect.Play();
                    }
                    else
                    {
                        DeltaX1 = 0;
                        DeltaY1 = 0;
                        BasePoint1.X = BaseImage1.X;
                        BasePoint1.Y = BaseImage1.Y;
                        RaisePropertyChanged("XPosition1");
                        RaisePropertyChanged("YPosition1");

                        mediaCorrect.Stop();
                        mediaInCorrect.Stop();
                        mediaVoid1.Stop();
                        mediaVoid2.Stop();
                        mediaVoid3.Stop();
                        mediaInCorrect.Play();
                    }
                }
                else if (l.Name == "Image2")
                {
                    if (ListImgSort[1] == 1)
                    {
                        x = Canvas.GetLeft(GridBox1);
                        y = Canvas.GetTop(GridBox1);
                    }
                    if (ListImgSort[1] == 2)
                    {
                        x = Canvas.GetLeft(GridBox2);
                        y = Canvas.GetTop(GridBox2);
                    }
                    if (ListImgSort[1] == 3)
                    {
                        x = Canvas.GetLeft(GridBox3);
                        y = Canvas.GetTop(GridBox3);
                    }

                    Image2.ReleaseMouseCapture();
                    BasePoint2.X += DeltaX2;
                    BasePoint2.Y += DeltaY2;
                    DeltaX2 = 0.0;
                    DeltaY2 = 0.0;
                    moving = false;
                    if ((((BasePoint2.X - 100) < x) && (BasePoint2.X + 100) > x) && (((BasePoint2.Y - 100) < y) && ((BasePoint2.Y + 100) > y)))
                    {
                        GridImg2.Visibility = Visibility.Hidden;
                        if (ListImgSort[1] == 1)
                        {
                            ImageBase1.Visibility = Visibility.Visible;
                        }
                        if (ListImgSort[1] == 2)
                        {
                            ImageBase2.Visibility = Visibility.Visible;
                        }
                        if (ListImgSort[1] == 3)
                        {
                            ImageBase3.Visibility = Visibility.Visible;
                        }
                        mediaCorrect.Stop();
                        mediaInCorrect.Stop();
                        mediaVoid1.Stop();
                        mediaVoid2.Stop();
                        mediaVoid3.Stop();
                        mediaCorrect.Play();
                    }
                    else
                    {
                        DeltaX2 = 0;
                        DeltaY2 = 0;
                        BasePoint2.X = BaseImage2.X;
                        BasePoint2.Y = BaseImage2.Y;
                        RaisePropertyChanged("XPosition2");
                        RaisePropertyChanged("YPosition2");

                        mediaCorrect.Stop();
                        mediaInCorrect.Stop();
                        mediaVoid1.Stop();
                        mediaVoid2.Stop();
                        mediaVoid3.Stop();
                        mediaInCorrect.Play();
                    }
                }
                else if (l.Name == "Image3")
                {
                    if (ListImgSort[2] == 1)
                    {
                        x = Canvas.GetLeft(GridBox1);
                        y = Canvas.GetTop(GridBox1);
                    }
                    if (ListImgSort[2] == 2)
                    {
                        x = Canvas.GetLeft(GridBox2);
                        y = Canvas.GetTop(GridBox2);
                    }
                    if (ListImgSort[2] == 3)
                    {
                        x = Canvas.GetLeft(GridBox3);
                        y = Canvas.GetTop(GridBox3);
                    }

                    Image3.ReleaseMouseCapture();
                    BasePoint3.X += DeltaX3;
                    BasePoint3.Y += DeltaY3;
                    DeltaX3 = 0.0;
                    DeltaY3 = 0.0;
                    moving = false;
                    if ((((BasePoint3.X - 100) < x) && (BasePoint3.X + 100) > x) && (((BasePoint3.Y - 100) < y) && ((BasePoint3.Y + 100) > y)))
                    {
                        GridImg3.Visibility = Visibility.Hidden;
                        if (ListImgSort[2] == 1)
                        {
                            ImageBase1.Visibility = Visibility.Visible;
                        }
                        if (ListImgSort[2] == 2)
                        {
                            ImageBase2.Visibility = Visibility.Visible;
                        }
                        if (ListImgSort[2] == 3)
                        {
                            ImageBase3.Visibility = Visibility.Visible;
                        }
                        mediaCorrect.Stop();
                        mediaInCorrect.Stop();
                        mediaVoid1.Stop();
                        mediaVoid2.Stop();
                        mediaVoid3.Stop();
                        mediaCorrect.Play();
                    }
                    else
                    {
                        DeltaX3 = 0;
                        DeltaY3 = 0;
                        BasePoint3.X = BaseImage3.X;
                        BasePoint3.Y = BaseImage3.Y;
                        RaisePropertyChanged("XPosition3");
                        RaisePropertyChanged("YPosition3");

                        mediaCorrect.Stop();
                        mediaInCorrect.Stop();
                        mediaVoid1.Stop();
                        mediaVoid2.Stop();
                        mediaVoid3.Stop();
                        mediaInCorrect.Play();
                    }
                }
            }
        }

        private void VoidImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image l = e.Source as Image;
            if (l != null)
            {
                if (l.Name == "ImageVoid1")
                {
                    mediaCorrect.Stop();
                    mediaInCorrect.Stop();
                    mediaVoid1.Stop();
                    mediaVoid2.Stop();
                    mediaVoid3.Stop();
                    mediaVoid1.Play();
                }
                else if (l.Name == "ImageVoid2")
                {
                    mediaCorrect.Stop();
                    mediaInCorrect.Stop();
                    mediaVoid1.Stop();
                    mediaVoid2.Stop();
                    mediaVoid3.Stop();
                    mediaVoid2.Play();
                }
                else if (l.Name == "ImageVoid3")
                {
                    mediaCorrect.Stop();
                    mediaInCorrect.Stop();
                    mediaVoid1.Stop();
                    mediaVoid2.Stop();
                    mediaVoid3.Stop();
                    mediaVoid3.Play();
                }
            }

        }
    }
}
