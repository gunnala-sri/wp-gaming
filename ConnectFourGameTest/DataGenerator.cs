/*
 * FileName: DataGenerator.cs
 * Created:  09/09/2019
 * Author: Sri Gunnala
 * Description: Generates mock data needed for connect four service test
 * 
 * UpdatedBy        Date        Comments
 * --               --          --
*/
using ConnectFourService;

namespace ConnectFourGameTest
{
    public static class DataGenerator
    {
        public static ConnectFour Get_CF_TopLeftToBottomRight_Diagonal_Yellow_Win_Check(int rows, int columns)
        {
            ConnectFour connectFour = new ConnectFour(rows, columns);

            // Column 0
            connectFour.Drop('y', 0);

            // Column 1
            connectFour.Drop('r', 1);
            connectFour.Drop('y', 1);

            // Column 2
            connectFour.Drop('r', 2);
            connectFour.Drop('y', 2);
            connectFour.Drop('y', 2);

            // Column 3
            connectFour.Drop('r', 3);
            connectFour.Drop('y', 3);
            connectFour.Drop('r', 3);
            connectFour.Drop('y', 3);

            return connectFour;
        }

        public static ConnectFour Get_CF_Game_Draw_6Rows_6Columns()
        {
            ConnectFour connectFour = new ConnectFour(6,6);

            // Column 0
            connectFour.Drop('y', 0);
            connectFour.Drop('r', 0);
            connectFour.Drop('y', 0);
            connectFour.Drop('r', 0);
            connectFour.Drop('y', 0);
            connectFour.Drop('r', 0);

            // Column 1
            connectFour.Drop('y', 1);
            connectFour.Drop('r', 1);
            connectFour.Drop('y', 1);
            connectFour.Drop('r', 1);
            connectFour.Drop('y', 1);
            connectFour.Drop('r', 1);

            // Column 2
            connectFour.Drop('r', 2);
            connectFour.Drop('y', 2);
            connectFour.Drop('r', 2);
            connectFour.Drop('y', 2);
            connectFour.Drop('r', 2);
            connectFour.Drop('y', 2);

            // Column 3
            connectFour.Drop('r', 3);
            connectFour.Drop('y', 3);
            connectFour.Drop('r', 3);
            connectFour.Drop('y', 3);
            connectFour.Drop('r', 3);
            connectFour.Drop('y', 3);
            connectFour.Drop('r', 3);
            connectFour.Drop('y', 3);

            // Column 4
            connectFour.Drop('y', 4);
            connectFour.Drop('r', 4);
            connectFour.Drop('y', 4);
            connectFour.Drop('r', 4);
            connectFour.Drop('y', 4);
            connectFour.Drop('r', 4);

            // Column 5
            connectFour.Drop('y', 5);
            connectFour.Drop('r', 5);
            connectFour.Drop('y', 5);
            connectFour.Drop('r', 5);
            connectFour.Drop('y', 5);
            connectFour.Drop('r', 5);

            return connectFour;
        }
    }
}
