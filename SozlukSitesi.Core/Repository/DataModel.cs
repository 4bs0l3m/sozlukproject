using SozlukSitesi.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukSitesi.Core.Repository
{
    public class DataModel
    {
        private static SozlukContext context;
        public static SozlukContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new SozlukContext();
                    return context;
                }
                return context;
            }
        }
    }
}
