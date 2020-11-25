using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;


namespace Game05___MultiThread_with_Input
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

            Thread t1 = new Thread(RunGameLoop);
            Thread t2 = new Thread(Enemy);
            t1.Start();
            t2.Start();

            //RunGameLoop();
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
                    if (myWorld.IsPositionWalkable(currentPlayer.X, currentPlayer.Y - 1))
                    {
                        currentPlayer.DrawBlank();
                        currentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (myWorld.IsPositionWalkable(currentPlayer.X, currentPlayer.Y + 1))
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
                case ConsoleKey.Enter:
                    {
                        Environment.Exit(0);
                        break;
                    }
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

        private void Enemy()
        {
            int D = 10;
            int C = 10;
            
            SetCursorPosition(C, D);
            while (true)
            {
                
                
                var rand = new Random();
                int A = rand.Next(0, 2);
                int B = rand.Next(0, 2);

                
                if (currentPlayer.X < C)
                {
                    A = A * -1;
                }
                if (currentPlayer.Y < D)
                {
                    B = B * -1;
                }

                C = C + A;
                D = D + B;

                if (C < 0)
                {
                    C = 0;
                }
                if (D < 0)
                {
                    D = 0;
                }

                SetCursorPosition(C, D);
                ForegroundColor = ConsoleColor.Cyan;
                Write("0");
                if (C == currentPlayer.X && D == currentPlayer.Y)
                {
                    ResetColor();
                    Console.WriteLine("You have died!");
                    break;
                }


                ResetColor();
                Thread.Sleep(500);
                SetCursorPosition(C, D);
                Write(" ");

            }
            Environment.Exit(0);
        }

    }
}
