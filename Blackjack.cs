#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace BlackJack
    {
    public partial class frmBlackJack : Form
        {
        public frmBlackJack()
            {
            InitializeComponent();
            }

        
        int rounds;
        Game gm = new Game();
        
        Deck dc = new Deck();



        private void frmBlackjack_Load(object sender, EventArgs e)
            {
            mnuFileNew.PerformClick();
            }

        public void ShowFirstRound()
            {
            picDealer1.Image = gm.Players[0].Cardhand.Cards[0].CardBack;
            picDealer1.Visible = true;

            Refresh();
            Thread.Sleep(200);
            picPlayer1.Image = gm.Players[1].Cardhand.Cards[0].CardFace;
            Refresh();
            Thread.Sleep(200);

            picComputer1.Image = gm.Players[2].Cardhand.Cards[0].CardFace;
            Refresh();
            Thread.Sleep(300);
            picDealer2.Image = gm.Players[0].Cardhand.Cards[1].CardFace;
            Refresh();
            Thread.Sleep(300);

            picPlayer2.Image = gm.Players[1].Cardhand.Cards[1].CardFace;
            Refresh();
            Thread.Sleep(200);
            picComputer2.Image = gm.Players[2].Cardhand.Cards[1].CardFace;
            Refresh();



            }

        private void mnuFileNew_Click(object sender, EventArgs e)
            {
            // start new game - clear winnings and start over
            System.IO.Stream audio = BlackJack.Properties.Resources.TADA;
            System.Media.SoundPlayer finishSoundPlayer = new System.Media.SoundPlayer(audio);

           
            finishSoundPlayer.Play();

            lblWinnings.Text = "0";
            lblComputerWinnings.Text = "0";
            //dc.Shuffle();

            
            rounds = 0;
            lblRounds.Text = rounds.ToString();
            // 'init game'
            gm.Init();
            //NewRound();
            btnChbet.Visible = false;
            btnDeal.Visible = false;
            btnHit.Visible = false;
            btnDeal.Visible = false;
            btnNewRound.Visible = true;
            btnStay.Visible = false;
            btnNewRound.Enabled = true;

            Refresh();



            //NewHand();
            }

        private void mnuFileExit_Click(object sender, EventArgs e)
            {
                      this.Close();
            }

        public void NewHand()
            {
            dc.ReSetCards();
            dc.Shuffle();

            // Deal a new hand
            // Clear table of cards




            lblDealerComment.Text = "";
            lblPlayerComment.Text = "";
            lblComputerComment.Text = "";

            btnHit.Enabled = true;
            btnStay.Enabled = true;
            btnDeal.Enabled = false;
            btnChbet.Enabled = false;
            btnNewRound.Enabled = false;

            btnHit.Visible = true;
            btnStay.Visible = true;
            btnDeal.Visible = false;
            btnChbet.Visible = false;
            btnNewRound.Visible = false;
            // Get two dealer cards
           
            gm.DealFirstRound(dc);
            ShowFirstRound();
            gm.CheckPlayersCardhands2Card();
            //  
            lblDlCardPoints.Text = "?";
            lblYouCardPoints.Text = gm.Players[1].Cardhand.BestHandvalue.ToString();
            lblComCardPoints.Text = gm.Players[2].Cardhand.BestHandvalue.ToString();

            if (gm.Players[1].Cardhand.Equal21)
                lblPlayerComment.Text = "You have Blackjack";
            else
                lblPlayerComment.Text = "You have " + lblYouCardPoints.Text;

            if (gm.Players[2].Cardhand.Equal21)
                lblComputerComment.Text = "Computer have Blackjack";
            else
                lblComputerComment.Text = "Computer have " + lblComCardPoints.Text;

            this.Refresh();
            Application.DoEvents();

            }


        public void addCardPlayer()
            {

            gm.Players[1].Cardhand.AddCard(dc.DrawACard());


            if (gm.Players[1].Cardhand.CountCards() == 3)

                picPlayer3.Image = gm.Players[1].Cardhand.Cards[2].CardFace;
            else if (gm.Players[1].Cardhand.CountCards() == 4)
                picPlayer4.Image = gm.Players[1].Cardhand.Cards[3].CardFace;
            else if (gm.Players[1].Cardhand.CountCards() == 5)
                picPlayer5.Image = gm.Players[1].Cardhand.Cards[4].CardFace;
            else if (gm.Players[1].Cardhand.CountCards() == 6)
                picPlayer6.Image = gm.Players[1].Cardhand.Cards[5].CardFace;
            else if (gm.Players[1].Cardhand.CountCards() == 7)
                picPlayer7.Image = gm.Players[1].Cardhand.Cards[7].CardFace;


            this.Refresh();
            Application.DoEvents();
            gm.Players[1].Cardhand.Getbesthandvalue();
            lblYouCardPoints.Text = gm.Players[1].Cardhand.BestHandvalue.ToString();
            Application.DoEvents();




            if (gm.Players[1].Cardhand.Above21)
                {
                gm.Players[1].Busted = true;
                lblPlayerComment.Text = " You are Busted!";
                
                btnHit.Visible = false;
                Stay_click();

                }
            else if (gm.Players[1].Cardhand.Equal21)
                {
                gm.Players[1].H21 = true;
                lblPlayerComment.Text = " You have BlackJack!";
                btnHit.Visible = false;
                Stay_click();

                }
            else
                lblPlayerComment.Text = " You have " + lblYouCardPoints.Text;

            Refresh();
            Thread.Sleep(700);


            }


        


        public void Computerplays()
            {
            System.IO.Stream audio = BlackJack.Properties.Resources.cardPlace1;
            System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(audio);
            

            do
                {
                Thread.Sleep(1000);
                if ((gm.Players[2].Cardhand.Atleast17))
                    {
                    gm.Players[2].Stands = true;
                    }
                else
                    {
                    gm.Players[2].Cardhand.AddCard(dc.DrawACard());
                    startSoundPlayer.Play();



                    if (gm.Players[2].Cardhand.CountCards() == 3)

                        picComputer3.Image = gm.Players[2].Cardhand.Cards[2].CardFace;
                    else if (gm.Players[2].Cardhand.CountCards() == 4)
                        picComputer4.Image = gm.Players[2].Cardhand.Cards[3].CardFace;
                    else if (gm.Players[2].Cardhand.CountCards() == 5)
                        picComputer5.Image = gm.Players[2].Cardhand.Cards[4].CardFace;
                    else if (gm.Players[2].Cardhand.CountCards() == 6)
                        picComputer6.Image = gm.Players[2].Cardhand.Cards[5].CardFace;
                    else if (gm.Players[2].Cardhand.CountCards() == 7)
                        picComputer7.Image = gm.Players[2].Cardhand.Cards[7].CardFace;

                    // picComputer3.Image = gm.Players[2].Cardhand.Cards[3].CardFace;
                    // picComputer3.Visible = true;
                    this.Refresh();
                    gm.Players[2].Cardhand.Getbesthandvalue();
                    lblComCardPoints.Text = gm.Players[2].Cardhand.BestHandvalue.ToString();

                    this.Refresh();
                    Application.DoEvents();
                    if (gm.Players[2].Cardhand.CountCards() == 3)

                        picComputer3.Image = gm.Players[2].Cardhand.Cards[2].CardFace;
                    else if (gm.Players[2].Cardhand.CountCards() == 4)
                        picComputer4.Image = gm.Players[2].Cardhand.Cards[3].CardFace;
                    else if (gm.Players[2].Cardhand.CountCards() == 5)
                        picComputer5.Image = gm.Players[2].Cardhand.Cards[4].CardFace;
                    else if (gm.Players[2].Cardhand.CountCards() == 6)
                        picComputer6.Image = gm.Players[2].Cardhand.Cards[5].CardFace;
                    else if (gm.Players[2].Cardhand.CountCards() == 7)
                        picComputer7.Image = gm.Players[2].Cardhand.Cards[7].CardFace;
                    this.Refresh();
                    Application.DoEvents();


                    }

                if (gm.Players[2].Cardhand.Above21)
                    {
                    gm.Players[2].Busted = true;
                    lblComputerComment.Text = " Computer is Busted!";
                    }
                else if (gm.Players[2].Cardhand.Equal21)
                    {
                    gm.Players[2].H21 = true;
                    lblComputerComment.Text = " Computer has Black Jack!";
                    }

                }
            while (!gm.Players[2].Cardhand.Atleast17 && !gm.Players[2].Cardhand.Above21);

            if (!gm.Players[2].Cardhand.Above21 && !gm.Players[2].Cardhand.Equal21)
                lblComputerComment.Text = " Computer stands on " + lblComCardPoints.Text;



            }


        public void Dealerplays()
            {
            Thread.Sleep(500);
            System.IO.Stream audio = BlackJack.Properties.Resources.cardPlace1;
            System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(audio);
            
            picDealer1.Image = gm.Players[0].Cardhand.Cards[0].CardFace;
            startSoundPlayer.Play();
            this.Refresh();
            gm.Players[0].Cardhand.Getbesthandvalue();
            lblDlCardPoints.Text = gm.Players[0].Cardhand.BestHandvalue.ToString();

            if (gm.Players[0].Cardhand.Above21)
                {
                gm.Players[0].Busted = true;
                lblDealerComment.Text = " Dealer is Busted! You Win";
                }
            else if (gm.Players[0].Cardhand.Equal21)
                {
                gm.Players[0].H21 = true;
                lblDealerComment.Text = "Dealer has Black Jack!";
                }
            else if (gm.Players[0].Cardhand.Atleast17)
                {

                lblDealerComment.Text = "Dealer stands on " + lblDlCardPoints.Text;
                gm.Players[0].Stands = true;
                }
            else
                {




                do
                    {
                    Thread.Sleep(800);
                    if ((gm.Players[0].Cardhand.Atleast17))
                        {
                        gm.Players[0].Stands = true;
                        }
                    else
                        {
                        gm.Players[0].Cardhand.AddCard(dc.DrawACard());
                        startSoundPlayer.Play();

                        this.Refresh();
                        Application.DoEvents();


                        if (gm.Players[0].Cardhand.CountCards() == 3)

                            picDealer3.Image = gm.Players[0].Cardhand.Cards[2].CardFace;

                        else if (gm.Players[0].Cardhand.CountCards() == 4)
                            {
                        
                            picDealer4.Image = gm.Players[0].Cardhand.Cards[3].CardFace;
                            }
                        else if (gm.Players[0].Cardhand.CountCards() == 5)
                            {
                            
                            picDealer5.Image = gm.Players[0].Cardhand.Cards[4].CardFace;
                            }
                        else if (gm.Players[0].Cardhand.CountCards() == 6)
                            {
                            picDealer6.Image = gm.Players[0].Cardhand.Cards[5].CardFace;
                            }
                        else if (gm.Players[0].Cardhand.CountCards() == 7)
                                picDealer7.Image = gm.Players[0].Cardhand.Cards[7].CardFace;

                            // picComputer3.Image = gm.Players[2].Cardhand.Cards[3].CardFace;
                            // picComputer3.Visible = true;
                        
                        gm.Players[0].Cardhand.Getbesthandvalue();
                        lblDlCardPoints.Text = gm.Players[0].Cardhand.BestHandvalue.ToString();

                        this.Refresh();
                        Application.DoEvents();

}

                    
                    if (gm.Players[0].Cardhand.Above21)
                        {
                        gm.Players[0].Busted = true;
                        lblDealerComment.Text = " Dealer is Busted!";
                        }
                    else if (gm.Players[0].Cardhand.Equal21)
                        {
                        gm.Players[0].H21 = true;
                        lblDealerComment.Text = " Dealer has Black Jack!";
                        }

                    }
                while (!gm.Players[0].Cardhand.Atleast17 && !gm.Players[0].Cardhand.Above21);

                if (!gm.Players[0].Cardhand.Above21 && !gm.Players[0].Cardhand.Equal21)
                    {
                    lblDealerComment.Text = " Dealer stands on " + lblDlCardPoints.Text;
                    gm.Players[0].Stands = true;
                    }
                }
            
            this.Refresh();
            Application.DoEvents();
            Thread.Sleep(400);
            // Calculate Winner
            Blink(10);
            Thread.Sleep(400);
            calculateWinner();
            Thread.Sleep(1000);
            // New Round
            // update winnings

            lblDlBalance.Text = gm.Players[0].Balance.ToString();
            lblYouBalance.Text = gm.Players[1].Balance.ToString();
            LblCompBalance.Text = gm.Players[2].Balance.ToString();
            lblComputerWinnings.Text = (gm.Players[2].Balance - 100).ToString();
            lblWinnings.Text = (gm.Players[1].Balance - 100).ToString();
          

            //NewRound();
            btnChbet.Visible = false;
            btnDeal.Visible = false;
            btnHit.Visible = false;
            btnDeal.Visible = false;
            btnNewRound.Visible = true;
            btnStay.Visible = false;
            btnNewRound.Enabled = true;

            Refresh();

            }


        public void calculateWinner()
            {
            System.IO.Stream audio = BlackJack.Properties.Resources.applause;
          
            System.Media.SoundPlayer startSoundPlayerwin = new System.Media.SoundPlayer(audio);
            audio = BlackJack.Properties.Resources.boo;
            System.Media.SoundPlayer startSoundPlayerlos = new System.Media.SoundPlayer(audio);
            
            



            if (gm.Players[0].Cardhand.Above21)
                {
                if (!gm.Players[1].Cardhand.Above21)
                    {
                    lblPlayerComment.Text = " Dealer Busted You Won!";
                    gm.Players[1].Won = true;
                    gm.Players[1].Indecisive = false;
                    gm.Players[1].Lost = false;
                    gm.Players[1].Balance = gm.Players[1].Balance + gm.Players[1].Betsize;
                    gm.Players[0].Balance = gm.Players[0].Balance - gm.Players[1].Betsize;
                    startSoundPlayerwin.Play();
                    }
                else
                    {
                    gm.Players[1].Won = false;
                    gm.Players[1].Indecisive = true;
                    gm.Players[1].Lost = false;
                    lblPlayerComment.Text = "Dealer are busted And  you too are busted .. a push!";
                    }
                if (!gm.Players[2].Cardhand.Above21)
                    {
                    lblComputerComment.Text = " Dealer Busted Computer Won!";
                    gm.Players[2].Won = true;
                    gm.Players[2].Indecisive = false;
                    gm.Players[2].Lost = false;
                    gm.Players[2].Balance = gm.Players[2].Balance + gm.Players[2].Betsize;
                    gm.Players[0].Balance = gm.Players[0].Balance - gm.Players[2].Betsize;
                    }
                else
                    {
                    gm.Players[2].Won = false;
                    gm.Players[2].Indecisive = true;
                    gm.Players[2].Lost = false;
                    lblComputerComment.Text = "Dealer are busted And Computer too are busted .. a push!";
                    }
                }
            else
                {

                if (!gm.Players[1].Cardhand.Above21)
                    {
                    if (gm.Players[0].Cardhand.BestHandvalue == gm.Players[1].Cardhand.BestHandvalue)
                        {
                        if (gm.Players[1].Cardhand.HasFive())
                            {
                            if (gm.Players[1].Cardhand.Equal21)
                                lblPlayerComment.Text = "Dealer has Black Jack and You have 5 card .. a push!";
                            else
                                lblPlayerComment.Text = "Dealer and You have the same and You have 5 card .. a push!";
                            }
                        else
                            {
                            startSoundPlayerlos.Play();
                            if (gm.Players[1].Cardhand.Equal21)
                                lblPlayerComment.Text = "Dealer has Black Jack and You, You Loose!";
                            else
                                lblPlayerComment.Text = "Dealer and You have the same, You Loose!";
                            gm.Players[1].Balance = gm.Players[1].Balance - gm.Players[1].Betsize;
                            gm.Players[0].Balance = gm.Players[0].Balance + gm.Players[1].Betsize;
                            }
                        }
                    else if (gm.Players[0].Cardhand.BestHandvalue > gm.Players[1].Cardhand.BestHandvalue)
                        {
                        startSoundPlayerlos.Play();
                        lblPlayerComment.Text = "Dealer has a better hand than You, You Loose!";
                        gm.Players[1].Balance = gm.Players[1].Balance - gm.Players[1].Betsize;
                        gm.Players[0].Balance = gm.Players[0].Balance + gm.Players[1].Betsize;
                        }
                    else if (gm.Players[0].Cardhand.BestHandvalue < gm.Players[1].Cardhand.BestHandvalue)
                        {
                        lblPlayerComment.Text = "You win ! Your hand is better than the Dealer";
                        startSoundPlayerwin.Play();
                        gm.Players[1].Balance = gm.Players[1].Balance + gm.Players[1].Betsize;
                        gm.Players[0].Balance = gm.Players[0].Balance - gm.Players[1].Betsize;
                        }
                    }
                else
                    {
                    startSoundPlayerlos.Play();
                    lblPlayerComment.Text = "You are busted but Dealer not, You Loose!";
                    gm.Players[1].Balance = gm.Players[1].Balance - gm.Players[1].Betsize;
                    gm.Players[0].Balance = gm.Players[0].Balance + gm.Players[1].Betsize;
                    }
                 

            if (!gm.Players[2].Cardhand.Above21)
                { 
                if (gm.Players[0].Cardhand.BestHandvalue == gm.Players[2].Cardhand.BestHandvalue)
                {
                if (gm.Players[2].Cardhand.HasFive())
                    {
                    if (gm.Players[2].Cardhand.Equal21)
                        lblComputerComment.Text = "Dealer has Black Jack and Computer have 5 card .. a push!";
                    else
                        lblComputerComment.Text = "Dealer and You have the same and Computer have 5 card .. a push!";
                    }
                else
                    {
                    if (gm.Players[2].Cardhand.Equal21)
                        lblComputerComment.Text = "Dealer has Black Jack and Computer, Computer Loose!";
                    else
                        lblComputerComment.Text = "Dealer and Computer have the same, Computer Loose!";
                    gm.Players[2].Balance = gm.Players[2].Balance - gm.Players[2].Betsize;
                    gm.Players[0].Balance = gm.Players[0].Balance + gm.Players[2].Betsize;
                    }
                }
            else if (gm.Players[0].Cardhand.BestHandvalue > gm.Players[2].Cardhand.BestHandvalue)
                {
                lblComputerComment.Text = "Dealer has a better hand than Computer, Computer Loose!";
                gm.Players[2].Balance = gm.Players[2].Balance - gm.Players[2].Betsize;
                gm.Players[0].Balance = gm.Players[0].Balance + gm.Players[2].Betsize;
                }
            else if (gm.Players[0].Cardhand.BestHandvalue < gm.Players[2].Cardhand.BestHandvalue)
                {
                lblComputerComment.Text = "Computer win ! Computers hand is better than the Dealer";
                gm.Players[2].Balance = gm.Players[2].Balance + gm.Players[2].Betsize;
                gm.Players[0].Balance = gm.Players[0].Balance - gm.Players[2].Betsize;
                }

            }
            else
                {
                lblComputerComment.Text = "Computer are busted but Dealer not, Computer Loose!";
                gm.Players[2].Balance = gm.Players[2].Balance - gm.Players[2].Betsize;
                gm.Players[0].Balance = gm.Players[0].Balance + gm.Players[2].Betsize;


                }

            }

    }
            
          



          



        private async void Blink(int nr)
            {
            int i = 0;
            while (i<nr)
                {
                i++;
                await Task.Delay(500);
                lblDealerComment.BackColor = lblDealerComment.BackColor == Color.Red ? Color.Green : Color.Red;
                }
            lblDealerComment.BackColor = lblPlayerComment.BackColor;
            }




        // Check for blackjacks
        /*
        if (scoreDealer == 11 && acesDealer == 1)
            scoreDealer = 21;
        if (scorePlayer == 11 && acesPlayer == 1)
            scorePlayer = 21;
        if (scoreDealer == 21 && scorePlayer == 21)
           // EndHand("Dealer has Blackjack!", "And, you have Blackjack .. a push!",  0);
        else if (scoreDealer == 21)
           // EndHand("Dealer has Blackjack!", "You lose ...", -10);
        else if (scorePlayer == 21)
           // EndHand("Dealer loses ...", "You have Blackjack!", 15);
           */

        
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
            {
            var form = new AboutBox1();
            System.IO.Stream audio = BlackJack.Properties.Resources.drum_roll_y;

            
            System.Media.SoundPlayer finishSoundPlayer = new  System.Media.SoundPlayer(audio);
            finishSoundPlayer.Play();
            form.Show();

            }

        private void mnuFile_Click(object sender, EventArgs e)
            {

            }

        private void btnNewRound_Click(object sender, EventArgs e)
            {
            lblStake.Text = "";
            picDealer1.Image = null;
            picDealer2.Image = null;
            picDealer3.Image = null;
            picDealer4.Image = null;
            picDealer5.Image = null;
            picDealer6.Image = null;
            picDealer7.Image = null;

            picPlayer1.Image = null;
            picPlayer2.Image = null;
            picPlayer3.Image = null;
            picPlayer4.Image = null;
            picPlayer5.Image = null;
            picPlayer6.Image = null;
            picPlayer7.Image = null;

            picComputer1.Image = null;
            picComputer2.Image = null;
            picComputer3.Image = null;
            picComputer4.Image = null;
            picComputer5.Image = null;
            picComputer6.Image = null;
            picComputer7.Image = null;
            this.NewRound();
            }

        public void NewRound()
            {
            rounds++;
            lblRounds.Text = rounds.ToString();
            gm.askComputerplayerBet();
            lblComputerComment.Text = "Computer Bets " + gm.Players[2].Betsize.ToString();
            lblComBetsize.Text = gm.Players[2].Betsize.ToString();

            System.IO.Stream audio = BlackJack.Properties.Resources.chipLay3;
            System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(audio);
           
            startSoundPlayer.Play();
            Refresh();

            //Ask for Bets.
            lblPlayerComment.Text = "Change Bets before You Press Deal";

            btnHit.Enabled = false;
            btnStay.Enabled = false;
            btnDeal.Enabled = true;
            btnChbet.Enabled = true;
            btnNewRound.Enabled = false;

            btnHit.Visible = false;
            btnStay.Visible = false;
            btnDeal.Visible = true;
            btnChbet.Visible = true;
            btnNewRound.Visible=false;
            btnStay.Visible = false;

            Refresh();
            btnChbet.Select();


            }

        private void cheatToolStripMenuItem_Click(object sender, EventArgs e)
            {

            }

        private void btnChbet_Click(object sender, EventArgs e)
            {
            int _bet_size = 0;
            while (_bet_size < 1 || _bet_size > 10)
                {
                string input = lblYouBetsize.Text;
                ShowInputDialog(ref input);
                lblYouBetsize.Text = input;
                _bet_size = int.Parse(input);
                if ((_bet_size < 1 || _bet_size > 10))
                    MessageBox.Show("Bet size should be between 1-10");
                }

            lblPlayerComment.Text = "Your Bets are " + _bet_size + "! Press Deal Now!";

            System.IO.Stream audio = BlackJack.Properties.Resources.chipLay3;
            System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(audio);

           
            startSoundPlayer.Play();
            gm.GetplayerBet(_bet_size);
            btnChbet.Visible = false;
            Refresh();
            btnDeal.Select();

            }
        private static DialogResult ShowInputDialog(ref string input)
            {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "BetSize";
            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;
            inputBox.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height) / 2);
            inputBox.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
            }
        
        private void btnDeal_Click(object sender, EventArgs e)
            {
            if (gm.Players[1].Balance <= 0)
                {
                MessageBox.Show("You are Bankrupt Game ENDS!!");
                this.Close();
                }
            else if (gm.Players[1].Betsize > gm.Players[1].Balance)
                gm.Players[1].Betsize = gm.Players[1].Balance;

            if (gm.Players[2].Balance <= 0)
                {
                MessageBox.Show("Computer are Bankrupt Game ENDS!!");
                this.Close();
                }
            else if (gm.Players[2].Betsize > gm.Players[2].Balance)
                gm.Players[2].Betsize = gm.Players[2].Balance;

            if (gm.Players[0].Balance <= 0)
                {
                MessageBox.Show("Dealer are Bankrupt Game ENDS!!");
                this.Close();
                }
            lblStake.Text = ((gm.Players[1].Betsize + gm.Players[2].Betsize) * 2).ToString();





            btnHit.Enabled = true;
            btnStay.Enabled = true;
            btnDeal.Enabled = false;
            btnChbet.Enabled = false;
            btnNewRound.Enabled = false;
            btnNewRound.Visible = false;


            this.Refresh();
            Application.DoEvents();
            


            System.IO.Stream audio = BlackJack.Properties.Resources.cardShuffle;


            System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(audio);
            startSoundPlayer.Play();
            NewHand();
            Refresh();
            Application.DoEvents();
            Refresh();
            }

        private void btnHit_Click(object sender, EventArgs e)
            {
            System.IO.Stream audio = BlackJack.Properties.Resources.cardPlace1;
            System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(audio);
            startSoundPlayer.Play();
            addCardPlayer();
            
            
            }

        private void btnStay_Click(object sender, EventArgs e)
            {
            Stay_click();
            }

        public void Stay_click()
            {
            btnHit.Enabled = false;
            btnStay.Enabled = false;
            btnHit.Visible = false;
            btnStay.Visible = false;
            System.IO.Stream audio = BlackJack.Properties.Resources.CHORD;
            System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(audio);


          
            startSoundPlayer.Play();
            //lblComputerComment.Text = " Computer Plays Now...";
            //lblPlayerComment.Text = " You Stands on " + lblYouCardPoints.Text;


            // Computer Player plays
            Computerplays();

            lblDealerComment.Text = "Dealer Plays Now...";


            Dealerplays();
            //



            }

        private void picDealer4_Click(object sender, EventArgs e)
            {

            }

        private void pictureBox2_Click(object sender, EventArgs e)
            {

            }
        }
    }
            
    
