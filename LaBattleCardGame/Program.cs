using System;
using System.Collections.Generic;

namespace LaBattleCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to Battle card game!");
                Console.WriteLine("Please enter the number of players...Player should be 2 or 4!");
                int numberOfPlayers = 0;
                int numberOfBoards = 0;
                numberOfPlayers = checkInteger(numberOfPlayers);
                while (!checkNumber(numberOfPlayers))
                {
                    Console.Write("Please enter the number either 2 or 4: ");
                    numberOfPlayers = checkInteger(numberOfPlayers);
                }
                Console.WriteLine("Please enter the number of Boards!");
                numberOfBoards = checkInteger(numberOfBoards);
                List<Player> playerList = new List<Player>();
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    playerList.Add(new Player() { Name = "Player_" + (i + 1) });
                }

                Game game = new Game(playerList);
                Console.WriteLine(game.Play(numberOfBoards));
                Console.ReadLine();
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    // do nothing until escape
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }

        }
        public static bool checkNumber(int number)
        {
            if(number == 2 ||number==4)
            {
                return true;
            }
            return false;
        }

        public static int checkInteger(int number)
        {
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
            }
            return number;
        }


    }
}
