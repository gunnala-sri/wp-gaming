using System;
using System.Linq;

namespace ConnectFourService
{
    public class ConnectFour
    {
        private char[,] _board;

        private int _rowCount;
        private int _columnCount;
        private bool[] _columnFillStatus;

        private const char BoardDefalutValue = '0';

        public ConnectFour(int rows, int columns)
        {
            this._rowCount = rows;
            this._columnCount = columns;

            this.Initialize();
        }

        public char[,] GetTheCurrentBoard()
        {
            return this._board;
        }

        public bool CheckWin(char player)
        {
            if (this.CheckHorizonalMatch(player)
                || this.CheckVerticalMatch(player)
                || this.CheckTopLeftToBottomRightDiagonalMatch(player)
                || this.CheckTopRightToBottomLeftDiagonalMatch(player))
            {
                return true;
            }

            else
                return false;
        }

        public bool IsBoardFull()
        {
            return !this._columnFillStatus.Any(t => !t);
        }

        public bool CanDrop(int column)
        {
            return this._board[this._rowCount - 1, column] == BoardDefalutValue;
        }

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

        private void Initialize()
        {
            this.InitializeBoard();
            this.InitializeColumnFillStatus();
        }

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

        private void InitializeColumnFillStatus()
        {
            this._columnFillStatus = new bool[this._columnCount];
            for (int i = 0; i < this._columnCount; i++)
            {
                this._columnFillStatus[i] = false;
            }
        }

        private bool CheckHorizonalMatch(char player)
        {
            for (int row = 0; row < this._rowCount; row++)
            {
                for (int column = 0; column <= this._columnCount - 4; column++)
                {
                    // if this is empty spot no check needed.
                    if (this._board[row, column] == BoardDefalutValue)
                        continue;

                    if (this._board[row, column] == player && this._board[row, column + 1] == player
                        && this._board[row, column + 2] == player && this._board[row, column + 3] == player)
                        return true;
                }
            }
            return false;
        }

        private bool CheckVerticalMatch(char player)
        {
            for (int row = 0; row <= this._rowCount - 4; row++)
            {
                for (int column = 0; column < this._columnCount; column++)
                {
                    // if this is empty spot no check needed.
                    if (this._board[row, column] == BoardDefalutValue)
                        continue;

                    if (this._board[row, column] == player && this._board[row + 1, column] == player
                        && this._board[row + 2, column] == player && this._board[row + 3, column] == player)
                        return true;
                }
            }
            return false;
        }

        private bool CheckTopRightToBottomLeftDiagonalMatch(char player)
        {
            // row <= this._rowCount - 4; Skip botton three rows, it won't have enough elements to match diagonally.
            for (int row = 0; row <= this._rowCount - 4; row++)
            {
                // column >= 3 - skip col0, col1, and col2 as it won't have enough elements to match diagonally.
                for (int column = this._columnCount - 1; column >= 3; column--)
                {
                    // if this is empty spot no check needed.
                    if (this._board[row, column] == BoardDefalutValue)
                        continue;

                    if (this._board[row, column] == player && this._board[row + 1, column - 1] == player
                        && this._board[row + 2, column - 2] == player && this._board[row + 3, column - 3] == player)
                        return true;
                }
            }
            return false;
        }

        private bool CheckTopLeftToBottomRightDiagonalMatch(char player)
        {
            // Skip botton three rows, it won't have enough elements to match diagonally.
            for (int row = 0; row <= this._rowCount - 4; row++)
            {
                // // Skip last three columns, it won't have enough elements to match diagonally.
                for (int column = 0; column <= this._columnCount - 4; column++)
                {
                    // if this is empty spot no check needed.
                    if (this._board[row, column] == BoardDefalutValue)
                        continue;

                    if (this._board[row, column] == player && this._board[row + 1, column + 1] == player
                        && this._board[row + 2, column + 2] == player && this._board[row + 3, column + 3] == player)
                        return true;
                }
            }
            return false;
        }

        //private bool CheckTopLeftToBottomRightDiagonalMatch(char player)
        //{
        //    for (int row = this._rowCount - 1; row > this._rowCount - 4; row--)
        //    {
        //        for (int column = this._columnCount - 1; column > this._columnCount - 4; column--)
        //        {
        //            if (this._board[row, column] == player && this._board[row - 1, column - 1] == player
        //                && this._board[row - 2, column - 2] == player && this._board[row - 3, column - 3] == player)
        //                return true;
        //        }
        //    }
        //    return false;
        //}

    }
}
