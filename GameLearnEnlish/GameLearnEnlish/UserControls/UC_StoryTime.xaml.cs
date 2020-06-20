using BLL;
using Data;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace GameLearnEnlish.UserControls
{
    /// <summary>
    /// Interaction logic for UC_StoryTime.xaml
    /// </summary>
    public partial class UC_StoryTime : UserControl
    {
        private int Unit;

        private List<Sentence> lstSentence = new List<Sentence>();

        private MediaPlayer mediaTitle = new MediaPlayer();
        private MediaPlayer mediaDescription = new MediaPlayer();

        private List<MediaPlayer> mediaSoundWord = new List<MediaPlayer>();
        private List<BitmapImage> bitmapImages = new List<BitmapImage>();
        private List<string> lstText = new List<string>();




        private List<StackPanel> ListStack = new List<StackPanel>();

        #region MediaBank
        MediaPlayer media_a = new MediaPlayer();
        MediaPlayer media_and = new MediaPlayer();
        MediaPlayer media_are = new MediaPlayer();
        MediaPlayer media_at = new MediaPlayer();
        MediaPlayer media_baby = new MediaPlayer();
        MediaPlayer media_balloons = new MediaPlayer();
        MediaPlayer media_big = new MediaPlayer();
        MediaPlayer media_brother = new MediaPlayer();
        MediaPlayer media_but = new MediaPlayer();
        MediaPlayer media_carrots = new MediaPlayer();
        MediaPlayer media_circles = new MediaPlayer();
        MediaPlayer media_crayon = new MediaPlayer();
        MediaPlayer media_days = new MediaPlayer();
        MediaPlayer media_do = new MediaPlayer();
        MediaPlayer media_doctor = new MediaPlayer();
        MediaPlayer media_doll = new MediaPlayer();
        MediaPlayer media_dollhouse = new MediaPlayer();
        MediaPlayer media_dolls = new MediaPlayer();
        MediaPlayer media_dont = new MediaPlayer();
        MediaPlayer media_face = new MediaPlayer();
        MediaPlayer media_family = new MediaPlayer();
        MediaPlayer media_find = new MediaPlayer();
        MediaPlayer media_fish = new MediaPlayer();
        MediaPlayer media_have = new MediaPlayer();
        MediaPlayer media_hello = new MediaPlayer();
        MediaPlayer media_her = new MediaPlayer();
        MediaPlayer media_hi = new MediaPlayer();
        MediaPlayer media_hospital = new MediaPlayer();
        MediaPlayer media_i = new MediaPlayer();
        MediaPlayer media_is = new MediaPlayer();
        MediaPlayer media_it = new MediaPlayer();
        MediaPlayer media_its = new MediaPlayer();
        MediaPlayer media_know = new MediaPlayer();
        MediaPlayer media_lets = new MediaPlayer();
        MediaPlayer media_look = new MediaPlayer();
        MediaPlayer media_lucy = new MediaPlayer();
        MediaPlayer media_lunch = new MediaPlayer();
        MediaPlayer media_milk = new MediaPlayer();
        MediaPlayer media_mother = new MediaPlayer();
        MediaPlayer media_my = new MediaPlayer();
        MediaPlayer media_new = new MediaPlayer();
        MediaPlayer media_no = new MediaPlayer();
        MediaPlayer media_nurses = new MediaPlayer();
        MediaPlayer media_oh = new MediaPlayer();
        MediaPlayer media_one = new MediaPlayer();
        MediaPlayer media_picture = new MediaPlayer();
        MediaPlayer media_play = new MediaPlayer();
        MediaPlayer media_please = new MediaPlayer();
        MediaPlayer media_puppet = new MediaPlayer();
        MediaPlayer media_puppies = new MediaPlayer();
        MediaPlayer media_school = new MediaPlayer();
        MediaPlayer media_see = new MediaPlayer();
        MediaPlayer media_sister = new MediaPlayer();
        MediaPlayer media_square = new MediaPlayer();
        MediaPlayer media_surprise = new MediaPlayer();
        MediaPlayer media_the = new MediaPlayer();
        MediaPlayer media_they = new MediaPlayer();
        MediaPlayer media_this = new MediaPlayer();
        MediaPlayer media_three = new MediaPlayer();
        MediaPlayer media_too = new MediaPlayer();
        MediaPlayer media_two = new MediaPlayer();
        MediaPlayer media_want = new MediaPlayer();
        MediaPlayer media_we = new MediaPlayer();
        MediaPlayer media_what = new MediaPlayer();
        MediaPlayer media_wheres = new MediaPlayer();
        MediaPlayer media_yay = new MediaPlayer();
        MediaPlayer media_yes = new MediaPlayer();
        MediaPlayer media_you = new MediaPlayer();
        #endregion




        public UC_StoryTime(int unit)
        {
            Unit = unit;
            lstSentence = new SentenceBLL().GetSentencesOfUnit(Unit);

            foreach (Sentence x in lstSentence)
            {
                bitmapImages.Add(new BitmapImage(new Uri(x.Image, UriKind.Relative)));
                MediaPlayer media = new MediaPlayer();
                media.Open(new Uri(x.Sound, UriKind.Relative));
                mediaSoundWord.Add(media);
                lstText.Add(x.Text.Trim());
            }

            if (mediaSoundWord.Count == 4)
            {
                mediaSoundWord[0].MediaEnded += UC_StoryTime_MediaEnded;
                mediaSoundWord[1].MediaEnded += UC_StoryTime_MediaEnded1;
                mediaSoundWord[2].MediaEnded += UC_StoryTime_MediaEnded2;
                mediaSoundWord[3].MediaEnded += UC_StoryTime_MediaEnded3;
            }

            mediaTitle.Open(new Uri(@"..\..\media\audio\storytime\title.mp3", UriKind.Relative));
            mediaTitle.MediaEnded += MediaTitle_MediaEnded;
            mediaDescription.Open(new Uri(@"..\..\media\audio\storytime\description.mp3", UriKind.Relative));
            mediaDescription.MediaEnded += MediaDescription_MediaEnded;

            InitializeComponent();

            BigImage.Source = bitmapImages[0];

            mediaTitle.Play();
            CreateMedia();
            CreateLabel(lstText);

        }
        private bool isFullVoidClick = true;
        private void UC_StoryTime_MediaEnded3(object sender, EventArgs e)
        {
            mediaSoundWord[3].Stop();
            ChangePicShowing(1);
            GridPanel.IsEnabled = true;

            if (!isFullVoidClick)
            {
                GridPanel.IsEnabled = false;
                return;
            }
        }

        private void UC_StoryTime_MediaEnded2(object sender, EventArgs e)
        {
            mediaSoundWord[2].Stop();
            if (!isFullVoidClick)
            {
                GridPanel.IsEnabled = false;
                return;
            }
            mediaSoundWord[3].Play();
            ChangePicShowing(4);
        }

        private void UC_StoryTime_MediaEnded1(object sender, EventArgs e)
        {
            mediaSoundWord[1].Stop();
            if (!isFullVoidClick)
            {
                GridPanel.IsEnabled = false;
                return;
            }
            mediaSoundWord[2].Play();
            ChangePicShowing(3);
        }

        private void UC_StoryTime_MediaEnded(object sender, EventArgs e)
        {
            mediaSoundWord[0].Stop();
            if (!isFullVoidClick)
            {
                GridPanel.IsEnabled = false;
                return;
            }
            mediaSoundWord[1].Play();
            ChangePicShowing(2);

        }

        private void MediaDescription_MediaEnded(object sender, EventArgs e)
        {
            GridMain.IsEnabled = true;
            GridMain.Opacity = 1;
        }

        private void MediaTitle_MediaEnded(object sender, EventArgs e)
        {
            mediaTitle.Stop();
            mediaDescription.Play();
        }

        public void CreateMedia()
        {
            #region MediaBank
            media_a.Open(new Uri(@"..\..\media\audio\storytime\audiobank\a.mp3", UriKind.Relative));
            media_and.Open(new Uri(@"..\..\media\audio\storytime\audiobank\and.mp3", UriKind.Relative));
            media_are.Open(new Uri(@"..\..\media\audio\storytime\audiobank\are.mp3", UriKind.Relative));
            media_at.Open(new Uri(@"..\..\media\audio\storytime\audiobank\at.mp3", UriKind.Relative));
            media_baby.Open(new Uri(@"..\..\media\audio\storytime\audiobank\baby.mp3", UriKind.Relative));
            media_balloons.Open(new Uri(@"..\..\media\audio\storytime\audiobank\balloons.mp3", UriKind.Relative));
            media_brother.Open(new Uri(@"..\..\media\audio\storytime\audiobank\brother.mp3", UriKind.Relative));
            media_but.Open(new Uri(@"..\..\media\audio\storytime\audiobank\but.mp3", UriKind.Relative));
            media_carrots.Open(new Uri(@"..\..\media\audio\storytime\audiobank\carrots.mp3", UriKind.Relative));
            media_circles.Open(new Uri(@"..\..\media\audio\storytime\audiobank\circles.mp3", UriKind.Relative));
            media_crayon.Open(new Uri(@"..\..\media\audio\storytime\audiobank\crayon.mp3", UriKind.Relative));
            media_days.Open(new Uri(@"..\..\media\audio\storytime\audiobank\days.mp3", UriKind.Relative));
            media_do.Open(new Uri(@"..\..\media\audio\storytime\audiobank\do.mp3", UriKind.Relative));
            media_doctor.Open(new Uri(@"..\..\media\audio\storytime\audiobank\doctor.mp3", UriKind.Relative));
            media_doll.Open(new Uri(@"..\..\media\audio\storytime\audiobank\doll.mp3", UriKind.Relative));
            media_dollhouse.Open(new Uri(@"..\..\media\audio\storytime\audiobank\dollhouse.mp3", UriKind.Relative));
            media_dolls.Open(new Uri(@"..\..\media\audio\storytime\audiobank\dolls.mp3", UriKind.Relative));
            media_dont.Open(new Uri(@"..\..\media\audio\storytime\audiobank\dont.mp3", UriKind.Relative));
            media_face.Open(new Uri(@"..\..\media\audio\storytime\audiobank\face.mp3", UriKind.Relative));
            media_family.Open(new Uri(@"..\..\media\audio\storytime\audiobank\family.mp3", UriKind.Relative));
            media_find.Open(new Uri(@"..\..\media\audio\storytime\audiobank\find.mp3", UriKind.Relative));
            media_fish.Open(new Uri(@"..\..\media\audio\storytime\audiobank\fish.mp3", UriKind.Relative));
            media_have.Open(new Uri(@"..\..\media\audio\storytime\audiobank\have.mp3", UriKind.Relative));
            media_hello.Open(new Uri(@"..\..\media\audio\storytime\audiobank\hello.mp3", UriKind.Relative));
            media_her.Open(new Uri(@"..\..\media\audio\storytime\audiobank\her.mp3", UriKind.Relative));
            media_hi.Open(new Uri(@"..\..\media\audio\storytime\audiobank\hi.mp3", UriKind.Relative));
            media_hospital.Open(new Uri(@"..\..\media\audio\storytime\audiobank\hospital.mp3", UriKind.Relative));
            media_i.Open(new Uri(@"..\..\media\audio\storytime\audiobank\i.mp3", UriKind.Relative));
            media_is.Open(new Uri(@"..\..\media\audio\storytime\audiobank\is.mp3", UriKind.Relative));
            media_it.Open(new Uri(@"..\..\media\audio\storytime\audiobank\it.mp3", UriKind.Relative));
            media_its.Open(new Uri(@"..\..\media\audio\storytime\audiobank\its.mp3", UriKind.Relative));
            media_know.Open(new Uri(@"..\..\media\audio\storytime\audiobank\know.mp3", UriKind.Relative));
            media_lets.Open(new Uri(@"..\..\media\audio\storytime\audiobank\lets.mp3", UriKind.Relative));
            media_look.Open(new Uri(@"..\..\media\audio\storytime\audiobank\look.mp3", UriKind.Relative));
            media_lucy.Open(new Uri(@"..\..\media\audio\storytime\audiobank\lucy.mp3", UriKind.Relative));
            media_lunch.Open(new Uri(@"..\..\media\audio\storytime\audiobank\lunch.mp3", UriKind.Relative));
            media_milk.Open(new Uri(@"..\..\media\audio\storytime\audiobank\milk.mp3", UriKind.Relative));
            media_mother.Open(new Uri(@"..\..\media\audio\storytime\audiobank\mother.mp3", UriKind.Relative));
            media_my.Open(new Uri(@"..\..\media\audio\storytime\audiobank\my.mp3", UriKind.Relative));
            media_new.Open(new Uri(@"..\..\media\audio\storytime\audiobank\new.mp3", UriKind.Relative));
            media_no.Open(new Uri(@"..\..\media\audio\storytime\audiobank\no.mp3", UriKind.Relative));
            media_nurses.Open(new Uri(@"..\..\media\audio\storytime\audiobank\nurses.mp3", UriKind.Relative));
            media_oh.Open(new Uri(@"..\..\media\audio\storytime\audiobank\oh.mp3", UriKind.Relative));
            media_one.Open(new Uri(@"..\..\media\audio\storytime\audiobank\one.mp3", UriKind.Relative));
            media_picture.Open(new Uri(@"..\..\media\audio\storytime\audiobank\picture.mp3", UriKind.Relative));
            media_play.Open(new Uri(@"..\..\media\audio\storytime\audiobank\play.mp3", UriKind.Relative));
            media_please.Open(new Uri(@"..\..\media\audio\storytime\audiobank\please.mp3", UriKind.Relative));
            media_puppet.Open(new Uri(@"..\..\media\audio\storytime\audiobank\puppet.mp3", UriKind.Relative));
            media_puppies.Open(new Uri(@"..\..\media\audio\storytime\audiobank\puppies.mp3", UriKind.Relative));
            media_school.Open(new Uri(@"..\..\media\audio\storytime\audiobank\school.mp3", UriKind.Relative));
            media_see.Open(new Uri(@"..\..\media\audio\storytime\audiobank\see.mp3", UriKind.Relative));
            media_sister.Open(new Uri(@"..\..\media\audio\storytime\audiobank\sister.mp3", UriKind.Relative));
            media_square.Open(new Uri(@"..\..\media\audio\storytime\audiobank\square.mp3", UriKind.Relative));
            media_surprise.Open(new Uri(@"..\..\media\audio\storytime\audiobank\surprise.mp3", UriKind.Relative));
            media_the.Open(new Uri(@"..\..\media\audio\storytime\audiobank\the.mp3", UriKind.Relative));
            media_they.Open(new Uri(@"..\..\media\audio\storytime\audiobank\they.mp3", UriKind.Relative));
            media_this.Open(new Uri(@"..\..\media\audio\storytime\audiobank\this.mp3", UriKind.Relative));
            media_three.Open(new Uri(@"..\..\media\audio\storytime\audiobank\three.mp3", UriKind.Relative));
            media_too.Open(new Uri(@"..\..\media\audio\storytime\audiobank\too.mp3", UriKind.Relative));
            media_two.Open(new Uri(@"..\..\media\audio\storytime\audiobank\two.mp3", UriKind.Relative));
            media_want.Open(new Uri(@"..\..\media\audio\storytime\audiobank\want.mp3", UriKind.Relative));
            media_we.Open(new Uri(@"..\..\media\audio\storytime\audiobank\we.mp3", UriKind.Relative));
            media_what.Open(new Uri(@"..\..\media\audio\storytime\audiobank\what.mp3", UriKind.Relative));
            media_wheres.Open(new Uri(@"..\..\media\audio\storytime\audiobank\wheres.mp3", UriKind.Relative));
            media_yay.Open(new Uri(@"..\..\media\audio\storytime\audiobank\yay.mp3", UriKind.Relative));
            media_yes.Open(new Uri(@"..\..\media\audio\storytime\audiobank\yes.mp3", UriKind.Relative));
            media_you.Open(new Uri(@"..\..\media\audio\storytime\audiobank\you.mp3", UriKind.Relative));

            //event chay xong thi stop
            media_a.MediaEnded += Media_a_MediaEnded;
            media_and.MediaEnded += Media_a_MediaEnded;
            media_are.MediaEnded += Media_a_MediaEnded;
            media_at.MediaEnded += Media_a_MediaEnded;
            media_baby.MediaEnded += Media_a_MediaEnded;
            media_balloons.MediaEnded += Media_a_MediaEnded;
            media_brother.MediaEnded += Media_a_MediaEnded;
            media_but.MediaEnded += Media_a_MediaEnded;
            media_carrots.MediaEnded += Media_a_MediaEnded;
            media_circles.MediaEnded += Media_a_MediaEnded;
            media_crayon.MediaEnded += Media_a_MediaEnded;
            media_days.MediaEnded += Media_a_MediaEnded;
            media_do.MediaEnded += Media_a_MediaEnded;
            media_doctor.MediaEnded += Media_a_MediaEnded;
            media_doll.MediaEnded += Media_a_MediaEnded;
            media_dollhouse.MediaEnded += Media_a_MediaEnded;
            media_dolls.MediaEnded += Media_a_MediaEnded;
            media_dont.MediaEnded += Media_a_MediaEnded;
            media_face.MediaEnded += Media_a_MediaEnded;
            media_family.MediaEnded += Media_a_MediaEnded;
            media_find.MediaEnded += Media_a_MediaEnded;
            media_fish.MediaEnded += Media_a_MediaEnded;
            media_have.MediaEnded += Media_a_MediaEnded;
            media_hello.MediaEnded += Media_a_MediaEnded;
            media_her.MediaEnded += Media_a_MediaEnded;
            media_hi.MediaEnded += Media_a_MediaEnded;
            media_hospital.MediaEnded += Media_a_MediaEnded;
            media_i.MediaEnded += Media_a_MediaEnded;
            media_is.MediaEnded += Media_a_MediaEnded;
            media_it.MediaEnded += Media_a_MediaEnded;
            media_its.MediaEnded += Media_a_MediaEnded;
            media_know.MediaEnded += Media_a_MediaEnded;
            media_lets.MediaEnded += Media_a_MediaEnded;
            media_look.MediaEnded += Media_a_MediaEnded;
            media_lucy.MediaEnded += Media_a_MediaEnded;
            media_lunch.MediaEnded += Media_a_MediaEnded;
            media_milk.MediaEnded += Media_a_MediaEnded;
            media_mother.MediaEnded += Media_a_MediaEnded;
            media_my.MediaEnded += Media_a_MediaEnded;
            media_new.MediaEnded += Media_a_MediaEnded;
            media_no.MediaEnded += Media_a_MediaEnded;
            media_nurses.MediaEnded += Media_a_MediaEnded;
            media_oh.MediaEnded += Media_a_MediaEnded;
            media_one.MediaEnded += Media_a_MediaEnded;
            media_picture.MediaEnded += Media_a_MediaEnded;
            media_play.MediaEnded += Media_a_MediaEnded;
            media_please.MediaEnded += Media_a_MediaEnded;
            media_puppet.MediaEnded += Media_a_MediaEnded;
            media_puppies.MediaEnded += Media_a_MediaEnded;
            media_school.MediaEnded += Media_a_MediaEnded;
            media_see.MediaEnded += Media_a_MediaEnded;
            media_sister.MediaEnded += Media_a_MediaEnded;
            media_square.MediaEnded += Media_a_MediaEnded;
            media_surprise.MediaEnded += Media_a_MediaEnded;
            media_the.MediaEnded += Media_a_MediaEnded;
            media_they.MediaEnded += Media_a_MediaEnded;
            media_this.MediaEnded += Media_a_MediaEnded;
            media_three.MediaEnded += Media_a_MediaEnded;
            media_too.MediaEnded += Media_a_MediaEnded;
            media_two.MediaEnded += Media_a_MediaEnded;
            media_want.MediaEnded += Media_a_MediaEnded;
            media_we.MediaEnded += Media_a_MediaEnded;
            media_what.MediaEnded += Media_a_MediaEnded;
            media_wheres.MediaEnded += Media_a_MediaEnded;
            media_yay.MediaEnded += Media_a_MediaEnded;
            media_yes.MediaEnded += Media_a_MediaEnded;
            media_you.MediaEnded += Media_a_MediaEnded;
            #endregion

            //pic
            Image1.Source = bitmapImages[0];
            Image2.Source = bitmapImages[1];
            Image3.Source = bitmapImages[2];
            Image4.Source = bitmapImages[3];
        }

        private void Media_a_MediaEnded(object sender, EventArgs e)
        {
            MediaPlayer media = sender as MediaPlayer;
            media.Stop();
        }

        public void CreateLabel(List<string> lst)
        {

            StackPanel stackMain = new StackPanel();
            stackMain.Orientation = Orientation.Vertical;
            CanvasString.Children.Add(stackMain);
            int indexLabel = 0;
            foreach (string ls in lst)
            {
                string str = ls;
                StackPanel stack = new StackPanel(); //stPic
                stack.Orientation = Orientation.Horizontal;

                Thickness margin = stack.Margin;
                margin.Top = 0;
                margin.Left = 10;
                stack.Margin = margin;

                if (str.IndexOf("@") == -1)//khong co xuong hang
                {
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
                        x.FontSize = 25;

                        x.MouseDown += X_MouseDown;
                        x.MouseEnter += X_MouseEnter;
                        x.MouseLeave += X_MouseLeave;
                        stack.Children.Add(x);
                    }
                    ListStack.Add(stack);
                    stackMain.Children.Add(stack);
                }
                else
                {
                    List<string> listString = new List<string>();
                    while (!String.IsNullOrEmpty(str.Trim()))//ls khong rong
                    {
                        int index = str.TrimStart().IndexOf('@');
                        if (index != -1)
                        {
                            listString.Add(str.TrimStart().Substring(0, index));
                            str = str.Remove(0, index + 1);
                        }
                        else
                        {
                            listString.Add(str.Trim());
                            str = "";
                        }
                    }

                    StackPanel moreStack = new StackPanel(); //stPic
                    moreStack.Orientation = Orientation.Vertical;
                    Thickness margin2 = stack.Margin;
                    margin2.Top = 0;
                    margin2.Left = 10;
                    moreStack.Margin = margin;

                    foreach (string l in listString)
                    {
                        StackPanel mulStack = new StackPanel();
                        mulStack.Orientation = Orientation.Horizontal;
                        string str2 = l;
                        while (!String.IsNullOrEmpty(str2.Trim()))//ls khong rong
                        {
                            string s2 = "";
                            int index2 = str2.TrimStart().IndexOf(' ');
                            if (index2 != -1)
                            {
                                s2 = str2.TrimStart().Substring(0, index2);
                                str2 = str2.Remove(0, index2 + 1);
                            }
                            else
                            {
                                s2 = str2.Trim();
                                str2 = "";
                            }
                            Label x = new Label();
                            x.Name = "lb" + indexLabel;
                            indexLabel++;
                            x.FontSize = 25;
                            x.FontWeight = FontWeights.Bold;
                            x.Content = s2 + " ";
                            x.MouseDown += X_MouseDown;
                            x.MouseEnter += X_MouseEnter;
                            x.MouseLeave += X_MouseLeave;

                            mulStack.Children.Add(x);
                        }
                        moreStack.Children.Add(mulStack);
                        ListStack.Add(mulStack);
                    }
                    stackMain.Children.Add(moreStack);

                }

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

            #region MediaBankStop
            media_a.Stop();
            media_and.Stop();
            media_are.Stop();
            media_at.Stop();
            media_baby.Stop();
            media_balloons.Stop();
            media_brother.Stop();
            media_but.Stop();
            media_carrots.Stop();
            media_circles.Stop();
            media_crayon.Stop();
            media_days.Stop();
            media_do.Stop();
            media_doctor.Stop();
            media_doll.Stop();
            media_dollhouse.Stop();
            media_dolls.Stop();
            media_dont.Stop();
            media_face.Stop();
            media_family.Stop();
            media_find.Stop();
            media_fish.Stop();
            media_have.Stop();
            media_hello.Stop();
            media_her.Stop();
            media_hi.Stop();
            media_hospital.Stop();
            media_i.Stop();
            media_is.Stop();
            media_it.Stop();
            media_its.Stop();
            media_know.Stop();
            media_lets.Stop();
            media_look.Stop();
            media_lucy.Stop();
            media_lunch.Stop();
            media_milk.Stop();
            media_mother.Stop();
            media_my.Stop();
            media_new.Stop();
            media_no.Stop();
            media_nurses.Stop();
            media_oh.Stop();
            media_one.Stop();
            media_picture.Stop();
            media_play.Stop();
            media_please.Stop();
            media_puppet.Stop();
            media_puppies.Stop();
            media_school.Stop();
            media_see.Stop();
            media_sister.Stop();
            media_square.Stop();
            media_surprise.Stop();
            media_the.Stop();
            media_they.Stop();
            media_this.Stop();
            media_three.Stop();
            media_too.Stop();
            media_two.Stop();
            media_want.Stop();
            media_we.Stop();
            media_what.Stop();
            media_wheres.Stop();
            media_yay.Stop();
            media_yes.Stop();
            media_you.Stop();
            #endregion
            switch (s)
            {
                case "a":
                    {
                        media_a.Play();
                    }
                    break;
                case "and":
                    {
                        media_and.Play();
                    }
                    break;
                case "are":
                    {
                        media_are.Play();
                    }
                    break;
                case "at":
                    {
                        media_at.Play();
                    }
                    break;
                case "baby":
                    {
                        media_baby.Play();
                    }
                    break;
                case "balloons":
                    {
                        media_balloons.Play();
                    }
                    break;
                case "big":
                    {
                        media_big.Play();
                    }
                    break;
                case "brother":
                    {
                        media_brother.Play();
                    }
                    break;
                case "but":
                    {
                        media_but.Play();
                    }
                    break;
                case "carrots":
                    {
                        media_carrots.Play();
                    }
                    break;
                case "circles":
                    {
                        media_circles.Play();
                    }
                    break;
                case "crayon":
                    {
                        media_crayon.Play();
                    }
                    break;
                case "days":
                    {
                        media_days.Play();
                    }
                    break;
                case "do":
                    {
                        media_do.Play();
                    }
                    break;
                case "doctor":
                    {
                        media_doctor.Play();
                    }
                    break;
                case "doll":
                    {
                        media_doll.Play();
                    }
                    break;
                case "dollhouse":
                    {
                        media_dollhouse.Play();
                    }
                    break;
                case "dolls":
                    {
                        media_dolls.Play();
                    }
                    break;
                case "dont":
                    {
                        media_dont.Play();
                    }
                    break;
                case "face":
                    {
                        media_face.Play();
                    }
                    break;
                case "family":
                    {
                        media_family.Play();
                    }
                    break;
                case "find":
                    {
                        media_find.Play();
                    }
                    break;
                case "fish":
                    {
                        media_fish.Play();
                    }
                    break;
                case "have":
                    {
                        media_have.Play();
                    }
                    break;
                case "hello":
                    {
                        media_hello.Play();
                    }
                    break;
                case "her":
                    {
                        media_her.Play();
                    }
                    break;
                case "hi":
                    {
                        media_hi.Play();
                    }
                    break;
                case "hospital":
                    {
                        media_hospital.Play();
                    }
                    break;
                case "i":
                    {
                        media_i.Play();
                    }
                    break;
                case "is":
                    {
                        media_is.Play();
                    }
                    break;
                case "it":
                    {
                        media_it.Play();
                    }
                    break;
                case "its":
                    {
                        media_its.Play();
                    }
                    break;
                case "know":
                    {
                        media_know.Play();
                    }
                    break;
                case "lets":
                    {
                        media_lets.Play();
                    }
                    break;
                case "look":
                    {
                        media_look.Play();
                    }
                    break;
                case "lucy":
                    {
                        media_lucy.Play();
                    }
                    break;
                case "lunch":
                    {
                        media_lunch.Play();
                    }
                    break;
                case "milk":
                    {
                        media_milk.Play();
                    }
                    break;
                case "mother":
                    {
                        media_mother.Play();
                    }
                    break;
                case "my":
                    {
                        media_my.Play();
                    }
                    break;
                case "new":
                    {
                        media_new.Play();
                    }
                    break;
                case "no":
                    {
                        media_no.Play();
                    }
                    break;
                case "nurses":
                    {
                        media_nurses.Play();
                    }
                    break;
                case "oh":
                    {
                        media_oh.Play();
                    }
                    break;
                case "one":
                    {
                        media_one.Play();
                    }
                    break;
                case "picture":
                    {
                        media_picture.Play();
                    }
                    break;
                case "play":
                    {
                        media_play.Play();
                    }
                    break;
                case "please":
                    {
                        media_please.Play();
                    }
                    break;
                case "puppet":
                    {
                        media_puppet.Play();
                    }
                    break;
                case "puppies":
                    {
                        media_puppies.Play();
                    }
                    break;
                case "school":
                    {
                        media_school.Play();
                    }
                    break;
                case "see":
                    {
                        media_see.Play();
                    }
                    break;
                case "sister":
                    {
                        media_sister.Play();
                    }
                    break;
                case "square":
                    {
                        media_square.Play();
                    }
                    break;
                case "surprise":
                    {
                        media_surprise.Play();
                    }
                    break;
                case "the":
                    {
                        media_the.Play();
                    }
                    break;
                case "they":
                    {
                        media_they.Play();
                    }
                    break;
                case "this":
                    {
                        media_this.Play();
                    }
                    break;
                case "three":
                    {
                        media_three.Play();
                    }
                    break;
                case "too":
                    {
                        media_too.Play();
                    }
                    break;
                case "two":
                    {
                        media_two.Play();
                    }
                    break;
                case "want":
                    {
                        media_want.Play();
                    }
                    break;
                case "we":
                    {
                        media_we.Play();
                    }
                    break;
                case "what":
                    {
                        media_what.Play();
                    }
                    break;
                case "wheres":
                    {
                        media_wheres.Play();
                    }
                    break;
                case "yay":
                    {
                        media_yay.Play();
                    }
                    break;
                case "yes":
                    {
                        media_yes.Play();
                    }
                    break;
                case "you":
                    {
                        media_you.Play();
                    }
                    break;

            }

            #region MediaBank


            #endregion
        }

        private void ImageVoid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StopAllMedia();
            isFullVoidClick = true;
            mediaSoundWord[0].Play();
            ChangePicShowing(1);
            GridPanel.IsEnabled = false;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            isFullVoidClick = false;
            StopAllMedia();
            switch (img.Name)
            {
                case "Image1":
                    {
                       
                        ChangePicShowing(1);
                        mediaSoundWord[0].Play();

                    }
                    break;
                case "Image2":
                    {
                       
                        ChangePicShowing(2);
                        mediaSoundWord[1].Play();
                    }
                    break;
                case "Image3":
                    {
                     
                        ChangePicShowing(3);
                        mediaSoundWord[2].Play();
                    }
                    break;
                case "Image4":
                    {
                        
                        ChangePicShowing(4);
                        mediaSoundWord[3].Play();
                    }
                    break;
            }
        }

        public void ChangePicShowing(int index)
        {
            Image1.Opacity = 0.5;
            Image2.Opacity = 0.5;
            Image3.Opacity = 0.5;
            Image4.Opacity = 0.5;

            BigImage.Source = bitmapImages[0];

            bor1.BorderBrush = Brushes.Green;
            bor2.BorderBrush = Brushes.Green;
            bor3.BorderBrush = Brushes.Green;
            bor4.BorderBrush = Brushes.Green;

            switch (index)
            {
                case 1:
                    {
                        Image1.Opacity = 1;
                        BigImage.Source = bitmapImages[0];
                        bor1.BorderBrush = Brushes.Red;
                    }
                    break;
                case 2:
                    {
                        Image2.Opacity = 1;
                        BigImage.Source = bitmapImages[1];
                        bor2.BorderBrush = Brushes.Red;
                    }
                    break;
                case 3:
                    {
                        Image3.Opacity = 1;
                        BigImage.Source = bitmapImages[2];
                        bor3.BorderBrush = Brushes.Red;
                    }
                    break;
                case 4:
                    {
                        Image4.Opacity = 1;
                        BigImage.Source = bitmapImages[3];
                        bor4.BorderBrush = Brushes.Red;
                    }
                    break;
            }
        }
        public void StopAllMedia()
        {
            foreach (MediaPlayer x in mediaSoundWord)
            {
                x.Stop();
            }

            media_a.Stop();
            media_and.Stop();
            media_are.Stop();
            media_at.Stop();
            media_baby.Stop();
            media_balloons.Stop();
            media_big.Stop();
            media_brother.Stop();
            media_but.Stop();
            media_carrots.Stop();
            media_circles.Stop();
            media_crayon.Stop();
            media_days.Stop();
            media_do.Stop();
            media_doctor.Stop();
            media_doll.Stop();
            media_dollhouse.Stop();
            media_dolls.Stop();
            media_dont.Stop();
            media_face.Stop();
            media_family.Stop();
            media_find.Stop();
            media_fish.Stop();
            media_have.Stop();
            media_hello.Stop();
            media_her.Stop();
            media_hi.Stop();
            media_hospital.Stop();
            media_i.Stop();
            media_is.Stop();
            media_it.Stop();
            media_its.Stop();
            media_know.Stop();
            media_lets.Stop();
            media_look.Stop();
            media_lucy.Stop();
            media_lunch.Stop();
            media_milk.Stop();
            media_mother.Stop();
            media_my.Stop();
            media_new.Stop();
            media_no.Stop();
            media_nurses.Stop();
            media_oh.Stop();
            media_one.Stop();
            media_picture.Stop();
            media_play.Stop();
            media_please.Stop();
            media_puppet.Stop();
            media_puppies.Stop();
            media_school.Stop();
            media_see.Stop();
            media_sister.Stop();
            media_square.Stop();
            media_surprise.Stop();
            media_the.Stop();
            media_they.Stop();
            media_this.Stop();
            media_three.Stop();
            media_too.Stop();
            media_two.Stop();
            media_want.Stop();
            media_we.Stop();
            media_what.Stop();
            media_wheres.Stop();
            media_yay.Stop();
            media_yes.Stop();
            media_you.Stop();

        }



    
    }
}
