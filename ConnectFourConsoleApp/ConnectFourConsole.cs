using ConnectFourService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourConsoleApp
{
    public class ConnectFourConsole
    {
        private ConnectFour _connectFour;
        private int _rows;
        private int _columns;


        public void StartGame()
        {
            this.DisplayWelcomeInfo();
            this.ReadGameInputs();
            this.InitializeGame();
            this.Run();

            Console.ReadLine();
        }

        private void DisplayWelcomeInfo()
        {
            Console.WriteLine("Welcome to Connect Four. Please read the instructions below, before you start.");
            Console.WriteLine("1. Payed with two people");
            Console.WriteLine("2. Player 1 Yellow indicated with 'Y' on the board");
            Console.WriteLine("3. Player 2 Red indicated with 'R'");
            Console.WriteLine("-------------------------------GAME STARTS NOW--------------------------------");
        }

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

        private void InitializeGame()
        {
            this._connectFour = new ConnectFour(this._rows, this._columns);

            Console.WriteLine("The boad has initialized");
            this.DisplayBorad();

            Console.WriteLine();
        }

        private void Run()
        {
            bool yellowTurn = true;
            char player;
            string colInput;

            do
            {
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

                // if the we can drop in given column
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
