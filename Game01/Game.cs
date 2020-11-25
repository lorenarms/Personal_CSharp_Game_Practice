using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;                                //remove need to type Console before everythingaaaaa

namespace Game01
{
    class Game


    {
        private World MyWorld;
        private Player CurrentPlayer;
        
        
        public void Start()
        {
            Title = "Welcome to the Maze";
            CursorVisible = false;

            string[,] grid = LevelParser.ParseFileToArray("Level1.txt");
            
            MyWorld = new World(grid);
            CurrentPlayer = new Player(1, 2);
            RunGameLoop();

        }
        private void DisplayIntro()
        {
            WriteLine("Welcome to the Maze");
            WriteLine("\nInstructions");
            WriteLine("> Use the arrow keys to move");
            Write("> Try to reach the goal, which looks like this: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            ResetColor();
            WriteLine("> Press any key to start");
            ReadKey(true);
        }
        private void DisplayOutro()
        {
            Clear();
            WriteLine("You escaped!");
            WriteLine("Thanks for playing");
            WriteLine("Press any key to exit...");
            ReadKey(true);
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
                    if(MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
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
                default:
                    break;
            }
        }

        private void RunGameLoop()
        {
            DisplayIntro();
            Clear();
            MyWorld.Draw();
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


                // Give the console a chance to render
                //System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();


        }

    }
}
