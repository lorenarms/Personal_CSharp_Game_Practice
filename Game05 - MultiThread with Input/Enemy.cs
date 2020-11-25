using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Game05___MultiThread_with_Input
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
            Console.SetCursorPosition(X, Y);
            Console.Write(EnemyMarker);
            
            Console.ResetColor();
            Thread.Sleep(300);
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
