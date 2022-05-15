using NDP_TASK_3.Api;
using NDP_TASK_3.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Reporters
{
    internal class DepodakiUrunler : IReporter
    {
        private IManager<Urun> manager;

        public DepodakiUrunler()
        {
            manager = Stoklar.GetInstance();
        }

        IReport IReporter.Report(DateTime filterDate)
        {
            Report report = new Report();

            report.getColumns().Add("ID");
            report.getColumns().Add("Isim");
            report.getColumns().Add("Pozisyon");
            report.getColumns().Add("Adet");
            foreach(Urun urun in manager.GetElements())
            {
                if (!urun.Position.Equals("Depoda"))
                {
                    continue;
                }

                List<string> row = new List<string>();
                row.Add(urun.Id.ToString());
                row.Add(urun.Name);
                row.Add(urun.Position.ToString());
                row.Add(urun.Count.ToString());
                report.getRows().Add(row);
            }

            return report;
        }
    
    }
}
