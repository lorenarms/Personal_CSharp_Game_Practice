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
        private Enemy enemyOne;

        public void Start()
        {
            Console.WriteLine("The game is starting");
            Console.CursorVisible = false;
            currentPlayer = new Player(2, 2);
            myWorld = new World();

            enemyOne = new Enemy(10, 10);

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
            
            
            SetCursorPosition(enemyOne.X, enemyOne.Y);
            while (true)
            {
                
                
                var rand = new Random();
                int A = rand.Next(0, 2);
                int B = rand.Next(0, 2);

                
                if (currentPlayer.X < enemyOne.X)
                {
                    A = A * -1;
                }
                if (currentPlayer.Y < enemyOne.Y)
                {
                    B = B * -1;
                }

                enemyOne.X = enemyOne.X + A;
                enemyOne.Y = enemyOne.Y + B;

                if (enemyOne.X < 0)
                {
                    enemyOne.X = 0;
                }
                if (enemyOne.Y < 0)
                {
                    enemyOne.Y = 0;
                }

                enemyOne.DrawEnemy();
                //SetCursorPosition(enemyOne.X, enemyOne.Y);
                //ForegroundColor = ConsoleColor.Cyan;
                //Write("0");
                if (enemyOne.X == currentPlayer.X && enemyOne.Y == currentPlayer.Y)
                {
                    ResetColor();
                    Console.WriteLine("You have died!");
                    break;
                }


                //ResetColor();
                //Thread.Sleep(500);
                //SetCursorPosition(enemyOne.X, enemyOne.Y);
                //Write(" ");

            }
            Environment.Exit(0);
        }

    }
}
