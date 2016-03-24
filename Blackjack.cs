#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace BlackJack
{
    partial class frmBlackJack : Form
    {
        public frmBlackJack()
        {
            InitializeComponent();
        }

        Image cardBack;
        Image[] cardImage = new Image[52];
        int[] cardPoints = new int[52];
        int[] card = new int[52];
        int currentCard;
        int winnings;
        int numberCardsDealer, acesDealer, scoreDealer;
        int numberCardsPlayer, acesPlayer, scorePlayer;
        Image dealerFaceDown;


        private void frmBlackjack_Load(object sender, EventArgs e)
        {
            var dc = new Deck();
            dc.Shuffle();
            Card cd = dc.DrawACard();
            picPlayer1.Image = cd.CardFace;
            picPlayer1.Visible = true;
            /*   string cn;
               // load card images and determine points for each
               cardBack = Image.FromFile(Application.StartupPath + "\\cardback.wmf");
               for (int cardNumber = 0; cardNumber < 52; cardNumber++)
               {
                   cn = cardNumber.ToString();
                   if (cardNumber < 10)
                       cn = "0" + cn;
                   cardImage[cardNumber] = Image.FromFile(Application.StartupPath + "\\card" + cn + ".wmf");
                   int i = cardNumber % 13 + 1; // get a number from 1 (A) to 13 (K)
                   if (i == 11 || i == 12 || i == 13) // Jack, Queen, King
                       cardPoints[cardNumber] = 10;
                   else // A through 10
                       cardPoints[cardNumber] = i;
               }
               */
            //mnuFileNew.PerformClick();
        }

        private int[] SortIntegers(int n)
        {
            /*
            *  Returns n randomly sorted integers 0 -> n - 1
            */
            int[] sortedArray = new int[n];
            int temp, s;
            Random sortRandom = new Random();
            //  initialize array from 0 to n - 1
            for (int i = 0; i < n; i++)
            {
                sortedArray[i] = i;
            }
            //  i is number of items remaining in list
            for (int i = n; i >= 1; i--)
            {
                s = sortRandom.Next(i);
                temp = sortedArray[s];
                sortedArray[s] = sortedArray[i - 1];
                sortedArray[i - 1] = temp;
            }
            return (sortedArray);
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            // start new game - clear winnings and start over
            winnings = 0;
            lblWinnings.Text = "0";
            card = SortIntegers(52);
            currentCard = 0;
            NewHand();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewHand()
        {
            // Deal a new hand
            // Clear table of cards
           // picDealer1.Image = null;
            picDealer2.Image = null;
            picDealer3.Image = null;
            picDealer4.Image = null;
            picDealer5.Image = null;
            picDealer6.Image = null;
            picPlayer1.Image = null;
            picPlayer2.Image = null;
            picPlayer3.Image = null;
            picPlayer4.Image = null;
            picPlayer5.Image = null;
            picPlayer6.Image = null;
            lblDealerComment.Text = "";
            lblPlayerComment.Text = "";
            btnHit.Enabled = true;
            btnStay.Enabled = true;
            btnDeal.Enabled = false;
            // reshuffle occasionally
            if (currentCard > 34)
            {
                card = SortIntegers(52);
                currentCard = 0;
            }
            // Get two dealer cards
            scoreDealer = 0;
            acesDealer = 0;
            numberCardsDealer = 0;
          //  AddDealerCard();
          //  AddDealerCard();
            // Get two player cards
            scorePlayer = 0;
            acesPlayer = 0;
            numberCardsPlayer = 0;
            AddPlayerCard();
            AddPlayerCard();
            // Check for blackjacks
            if (scoreDealer == 11 && acesDealer == 1)
                scoreDealer = 21;
            if (scorePlayer == 11 && acesPlayer == 1)
                scorePlayer = 21;
            if (scoreDealer == 21 && scorePlayer == 21)
                EndHand("Dealer has Blackjack!", "And, you have Blackjack .. a push!", 0);
            else if (scoreDealer == 21)
                EndHand("Dealer has Blackjack!", "You lose ...", -10);
            else if (scorePlayer == 21)
                EndHand("Dealer loses ...", "You have Blackjack!", 15);
        }
        private void EndHand(string dealerComment, string playerComment, int change)
        {
            // make sure dealer cards are seen
            picDealer1.Image = dealerFaceDown;
            lblDealerComment.Text = dealerComment;
            lblPlayerComment.Text = playerComment;
            // Hand has ended - update winnings
            winnings += change;
            lblWinnings.Text = winnings.ToString();
            btnHit.Enabled = false;
            btnStay.Enabled = false;
            btnDeal.Enabled = true;
        }
        private void AddDealerCard()
        {
            int cardNumber;
            cardNumber = card[currentCard];
            // Adds a card to dealer hand
            numberCardsDealer++;
            switch (numberCardsDealer)
            {
                case 1:
                    dealerFaceDown = cardImage[cardNumber];
                    picDealer1.Image = cardBack;
                    break;
                case 2:
                    picDealer2.Image = cardImage[cardNumber];
                    break;
                case 3:
                    picDealer3.Image = cardImage[cardNumber];
                    break;
                case 4:
                    picDealer4.Image = cardImage[cardNumber];
                    break;
                case 5:
                    picDealer5.Image = cardImage[cardNumber];
                    break;
                case 6:
                    picDealer6.Image = cardImage[cardNumber];
                    break;
            }
            scoreDealer += cardPoints[cardNumber];
            if (cardPoints[cardNumber] == 1)
                acesDealer++;
            currentCard++;
        }

        private void label4_Click(object sender, EventArgs e)
            {

            }

        private void label15_Click(object sender, EventArgs e)
            {

            }

        private void label14_Click(object sender, EventArgs e)
            {

            }

        private void hinrToolStripMenuItem_Click(object sender, EventArgs e)
            {

            }

        private void AddPlayerCard()
        {
            int cardNumber;
            cardNumber = card[currentCard];
            // Adds a card to player hand
            numberCardsPlayer++;
            switch (numberCardsPlayer)
            {
                case 1:
                    picPlayer1.Image = cardImage[cardNumber];
                    break;
                case 2:
                    picPlayer2.Image = cardImage[cardNumber];
                    break;
                case 3:
                    picPlayer3.Image = cardImage[cardNumber];
                    break;
                case 4:
                    picPlayer4.Image = cardImage[cardNumber];
                    break;
                case 5:
                    picPlayer5.Image = cardImage[cardNumber];
                    break;
                case 6:
                    picPlayer6.Image = cardImage[cardNumber];
                    break;
            }
            scorePlayer += cardPoints[cardNumber];
            if (cardPoints[cardNumber] == 1)
                acesPlayer++;
            currentCard++;
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            NewHand();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            
            
            // Add a card if player requests
            AddPlayerCard();
            if (scorePlayer > 21)
                EndHand("Dealer wins", "You busted!", -10);
            else if (numberCardsPlayer == 6)
                EndHand("No dealer play", "You win - 6 cards and not over 21!", 10);
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            bool dealerDone = false;
            int scoreTemp, acesTemp;
            btnHit.Enabled = false;
            btnStay.Enabled = false;
            // Check for aces in player hand and adjust score
            // to highest possible
            if (acesPlayer != 0 && scorePlayer <= 11)
            {
                scorePlayer += 10;
                acesPlayer--;
            }
            // Uncover dealer face down card and play dealer hand
            picDealer1.Image = dealerFaceDown;
            do
            {
                scoreTemp = scoreDealer;
                acesTemp = acesDealer;
                // Check for aces and adjust score
                if (acesTemp != 0 && scoreDealer <= 11)
                {
                    scoreTemp += 10;
                    acesTemp--;
                }
                // add card unless score above 16 or dealer has 6 cards
                if (scoreTemp > 16)
                {
                    if (scoreTemp > scorePlayer)
                        EndHand("Dealer wins with " + scoreTemp.ToString(), "You lose with " + scorePlayer.ToString(), -10);
                    else if (scoreTemp == scorePlayer)
                        EndHand("Dealer has " + scoreTemp.ToString(), "So do you ... a push!", 0);
                    else
                        EndHand("Dealer loses with " + scoreTemp.ToString(), "You win with " + scorePlayer.ToString(), 10);
                    dealerDone = true;
                    continue;
                }
                else if (numberCardsDealer == 6)
                {
                    EndHand("Dealer wins ... 6 cards and not over 16!", "You lose ...", -10);
                    dealerDone = true;
                    continue;
                }
                else
                {
                    AddDealerCard();
                    // dealer loses if busted
                    if (scoreDealer > 21)
                    {
                        EndHand("Dealer busts!", "You win!!", 10);
                        dealerDone = true;
                        continue;
                    }
                }
            }
            while (!dealerDone);
        }
    }
}