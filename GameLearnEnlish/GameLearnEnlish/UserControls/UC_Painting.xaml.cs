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

        MediaPlayer mediaTitle = new MediaPlayer();
        MediaPlayer mediaDescription = new MediaPlayer();

        MediaPlayer mediaCorrect = new MediaPlayer();
        MediaPlayer mediaInCorrect = new MediaPlayer();

        MediaPlayer Void1 = new MediaPlayer();
        MediaPlayer Void2 = new MediaPlayer();
        MediaPlayer Void3 = new MediaPlayer();

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
           
            this.DataContext = this;
        }

        private void MediaDescription_MediaEnded(object sender, EventArgs e)
        {
         
            Main.Opacity = 1;

            Void1.Stop();
            Void2.Stop();
            Void3.Stop();

            Main.IsEnabled = false; //khóa màn hình khi phát âm thanh
            if (Index >= 3)
                return;

            switch (ListImagePosition[Index])
            {
                case 1:
                    Void1.Play();
                    break;
                case 2:
                    Void2.Play();
                    break;
                case 3:
                    Void3.Play();
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
                        ListImagePosition = new int[] { 3, 1, 2};
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
                        ListImageColor = new int[] {3, 2, 4 };
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
                        ListImagePosition = new int[] { 2, 1,3};
                    }
                    break;
                case 8:
                    {
                        ListImageColor = new int[] { 1, 3, 4 };
                        ListImagePosition = new int[] { 2, 1, 3 };
                    }
                    break;
            }




            Pic1.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act" + Unit + @"\img1.png", UriKind.Relative));
            Pic2.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act" + Unit + @"\img2.png", UriKind.Relative));
            Pic3.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act" + Unit + @"\img3.png", UriKind.Relative));


            mediaCorrect.Open(new Uri(@"..\..\media\audio\global\right.mp3", UriKind.Relative));
            mediaInCorrect.Open(new Uri(@"..\..\media\audio\global\wrong.mp3", UriKind.Relative));
            mediaCorrect.MediaEnded += MediaDescription_MediaEnded;
            mediaInCorrect.MediaEnded += MediaDescription_MediaEnded;


            Void1.Open(new Uri(@"..\..\media\audio\painting\act" + Unit + @"\sound1.mp3", UriKind.Relative));
            Void2.Open(new Uri(@"..\..\media\audio\painting\act" + Unit + @"\sound2.mp3", UriKind.Relative));
            Void3.Open(new Uri(@"..\..\media\audio\painting\act" + Unit + @"\sound3.mp3", UriKind.Relative));

            Void1.MediaEnded += Void_MediaEnded;
            Void2.MediaEnded += Void_MediaEnded;
            Void3.MediaEnded += Void_MediaEnded;
        }

        private void Void_MediaEnded(object sender, EventArgs e)
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
                if (l.Name == "Image1")
                {
                    Panel.SetZIndex(Image1, 2000);
                    Panel.SetZIndex(Image2, 1003);
                    Panel.SetZIndex(Image3, 1002);
                    Panel.SetZIndex(Image4, 1001);
                    Panel.SetZIndex(Pic1, 1000);
                    Panel.SetZIndex(Pic2, 999);
                    Panel.SetZIndex(Pic3, 998);
                    Image1.CaptureMouse();
                    moving = true;
                    Point pointToWindow = Mouse.GetPosition(this);
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 80;
                    PositionImage.Y -= 325;

                }
                else if (l.Name == "Image2")
                {
                    Panel.SetZIndex(Image2, 2000);
                    Panel.SetZIndex(Image1, 1003);
                    Panel.SetZIndex(Image3, 1002);
                    Panel.SetZIndex(Image4, 1001);
                    Panel.SetZIndex(Pic1, 1000);
                    Panel.SetZIndex(Pic2, 999);
                    Panel.SetZIndex(Pic3, 998);
                    Image2.CaptureMouse();
                    moving = true;
                    Point pointToWindow = Mouse.GetPosition(this);
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 205;
                    PositionImage.Y -= 325;
                }
                else if (l.Name == "Image3")
                {
                    Panel.SetZIndex(Image3, 2000);
                    Panel.SetZIndex(Image2, 1003);
                    Panel.SetZIndex(Image1, 1002);
                    Panel.SetZIndex(Image4, 1001);
                    Panel.SetZIndex(Pic1, 1000);
                    Panel.SetZIndex(Pic2, 999);
                    Panel.SetZIndex(Pic3, 998);
                    Image3.CaptureMouse();
                    moving = true;
                    Point pointToWindow = Mouse.GetPosition(this);
                    PositionImage = PointToScreen(pointToWindow);
                    PositionImage.X -= 355;
                    PositionImage.Y -= 325;
                }
                else if (l.Name == "Image4")
                {
                    Panel.SetZIndex(Image4, 2000);
                    Panel.SetZIndex(Image2, 1003);
                    Panel.SetZIndex(Image1, 1002);
                    Panel.SetZIndex(Image3, 1001);
                    Panel.SetZIndex(Pic1, 1000);
                    Panel.SetZIndex(Pic2, 999);
                    Panel.SetZIndex(Pic3, 998);
                    Image4.CaptureMouse();
                    moving = true;
                    Point pointToWindow = Mouse.GetPosition(this);
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
        }
        private void Feast_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!moving || Index >= 3)
            {
                return;
            }

            moving = false;
            Image l = e.Source as Image;
            double x = 0;
            double y = 0;
            l.ReleaseMouseCapture();
            if (l != null)
            {

                if (l.Name == "Image1")
                {

                    if (ListImageColor[Index] == 1)//chọn đúng màu
                    {
                        Image image = new Image();
                        switch (ListImagePosition[Index])//lấy vị trí hình đáp án
                        {
                            case 1:
                                {
                                    x = Canvas.GetLeft(GridPic1);
                                    y = Canvas.GetTop(GridPic1);
                                    image = Pic1;
                                }
                                break;
                            case 2:
                                {
                                    x = Canvas.GetLeft(GridPic2);
                                    y = Canvas.GetTop(GridPic2);
                                    image = Pic2;
                                }
                                break;
                            case 3:
                                {
                                    x = Canvas.GetLeft(GridPic3);
                                    y = Canvas.GetTop(GridPic3);
                                    image = Pic3;
                                }
                                break;
                        }
                        BasePoint1.X += DeltaX1;
                        BasePoint1.Y += DeltaY1;
                        DeltaX1 = 0.0;
                        DeltaY1 = 0.0;

                        if ((((BasePoint1.X - 100) < x) && (BasePoint1.X + 100) > x) && (((BasePoint1.Y - 100) < y) && ((BasePoint1.Y + 100) > y))) //đúng
                        {

                            mediaCorrect.Stop();
                            mediaInCorrect.Stop();

                            Main.IsEnabled = false;
                            mediaCorrect.Play();
                            image.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act" + Unit + @"\coloredimg" + ListImagePosition[Index] + ".png", UriKind.Relative));

                            DeltaX1 = 0;
                            DeltaY1 = 0;
                            BasePoint1.X = BaseImage1.X;
                            BasePoint1.Y = BaseImage1.Y;
                            RaisePropertyChanged("XPosition1");
                            RaisePropertyChanged("YPosition1");
                            Index++;
                            return;
                        }

                    }
                    //Chọn sai màu hoặc tô sai vị trí
                    DeltaX1 = 0;
                    DeltaY1 = 0;
                    BasePoint1.X = BaseImage1.X;
                    BasePoint1.Y = BaseImage1.Y;
                    RaisePropertyChanged("XPosition1");
                    RaisePropertyChanged("YPosition1");

                    mediaCorrect.Stop();
                    mediaInCorrect.Stop();

                    Main.IsEnabled = false;
                    mediaInCorrect.Play();

                }
                else if (l.Name == "Image2")
                {


                    if (ListImageColor[Index] == 2)//chọn đúng màu
                    {
                        Image image = new Image();
                        switch (ListImagePosition[Index])//lấy vị trí hình đáp án
                        {
                            case 1:
                                {
                                    x = Canvas.GetLeft(GridPic1);
                                    y = Canvas.GetTop(GridPic1);
                                    image = Pic1;
                                }
                                break;
                            case 2:
                                {
                                    x = Canvas.GetLeft(GridPic2);
                                    y = Canvas.GetTop(GridPic2);
                                    image = Pic2;
                                }
                                break;
                            case 3:
                                {
                                    x = Canvas.GetLeft(GridPic3);
                                    y = Canvas.GetTop(GridPic3);
                                    image = Pic3;
                                }
                                break;
                        }

                        BasePoint2.X += DeltaX2;
                        BasePoint2.Y += DeltaY2;
                        DeltaX2 = 0.0;
                        DeltaY2 = 0.0;

                        if ((((BasePoint2.X - 100) < x) && (BasePoint2.X + 100) > x) && (((BasePoint2.Y - 100) < y) && ((BasePoint2.Y + 100) > y))) //đúng
                        {

                            mediaCorrect.Stop();
                            mediaInCorrect.Stop();
                            Main.IsEnabled = false;
                            mediaCorrect.Play();
                            image.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act" + Unit + @"\coloredimg" + ListImagePosition[Index] + ".png", UriKind.Relative));

                            DeltaX2 = 0;
                            DeltaY2 = 0;
                            BasePoint2.X = BaseImage2.X;
                            BasePoint2.Y = BaseImage2.Y;
                            RaisePropertyChanged("XPosition2");
                            RaisePropertyChanged("YPosition2");
                            Index++;
                            return;
                        }

                    }
                    //Chọn sai màu hoặc tô sai vị trí
                    DeltaX2 = 0;
                    DeltaY2 = 0;
                    BasePoint2.X = BaseImage2.X;
                    BasePoint2.Y = BaseImage2.Y;
                    RaisePropertyChanged("XPosition2");
                    RaisePropertyChanged("YPosition2");

                    mediaCorrect.Stop();
                    mediaInCorrect.Stop();
                    Main.IsEnabled = false;
                    mediaInCorrect.Play();
                }
                else if (l.Name == "Image3")
                {


                    if (ListImageColor[Index] == 3)//chọn đúng màu
                    {
                        Image image = new Image();
                        switch (ListImagePosition[Index])//lấy vị trí hình đáp án
                        {
                            case 1:
                                {
                                    x = Canvas.GetLeft(GridPic1);
                                    y = Canvas.GetTop(GridPic1);
                                    image = Pic1;
                                }
                                break;
                            case 2:
                                {
                                    x = Canvas.GetLeft(GridPic2);
                                    y = Canvas.GetTop(GridPic2);
                                    image = Pic2;
                                }
                                break;
                            case 3:
                                {
                                    x = Canvas.GetLeft(GridPic3);
                                    y = Canvas.GetTop(GridPic3);
                                    image = Pic3;
                                }
                                break;
                        }
                        BasePoint3.X += DeltaX3;
                        BasePoint3.Y += DeltaY3;
                        DeltaX3 = 0.0;
                        DeltaY3 = 0.0;

                        if ((((BasePoint3.X - 100) < x) && (BasePoint3.X + 100) > x) && (((BasePoint3.Y - 100) < y) && ((BasePoint3.Y + 100) > y))) //đúng
                        {

                            mediaCorrect.Stop();
                            mediaInCorrect.Stop();
                            Main.IsEnabled = false;
                            mediaCorrect.Play();
                            image.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act" + Unit + @"\coloredimg" + ListImagePosition[Index] + ".png", UriKind.Relative));

                            DeltaX3 = 0;
                            DeltaY3 = 0;
                            BasePoint3.X = BaseImage3.X;
                            BasePoint3.Y = BaseImage3.Y;
                            RaisePropertyChanged("XPosition3");
                            RaisePropertyChanged("YPosition3");
                            Index++;
                            return;
                        }

                    }
                    //Chọn sai màu hoặc tô sai vị trí
                    DeltaX3 = 0;
                    DeltaY3 = 0;
                    BasePoint3.X = BaseImage3.X;
                    BasePoint3.Y = BaseImage3.Y;
                    RaisePropertyChanged("XPosition3");
                    RaisePropertyChanged("YPosition3");

                    mediaCorrect.Stop();
                    mediaInCorrect.Stop();
                    Main.IsEnabled = false;
                    mediaInCorrect.Play();
                }
                else if (l.Name == "Image4")
                {


                    if (ListImageColor[Index] == 4)//chọn đúng màu
                    {
                        Image image = new Image();
                        switch (ListImagePosition[Index])//lấy vị trí hình đáp án
                        {
                            case 1:
                                {
                                    x = Canvas.GetLeft(GridPic1);
                                    y = Canvas.GetTop(GridPic1);
                                    image = Pic1;
                                }
                                break;
                            case 2:
                                {
                                    x = Canvas.GetLeft(GridPic2);
                                    y = Canvas.GetTop(GridPic2);
                                    image = Pic2;
                                }
                                break;
                            case 3:
                                {
                                    x = Canvas.GetLeft(GridPic3);
                                    y = Canvas.GetTop(GridPic3);
                                    image = Pic3;
                                }
                                break;
                        }


                        BasePoint4.X += DeltaX4;
                        BasePoint4.Y += DeltaY4;
                        DeltaX4 = 0.0;
                        DeltaY4 = 0.0;

                        if ((((BasePoint4.X - 100) < x) && (BasePoint4.X + 100) > x) && (((BasePoint4.Y - 100) < y) && ((BasePoint4.Y + 100) > y))) //đúng
                        {

                            mediaCorrect.Stop();
                            mediaInCorrect.Stop();
                            Main.IsEnabled = false;
                            mediaCorrect.Play();

                            image.Source = new BitmapImage(new Uri(@"..\..\media\textures\painting\act"+Unit+@"\coloredimg"+ ListImagePosition[Index]+".png", UriKind.Relative));

                            DeltaX4 = 0;
                            DeltaY4 = 0;
                            BasePoint4.X = BaseImage4.X;
                            BasePoint4.Y = BaseImage4.Y;
                            RaisePropertyChanged("XPosition4");
                            RaisePropertyChanged("YPosition4");
                            Index++;
                            return;
                        }

                    }
                    //Chọn sai màu hoặc tô sai vị trí
                    DeltaX4 = 0;
                    DeltaY4 = 0;
                    BasePoint4.X = BaseImage4.X;
                    BasePoint4.Y = BaseImage4.Y;
                    RaisePropertyChanged("XPosition4");
                    RaisePropertyChanged("YPosition4");

                    mediaCorrect.Stop();
                    mediaInCorrect.Stop();
                    Main.IsEnabled = false;
                    mediaInCorrect.Play();
                }
            }
        }








    }
}
