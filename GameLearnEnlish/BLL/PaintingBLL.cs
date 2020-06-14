using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PaintingBLL
    {
        private static readonly EnglishGameEntities db = new EnglishGameEntities();

        public PaintingBLL()
        {

        }
        public List<Data.Painting> GetPaintingDataOfUnit(int Unit)
        {
            List<Data.Painting> lst = db.Paintings.Where(x => x.Units.Where(t => t.Id == Unit).Count() != 0).ToList().Select(z => new Data.Painting(z.Id, z.Image, z.ImagePainted, z.Request, z.Color.Value)).OrderBy(x => x.Id).ToList();
            return lst;
        }
    }
}
