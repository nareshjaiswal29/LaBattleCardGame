using System;
using System.Collections.Generic;

namespace LaBattleCardGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards;
        public Player()
        {
            Cards = new List<Card>();

        }
    }
}
