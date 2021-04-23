using System;

namespace WindowsForms_Lab2
{
    interface IHateFactory
    {
        Student CreateStudent(string fio, int age, DateTime birth, int course, int avg, string sex, string speciality, bool brsm, AdressClass adress);
        AdressClass CreateAdress(string city, string street, string house, string flat);
    }
}
