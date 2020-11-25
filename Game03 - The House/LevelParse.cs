using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Game03___The_Maze
{
    class LevelParser
    {
        public static string[,] ParseFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows = lines.Length;

            int startDraw = (Game.width - firstLine.Length) / 2;
            string append = new string(' ', startDraw);
            
            
            int cols = firstLine.Length + startDraw;
            string[,] grid = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                string line = append + lines[y];
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
