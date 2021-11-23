using Game.Controller;
using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int optionContinue = 0;
            while (optionContinue == 0)
            {
                var game = new GameController();
                InitialText();
                int playersOption = ReadOption(2);

                game.InitializeGame(playersOption == 0, playersOption == 2);
                for (int i = 0; i < 3; i++)
                {
                    Console.Clear();
                    ShowScore(game);
                    if (playersOption == 0)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("*****************Player 1 Selection*****************");
                        SelectionText();
                        int players1OptionSelected = ReadOption(3);
                        Console.WriteLine(" ");
                        Console.WriteLine("*****************Player 2 Selection*****************");
                        SelectionText();
                        int players2OptionSelected = ReadOption(3);
                        var continueGame = CalculeWinner(players1OptionSelected, players2OptionSelected, game);
                        if (!continueGame)
                            return;
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("*****************Player 1 Selection*****************");
                        SelectionText();
                        int players1OptionSelected = ReadOption(3);
                        int players2OptionSelected = game.GetComputerOption();
                        Console.WriteLine("The computer have selected the option: " + players2OptionSelected);
                        var continueGame = CalculeWinner(players1OptionSelected, players2OptionSelected, game);
                        if (!continueGame)
                            return;
                    }
                }

                Console.Clear();
                ShowScore(game);
                if (game.Player1Points < game.Player2Points)
                    Console.WriteLine("*************The champion is the Player2*************");
                else
                    Console.WriteLine("*************The champion is the Player1*************");
                Console.WriteLine("Press 0 to continue new game or 1 to exit");
                optionContinue = ReadOption(1);
                Console.Clear();
            }
        }

        private static bool CalculeWinner(int players1OptionSelected, int players2OptionSelected, GameController game)
        {
            if (players1OptionSelected == players2OptionSelected)
            {
                Console.WriteLine("The players have selected the same option, game over, press any key to continue");
                Console.ReadKey();
                return false;
            }
            else
            {
                if (game.IsWinner(players1OptionSelected, players2OptionSelected))
                    Console.WriteLine("the winner of the round " + game.Round + " is the player 1, press any key to continue");
                else
                    Console.WriteLine("the winner of the round " + game.Round + " is the player 2, press any key to continue");
                Console.ReadKey();
                return true;
            }
        }

        private static void ShowScore(GameController game)
        {
            Console.WriteLine(" ");
            Console.WriteLine("***********************Score***********************");
            Console.WriteLine("Rounds Played:   " + game.Round );
            Console.WriteLine("Player1:   " + game.Player1Points + " Points");
            Console.WriteLine("Player2:   " + game.Player2Points + " Points");
            Console.WriteLine("*****************************************************");
        }

        private static void InitialText()
        {
            Console.WriteLine(" ");
            Console.WriteLine("*****************WELCOME TO THE GAME*****************");
            Console.WriteLine("Options:");
            Console.WriteLine("press 0 for: Two human players");
            Console.WriteLine("press 1 for: One human player vs computer (stronger opition selector)");
            Console.WriteLine("press 2 for: One human player vs computer (ramdon selector)");
        }
        private static void SelectionText()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("press 0 for: Rock");
            Console.WriteLine("press 1 for: Paper");
            Console.WriteLine("press 2 for: Scissors");
            Console.WriteLine("press 3 for: Flamethrower");
        }

        private static int ReadOption(int max)
        {
            int n;
            while ((!int.TryParse(Console.ReadLine(), out n)) || n < 0 || n > max)
            {
                Console.Clear();
                InitialText();

                Console.WriteLine("You entered an invalid number");
                Console.Write("enter number of conversations ");
            }

            return n;
        }

    }
}
