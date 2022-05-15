using NDP_TASK_3.Api;
using NDP_TASK_3.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Reporters
{
    internal class GunlukSatilanUrunler : IReporter
    {
        private IManager<Satis> manager;

        public GunlukSatilanUrunler()
        {
            manager = Satislar.GetInstance();
        }

        IReport IReporter.Report(DateTime filterDate)
        {
            Report report = new Report();

            report.getColumns().Add("ID");
            report.getColumns().Add("Urun ID");
            report.getColumns().Add("Alici ID");
            report.getColumns().Add("Adet");
            report.getColumns().Add("Tarih");
            foreach (Satis satis in manager.GetElements())
            {
                if (filterDate.Date != satis.ActionDate.Date)
                {
                    continue;
                }

                List<string> row = new List<string>();
                row.Add(satis.Id.ToString());
                row.Add(satis.ProductId.ToString());
                row.Add(satis.BuyerId.ToString());
                row.Add(satis.Count.ToString());
                row.Add(satis.ActionDate.ToString());
                report.getRows().Add(row);
            }

            return report;
        }
    }
}
