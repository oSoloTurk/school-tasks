using NDP_TASK_3.Api;
using NDP_TASK_3.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Reporters
{
    internal class GunlukSiparisler : IReporter
    {
        private IManager<Siparis> manager;

        public GunlukSiparisler()
        {
            manager = Siparisler.GetInstance();
        }

        IReport IReporter.Report(DateTime filterDate)
        {
            Report report = new Report();

            report.getColumns().Add("ID");
            report.getColumns().Add("Urun ID");
            report.getColumns().Add("Uretici ID");
            report.getColumns().Add("Adet");
            report.getColumns().Add("Tarih");
            foreach (Siparis siparis in manager.GetElements())
            {
                if (filterDate.Date != siparis.ActionDate.Date)
                {
                    continue;
                }

                List<string> row = new List<string>();
                row.Add(siparis.Id.ToString());
                row.Add(siparis.ProductId.ToString());
                row.Add(siparis.ProducerId.ToString());
                row.Add(siparis.Count.ToString());
                row.Add(siparis.ActionDate.ToString());
                report.getRows().Add(row);
            }

            return report;
        }

    }
}
