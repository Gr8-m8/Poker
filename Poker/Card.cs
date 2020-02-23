using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Card
    {
        int suit;
        int value;

        public Card(int suitSet, int valueSet)
        {
            suit = suitSet;
            value = valueSet;
        }
    }
}
