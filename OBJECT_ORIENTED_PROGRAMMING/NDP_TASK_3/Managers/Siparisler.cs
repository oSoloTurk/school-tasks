using NDP_TASK_3.Api;
using NDP_TASK_3.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3
{
    class Siparisler : IManager<Siparis>
    {
        private List<Siparis> siparisler { get; }
        private static Siparisler _instance;
        private Siparisler()
        {
            siparisler = new List<Siparis>();
            InitFromFile();
        }

        public static Siparisler GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Siparisler();
            }
            return _instance;
        }

        private void InitFromFile()
        {
            string[]? fileInput;
            try
            {
                fileInput = File.ReadAllLines(Directory.GetCurrentDirectory() + Environments.SiparislerDosyaYolu);
            }
            catch
            {
                return;
            }
            foreach (string rSiparis in fileInput)
            {
                string[] details = rSiparis.Split(Environments.CodingSeperator);
                if(details.Length != 5)
                {
                    continue;
                } 
                Siparis Siparis = new(Int32.Parse(details[0]), Int32.Parse(details[1]), Int32.Parse(details[2]), Int32.Parse(details[3]), DateTime.FromBinary(Int64.Parse(details[4])));
                siparisler.Add(Siparis);
            }
        }

        public void SaveToFile()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + Environments.SiparislerDosyaYolu))
            {
                FileStream file = File.Create(Directory.GetCurrentDirectory() + Environments.SiparislerDosyaYolu);
                file.Close();
            }
            using (StreamWriter writer = new StreamWriter((Directory.GetCurrentDirectory() + Environments.SiparislerDosyaYolu)))
            {
                foreach (Siparis siparis in siparisler)
                {
                    writer.WriteLine(siparis.ToString());
                }
            }
        }

        public int GetAutoID()
        {
            return siparisler.Count;
        }

        public List<Siparis> GetElements()
        {
            return siparisler;
        }
    }
}
