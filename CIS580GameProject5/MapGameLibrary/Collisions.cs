using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGameLibrary
{
    public class Collisions
    {
        public static bool pointInRectangle(int x, int y, int left, int right, int top, int bottom)
        {
            if (x < left || x > right)
                return false;
            if (y < top || y > bottom)
                return false;
            return true;
        }

    }
}
