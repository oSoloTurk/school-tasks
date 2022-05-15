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
    class Musteriler : IManager<Musteri>
    {
        private List<Musteri> musteriler { get; }
        private static Musteriler _instance;
        private Musteriler()
        {
            musteriler = new List<Musteri>();
            InitFromFile();
        }

        public static Musteriler GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Musteriler();
            }
            return _instance;
        }

        private void InitFromFile()
        {
            string[]? fileInput;
            try
            {
                fileInput = File.ReadAllLines(Directory.GetCurrentDirectory() + Environments.MusterilerDosyaYolu);
            }
            catch
            {
                return;
            }
            foreach (string rMusteri in fileInput)
            {
                string[] details = rMusteri.Split(Environments.CodingSeperator);
                if(details.Length != 5)
                {
                    continue;
                } 
                Musteri musteri = new(Int32.Parse(details[0]), details[1], details[2], details[3], DateTime.FromBinary(Int64.Parse(details[4])));
                musteriler.Add(musteri);
            }
        }
        public void SaveToFile()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + Environments.MusterilerDosyaYolu))
            {
                FileStream file = File.Create(Directory.GetCurrentDirectory() + Environments.MusterilerDosyaYolu);
                file.Close();
            }
            using (StreamWriter writer = new StreamWriter((Directory.GetCurrentDirectory() + Environments.MusterilerDosyaYolu)))
            {
                foreach (Musteri musteri in musteriler)
                {
                    writer.WriteLine(musteri.ToString());
                }
            }
        }

        public int GetAutoID()
        {
            return musteriler.Count;
        }

        public List<Musteri> GetElements()
        {
            return musteriler;
        }
    }
}
