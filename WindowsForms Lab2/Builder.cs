using System;

namespace WindowsForms_Lab2
{
    class Builder
    {
        public Student BuildStudent()
        {
            var student = new Student();
            return student;
        }

        public Student BuildStudentWAdress(AdressClass adress)
        {
            var student = new Student();
            student.Adress = adress;
            return student;
        }

        public Student StandartStudent(AdressClass adress)
        {
            var student = new Student();
            student.Fio = "Коля Бовкун";
            student.Age = 19;
            student.DateOfBirth = new DateTime(2001, 12, 19);
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
