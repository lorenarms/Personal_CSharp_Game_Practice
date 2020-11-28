using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Game06___Maze_with_Enemy
{
    class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }

        private string EnemyMarker;
        private ConsoleColor EnemyColor;

        public Enemy (int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            EnemyMarker = "0";
            EnemyColor = ConsoleColor.Cyan;

        }
        public void DrawEnemy()
        {
            Console.ForegroundColor = EnemyColor;
            Console.SetCursorPosition(X + 1, Y + 1);
            Console.Write(EnemyMarker);
            
            Console.ResetColor();
            Thread.Sleep(300);
            Console.SetCursorPosition(X + 1, Y + 1);
            Console.Write(" ");
        }
    }
}
