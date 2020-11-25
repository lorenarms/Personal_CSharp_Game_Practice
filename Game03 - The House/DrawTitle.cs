using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Game03___The_Maze
{
    class DrawTitle
    {
        public static void DrawNewTitle(int row, string title)
        {
            int width = Console.WindowWidth;
            int sWidth = title.Length;
            int center = width - sWidth;
            center = center / 2;
            SetCursorPosition(center, row);
            WriteLine(title);
        }

        public static void DrawMainTitle(int row, string[] title)
        {
            
            for (int i = 0; i < title.GetLength(0); i++)
            {
                int column = (Game.width - title[i].Length) / 2;
                SetCursorPosition(column, row);
                WriteLine(title[i]);
                row++;
            }
            
            
        }

        

    }
    class MainTitle
    {
        public static string[] mainTitle { get; set;}
        public MainTitle()
        {
            mainTitle = new string[7];
            mainTitle[0] = @"  _________  ___  ___  _______           _____ ______   ________  ________  _______      ";
            mainTitle[1] = @"|\___   ___\\  \|\  \|\  ___ \         |\   _ \  _   \|\   __  \|\_____  \|\  ___ \      ";
            mainTitle[2] = @"\|___ \  \_\ \  \\\  \ \   __/|        \ \  \\\__\ \  \ \  \|\  \\|___/  /\ \   __/|     ";
            mainTitle[3] = @"     \ \  \ \ \   __  \ \  \_|/__       \ \  \\|__| \  \ \   __  \   /  / /\ \  \_|/__   ";
            mainTitle[4] = @"      \ \  \ \ \  \ \  \ \  \_|\ \       \ \  \    \ \  \ \  \ \  \ /  /_/__\ \  \_|\ \  ";
            mainTitle[5] = @"       \ \__\ \ \__\ \__\ \_______\       \ \__\    \ \__\ \__\ \__\\________\ \_______\ ";
            mainTitle[6] = @"        \|__|  \|__|\|__|\|_______|        \|__|     \|__|\|__|\|__|\|_______|\|_______| ";

        }
    }
    
}
