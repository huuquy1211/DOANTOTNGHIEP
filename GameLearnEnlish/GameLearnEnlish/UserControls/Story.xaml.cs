using BLL;
using Data;
using GameLearnEnlish.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Story.xaml
    /// </summary>
    public partial class Story : UserControl
    {
        private WrapPanel[] ImageControls;
        private static string[] TransitionEffects = new[] { "SlideUp", "SlideDown" };
        private string TransitionType;
        private int CurrentCtrlIndex = 0;//trang slide img hiện tại


        private int Unit;
        private List<Sentence> lstSentence = new List<Sentence>();

        private MediaPlayer mediaTitle = new MediaPlayer();
        private MediaPlayer mediaDescription = new MediaPlayer();

        private List<string> lstText = new List<string>();//danh sách các câu tiếng anh (dạng text)
        private List<WrapPanel> ListStack = new List<WrapPanel>(); // danh sách các câu (dạng control label)
        private List<string> imgList = new List<string>();// danh sách path hình ảnh của các câu tiếng anh

        private List<MediaPlayer> mediaSoundWord = new List<MediaPlayer>(); // danh sách âm thanh của các câu

        private List<Image> Images = new List<Image>(); // danh sách control image trong slide img
        private List<Border> Borders = new List<Border>();

        private MediaPlayer media = new MediaPlayer();
        private int IndexMedia = 0;
        private bool IsFullSoundClick = false;

        int firstPage = 0;
        int lastPage = 0;

        public Story(int unit)
        {
            Unit = unit;
            mediaTitle.Open(new Uri(@"..\..\media\audio\storytime\title.mp3", UriKind.Relative));
            mediaTitle.MediaEnded += MediaTitle_MediaEnded;
            mediaDescription.Open(new Uri(@"..\..\media\audio\storytime\description.mp3", UriKind.Relative));
            mediaDescription.MediaEnded += MediaDescription_MediaEnded;
            InitializeComponent();
            lstSentence = new SentenceBLL().GetSentencesOfUnit(Unit);

            IndexMedia = 0;
            foreach (Sentence x in lstSentence)
            {
                imgList.Add(x.Image.Trim());
                MediaPlayer media = new MediaPlayer();
                media.Open(new Uri(x.Sound, UriKind.Relative));
                media.MediaEnded += Media_MediaEnded;
                mediaSoundWord.Add(media);
                lstText.Add(x.Text.Trim());
            }

            LoadSlideImage();

            BigImage.Source = new BitmapImage(new Uri(imgList[0], UriKind.Relative));
            mediaTitle.Play();
            CreateLabel(lstText);
        }

        private void Media_MediaEnded(object sender, EventArgs e)
        {
            StopMediaVoid();

            if (IsFullSoundClick == true)
            {
                IndexMedia++;
                if (ListStack.Count >= IndexMedia)
                {
                    ChangeLineFocus(IndexMedia);
                    ShowBorderImageFocus(IndexMedia);
                }
                if (mediaSoundWord.Count > IndexMedia)
                    mediaSoundWord[IndexMedia].Play();
                if (IndexMedia == mediaSoundWord.Count)
                {
                    IndexMedia = 0;
                    GridPanel.IsEnabled = true;
                    SlideToPage(0);
                }

            }
            else
            {
                StopMediaVoid();
                IndexMedia = 0;
                ChangeLineFocus(-1);
                GridPanel.IsEnabled = true;
                ShowBorderImageFocus(-1);
            }


        }

        private void MediaTitle_MediaEnded(object sender, EventArgs e)
        {
            mediaTitle.Stop();
            mediaDescription.Play();
        }
        private void MediaDescription_MediaEnded(object sender, EventArgs e)
        {
            GridMain.IsEnabled = true;
            GridMain.Opacity = 1;
        }

        #region create label
        public void CreateLabel(List<string> lst)
        {

            stackMain.Orientation = Orientation.Vertical;
            int indexLabel = 0;
            foreach (string ls in lst)
            {
                string str = ls;
                WrapPanel stack = new WrapPanel(); //stPic
                stack.Orientation = Orientation.Horizontal;


                Thickness margin = stack.Margin;
                margin.Top = 0;
                margin.Left = 10;
                stack.Margin = margin;

                while (!String.IsNullOrEmpty(str.Trim()))//ls khong rong
                {
                    string s = "";
                    int index = str.TrimStart().IndexOf(' ');
                    if (index != -1)
                    {
                        s = str.TrimStart().Substring(0, index);
                        str = str.Remove(0, index + 1);
                    }
                    else
                    {
                        s = str.Trim();
                        str = "";
                    }

                    Label x = new Label();
                    x.Name = "lb" + indexLabel;
                    x.FontWeight = FontWeights.Bold;
                    indexLabel++;
                    x.Content = s + " ";
                    x.FontSize = 20;
                    x.Foreground = Brushes.Black;

                    x.MouseDown += X_MouseDown;
                    x.MouseEnter += X_MouseEnter;
                    x.MouseLeave += X_MouseLeave;
                    stack.Children.Add(x);
                }
                ListStack.Add(stack);
                stackMain.Children.Add(stack);
            }
        }

        private void X_MouseLeave(object sender, MouseEventArgs e)
        {
            Label lb = sender as Label;
            lb.Foreground = Brushes.Black;
        }

        private void X_MouseEnter(object sender, MouseEventArgs e)
        {
            Label lb = sender as Label;
            lb.Foreground = Brushes.Red;
        }

        private void X_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Label lb = sender as Label;
            lb.Foreground = Brushes.Blue;
            string s = lb.Content.ToString();

            Regex rgx = new Regex("[^a-zA-Z0-9]");
            s = rgx.Replace(s, "");
            s = s.ToLower();

            PlayMedia(MediaBank.getInstance().GetMedia(s));
        }
        #endregion

        private void PlayMedia(MediaPlayer m)
        {
            if (media != null)
            {
                media.Stop();
            }

            media = m;
            if (media != null)
            {
                media.Play();
            }
        }
        private void ImageVoid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StopMediaVoid();
            IsFullSoundClick = true;
            IndexMedia = 0;
            mediaSoundWord[0].Play();
            ChangeLineFocus(0);
            ShowBorderImageFocus(0);
            GridPanel.IsEnabled = false;
        }

        public void ChangeLineFocus(int i)
        {
            foreach (WrapPanel x in ListStack)
            {
                foreach (var y in x.Children)
                {
                    (y as Label).Foreground = Brushes.Black;
                }
            }
            if (ListStack.Count > i && i >= 0)
            {
                foreach (var x in ListStack[i].Children)
                {
                    (x as Label).Foreground = Brushes.Red;
                }
            }
        }


        #region SlideImage
        //Load images from folder
        private void LoadSlideImage()
        {
            try
            {
                ImageControls = new WrapPanel[imgList.Count];
                for (int j = 0; j < imgList.Count; j++)
                {
                    WrapPanel myWrapPanel = new WrapPanel();

                    myWrapPanel.Name = "myImage" + j;
                    myWrapPanel.RenderTransformOrigin = new Point(0.5, 0.5);

                    myWrapPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    myWrapPanel.VerticalAlignment = System.Windows.VerticalAlignment.Center;

                    myWrapPanel.Orientation = Orientation.Horizontal;

                    myWrapPanel.RenderTransform = new ScaleTransform() { ScaleX = 1, ScaleY = 1, CenterX = 0, CenterY = 0 };
                    myWrapPanel.RenderTransform = new SkewTransform() { AngleX = 0, AngleY = 0, CenterX = 0, CenterY = 0 };
                    myWrapPanel.RenderTransform = new RotateTransform() { Angle = 0, CenterX = 0, CenterY = 0 };
                    myWrapPanel.RenderTransform = new TranslateTransform() { X = 0, Y = 0 };
                    myWrapPanel.Visibility = System.Windows.Visibility.Hidden;
                    GridLst.Children.Add(myWrapPanel);
                    ImageControls[j] = myWrapPanel;
                }
                ImageControls[0].Visibility = System.Windows.Visibility.Visible;
                int s = 0;
                int intCnt = 0;
                for (int i = 0; i < imgList.Count; i++)
                {
                    Border brd = new Border();
                    brd.BorderBrush = Brushes.Green;
                    brd.CornerRadius = new CornerRadius(8);
                    brd.BorderThickness = new Thickness(3);
                    brd.Margin = new Thickness(10, 0, 10, 0);
                    brd.HorizontalAlignment = HorizontalAlignment.Center;
                    brd.VerticalAlignment = VerticalAlignment.Center;
                    brd.Background = Brushes.Transparent;

                    brd.Padding = new Thickness(2);
                    Borders.Add(brd);

                    Image img = new Image();

                    img.Name = "img" + i;
                    img.Source = new BitmapImage(new Uri(imgList[i], UriKind.Relative));
                    img.MouseUp += Img_MouseUp; ;
                    img.MouseEnter += Img_MouseEnter;
                    img.MouseLeave += Img_MouseLeave;
                    img.Stretch = Stretch.Fill;
                    img.Width = 40;
                    img.Height = 40;

                    Panel.SetZIndex(img, 1000000);

                    brd.Child = img;
                    Images.Add(img);

                    if (intCnt < 3)
                    {
                        ImageControls[s].Children.Add(brd);
                        intCnt++;
                    }
                    else
                    {
                        s++;
                        intCnt = 1;
                        ImageControls[s].Children.Add(brd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            if(ImageControls.Length % 3==0)
            {
                lastPage = ImageControls.Length / 3;
            }
            else
            {
                lastPage = ImageControls.Length / 3 + 1;
            }
           

        }

        //Slide images in Up or Down direction
        private void Play_Image_Slider(string strDirection)
        {
            try
            {
                if (ImageControls.Length == 1)
                    return;
                var oldCtrlIndex = CurrentCtrlIndex;

                if (strDirection == "UpSide")
                {
                    TransitionType = TransitionEffects[1].ToString();
                    if (CurrentCtrlIndex == 0) //đang ở trang đầu
                    {
                        if (ImageControls.Length % 3 == 0)
                        {
                            CurrentCtrlIndex = ImageControls.Length / 3;
                        }
                        else
                        {
                            CurrentCtrlIndex = (ImageControls.Length / 3 + 1);
                        }
                    }
                    else // không ở trang đầu
                        CurrentCtrlIndex--;
                }
                else
                {
                    TransitionType = TransitionEffects[0].ToString();
                    if (CurrentCtrlIndex == lastPage) //đang ở trang cuối
                        CurrentCtrlIndex = 0;
                    else // không ở trang cuối
                        CurrentCtrlIndex++;
                }

                WrapPanel oldImage = ImageControls[oldCtrlIndex];
                WrapPanel newImage = ImageControls[CurrentCtrlIndex];

                //For Animation of opacity......
                Storyboard DefaultPosition = (Resources["SlideAndFadeIn"] as Storyboard).Clone();
                DefaultPosition.Begin(newImage);

                //For Sliding....
                Storyboard hidePage = (Resources[string.Format("{0}Out", TransitionType.ToString())] as Storyboard).Clone();
                hidePage.Begin(oldImage);
                Storyboard showNewPage = Resources[string.Format("{0}In", TransitionType.ToString())] as Storyboard;
                showNewPage.Begin(newImage);

                // ẩn nút next, previous
                if (CurrentCtrlIndex == lastPage-1) // trang cuối
                {
                    imgDown.Visibility = Visibility.Hidden;
                }
                else
                {
                    imgDown.Visibility = Visibility.Visible;
                }
                if (CurrentCtrlIndex == 0)
                {
                    imgUp.Visibility = Visibility.Hidden;
                }
                else
                {
                    imgUp.Visibility = Visibility.Visible;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Images slide up
        private void imgUp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int tempIndex;
                if ((CurrentCtrlIndex - 1) == -1)
                    tempIndex = (ImageControls.Length - 1);
                else
                    tempIndex = (CurrentCtrlIndex - 1);
                if (ImageControls[tempIndex].Visibility == System.Windows.Visibility.Hidden)
                    ImageControls[tempIndex].Visibility = System.Windows.Visibility.Visible;

                Play_Image_Slider("UpSide");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Images slide down
        private void imgDown_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int tempIndex;
                if (CurrentCtrlIndex == ImageControls.Length / 3)
                    tempIndex = 0;
                else
                    tempIndex = (CurrentCtrlIndex + 1);
                if (ImageControls[tempIndex].Visibility == System.Windows.Visibility.Hidden)
                    ImageControls[tempIndex].Visibility = System.Windows.Visibility.Visible;

                Play_Image_Slider("DownSide");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Img_MouseLeave(object sender, MouseEventArgs e)
        {
            pnlImageView.IsOpen = false;
        }

        private void Img_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                string strImageSource = (sender as Image).Source.ToString();
                imgView.Source = new ImageSourceConverter().ConvertFromString(strImageSource) as ImageSource;
                pnlImageView.IsOpen = true;
                for (int i = 0; i < Images.Count; i++)
                {
                    if (Images[i].Source.ToString() == strImageSource)
                    {
                        LabelPopup.Content = lstText[i];
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Img_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string strImageSource = (sender as Image).Source.ToString();
            for (int i = 0; i < Images.Count; i++)
            {
                if (Images[i].Source.ToString() == strImageSource)
                {
                    ShowBorderImageFocus(i);
                    PlayVoidIndex(i);
                    return;
                }
            }
        }

        #endregion
        public void ShowBorderImageFocus(int index)
        {
            for (int i = 0; i < Borders.Count; i++)
            {
                Borders[i].BorderBrush = Brushes.Green;
                BigImage.Source = Images[0].Source;
            }
            if (index < Borders.Count && index >= 0)
            {
                Borders[index].BorderBrush = Brushes.Red;
                BigImage.Source = Images[index].Source;
                SlideToPage(index);
            }  
            if(index <0)
            {     
                SlideToPage(0);
            }    
      


        }
        public void SlideToPage(int index)
        {
            while (CurrentCtrlIndex != index / 3)
            {
                if (index / 3 < CurrentCtrlIndex)
                {
                    try
                    {
                        int tempIndex;
                        if ((CurrentCtrlIndex - 1) == -1)
                            tempIndex = (ImageControls.Length - 1);
                        else
                            tempIndex = (CurrentCtrlIndex - 1);
                        if (ImageControls[tempIndex].Visibility == System.Windows.Visibility.Hidden)
                            ImageControls[tempIndex].Visibility = System.Windows.Visibility.Visible;

                        Play_Image_Slider("UpSide");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                if (index / 3 > CurrentCtrlIndex)
                {
                    try
                    {
                        int tempIndex;
                        if (CurrentCtrlIndex == ImageControls.Length / 3)
                            tempIndex = 0;
                        else
                            tempIndex = (CurrentCtrlIndex + 1);
                        if (ImageControls[tempIndex].Visibility == System.Windows.Visibility.Hidden)
                            ImageControls[tempIndex].Visibility = System.Windows.Visibility.Visible;

                        Play_Image_Slider("DownSide");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        public void PlayVoidIndex(int index)
        {
            StopMediaVoid();
            IsFullSoundClick = false;
            IndexMedia = index;
            mediaSoundWord[index].Play();
            ChangeLineFocus(index);
            GridPanel.IsEnabled = false;
        }
        public void StopMediaVoid()
        {
            foreach (MediaPlayer x in mediaSoundWord)
            {
                x.Stop();
            }
        }
    }
}
