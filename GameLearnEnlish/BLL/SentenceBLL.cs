using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SentenceBLL
    {
        private static readonly EnglishGameEntities db = new EnglishGameEntities();

        public SentenceBLL()
        {

        }
        public List<Data.Sentence> GetSentencesOfUnit(int Unit)
        {
            List<Data.Sentence> lst = db.Sentences.Where(x => x.Units.Where(t => t.Id == Unit).Count() != 0).ToList().Select(z => new Data.Sentence(z.Id, z.Image, z.Sound, z.Text)).OrderBy(x=>x.Id).ToList();
            return lst;
        }
    }
}
