using GameLearnEnlish.Model;
using GameLearnEnlish.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLearnEnlish.Utility
{
   public class Global
   {
        private static Global _instance;
        public static Global Instance
        { 
            get
            {
                if (_instance == null)
                {
                    _instance = new Global();
                }
                return _instance;
            } 
        }      

        public  MainWindow WindowMain;
        public  SelectElementUC ButtonMenuSelect;
        public  Unit UnitSelect;
        //public void StopVoid()
        //{
        //    HomeUC.homeUC.StopVoid();
        //    MenuUC.menuUC.StopVoid();
        //    BoxSubMenuUC.boxSubMenuUC.StopVoid();
        //    UC_Matching.uC_Matching.StopVoid();
        //    UC_Description.uC_Description.StopVoid();
        //}
    }
}
