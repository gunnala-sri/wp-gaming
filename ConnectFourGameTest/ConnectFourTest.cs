using ConnectFourService;
using System;
using Xunit;

namespace ConnectFourGameTest
{
    public class ConnectFourTest
    {
        [Theory]
        [InlineData(4, 5)]
        [InlineData(10, 15)]
        [InlineData(6, 6)]
        public void Horizontal_Yellow_WinCheck(int rows, int columns)
        {
            ConnectFour connectFour = new ConnectFour(rows, columns);

            for (int i = 0; i < 4; i++)
                connectFour.Drop('y', i);

            var result = connectFour.CheckWin('y');

            Assert.True(result);
        }

        [Theory]
        [InlineData(4, 5)]
        [InlineData(10, 15)]
        [InlineData(6, 6)]
        public void Vertical_Red_windCheck(int rows, int columns)
        {
            ConnectFour connectFour = new ConnectFour(rows, columns);

            for (int i = 0; i < 4; i++)
                connectFour.Drop('r', 0);

            var result = connectFour.CheckWin('r');

            Assert.True(result);

        }

        [Theory]
        [InlineData(4, 5)]
        [InlineData(10, 15)]
        [InlineData(6, 6)]
        public void Diagonal_Yellow_Wins(int rows, int columns)
        {
            ConnectFour connectFour =
                DataGenerator.Get_CF_TopLeftToBottomRight_Diagonal_Yellow_Win_Check(rows, columns);

            var result = connectFour.CheckWin('y');

            Assert.True(result);
        }

        [Fact]
        public void Game_Draw_6Rows_6Columns()
        {
            ConnectFour connectFour =
                DataGenerator.Get_CF_Game_Draw_6Rows_6Columns();

            var resultY = connectFour.CheckWin('y');
            var resultR = connectFour.CheckWin('r');
            var boardfull = connectFour.IsBoardFull();

            Assert.True(!resultY && !resultR && boardfull);
        }

        [Theory]
        [InlineData(4, 3)]
        [InlineData(3, 4)]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        public void Invalid_Argument_Exception(int rows, int columns)
        {
            Assert.Throws<ArgumentException>(() => new ConnectFour(rows, columns));
        }

        [Theory]
        [InlineData(4, 5)]
        [InlineData(10, 15)]
        [InlineData(6, 6)]
        public void Invalid_Move_Test(int rows, int columns)
        {
            ConnectFour connectFour = new ConnectFour(rows, columns);

            bool invalidMove = false;

            for (int i = 0; i < rows; i++)
            {
                connectFour.Drop('y', 0);
                connectFour.Drop('r', 0);
            }

            invalidMove = connectFour.Drop('y', 0);
            Assert.False(invalidMove);
        }
    }
}
