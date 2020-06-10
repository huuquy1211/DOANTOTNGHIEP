using BLL;
using GameLearnEnlish.Model;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLearnEnlish.UserControls
{
    /// <summary>
    /// Interaction logic for UC_Matching.xaml
    /// </summary>
    public partial class UC_Matching : UserControl
    {
        public static UC_Matching uC_Matching = null;
        private int Unit = 1;
        private bool Question1 = false;//Bấm vào câu hỏi 1
        private bool Question2 = false;//Bấm vào câu hỏi 2
        private bool Question3 = false;//Bấm vào câu hỏi 3

        private bool Answer1 = false;//Bấm vào câu trả lời 1
        private bool Answer2 = false;//Bấm vào câu trả lời 2
        private bool Answer3 = false;//Bấm vào câu trả lời 3

        private bool HiddenQuestion1 = false;//Ẩn câu hỏi 1 khi chọn đúng
        private bool HiddenQuestion2 = false;//Ẩn câu hỏi 2 khi chọn đúng
        private bool HiddenQuestion3 = false;//Ẩn câu hỏi 3 khi chọn đúng

        private bool HiddenAnswer1 = false;//Ẩn câu trả lời 1 khi chọn đúng
        private bool HiddenAnswer2 = false;//Ẩn câu trả lời 2 khi chọn đúng
        private bool HiddenAnswer3 = false;//Ẩn câu trả lời 3 khi chọn đúng


        private bool IsClickFirst = false;//Bấm vào câu hỏi lần đầu
        private bool IsClickQuestion = false;//Bấm vào câu hỏi



        private bool CheckHiddenAnswer1 = false;//Ẩn câu hỏi 1
        private bool CheckHiddenAnswer2 = false;//Ẩn câu hỏi 2
        private bool CheckHiddenAnswer3 = false;//Ẩn câu hỏi 3

        private Line line = new Line();


        private MediaPlayer mediaPlayerVoid1 = new MediaPlayer();
        private MediaPlayer mediaPlayerVoid2 = new MediaPlayer();
        private MediaPlayer mediaPlayerVoid3 = new MediaPlayer();
        private MediaPlayer mediaPlayerVoidStart = new MediaPlayer();
        private MediaPlayer mediaPlayerVoiceDescription = new MediaPlayer();//Khởi tạo âm Description

        private MediaPlayer mediaPlayerVoidCorrect = new MediaPlayer();
        private MediaPlayer mediaPlayerVoidClickCard = new MediaPlayer();
        private MediaPlayer mediaPlayerVoiInCorrect = new MediaPlayer();

        private List<Data.Word> lstWord = new List<Data.Word>();

        private List<string> ListImgWord = new List<string>();//danh sách hình ảnh của từ
        private List<int> ListImgSort = new List<int>();//vị trí của 3 bức ảnh.
        private List<int> ListVoidSort = new List<int>();//vị trí của 3 âm thanh.
        private List<string> ListVoidWord = new List<string>();//danh sách âm thanh của từ


        public int numImageClick;//vị trí hình vừa chọn

        private readonly string VoidCorrect = @"..\..\media\audio\matching\right.mp3";//âm khi chọn câu trả lời đúng
        private readonly string VoidClickCard = @"..\..\media\audio\matching\click_card.mp3";//âm khi chọn câu trả lời đúng
        private readonly string VoidInCorrect = @"..\..\media\audio\matching\wrong.mp3";//âm khi chọn câu trả lời sai
        private readonly string VoidStart = @"..\..\media\audio\matching\title.mp3";//âm khi khởi động
        private string VoiceDescription = @"..\..\media\audio\matching\description.mp3";//âm description
        private string TextDescription = "Listen and match.";

        public UC_Matching(int unit)
        {
            uC_Matching = this;
            InitializeComponent();
            Unit = unit;
            StartApp();//Khong thao tác khi đang khởi động
            
            CreateQuestionAndAnswer();//Khởi tạo câu hỏi và câu trả lời

            mediaPlayerVoidStart.Open(new Uri(VoidStart, UriKind.Relative));//Âm thanh title
            mediaPlayerVoidStart.Stop();
            //Phát âm thanh title
            mediaPlayerVoidStart.Play();

            Global.Instance.WindowMain.grdUC_Description.Children.Clear();
            Global.Instance.WindowMain.grdUC_Description.Children.Add(new UC_Description());//Gọi UC Description
            UC_Description.uC_Description.CallTextDescription(TextDescription);//Gọi UC Description truyền TextDescription

            mediaPlayerVoiceDescription.Open(new Uri(VoiceDescription, UriKind.Relative));
            mediaPlayerVoiceDescription.Stop();
            
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
                Thread.Sleep(2000);
                FinishStartApp(); //Khởi động xong
            });

        }

        #region [Hàm dùng chung]
        //Khởi tạo list câu hỏi và câu trả lời
        public void CreateQuestionAndAnswer()
        {
            lstWord = new WordBLL().GetWordsOfUnit(Unit);
            ListImgWord.Clear();
            ListImgSort.Clear();

            ListVoidWord.Clear();
            ListVoidSort.Clear();


            #region media

            mediaPlayerVoidCorrect.Open(new Uri(VoidCorrect, UriKind.Relative));
            mediaPlayerVoidClickCard.Open(new Uri(VoidClickCard, UriKind.Relative));
            mediaPlayerVoiInCorrect.Open(new Uri(VoidInCorrect, UriKind.Relative));
            #endregion

            string pathLinkImg = @"..\..\media\textures\matching\act" + Unit;
            string pathVoidWord = @"..\..\media\audio\matching\act" + Unit;
            Random rd = new Random();
            int rand = 0;
            for (int i = 1; i <= 3; i++)
            {
                bool temp = false;

                while (temp == false)
                {
                    bool flag = false;
                    rand = (rd.Next(1, 1000) % 3) + 1;
                    if (rand <= 3 && rand >= 1)
                    {
                        for (int j = 0; j < ListImgSort.Count; j++)
                        {
                            if (ListImgSort[j] == rand)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            //ListImgWord.Add(pathLinkImg + @"\img" + rand + ".png");
                            ListImgWord.Add(lstWord[rand - 1].Image);
                            ListImgSort.Add(rand);
                            temp = true;
                        }


                    }
                }
            }


            for (int i = 1; i <= 3; i++)
            {
                bool temp = false;

                while (temp == false)
                {
                    bool flag = false;
                    rand = (rd.Next(1, 1000) % 3) + 1;
                    if (rand <= 3 && rand >= 1)
                    {
                        for (int j = 0; j < ListVoidWord.Count; j++)
                        {
                            if (ListVoidSort[j] == rand)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            //ListVoidWord.Add(pathVoidWord + @"\sound" + rand + ".mp3");
                            ListVoidWord.Add(lstWord[rand - 1].Voice);
                            ListVoidSort.Add(rand);
                            temp = true;
                        }


                    }
                }
            }

            imgImg1.Source = new BitmapImage(new Uri(ListImgWord[0], UriKind.Relative));
            imgImg2.Source = new BitmapImage(new Uri(ListImgWord[1], UriKind.Relative));
            imgImg3.Source = new BitmapImage(new Uri(ListImgWord[2], UriKind.Relative));//Khởi tạo các hình ảnh ramdom cho câu trả lời

            imgImg1.IsEnabled = false;
            imgImg2.IsEnabled = false;
            imgImg3.IsEnabled = false;
            imgNode1a.IsEnabled = false;
            imgNode2a.IsEnabled = false;
            imgNode3a.IsEnabled = false;//Không cho thao tác với câu trả lời khi chưa chọn câu hỏi


        }
        public void StopVoid()//Tắt âm thanh
        {
            mediaPlayerVoiInCorrect.Stop();
            mediaPlayerVoidClickCard.Stop();
            mediaPlayerVoidCorrect.Stop();
            mediaPlayerVoidStart.Stop();
            mediaPlayerVoid3.Stop();
            mediaPlayerVoid2.Stop();
            mediaPlayerVoid1.Stop();
            mediaPlayerVoiceDescription.Stop();
        }
        public void StartApp()//Khong thao tác khi đang khởi động
        {
            this.Dispatcher.Invoke(() =>
            {
                lblQuestion1.IsEnabled = false;
                imgGuyaudio1.IsEnabled = false;
                imgNode1.IsEnabled = false;


                lblQuestion2.IsEnabled = false;
                imgGuyaudio2.IsEnabled = false;
                imgNode2.IsEnabled = false;

                lblQuestion3.IsEnabled = false;
                imgGuyaudio3.IsEnabled = false;
                imgNode3.IsEnabled = false;

                this.Cursor = Cursors.No;
            });

        }

        public void FinishStartApp() //Khởi động xong
        {
            this.Dispatcher.Invoke(() =>
            {
                lblQuestion1.IsEnabled = true;
                imgGuyaudio1.IsEnabled = true;
                imgNode1.IsEnabled = true;

                lblQuestion2.IsEnabled = true;
                imgGuyaudio2.IsEnabled = true;
                imgNode2.IsEnabled = true;

                lblQuestion3.IsEnabled = true;
                imgGuyaudio3.IsEnabled = true;
                imgNode3.IsEnabled = true;
                this.Cursor = Cursors.Arrow;
            });

        }
        //Ẩn các câu hỏi khi 1 câu hỏi được click
        public void IsHiddenQuestion(string NameQuestion)
        {
            if (NameQuestion != null)
            {
                switch (NameQuestion)
                {
                    case "Question1":
                        {
                            lblQuestion1.IsEnabled = false;
                            imgGuyaudio1.IsEnabled = false;
                            imgNode1.IsEnabled = false;

                            imgGuyaudio1.Opacity = 0.4;
                            lblQuestion1.Opacity = 0.4;
                            imgNode1.Opacity = 0.4;


                            break;
                        }
                    case "Question2":
                        {

                            lblQuestion2.IsEnabled = false;
                            imgGuyaudio2.IsEnabled = false;
                            imgNode2.IsEnabled = false;

                            imgGuyaudio2.Opacity = 0.4;
                            lblQuestion2.Opacity = 0.4;
                            imgNode2.Opacity = 0.4;




                            break;
                        }
                    case "Question3":
                        {
                            lblQuestion3.IsEnabled = false;
                            imgGuyaudio3.IsEnabled = false;
                            imgNode3.IsEnabled = false;

                            imgGuyaudio3.Opacity = 0.4;
                            lblQuestion3.Opacity = 0.4;
                            imgNode3.Opacity = 0.4;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        //Ần câu trả lời khi đã dược trả lời
        public void IsHiddenAnswer(string NameAnswer)
        {
            if (NameAnswer != null)
            {
                switch (NameAnswer)
                {
                    case "Answer1":
                        {
                            imgImg1.IsEnabled = false;
                            imgNode1a.IsEnabled = false;
                            imgImg1.Opacity = 0.4;
                            imgNode1a.Opacity = 0.4;
                            CheckHiddenAnswer1 = true;
                            break;
                        }
                    case "Answer2":
                        {
                            imgImg2.IsEnabled = false;
                            imgNode2a.IsEnabled = false;
                            CheckHiddenAnswer2 = true;
                            imgImg2.Opacity = 0.4;
                            imgNode2a.Opacity = 0.4;

                            break;
                        }
                    case "Answer3":
                        {
                            imgImg3.IsEnabled = false;
                            imgNode3a.IsEnabled = false;
                            CheckHiddenAnswer3 = true;
                            imgImg3.Opacity = 0.4;
                            imgNode3a.Opacity = 0.4;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        //Cho phép thao tác trên câu hỏi
        public void IsEnabledAnswer(string NameAnswer)
        {
            if (NameAnswer != null)
            {
                switch (NameAnswer)
                {
                    case "Answer1":
                        {
                            imgImg1.IsEnabled = true;
                            imgNode1a.IsEnabled = true;
                            imgImg1.Cursor = Cursors.Hand;
                            imgNode1a.Cursor = Cursors.Hand;
                            break;
                        }
                    case "Answer2":
                        {
                            imgImg2.IsEnabled = true;
                            imgNode2a.IsEnabled = true;
                            imgImg2.Cursor = Cursors.Hand;
                            imgNode2a.Cursor = Cursors.Hand;
                            break;
                        }
                    case "Answer3":
                        {
                            imgImg3.IsEnabled = true;
                            imgNode3a.IsEnabled = true;
                            imgImg3.Cursor = Cursors.Hand;
                            imgNode3a.Cursor = Cursors.Hand;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        //Không cho phép thao tác trên câu hỏi
        public void NotEnableAnswer(string NameAnswer)
        {
            if (NameAnswer != null)
            {
                switch (NameAnswer)
                {
                    case "Answer1":
                        {
                            imgImg1.IsEnabled = false;
                            imgNode1a.IsEnabled = false;
                            break;
                        }
                    case "Answer2":
                        {
                            imgImg2.IsEnabled = false;
                            imgNode2a.IsEnabled = false;
                            break;
                        }
                    case "Answer3":
                        {
                            imgImg3.IsEnabled = false;
                            imgNode3a.IsEnabled = false;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        //Hiện câu hỏi
        public void IsVisibleQuestion(string NameQuestion)
        {
            if (NameQuestion != null)
            {
                switch (NameQuestion)
                {
                    case "Question1":
                        {
                            lblQuestion1.IsEnabled = true;
                            imgGuyaudio1.IsEnabled = true;
                            imgNode1.IsEnabled = true;

                            imgGuyaudio1.Opacity = 1;
                            lblQuestion1.Opacity = 1;
                            imgNode1.Opacity = 1;

                            break;
                        }
                    case "Question2":
                        {
                            lblQuestion2.IsEnabled = true;
                            imgGuyaudio2.IsEnabled = true;
                            imgNode2.IsEnabled = true;

                            imgGuyaudio2.Opacity = 1;
                            lblQuestion2.Opacity = 1;
                            imgNode2.Opacity = 1;
                            break;
                        }
                    case "Question3":
                        {
                            lblQuestion3.IsEnabled = true;
                            imgGuyaudio3.IsEnabled = true;
                            imgNode3.IsEnabled = true;

                            imgGuyaudio3.Opacity = 1;
                            lblQuestion3.Opacity = 1;
                            imgNode3.Opacity = 1;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        #endregion

        #region [Question 1]

        private void Question1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //var startPoint = e.GetPosition(imgNode1);
            if (IsClickQuestion == false)//Nếu chưa bấm vào câu hỏi
            {
                IsClickFirst = true; //Lần đầu bấm vào câu hỏi
                mediaPlayerVoid1.Open(new Uri(ListVoidWord[0], UriKind.Relative));
                mediaPlayerVoid1.Play();
                Question1 = true;//Câu hỏi đã được bấm vào

                IsHiddenQuestion("Question2");
                IsHiddenQuestion("Question3");//Ẩn các câu hỏi cỏn lại

                if (HiddenAnswer1 == false)//Nếu câu trả lời chưa dược trả lời
                {
                    IsEnabledAnswer("Answer1");//Cho phép thao tác với câu hỏi
                }
                if (HiddenAnswer2 == false)//Nếu câu trả lời chưa dược trả lời
                {
                    IsEnabledAnswer("Answer2");//Cho phép thao tác với câu hỏi
                }
                if (HiddenAnswer3 == false)//Nếu câu trả lời chưa dược trả lời
                {
                    IsEnabledAnswer("Answer3");//Cho phép thao tác với câu hỏi
                }

                if (grdUC_Matching.CaptureMouse())
                {
                    line = new Line();

                    line.Stroke = System.Windows.Media.Brushes.Aqua;
                    line.X1 = 255.875;
                    line.X2 = 255.875;
                    line.Y1 = 80.294117647058727;
                    line.Y2 = 80.294117647058727;

                    //line.X1 = startPoint.X;
                    //line.X2 = startPoint.X;
                    //line.Y1 = startPoint.Y;
                    //line.Y2 = startPoint.Y;
                    line.StrokeThickness = 7;
                    grdUC_Matching.Children.Add(line);
                    //IsClickQuestion = true;
                }
            }
            IsClickQuestion = true;//Đã bấm vào câu hỏi
        }


        private void Question1_MouseEnter(object sender, MouseEventArgs e)
        {

            imgGuyaudio1.Opacity = 0.8;
            lblQuestion1.Opacity = 0.8;
            imgNode1.Opacity = 0.8;
        }

        private void Question1_MouseLeave(object sender, MouseEventArgs e)
        {
            imgGuyaudio1.Opacity = 1;
            lblQuestion1.Opacity = 1;
            imgNode1.Opacity = 1;
        }

        #endregion

        #region [Question 2]

        private void Question2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsClickQuestion == false)//Nếu chưa bấm vào câu hỏi
            {
                IsClickFirst = true;
                mediaPlayerVoid2.Open(new Uri(ListVoidWord[1], UriKind.Relative));
                mediaPlayerVoid2.Play();
                Question2 = true;

                IsHiddenQuestion("Question1");
                IsHiddenQuestion("Question3");//Ẩn các câu hỏi cỏn lại

                if (HiddenAnswer1 == false)//Nếu câu trả lời chưa dược trả lời
                {
                    IsEnabledAnswer("Answer1");//Cho phép thao tác với câu hỏi
                }
                if (HiddenAnswer2 == false)//Nếu câu trả lời chưa dược trả lời
                {
                    IsEnabledAnswer("Answer2");//Cho phép thao tác với câu hỏi
                }
                if (HiddenAnswer3 == false)//Nếu câu trả lời chưa dược trả lời
                {
                    IsEnabledAnswer("Answer3");//Cho phép thao tác với câu hỏi
                }

                if (grdUC_Matching.CaptureMouse())
                {

                    line = new Line();
                    line.Stroke = System.Windows.Media.Brushes.Aqua;
                    line.X1 = 255.875;
                    line.X2 = 255.875;
                    line.Y1 = 251.29411764705873;
                    line.Y2 = 251.29411764705873;
                    line.StrokeThickness = 7;
                    grdUC_Matching.Children.Add(line);
                    //IsClickQuestion = true;
                }
            }
            IsClickQuestion = true;//Đã bấm vào câu hỏi


        }

        private void Question2_MouseEnter(object sender, MouseEventArgs e)
        {

            imgGuyaudio2.Opacity = 0.8;
            lblQuestion2.Opacity = 0.8;
            imgNode2.Opacity = 0.8;
        }

        private void Question2_MouseLeave(object sender, MouseEventArgs e)
        {
            imgGuyaudio2.Opacity = 1;
            lblQuestion2.Opacity = 1;
            imgNode2.Opacity = 1;
        }
        #endregion

        #region [Question 3]
        private void Question3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsClickQuestion == false)//Nếu chưa bấm vào câu hỏi
            {
                IsClickFirst = true;
                mediaPlayerVoid3.Open(new Uri(ListVoidWord[2], UriKind.Relative));
                mediaPlayerVoid3.Play();
                Question3 = true;

                IsHiddenQuestion("Question1");
                IsHiddenQuestion("Question2");//Ẩn các câu hỏi cỏn lại

                if (HiddenAnswer1 == false)//Nếu câu trả lời chưa dược trả lời
                {
                    IsEnabledAnswer("Answer1");//Cho phép thao tác với câu hỏi
                }
                if (HiddenAnswer2 == false)//Nếu câu trả lời chưa dược trả lời
                {
                    IsEnabledAnswer("Answer2");//Cho phép thao tác với câu hỏi
                }
                if (HiddenAnswer3 == false)//Nếu câu trả lời chưa dược trả lời
                {
                    IsEnabledAnswer("Answer3");//Cho phép thao tác với câu hỏi
                }

                if (grdUC_Matching.CaptureMouse())
                {
                    line = new Line();
                    line.Stroke = System.Windows.Media.Brushes.Aqua;
                    line.X1 = 255.875;
                    line.X2 = 255.875;
                    line.Y1 = 413.29411764705873;
                    line.Y2 = 413.29411764705873;
                    line.StrokeThickness = 7;
                    grdUC_Matching.Children.Add(line);
                    //IsClickQuestion = true;
                }
            }
            IsClickQuestion = true;//Đã bấm vào câu hỏi

        }
        private void Question3_MouseEnter(object sender, MouseEventArgs e)
        {
            imgGuyaudio3.Opacity = 0.8;
            lblQuestion3.Opacity = 0.8;
            imgNode3.Opacity = 0.8;
        }
        private void Question3_MouseLeave(object sender, MouseEventArgs e)
        {
            imgGuyaudio3.Opacity = 1;
            lblQuestion3.Opacity = 1;
            imgNode3.Opacity = 1;

        }
        #endregion

        #region [Tạo đường nối giữa câu hỏi và câu trả lời]
        private void grdUC_Matching_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (Question1 == true && IsClickFirst == false)//Câu hỏi 1 được chọn và không phải lần đầu bấm vào màng hình
            {
                //mediaPlayerVoidCorrect.Stop();
                //mediaPlayerVoiInCorrect.Stop();//Xóa âm thanh khi bấm vào
                if (Answer1 == false || Answer2 == false || Answer3 == false) //Các câu trả lời chưa dược chọn
                {
                    grdUC_Matching.Children.Remove(line);//xóa dường vẽ
                    Question1 = false;//Câu hỏi không còn dược chọn nữa
                    IsClickQuestion = false;//Chưa bấm vào câu hỏi
                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    //mediaPlayerVoiInCorrect.Play(); //Phát âm thanh khi chọn ra ngoài

                }
                NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi

            }

            if (Question2 == true && IsClickFirst == false)//Câu hỏi 2 được chọn và không phải lần đầu bấm vào màng hình
            {
                //mediaPlayerVoidCorrect.Stop();
                //mediaPlayerVoiInCorrect.Stop();//Xóa âm thanh khi bấm vào
                if (Answer1 == false || Answer2 == false || Answer3 == false) //Các câu trả lời chưa dược chọn
                {
                    grdUC_Matching.Children.Remove(line);//xóa dường vẽ
                    Question2 = false;//Câu hỏi không còn dược chọn nữa
                    IsClickQuestion = false;//Chưa bấm vào câu hỏi
                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    //mediaPlayerVoiInCorrect.Play(); //Phát âm thanh khi chọn ra ngoài
                }
                NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi

            }

            if (Question3 == true && IsClickFirst == false)//Câu hỏi 3 được chọn và không phải lần đầu bấm vào màng hình
            {
                //mediaPlayerVoidCorrect.Stop();
                //mediaPlayerVoiInCorrect.Stop();//Xóa âm thanh khi bấm vào
                if (Answer1 == false || Answer2 == false || Answer3 == false) //Các câu trả lời chưa dược chọn
                {
                    grdUC_Matching.Children.Remove(line);//xóa dường vẽ
                    Question3 = false;//Câu hỏi không còn dược chọn nữa
                    IsClickQuestion = false;//Chưa bấm vào câu hỏi
                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }
                    //mediaPlayerVoiInCorrect.Play(); //Phát âm thanh khi chọn ra ngoài
                }
                NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi

            }
            IsClickFirst = false;//Set thuộc tính không phải lần đầu nữa
        }
        private void grdUC_Matching_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (grdUC_Matching).ReleaseMouseCapture();
        }
        private void grdUC_Matching_MouseMove(object sender, MouseEventArgs e)
        {
            var line = grdUC_Matching.Children.OfType<Line>().LastOrDefault();

            if (line != null)
            {
                var endPoint = e.GetPosition(grdUC_Matching);
                line.X2 = endPoint.X - 5;
                line.Y2 = endPoint.Y - 5;
            }
        }


        #endregion


        #region [Answer1]

        private void Answer1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayerVoidCorrect.Stop();
            mediaPlayerVoidClickCard.Stop();
            mediaPlayerVoiInCorrect.Stop();//Tắt âm trước khi phát
            Answer1 = true;//Câu trả lời được bấm vào
            if (Question1 == true)
            {
                if (ListImgSort[0] == ListVoidSort[0])
                {
                    line = new Line();
                    grdUC_Matching.Children.Add(line);
                    IsHiddenAnswer("Answer1");
                    IsHiddenQuestion("Question1");

                    HiddenAnswer1 = true;
                    HiddenQuestion1 = true; //Câu hỏi và câu trả lời đã bị ẩn

                    Question1 = false; //Câu hỏi không còn được chọn nữa

                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }

                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi

                    IsClickQuestion = false;//Set câu hỏi chưa được chọn

                    mediaPlayerVoidCorrect.Play();//Phát ra âm chọn đúng
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click

                    //if (HiddenAnswer1 == true && HiddenQuestion1 == true && HiddenAnswer2 == true && HiddenQuestion2 == true && HiddenAnswer3 == true && HiddenQuestion3 == true)//Nếu tất cả câu trả lời đều được chọn
                    //{

                    //}

                    return;
                }
                else
                {
                    Question1 = false; //Câu hỏi không còn được chọn nữa
                    grdUC_Matching.Children.Remove(line);//Xóa đường vẽ

                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn

                    HiddenAnswer1 = false;
                    HiddenQuestion1 = false; //Câu hỏi và câu trả lời chưa ẩn
                    mediaPlayerVoiInCorrect.Play();//Phá ra âm chọn sai
                    return;
                }
            }
            if (Question2 == true)
            {
                if (ListImgSort[0] == ListVoidSort[1])
                {
                    line = new Line();

                    grdUC_Matching.Children.Add(line);
                    IsHiddenAnswer("Answer1");
                    IsHiddenQuestion("Question2");

                    HiddenAnswer1 = true;
                    HiddenQuestion2 = true; //Câu hỏi và câu trả lời đã bị ẩn
                    Question2 = false;

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn
                    mediaPlayerVoidCorrect.Play();//Phát ra âm chọn đúng
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click
                    return;

                }
                else
                {
                    Question2 = false;
                    grdUC_Matching.Children.Remove(line);
                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn

                    HiddenAnswer1 = false;
                    HiddenQuestion2 = false; //Câu hỏi và câu trả lời chưa ẩn
                    mediaPlayerVoiInCorrect.Play();//Phá ra âm chọn sai
                    return;
                }
            }
            if (Question3 == true)
            {
                if (ListImgSort[0] == ListVoidSort[2])
                {
                    line = new Line();
                    grdUC_Matching.Children.Add(line);

                    IsHiddenAnswer("Answer1");
                    IsHiddenQuestion("Question3");
                    HiddenAnswer1 = true;
                    HiddenQuestion3 = true; //Câu hỏi và câu trả lời đã bị ẩn
                    Question3 = false;

                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn
                    mediaPlayerVoidCorrect.Play();//Phát ra âm chọn đúng
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click
                    return;
                }
                else
                {
                    Question3 = false;
                    grdUC_Matching.Children.Remove(line);
                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn

                    HiddenAnswer1 = false;
                    HiddenQuestion3 = false; //Câu hỏi và câu trả lời chưa ẩn
                    mediaPlayerVoiInCorrect.Play();//Phá ra âm chọn sai
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click
                    return;
                }
            }
        }
        private void Answer1_MouseEnter(object sender, MouseEventArgs e)
        {
            imgImg1.Opacity = 0.8;
            imgNode1a.Opacity = 0.8;
        }

        private void Answer1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CheckHiddenAnswer1 == false)
            {
                imgImg1.Opacity = 1;
                imgNode1a.Opacity = 1;
            }

        }
        #endregion

        #region [Answer2]

        private void Answer2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayerVoidCorrect.Stop();
            mediaPlayerVoidClickCard.Stop();
            mediaPlayerVoiInCorrect.Stop();//Tắt các âm trước khi phát
            if (Question1 == true)
            {
                if (ListImgSort[1] == ListVoidSort[0])
                {
                    line = new Line();

                    grdUC_Matching.Children.Add(line);
                    IsHiddenAnswer("Answer2");
                    IsHiddenQuestion("Question1");
                    HiddenAnswer2 = true;
                    HiddenQuestion1 = true; //Câu hỏi và câu trả lời đã bị ẩn
                    Question1 = false;

                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn
                    mediaPlayerVoidCorrect.Play();//Phát ra âm chọn đúng
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click
                    return;
                }
                else
                {
                    Question1 = false;
                    grdUC_Matching.Children.Remove(line);

                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn

                    HiddenAnswer2 = false;
                    HiddenQuestion1 = false; //Câu hỏi và câu trả lời chưa ẩn
                    mediaPlayerVoiInCorrect.Play();//Phát ra âm chọn sai
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click
                    return;
                }
            }
            if (Question2 == true)
            {
                if (ListImgSort[1] == ListVoidSort[1])
                {
                    line = new Line();
                    grdUC_Matching.Children.Add(line);
                    IsHiddenAnswer("Answer2");
                    IsHiddenQuestion("Question2");
                    HiddenAnswer2 = true;
                    HiddenQuestion2 = true; //Câu hỏi và câu trả lời đã bị ẩn

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    Question2 = false;

                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn
                    mediaPlayerVoidCorrect.Play();//Phát ra âm chọn đúng
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click
                    return;

                }
                else
                {
                    Question2 = false;
                    grdUC_Matching.Children.Remove(line);

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }

                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn

                    HiddenAnswer2 = false;
                    HiddenQuestion2 = false; //Câu hỏi và câu trả lời chưa ẩn
                    mediaPlayerVoiInCorrect.Play();//Phá ra âm chọn sai
                    return;
                }
            }
            if (Question3 == true)
            {
                if (ListImgSort[1] == ListVoidSort[2])
                {
                    line = new Line();

                    grdUC_Matching.Children.Add(line);
                    IsHiddenAnswer("Answer2");
                    IsHiddenQuestion("Question3");
                    HiddenAnswer2 = true;
                    HiddenQuestion3 = true; //Câu hỏi và câu trả lời đã bị ẩn

                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }
                    Question3 = false;

                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn
                    mediaPlayerVoidCorrect.Play();//Phát ra âm chọn đúng
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click
                    return;
                }
                else
                {
                    Question3 = false;
                    grdUC_Matching.Children.Remove(line);

                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }

                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn

                    HiddenAnswer2 = false;
                    HiddenQuestion3 = false; //Câu hỏi và câu trả lời chưa ẩn
                    mediaPlayerVoiInCorrect.Play();//Phá ra âm chọn sai
                    return;
                }
            }
        }
        private void Answer2_MouseEnter(object sender, MouseEventArgs e)
        {
            imgImg2.Opacity = 0.8;
            imgNode2a.Opacity = 0.8;
        }
        private void Answer2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CheckHiddenAnswer2 == false)
            {
                imgImg2.Opacity = 1;
                imgNode2a.Opacity = 1;
            }
        }
        #endregion


        #region [Answer3]
        private void Answer3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mediaPlayerVoidCorrect.Stop();
            mediaPlayerVoidClickCard.Stop();
            mediaPlayerVoiInCorrect.Stop();//Tắt các âm khi bấm vào
            if (Question1 == true)
            {
                if (ListImgSort[2] == ListVoidSort[0])
                {
                    line = new Line();

                    grdUC_Matching.Children.Add(line);

                    IsHiddenAnswer("Answer3");
                    IsHiddenQuestion("Question1");
                    HiddenAnswer3 = true;
                    HiddenQuestion1 = true; //Câu hỏi và câu trả lời đã bị ẩn
                    Question1 = false;

                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn
                    mediaPlayerVoidCorrect.Play();//Phát ra âm chọn đúng
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click
                    return;
                }
                else
                {
                    Question1 = false;
                    grdUC_Matching.Children.Remove(line);

                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn

                    HiddenAnswer3 = false;
                    HiddenQuestion1 = false; //Câu hỏi và câu trả lời chưa ẩn
                    mediaPlayerVoiInCorrect.Play();//Phá ra âm chọn sai
                    return;
                }
            }
            if (Question2 == true)
            {
                if (ListImgSort[2] == ListVoidSort[1])
                {
                    line = new Line();

                    grdUC_Matching.Children.Add(line);
                    IsHiddenAnswer("Answer3");
                    IsHiddenQuestion("Question2");
                    HiddenAnswer3 = true;
                    HiddenQuestion2 = true; //Câu hỏi và câu trả lời đã bị ẩn
                    Question2 = false;

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn
                    mediaPlayerVoidCorrect.Play();//Phát ra âm chọn đúng
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click
                    return;

                }
                else
                {
                    Question2 = false;
                    grdUC_Matching.Children.Remove(line);

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn

                    HiddenAnswer3 = false;
                    HiddenQuestion2 = false; //Câu hỏi và câu trả lời chưa ẩn
                    mediaPlayerVoiInCorrect.Play();//Phá ra âm chọn sai
                    return;
                }
            }
            if (Question3 == true)
            {
                if (ListImgSort[2] == ListVoidSort[2])
                {
                    line = new Line();
                    grdUC_Matching.Children.Add(line);

                    IsHiddenAnswer("Answer3");
                    IsHiddenQuestion("Question3");
                    HiddenAnswer3 = true;
                    HiddenQuestion3 = true; //Câu hỏi và câu trả lời đã bị ẩn
                    Question3 = false;

                    if (HiddenQuestion2 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question2");//Hiện câu hỏi
                    }

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn
                    mediaPlayerVoidCorrect.Play();//Phát ra âm chọn đúng
                    mediaPlayerVoidClickCard.Play();//Phát ra âm click
                    return;
                }
                else
                {
                    Question3 = false;
                    grdUC_Matching.Children.Remove(line);

                    if (HiddenQuestion1 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question1");//Hiện câu hỏi
                    }

                    if (HiddenQuestion3 == false)//Nếu câu hỏi chưa dược trả lời
                    {
                        IsVisibleQuestion("Question3");//Hiện câu hỏi
                    }
                    NotEnableAnswer("Answer1");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer2");//Không cho phép thao tác với câu hỏi
                    NotEnableAnswer("Answer3");//Không cho phép thao tác với câu hỏi
                    IsClickQuestion = false;//Set câu hỏi chưa được chọn

                    HiddenAnswer3 = false;
                    HiddenQuestion3 = false; //Câu hỏi và câu trả lời chưa ẩn
                    mediaPlayerVoiInCorrect.Play();//Phá ra âm chọn sai
                    return;
                }
            }
        }
        private void Answer3_MouseEnter(object sender, MouseEventArgs e)
        {
            imgImg3.Opacity = 0.8;
            imgNode3a.Opacity = 0.8;
        }


        private void Answer3_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CheckHiddenAnswer3 == false)
            {
                imgImg3.Opacity = 1;
                imgNode3a.Opacity = 1;
            }

        }

        #endregion
    }
}
