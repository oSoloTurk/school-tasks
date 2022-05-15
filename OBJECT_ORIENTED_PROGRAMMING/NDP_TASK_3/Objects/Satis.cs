using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Objects
{
    class Satis
    {
        public int Id { get; }
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public int Count { get; set; }
        public DateTime ActionDate { get; set; }

        public Satis(int id, int productId, int buyerId, int count, DateTime actionDate)
        {
            Id = id;
            ProductId = productId;
            BuyerId = buyerId;
            Count = count;
            ActionDate = actionDate;
        }

        public Satis(int productId, int buyerId, int count, DateTime actionDate)
        {
            Id = Satislar.GetInstance().GetAutoID();
            ProductId = productId;
            BuyerId = buyerId;
            Count = count;
            ActionDate = actionDate;
        }

        override
        public string ToString()
        {
            return $"{Id}{Environments.CodingSeperator}{ProductId}{Environments.CodingSeperator}{BuyerId}{Environments.CodingSeperator}{Count}{Environments.CodingSeperator}{ActionDate.ToBinary()}";
        }
    }

}
