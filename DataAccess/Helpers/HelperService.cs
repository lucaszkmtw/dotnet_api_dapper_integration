using DataAccess.Mapper;
using DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helpers
{
    public class HelperService
    {

        private static HelperService instance;
        //private Utils.DateUtilsService dateUtils;


        public static HelperService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HelperService();
                }
                return instance;
            }
        }





    }
}
