using System;
using System.ComponentModel.DataAnnotations;

namespace WindowsForms_Lab2
{
    [Serializable]
    public class Student : Prototype
    {
        public AdressClass Adress { get; set; }

        [Required(ErrorMessage = "ФИО - обязательное поле")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "Некорректная длина имени")]
        [RegularExpression(@"\D+", ErrorMessage = "Фио содержит недопустимые символы")]
        public string Fio { get; set; }

        [Range(15, 100, ErrorMessage = "Указанный возраст не подходит для студента")]
        public int Age { get; set; }
       
        public DateTime DateOfBirth { get; set; }
         

        [Required(ErrorMessage = "Укажите курс")]
        public int Course { get; set; }

        public int Avg { get; set; }

        [Required(ErrorMessage = "Укажите пол")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Укажите специальность")]
        public string Speciality { get; set; }

        public bool Brsm { get; set; }

        public Student(string fio, int age, DateTime birth, int course, int avg, string sex, string speciality, bool brsm, AdressClass adress)
        {
            Fio = fio;
            Age = age;
            DateOfBirth = birth;
            Course = course;
            Avg = avg;
            Sex = sex;
            Speciality = speciality;
            Brsm = brsm;
            Adress = adress;
        }

        public object Clone()
        {
            var ClonedStudent = new Student();
            ClonedStudent.Adress = Adress;
            ClonedStudent.Course = Course;
            ClonedStudent.Fio = Fio;
            ClonedStudent.Sex = Sex;
            ClonedStudent.Speciality = Speciality;
            ClonedStudent.Avg = Avg;
            ClonedStudent.Age = Age;
            ClonedStudent.Brsm = Brsm;
            ClonedStudent.DateOfBirth = DateOfBirth;
            return ClonedStudent;
        }   

        public void CreateSnapshot()
        {
            var snapshot = new Snapshot(this);
        }

        public Student()
        {

        }
    }
}
