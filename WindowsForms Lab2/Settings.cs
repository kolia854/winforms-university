using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab2
{
    class Singleton
    {
        private static Singleton settings;

        public static Singleton GetInstance()
        {
            if (settings == null)
            {
                settings = new Singleton();
            }
            return settings;
        }

        public static void GetCurrentSettings()
        {
            
        }


        private Singleton()
        {

        }

    }
}
