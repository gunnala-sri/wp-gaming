/*
 * FileName: Program.cs
 * Created:  09/09/2019
 * Author: Sri Gunnala
 * Description: Entry class for the console Application
 * 
 * UpdatedBy        Date        Comments
 * --               --          --
*/
namespace ConnectFourConsoleApp
{
    class Program
    {
        /// <summary>
        /// Entry point method
        /// </summary>
        /// <param name="args">Command Arguments</param>
        static void Main(string[] args)
        {
            // Start Connect Four game
            (new ConnectFourConsole())
               .StartGame();
        }
    }
}
