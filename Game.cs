using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
    {
   
    class Game
       
        {
        public const int BETTING_SIZE = 10;
        public const int INIT_BALANCE = 100;
        public List<Player> Players { get; set; }
        
        public Game()
            {
            this.Players = new List<Player>();


            }

       
        public void AddPlayer(playertypes Type, string name)
        {
                 //if (Type == playertypes.Computerplayer)

            switch (Type)
                {
                case playertypes.Dealer:
                    break;
                case playertypes.Humanplayer:
                    break;
                case playertypes.Computerplayer:
                    break;
                default:
                    break;
                }


        

            }

        }
    }
