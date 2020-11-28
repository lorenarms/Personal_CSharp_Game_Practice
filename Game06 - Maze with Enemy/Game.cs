using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;        //remove need to type Console before everythingaaaaa
using System.Threading;

namespace Game06___Maze_with_Enemy
{
    class Game


    {
        private World MyWorld;
        private Player CurrentPlayer;
        private Enemy enemyOne;
        private bool endOfGame = false;
        
        
        public void Start()
        {
            Title = "Welcome to the Maze";
            CursorVisible = false;

            string[,] grid = LevelParser.ParseFileToArray("Level1.txt");
            
            MyWorld = new World(grid);
            CurrentPlayer = new Player(1, 2);
            enemyOne = new Enemy(10, 10);

            Thread t1 = new Thread(RunGameLoop);
            
            t1.Start();
            

            //RunGameLoop();

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
            Thread t2 = new Thread(Enemy);
            t2.Start();
            while (true)
            {

                // draw everything
                //DrawFrame();
                CurrentPlayer.Draw();

                // Check for player input from the keyboard and move player
                HandlePlayerInput();

                // Check if player has reached the exit and if so, end the game
                string elementAtPlayerPost = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPost == "X")
                {
                    endOfGame = true;
                    break;
                }
                if (CurrentPlayer.X == enemyOne.X && CurrentPlayer.Y == enemyOne.Y)
                {
                    endOfGame = true;
                    break;
                }

            }
            DisplayOutro();


        }
        private void Enemy()
        {
            SetCursorPosition(enemyOne.X, enemyOne.Y);
            while (true)
            {

                var rand = new Random();
                int randX = rand.Next(0, 2);
                int randY = rand.Next(0, 2);
                int initialEnemyX = enemyOne.X;
                int initialEnemyY = enemyOne.Y;

                if(CurrentPlayer.X <= enemyOne.X)
                {
                    randX *= -1;
                }
                if(CurrentPlayer.Y <= enemyOne.Y)
                {
                    randY *= -1;
                }

                if(MyWorld.IsPositionWalkable(enemyOne.X + randX, enemyOne.Y + randY))
                {
                    enemyOne.X += randX;
                    enemyOne.Y += randY;
                    enemyOne.DrawEnemy();
                }
                else if (endOfGame)
                {
                    break;
                }
                else
                {
                    enemyOne.X = initialEnemyX;
                    enemyOne.Y = initialEnemyY;
                    enemyOne.DrawEnemy();
                }

            }
            //Environment.Exit(0);
        }

        public bool GameOver(bool endOfGame)
        {
            if (endOfGame == true)
            {
                return true;
            }

            return false;
            
        }

    }
}
