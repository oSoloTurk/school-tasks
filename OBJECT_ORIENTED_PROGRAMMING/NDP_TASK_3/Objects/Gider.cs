using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Objects
{
    class Gider
    {
        public int Id { get; }
        public string Name { get; set; }
        public int Value { get; set; }
        public DateTime Created { get; }

        public Gider(string name, int value)
        {
            Id = Musteriler.GetInstance().GetAutoID();
            Name = name;
            Value = value;
            Created = DateTime.Now;
        }
        public Gider(int id, string name, int value, DateTime created)
        {
            Id = id;
            Name = name;
            Value = value;
            Created = created;
        }

        override
        public string ToString()
        {
            return $"{Id}{Environments.CodingSeperator}{Name}{Environments.CodingSeperator}{Value}{Environments.CodingSeperator}{Created.ToBinary()}";
        }
    }
}
