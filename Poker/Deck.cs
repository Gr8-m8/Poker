using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Deck
    {
        Random random;// = new Random();
        List<Card> cards; //= new List<Card>();

        public Deck(Random randomSet)
        {
            random = randomSet;

            cards = new List<Card>();

            for (int s = 0; s < 4; s++)
            {
                for(int v = 1; v < 14; v++)
                {
                    cards.Add(new Card(s+1, v+1));
                }
            }
        }

        public Card DrawCard()
        {
            int index = random.Next(cards.Count);
            Card draw = cards[index];
            cards.RemoveAt(index);

            return draw;
        }
    }
}
