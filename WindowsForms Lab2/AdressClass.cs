using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab2
{
    [Serializable]
    [AdressValidation]    
    public class AdressClass
    {
        public string City;
        public string Street;
        public string HouseNumber;
        public string FlatNumber;
    }
}
