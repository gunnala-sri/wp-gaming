/*
 * FileName: ConnectFour.cs
 * Created:  09/09/2019
 * Author: Sri Gunnala
 * Description: ConnectFour algorithm
 * 
 * UpdatedBy        Date        Comments
 * --               --          --
*/
using System;
using System.Linq;

namespace ConnectFourService
{
    /// <summary>
    /// Class to handle ConnectFour game algorithm
    /// </summary>
    public class ConnectFour
    {
        /// <summary>
        /// Board to hold checkers
        /// </summary>
        private char[,] _board;

        /// <summary>
        /// Number of rows of board
        /// </summary>
        private int _rowCount;

        /// <summary>
        /// Number of Columns of board
        /// </summary>
        private int _columnCount;

        /// <summary>
        /// Array to represent column fill status.
        /// </summary>
        private bool[] _columnFillStatus;

        /// <summary>
        /// Default character on board coordinates when it initialized.
        /// </summary>
        private const char BoardDefalutValue = '0';

        /// <summary>
        /// Instantiates new ConnectFour object with number of rows and columns.
        /// </summary>
        /// <param name="rows">number of rows of the board</param>
        /// <param name="columns">number of columns of the board</param>
        public ConnectFour(int rows, int columns)
        {
            // check for valid rows and columns
            if (rows < 4 || columns < 4)
                throw new ArgumentException("Invalid rows or columns");

            this._rowCount = rows;
            this._columnCount = columns;

            // Initialize the board
            this.Initialize();
        }

        /// <summary>
        /// Gets the board values with current status.
        /// </summary>
        /// <returns>Board values</returns>
        public char[,] GetTheCurrentBoard()
        {
            return this._board;
        }

        /// <summary>
        /// Checks Horizontally, Vertically or Diagonally for win
        /// </summary>
        /// <param name="player">current player who just dropped checker</param>
        /// <returns>true if won, else false</returns>
        public bool CheckWin(char player)
        {
            for (int row = 0; row < this._rowCount; row++)
            {
                for (int column = 0; column < this._columnCount; column++)
                {
                    // if this is empty spot no check needed.
                    if (this._board[row, column] == BoardDefalutValue)
                        continue;

                    if (CheckHorizonalMatch(row, column, player) ||
                        CheckVerticalMatch(row, column, player) ||
                        CheckTopLeftToBottomRightDiagonalMatch(row, column, player) ||
                        CheckTopRightToBottomLeftDiagonalMatch(row, column, player))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if board is full
        /// </summary>
        /// <returns>True if board is full, else false</returns>
        public bool IsBoardFull()
        {
            return !this._columnFillStatus.Any(t => !t);
        }

        /// <summary>
        /// Check if a checker can be dropped in given columns
        /// </summary>
        /// <param name="column">Column number where checker needs to be dropped</param>
        /// <returns></returns>
        public bool CanDrop(int column)
        {
            return this._board[this._rowCount - 1, column] == BoardDefalutValue;
        }

        /// <summary>
        /// Drops the checker in given column
        /// </summary>
        /// <param name="player">Player who is having a turn now</param>
        /// <param name="column">Column where checker should be dropped</param>
        /// <returns></returns>
        public bool Drop(char player, int column)
        {
            for (int row = 0; row < this._rowCount; row++)
            {
                if (this._board[row, column] == BoardDefalutValue)
                {
                    this._board[row, column] = player;

                    // set the flag if column is full
                    if (row == this._rowCount - 1)
                        this._columnFillStatus[column] = true;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Initialize the ConnectFour
        /// </summary>
        private void Initialize()
        {
            // Initialize the board.
            this.InitializeBoard();

            // Initialize the column fill status.
            this.InitializeColumnFillStatus();
        }

        /// <summary>
        /// Initializes the board with default value '0'
        /// </summary>
        private void InitializeBoard()
        {
            this._board = new char[this._rowCount, this._columnCount];

            for (int row = 0; row < this._rowCount; row++)
            {
                for (int column = 0; column < this._columnCount; column++)
                {
                    this._board[row, column] = BoardDefalutValue;
                }
            }
        }

        /// <summary>
        /// Initializes the column fill status to not filled.
        /// </summary>
        private void InitializeColumnFillStatus()
        {
            this._columnFillStatus = new bool[this._columnCount];
            for (int i = 0; i < this._columnCount; i++)
            {
                this._columnFillStatus[i] = false;
            }
        }

        /// <summary>
        /// Checks to see if there is match horizontally
        /// </summary>
        /// <param name="player">Player who just had a turn</param>
        /// <returns>True if won, else false</returns>
        private bool CheckHorizonalMatch(int row, int column, char player)
        {
            // skip last three columns
            if (column > this._columnCount - 4)
                return false;

            if (this._board[row, column] == player && this._board[row, column + 1] == player
                && this._board[row, column + 2] == player && this._board[row, column + 3] == player)
                return true;

            return false;
        }

        /// <summary>
        /// Checks to see if there is match vertically
        /// </summary>
        /// <param name="player">Player who just had a turn</param>
        /// <returns>True if won, else false</returns>
        private bool CheckVerticalMatch(int row, int column, char player)
        {
            // skip last three rows
            if (row > this._rowCount - 4)
                return false;

            if (this._board[row, column] == player && this._board[row + 1, column] == player
                && this._board[row + 2, column] == player && this._board[row + 3, column] == player)
                return true;

            return false;
        }

        /// <summary>
        /// Checks to see if there is match diagonally in the direction of top right to bottom left
        /// </summary>
        /// <param name="player">Player who just had a turn</param>
        /// <returns>True if won, else false</returns>
        private bool CheckTopRightToBottomLeftDiagonalMatch(int row, int column, char player)
        {
            //skip col0, col1, col2 and last three rows
            if (column < 3 || row > this._rowCount - 4)
                return false;

            if (this._board[row, column] == player && this._board[row + 1, column - 1] == player
                && this._board[row + 2, column - 2] == player && this._board[row + 3, column - 3] == player)
                return true;

            return false;
        }

        /// <summary>
        /// Checks to see if there is match diagonally in the direction of top left to bottom right
        /// </summary>
        /// <param name="player">Player who just had a turn</param>
        /// <returns>True if won, else false</returns>
        private bool CheckTopLeftToBottomRightDiagonalMatch(int row, int column, char player)
        {
            // skip last three rows and last three columns
            if (row > this._rowCount - 4 || column > this._columnCount - 4)
                return false;

            if (this._board[row, column] == player && this._board[row + 1, column + 1] == player
                && this._board[row + 2, column + 2] == player && this._board[row + 3, column + 3] == player)
                return true;

            return false;
        }

    }
}
