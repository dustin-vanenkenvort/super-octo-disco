//-----------------------------------------------------------------------
// <copyright file="Deck.cs" company="C# Part 2">
//     Copyright (c) C# Part 2". All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace UnoGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Implements the class deck
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Deck
    {
        /// <summary>
        /// Hold List of deck cards
        /// </summary>
        public List<string> DeckCard = new List<string>();

        /// <summary>
        /// Player 1
        /// </summary>
        public PlayerHand Player1;

        /// <summary>
        /// Player 2 as computer
        /// </summary>
        public PlayerHand Player2;

        /// <summary>
        /// Player 3
        /// </summary>
        public PlayerHand Player3;

        /// <summary>
        /// Player 0
        /// </summary>
        public PlayerHand Player0;

        /// <summary>
        /// Holds the currentDiscard
        /// </summary>
        public string CurrentDiscard;

        /// <summary>
        /// Initializes a new instance of the <see cref="Deck"/> class.
        /// </summary>
        /// <param name="d"> Add to list deck card</param>
        public Deck(List<string> d)
        {
            foreach (string c in d)
            {
                this.DeckCard.Add(c);
            }
        }

        /// <summary>
        /// shuffle method 
        /// </summary>
        public void Shuffle()
        {
            int index;
            string copy = this.DeckCard[0];
            string temp = string.Empty;
            Random gen = new Random();

            // Can be changed depending on how much we want to shuffle the deck
            for (int i = 0; i < 250; i++)
            {
                // Sending the first random number to the 0 spot, so we don't erase any cards
                index = gen.Next(this.DeckCard.Count - 1) + 1;
                temp = copy;
                copy = this.DeckCard[index];
                this.DeckCard[index] = temp;
            }

            this.DeckCard[0] = copy;
        }

        /// <summary>
        /// Method to draw card from deck
        /// </summary>
        /// <param name="playerNum">Represent player to draw</param>
        public void Draw(int playerNum)
        {
            string card = this.DeckCard[0];
            if (playerNum == 0)
            {
                this.Player0.Hand.Add(card);
                this.Player0.HandSize++;
            }
            else if (playerNum == 1)
            {
                this.Player1.Hand.Add(card);
                this.Player1.HandSize++;
            }
            else if (playerNum == 2)
            {
                this.Player2.Hand.Add(card);
                this.Player2.HandSize++;
            }
            else
            {
                this.Player3.Hand.Add(card);
                this.Player3.HandSize++;
            }

            this.DeckCard.Remove(card);
        }

        /// <summary>
        /// Method to remove and return the first card of the deck
        /// </summary>
        /// <returns> return card</returns>
        public string FirstDiscard()
        {
            string card = this.DeckCard[0];
            int i = 0;
            while (card == "D4" || card == "W")
            {
                i++;
                card = this.DeckCard[i];
            }

            this.DeckCard.Remove(card);
            return card;
        }

        /// <summary>
        /// Method to deal player 7 cards each when game begins
        /// </summary>
        /// <param name="playerCount">Player who will be given cards to deal</param>
        public void Deal(int playerCount)
        {
            // Testing
            // Shuffle();
            for (int i = 0; i < playerCount; i++)
            {
                if (playerCount == 2 && i == 1)
                {
                    i = 2;
                }

                    for (int s = 0; s < 7; s++)
                    {
                        this.Draw(i);
                    }
            }
        }

            /// <summary>
            /// Updates the handSize
            /// </summary>
            /// <param name="playerNum">Number of the player</param>
            public void UpdateHandSize(int playerNum)
            {
                if (playerNum == 0)
                {
                    int i = 0;
                    foreach (string s in this.Player0.Hand)
                    {
                        i++;
                        this.Player0.HandSize = i;
                    }
                }
                else if (playerNum == 1)
                {
                    int p = 0;
                    foreach (string s in this.Player1.Hand)
                    {
                        p++;
                        this.Player1.HandSize = p;
                    }
                }
                else if (playerNum == 2)
                {
                    int p = 0;
                    foreach (string s in this.Player2.Hand)
                    {
                        p++;
                        this.Player2.HandSize = p;
                    }
                }
                else if (playerNum == 3)
                {
                    int p = 0;
                    foreach (string s in this.Player3.Hand)
                    {
                        p++;
                        this.Player3.HandSize = p;
                    }
                }
            }
        }
    }
