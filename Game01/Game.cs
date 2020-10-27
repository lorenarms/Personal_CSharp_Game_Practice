using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;                                //remove need to type Console before everythingaaaaa

namespace Game01
{
    class Game
    {
        public void Start()
        {
            //Console.WriteLine("The game is starting.");
            /*
            SetCursorPosition(4, 2);
            Write("X");
            */

            string[,] grid =                                //2 dimensional array
            {
                {"=", "=", "=" , "=", "=", "=" , "="},
                {"=", " ", "=" , " ", " ", " " , "X"},
                {"O", " ", "=" , " ", "=", " " , "="},
                {"=", " ", "=" , " ", "=", " " , "="},
                {"=", " ", " " , " ", "=", " " , "="},
                {"=", "=", "=" , "=", "=", "=" , "="},
            };

            World myWorld = new World(grid);
            myWorld.Draw();

            WriteLine(myWorld.IsPositionWalkable(0, 0));    //false
            WriteLine(myWorld.IsPositionWalkable(1, 1));    //true
            WriteLine(myWorld.IsPositionWalkable(6, 1));    //true
            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey(true);
        }

    }
}
