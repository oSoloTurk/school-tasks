using System;

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
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Sifrenizi Giriniz: ");
            string Sifre = "";
            ConsoleKeyInfo OkunanKarakter;
            do
            {
                OkunanKarakter = Console.ReadKey();
                switch ((char)OkunanKarakter.KeyChar)
                {
                    case '\b':
                        Sifre = Sifre.Substring(0, Sifre.Length - 1);
                        Console.Write(" \b");
                        break;
                    default:
                        Sifre += OkunanKarakter.KeyChar;
                        break;
                }
                GirdiyiDegerlendir(Sifre);
            } while (OkunanKarakter.KeyChar != '\r');
            Console.Write("\n\n\n\n\n");
            SifreDogrulayici.SifreDogrula(Sifre);
        }

        private static void GirdiyiDegerlendir(string sifre)
        {
            (int, int) ConsoleIsaretci = Console.GetCursorPosition();
            Console.WriteLine("\n");
            Tuple<string, int> DegerlendirmeSonucu = SifreDogrulayici.SifreTestEt(sifre);
            Console.Write("[");
            int Ilerleme = (DegerlendirmeSonucu.Item2 <= 100 ? DegerlendirmeSonucu.Item2 : 100) / 5;
            for (int i = 0; i < Ilerleme; i++) Console.Write("*");
            for (int i = 0; i < 20 - Ilerleme; i++) Console.Write(" ");
            Console.Write("] %"+ (Ilerleme * 5) + "\n");
            Console.Write(DegerlendirmeSonucu.Item1);
            for (int i = 0; i < 50 - DegerlendirmeSonucu.Item1.Length; i++) Console.Write(" ");
            Console.SetCursorPosition(ConsoleIsaretci.Item1, ConsoleIsaretci.Item2);
        }

    }
}
