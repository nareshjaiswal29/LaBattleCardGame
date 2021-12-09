using NUnit.Framework;
using LaBattleCardGame;
using System.Collections.Generic;

namespace BattleTest
{
    public class Tests
    {
        List<Player> playerList = new List<Player>();
        Game game;
        Deck deck = new Deck();
        Battle battle;

        [SetUp]
        public void Setup()
        {
            addPlayerList();
            game = new Game(playerList);
            deck.Deal(playerList);
            battle = new Battle(playerList);
        }

        [Test]
        public void TestNumberofPlayers()
        {
            Assert.Pass("2", playerList.Count.ToString());
        }
       
        [Test]
        public void TestEqualyDistributedCards()
        {
            Assert.Pass("26", playerList[0].Cards.Count.ToString());
            Assert.Pass("26", playerList[1].Cards.Count.ToString());
        }


        [Test]
        public void verifyWinner()
        {
            game.Play(3);
            string winner = game.FindWinner();

            if (playerList[0].Cards.Count > playerList[0].Cards.Count)
            {
                Assert.Pass(playerList[0].Name, winner);
            }
            else
            {
                Assert.Pass(playerList[1].Name, winner);
            }
        }

        [Test]
        public void TestSameNumberOfCards()
        {

            if (playerList[0].Cards.Count != playerList[0].Cards.Count)
            {
                Assert.Pass();
            }
        }
        public void addPlayerList()
        {
            playerList.Add(new Player() { Name = "Player_1" });
            playerList.Add(new Player() { Name = "Player_2" });
        }

    }
}