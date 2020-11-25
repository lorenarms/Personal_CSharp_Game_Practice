using System;
using System.Collections.Generic;
using System.Text;

namespace Game02
{
    class Game
    {
        private World myWorld;
        private Player currentPlayer;

        public void Start()
        {
            Console.WriteLine("The game is starting");
            Console.CursorVisible = false;
            currentPlayer = new Player(2, 2);
            myWorld = new World();
            RunGameLoop();
        }

        private void DrawFrame()
        {
            //Console.Clear();
            currentPlayer.Draw();
            
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if(myWorld.IsPositionWalkable(currentPlayer.X, currentPlayer.Y - 1))
                    {
                        currentPlayer.DrawBlank();
                        currentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(myWorld.IsPositionWalkable(currentPlayer.X, currentPlayer.Y + 1))
                    {
                        currentPlayer.DrawBlank();
                        currentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (myWorld.IsPositionWalkable(currentPlayer.X - 1, currentPlayer.Y))
                    {
                        currentPlayer.DrawBlank();
                        currentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (myWorld.IsPositionWalkable(currentPlayer.X + 1, currentPlayer.Y))
                    {

                        currentPlayer.DrawBlank();
                        currentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        private void RunGameLoop()
        {
            while (true)
            {
                DrawFrame();
                //Console.Write(currentPlayer.X + " " + currentPlayer.Y);
                HandlePlayerInput();

            }
        }
       
    }
}
