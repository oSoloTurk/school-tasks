using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/****************************************************************************
** SAKARYA �N�VERS�TES�
** B�LG�SAYAR VE B�L���M B�L�MLER� FAK�LTES�
** B�LG�SAYAR M�HEND�SL��� B�L�M�
** NESNEYE DAYALI PROGRAMLAMA DERS�
** 2021-2022 BAHAR D�NEM�
**
** �DEV NUMARASI..........: 2
** ��RENC� ADI............: HAKKI CEYLAN
** ��RENC� NUMARASI.......: G211210350
** DERS�N ALINDI�I GRUP...: 2-A
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
