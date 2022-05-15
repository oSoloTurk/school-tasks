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
    class Giderler : IManager<Gider>
    {
        private List<Gider> giderler { get; }
        private static Giderler _instance;
        private Giderler()
        {
            giderler = new List<Gider>();
            InitFromFile();
        }

        public static Giderler GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Giderler();
            }
            return _instance;
        }

        private void InitFromFile()
        {
            string[]? fileInput;
            try
            {
                fileInput = File.ReadAllLines(Directory.GetCurrentDirectory() + Environments.GiderlerDosyaYolu);
            }
            catch
            {
                return;
            }
            foreach (string rGider in fileInput)
            {
                string[] details = rGider.Split(Environments.CodingSeperator);
                if(details.Length != 5)
                {
                    continue;
                } 
                Gider Gider = new(Int32.Parse(details[0]), details[1], Int32.Parse(details[2]), DateTime.FromBinary(Int64.Parse(details[4])));
                giderler.Add(Gider);
            }
        }

        public void SaveToFile()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + Environments.GiderlerDosyaYolu))
            {
                FileStream file = File.Create(Directory.GetCurrentDirectory() + Environments.GiderlerDosyaYolu);
                file.Close();
            }
            using (StreamWriter writer = new StreamWriter((Directory.GetCurrentDirectory() + Environments.GiderlerDosyaYolu)))
            {
                foreach (Gider gider in giderler)
                {
                    writer.WriteLine(gider.ToString());
                }
            }
        }

        public int GetAutoID()
        {
            return giderler.Count;
        }

        public List<Gider> GetElements()
        {
            return giderler;
        }
    }
}
