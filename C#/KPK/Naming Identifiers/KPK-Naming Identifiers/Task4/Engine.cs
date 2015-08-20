namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Engine
    {
        internal const int MaxPlayerPoints = 35;

        internal static void Start()
        {
            string command = string.Empty;
            char[,] board = InitBoard();
            char[,] bombField = GenerateBombs();
            int playerPoints = 0;
            bool foundBomb = false;
            List<Player> players = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool startScreen = true;
            bool playerNeverDied = false;

            do
            {
                if (startScreen)
                {
                    Console.WriteLine("Lets play Minesweeper. Try your luck and find the blocks without mines." +
                    " Command 'top' shows the ranking, 'restart' resets the game, 'exit' exits and have a nice day!");
                    RenderBoard(board);
                    startScreen = false;
                }
                Console.Write("Give us row and a column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= board.GetLength(0) && col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        Ranking(players);
                        break;
                    case "restart":
                        board = InitBoard();
                        bombField = GenerateBombs();
                        RenderBoard(board);
                        foundBomb = false;
                        startScreen = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombField[row, col] != '*')
                        {
                            if (bombField[row, col] == '-')
                            {
                                MakeMove(board, bombField, row, col);
                                playerPoints++;
                            }
                            if (MaxPlayerPoints == playerPoints)
                            {
                                playerNeverDied = true;
                            }
                            else
                            {
                                RenderBoard(board);
                            }
                        }
                        else
                        {
                            foundBomb = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nOops! Wrong command!\n");
                        break;
                }
                if (foundBomb)
                {
                    RenderBoard(bombField);
                    Console.Write("\nHrrrrrr! You died heroicly with {0} points. " +
                        "Tell us your name: ", playerPoints);
                    string nickname = Console.ReadLine();
                    Player player = new Player(nickname, playerPoints);
                    if (players.Count < 5)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Points < player.Points)
                            {
                                players.Insert(i, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }
                    players.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    players.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    Ranking(players);

                    board = InitBoard();
                    bombField = GenerateBombs();
                    playerPoints = 0;
                    foundBomb = false;
                    startScreen = true;
                }
                if (playerNeverDied)
                {
                    Console.WriteLine("\nWELL DONE! You have opened 35 blocks without drawing a single blood.");
                    RenderBoard(bombField);
                    Console.WriteLine("Give us your name, batka: ");
                    string nickname = Console.ReadLine();
                    Player player = new Player(nickname, playerPoints);
                    players.Add(player);
                    Ranking(players);
                    board = InitBoard();
                    bombField = GenerateBombs();
                    playerPoints = 0;
                    playerNeverDied = false;
                    startScreen = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Ranking(List<Player> players)
        {
            Console.WriteLine("\nScore:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} Points(blocks)",
                        i + 1, players[i].Name, players[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty Ranklist!\n");
            }
        }

        private static void MakeMove(char[,] board, char[,] bombField, int row, int col)
        {
            char countBombs = CountBombsNearby(bombField, row, col);
            bombField[row, col] = countBombs;
            board[row, col] = countBombs;
        }

        private static void RenderBoard(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardCols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardCols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] InitBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] GenerateBombs()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> generateRandomNumbers = new List<int>();
            while (generateRandomNumbers.Count < 15)
            {
                Random randomNumber = new Random();
                int number = randomNumber.Next(50);
                if (!generateRandomNumbers.Contains(number))
                {
                    generateRandomNumbers.Add(number);
                }
            }

            foreach (int number in generateRandomNumbers)
            {
                int row = (number % boardColumns);
                int col = (number / boardColumns);
                if (row == 0 && number != 0)
                {
                    row = boardColumns;
                    col--;
                }
                else
                {
                    row++;
                }
                board[col, row - 1] = '*';
            }

            return board;
        }

        private static void Calculations(char[,] board)
        {
            int boardRow = board.GetLength(1);
            int boardCol = board.GetLength(0);

            for (int i = 0; i < boardCol; i++)
            {
                for (int j = 0; j < boardRow; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char bombsCount = CountBombsNearby(board, i, j);
                        board[i, j] = bombsCount;
                    }
                }
            }
        }

        private static char CountBombsNearby(char[,] board, int boardCol, int boardRow)
        {
            int countBombs = 0;
            int boardRows = board.GetLength(0);
            int boardCols = board.GetLength(1);

            if (boardCol - 1 >= 0)
            {
                if (board[boardCol - 1, boardRow] == '*')
                {
                    countBombs++;
                }
            }
            if (boardCol + 1 < boardRows)
            {
                if (board[boardCol + 1, boardRow] == '*')
                {
                    countBombs++;
                }
            }
            if (boardRow - 1 >= 0)
            {
                if (board[boardCol, boardRow - 1] == '*')
                {
                    countBombs++;
                }
            }
            if (boardRow + 1 < boardCols)
            {
                if (board[boardCol, boardRow + 1] == '*')
                {
                    countBombs++;
                }
            }
            if ((boardCol - 1 >= 0) && (boardRow - 1 >= 0))
            {
                if (board[boardCol - 1, boardRow - 1] == '*')
                {
                    countBombs++;
                }
            }
            if ((boardCol - 1 >= 0) && (boardRow + 1 < boardCols))
            {
                if (board[boardCol - 1, boardRow + 1] == '*')
                {
                    countBombs++;
                }
            }
            if ((boardCol + 1 < boardRows) && (boardRow - 1 >= 0))
            {
                if (board[boardCol + 1, boardRow - 1] == '*')
                {
                    countBombs++;
                }
            }
            if ((boardCol + 1 < boardRows) && (boardRow + 1 < boardCols))
            {
                if (board[boardCol + 1, boardRow + 1] == '*')
                {
                    countBombs++;
                }
            }
            return char.Parse(countBombs.ToString());
        }
    }
}