using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
    {
  public  class GUI
        {
        public void updateformBets(Game gm, frmBlackJack frm)
            {
            frm.lblComBetsize.Text = gm.Players[(int)playertypes.Computerplayer].Betsize.ToString();
            frm.lblYouBetsize.Text = gm.Players[(int)playertypes.Humanplayer].Betsize.ToString();
            frm.lblStake.Text = gm.Players[(int)playertypes.Dealer].Betsize.ToString();
            
            }
        
        public void GetBetfromplayer(Game gm, frmBlackJack frm)
            {
            gm.Players[(int)playertypes.Humanplayer].Betsize = int.Parse(frm.lblYouBetsize.Text);
            }
        public void UpdateViews()
            {

            }
        public void EventDeal()
            {

            }
        public void EventHit()
            {

            }
        public void EventStay()
            {

            }

        public void EventBust()
            {

            }




        }
    }
