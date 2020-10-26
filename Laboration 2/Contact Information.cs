using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    class ContactInfo
    {
        //Instansvariabler för kontaktlistan
        private string _firstName;
        private string _surName;
        private string _address;
        private string _phoneHome;
        private string _phoneMob;

        //Konstruktor för att bestämma värde på instansvariabler
        public ContactInfo(string firstName, string surName, string address, string phoneHome, string phoneMob)
        {
            _firstName = firstName;
            _surName = surName;
            _address = address;
            _phoneHome = phoneHome;
            _phoneMob = phoneMob;
        }

        //Properties för att kunna ändra och söka efter instansvariablerna
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string SurName { get { return _surName; } set { _surName = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string PhoneHome { get { return _phoneHome; } set { _phoneHome = value; } }
        public string PhoneMob { get { return _phoneMob; } set { _phoneMob = value; } }

        //Metod för att skriva ut värdet på instansvariablerna
        public void Contacts()
        {
            Console.Write($"Name: {_surName}, {_firstName} \nAddress: {_address} \nHome number: {_phoneHome} \nPhone Number: {_phoneMob}\n\n");
        }
    }
}
