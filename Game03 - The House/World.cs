using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Game03___The_Maze
{
    class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;
        public int X = 0;
        public int Y = 0;

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
                    Console.SetCursorPosition(x + 1, y + 1);
                    if (element == "X")
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }
                    else if (element == "Θ")
                    {
                        ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (element == "0")
                    {
                        X = CursorLeft - 1;
                        Y = CursorTop - 1;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }
                    
                    
                    
                    Write(element);

                }
                
            }
        }

        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        public bool IsPositionWalkable(int x, int y)
        {
            //check bounds first
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }
            if (Grid[y,x] == "Θ")
            {
                Game.coinCount++;
            }
            //Check if the grid is a walkable tile


            return Grid[y, x] == " " || Grid[y, x] == "X" || Grid[y, x] == "Θ";
        }
            
    }
}
