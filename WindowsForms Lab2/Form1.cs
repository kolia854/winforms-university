using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel.DataAnnotations;

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

            adress.City = comboBox1.Text;

            adress.Street = Street.Text;
            adress.HouseNumber = Home.Text;
            adress.FlatNumber = Flat.Text;

            var AdressResults = new List<ValidationResult>();
            var Context = new ValidationContext(adress);
            string strWithErrror = "";
            if (!Validator.TryValidateObject(adress, Context, AdressResults, true))
            {
                foreach (var error in AdressResults)
                {
                    strWithErrror += error.ErrorMessage + "\n";
                    label9.Text = "Программа приостановлена";
                }
                MessageBox.Show(strWithErrror);
                return;
            }

            student.Adress = adress;

            if (BRSMcheckBox.Checked)
                student.Brsm = true;
            else
                student.Brsm = false;

            student.Fio = Fio.Text;

            student.DateOfBirth = dateTimePicker1.Value;
     
            foreach (var b in groupBox1.Controls)
            {
                if (b is RadioButton)
                {
                    if ((b as RadioButton).Checked)
                        student.Course = Convert.ToInt32((b as RadioButton).Text);
                }
            }

            student.Speciality = SpPicker.Text;

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

            var resultsSt = new List<ValidationResult>();
            var context = new ValidationContext(student);
            strWithErrror = "";

            if (!Validator.TryValidateObject(student, context, resultsSt, true))
            {
                foreach (var error in resultsSt)
                {
                    strWithErrror += error.ErrorMessage + "\n";
                    label9.Text = "Программа приостановлена";

                }
                MessageBox.Show(strWithErrror);
                return;
            }

            studentList.Add(student);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream("Students.xml", FileMode.Create))
            {
                {
                    formatter.Serialize(fs, studentList);
                }
            }

            label9.Text = "Объект добавлен";
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
            listBox1.Items.Clear();

            XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
            List<Student> SavedStudents = new List<Student>();
            using (FileStream fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {

                SavedStudents = (List<Student>)formatter.Deserialize(fs);
            }

            label9.Text = "Сохраненных объектов: " + SavedStudents.Count;

            if (SearchText.Text == "")
            {
                foreach (Student st in SavedStudents)
                {
                    string info;
                    info = st.Fio;
                    listBox1.Items.Add(info);
                    info = "Адрес: " + st.Adress.City + " ул." + st.Adress.Street + " д." + st.Adress.HouseNumber + " кв." + st.Adress.FlatNumber;
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
                    listBox1.Items.Add("");
                }
            }

            else
            {

                Regex search = new Regex($@"{SearchText.Text}(\w*)");
                foreach (Student st in SavedStudents)
                {
                    MatchCollection matches = search.Matches(st.Fio);
                    if (matches.Count > 0)
                    {
                        string info;
                        info = st.Fio;
                        listBox1.Items.Add(info);
                        info = "Адрес: " + st.Adress.City + " ул." + st.Adress.Street + " д." + st.Adress.HouseNumber + " кв." + st.Adress.FlatNumber;
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
                        listBox1.Items.Add("");
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SearchForm newForm = new SearchForm(this);
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("версия 22.2.2.2 (сделал Коля Бовкун)");
        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
