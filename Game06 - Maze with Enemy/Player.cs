using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Game06___Maze_with_Enemy

{
    class Player
    {

        public int X { get; set; }
        public int Y { get; set; }

        private string PlayerMarker;
        private ConsoleColor PlayerColor;
        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "0";
            PlayerColor = ConsoleColor.Red;

        }

        public void Draw()
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(X + 1, Y + 1);
            Console.Write(PlayerMarker);
            Console.ResetColor();
        }
        public void DrawBlank()
        {
            
            Console.SetCursorPosition(X + 1, Y + 1);
            Console.Write(" ");
            
        }
    }
}
