using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab2
{
    abstract class KolyaBovkun
    {
        virtual public bool IsKolyaBovkun(Student student)
        {
            if (student.Fio == "Коля Бовкун")
                return true;
            else
                return false;
        }

        virtual public void ToKolyaBovkun(Student student)
        {
            student.Fio = "Коля бовкун";
        }
    }
}
