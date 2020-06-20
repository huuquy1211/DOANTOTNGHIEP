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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLearnEnlish.UserControls
{
    /// <summary>
    /// Interaction logic for UC_MultipleChoice.xaml
    /// </summary>
    public partial class UC_MultipleChoice : UserControl
    {
        public static UC_MultipleChoice uC_MultipleChoice = null;
        //public static Thread threadVoidUC_MultipleChoice;
        private int Unit = 1;
        private int CountQuestion = 0;//Số câu hỏi
        private bool IsCreateNew = true;//Khởi tạo lần đầu

        //Nhấn vào câu trả lời
        private bool Answer1 = false;//Bấm vào câu trả lời 1
        private bool Answer2 = false;//Bấm vào câu trả lời 2
        private bool Answer3 = false;//Bấm vào câu trả lời 3


        private readonly string VoidStart = @"..\..\media\audio\multiplechoice\title.mp3";//âm khi khởi động

        private string TextDescription = "Look and listen. Choose.";//Nội dung Description
        private string VoiceDescription = @"..\..\media\audio\multiplechoice\description.mp3";//âm description
        private readonly string VoidCorrect = @"..\..\media\audio\global\right.mp3";//âm khi chọn câu trả lời đúng
        private readonly string VoidInCorrect = @"..\..\media\audio\global\wrong.mp3";//âm khi chọn câu trả lời sai
        //Âm thanh
        private MediaPlayer mediaPlayerVoidStart = new MediaPlayer();//Khởi tạo âm thanh khi khởi động

        private MediaPlayer mediaPlayerVoiceDescription = new MediaPlayer();//Khởi tạo âm Description
        private MediaPlayer mediaPlayerVoid = new MediaPlayer();//Âm thanh câu hỏi
        private MediaPlayer mediaPlayerVoidCorrect = new MediaPlayer();//Âm thanh câu trả lời đúng
        private MediaPlayer mediaPlayerVoiInCorrect = new MediaPlayer();//Âm thanh câu trả lời sai
        //Hình ảnh
        private Uri ImgCorrect = new Uri(@"..\..\media\textures\multipleChoice\correct.png", UriKind.Relative);//image khi chọn câu trả lời đúng
        private Uri ImgInCorrect = new Uri(@"..\..\media\textures\multipleChoice\wrong.png", UriKind.Relative);//image khi chọn câu trả lời sai


        private List<Data.Word> lstWord = new List<Data.Word>();
        private List<string> ListImgWord = new List<string>();//danh sách hình ảnh của từ
        private List<int> ListImgSort = new List<int>();//vị trí của 3 bức ảnh.
        private List<int> ListVoidSort = new List<int>();//vị trí của 3 âm thanh.
        private List<string> ListVoidWord = new List<string>();//danh sách âm thanh của từ


        public UC_MultipleChoice(int unit)
        {
            uC_MultipleChoice = this;
            InitializeComponent();
            Unit = unit;
            StartApp();//Không thao tác đến khi khởi động xong
            //Clear các âm thanh và câu hỏi trong danh sách
            ListVoidWord.Clear();
            ListVoidSort.Clear();

            try
            {
                CreateQuestionAndAnswer();//Khởi tạo danh sách câu hỏi và câu trả lời ngẫu nhiên
                mediaPlayerVoidStart.Open(new Uri(VoidStart, UriKind.Relative));//Âm thanh title
                mediaPlayerVoidStart.Stop();
                mediaPlayerVoidStart.Play();
                //Gọi UC Description
                Global.Instance.WindowMain.grdUC_Description.Children.Clear();
                Global.Instance.WindowMain.grdUC_Description.Children.Add(new UC_Description());
                UC_Description.uC_Description.CallTextDescription(TextDescription);
                //Âm thanh Description
                mediaPlayerVoiceDescription.Open(new Uri(VoiceDescription, UriKind.Relative));
                mediaPlayerVoiceDescription.Stop();

                //Âm thanh câu hỏi khi bắt đầu khởi động game
                mediaPlayerVoid.Open(new Uri(ListVoidWord[CountQuestion], UriKind.Relative));
                mediaPlayerVoid.Stop();

                if (CountQuestion < 3)
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(2000);
                        this.Dispatcher.Invoke(() =>
                        {
                            mediaPlayerVoiceDescription.Play();
                            Thread.Sleep(3000); //Chờ dể đọc xong Description
                            mediaPlayerVoid.Play();//Phát âm câu hỏi
                            NotEnableQuestionAndAnswer();//Ẩn các hình ảnh khi phát âm
                        });
                    }).ContinueWith((task) =>
                    {
                        Thread.Sleep(1000);
                        //Tự đọc câu hỏi khi khởi động
                        FinishStartApp();// khởi động xong //Hiện các câu trả lời và câu hỏi
                    });
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi khi khởi tạo UserControl!");
            }
        }

        public void StopVoid()//Tắt âm thanh
        {
            mediaPlayerVoiInCorrect.Stop();
            mediaPlayerVoidCorrect.Stop();
            mediaPlayerVoid.Stop();
            mediaPlayerVoidStart.Stop();
            mediaPlayerVoiceDescription.Stop();
        }
        public void CreateQuestionAndAnswer()
        {
            this.Dispatcher.Invoke(() =>
            {
                lstWord = new WordBLL().GetWordsOfUnit(Unit);
                ListImgWord.Clear();
                ListImgSort.Clear();
                mediaPlayerVoidCorrect.Stop();
                mediaPlayerVoiInCorrect.Stop();

                #region media

                mediaPlayerVoidCorrect.Open(new Uri(VoidCorrect, UriKind.Relative));
                mediaPlayerVoiInCorrect.Open(new Uri(VoidInCorrect, UriKind.Relative));
                #endregion

                string pathLinkImg = @"..\..\media\textures\multiplechoice\act" + Unit;
                string pathVoidWord = @"..\..\media\audio\multiplechoice\act" + Unit;
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
                                ListImgWord.Add(lstWord[rand - 1].Image);
                                ListImgSort.Add(rand);
                                temp = true;
                            }
                        }
                    }
                }

                if (IsCreateNew == true)
                {
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
                                    ListVoidWord.Add(lstWord[rand - 1].Voice);
                                    ListVoidSort.Add(rand);
                                    temp = true;
                                }


                            }
                        }
                    }
                }


                imgImg1.Source = new BitmapImage(new Uri(ListImgWord[0], UriKind.Relative));
                imgImg2.Source = new BitmapImage(new Uri(ListImgWord[1], UriKind.Relative));
                imgImg3.Source = new BitmapImage(new Uri(ListImgWord[2], UriKind.Relative));//Khởi tạo các hình ảnh ramdom cho câu trả lời

                //Các câu hỏi chưa được trả lời
                Answer1 = false;
                Answer2 = false;
                Answer3 = false;

                //Ẩn các dáp án
                imgAnswer1.Visibility = Visibility.Hidden;
                imgAnswer2.Visibility = Visibility.Hidden;
                imgAnswer3.Visibility = Visibility.Hidden;

            });
        }

        public void StartApp()//Không thao tác đến khi khởi động xong
        {
            this.Dispatcher.Invoke(() =>
            {
                this.Cursor = Cursors.No;
                imgCard_back.IsEnabled = false;
                imgImg1.IsEnabled = false;
                imgImg2.IsEnabled = false;
                imgImg3.IsEnabled = false;
            });
        }

        public void NotClickUI()//Không thao tác UI khi chọn câu trả lời
        {
            this.Dispatcher.Invoke(() =>
            {
                this.Cursor = Cursors.Arrow;
                imgCard_back.Cursor = Cursors.Arrow;
                imgCard_back.IsEnabled = false;
                imgImg1.IsEnabled = false;
                imgImg2.IsEnabled = false;
                imgImg3.IsEnabled = false;
            });
        }

        public void FinishStartApp()// khởi động xong
        {
            this.Dispatcher.Invoke(() =>
            {
                this.Cursor = Cursors.Arrow;
                imgCard_back.Opacity = 1;
                imgImg1.Opacity = 1;
                imgImg2.Opacity = 1;
                imgImg3.Opacity = 1;

                imgCard_back.IsEnabled = true;
                imgImg1.IsEnabled = true;
                imgImg2.IsEnabled = true;
                imgImg3.IsEnabled = true;
            });
        }
        public void NotEnableQuestionAndAnswer()
        {
            this.Dispatcher.Invoke(() =>
            {
                imgCard_back.Opacity = 0.4;
                imgCard_back.IsEnabled = false;
                imgImg1.IsEnabled = false;
                imgImg2.IsEnabled = false;
                imgImg3.IsEnabled = false;
                if (Answer1 == true)//Nếu đã trả lời sai
                {
                    imgImg1.Opacity = 1;
                }
                else
                {
                    imgImg1.Opacity = 0.4;
                }

                if (Answer2 == true)//Nếu đã trả lời sai
                {
                    imgImg2.Opacity = 1;
                }
                else
                {
                    imgImg2.Opacity = 0.4;
                }

                if (Answer3 == true)//Nếu đã trả lời sai
                {
                    imgImg3.Opacity = 1;
                }
                else
                {
                    imgImg3.Opacity = 0.4;
                }
            });

        }

        public void EnableQuestionAndAnswer()
        {
            this.Dispatcher.Invoke(() =>
            {
                imgCard_back.Opacity = 1;
                imgImg1.Opacity = 1;
                imgImg2.Opacity = 1;
                imgImg3.Opacity = 1;

                imgCard_back.IsEnabled = true;
                if (Answer1 == true)//Nếu đã trả lời sai
                {
                    imgImg1.IsEnabled = false;
                }
                else
                {
                    imgImg1.IsEnabled = true;
                }

                if (Answer2 == true)//Nếu đã trả lời sai
                {
                    imgImg2.IsEnabled = false;
                }
                else
                {
                    imgImg2.IsEnabled = true;
                }

                if (Answer3 == true)//Nếu đã trả lời sai
                {
                    imgImg3.IsEnabled = false;
                }
                else
                {
                    imgImg3.IsEnabled = true;
                }
            });
        }

        #region [Question]
        private void imgCard_back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (CountQuestion < 3)
                {
                    Task.Run(() =>
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            mediaPlayerVoid.Open(new Uri(ListVoidWord[CountQuestion], UriKind.Relative));
                            mediaPlayerVoid.Stop();
                            mediaPlayerVoid.Play();//Phát âm câu hỏi
                            NotEnableQuestionAndAnswer();//Ẩn các hình ảnh khi phát âm
                        });
                        Thread.Sleep(800);
                        //Phát âm và đợi xong thì tiếp tục thực hiện các bước dưới
                    }).ContinueWith((task) =>
                    {
                        EnableQuestionAndAnswer(); //Hiện các câu trả lời và câu hỏi
                    });
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi nhấn nút phát âm thanh!");
            }

        }
        #endregion

        #region [Answer]
        private void Answer1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (CountQuestion < 3)
                {
                    NotClickUI();//Không thao tác UI khi chọn câu trả lời
                    mediaPlayerVoidCorrect.Stop();// Tắt âm khi bấm vào
                    if (ListVoidSort[CountQuestion] == ListImgSort[0])//Nếu âm thanh trùng với hình ảnh
                    {
                        mediaPlayerVoidCorrect.Open(new Uri(VoidCorrect, UriKind.Relative));
                        mediaPlayerVoidCorrect.Play();//Phát âm trả lời đúng
                        imgAnswer1.Source = new BitmapImage(ImgCorrect);//Hình đúng
                        imgAnswer1.Visibility = Visibility.Visible;
                        CountQuestion++;//Nếu trả lời đúng thì tăng số câu hỏi lên 1
                    }
                    else
                    {
                        Answer1 = true; //Đã trả lời sai
                        mediaPlayerVoidCorrect.Open(new Uri(VoidInCorrect, UriKind.Relative));
                        mediaPlayerVoidCorrect.Play();
                        imgAnswer1.Source = new BitmapImage(ImgInCorrect);
                        imgAnswer1.Visibility = Visibility.Visible;
                        imgAnswer1.IsEnabled = false;
                        imgAnswer1.Cursor = Cursors.Arrow;//Đổi kiều chuột
                        EnableQuestionAndAnswer();//Cho phép thao tác UI
                        return;
                    }

                    Task.Run(() =>
                    {
                        //Xử lý các chức năng và đợi 1,5s để chuyển câu hỏi
                        Thread.Sleep(1500);
                    }).ContinueWith((task) =>
                    {
                        //Kiểm tra và chuyển câu hỏi
                        if (CountQuestion < 3)// Nếu chưa đủ 3 câu hỏi thì tiếp tục tạo câu hỏi mới
                        {
                            Task.Run(() =>
                            {
                                this.Dispatcher.Invoke(() =>
                                {
                                    IsCreateNew = false;//Không phải khởi tạo lần đầu
                                    CreateQuestionAndAnswer();
                                    mediaPlayerVoid.Open(new Uri(ListVoidWord[CountQuestion], UriKind.Relative));
                                    mediaPlayerVoid.Stop();
                                    mediaPlayerVoid.Play();//Phát âm câu hỏi
                                    NotEnableQuestionAndAnswer();//Ẩn các hình ảnh khi phát âm
                                });
                                Thread.Sleep(1000);
                            }).ContinueWith((task1) =>
                            {
                                EnableQuestionAndAnswer(); //Hiện các câu trả lời và câu hỏi
                            });
                        }
                        else if (CountQuestion == 3)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                NotClickUI();//Khong thao tác trn6 giao diện
                            });
                        }
                        EnableQuestionAndAnswer();//Cho phép thao tác UI
                    });
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi khi nhấn vào câu trả lời 1!");
            }

        }
        private void Answer2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (CountQuestion < 3)
                {
                    NotClickUI();//Không thao tác UI khi chọn câu trả lời
                    mediaPlayerVoidCorrect.Stop();
                    if (ListVoidSort[CountQuestion] == ListImgSort[1])
                    {

                        mediaPlayerVoidCorrect.Open(new Uri(VoidCorrect, UriKind.Relative));
                        mediaPlayerVoidCorrect.Play();
                        imgAnswer2.Source = new BitmapImage(ImgCorrect);
                        imgAnswer2.Visibility = Visibility.Visible;

                        CountQuestion++;//Nếu trả lời đúng thì tăng số câu hỏi lên 1


                    }
                    else
                    {
                        Answer2 = true; //Đã trả lời sai
                        mediaPlayerVoidCorrect.Open(new Uri(VoidInCorrect, UriKind.Relative));
                        mediaPlayerVoidCorrect.Play();
                        imgAnswer2.Source = new BitmapImage(ImgInCorrect);
                        imgAnswer2.Visibility = Visibility.Visible;
                        imgAnswer2.IsEnabled = false;
                        imgAnswer2.Cursor = Cursors.Arrow;//Đổi kiều chuột
                        EnableQuestionAndAnswer();//Cho phép thao tác UI
                        return;
                    }

                    Task.Run(() =>
                    {
                        Thread.Sleep(1500);
                    }).ContinueWith((task) =>
                    {
                        if (CountQuestion < 3)// Nếu chưa đủ 3 câu hỏi thì tiếp tục tạo câu hỏi mới
                        {
                            Task.Run(() =>
                            {
                                this.Dispatcher.Invoke(() =>
                                {
                                    IsCreateNew = false;//Không phải khởi tạo lần đầu
                                    CreateQuestionAndAnswer();
                                    mediaPlayerVoid.Open(new Uri(ListVoidWord[CountQuestion], UriKind.Relative));
                                    mediaPlayerVoid.Stop();
                                    mediaPlayerVoid.Play();//Phát âm câu hỏi
                                    NotEnableQuestionAndAnswer();//Ẩn các hình ảnh khi phát âm
                                });
                                Thread.Sleep(1000);
                            }).ContinueWith((task1) =>
                            {
                                EnableQuestionAndAnswer(); //Hiện các câu trả lời và câu hỏi
                            });
                        }
                        else if (CountQuestion == 3)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                NotClickUI();//Khong thao tác trn6 giao diện
                            });
                        }
                        EnableQuestionAndAnswer();//Cho phép thao tác UI
                    });
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi khi nhấn vào câu trả lời 2!");
            }


        }
        private void Answer3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (CountQuestion < 3)
                {
                    NotClickUI();//Không thao tác UI khi chọn câu trả lời
                    mediaPlayerVoidCorrect.Stop();
                    if (ListVoidSort[CountQuestion] == ListImgSort[2])
                    {
                        mediaPlayerVoidCorrect.Open(new Uri(VoidCorrect, UriKind.Relative));
                        mediaPlayerVoidCorrect.Play();
                        imgAnswer3.Source = new BitmapImage(ImgCorrect);
                        imgAnswer3.Visibility = Visibility.Visible;
                        CountQuestion++;//Nếu trả lời đúng thì tăng số câu hỏi lên 1


                    }
                    else
                    {
                        Answer3 = true; //Đã trả lời sai
                        mediaPlayerVoidCorrect.Open(new Uri(VoidInCorrect, UriKind.Relative));
                        mediaPlayerVoidCorrect.Play();
                        imgAnswer3.Source = new BitmapImage(ImgInCorrect);
                        imgAnswer3.Visibility = Visibility.Visible;
                        imgAnswer3.IsEnabled = false;
                        imgAnswer3.Cursor = Cursors.Arrow;//Đổi kiều chuột
                        EnableQuestionAndAnswer();//Cho phép thao tác UI
                        return;
                    }
                    Task.Run(() =>
                    {
                        Thread.Sleep(1500);
                    }).ContinueWith((task) =>
                    {
                        if (CountQuestion < 3)// Nếu chưa đủ 3 câu hỏi thì tiếp tục tạo câu hỏi mới
                        {
                            Task.Run(() =>
                            {
                                this.Dispatcher.Invoke(() =>
                                {
                                    IsCreateNew = false;//Không phải khởi tạo lần đầu
                                    CreateQuestionAndAnswer();
                                    mediaPlayerVoid.Open(new Uri(ListVoidWord[CountQuestion], UriKind.Relative));
                                    mediaPlayerVoid.Stop();
                                    mediaPlayerVoid.Play();//Phát âm câu hỏi
                                    NotEnableQuestionAndAnswer();//Ẩn các hình ảnh khi phát âm
                                });
                                Thread.Sleep(1000);
                            }).ContinueWith((task1) =>
                            {
                                EnableQuestionAndAnswer(); //Hiện các câu trả lời và câu hỏi
                            });
                        }
                        else if (CountQuestion == 3)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                NotClickUI();//Khong thao tác trn6 giao diện
                            });
                        }
                        EnableQuestionAndAnswer();//Cho phép thao tác UI
                    });
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi nhấn vào câu trả lời 3!");
            }

        }
        #endregion


    }
}
