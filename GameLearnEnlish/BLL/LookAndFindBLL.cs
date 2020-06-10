using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LookAndFindBLL
    {
        private static readonly EnglishGameEntities db = new EnglishGameEntities();
        public LookAndFindBLL()
        {

        }
        public List<Data.LookAndFind> GetLookAndFinds(int Unit)
        {
            List<Data.LookAndFind> lst = db.LookAndFinds.Where(x => x.Units.Where(t => t.Id == Unit).Count() != 0).ToList().Select(z => new Data.LookAndFind(z.Id, z.Image)).ToList();
            return lst;
        }
    }
}
