using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Painting
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string ImagePainted { get; set; }
        public string Request { get; set; }
        public int Color { get; set; }
        public Painting(int Id, string Image, string ImagePainted, string Request, int Color)
        {
            this.Id = Id;
            this.Image = Image;
            this.ImagePainted = ImagePainted;
            this.Request = Request;
            this.Color = Color;
        }

    }
}
