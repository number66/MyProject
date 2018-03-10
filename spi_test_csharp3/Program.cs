using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FTD2XX_NET;
using System.Threading;

namespace spi_test_csharp3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
