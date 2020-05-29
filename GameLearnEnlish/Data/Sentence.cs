using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Sentence
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Sound { get; set; }
        public string Text { get; set; }

        public Sentence(int Id, string Image, string Sound,string Text)
        {
            this.Id = Id;
            this.Image = Image;
            this.Sound = Sound;
            this.Text = Text;
        }
    }
}
