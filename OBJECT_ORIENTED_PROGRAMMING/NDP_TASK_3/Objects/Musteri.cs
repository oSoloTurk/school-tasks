using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Objects
{
    class Musteri
    {
        private int _id { get; }
        private string _name { get; set; }
        private Gender _gender { get; set; }
        private string _phoneNumber { get; set; }
        private DateTime _created { get; }

        public Musteri(string name, string gender, string phoneNumber)
        {
            _id = Musteriler.GetInstance().GetAutoID();
            _name = name;
            _gender = gender.ToUpper().Equals("MALE") ? Gender.MALE : Gender.FEMALE;
            _phoneNumber = phoneNumber;
            _created = DateTime.Now;
        }
        public Musteri(int id, string name, string gender, string phoneNumber, DateTime created)
        {
            _id = id;
            _name = name;
            _gender = gender.ToUpper().Equals("MALE") ? Gender.MALE : Gender.FEMALE;
            _phoneNumber = phoneNumber;
            _created = created;
        }

        override
        public string ToString()
        {
            return $"{_id}{Environments.CodingSeperator}{_name}{Environments.CodingSeperator}{_gender}{Environments.CodingSeperator}{_phoneNumber}{Environments.CodingSeperator}{_created.ToBinary()}";
        }
    }

    enum Gender
    {
        MALE, FEMALE
    }
}
