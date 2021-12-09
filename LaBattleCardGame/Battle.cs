using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaBattleCardGame
{
    public class Battle
    {
        private List<Card> _bounty;
        private StringBuilder _sb;
        public Random _random { get; set; }
        private List<Player> _playerList = new List<Player>();
        public int round = 0;

        public Battle(List<Player> playerList)
        {
            _random = new Random();
            _bounty = new List<Card>();
            _sb = new StringBuilder();
            _playerList = playerList;
        }
        public string PerformBattle()
        {
            var PlayerWithCards = new Dictionary<Player, Card>();
            try
            {
                foreach (Player player in _playerList)
                {
                    Card card = GetCard(player);
                    if (card != null)
                    {
                        PlayerWithCards.Add(player, card);
                    }
                }
                PerformEvaluation(PlayerWithCards);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return _sb.ToString();
        }

        public Card GetCard(Player player)
        {
            Card card = null;
            try
            {
                if (player.Cards.Count != 0)
                {
                    card = player.Cards.ElementAt(0);
                    player.Cards.Remove(card);
                    _bounty.Add(card);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return card;
        }

        private void PerformEvaluation(Dictionary<Player, Card> playersWithcard)
        {
            try
            {
                round = round + 1;
                displayBattleCards(playersWithcard);
                Player winnerplayer = new Player();
                int highestCard = 0;
                for (int i = 0; i < playersWithcard.Count; i++)
                {
                    var element = playersWithcard.ElementAt(i);
                    Player player1 = element.Key;
                    Card card1 = element.Value;
                    int cardValue1 = 0;
                    if (card1 != null)
                    {
                        cardValue1 = card1.CardValue();
                    }
                    for (int j = i + 1; j < playersWithcard.Count; j++)
                    {
                        var element1 = playersWithcard.ElementAt(j);
                        Player player2 = element1.Key;
                        Card card2 = element1.Value;
                        int cardValue2 = 0;
                        if (card2 != null)
                        {
                            cardValue2 = card2.CardValue();
                        }
                        if (cardValue1 == cardValue2)
                        {
                            War(playersWithcard);
                            goto last;

                        }
                        if (cardValue1 > cardValue2)
                        {
                            if (cardValue1 > highestCard)
                            {
                                highestCard = cardValue1;
                                winnerplayer.Name = player1.Name;
                            }
                        }
                        else
                        {
                            if (cardValue2 > highestCard)
                            {
                                highestCard = cardValue2;
                                winnerplayer.Name = player2.Name;
                            }
                        }
                    }

                }
                if (winnerplayer.Name != null)
                {
                    try
                    {
                        var cards = (from player in _playerList where player.Name == winnerplayer.Name select player.Cards).ToList()[0];
                        winnerplayer.Cards.AddRange(cards);
                        AwardWinner(winnerplayer);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }

                }
            last:;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }
        private void AwardWinner(Player player)
        {
            try
            {
                foreach (Player playerList in _playerList)
                {
                    if (player.Name == playerList.Name)
                    {
                        playerList.Cards.AddRange(_bounty);
                    }
                }
                _sb.Append("\n");
                _sb.Append("\n" + player.Name + " Wins!\n");
                _bounty.Clear();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }


        private void War(Dictionary<Player, Card> playersWithcard)
        {
            try
            {
                Player player = new Player();
                _sb.Append("\n" + "=======___WAR!___=======" + "\n");
                _sb.Append("\n" + "Adding 3 more cards to the battle ground..." + "\n");
                var playersWithcardWar = new Dictionary<Player, Card>();
                foreach (KeyValuePair<Player, Card> kvp in playersWithcard)
                {
                    GetCard(kvp.Key);
                    Card card = GetCard(kvp.Key);
                    GetCard(kvp.Key);
                    if (card != null)
                    {
                        playersWithcardWar.Add(kvp.Key, card);
                    }
                }
                PerformEvaluation(playersWithcardWar);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        private void displayBattleCards(Dictionary<Player, Card> playersWithCards)
        {
            try
            {
                StringBuilder _battleHistory = new StringBuilder();
                int count = 0;
                _battleHistory.Append("\n");
                _battleHistory.Append("\nBattle Cards: ");
                foreach (KeyValuePair<Player, Card> kvp in playersWithCards)
                {
                    count = count + 1;
                    if (kvp.Value != null)
                    {
                        _battleHistory.Append(kvp.Key.Name);
                        _battleHistory.Append(" have ");
                        _battleHistory.Append(kvp.Value.Kind);
                        _battleHistory.Append(" of ");
                        _battleHistory.Append(kvp.Value.Suit);
                        if (playersWithCards.Keys.Count != count)
                        {
                            _battleHistory.Append(" vs. ");
                        }

                    }
                }
                _sb.Append(_battleHistory);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void displayBountyCards()
        {
            try
            {
                _sb.Append("\n ");
                _sb.Append("\n Bounty ...");

                foreach (var card in _bounty)
                {
                    _sb.Append("\n" + card.Kind + " of " + card.Suit);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        private bool checkPlayerCard()
        {
            try
            {
                if (_playerList != null)
                {
                    var playerCards = (from r in _playerList where r.Cards.Count > 0 select r.Name).ToList();
                    if (playerCards.Count > 1)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return false;
        }

    }
}
