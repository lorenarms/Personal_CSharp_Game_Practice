using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Game01
{
    class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
                    Write(element);

                }
            }
        }

        public bool IsPositionWalkable(int x, int y)
        {
            //check bounds first
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }

            //Check if the grid is a walkable tile
            
            return Grid[y, x] == " " || Grid[y, x] == "X";
        }
            
    }
}
