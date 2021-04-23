using System;

namespace WindowsForms_Lab2
{
    class StudentFactory : IHateFactory
    {
        public Student CreateStudent(string fio, int age, DateTime birth, int course, int avg, string sex, string speciality, bool brsm, AdressClass adress)
        {
            return new Student(fio, age, birth, course, avg, sex, speciality, brsm, adress);
        }

        public AdressClass CreateAdress(string c, string s, string h, string f)
        {
            AdressClass adress = new AdressClass();
            adress.City = c;
            adress.Street = s;
            adress.HouseNumber = h;
            adress.FlatNumber = f;
            return adress;
        }
    }
}
