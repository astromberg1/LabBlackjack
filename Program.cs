using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {

            
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
