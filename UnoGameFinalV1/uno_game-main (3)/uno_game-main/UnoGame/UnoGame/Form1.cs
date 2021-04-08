//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="C# Part 2">
//     Copyright (c) C# Part 2". All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace UnoGame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using UnoGame.Properties;

    /// <summary>
    /// Documentation for the class Form.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class Form1 : Form
    {
        /// <summary>
        /// Instantiate game class
        /// </summary>
        public Game Game = new Game();

        /// <summary>
        /// Rotation List
        /// </summary>
        public List<PlayerHand> RotationList = new List<PlayerHand>();

        /// <summary>
        /// A list of the labels, it will be RotationList - 1, as spot 0 on RotationList is the player's whose turn it is
        /// </summary>
        public List<Label> LabelList = new List<Label>();

        /// <summary>
        /// Creates a list of picture boxes to hold the slots picture box
        /// </summary>
        public List<PictureBox> Slots = new List<PictureBox>();

        /// <summary>
        /// Creates a list of players
        /// </summary>
        public List<PlayerHand> PlayerList = new List<PlayerHand>
        {
        };

        /// <summary>
        /// Making the displayCard method reusable by the discard picture box to a list
        /// </summary>
        public List<PictureBox> Discard = new List<PictureBox>();

        /// <summary>
        /// field for current selected card
        /// </summary>
        public string CurrentSelection;

        /// <summary>
        /// Computer moving count to avoid infinite loops
        /// </summary>
        public int ComputerMoving = 0;

        /// <summary>
        /// List that holds full deck of cards
        /// </summary>
        public List<string> FullDeckOfCards = new List<string>
        {
          "G0", "G1", "G1", "G2", "G2", "G3", "G3", "G4", "G4", "G5", "G5", "G6", "G6", "G7", "G7", "G8", "G8", "G9", "G9", "GS", "GS", "GR", "GR", "GD2", "GD2",
          "B0", "B1", "B1", "B2", "B2", "B3", "B3", "B4", "B4", "B5", "B5", "B6", "B6", "B7", "B7", "B8", "B8", "B9", "B9", "BS", "BS", "BR", "BR", "BD2", "BD2",
          "Y0", "Y1", "Y1", "Y2", "Y2", "Y3", "Y3", "Y4", "Y4", "Y5", "Y5", "Y6", "Y6", "Y7", "Y7", "Y8", "Y8", "Y9", "Y9", "YS", "YS", "YR", "YR", "YD2", "YD2",
          "R0", "R1", "R1", "R2", "R2", "R3", "R3", "R4", "R4", "R5", "R5", "R6", "R6", "R7", "R7", "R8", "R8", "R9", "R9", "RS", "RS", "RR", "RR", "RD2", "RD2",
          "W", "W", "W", "W", "D4", "D4", "D4", "D4"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.buttonOnePlayer.Visible = false;
            this.buttonThreePlayers.Visible = false;
            this.unoLogo.Visible = true;
            this.labelHandSize.Visible = false;
            this.label2HandSize.Visible = false;
            this.label3HandSize.Visible = false;
            this.fadeOutStart.Start();
            this.LabelList.Add(this.labelHandSize);
            this.LabelList.Add(this.label2HandSize);
            this.LabelList.Add(this.label3HandSize);

            for (int i = 0; i < 15; i++)
            {
               this.Slots.Add((PictureBox)Controls.Find("cardSlot" + (i + 1), true)[0]);
            }

            this.Game.Deck = new Deck(this.FullDeckOfCards);
        }

        /// <summary>
        /// start Fade out logo
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        public void FadeOutStart_Tick(object sender, EventArgs e)
        {
            this.unoLogo.Visible = false;
            this.fadeOutStart.Stop();
            this.buttonOnePlayer.Visible = true;
            this.buttonThreePlayers.Visible = true;
        }

        /// <summary>
        /// Method to display cards
        /// </summary>
        /// <param name="playerNum">uses players number to display the right hand</param>
        public void DisplayHand(int playerNum)
        {
            int max = this.Game.NextCardSlot;
            this.Game.NextCardSlot = 0;
            bool cardMaxReached = false;
            foreach (string s in this.PlayerList[playerNum].Hand)
            {
                if (max < 15)
                {
                    this.DisplayCard(s, this.Game.NextCardSlot, this.Slots);
                }
                else
                {
                    cardMaxReached = true;
                }

                this.Game.NextCardSlot++;
            }

            for (int i = 0; i < 15; i++)
            {
                if (this.PlayerList[playerNum].HandSize <= i)
                {
                    this.Slots[i].Image = null;
                }
            }

            if (cardMaxReached)
            {
                MessageBox.Show("Too many cards to show all, clear some out and it should work again");
            }             
        }

        /// <summary>
        /// Displays a cards image, at a specific index of a list of picture boxes.
        /// This is for reusability, to hopefully use in the discard pile picture.
        /// For example you can add just the 1 card to a list of picture boxes, then pass the 0 as the index and the card
        /// name you would like to display.
        /// </summary>
        /// <param name="card">The cards name</param>
        /// <param name="i">The index in the picture box list</param>
        /// <param name="slots">List of picture boxes, doesn't need to be the global slots list</param>
        public void DisplayCard(string card, int i, List<PictureBox> slots)
        {
            switch (card)
            {
                case "G1":
                    slots[i].Image = Resource1.RG1;
                    break;
                case "G0":
                    slots[i].Image = Resource1.G0;
                    break;
                case "G2":
                    slots[i].Image = Resource1.G2;
                    break;
                case "G3":
                    slots[i].Image = Resource1.G3;
                    break;
                case "GR":
                    slots[i].Image = Resource1.GR;
                    break;
                case "G4":
                    slots[i].Image = Resource1.G4;
                    break;
                case "G5":
                    slots[i].Image = Resource1.G5;
                    break;
                case "G6":
                    slots[i].Image = Resource1.G6;
                    break;
                case "G7":
                    slots[i].Image = Resource1.G7;
                    break;
                case "G8":
                    slots[i].Image = Resource1.G8;
                    break;
                case "G9":
                    slots[i].Image = Resource1.G9;
                    break;
                case "GS":
                    slots[i].Image = Resource1.GS;
                    break;
                case "GD2":
                    slots[i].Image = Resource1.GD2;
                    break;
                case "B1":
                    slots[i].Image = Resource1.B1;
                    break;
                case "B0":
                    slots[i].Image = Resource1.B0;
                    break;
                case "B2":
                    slots[i].Image = Resource1.B2;
                    break;
                case "B3":
                    slots[i].Image = Resource1.B3;
                    break;
                case "BR":
                    slots[i].Image = Resource1.BR;
                    break;
                case "B4":
                    slots[i].Image = Resource1.B4;
                    break;
                case "B5":
                    slots[i].Image = Resource1.B5;
                    break;
                case "B6":
                    slots[i].Image = Resource1.B6;
                    break;
                case "B7":
                    slots[i].Image = Resource1.B7;
                    break;
                case "B8":
                    slots[i].Image = Resource1.B8;
                    break;
                case "B9":
                    slots[i].Image = Resource1.B9;
                    break;
                case "BS":
                    slots[i].Image = Resource1.BS;
                    break;
                case "BD2":
                    slots[i].Image = Resource1.BD2;
                    break;
                case "R1":
                    slots[i].Image = Resource1.R1;
                    break;
                case "R0":
                    slots[i].Image = Resource1.R0;
                    break;
                case "R2":
                    slots[i].Image = Resource1.R2;
                    break;
                case "R3":
                    slots[i].Image = Resource1.R3;
                    break;
                case "RR":
                    slots[i].Image = Resource1.RR;
                    break;
                case "R4":
                    slots[i].Image = Resource1.R4;
                    break;
                case "R5":
                    slots[i].Image = Resource1.R5;
                    break;
                case "R6":
                    slots[i].Image = Resource1.R6;
                    break;
                case "R7":
                    slots[i].Image = Resource1.R7;
                    break;
                case "R8":
                    slots[i].Image = Resource1.R8;
                    break;
                case "R9":
                    slots[i].Image = Resource1.R9;
                    break;
                case "RS":
                    slots[i].Image = Resource1.RS;
                    break;
                case "RD2":
                    slots[i].Image = Resource1.R2;
                    break;
                case "Y1":
                    slots[i].Image = Resource1.Y1;
                    break;
                case "Y0":
                    slots[i].Image = Resource1.Y0;
                    break;
                case "Y2":
                    slots[i].Image = Resource1.Y2;
                    break;
                case "Y3":
                    slots[i].Image = Resource1.Y3;
                    break;
                case "YR":
                    slots[i].Image = Resource1.YR;
                    break;
                case "Y4":
                    slots[i].Image = Resource1.Y4;
                    break;
                case "Y5":
                    slots[i].Image = Resource1.Y5;
                    break;
                case "Y6":
                    slots[i].Image = Resource1.Y6;
                    break;
                case "Y7":
                    slots[i].Image = Resource1.Y7;
                    break;
                case "Y8":
                    slots[i].Image = Resource1.Y8;
                    break;
                case "Y9":
                    slots[i].Image = Resource1.Y9;
                    break;
                case "YS":
                    slots[i].Image = Resource1.YS;
                    break;
                case "YD2":
                    slots[i].Image = Resource1.YD2;
                    break;
                case "W":
                    slots[i].Image = Resource1.W;
                    break;
                case "D4":
                    slots[i].Image = Resource1.D4;
                    break;
                case "YW":
                    slots[i].Image = Resource1.W;
                    break;
                case "RW":
                    slots[i].Image = Resource1.W;
                    break;
                case "BW":
                    slots[i].Image = Resource1.W;
                    break;
                case "GW":
                    slots[i].Image = Resource1.W;
                    break;
            }
        }

        /// <summary>
        /// Attempts to play the selected card.
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        public void ButtonPlayCard_Click(object sender, EventArgs e)
        {
            if (this.CurrentSelection != null)
            {
                MessageBox.Show("Current Selection: " + this.CurrentSelection);
                if (this.IsLegal(this.CurrentSelection) == false)
                {
                    if (this.CurrentSelection == "W" || this.CurrentSelection == "D4")
                    {
                        List<string> moves = new List<string>();
                        //// To make sure it doesn't over loop the player list, as player2 (computer), is in the 1 index spot.
                        
                        int turncount = this.Game.TurnCount;
                        if (this.Game.PlayerCount == 2 && this.Game.TurnCount == 2)
                        {
                            turncount = 1;
                        }

                        foreach (string c in this.PlayerList[turncount].Hand)
                        {
                            if (this.IsLegal(c) == true)
                            {
                                moves.Add(c);
                            }
                        }

                        if (moves.Count == 0)
                        {
                            this.SelectCard(this.CurrentSelection);
                            this.NextPlayersTurn();
                        }
                        else
                        {
                            MessageBox.Show("You have " + moves.Count.ToString() + " possible move(s), draw 4 is only legal when you have nothing else to play.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Card cannot currently be played, if you have no matches try drawing a card!");
                    }
                }                   
                else
                {
                    this.SelectCard(this.CurrentSelection);

                    this.NextPlayersTurn();
                    /* *************
                     * 
                     *   Needs major fixing
                     * 
                     * *************/
                    /* if (this.CurrentSelection.ToCharArray()[1] != 'S' && this.CurrentSelection.ToCharArray()[1] != 'R')
                    {
                        
                        Will need to be changed for a real player's turn
                        *
                        *   Please read ^
                        *    
                        * !!!!!!!!!!!!!!!!
                        while (this.Game.TurnCount == 1)
                        {
                            Thread.Sleep(2000);
                            MessageBox.Show("Player 2 is moving!");
                            this.Player1Turn();
                        }

                        while (this.Game.TurnCount == 3)
                        {
                            Thread.Sleep(2000);
                            MessageBox.Show("Player 3 is moving!");
                            this.Player3Turn();
                        }
                    } */
                }

                this.UpdateHands();
            }
            else
            {
                MessageBox.Show("Must select a card first");
            }               
        }

        /// <summary>
        /// Check if the card is legal to play
        /// </summary>
        /// <param name="currentSelection">contains the current card on play</param>
        /// <returns> return playable value</returns>
        public bool IsLegal(string currentSelection)
        {
            bool playable = false;
            
            // Creates 2 char arrays to make comparing possible
            char[] cardSelected = currentSelection.ToCharArray();
            char[] cardDiscarded = this.Game.Deck.CurrentDiscard.ToCharArray();
            if (currentSelection != "W" && currentSelection != "D4")
            {
                // Filters out the nD2 cards
                if (cardSelected.Length == 2 && cardDiscarded.Length == 2)
                {
                    if (cardSelected[1] != 'S' && cardSelected[1] != 'R')
                    {
                        if (cardSelected[0] == cardDiscarded[0] || cardSelected[1] == cardDiscarded[1])
                        {
                            playable = true;
                        }
                    }
                    else
                    {
                        // Code for S and R, remember R turns into S in 1 player game.
                        if (cardSelected[0] == cardDiscarded[0] || cardSelected[1] == cardDiscarded[1])
                        {
                            playable = true;                           
                        }
                    }
                }
                else
                {
                    if (cardSelected[0] == cardDiscarded[0] || cardSelected[1] == cardDiscarded[1])
                    {
                        playable = true;
                    }
                }
            }
            else
            {
                playable = false;
            }

            return playable;
        }
    
        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="currentSelection">The card testing if it equal to discard pile</param>
        public void SelectCard(string currentSelection)
        {
            // Creates 2 char arrays to make comparing possible
            char[] cardSelected = currentSelection.ToCharArray();
            char[] cardDiscarded = this.Game.Deck.CurrentDiscard.ToCharArray();
            if (currentSelection != "W" && currentSelection != "D4")
            {
                // Filters out the nD2 cards
                if (cardSelected.Length == 2)
                {
                    if (cardSelected[1] != 'S' && cardSelected[1] != 'R')
                    {
                        if (cardSelected[0] == cardDiscarded[0] || cardSelected[1] == cardDiscarded[1])
                        {
                            this.PlayCard(currentSelection);
                        }
                    }
                    else
                    {
                        // Code for S and R, remember R turns into S in 1 player game.
                        if (cardSelected[0] == cardDiscarded[0] || cardSelected[1] == cardDiscarded[1])
                        {
                            this.PlayCard(currentSelection);
                        }
                    }
                }
                else
                {
                    if (cardSelected[0] == cardDiscarded[0] || cardSelected[1] == cardDiscarded[1])
                    {
                        this.Game.Deck.Draw(this.Game.GetAffectedPlayer());
                        this.Game.Deck.Draw(this.Game.GetAffectedPlayer());
                        /*
                        // Will need to change for more players
                        if (this.Game.TurnCount == 0)
                        {
                            this.Game.Deck.Player0.Hand.Remove(currentSelection);
                            this.Game.Deck.Draw(1);
                            this.Game.Deck.Draw(1);
                        }
                        else if (this.Game.TurnCount == 1)
                        {
                            this.Game.Deck.Player1.Hand.Remove(currentSelection);
                            this.Game.Deck.Draw(2);
                            this.Game.Deck.Draw(2);
                        }
                        else if (this.Game.TurnCount == 2)
                        {
                            this.Game.Deck.Player2.Hand.Remove(currentSelection);
                            this.Game.Deck.Draw(3);
                            this.Game.Deck.Draw(3);                     
                        }
                        else 
                        {
                            this.Game.Deck.Player3.Hand.Remove(currentSelection);
                            this.Game.Deck.Draw(0);
                            this.Game.Deck.Draw(0);
                            this.DisplayHand();
                        } */

                        this.PlayCard(currentSelection);
                    }
                }
            }
            else
            {
                /* *********
                 *  Needs updating for multiple players
                 * ********/
                if (currentSelection == "W")
                {
                    if (this.Game.TurnCount != 2)
                    {
                        this.buttonR.Enabled = true;
                        this.buttonY.Enabled = true;
                        this.buttonG.Enabled = true;
                        this.buttonB.Enabled = true;
                        this.buttonR.Visible = true;
                        this.buttonY.Visible = true;
                        this.buttonG.Visible = true;
                        this.buttonB.Visible = true;
                        this.buttonPlayCard.Enabled = false;
                        this.buttonDrawCard.Enabled = false;
                        this.CurrentSelection = string.Empty;
                    }
                    else
                    {
                        this.Game.Deck.Player2.Hand.Remove("W");
                        this.Game.Deck.Player2.Hand.Add("YW");
                        this.PlayCard("YW");
                        MessageBox.Show("The color is yellow");
                    }
                }
                else
                {
                    if (this.Game.TurnCount != 2)
                    {
                        this.Game.Deck.Draw(this.Game.GetAffectedPlayer());
                        this.Game.Deck.Draw(this.Game.GetAffectedPlayer());
                        this.Game.Deck.Draw(this.Game.GetAffectedPlayer());
                        this.Game.Deck.Draw(this.Game.GetAffectedPlayer());
                        int tempPlayerCount = 0;
                        if (this.Game.GetAffectedPlayer() == 2 && this.Game.PlayerCount == 2)
                        {
                            tempPlayerCount = 1;
                        }
                        else
                        {
                            tempPlayerCount = this.Game.GetAffectedPlayer();
                        }

                        this.UpdateHands();
                        this.buttonR.Enabled = true;
                        this.buttonY.Enabled = true;
                        this.buttonG.Enabled = true;
                        this.buttonB.Enabled = true;
                        this.buttonR.Visible = true;
                        this.buttonY.Visible = true;
                        this.buttonG.Visible = true;
                        this.buttonB.Visible = true;
                        this.buttonPlayCard.Enabled = false;
                        this.buttonDrawCard.Enabled = false;
                        this.CurrentSelection = string.Empty;
                    }
                    else 
                    {
                        this.Game.Deck.Draw(this.Game.GetAffectedPlayer());
                        this.Game.Deck.Draw(this.Game.GetAffectedPlayer());
                        this.Game.Deck.Draw(this.Game.GetAffectedPlayer());
                        this.Game.Deck.Draw(this.Game.GetAffectedPlayer());
                        this.DisplayHand(this.RotationList[0].PlayerNumber);
                        MessageBox.Show("The color is now red.");
                            
                        this.PlayCard("D4");
                    }

                    this.PlayCard(currentSelection);
                }
            }

            currentSelection = " ";
            this.DisplayHand(this.RotationList[0].PlayerNumber);
        }

        /// <summary>
        /// call method to play card and put it on discard pile
        /// </summary>
        /// <param name="card">The card currently playing</param>
        public void PlayCard(string card)
        {
            if (card != "D4")
            {
                this.DisplayCard(card, 0, this.Discard);
                this.Game.Deck.CurrentDiscard = card;
            }
            else
            {
                this.DisplayCard("RW", 0, this.Discard);
                this.Game.Deck.CurrentDiscard = "RW";
            }

            if (this.Game.TurnCount == 0)
            {
                this.Game.Deck.Player0.Hand.Remove(card);
                this.Game.Deck.Player0.HandSize--;
                this.DisplayHand(this.RotationList[0].PlayerNumber);
                if (card.ToCharArray()[1] != 'S' && card.ToCharArray()[1] != 'R' && this.Game.PlayerCount == 2)
                {
                    this.Game.UpdateTurnCount();
                }
                else
                {
                    if (card.ToCharArray()[1] == 'S' && this.Game.PlayerCount == 4)
                    {
                        this.Game.UpdateTurnCount();
                        this.Game.UpdateTurnCount();
                    }
                    else if (this.Game.PlayerCount == 4 && card.ToCharArray()[1] == 'R') 
                    {
                        if (this.Game.GameDirection == 0)
                        {
                            this.Game.GameDirection = 1;
                            this.Game.UpdateTurnCount();
                        }
                        else if (this.Game.GameDirection == 1)
                        {
                            this.Game.GameDirection = 0;
                            this.Game.UpdateTurnCount();
                        }
                    }
                    else
                    {
                        this.Game.UpdateTurnCount();
                    }
                }

                if (this.Game.Deck.Player0.Hand.Count == 0)
                {
                    MessageBox.Show("Player0 has won the game, game will now close.");
                    this.Close();
                }
            }
            else if (this.Game.TurnCount == 1)
            {
                this.Game.Deck.Player1.Hand.Remove(card);
                this.Game.Deck.Player1.HandSize--;
                if (card.ToCharArray()[1] != 'S' && card.ToCharArray()[1] != 'R' && this.Game.PlayerCount == 2)
                {
                    this.Game.UpdateTurnCount();
                }
                else
                {
                    if (card.ToCharArray()[1] == 'S' && this.Game.PlayerCount == 4)
                    {
                        this.Game.UpdateTurnCount();
                        this.Game.UpdateTurnCount();
                    }
                    else if (this.Game.PlayerCount == 4 && card.ToCharArray()[1] == 'R')
                    {
                        if (this.Game.GameDirection == 0)
                        {
                            this.Game.GameDirection = 1;
                            this.Game.UpdateTurnCount();
                        }
                        else if (this.Game.GameDirection == 1)
                        {
                            this.Game.GameDirection = 0;
                            this.Game.UpdateTurnCount();
                        }
                    }
                    else
                    {
                        this.Game.UpdateTurnCount();
                    }
                }
                //// Will need changing for multiple players
                if (this.Game.Deck.Player1.HandSize == 0)
                {                   
                    MessageBox.Show("Player1 has won the game, game will now close.");
                    this.Close();
                }
            }
            else if (this.Game.TurnCount == 2)
            {
                this.Game.Deck.Player2.Hand.Remove(card);
                this.Game.Deck.Player2.HandSize--;
                if (card.ToCharArray()[1] != 'S' && card.ToCharArray()[1] != 'R' && this.Game.PlayerCount == 2)
                {
                    this.Game.UpdateTurnCount();
                }
                else
                {
                    if (card.ToCharArray()[1] == 'S' && this.Game.PlayerCount == 4)
                    {
                        this.Game.UpdateTurnCount();
                        this.Game.UpdateTurnCount();
                    }
                    else if (this.Game.PlayerCount == 4 && card.ToCharArray()[1] == 'R')
                    {
                        if (this.Game.GameDirection == 0)
                        {
                            this.Game.GameDirection = 1;
                            this.Game.UpdateTurnCount();
                        }
                        else if (this.Game.GameDirection == 1)
                        {
                            this.Game.GameDirection = 0;
                            this.Game.UpdateTurnCount();
                        }  
                    }
                    else
                    {
                        this.Game.UpdateTurnCount();
                    }
                }
                //// Will need changing for multiple players
                if (this.Game.Deck.Player2.HandSize == 0)
                {
                    MessageBox.Show("Computer has won the game, game will now close.");
                    this.Close();
                }
            }
            else
            {
                this.Game.Deck.Player3.Hand.Remove(card);
                this.Game.Deck.Player3.HandSize--;
                if (card.ToCharArray()[1] != 'S' && card.ToCharArray()[1] != 'R' && this.Game.PlayerCount == 2)
                {
                    this.Game.UpdateTurnCount();
                }
                else
                {
                    if (card.ToCharArray()[1] == 'S' && this.Game.PlayerCount == 4)
                    {
                        this.Game.UpdateTurnCount();
                        this.Game.UpdateTurnCount();
                    }
                    else if (this.Game.PlayerCount == 4 && card.ToCharArray()[1] == 'R')
                    {
                        if (this.Game.GameDirection == 0)
                        {
                            this.Game.GameDirection = 1;
                            this.Game.UpdateTurnCount();
                        }
                        else if (this.Game.GameDirection == 1)
                        {
                            this.Game.GameDirection = 0;
                            this.Game.UpdateTurnCount();
                        }
                    }
                    else
                    {
                        this.Game.UpdateTurnCount();
                    }
                }
                //// Will need changing for multiple players
                if (this.Game.Deck.Player3.HandSize == 0)
                {
                    MessageBox.Show("Player3 has won the game, game will now close.");
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Method to move the game to the next player.
        /// </summary>
        public void NextPlayersTurn()
        {
            if (this.Game.PlayerCount == 4)
            {
                this.UpdateHands();
                if (this.Game.TurnCount != 2)
                {
                    MessageBox.Show("It is about to be player " + this.Game.TurnCount +
                                    "'s turn, the screen will shift");
                }

                while (this.Game.TurnCount == 2)
                {
                     this.ComputerTurn();
                }

                this.ShiftPlayers();
                if (this.RotationList[0].PlayerNumber == 2)
                {
                    this.ShiftPlayers();
                }
            }
            else
            {
                while (this.Game.TurnCount == 2)
                {
                    this.ComputerTurn();
                }
            }
        }

        /// <summary>
        /// Computer's turn to play the game, remember computer is now player 2
        /// </summary>
        public void ComputerTurn()
        {
            MessageBox.Show("Computer is moving!");
            Thread.Sleep(2000);
            //// bool legalMoves = false;
            List<string> possibleMoves = new List<string>();
            foreach (string card in this.Game.Deck.Player2.Hand)
            {
                if (this.IsLegal(card))
                {
                    possibleMoves.Add(card);
                }
            }              

            if (possibleMoves.Count() != 0)
            {
                //// legalMoves = true;
                this.SelectCard(possibleMoves[0]);
                this.UpdateHands();
            }
            else
            {
                MessageBox.Show("Computer is drawing a card");
                this.Game.Deck.Draw(2);
                this.UpdateHands();
            }

            this.UpdateHands();
        }

        /// <summary>
        /// Update's players hands;
        /// </summary>
        public void UpdateHands()
        {
            if (this.Game.PlayerCount == 2)
            {
                this.DisplayHand(this.RotationList[0].PlayerNumber);
                this.label2HandSize.Text = "Computer Hand Size: " + this.Game.Deck.Player2.HandSize;
            }
            else
            {
                this.DisplayHand(this.RotationList[0].PlayerNumber);
                for (int i = 0; i < 3; i++) 
                {
                    string message = " ";
                    if (this.RotationList[i + 1].PlayerNumber == 2)
                    {
                        message = "Computer Hand Size: ";
                    }
                    else
                    {
                        message = "Player " + this.RotationList[i + 1].PlayerNumber + " Hand Size: ";
                    }

                    this.LabelList[i].Text = message + this.RotationList[i + 1].HandSize;
                }
            }
        }

        /// <summary>
        /// shifts everyone left or right depending on games direction
        /// </summary>
        public void ShiftPlayers()
        {
            /* Shifting everyone either right or left depending on the game direction 
                Remember we shift the opposite way of the game flow, it makes sense logically. Took me a bit to
                realize
             */
            PlayerHand temp = new PlayerHand(0);
            if (this.Game.GameDirection == 0)
            {
                temp = this.RotationList[3];
                this.RotationList[3] = this.RotationList[0];
                this.RotationList[0] = this.RotationList[1];
                this.RotationList[1] = this.RotationList[2];
                this.RotationList[2] = temp;                
            }
            else
            {
                temp = this.RotationList[0];
                this.RotationList[0] = this.RotationList[3];
                this.RotationList[3] = this.RotationList[2];
                this.RotationList[2] = this.RotationList[1];
                this.RotationList[1] = temp;
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot1_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 1)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[0];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    //// To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 1)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[0];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 1)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[0];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 1)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[0];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot2_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 2)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[1];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    //// To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 2)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[1];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 2)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[1];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 2)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[1];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot3_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 3)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[2];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    //// To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 3)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[2];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 3)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[2];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 3)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[2];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot4_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 4)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[3];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    //// To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 4)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[3];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 4)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[3];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 4)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[3];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot5_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 5)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[4];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 5)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[4];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 5)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[4];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 5)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[4];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot6_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 6)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[5];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 6)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[5];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 6)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[5];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 6)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[5];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot7_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 7)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[6];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 7)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[6];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 7)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[6];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 7)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[6];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot8_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 8)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[7];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 8)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[7];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 8)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[7];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 8)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[7];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot9_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 9)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[8];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 9)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[8];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 9)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[8];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 9)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[8];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot10_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 10)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[9];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 10)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[9];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 10)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[9];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 10)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[9];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot11_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 11)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[10];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 11)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[10];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 11)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[10];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 11)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[10];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot12_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 12)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[11];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 12)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[11];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 12)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[11];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 12)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[11];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot13_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 13)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[12];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 13)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[12];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 13)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[12];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 13)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[12];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot14_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 14)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[13];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 14)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[13];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 14)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[13];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 14)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[13];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// gets the currently selected card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void CardSlot15_Click(object sender, EventArgs e)
        {
            if (this.Game.PlayerCount == 2)
            {
                this.Game.Deck.UpdateHandSize(0);
                if (this.RotationList[0].HandSize >= 15)
                {
                    this.CurrentSelection = this.RotationList[0].Hand[14];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // To skip the computer which is player 2
                    if (i == 2)
                    {
                        i = 3;
                    }

                    if (i == this.RotationList[0].PlayerNumber)
                    {
                        this.Game.Deck.UpdateHandSize(i);
                        switch (i)
                        {
                            case 0:
                                {
                                    if (this.Game.Deck.Player0.HandSize >= 15)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player0.Hand[14];
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (this.Game.Deck.Player1.HandSize >= 15)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player1.Hand[14];
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (this.Game.Deck.Player3.HandSize >= 15)
                                    {
                                        this.CurrentSelection = this.Game.Deck.Player3.Hand[14];
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// select color of the next card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void buttonB_Click(object sender, EventArgs e)
        {
            this.PlayerList[this.Game.TurnCount].Hand.Remove("W");
            this.PlayerList[this.Game.TurnCount].Hand.Add("BW");
            MessageBox.Show("The color is now blue.");
            this.PlayCard("BW");
            this.buttonPlayCard.Enabled = true;
            this.buttonDrawCard.Enabled = true;
            this.buttonR.Visible = false;
            this.buttonY.Visible = false;
            this.buttonG.Visible = false;
            this.buttonB.Visible = false;
        }

        /// <summary>
        /// select color of the next card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void buttonR_Click(object sender, EventArgs e)
        {
            this.PlayerList[this.Game.TurnCount].Hand.Remove("W");
            this.PlayerList[this.Game.TurnCount].Hand.Add("RW");
            MessageBox.Show("The color is now red.");
            this.PlayCard("RW");
            this.buttonPlayCard.Enabled = true;
            this.buttonDrawCard.Enabled = true;
            this.buttonR.Visible = false;
            this.buttonY.Visible = false;
            this.buttonG.Visible = false;
            this.buttonB.Visible = false;
        }

        /// <summary>
        /// select color of the next card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void buttonY_Click(object sender, EventArgs e)
        {
            this.PlayerList[this.Game.TurnCount].Hand.Remove("W");
            this.PlayerList[this.Game.TurnCount].Hand.Add("YW");
            this.PlayCard("YW");
            MessageBox.Show("The color is now yellow.");
            this.buttonPlayCard.Enabled = true;
            this.buttonDrawCard.Enabled = true;
            this.buttonR.Visible = false;
            this.buttonY.Visible = false;
            this.buttonG.Visible = false;
            this.buttonB.Visible = false;
        }

        /// <summary>
        /// select color of the next card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void buttonG_Click(object sender, EventArgs e)
        {
            this.PlayerList[this.Game.TurnCount].Hand.Remove("W");
            this.PlayerList[this.Game.TurnCount].Hand.Add("GW");
            MessageBox.Show("The color is now green.");
            this.PlayCard("GW");
            this.buttonPlayCard.Enabled = true;
            this.buttonDrawCard.Enabled = true;
            this.buttonR.Visible = false;
            this.buttonY.Visible = false;
            this.buttonG.Visible = false;
            this.buttonB.Visible = false;
        }

        /// <summary>
        /// Attempts to draw card
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void ButtonDrawCard_Click(object sender, EventArgs e)
        {
            //// List<string> possibleMoves = new List<string>();
            //// foreach (string card in this.Game.Deck.Player1.Hand)
            ////     if (IsLegal(card))
            ////     {
            ////         possibleMoves.Add(card);
            ////     }
            //// if (possibleMoves.Count() == 0)
            //// {
            ////     this.Game.Deck.Draw(this.Game.TurnCount);
            //// }
            //// else
            //// {
            ////     this.Game.Deck.Draw(this.Game.TurnCount);
            //// }
            //  Going to need to fix probably using the above code ^ view requirements for more info
            if (this.Game.Deck.Player0.HandSize <= 15)
            {
                this.Game.Deck.Draw(this.Game.TurnCount);
                this.DisplayHand(this.RotationList[0].PlayerNumber);
            }
            else
            {
                MessageBox.Show("You have the maximum amount of allotted cards, it will now be the computers turn.");
                this.ComputerTurn();
            }
        }

        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Shows the rules for Uno.
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void buttonRules_Click(object sender, EventArgs e)
        {
            //// spacing was done on purpose so it would go to the next line.
            MessageBox.Show("1.) You may have a maximum of 15 cards in your hand at once, at that point it will be the next players turn and you must wait to play a card until the next time possible." + "                                                                                                         2.) Your last card played cannot be a wild, if saving one it has to be played second to last.", "Rules", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Button for 1 player and the computer.
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void buttonOnePlayer_Click(object sender, EventArgs e)
        {
            // Created button for both, getting single player working first.
            this.buttonOnePlayer.Visible = false;
            this.buttonThreePlayers.Visible = false;
            this.buttonDrawCard.Enabled = true;
            this.buttonPlayCard.Enabled = true;
            this.deckSlot.Enabled = true;
            this.discardPile.Enabled = true;
            this.buttonDrawCard.Visible = true;
            this.buttonPlayCard.Visible = true;
            this.deckSlot.Visible = true;
            this.discardPile.Visible = true;
            this.label2HandSize.Visible = true;

            this.Game.PlayerCount = 2;

            this.Game.Deck.Player0 = new PlayerHand(0);
            this.Game.Deck.Player2 = new PlayerHand(2);

            this.PlayerList.Add(this.Game.Deck.Player0);
            this.PlayerList.Add(this.Game.Deck.Player2);
            this.RotationList.Add(this.Game.Deck.Player0);
            this.RotationList.Add(this.Game.Deck.Player2);

            // Shuffling the deck
            this.Game.Deck.Shuffle();

            // Dealing cards to other players, only made for 1 player and computer now but added a bit what will be needed for multiple players
            this.Game.Deck.Deal(this.Game.PlayerCount);
            string firstDiscard = this.Game.Deck.FirstDiscard();
            this.Discard.Add(this.discardPile);
            this.Game.Deck.CurrentDiscard = firstDiscard;
            this.DisplayCard(firstDiscard, 0, this.Discard);
            this.DisplayHand(this.RotationList[0].PlayerNumber);

            this.label2HandSize.Text = "Computer Hand Size: " + this.Game.Deck.Player2.HandSize;
        }

        /// <summary>
        /// Button for 3 players and the computer.
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event.</param>
        /// <param name="e">contains the event data</param>
        private void buttonThreePlayers_Click(object sender, EventArgs e)
        {
            this.buttonOnePlayer.Visible = false;
            this.buttonThreePlayers.Visible = false;
            this.buttonDrawCard.Enabled = true;
            this.buttonPlayCard.Enabled = true;
            this.deckSlot.Enabled = true;
            this.discardPile.Enabled = true;
            this.buttonDrawCard.Visible = true;
            this.buttonPlayCard.Visible = true;
            this.deckSlot.Visible = true;
            this.discardPile.Visible = true;
            this.label2HandSize.Visible = true;
            this.labelHandSize.Visible = true;
            this.label3HandSize.Visible = true;

            this.Game.PlayerCount = 4;

            this.Game.Deck.Player0 = new PlayerHand(0);
            this.Game.Deck.Player1 = new PlayerHand(1);
            this.Game.Deck.Player2 = new PlayerHand(2);
            this.Game.Deck.Player3 = new PlayerHand(3);

            // Player 2 will now be the computer, so it is across for single player game
            this.PlayerList.Add(this.Game.Deck.Player0);
            this.PlayerList.Add(this.Game.Deck.Player1);
            this.PlayerList.Add(this.Game.Deck.Player2);
            this.PlayerList.Add(this.Game.Deck.Player3);
            this.RotationList.Add(this.Game.Deck.Player0);
            this.RotationList.Add(this.Game.Deck.Player1);
            this.RotationList.Add(this.Game.Deck.Player2);
            this.RotationList.Add(this.Game.Deck.Player3);

            List<PlayerHand> playerList = new List<PlayerHand> { this.Game.Deck.Player0, this.Game.Deck.Player1, this.Game.Deck.Player2, this.Game.Deck.Player2 };

            // Shuffling the deck
            this.Game.Deck.Shuffle();

            MessageBox.Show("Cards 1, 2, 3 and 4 will be dealt. The lowest card is the dealer");
            Random rand = new Random();
            List<string> dealerCards = new List<string> { "Y1", "B2", "G3", "R4" };

            this.deal0.Visible = true;
            this.deal1.Visible = true;
            this.deal2.Visible = true;
            this.deal3.Visible = true;
            string randCard0 = dealerCards[rand.Next(dealerCards.Count)];
            dealerCards.Remove(randCard0);
            switch (randCard0)
            {
                case "Y1":
                    this.deal0.Image = Resource1.Y1;
                    break;
                case "B2":
                    this.deal0.Image = Resource1.B2;
                    break;
                case "G3":
                    this.deal0.Image = Resource1.G3;
                    break;
                case "R4":
                    this.deal0.Image = Resource1.R4;
                    break;
            }

            string randCard1 = dealerCards[rand.Next(dealerCards.Count)];
            dealerCards.Remove(randCard1);
            switch (randCard1)
            {
                case "Y1":
                    this.deal1.Image = Resource1.Y1;
                    break;
                case "B2":
                    this.deal1.Image = Resource1.B2;
                    break;
                case "G3":
                    this.deal1.Image = Resource1.G3;
                    break;
                case "R4":
                    this.deal1.Image = Resource1.R4;
                    break;
            }

            string randCard2 = dealerCards[rand.Next(dealerCards.Count)];
            dealerCards.Remove(randCard2);
            switch (randCard2)
            {
                case "Y1":
                    this.deal2.Image = Resource1.Y1;
                    break;
                case "B2":
                    this.deal2.Image = Resource1.B2;
                    break;
                case "G3":
                    this.deal2.Image = Resource1.G3;
                    break;
                case "R4":
                    this.deal2.Image = Resource1.R4;
                    break;
            }

            string randCard3 = dealerCards[rand.Next(dealerCards.Count)];
            dealerCards.Remove(randCard3); 
            switch (randCard3)
            {
                case "Y1":
                    this.deal3.Image = Resource1.Y1;
                    break;
                case "B2":
                    this.deal3.Image = Resource1.B2;
                    break;
                case "G3":
                    this.deal3.Image = Resource1.G3;
                    break;
                case "R4":
                    this.deal3.Image = Resource1.R4;
                    break;
            }

            int lowest = 3;
            if (randCard3.ToCharArray()[1] > randCard2.ToCharArray()[1] && randCard1.ToCharArray()[1] > randCard2.ToCharArray()[1] && randCard0.ToCharArray()[1] > randCard2.ToCharArray()[1])
            {
                lowest = 2;
            }

            if (randCard3.ToCharArray()[1] > randCard1.ToCharArray()[1] && randCard2.ToCharArray()[1] > randCard1.ToCharArray()[1] && randCard0.ToCharArray()[1] > randCard1.ToCharArray()[1])
            {
                lowest = 1;
            }

            if (randCard3.ToCharArray()[1] > randCard0.ToCharArray()[1] && randCard2.ToCharArray()[1] > randCard0.ToCharArray()[1] && randCard1.ToCharArray()[1] > randCard0.ToCharArray()[1])
            {
                lowest = 0;
            }

            Thread.Sleep(3000);

            MessageBox.Show("Looks like player " + lowest + " will be the dealer, we will start to the left of them");

            this.deal0.Visible = false;
            this.deal1.Visible = false;
            this.deal2.Visible = false;
            this.deal3.Visible = false;

            // Shift Players isn't working
            // Opponents turn isn't working
            // Update hand isn't working
            for (int i = 0; i < lowest + 1; i++)
            {
                this.ShiftPlayers();
                this.Game.UpdateTurnCount();
            }

            this.labelHandSize.Visible = true;
            this.label2HandSize.Visible = true;
            this.label3HandSize.Visible = true;

            // Dealing cards to other players, only made for 1 player and computer now but added a bit what will be needed for multiple players
            this.Game.Deck.Deal(this.Game.PlayerCount);
            string firstDiscard = this.Game.Deck.FirstDiscard();
            this.Discard.Add(this.discardPile);
            this.Game.Deck.CurrentDiscard = firstDiscard;
            this.DisplayCard(firstDiscard, 0, this.Discard);

            this.DisplayHand(this.RotationList[0].PlayerNumber);

            this.UpdateHands();

            // Reminder 2 is the computer
            if (this.Game.TurnCount == 2)
            {
                this.NextPlayersTurn();
            }
            else
            {
            }

            // Setting opponent hand size, will ideally be replaced with 15 slots showing the back uno card for every card in it.
            // The starting player is player 0.
        }

        // private void button1_Click(object sender, EventArgs e)
        // {
        //    string message = string.Empty;
        //    foreach (string c in this.RotationList[0].Hand)
        //    {
        //        message += " " + c;
        //    }

        ////    MessageBox.Show("Current Players Hand should be: " + message + "\n Current Turn:" + this.Game.TurnCount.ToString() + "\n Current Player: " + this.RotationList[0].PlayerNumber.ToString());
        // }
    }
}