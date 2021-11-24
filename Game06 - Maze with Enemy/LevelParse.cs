using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Game06___Maze_with_Enemy
{
    class LevelParser
    {
        public static string[,] ParseFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            //string firstLine = lines[0];
            int rows = lines.Length;
            int cols = lines[0].Length;
            string[,] grid = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < cols; x++)
                {
                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }
            }

            return grid;


        }
    }
}
