using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LookAndFind
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public LookAndFind(int Id, string Image)
        {
            this.Id = Id;
            this.Image = Image;
        }
    }
}
