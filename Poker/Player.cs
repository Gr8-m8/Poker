using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Player
    {
        Card[] cards;

        bool fold = false;
        public bool Fold => fold;

        int money;
        public int Money => money;
        int bet;
        public int Bet => bet;

        public Player(int moneySet)
        {
            money = moneySet;
        }

        public void SetHand(Card card1, Card card2)
        {
            cards = new Card[2] {
                card1,
                card2
            };
        }

        public void Act()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    break;

                case ConsoleKey.W:
                    break;

                case ConsoleKey.E:
                    break;

            }
        }

        public void ActionBet()
        {

        }

        public void ActionCheck()
        {

        }

        public void ActionFold()
        {

        }
    }
}
