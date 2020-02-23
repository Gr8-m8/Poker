using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class GameControll
    {
        static Random random;

        List<Player> players;
        Deck deck;

        List<Card> board;

        public GameControll(Random randomSet)
        {
            random = randomSet;
        }

        public void InitPlayers(int numberOfPlayers, int moneyStart)
        {
            players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player(moneyStart));
            }
        }

        public void AddPlayer(int moneyStart)
        {
            players.Add(new Player(moneyStart));
        }

        public void Game()
        {
            int rundsTimer = 30;
            
            while (--rundsTimer > 0)
            {
                board = new List<Card>();
                foreach (Player p in players)
                {
                    if (!p.Fold)
                    {
                        p.SetHand(deck.DrawCard(), deck.DrawCard());
                    }
                }

                int playersfold = 0;
                while (playersfold >= players.Count - 1 || board.Count >= 5) {

                    playersfold = 0;
                    foreach (Player p in players)
                    {
                        if (!p.Fold)
                        {
                            p.Act();
                        }
                        else
                        {
                            ++playersfold;
                        }
                    }

                    board.Add(deck.DrawCard());
                }
            }
        }
    }
}
