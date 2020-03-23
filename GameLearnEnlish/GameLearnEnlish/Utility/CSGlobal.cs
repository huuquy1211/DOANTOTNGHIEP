using GameLearnEnlish.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLearnEnlish.Utility
{
   public class CSGlobal
   {
        private static CSGlobal _instance;
        public static CSGlobal Instance
        { 
            get
            {
                if (_instance == null)
                {
                    _instance = new CSGlobal();
                }
                return _instance;
            } 
        }      

        public  MainWindow WindowMain;
   }
}
