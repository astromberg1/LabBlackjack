using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {

            var dc = new Deck();
             
            

            dc.Shuffle();
            Card cd = dc.DrawACard();
            //card2 = (Card) card.Clone();

            Console.WriteLine(cd.cardName);
            Console.ReadKey();
        }
    }
}
