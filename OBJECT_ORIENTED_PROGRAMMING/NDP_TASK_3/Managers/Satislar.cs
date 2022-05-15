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
    class Satislar : IManager<Satis>
    {
        private List<Satis> satislar { get; }
        private static Satislar _instance;
        private Satislar()
        {
            satislar = new List<Satis>();
            InitFromFile();
        }

        public static Satislar GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Satislar();
            }
            return _instance;
        }

        private void InitFromFile()
        {
            string[]? fileInput;
            try
            {
                fileInput = File.ReadAllLines(Directory.GetCurrentDirectory() + Environments.SatislarDosyaYolu);
            }
            catch
            {
                return;
            }
            foreach (string rSatis in fileInput)
            {
                string[] details = rSatis.Split(Environments.CodingSeperator);
                if(details.Length != 5)
                {
                    continue;
                } 
                Satis satis = new(Int32.Parse(details[0]), Int32.Parse(details[1]), Int32.Parse(details[2]), Int32.Parse(details[3]), DateTime.FromBinary(Int64.Parse(details[4])));
                satislar.Add(satis);
            }
        }

        public void SaveToFile()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + Environments.SatislarDosyaYolu))
            {
                FileStream file = File.Create(Directory.GetCurrentDirectory() + Environments.SatislarDosyaYolu);
                file.Close();
            }
            using (StreamWriter writer = new StreamWriter((Directory.GetCurrentDirectory() + Environments.SatislarDosyaYolu)))
            {
                foreach (Satis satis in satislar)
                {
                    writer.WriteLine(satis.ToString());
                }
            }
        }

        public int GetAutoID()
        {
            return satislar.Count;
        }

        public List<Satis> GetElements()
        {
            return satislar;
        }
    }
}
