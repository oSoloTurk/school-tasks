using NDP_TASK_3.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3
{
    internal class FakeDateCreator
    {
        const int FAKE_DATA_COUNT = 250;
        public static void CreateFakeFiles()
        {
            Giderler giderler = Giderler.GetInstance();
            Musteriler musteriler = Musteriler.GetInstance();
            Satislar satislar = Satislar.GetInstance(); 
            Siparisler siparisler = Siparisler.GetInstance();  
            Stoklar stoklar = Stoklar.GetInstance();
            Tedarikciler tedarikciler = Tedarikciler.GetInstance();
            for(int i = 0; i < FAKE_DATA_COUNT; i++)
            {
                Gider gider = new Gider(Faker.Name.FullName(), Faker.RandomNumber.Next(0, 100));
                giderler.GetElements().Add(gider);
            }
            giderler.SaveToFile();

            for (int i = 0; i < FAKE_DATA_COUNT; i++)
            {
                Musteri musteri = new Musteri(Faker.Name.FullName(), Faker.Enum.Random<Gender>().ToString(), Faker.Phone.Number());
                musteriler.GetElements().Add(musteri);
            }
            musteriler.SaveToFile();

            for (int i = 0; i < FAKE_DATA_COUNT; i++)
            {
                Satis satis = new Satis(Faker.RandomNumber.Next(0, FAKE_DATA_COUNT), Faker.RandomNumber.Next(0, FAKE_DATA_COUNT), Faker.RandomNumber.Next(0, 5), Faker.Finance.Maturity(0, 1));
                satislar.GetElements().Add(satis);
            }
            satislar.SaveToFile();

            for (int i = 0; i < FAKE_DATA_COUNT; i++)
            {
                Siparis siparis = new Siparis(Faker.RandomNumber.Next(0, FAKE_DATA_COUNT), Faker.RandomNumber.Next(0, FAKE_DATA_COUNT), Faker.RandomNumber.Next(0, 5), Faker.Finance.Maturity(0, 1));
                siparisler.GetElements().Add(siparis);
            }
            siparisler.SaveToFile();

            for (int i = 0; i < FAKE_DATA_COUNT; i++)
            {
                Urun stok = new Urun(Faker.Name.First(), Faker.RandomNumber.Next(0, FAKE_DATA_COUNT) % 2 == 0 ? "Rafta" :  "Depoda", Faker.RandomNumber.Next(0, 5), (float)(Faker.RandomNumber.Next(100, 1000) * 0.78));
                stoklar.GetElements().Add(stok);
            }
            stoklar.SaveToFile();

            for (int i = 0; i < FAKE_DATA_COUNT; i++)
            {
                Tedarikci tedarikci = new Tedarikci(Faker.Name.First(), Faker.Phone.Number());
                tedarikciler.GetElements().Add(tedarikci);
            }
            tedarikciler.SaveToFile();
        }
    }
}
