using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab2
{
    class KolyaCourse : KolyaBovkun
    {
        public override bool IsKolyaBovkun(Student student)
        {
            if (student.Course == 2)
                return false;
            else
                return true;
        }

        public override void ToKolyaBovkun(Student student)
        {
            student.Course = 2;
        }
    }
}
