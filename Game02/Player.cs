using System;
using System.Collections.Generic;
using System.Text;

namespace Game02
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }

        private string PlayerMarker;
        private ConsoleColor PlayerColor;

        public Player (int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "0";
            PlayerColor = ConsoleColor.Red;
        }
        public void Draw()
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(PlayerMarker);
            Console.ResetColor();
        }
        public void DrawBlank()
        {
            //Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
            //Console.ResetColor();
        }

    }
}
