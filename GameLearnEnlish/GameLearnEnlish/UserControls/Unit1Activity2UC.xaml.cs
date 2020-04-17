using System;
using System.Collections.Generic;
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
    /// Interaction logic for Unit1Activity2UC.xaml
    /// </summary>
    public partial class Unit1Activity2UC : UserControl
    {
        public Unit1Activity2UC()
        {
            InitializeComponent();
        }


        #region [Question 1]
        private void Question1_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void Question1_MouseEnter(object sender, MouseEventArgs e)
        {

            imgGuyaudio1.Opacity = 0.7;
            lblQuestion1.Opacity = 0.7;
            imgNode1.Opacity = 0.7;
        }

        private void Question1_MouseLeave(object sender, MouseEventArgs e)
        {
            imgGuyaudio1.Opacity = 1;
            lblQuestion1.Opacity = 1;
            imgNode1.Opacity = 1;
        }
        #endregion

        #region [Question 2]
        private void Question2_MouseEnter(object sender, MouseEventArgs e)
        {

            imgGuyaudio2.Opacity = 0.7;
            lblQuestion2.Opacity = 0.7;
            imgNode2.Opacity = 0.7;
        }

        private void Question2_MouseLeave(object sender, MouseEventArgs e)
        {
            imgGuyaudio2.Opacity = 1;
            lblQuestion2.Opacity = 1;
            imgNode2.Opacity = 1;
        }
        #endregion

        #region [Question 3]
        private void Question3_MouseEnter(object sender, MouseEventArgs e)
        {
            imgGuyaudio3.Opacity = 0.7;
            lblQuestion3.Opacity = 0.7;
            imgNode3.Opacity = 0.7;
        }
        private void Question3_MouseLeave(object sender, MouseEventArgs e)
        {
            imgGuyaudio3.Opacity = 1;
            lblQuestion3.Opacity = 1;
            imgNode3.Opacity = 1;
           
        }
        #endregion

       
    }
}
