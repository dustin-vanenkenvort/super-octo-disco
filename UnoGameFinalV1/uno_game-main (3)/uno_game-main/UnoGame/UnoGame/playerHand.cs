//-----------------------------------------------------------------------
// <copyright file="PlayerHand.cs" company="C# Part 2">
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
    /// PlayerHand class
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class PlayerHand
    {
        /// <summary>
        /// hold variable of player number
        /// </summary>
        public int PlayerNumber;

        /// <summary>
        /// variable for hand size
        /// </summary>
        public int HandSize = 0;

        /// <summary>
        /// hold List of string hand
        /// </summary>
        public List<string> Hand = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerHand"/> class.
        /// </summary>
        /// <param name="pn"> Set the number for player number.</param>
        public PlayerHand(int pn)
        {
            this.PlayerNumber = pn;
        }

        /// <summary>
        /// method to add card to list
        /// </summary>
        /// <param name="c">contains the card to be added on hand list.</param>
        public void AddCard(string c)
        {
            this.Hand.Add(c);
            this.HandSize++;
        }

        /// <summary>
        /// method to remove card that was used 
        /// </summary>
        /// <param name="card">contains the type of card that was played.</param>
        /// <param name="discardCard">contains the discard card</param>
        public void PlayCard(string card, string discardCard)
        {
            this.Hand.Remove(card);
            this.HandSize--;
        }
    }
}