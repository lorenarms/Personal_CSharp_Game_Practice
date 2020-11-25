using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Game03___The_Maze
{
    class Game
    {
        private MainTitle mainTitle;
        public static int width = 120;
        private World MyWorld;
        private Player CurrentPlayer;
        private static int lvl;
        private static string levelMap;
        public static int coinCount;

        public void Start()
        {
            Title = "The Maze";
            CursorVisible = false;
            SetWindowSize(120, 30);
            mainTitle = new MainTitle();
            DrawTitle.DrawMainTitle(0, MainTitle.mainTitle);

            DrawTitle.DrawNewTitle(CursorTop + 1, "Press any key to start...");

            ReadKey(true);
            Clear();
            MainMenu();
            WriteLine("Press any key to continue...");
            ReadKey(true);
        }
        private void MainMenu()
        {
            bool inMenu = true;
            do
            {
                
                string prompt = "MAIN MENU: please make a selection using the arrow keys";
                string[] options = { "Continue Game", "New Game", "High Score" ,
                    "About", "Exit app" };
                options = Menu.BuildMenu(options);
                int startPosition = 2;
                Menu mainMenu = new Menu(prompt, options, startPosition);
                int selection = mainMenu.RunMenu();

                switch (selection)
                {
                    case 0:
                        {
                            Clear();
                            string[,] grid = LevelParser.ParseFileToArray(levelMap);
                            MyWorld = new World(grid);
                            RunGameLoop();

                            break;
                        }
                    case 1:
                        {
                            lvl = 1;
                            levelMap = "Level1.txt";
                            string[,] grid = LevelParser.ParseFileToArray(levelMap);
                            MyWorld = new World(grid);
                            RunGameLoop();
                            lvl = 2;
                            levelMap = "Level2.txt";
                            grid = LevelParser.ParseFileToArray(levelMap);
                            MyWorld = new World(grid);
                            RunGameLoop();
                            break;
                        }
                    case 2:
                        {

                            break;
                        }
                    case 3:
                        {
                            Clear();
                            DrawTitle.DrawMainTitle(3, MainTitle.mainTitle);
                            string[] title = { "The Maze", "Created by Lawrence Artl III", "Copyright 2020", "Special thanks to Michael Hadley ",
                            "Press any key to continue..."};
                            for (int i = 0; i < title.Length; i++)
                            {
                                DrawTitle.DrawNewTitle(CursorTop + 1, title[i]);
                            }
                            ReadKey(true);
                            Clear();
                            //MainMenu();
                            break;

                        }

                    case 4:
                        {

                            string eForExit = "Press 'e' to exit the program. Press any other key to cancel.";
                            DrawTitle.DrawNewTitle(CursorTop + 1, eForExit);
                            ConsoleKeyInfo keyInfo = ReadKey(true);
                            if (keyInfo.Key == ConsoleKey.E)
                            {
                                Environment.Exit(0);
                                break;
                            }
                            else
                                Clear();
                            MainMenu();
                            break;
                        }
                    default: { break; }
                }
            } while (inMenu);

        }
        private void DrawFrame()
        {
            //Clear();

            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.DrawBlank();
                        CurrentPlayer.Y -= 1;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.DrawBlank();
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.DrawBlank();
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.DrawBlank();
                        CurrentPlayer.X += 1;
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        MainMenu();
                        break;
                    }
                default:
                    break;
            }
            
            
        }
        private void RunGameLoop()
        {

            Clear();
            MyWorld.Draw();
            CurrentPlayer = new Player(MyWorld.X, MyWorld.Y);
            while (true)
            {

                // draw everything
                DrawFrame();


                // Check for player input from the keyboard and move player
                HandlePlayerInput();

                // Check if player has reached the exit and if so, end the game
                string elementAtPlayerPost = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPost == "X")
                {
                    
                    break;
                }

            }
            
        }
    }

}
