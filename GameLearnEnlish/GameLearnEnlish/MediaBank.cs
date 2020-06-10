using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GameLearnEnlish
{
    public class MediaBank
    {

        private static MediaBank instance = new MediaBank();
        #region MediaBank
        public MediaPlayer media_a = new MediaPlayer();
        public MediaPlayer media_and = new MediaPlayer();
        public MediaPlayer media_are = new MediaPlayer();
        public MediaPlayer media_at = new MediaPlayer();
        public MediaPlayer media_baby = new MediaPlayer();
        public MediaPlayer media_balloons = new MediaPlayer();
        public MediaPlayer media_big = new MediaPlayer();
        public MediaPlayer media_brother = new MediaPlayer();
        public MediaPlayer media_but = new MediaPlayer();
        public MediaPlayer media_carrots = new MediaPlayer();
        public MediaPlayer media_circles = new MediaPlayer();
        public MediaPlayer media_crayon = new MediaPlayer();
        public MediaPlayer media_days = new MediaPlayer();
        public MediaPlayer media_do = new MediaPlayer();
        public MediaPlayer media_doctor = new MediaPlayer();
        public MediaPlayer media_doll = new MediaPlayer();
        public MediaPlayer media_dollhouse = new MediaPlayer();
        public MediaPlayer media_dolls = new MediaPlayer();
        public MediaPlayer media_dont = new MediaPlayer();
        public MediaPlayer media_face = new MediaPlayer();
        public MediaPlayer media_family = new MediaPlayer();
        public MediaPlayer media_find = new MediaPlayer();
        public MediaPlayer media_fish = new MediaPlayer();
        public MediaPlayer media_have = new MediaPlayer();
        public MediaPlayer media_hello = new MediaPlayer();
        public MediaPlayer media_her = new MediaPlayer();
        public MediaPlayer media_hi = new MediaPlayer();
        public MediaPlayer media_hospital = new MediaPlayer();
        public MediaPlayer media_i = new MediaPlayer();
        public MediaPlayer media_is = new MediaPlayer();
        public MediaPlayer media_it = new MediaPlayer();
        public MediaPlayer media_its = new MediaPlayer();
        public MediaPlayer media_know = new MediaPlayer();
        public MediaPlayer media_lets = new MediaPlayer();
        public MediaPlayer media_look = new MediaPlayer();
        public MediaPlayer media_lucy = new MediaPlayer();
        public MediaPlayer media_lunch = new MediaPlayer();
        public MediaPlayer media_milk = new MediaPlayer();
        public MediaPlayer media_mother = new MediaPlayer();
        public MediaPlayer media_my = new MediaPlayer();
        public MediaPlayer media_new = new MediaPlayer();
        public MediaPlayer media_no = new MediaPlayer();
        public MediaPlayer media_nurses = new MediaPlayer();
        public MediaPlayer media_oh = new MediaPlayer();
        public MediaPlayer media_one = new MediaPlayer();
        public MediaPlayer media_picture = new MediaPlayer();
        public MediaPlayer media_play = new MediaPlayer();
        public MediaPlayer media_please = new MediaPlayer();
        public MediaPlayer media_puppet = new MediaPlayer();
        public MediaPlayer media_puppies = new MediaPlayer();
        public MediaPlayer media_school = new MediaPlayer();
        public MediaPlayer media_see = new MediaPlayer();
        public MediaPlayer media_sister = new MediaPlayer();
        public MediaPlayer media_square = new MediaPlayer();
        public MediaPlayer media_surprise = new MediaPlayer();
        public MediaPlayer media_the = new MediaPlayer();
        public MediaPlayer media_they = new MediaPlayer();
        public MediaPlayer media_this = new MediaPlayer();
        public MediaPlayer media_three = new MediaPlayer();
        public MediaPlayer media_too = new MediaPlayer();
        public MediaPlayer media_two = new MediaPlayer();
        public MediaPlayer media_want = new MediaPlayer();
        public MediaPlayer media_we = new MediaPlayer();
        public MediaPlayer media_what = new MediaPlayer();
        public MediaPlayer media_wheres = new MediaPlayer();
        public MediaPlayer media_yay = new MediaPlayer();
        public MediaPlayer media_yes = new MediaPlayer();
        public MediaPlayer media_you = new MediaPlayer();
        #endregion
        //private constructor to avoid client applications to use constructor
        private MediaBank()
        {
            #region MediaBank
            media_a.Open(new Uri(@"..\..\media\audio\storytime\audiobank\a.mp3", UriKind.Relative));
            media_and.Open(new Uri(@"..\..\media\audio\storytime\audiobank\and.mp3", UriKind.Relative));
            media_are.Open(new Uri(@"..\..\media\audio\storytime\audiobank\are.mp3", UriKind.Relative));
            media_at.Open(new Uri(@"..\..\media\audio\storytime\audiobank\at.mp3", UriKind.Relative));
            media_baby.Open(new Uri(@"..\..\media\audio\storytime\audiobank\baby.mp3", UriKind.Relative));
            media_balloons.Open(new Uri(@"..\..\..\media\audio\storytime\audiobank\balloons.mp3", UriKind.Relative));
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
        }
        private void Media_a_MediaEnded(object sender, EventArgs e)
        {
            MediaPlayer media = sender as MediaPlayer;
            media.Stop();
        }
        public static MediaBank getInstance()
        {
            return instance;
        }

        public MediaPlayer GetMedia(string s)
        {
            switch (s)
            {
                case "a":
                    {
                        return media_a;
                    }

                case "and":
                    {
                        return media_and;
                    }

                case "are":
                    {
                        return media_are;
                    }

                case "at":
                    {
                        return media_at;
                    }

                case "baby":
                    {
                        return media_baby;
                    }

                case "balloons":
                    {
                        return media_balloons;
                    }

                case "big":
                    {
                        return media_big;
                    }

                case "brother":
                    {
                        return media_brother;
                    }

                case "but":
                    {
                        return media_but;
                    }

                case "carrots":
                    {
                        return media_carrots;
                    }

                case "circles":
                    {
                        return media_circles;
                    }

                case "crayon":
                    {
                        return media_crayon;
                    }

                case "days":
                    {
                        return media_days;
                    }

                case "do":
                    {
                        return media_do;
                    }

                case "doctor":
                    {
                        return media_doctor;
                    }

                case "doll":
                    {
                        return media_doll;
                    }

                case "dollhouse":
                    {
                        return media_dollhouse;
                    }

                case "dolls":
                    {
                        return media_dolls;
                    }

                case "dont":
                    {
                        return media_dont;
                    }

                case "face":
                    {
                        return media_face;
                    }

                case "family":
                    {
                        return media_family;
                    }

                case "find":
                    {
                        return media_find;
                    }

                case "fish":
                    {
                        return media_fish;
                    }

                case "have":
                    {
                        return media_have;
                    }

                case "hello":
                    {
                        return media_hello;
                    }

                case "her":
                    {
                        return media_her;
                    }

                case "hi":
                    {
                        return media_hi;
                    }

                case "hospital":
                    {
                        return media_hospital;
                    }

                case "i":
                    {
                        return media_i;
                    }

                case "is":
                    {
                        return media_is;
                    }

                case "it":
                    {
                        return media_it;
                    }

                case "its":
                    {
                        return media_its;
                    }

                case "know":
                    {
                        return media_know;
                    }

                case "lets":
                    {
                        return media_lets;
                    }

                case "look":
                    {
                        return media_look;
                    }

                case "lucy":
                    {
                        return media_lucy;
                    }

                case "lunch":
                    {
                        return media_lunch;
                    }

                case "milk":
                    {
                        return media_milk;
                    }

                case "mother":
                    {
                        return media_mother;
                    }

                case "my":
                    {
                        return media_my;
                    }

                case "new":
                    {
                        return media_new;
                    }

                case "no":
                    {
                        return media_no;
                    }

                case "nurses":
                    {
                        return media_nurses;
                    }

                case "oh":
                    {
                        return media_oh;
                    }

                case "one":
                    {
                        return media_one;
                    }

                case "picture":
                    {
                        return media_picture;
                    }

                case "play":
                    {
                        return media_play;
                    }

                case "please":
                    {
                        return media_please;
                    }

                case "puppet":
                    {
                        return media_puppet;
                    }

                case "puppies":
                    {
                        return media_puppies;
                    }

                case "school":
                    {
                        return media_school;
                    }

                case "see":
                    {
                        return media_see;
                    }

                case "sister":
                    {
                        return media_sister;
                    }

                case "square":
                    {
                        return media_square;
                    }

                case "surprise":
                    {
                        return media_surprise;
                    }

                case "the":
                    {
                        return media_the;
                    }

                case "they":
                    {
                        return media_they;
                    }

                case "this":
                    {
                        return media_this;
                    }

                case "three":
                    {
                        return media_three;
                    }

                case "too":
                    {
                        return media_too;
                    }

                case "two":
                    {
                        return media_two;
                    }

                case "want":
                    {
                        return media_want;
                    }

                case "we":
                    {
                        return media_we;
                    }

                case "what":
                    {
                        return media_what;
                    }

                case "wheres":
                    {
                        return media_wheres;
                    }

                case "yay":
                    {
                        return media_yay;
                    }

                case "yes":
                    {
                        return media_yes;
                    }

                case "you":
                    {
                        return media_you;
                    }


            }
            return null;
        }

    }
}
