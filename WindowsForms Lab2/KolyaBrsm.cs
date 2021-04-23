using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab2
{
    class KolyaBrsm : KolyaBovkun
    {
        public override bool IsKolyaBovkun(Student student)
        {
            if (student.Brsm)
                return false;
            else
                return true;
        }

        public override void ToKolyaBovkun(Student student)
        {
            student.Brsm = false;
            System.Windows.Forms.MessageBox.Show("Никакого брсм!");
        }
    }
}
