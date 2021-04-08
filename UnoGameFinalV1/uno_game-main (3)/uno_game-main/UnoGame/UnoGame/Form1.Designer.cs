//-----------------------------------------------------------------------
// <copyright file="Form1.Designer.cs" company="C# Part 2">
//     Copyright (c) C# Part 2". All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace UnoGame
{
    /// <summary>
    /// Form1 class 
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// button exit
        /// </summary>
        private System.Windows.Forms.Button buttonExit;

        /// <summary>
        /// card slot 15
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot15;

        /// <summary>
        /// card slot 14
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot14;

        /// <summary>
        /// card slot 12
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot13;

        /// <summary>
        /// card slot 12
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot12;

        /// <summary>
        /// card slot 11
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot11;

        /// <summary>
        /// card slot 10
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot10;

        /// <summary>
        /// card slot 9
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot9;

        /// <summary>
        /// card slot 8
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot8;

        /// <summary>
        /// card slot 7
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot7;

        /// <summary>
        /// card slot 6
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot6;

        /// <summary>
        /// card slot 5
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot5;

        /// <summary>
        /// card slot 4
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot4;

        /// <summary>
        /// card slot 3
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot3;

        /// <summary>
        /// deck slot
        /// </summary>
        private System.Windows.Forms.PictureBox deckSlot;

        /// <summary>
        /// card slot 2
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot2;

        /// <summary>
        /// card slot 1
        /// </summary>
        private System.Windows.Forms.PictureBox cardSlot1;

        /// <summary>
        /// fade out start
        /// </summary>
        private System.Windows.Forms.Timer fadeOutStart;

        /// <summary>
        /// for the uno logo
        /// </summary>
        private System.Windows.Forms.PictureBox unoLogo;

        /// <summary>
        /// field for hand size label
        /// </summary>
        private System.Windows.Forms.Label labelHandSize;

        /// <summary>
        /// field for discard pile
        /// </summary>
        private System.Windows.Forms.PictureBox discardPile;

        /// <summary>
        /// field for play card
        /// </summary>
        private System.Windows.Forms.Button buttonPlayCard;

        /// <summary>
        /// field for blue button 
        /// </summary>
        private System.Windows.Forms.Button buttonB;

        /// <summary>
        /// field for yellow button 
        /// </summary>
        private System.Windows.Forms.Button buttonY;

        /// <summary>
        /// field for red button 
        /// </summary>
        private System.Windows.Forms.Button buttonR;

        /// <summary>
        /// field for green button 
        /// </summary>
        private System.Windows.Forms.Button buttonG;

        /// <summary>
        /// field for draw card button
        /// </summary>
        private System.Windows.Forms.Button buttonDrawCard;

        /// <summary>
        /// States the rules of the game
        /// </summary>
        private System.Windows.Forms.Button buttonRules;

        /// <summary>
        /// field for hand size label 2
        /// </summary>
        private System.Windows.Forms.Label label2HandSize;

        /// <summary>
        /// field for hand size label 3
        /// </summary>
        private System.Windows.Forms.Label label3HandSize;

        /// <summary>
        /// Field for buttons
        /// </summary>
        #region Windows Form Designer generated code

        /// <summary>
        /// Field for button One Player
        /// </summary>
        private System.Windows.Forms.Button buttonOnePlayer;

        /// <summary>
        /// Field for button for Three Players
        /// </summary>
        private System.Windows.Forms.Button buttonThreePlayers;

        /// <summary>
        /// Field for button for Three Players
        /// </summary>
        private System.Windows.Forms.PictureBox deal0;

        /// <summary>
        /// Field for button for Three Players
        /// </summary>
        private System.Windows.Forms.PictureBox deal1;

        /// <summary>
        /// Field for button for Three Players
        /// </summary>
        private System.Windows.Forms.PictureBox deal3;

        /// <summary>
        /// Field for button for Three Players
        /// </summary>
        private System.Windows.Forms.PictureBox deal2;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonExit = new System.Windows.Forms.Button();
            this.cardSlot15 = new System.Windows.Forms.PictureBox();
            this.cardSlot14 = new System.Windows.Forms.PictureBox();
            this.cardSlot13 = new System.Windows.Forms.PictureBox();
            this.cardSlot12 = new System.Windows.Forms.PictureBox();
            this.cardSlot11 = new System.Windows.Forms.PictureBox();
            this.cardSlot10 = new System.Windows.Forms.PictureBox();
            this.cardSlot9 = new System.Windows.Forms.PictureBox();
            this.cardSlot8 = new System.Windows.Forms.PictureBox();
            this.cardSlot7 = new System.Windows.Forms.PictureBox();
            this.cardSlot6 = new System.Windows.Forms.PictureBox();
            this.cardSlot5 = new System.Windows.Forms.PictureBox();
            this.cardSlot4 = new System.Windows.Forms.PictureBox();
            this.cardSlot3 = new System.Windows.Forms.PictureBox();
            this.deckSlot = new System.Windows.Forms.PictureBox();
            this.cardSlot2 = new System.Windows.Forms.PictureBox();
            this.cardSlot1 = new System.Windows.Forms.PictureBox();
            this.fadeOutStart = new System.Windows.Forms.Timer(this.components);
            this.unoLogo = new System.Windows.Forms.PictureBox();
            this.labelHandSize = new System.Windows.Forms.Label();
            this.discardPile = new System.Windows.Forms.PictureBox();
            this.buttonPlayCard = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonY = new System.Windows.Forms.Button();
            this.buttonR = new System.Windows.Forms.Button();
            this.buttonG = new System.Windows.Forms.Button();
            this.buttonDrawCard = new System.Windows.Forms.Button();
            this.buttonRules = new System.Windows.Forms.Button();
            this.label2HandSize = new System.Windows.Forms.Label();
            this.label3HandSize = new System.Windows.Forms.Label();
            this.buttonOnePlayer = new System.Windows.Forms.Button();
            this.buttonThreePlayers = new System.Windows.Forms.Button();
            this.deal0 = new System.Windows.Forms.PictureBox();
            this.deal1 = new System.Windows.Forms.PictureBox();
            this.deal3 = new System.Windows.Forms.PictureBox();
            this.deal2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deckSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unoLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardPile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deal0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deal3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deal2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(1141, 405);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 28);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // cardSlot15
            // 
            this.cardSlot15.Location = new System.Drawing.Point(1167, 458);
            this.cardSlot15.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot15.Name = "cardSlot15";
            this.cardSlot15.Size = new System.Drawing.Size(75, 110);
            this.cardSlot15.TabIndex = 3;
            this.cardSlot15.TabStop = false;
            this.cardSlot15.Click += new System.EventHandler(this.CardSlot15_Click);
            // 
            // cardSlot14
            // 
            this.cardSlot14.Location = new System.Drawing.Point(1084, 458);
            this.cardSlot14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot14.Name = "cardSlot14";
            this.cardSlot14.Size = new System.Drawing.Size(75, 110);
            this.cardSlot14.TabIndex = 4;
            this.cardSlot14.TabStop = false;
            this.cardSlot14.Click += new System.EventHandler(this.CardSlot14_Click);
            // 
            // cardSlot13
            // 
            this.cardSlot13.Location = new System.Drawing.Point(1001, 458);
            this.cardSlot13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot13.Name = "cardSlot13";
            this.cardSlot13.Size = new System.Drawing.Size(75, 110);
            this.cardSlot13.TabIndex = 5;
            this.cardSlot13.TabStop = false;
            this.cardSlot13.Click += new System.EventHandler(this.CardSlot13_Click);
            // 
            // cardSlot12
            // 
            this.cardSlot12.Location = new System.Drawing.Point(919, 458);
            this.cardSlot12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot12.Name = "cardSlot12";
            this.cardSlot12.Size = new System.Drawing.Size(75, 110);
            this.cardSlot12.TabIndex = 6;
            this.cardSlot12.TabStop = false;
            this.cardSlot12.Click += new System.EventHandler(this.CardSlot12_Click);
            // 
            // cardSlot11
            // 
            this.cardSlot11.Location = new System.Drawing.Point(836, 458);
            this.cardSlot11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot11.Name = "cardSlot11";
            this.cardSlot11.Size = new System.Drawing.Size(75, 110);
            this.cardSlot11.TabIndex = 7;
            this.cardSlot11.TabStop = false;
            this.cardSlot11.Click += new System.EventHandler(this.CardSlot11_Click);
            // 
            // cardSlot10
            // 
            this.cardSlot10.Location = new System.Drawing.Point(753, 458);
            this.cardSlot10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot10.Name = "cardSlot10";
            this.cardSlot10.Size = new System.Drawing.Size(75, 110);
            this.cardSlot10.TabIndex = 8;
            this.cardSlot10.TabStop = false;
            this.cardSlot10.Click += new System.EventHandler(this.CardSlot10_Click);
            // 
            // cardSlot9
            // 
            this.cardSlot9.Location = new System.Drawing.Point(671, 458);
            this.cardSlot9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot9.Name = "cardSlot9";
            this.cardSlot9.Size = new System.Drawing.Size(75, 110);
            this.cardSlot9.TabIndex = 9;
            this.cardSlot9.TabStop = false;
            this.cardSlot9.Click += new System.EventHandler(this.CardSlot9_Click);
            // 
            // cardSlot8
            // 
            this.cardSlot8.Location = new System.Drawing.Point(588, 458);
            this.cardSlot8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot8.Name = "cardSlot8";
            this.cardSlot8.Size = new System.Drawing.Size(75, 110);
            this.cardSlot8.TabIndex = 10;
            this.cardSlot8.TabStop = false;
            this.cardSlot8.Click += new System.EventHandler(this.CardSlot8_Click);
            // 
            // cardSlot7
            // 
            this.cardSlot7.Location = new System.Drawing.Point(505, 458);
            this.cardSlot7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot7.Name = "cardSlot7";
            this.cardSlot7.Size = new System.Drawing.Size(75, 110);
            this.cardSlot7.TabIndex = 11;
            this.cardSlot7.TabStop = false;
            this.cardSlot7.Click += new System.EventHandler(this.CardSlot7_Click);
            // 
            // cardSlot6
            // 
            this.cardSlot6.Location = new System.Drawing.Point(423, 458);
            this.cardSlot6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot6.Name = "cardSlot6";
            this.cardSlot6.Size = new System.Drawing.Size(75, 110);
            this.cardSlot6.TabIndex = 12;
            this.cardSlot6.TabStop = false;
            this.cardSlot6.Click += new System.EventHandler(this.CardSlot6_Click);
            // 
            // cardSlot5
            // 
            this.cardSlot5.Location = new System.Drawing.Point(340, 458);
            this.cardSlot5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot5.Name = "cardSlot5";
            this.cardSlot5.Size = new System.Drawing.Size(75, 110);
            this.cardSlot5.TabIndex = 13;
            this.cardSlot5.TabStop = false;
            this.cardSlot5.Click += new System.EventHandler(this.CardSlot5_Click);
            // 
            // cardSlot4
            // 
            this.cardSlot4.Location = new System.Drawing.Point(257, 458);
            this.cardSlot4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot4.Name = "cardSlot4";
            this.cardSlot4.Size = new System.Drawing.Size(75, 110);
            this.cardSlot4.TabIndex = 14;
            this.cardSlot4.TabStop = false;
            this.cardSlot4.Click += new System.EventHandler(this.CardSlot4_Click);
            // 
            // cardSlot3
            // 
            this.cardSlot3.Location = new System.Drawing.Point(175, 458);
            this.cardSlot3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot3.Name = "cardSlot3";
            this.cardSlot3.Size = new System.Drawing.Size(75, 110);
            this.cardSlot3.TabIndex = 15;
            this.cardSlot3.TabStop = false;
            this.cardSlot3.Click += new System.EventHandler(this.CardSlot3_Click);
            // 
            // deckSlot
            // 
            this.deckSlot.Enabled = false;
            this.deckSlot.Image = global::UnoGame.Resource1.backOfCard;
            this.deckSlot.Location = new System.Drawing.Point(423, 167);
            this.deckSlot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deckSlot.Name = "deckSlot";
            this.deckSlot.Size = new System.Drawing.Size(75, 110);
            this.deckSlot.TabIndex = 16;
            this.deckSlot.TabStop = false;
            this.deckSlot.Visible = false;
            // 
            // cardSlot2
            // 
            this.cardSlot2.Location = new System.Drawing.Point(92, 458);
            this.cardSlot2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot2.Name = "cardSlot2";
            this.cardSlot2.Size = new System.Drawing.Size(75, 110);
            this.cardSlot2.TabIndex = 17;
            this.cardSlot2.TabStop = false;
            this.cardSlot2.Click += new System.EventHandler(this.CardSlot2_Click);
            // 
            // cardSlot1
            // 
            this.cardSlot1.Location = new System.Drawing.Point(9, 458);
            this.cardSlot1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardSlot1.Name = "cardSlot1";
            this.cardSlot1.Size = new System.Drawing.Size(75, 110);
            this.cardSlot1.TabIndex = 18;
            this.cardSlot1.TabStop = false;
            this.cardSlot1.Click += new System.EventHandler(this.CardSlot1_Click);
            // 
            // fadeOutStart
            // 
            this.fadeOutStart.Interval = 7500;
            this.fadeOutStart.Tick += new System.EventHandler(this.FadeOutStart_Tick);
            // 
            // unoLogo
            // 
            this.unoLogo.Image = global::UnoGame.Resource1.unoLogo;
            this.unoLogo.Location = new System.Drawing.Point(219, 1);
            this.unoLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unoLogo.Name = "unoLogo";
            this.unoLogo.Size = new System.Drawing.Size(815, 449);
            this.unoLogo.TabIndex = 19;
            this.unoLogo.TabStop = false;
            this.unoLogo.Visible = false;
            // 
            // labelHandSize
            // 
            this.labelHandSize.AutoSize = true;
            this.labelHandSize.Location = new System.Drawing.Point(33, 206);
            this.labelHandSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHandSize.Name = "labelHandSize";
            this.labelHandSize.Size = new System.Drawing.Size(133, 17);
            this.labelHandSize.TabIndex = 24;
            this.labelHandSize.Text = "Player 1 Hand Size:";
            // 
            // discardPile
            // 
            this.discardPile.Enabled = false;
            this.discardPile.InitialImage = null;
            this.discardPile.Location = new System.Drawing.Point(519, 167);
            this.discardPile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.discardPile.Name = "discardPile";
            this.discardPile.Size = new System.Drawing.Size(75, 110);
            this.discardPile.TabIndex = 25;
            this.discardPile.TabStop = false;
            this.discardPile.Visible = false;
            // 
            // buttonPlayCard
            // 
            this.buttonPlayCard.Enabled = false;
            this.buttonPlayCard.Location = new System.Drawing.Point(1033, 369);
            this.buttonPlayCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPlayCard.Name = "buttonPlayCard";
            this.buttonPlayCard.Size = new System.Drawing.Size(100, 28);
            this.buttonPlayCard.TabIndex = 26;
            this.buttonPlayCard.Text = "Play Card";
            this.buttonPlayCard.UseVisualStyleBackColor = true;
            this.buttonPlayCard.Visible = false;
            this.buttonPlayCard.Click += new System.EventHandler(this.ButtonPlayCard_Click);
            // 
            // buttonB
            // 
            this.buttonB.Enabled = false;
            this.buttonB.Location = new System.Drawing.Point(629, 182);
            this.buttonB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(100, 28);
            this.buttonB.TabIndex = 27;
            this.buttonB.Text = "Blue";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Visible = false;
            this.buttonB.Click += new System.EventHandler(this.buttonB_Click);
            // 
            // buttonY
            // 
            this.buttonY.Enabled = false;
            this.buttonY.Location = new System.Drawing.Point(629, 218);
            this.buttonY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonY.Name = "buttonY";
            this.buttonY.Size = new System.Drawing.Size(100, 28);
            this.buttonY.TabIndex = 28;
            this.buttonY.Text = "Yellow";
            this.buttonY.UseVisualStyleBackColor = true;
            this.buttonY.Visible = false;
            this.buttonY.Click += new System.EventHandler(this.buttonY_Click);
            // 
            // buttonR
            // 
            this.buttonR.Enabled = false;
            this.buttonR.Location = new System.Drawing.Point(737, 182);
            this.buttonR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(100, 28);
            this.buttonR.TabIndex = 29;
            this.buttonR.Text = "Red";
            this.buttonR.UseVisualStyleBackColor = true;
            this.buttonR.Visible = false;
            this.buttonR.Click += new System.EventHandler(this.buttonR_Click);
            // 
            // buttonG
            // 
            this.buttonG.Enabled = false;
            this.buttonG.Location = new System.Drawing.Point(737, 218);
            this.buttonG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonG.Name = "buttonG";
            this.buttonG.Size = new System.Drawing.Size(100, 28);
            this.buttonG.TabIndex = 30;
            this.buttonG.Text = "Green";
            this.buttonG.UseVisualStyleBackColor = true;
            this.buttonG.Visible = false;
            this.buttonG.Click += new System.EventHandler(this.buttonG_Click);
            // 
            // buttonDrawCard
            // 
            this.buttonDrawCard.Enabled = false;
            this.buttonDrawCard.Location = new System.Drawing.Point(1141, 369);
            this.buttonDrawCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDrawCard.Name = "buttonDrawCard";
            this.buttonDrawCard.Size = new System.Drawing.Size(100, 28);
            this.buttonDrawCard.TabIndex = 31;
            this.buttonDrawCard.Text = "Draw Card";
            this.buttonDrawCard.UseVisualStyleBackColor = true;
            this.buttonDrawCard.Visible = false;
            this.buttonDrawCard.Click += new System.EventHandler(this.ButtonDrawCard_Click);
            // 
            // buttonRules
            // 
            this.buttonRules.Location = new System.Drawing.Point(1035, 405);
            this.buttonRules.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRules.Name = "buttonRules";
            this.buttonRules.Size = new System.Drawing.Size(100, 28);
            this.buttonRules.TabIndex = 32;
            this.buttonRules.Text = "Rules";
            this.buttonRules.UseVisualStyleBackColor = true;
            this.buttonRules.Click += new System.EventHandler(this.buttonRules_Click);
            // 
            // label2HandSize
            // 
            this.label2HandSize.AutoSize = true;
            this.label2HandSize.Location = new System.Drawing.Point(507, 9);
            this.label2HandSize.Name = "label2HandSize";
            this.label2HandSize.Size = new System.Drawing.Size(142, 17);
            this.label2HandSize.TabIndex = 33;
            this.label2HandSize.Text = "Computer Hand Size:";
            // 
            // label3HandSize
            // 
            this.label3HandSize.AutoSize = true;
            this.label3HandSize.Location = new System.Drawing.Point(1093, 194);
            this.label3HandSize.Name = "label3HandSize";
            this.label3HandSize.Size = new System.Drawing.Size(133, 17);
            this.label3HandSize.TabIndex = 34;
            this.label3HandSize.Text = "Player 3 Hand Size:";
            // 
            // buttonOnePlayer
            // 
            this.buttonOnePlayer.Location = new System.Drawing.Point(480, 132);
            this.buttonOnePlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOnePlayer.Name = "buttonOnePlayer";
            this.buttonOnePlayer.Size = new System.Drawing.Size(100, 28);
            this.buttonOnePlayer.TabIndex = 35;
            this.buttonOnePlayer.Text = "One Player";
            this.buttonOnePlayer.UseVisualStyleBackColor = true;
            this.buttonOnePlayer.Click += new System.EventHandler(this.buttonOnePlayer_Click);
            // 
            // buttonThreePlayers
            // 
            this.buttonThreePlayers.Location = new System.Drawing.Point(604, 132);
            this.buttonThreePlayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonThreePlayers.Name = "buttonThreePlayers";
            this.buttonThreePlayers.Size = new System.Drawing.Size(100, 28);
            this.buttonThreePlayers.TabIndex = 36;
            this.buttonThreePlayers.Text = "3 Players";
            this.buttonThreePlayers.UseVisualStyleBackColor = true;
            this.buttonThreePlayers.Click += new System.EventHandler(this.buttonThreePlayers_Click);
            // 
            // deal0
            // 
            this.deal0.Location = new System.Drawing.Point(655, 324);
            this.deal0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deal0.Name = "deal0";
            this.deal0.Size = new System.Drawing.Size(75, 110);
            this.deal0.TabIndex = 37;
            this.deal0.TabStop = false;
            this.deal0.Visible = false;
            // 
            // deal1
            // 
            this.deal1.Location = new System.Drawing.Point(175, 167);
            this.deal1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deal1.Name = "deal1";
            this.deal1.Size = new System.Drawing.Size(75, 110);
            this.deal1.TabIndex = 38;
            this.deal1.TabStop = false;
            this.deal1.Visible = false;
            // 
            // deal3
            // 
            this.deal3.Location = new System.Drawing.Point(1097, 218);
            this.deal3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deal3.Name = "deal3";
            this.deal3.Size = new System.Drawing.Size(75, 110);
            this.deal3.TabIndex = 39;
            this.deal3.TabStop = false;
            this.deal3.Visible = false;
            // 
            // deal2
            // 
            this.deal2.Location = new System.Drawing.Point(671, 15);
            this.deal2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deal2.Name = "deal2";
            this.deal2.Size = new System.Drawing.Size(75, 110);
            this.deal2.TabIndex = 40;
            this.deal2.TabStop = false;
            this.deal2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 582);
            this.Controls.Add(this.deal2);
            this.Controls.Add(this.deal3);
            this.Controls.Add(this.deal1);
            this.Controls.Add(this.deal0);
            this.Controls.Add(this.buttonThreePlayers);
            this.Controls.Add(this.buttonOnePlayer);
            this.Controls.Add(this.label3HandSize);
            this.Controls.Add(this.label2HandSize);
            this.Controls.Add(this.buttonRules);
            this.Controls.Add(this.buttonDrawCard);
            this.Controls.Add(this.buttonG);
            this.Controls.Add(this.buttonR);
            this.Controls.Add(this.buttonY);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonPlayCard);
            this.Controls.Add(this.discardPile);
            this.Controls.Add(this.labelHandSize);
            this.Controls.Add(this.cardSlot1);
            this.Controls.Add(this.cardSlot2);
            this.Controls.Add(this.deckSlot);
            this.Controls.Add(this.cardSlot3);
            this.Controls.Add(this.cardSlot4);
            this.Controls.Add(this.cardSlot5);
            this.Controls.Add(this.cardSlot6);
            this.Controls.Add(this.cardSlot7);
            this.Controls.Add(this.cardSlot8);
            this.Controls.Add(this.cardSlot9);
            this.Controls.Add(this.cardSlot10);
            this.Controls.Add(this.cardSlot11);
            this.Controls.Add(this.cardSlot12);
            this.Controls.Add(this.cardSlot13);
            this.Controls.Add(this.cardSlot14);
            this.Controls.Add(this.cardSlot15);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.unoLogo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Uno";
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deckSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardSlot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unoLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardPile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deal0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deal3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deal2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
