using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Objects
{
    class Urun
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }

        public Urun(int id, string name, string position, int count, float price)
        {
            Id = id;
            Name = name;
            Position = position;
            Count = count;
            Price = price;
        }
        public Urun(string name, string position, int count, float price)
        {
            Id = Stoklar.GetInstance().GetAutoID();
            Name = name;
            Position = position;
            Count = count;
            Price = price;
        }

        override
        public string ToString()
        {
            return $"{Id}{Environments.CodingSeperator}{Name}{Environments.CodingSeperator}{Position}{Environments.CodingSeperator}{Count}{Environments.CodingSeperator}{Price}";
        }
    }

}
