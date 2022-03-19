using System;
using System.Linq;
using System.Text.RegularExpressions;

/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2021-2022 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 1
**				ÖĞRENCİ ADI............: Hakkı Ceylan
**				ÖĞRENCİ NUMARASI.......: G211210350
**                         DERSİN ALINDIĞI GRUP...: 2. Öğretim - A Grubu
****************************************************************************/

namespace TaskOne
{
    static class SifreDogrulayici
    {
        public static Regex BUYUK_HARF_DOGRULAMA = new(@"[A-ZÇŞĞÜİÖ]");
        public static Regex KUCUK_HARF_DOGRULAMA = new(@"[a-zçşğüıö]");
        public static Regex RAKAM_DOGRULAMA = new(@"[0-9]");
        public static Regex SEMBOL_DOGRULAMA = new(@"[\+\-\*\/\!\'\^\%\&\/\/\(\)\=\\\.\#\$\{\[\]\}\|\,]");

        public static int BuyukHarfSayisi(string Sifre)
        {
            return BUYUK_HARF_DOGRULAMA.Matches(Sifre).Count;
        }

        public static int KucukHarfSayisi(string Sifre)
        {
            return KUCUK_HARF_DOGRULAMA.Matches(Sifre).Count;
        }
        public static int RakamSayisi(string Sifre)
        {
            return RAKAM_DOGRULAMA.Matches(Sifre).Count;
        }

        public static int SembolSayisi(string Sifre)
        {
            return SEMBOL_DOGRULAMA.Matches(Sifre).Count;
        }

        public static Tuple<string, int> SifreTestEt(string Sifre)
        {

            int Puan = 0;

            int KucukHarfSayisi = SifreDogrulayici.KucukHarfSayisi(Sifre);
            int BuyukHarfSayici = SifreDogrulayici.BuyukHarfSayisi(Sifre);
            int SembolSayisi = SifreDogrulayici.SembolSayisi(Sifre);
            int RakamSayisi = SifreDogrulayici.RakamSayisi(Sifre);
            if (Sifre.Count() > 9)
            {
                if (KucukHarfSayisi == 0)
                {
                    return new Tuple<string, int>("Sifreniz kucuk harf icermelidir", 0);
                }
                if (BuyukHarfSayici == 0)
                {
                    return new Tuple<string, int>("Sifreniz buyuk harf icermelidir", 0);
                }
                if (SembolSayisi == 0)
                {
                    return new Tuple<string, int>("Sifreniz sembol icermelidir\n Uygun Karakterler: +, -, *, /, !, ', ^, %, &, /, /, (, ), =,\\, ., #, $, {, [, ], }, |, ','", 0);
                }
                if (RakamSayisi == 0)
                {
                    return new Tuple<string, int>("Sifreniz rakam icermelidir", 0);
                }
            }
            Puan += KucukHarfSayisi > 2 ? 20 : KucukHarfSayisi * 10;
            Puan += BuyukHarfSayici > 2 ? 20 : BuyukHarfSayici * 10;
            Puan += RakamSayisi > 2 ? 20 : RakamSayisi * 10;
            Puan += SembolSayisi * 10;
            Puan += Sifre.Count() == 9 ? 10 : 0;
            if (Puan < 70)
            {
                return new Tuple<string, int>("Sifre yeterince guclu degil.", Puan);
            }
            if (Puan < 90)
            {
                return new Tuple<string, int>("Sifre yeterince guclu.", Puan);
            }
            return new Tuple<string, int>("Sifre cok guclu!", Puan);

        }

        public static Tuple<string, int> SifreDogrula(string Sifre)
        {

            int Puan = 0;
            if (Sifre.Count() < 9)
            {
                return new Tuple<string, int>("Sifre 9 karakterden daha uzun olmalidir.", 0);
            }

            int KucukHarfSayisi = SifreDogrulayici.KucukHarfSayisi(Sifre);
            int BuyukHarfSayici = SifreDogrulayici.BuyukHarfSayisi(Sifre);
            int SembolSayisi = SifreDogrulayici.SembolSayisi(Sifre);
            int RakamSayisi = SifreDogrulayici.RakamSayisi(Sifre);
            if (Sifre.Count() > 9)
            {
                if (KucukHarfSayisi == 0)
                {
                    return new Tuple<string, int>("Sifreniz kucuk harf icermelidir", 0);
                }
                if (BuyukHarfSayici == 0)
                {
                    return new Tuple<string, int>("Sifreniz buyuk harf icermelidir", 0);
                }
                if (SembolSayisi == 0)
                {
                    return new Tuple<string, int>("Sifreniz sembol icermelidir", 0);
                }
                if (RakamSayisi == 0)
                {
                    return new Tuple<string, int>("Sifreniz rakam icermelidir", 0);
                }
            }
            Puan += KucukHarfSayisi > 2 ? 20 : KucukHarfSayisi * 10;
            Puan += BuyukHarfSayici > 2 ? 20 : BuyukHarfSayici * 10;
            Puan += RakamSayisi > 2 ? 20 : RakamSayisi * 10;
            Puan += SembolSayisi * 10;
            Puan += Sifre.Count() == 9 ? 10 : 0;
            Console.WriteLine("KucukHarfSayisi: " + KucukHarfSayisi);
            Console.WriteLine("BuyukHarfSayisi: " + BuyukHarfSayici);
            Console.WriteLine("RakamHarfSayisi: " + RakamSayisi);
            Console.WriteLine("SembolHarfSayisi: " + SembolSayisi);
            if (Puan < 70)
            {
                return new Tuple<string, int>("Sifre yeterince guclu degil.", Puan);
            }
            if (Puan < 90)
            {
                return new Tuple<string, int>("Sifre yeterince guclu.", Puan);
            }
            return new Tuple<string, int>("Sifre cok guclu!", Puan);

        }
    }
}
