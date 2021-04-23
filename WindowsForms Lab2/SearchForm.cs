using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace WindowsForms_Lab2
{
    public partial class SearchForm : Form
    {
        public List<Student> SearchResults = new List<Student>();
        AdressClass adress = new AdressClass();
        Student boof = new Student();
        Form1 f;
        public SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(Form1 f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void Output_Click(object sender, EventArgs e)
        {


            foreach (var b in groupBox1.Controls)
            {
                if (b is RadioButton)
                {
                    if ((b as RadioButton).Checked)
                        boof.Course = Convert.ToInt32((b as RadioButton).Text);
                }
            }

            foreach (var b in groupBox2.Controls)
            {
                if (b is RadioButton)
                {
                    if ((b as RadioButton).Checked)
                        boof.Sex = (string)(b as RadioButton).Text;
                }
            }

            boof.Speciality = SpPicker.Text;

            adress.City = comboBox1.Text;

            boof.Adress = adress;

            f.listBox1.Items.Clear();

            XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
            List<Student> SavedStudents = new List<Student>();
            using (FileStream fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {
                SavedStudents = (List<Student>)formatter.Deserialize(fs);
            }

            foreach (Student st in SavedStudents)
            {
                if (boof.Sex != null)
                {
                    if (st.Sex != boof.Sex)
                        continue;
                }

                if (boof.Course != 0)
                {
                    if (st.Course != boof.Course)
                        continue;
                }

                if (boof.Speciality != "")
                {
                    if (st.Speciality != boof.Speciality)
                        continue;
                }

                if (boof.Adress.City != "")
                {
                    if (st.Adress.City != boof.Adress.City)
                        continue;
                }

                SearchResults.Add(st);
            }

            XmlSerializer format = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream("SearchRasults.xml", FileMode.Create))
            {
                    formatter.Serialize(fs, SearchResults);
            }

            var a = from s in SearchResults
                    orderby s.Fio
                    select s;
            foreach (var st in a)
            {
                string info;
                info = st.Fio;
                f.listBox1.Items.Add(info);
                info = "Адрес: " + st.Adress.City + st.Adress.Street + " д." + st.Adress.HouseNumber + " кв." + st.Adress.FlatNumber;
                f.listBox1.Items.Add(info);
                info = "Дата рождения: " + st.DateOfBirth.Year + " " + st.DateOfBirth.Month + " " + st.DateOfBirth.Day;
                f.listBox1.Items.Add(info);
                info = "Возраст: " + st.Age;
                f.listBox1.Items.Add(info);
                info = "Пол: " + st.Sex;
                f.listBox1.Items.Add(info);
                info = "Специальность: " + st.Speciality;
                f.listBox1.Items.Add(info);
                info = "Курс: " + st.Course;
                f.listBox1.Items.Add(info);
                info = "Член брсм: " + st.Brsm;
                f.listBox1.Items.Add(info);
                f.listBox1.Items.Add("");
            }
        }



        private void SearchForm_Load(object sender, EventArgs e)
        {

        }
    }
}
