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
    class Tedarikciler : IManager<Tedarikci>
    {
        private List<Tedarikci> tedarikciler { get; }
        private static Tedarikciler _instance;
        private Tedarikciler()
        {
            tedarikciler = new List<Tedarikci>();
            InitFromFile();
        }

        public static Tedarikciler GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Tedarikciler();
            }
            return _instance;
        }

        private void InitFromFile()
        {
            string[]? fileInput;
            try
            {
                fileInput = File.ReadAllLines(Directory.GetCurrentDirectory() + Environments.TedarikcilerDosyaYolu);
            }
            catch
            {
                return;
            }
            foreach (string rTedarikci in fileInput)
            {
                string[] details = rTedarikci.Split(Environments.CodingSeperator);
                if(details.Length != 4)
                {
                    continue;
                }
                Tedarikci tedarikci = new(Int32.Parse(details[0]), details[1], details[2], DateTime.FromBinary(Int64.Parse(details[3])));
                tedarikciler.Add(tedarikci);
            }
        }
        public void SaveToFile()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + Environments.TedarikcilerDosyaYolu))
            {
                FileStream file = File.Create(Directory.GetCurrentDirectory() + Environments.TedarikcilerDosyaYolu);
                file.Close();
            }
            using (StreamWriter writer = new StreamWriter((Directory.GetCurrentDirectory() + Environments.TedarikcilerDosyaYolu)))
            {
                foreach (Tedarikci tedarikci in tedarikciler)
                {
                    writer.WriteLine(tedarikci.ToString());
                }
            }
        }


        public int GetAutoID()
        {
            return tedarikciler.Count;
        }

        public List<Tedarikci> GetElements()
        {
            return tedarikciler;
        }
    }
}
