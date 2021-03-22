﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace WindowsForms_Lab2
{
    public partial class Form1 : Form
    {
        public List<Student> studentList = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var student = new Student();
            var adress = new AdressClass();

            if (SpPicker.Text != "")
            {
                adress.City = SpPicker.Text;
            }
            else
            {
                throw new Exception("Введите адрес корректно");
            }

            adress.Street = Street.Text;
            adress.HouseNumber = Home.Text;
            adress.FlatNumber = Flat.Text;

            student.Adress = adress;

            if (BRSMcheckBox.Checked)
                student.Brsm = true;
            else student.Brsm = false;

            if (Fio.Text != "")
            {
                student.Fio = Fio.Text;
            }
            else
            {
                throw new Exception("ФИО - обязательное поле");
            }


            if (dateTimePicker1.Value.Year < DateTime.Now.Year - 15 && dateTimePicker1.Value.Year > 1900)
            {
                student.DateOfBirth = dateTimePicker1.Value;
            }
            else
            {
                throw new Exception("указанный возраст не подходит для студента");
            }

            foreach (var b in groupBox1.Controls)
            {
                if (b is RadioButton)
                {
                    if ((b as RadioButton).Checked)
                        student.Course = Convert.ToInt32((b as RadioButton).Text);
                }
            }
            if (student.Course == 0)
                throw new Exception("Курс - обязательное поле!");

            student.Speciality = SpPicker.Text;
            if (student.Speciality == null)
                throw new Exception("Специальность - обязательное поле!");

            student.Avg = Convert.ToInt32(numericUpDown1.Value);

            foreach (var b in groupBox2.Controls)
            {
                if (b is RadioButton)
                {
                    if ((b as RadioButton).Checked)
                        student.Sex = (b as RadioButton).Text;
                }
            }

            student.Age = DateTime.Now.Year - dateTimePicker1.Value.Year;

            studentList.Add(student);

            XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("Students.xml", FileMode.Create))
            {
                {
                    formatter.Serialize(fs, studentList);
                }
            }

            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Fio.Text = "";
            dateTimePicker1.Value = dateTimePicker1.MinDate;
            SpPicker.Text = "";
            foreach (var b in groupBox2.Controls)
            {
                if (b is RadioButton)
                {
                    (b as RadioButton).Checked = false;
                }
            }
            foreach (var b in groupBox1.Controls)
            {
                if (b is RadioButton)
                {
                    (b as RadioButton).Checked = false;
                }
            }
            numericUpDown1.Value = 1;
            BRSMcheckBox.Checked = false;
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
            List<Student> SavedStudents = new List<Student>();
            using (FileStream fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {

                SavedStudents = (List<Student>)formatter.Deserialize(fs);
            }
            foreach (Student st in SavedStudents)
            {
                string info;
                info = st.Fio;
                listBox1.Items.Add(info);
                info = "Адрес: " + st.Adress.City + st.Adress.Street + " д." + st.Adress.HouseNumber + " кв." + st.Adress.FlatNumber;
                listBox1.Items.Add(info);
                info = "Дата рождения: " + st.DateOfBirth.Year + " " + st.DateOfBirth.Month + " " + st.DateOfBirth.Day;
                listBox1.Items.Add(info);
                info = "Возраст: " + st.Age;
                listBox1.Items.Add(info);
                info = "Пол: " + st.Sex;
                listBox1.Items.Add(info);
                info = "Специальность: " + st.Speciality;
                listBox1.Items.Add(info);
                info = "Курс: " + st.Course;
                listBox1.Items.Add(info);
                info = "Член брсм: " + st.Brsm;
                listBox1.Items.Add(info);
            }
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
