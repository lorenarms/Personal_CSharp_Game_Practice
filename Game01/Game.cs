using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;                                //remove need to type Console before everythingaaaaa

namespace Game01
{
    class Game
    {
        public void Start()
        {
            Console.WriteLine("The game is starting.");
            /*
            SetCursorPosition(4, 2);
            Write("X");
            */

            string[,] grid =                                //2 dimensional array
            {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" },
            };

            int rows = grid.GetLength(0);                   //(0) for rows in 2D array
            int cols = grid.GetLength(1);                   //(1) for columns in 2D array
            for (int y = 0; y < rows; y++)                  //loop to build map
            {
                for (int x = 0; x < cols; x++)
                {
                    string element = grid[y, x];            //columns vs rows
                    SetCursorPosition(x, y);                //rows vs columns
                    Write(element);
                }
            }

            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey(true);
        }

    }
}
