using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab2
{
    class Builder
    {
        public Student BuildStudent()
        {
            Student student = new Student();
            return student;
        }

        public Student BuildStudentWAdress(AdressClass adress)
        {
            Student student = new Student();
            student.Adress = adress;
            return student;
        }

        public Student BuildFullStudent(AdressClass adress)
        {
            Student student = new Student();
            student.Fio = "Коля Бовкун";
            student.Age = 19;
            student.DateOfBirth = new DateTime(2001, 12, 19); ;
            student.Course = 2;
            student.Avg = 10;
            student.Sex = "м";
            student.Speciality = "ИСИТ";
            student.Brsm = false;
            student.Adress = adress;
            return student;
        }
    }
}
