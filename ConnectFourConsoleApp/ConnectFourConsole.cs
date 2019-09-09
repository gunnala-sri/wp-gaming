using ConnectFourService;
using System;

namespace ConnectFourConsoleApp
{
    /// <summary>
    /// Console class to handle the user interaction for the Game.
    /// </summary>
    public class ConnectFourConsole
    {
        /// <summary>
        /// ConnectFour Service class object 
        /// </summary>
        private ConnectFour _connectFour;

        /// <summary>
        /// Number of rows in ConnectFour Board 
        /// </summary>
        private int _rows;

        /// <summary>
        /// Number of columns in ConnectFour Board
        /// </summary>
        private int _columns;


        /// <summary>
        /// Starts the ConnectFour Game
        /// </summary>
        public void StartGame()
        {
            // Display welcome message and instructions
            this.DisplayWelcomeInfo();

            // Read board size.
            this.ReadGameInputs();

            // Initialize the ConnectFourService
            this.InitializeGame();

            // Run the game.
            this.Run();

            Console.ReadLine();
        }

        /// <summary>
        /// Displays welcome info and instructions
        /// </summary>
        private void DisplayWelcomeInfo()
        {
            Console.WriteLine("Welcome to Connect Four. Please read the instructions below, before you start.");
            Console.WriteLine("1. Two players game");
            Console.WriteLine("2. Player 1 is Yellow and indicated with 'Y' on the board");
            Console.WriteLine("3. Player 2 is Red and indicated with 'R' on the board");
            Console.WriteLine("-------------------------------GAME STARTS NOW--------------------------------");
        }

        /// <summary>
        /// Read the bord size - number of rows and columns
        /// </summary>
        private void ReadGameInputs()
        {
            Console.WriteLine("Please enter number rows. It should be greater than 4");
            string rowsInput = Console.ReadLine();
            int rowNumber;
            while (!Int32.TryParse(rowsInput, out rowNumber) || rowNumber < 4)
            {
                //this.CheckEscKey();
                Console.WriteLine("Please enter valid input");
                rowsInput = Console.ReadLine();
            }

            Console.WriteLine("Please enter number columns. It should be greater than 4");
            string colsInput = Console.ReadLine();
            int colNumber;
            while (!Int32.TryParse(colsInput, out colNumber) || colNumber < 4)
            {
                //this.CheckEscKey();
                Console.WriteLine("Please enter valid input");
                colsInput = Console.ReadLine();
            }

            this._rows = rowNumber;
            this._columns = colNumber;
        }

        /// <summary>
        /// Initializes the ConnectFour service and displays intial board.
        /// </summary>
        private void InitializeGame()
        {
            this._connectFour = new ConnectFour(this._rows, this._columns);

            Console.WriteLine("The boad has initialized");
            this.DisplayBorad();

            Console.WriteLine();
        }

        /// <summary>
        /// Runs the Games. 
        /// Gives turns to each player, checks for win/draw.
        /// </summary>
        private void Run()
        {
            bool yellowTurn = true;
            char player;
            string colInput;

            do
            {
                // give a turn to each individual
                if (yellowTurn)
                {
                    Console.WriteLine("\nYellows turn:");
                    player = 'Y';
                    yellowTurn = false;
                }
                else
                {
                    Console.WriteLine("\nReds turn:");
                    player = 'R';
                    yellowTurn = true;
                }

                // Validate the user input column number.
                colInput = Console.ReadLine();
                //this.CheckEscKey();
                if (!Int32.TryParse(colInput, out int colNumber) || colNumber > this._columns)
                {
                    Console.WriteLine("\nPlease enter valid input");

                    // negate the turn to continue same player.
                    yellowTurn = !yellowTurn;
                    continue;
                }

                // Check if we can drop the checker in given column
                colNumber--;
                if (!this._connectFour.CanDrop(colNumber))
                {
                    Console.WriteLine("\nColumn is already full. Chose a different column");

                    // negate the turn to continue same player.
                    yellowTurn = !yellowTurn;
                    continue;
                }

                // drop the checkers and display the borad
                this._connectFour.Drop(player, colNumber);
                this.DisplayBorad();

                // check for the winning
                if (this._connectFour.CheckWin(player))
                {
                    Console.WriteLine($"\nPlayer {player} has won! Please start a new game.");
                    return;
                }

                // if not won, check if the obard is full
                if (this._connectFour.IsBoardFull())
                {
                    Console.WriteLine("\nIt is a Draw. Please start a new game");
                    return;
                }

            } while (true);
        }

        /// <summary>
        /// Displays the board
        /// </summary>
        private void DisplayBorad()
        {
            Console.WriteLine();
            var board = this._connectFour.GetTheCurrentBoard();
            //for (int row = this._rowCount - 1; row >= 0; row--)
            //{
            //    for (int column = 0; column < this._columnCount; column++)
            //    {
            //        Console.Write(board[row, column] + "  ");
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            for (int row = 0; row < this._rows; row++)
            {
                for (int column = 0; column < this._columns; column++)
                {
                    Console.Write(board[row, column] + "  ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private void CheckEscKey()
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

    }
}
