using NDP_TASK_3.Api;
using NDP_TASK_3.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Reporters
{
    internal class GunlukMaliTablo : IReporter
    {
        private IManager<Satis> satisManager;
        private IManager<Siparis> siparisManager;
        private IManager<Gider> giderManager;

        public GunlukMaliTablo()
        {
            satisManager = Satislar.GetInstance();
            siparisManager = Siparisler.GetInstance();
            giderManager = Giderler.GetInstance();
        }

        IReport IReporter.Report(DateTime filterDate)
        {
            Report report = new Report();

            report.getColumns().Add("Gelir");
            report.getColumns().Add("Gider");
            report.getColumns().Add("Tarih");
            Dictionary<DateTime,float> gelirler = new Dictionary<DateTime, float>();
            Dictionary<DateTime, float> giderler = new Dictionary<DateTime, float>();
            foreach (Siparis siparis in siparisManager.GetElements())
            {
                float siparisTutari = giderler.GetValueOrDefault(siparis.ActionDate, 0);
                Urun urun = Stoklar.GetInstance().GetElements().Find(urun => urun.Id == siparis.ProductId);
                if(urun != null)
                {
                    siparisTutari += urun.Price * siparis.Count;
                    giderler[siparis.ActionDate.Date] = siparisTutari;
                }

            }

            foreach (Gider gider in giderManager.GetElements())
            {
                float giderTutari = giderler.GetValueOrDefault(gider.Created.Date, 0);
                giderTutari += gider.Value;
                giderler[gider.Created.Date] = giderTutari;
            }


            foreach (Satis satis in satisManager.GetElements())
            {
                float satisTutari = gelirler.GetValueOrDefault(satis.ActionDate.Date, 0);
                Urun urun = Stoklar.GetInstance().GetElements().Find(urun => urun.Id == satis.ProductId);
                if (urun != null)
                {
                    satisTutari += urun.Price * satis.Count;
                    gelirler[satis.ActionDate.Date] = satisTutari;
                }
            }
            List<DateTime> printedDates = new List<DateTime>();

            foreach(DateTime date in giderler.Keys)
            {
                List<string> row = new List<string>();
                row.Add(gelirler.GetValueOrDefault(date.Date, 0).ToString());
                row.Add(giderler.GetValueOrDefault(date.Date, 0).ToString());
                row.Add(date.Date.ToString());
                report.getRows().Add(row);
                printedDates.Add(date.Date);
            }


            foreach (DateTime date in gelirler.Keys)
            {
                if (printedDates.Contains(date.Date)) continue;

                List<string> row = new List<string>();
                row.Add(gelirler.GetValueOrDefault(date.Date, 0).ToString());
                row.Add(giderler.GetValueOrDefault(date.Date, 0).ToString());
                row.Add(date.Date.ToString());
                report.getRows().Add(row);
            }

            return report;
        }

    }
}
