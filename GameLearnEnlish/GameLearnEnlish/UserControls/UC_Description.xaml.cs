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
    /// Interaction logic for UC_Description.xaml
    /// </summary>
    /// 
    
    public partial class UC_Description : UserControl
    {
        public static UC_Description uC_Description = null;
        private MediaPlayer mediaPlayerVoidDescription = new MediaPlayer();
        private string VoidDescription;//âm description
        public UC_Description()
        {
            InitializeComponent();
            uC_Description = this;
        }

       
        public void CallTextDescription(string TextDescription)
        {
            this.Dispatcher.Invoke(() =>
            {
                txtDescription.Text = TextDescription;
            });
            
        }

    }
}
