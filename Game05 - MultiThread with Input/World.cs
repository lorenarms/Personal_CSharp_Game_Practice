using System;
using System.Collections.Generic;
using System.Text;

namespace Game05___MultiThread_with_Input
{
    class World
    {
        public bool IsPositionWalkable(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return false;
            }
            else
                return true;
        }

    }
}
