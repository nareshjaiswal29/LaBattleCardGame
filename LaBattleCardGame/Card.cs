using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaBattleCardGame
{
    // Cards have a suit and kind.
    public class Card
    {
        public string Suit { get; set; }
        public string Kind { get; set; }


        public int CardValue()
        {
            int value = 0;
            
            switch (this.Kind)
            {
                case "Jack":
                    value = 11;
                    break;
                case "Queen":
                    value = 12;
                    break;
                case "King":
                    value = 13;
                    break;
                case "Ace":
                    value = 14;
                    break;
                case null:
                    value = 0;
                    break;
                default:
                    value = int.Parse(this.Kind);
                    break;
             
            }
            return value;
        }
    }
}
