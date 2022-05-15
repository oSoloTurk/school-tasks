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
    class Stoklar : IManager<Urun>
    {
        public List<Urun> stoklar { get; }
        public static Stoklar _instance;
        private Stoklar()
        {
            stoklar = new List<Urun>();
            InitFromFile();
        }

        public static Stoklar GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Stoklar();
            }
            return _instance;
        }

        private void InitFromFile()
        {
            string[]? fileInput;
            try
            {
                fileInput = File.ReadAllLines(Directory.GetCurrentDirectory() + Environments.StoklarDosyaYolu);
            }
            catch
            {
                return;
            }
            foreach (string rUrun in fileInput)
            {
                string[] details = rUrun.Split(Environments.CodingSeperator);
                if(details.Length != 5)
                {
                    continue;
                } 
                Urun urun = new(Int32.Parse(details[0]), details[1], details[2], Int32.Parse(details[3]), float.Parse(details[4]));
                stoklar.Add(urun);
            }
        }

        public void SaveToFile()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + Environments.StoklarDosyaYolu))
            {
                FileStream file = File.Create(Directory.GetCurrentDirectory() + Environments.StoklarDosyaYolu);
                file.Close();
            }
            using (StreamWriter writer = new StreamWriter((Directory.GetCurrentDirectory() + Environments.StoklarDosyaYolu)))
            {
                foreach (Urun stok in stoklar)
                {
                    writer.WriteLine(stok.ToString());
                }
            }
        }


        public int GetAutoID()
        {
            return stoklar.Count;
        }

        public List<Urun> GetElements()
        {
            return stoklar;
        }
    }
}
