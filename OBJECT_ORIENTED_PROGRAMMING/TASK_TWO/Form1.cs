using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2021-2022 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........: 2
** ÖĞRENCİ ADI............: HAKKI CEYLAN
** ÖĞRENCİ NUMARASI.......: G211210350
** DERSİN ALINDIĞI GRUP...: 2-A
****************************************************************************/

namespace ndp_task_two
{
       public partial class Form1 : Form
    {
        private Dictionary<string, Number> NUMBERS;
        private Dictionary<int, string> STEPS;
        public Form1()
        {
            InitializeComponent();
            NUMBERS = new Dictionary<string, Number>();
            STEPS = new Dictionary<int, string>();
            NUMBERS.Add("0", new Number("", ""));
            NUMBERS.Add("1", new Number("ON", "BIR"));
            NUMBERS.Add("2", new Number("YIRMI", "IKI"));
            NUMBERS.Add("3", new Number("OTUZ", "UC"));
            NUMBERS.Add("4", new Number("KIRK", "DORT"));
            NUMBERS.Add("5", new Number("ELLI", "BES"));
            NUMBERS.Add("6", new Number("ALTMIS", "ALTI"));
            NUMBERS.Add("7", new Number("YETMIS", "YEDI"));
            NUMBERS.Add("8", new Number("SEKSEN", "SEKIZ"));
            NUMBERS.Add("9", new Number("DOKSAN", "DOKUZ"));
            STEPS.Add(1, "");
            STEPS.Add(2, "");
            STEPS.Add(3, "YUZ");
            STEPS.Add(4, "BIN");
            STEPS.Add(5, "BIN");
        }

        public string cevir(string sayi)
        {
            string metin = "";
            for (int index = sayi.Length - 1, counter = 0; index >= 0; index--, counter++)
            {
                int releativePosition = counter % 3;
                NumberStyle style = releativePosition % 2 == 1 ? NumberStyle.MASKED : NumberStyle.NATIVE;
                string letterResponse;
                letterResponse = NUMBERS[sayi[index].ToString()].getNumber(style);
                if (sayi[index] == '1' && counter != 0 && style == NumberStyle.NATIVE) letterResponse = "";
                if (counter == 2 || counter == 3) letterResponse = letterResponse + " " + STEPS[sayi.Length - index] + " ";
                metin = letterResponse + " " + metin;
            }
            return metin;
        }

        private string hesapla(string sayi)
        {
            if (sayi.Length > 5) return "Sayi cok buyuk!";
            if (sayi.Contains("-")) return "Sayi negatif olamaz!";
            string tamKisim = "";
            string ondalikKisim = "";
            if (sayi.Contains("."))
            {
                tamKisim = sayi.Substring(0, sayi.IndexOf("."));
                ondalikKisim = sayi.Substring(sayi.IndexOf(".") + 1);
                if (ondalikKisim.Length == 1) ondalikKisim += "0";
            } else
            {
                tamKisim = sayi;
            }
            string yanit = "";
            yanit += cevir(tamKisim);
            yanit += " TL ";
            if (!ondalikKisim.Equals(""))
            {
                yanit += cevir(ondalikKisim);
                yanit += " Kuruş";
            }
            return yanit;
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            txtBoxOutput.Text = hesapla(txtBoxInput.Text);
        }
    }
    public enum NumberStyle
    {
        NATIVE, MASKED
    }
    public class Number
    {
        Dictionary<NumberStyle, string> views;

        public Number(string masked, string native)
        {
            views = new Dictionary<NumberStyle, string>();
            views.Add(NumberStyle.NATIVE, native);
            views.Add(NumberStyle.MASKED, masked);
        }

        public string getNumber(NumberStyle style)
        {
            return views.GetValueOrDefault(style, "");
        }
    }
}
