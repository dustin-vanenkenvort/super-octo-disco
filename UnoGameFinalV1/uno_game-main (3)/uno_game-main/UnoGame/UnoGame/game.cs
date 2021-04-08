//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="C# Part 2">
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

    /// <summary>
    /// Game class
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Game
    {
        /// <summary>
        /// Current turn count, 0 will be player 1 will be computer... when more players are added it will be 1 thru n going left... then the reverse would have to change the way the order went. 
        /// </summary>
        public int TurnCount = 0;

        /// <summary>
        /// The number of players
        /// </summary>
        public int PlayerCount = 4;

        /// <summary>
        /// The direction the game flows, 0 for left and 1 for right.
        /// </summary>
        public int GameDirection = 0;

        /// <summary>
        /// Where the next card will be displayed 
        /// </summary>
        public int NextCardSlot = 0;

        /// <summary>
        /// Deck class 
        /// </summary>
        public Deck Deck;

        /// <summary>
        /// Gets the next player affected by a card being played, does not update turnCount.
        /// </summary>
        /// <returns> The player number of the affected player </returns>
        public int GetAffectedPlayer()
        {
            int pn = 0;
            if (this.PlayerCount == 2)
            {
                if (this.TurnCount == 0)
                {
                    pn = 2;
                }
                else
                {
                    pn = 0;
                }
            }
            else
            {
                if (this.GameDirection == 0)
                {
                    if (this.TurnCount != 3)
                    {
                        pn = this.TurnCount + 1;
                    }
                    else
                    {
                        pn = 0;
                    }
                }
                else
                {
                    if (this.TurnCount != 0)
                    {
                        pn = this.TurnCount - 1;
                    }
                    else
                    {
                        pn = 3;
                    }
                }
            }

            return pn;
        }

        /// <summary>
        /// Updates turn count
        /// </summary>
        public void UpdateTurnCount()
        {
            if (this.PlayerCount == 2)
            {
                if (this.TurnCount == 0)
                {
                    this.TurnCount = 2;
                }
                else if (this.TurnCount == 2)
                {
                    this.TurnCount = 0;
                }
            }
            else
            {
                if (this.GameDirection == 0)
                {
                    if (this.TurnCount != 3)
                    {
                        this.TurnCount++;
                    }
                    else
                    {
                        this.TurnCount = 0;
                    }
                }
                else
                {
                    if (this.TurnCount != 0)
                    {
                        this.TurnCount--;
                    }
                    else
                    {
                        this.TurnCount = 3;
                    }
                }
            }
        }
    }
}
