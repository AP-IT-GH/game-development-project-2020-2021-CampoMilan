using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Collision
{
    class CollisionManager
    {
        public bool CheckCollision(Rectangle obj1, Rectangle obj2)
        {
            if (obj1.Intersects(obj2))
            {
                return true;
            }

            return false;
        }
    }
}
