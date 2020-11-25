using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Game03___The_Maze
{
    class Menu
    {
        private string[] Options;
        private int CurrentSelection;
        private string Prompt;
        private int StartPosition;

        public Menu(string prompt, string[] options, int startPosition)
        {
            Prompt = prompt;
            Options = options;
            CurrentSelection = 0;
            StartPosition = startPosition;
        }
        public static string[] BuildMenu(string[] menu)
        {
            for (int i = 0; i < menu.GetLength(0); i++)
            {
                int width = menu[i].Length;
                width = 30 - width;
                width = width / 2;
                string xtra = new string(' ', width);
                menu[i] = xtra + menu[i] + xtra;
                if(menu[i].Length < 30)
                {
                    menu[i] = menu[i] + " ";
                }

            }


            return menu;
        }


        public int RunMenu()
        {
            int consoleCenter = WindowWidth / 2 - Prompt.Length / 2;
            //store the start position of cursor for use later
            int cursorPosition = StartPosition;
            StartPosition++;


            //initial display of menu with prompt
            SetCursorPosition(consoleCenter, cursorPosition);
            WriteLine(Prompt);
            cursorPosition++;
            consoleCenter = (WindowWidth / 2) - 15;
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                SetCursorPosition(consoleCenter, cursorPosition);
                //color white if selected, otherwise color normal
                if (CurrentSelection == i)
                {
                    BackgroundColor = ConsoleColor.White;
                    ForegroundColor = ConsoleColor.Black;
                    WriteLine($"{currentOption}");
                }
                else if (CurrentSelection != i)
                {
                    BackgroundColor = ConsoleColor.Black;
                    ForegroundColor = ConsoleColor.White;
                    WriteLine($"{currentOption}");
                }
                cursorPosition++;
            }
            ResetColor();
            cursorPosition = StartPosition;

            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                //check for key press of arrows
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SetCursorPosition(consoleCenter, cursorPosition);           //set to current selection location
                    ResetColor();
                    //ForegroundColor = ConsoleColor.White;           //reset color
                    //BackgroundColor = ConsoleColor.Black;           //reset color
                    Write($"{Options[CurrentSelection]}");    //rewrite the selection at this spot in normal colors
                    cursorPosition--;                               //set cursor to line above
                    CurrentSelection--;                             //set selection to previous spot in options array

                    //check if the array position even exists
                    if (CurrentSelection == -1)
                    {
                        CurrentSelection = Options.Length - 1;                  //set to last element in options[]
                        cursorPosition = StartPosition + Options.Length - 1;    //set cursor to last line in menu
                    }
                    SetCursorPosition(consoleCenter, cursorPosition);           //set the cursor
                    ForegroundColor = ConsoleColor.Black;           //rewrite option in black
                    BackgroundColor = ConsoleColor.White;           //with white background
                    Write($"{Options[CurrentSelection]}");    //write it

                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {

                    SetCursorPosition(consoleCenter, cursorPosition);
                    ResetColor();
                    //ForegroundColor = ConsoleColor.White;
                    //BackgroundColor = ConsoleColor.Black;
                    Write($"{Options[CurrentSelection]}");
                    cursorPosition++;
                    CurrentSelection++;
                    if (CurrentSelection == Options.Length)
                    {
                        CurrentSelection = 0;
                        cursorPosition = StartPosition;
                    }
                    SetCursorPosition(consoleCenter, cursorPosition);
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                    Write($"{Options[CurrentSelection]}");
                }


            } while (keyPressed != ConsoleKey.Enter);
            ResetColor();
            SetCursorPosition(10, StartPosition + Options.Length);       //reset the cursor position to the bottom of the menu
            return CurrentSelection;

        }
    }
}
