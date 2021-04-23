using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab2
{
    class Snapshot
    {
        private AdressClass Adress { get; set; }
        private string Fio { get; set; }
        private int Age { get; set; }
        private DateTime DateOfBirth { get; set; }
        private int Course { get; set; }
        private int Avg { get; set; }
        private string Sex { get; set; }
        private string Speciality { get; set; }
        private bool Brsm { get; set; }

        public Snapshot(Student student)
        {
            Fio = student.Fio;
            Age = student.Age;
            DateOfBirth = student.DateOfBirth;
            Course = student.Course;
            Avg = student.Avg;
            Sex = student.Sex;
            Speciality = student.Speciality;
            Brsm = student.Brsm;
            Adress = student.Adress;
        }

        public void Restore(Student student)
        {
            student.Fio = Fio;
            student.Age = Age;
            student.DateOfBirth = DateOfBirth;
            student.Course = Course;
            student.Avg = Avg;
            student.Sex = Sex;
            student.Speciality = Speciality;
            student.Brsm = Brsm;
            student.Adress = Adress;


        }
    }
}
