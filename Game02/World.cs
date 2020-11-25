using System;
using System.Collections.Generic;
using System.Text;

namespace Game02
{
    class World
    {
        public bool IsPositionWalkable(int x, int y)
        {
            if(x < 0 || y < 0)
            {
                return false;
            }
            else
                return true;
        }

    }
}
