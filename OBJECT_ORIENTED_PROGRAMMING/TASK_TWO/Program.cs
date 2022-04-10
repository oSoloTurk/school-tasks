using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/****************************************************************************
** SAKARYA ÜNÝVERSÝTESÝ
** BÝLGÝSAYAR VE BÝLÝÞÝM BÝLÝMLERÝ FAKÜLTESÝ
** BÝLGÝSAYAR MÜHENDÝSLÝÐÝ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSÝ
** 2021-2022 BAHAR DÖNEMÝ
**
** ÖDEV NUMARASI..........: 2
** ÖÐRENCÝ ADI............: HAKKI CEYLAN
** ÖÐRENCÝ NUMARASI.......: G211210350
** DERSÝN ALINDIÐI GRUP...: 2-A
****************************************************************************/
namespace ndp_task_two
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
