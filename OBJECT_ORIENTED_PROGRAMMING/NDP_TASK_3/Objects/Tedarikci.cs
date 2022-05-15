using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Objects
{
    class Tedarikci
    {
        private int _id { get; }
        private string _name { get; set; }
        private string _phoneNumber { get; set; }
        private DateTime _created { get; }

        public Tedarikci(string name, string phoneNumber)
        {
            _id = Tedarikciler.GetInstance().GetAutoID();
            _name = name;
            _phoneNumber = phoneNumber;
            _created = DateTime.Now;
        }
        public Tedarikci(int id, string name, string phoneNumber, DateTime created)
        {
            _id = id;
            _name = name;
            _phoneNumber = phoneNumber;
            _created = created;
        }

        override
        public string ToString()
        {
            return $"{_id}{Environments.CodingSeperator}{_name}{Environments.CodingSeperator}{_phoneNumber}{Environments.CodingSeperator}{_created.ToBinary()}";
        }
    }

}
