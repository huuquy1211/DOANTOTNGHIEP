using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using Data;
namespace BLL
{
    public class WordBLL
    {
        private static readonly EnglishGameEntities db = new EnglishGameEntities();

        public WordBLL()
        {

        }

        public List<Data.Word> GetWordsOfUnit(int Unit)
        {
            List<Data.Word> lst = db.Words.Where(x=>x.Units.Where(t=>t.Id==Unit).Count()!=0).ToList().Select(z=>new Data.Word(z.Id,z.Image,z.Voice)).ToList();

            return lst;
        }
    }
}
