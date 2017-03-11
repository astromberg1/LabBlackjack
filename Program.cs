using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BlackJack
{
    class Program
    {

        public static void ShowConsoleWindow()
            {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
                {
                AllocConsole();
                }
            else
                {
                ShowWindow(handle, SW_SHOW);
                }
            }

        public static void HideConsoleWindow()
            {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);
            }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static void Main(string[] args)
        {
            HideConsoleWindow();

              Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BlackJack.frmBlackJack());

           //test
            
            //card2 = (Card) card.Clone();

           // Console.WriteLine(cd.cardName);
           // Console.ReadKey();
        }
    }
}
