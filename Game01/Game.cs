using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

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

            string[,] grid =
            {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" },
            };

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    string element = grid[y, x];
                    SetCursorPosition(x, y);
                    Write(element);
                }
            }

            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey(true);
        }

    }
}
