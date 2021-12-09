using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaBattleCardGame
{
    public class Game
    {
        private List<Player> _playerList = new List<Player>();

        public Game(List<Player> pl)
        {
            foreach (Player player in pl)
            {
                _playerList.Add(new Player { Name = player.Name });
            }

        }
        public string Play(int noOfBoard)
        {
            Deck deck = new Deck();
            string result = "";
            try
            {
                deck.Deal(_playerList);
                result = deck.Deal(_playerList);
                for (int i = 0; i < noOfBoard; i++)
                {

                    if (CheckPlayerCard())
                    {
                        result += "\n\n---------------------------------------------------------------------------------------------------";
                        result += "\n\nRound:- " + (i + 1).ToString();
                        Battle battle = new Battle(_playerList);
                        result += battle.PerformBattle();
                        result += TotalRemainingCard(_playerList);
                    }
                }
                result += DetermineWinner();
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            return result;
        }

        public string DetermineWinner()
        {
            string result = "";
            try
            {
                if (FindWinner() != string.Empty)
                {
                    result = "\n";
                    result += TotalRemainingCard(_playerList);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
           
            return result;
        }

        public string FindWinner()
        {
            if (_playerList.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            string winnerPlayer = string.Empty;
            try
            {
                int maxCard = 0;
                foreach (Player player in _playerList)
                {
                    if (player.Cards.Count > maxCard)
                    {
                        maxCard = player.Cards.Count;
                        winnerPlayer = player.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return winnerPlayer;
        }
        public bool CheckPlayerCard()
        {
            try
            {
                if (_playerList != null)
                {
                    var aa = (from r in _playerList where r.Cards.Count > 0 select r.Name).ToList();
                    if (aa.Count > 1)
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

        public string TotalRemainingCard(List<Player> playerList)
        {
            string rankList = "";
            int lastCardValue = -1;
            try
            {
                if (playerList != null)
                {
                    int count = 0;
                    List<Player> sortedList = (from r in playerList orderby r.Cards.Count descending select r).ToList();
                    foreach (Player player in sortedList)
                    {

                        if (lastCardValue != player.Cards.Count)
                        {
                            lastCardValue = player.Cards.Count;
                            count = count + 1;
                        }
                        rankList += "\nPlayer Name:- " + player.Name + ", Remaining Card:- " + player.Cards.Count + "  Rank:- " + (count);
                    };
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return rankList;

        }

    }
}
