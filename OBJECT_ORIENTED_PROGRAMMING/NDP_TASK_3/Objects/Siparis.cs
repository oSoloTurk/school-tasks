using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Objects
{
    class Siparis
    {
        public int Id { get; }
        public int ProductId { get; set; }
        public int ProducerId { get; set; }
        public int Count { get; set; }
        public DateTime ActionDate { get; set; }

        public Siparis(int id, int productId, int producerId, int count, DateTime actionDate)
        {
            Id = id;
            ProductId = productId;
            ProducerId = producerId;
            Count = count;
            ActionDate = actionDate;
        }

        public Siparis(int productId, int producerId, int count, DateTime actionDate)
        {
            Id = Satislar.GetInstance().GetAutoID();
            ProductId = productId;
            ProducerId = producerId;
            Count = count;
            ActionDate = actionDate;
        }

        override
        public string ToString()
        {
            return $"{Id}{Environments.CodingSeperator}{ProductId}{Environments.CodingSeperator}{ProducerId}{Environments.CodingSeperator}{Count}{Environments.CodingSeperator}{ActionDate.ToBinary()}";
        }
    }

}
