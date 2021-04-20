using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WindowsForms_Lab2
{
    class AdressValidation : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            AdressClass adress = obj as AdressClass;
            int MistakeCounter = 0;
            int num = 0;
            string Numbers = "1234567890";
            foreach (char s in Numbers)
            {
                if (adress.City.Contains(s))
                {
                    MistakeCounter++;
                }
            }
            this.ErrorMessage = "";
            if (adress == null)
            {
                this.ErrorMessage += "Заполните поле адреса\n";
            }

            else if (adress.City == "")
            {
                this.ErrorMessage += "Заполните поле города\n";
            }
            else if (MistakeCounter != 0)
            {
                this.ErrorMessage += "Поле города содержит недопустимые символы\n";
            }

            else if (adress.Street == "")
            {
                this.ErrorMessage += "Заполните поле улицы\n";
            }


            else if (adress.HouseNumber == "")
            {
                this.ErrorMessage += "Заполните поле номера дома\n";
            }

            try
            {
                num = Convert.ToInt32(adress.FlatNumber);
            }
            catch
            {
                this.ErrorMessage += "Номер квартиры содержит недопустимые символы или пусто\n";
            }
            if (num < 1 || num > 2000)
            {
                this.ErrorMessage += "Неподходящий номер квартиры\n";
            }
            if (!string.IsNullOrEmpty(this.ErrorMessage))
                return false;
            return true;
        }
    }
}
