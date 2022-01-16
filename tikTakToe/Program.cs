namespace TikTakToe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool won = false;
            string[] namePlayers = new string[2];
            Console.Write("Playre one please enter your name :");
            namePlayers[0] = Console.ReadLine();
            Console.Write("Playre two please enter your name :");
            namePlayers[1] = Console.ReadLine();

            string[,] tikTakToe = {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" } };

            while (!won)
            {
                DisplayGame(tikTakToe);
                IfWon(tikTakToe, namePlayers[1]);

                Console.Write($"{namePlayers[0]} its your turn , please enter your choise :");
                int choiseZero = IfNumber(Console.ReadLine(), namePlayers[0]);
                int[] choiseAdressZero = ValidChoise(tikTakToe, choiseZero, namePlayers[0]);
                tikTakToe[choiseAdressZero[0], choiseAdressZero[1]] = "O";

                DisplayGame(tikTakToe);
                IfWon(tikTakToe, namePlayers[0]);

                Console.Write($"{namePlayers[1]} its your turn , please enter your choise :");
                int choiseOne = IfNumber(Console.ReadLine(), namePlayers[1]);
                int[] choiseAdressOne = ValidChoise(tikTakToe, choiseOne, namePlayers[1]);
                tikTakToe[choiseAdressOne[0], choiseAdressOne[1]] = "X";
            }
        }

        public static void IfWon(string[,] game, string playerName)
        {
            if ((game[0, 0].Equals(game[0, 1]) && game[0, 1].Equals(game[0, 2]))
                || (game[1, 0].Equals(game[1, 1]) && game[1, 1].Equals(game[1, 2]))
                || (game[2, 0].Equals(game[2, 1]) && game[2, 1].Equals(game[2, 2]))
                || (game[0, 0].Equals(game[1, 0]) && game[1, 0].Equals(game[2, 0]))
                || (game[0, 1].Equals(game[1, 1]) && game[1, 1].Equals(game[2, 1]))
                || (game[0, 2].Equals(game[1, 2]) && game[1, 2].Equals(game[2, 2]))
                || (game[0, 0].Equals(game[1, 1]) && game[1, 1].Equals(game[2, 2]))
                || (game[0, 2].Equals(game[1, 1]) && game[1, 1].Equals(game[2, 0])))
            {
                Console.WriteLine($"Player {playerName} Won !!!!");
                Console.ReadLine();

            }
        }
        public static int[] ValidChoise(string[,] game, int choise, string namePlayer)
        {
            int[] choiseAdress = { 5, 5 };
            for (int i = 0; i < game.GetLength(0); i++)
            {

                for (int j = 0; j < game.GetLength(1); j++)
                {
                    if (Convert.ToString(choise) == game[i, j])
                    {
                        choiseAdress[0] = i;
                        choiseAdress[1] = j;
                    }
                }
            }
            if (choiseAdress[0] == 5 && choiseAdress[1] == 5)
            {
                Console.Write($"Wrong selection {namePlayer}, please enter valid selection :");
                string input = Console.ReadLine();
                choiseAdress = ValidChoise(game, IfNumber(input, namePlayer), namePlayer);
            }

            return choiseAdress;
        }
        public static void DisplayGame(string[,] game)
        {
            Console.Clear();
            Console.Write($"{game[0, 0]}|{game[0, 1]}|{game[0, 2]}\n" +
                          $"-----\n" +
                          $"{game[1, 0]}|{game[1, 1]}|{game[1, 2]}\n" +
                          $"-----\n" +
                          $"{game[2, 0]}|{game[2, 1]}|{game[2, 2]}\n" +
                          $"-----\n");
        }
        public static int IfNumber(string input, string player)
        {
            int intInput;
            bool isInt = int.TryParse(input, out intInput);
            while (!isInt)
            {
                isInt = int.TryParse(input, out intInput);
                if (isInt)
                {
                    break;
                }
                Console.Write($"Incorrect input player {player}, try again :");
                input = Console.ReadLine();
            }
            return intInput;
        }
    }
}