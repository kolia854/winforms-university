using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WindowsForms_Lab2
{
    [Serializable]
    public class Student
    {
        private string fio;
        private int age;
        private DateTime dateofbirth;
        private int course;
        private int avg;
        private string sex;
        private string speciality;
        private bool brsm;
        public AdressClass Adress;


        [Required(ErrorMessage = "ФИО - обязательное поле")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "Некорректная длина имени")]
        [RegularExpression(@"\D+", ErrorMessage = "Фио содержит недопустимые символы")]
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

        [Range(15, 100, ErrorMessage = "Указанный возраст не подходит для студента")]
        public int Age
         {
            get { return age; }
            set { age = value; }
        }

        public DateTime DateOfBirth
         {
            get { return dateofbirth; }
            set { dateofbirth = value; }
        }

        [Required(ErrorMessage = "Укажите курс")]
        public int Course
        {
            get { return course; }
            set { course = value; }
        }

        public int Avg
        {
            get { return avg; }
            set { avg = value; }
        }

        [Required(ErrorMessage = "Укажите пол")]
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        [Required(ErrorMessage = "Укажите специальность")]
        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; }
        }

        public bool Brsm
        {
            get { return brsm; }
            set { brsm = value; }
        }
    }
}
