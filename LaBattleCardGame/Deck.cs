using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LaBattleCardGame
{

    public class Deck
    {
        private List<Card> _deck = new List<Card>();
        private Random _random = new Random();
        private StringBuilder _sb = new StringBuilder();

        public Deck()
        {
            _deck = new List<Card>();
            _random = new Random();
            _sb = new StringBuilder();

            string[] suit = new string[] { "Diamonds", "Spades", "Hearts", "Clubs" };
            string[] kind = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10",
                "Jack", "Queen", "King", "Ace" }; 
            foreach (var suits in suit)
            {
                foreach (var kinds in kind)
                {
                    _deck.Add(new Card { Suit = suits, Kind = kinds });
                }
            }
        }

        public bool didDealHappen = true;

        public string Deal(List<Player> _players)
        {
            Player pl = new Player();
            try
            {
                while (_deck.Count > 0)
                {
                    foreach (Player player in _players)
                    {
                        DealCard(player);
                    }
                }
                didDealHappen = true;
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            return _sb.ToString();
        }


        public void DealCard(Player player)
        {
            try
            {
                Card card = _deck.ElementAt(_random.Next(_deck.Count));
                player.Cards.Add(card);
                _deck.Remove(card);
                _sb.Append(player.Name + " has the " + card.Kind + " of " + card.Suit + "\n");
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

    }
}
