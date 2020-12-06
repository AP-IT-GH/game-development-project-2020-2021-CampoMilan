using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Collision
{
    public enum CollisionLocation
    {
        None,
        Top,
        Bottom,
        Left,
        Right
    }
    public class CollisionManager
    {
        Rectangle staticObject;
        
        public Vector2 CheckCollision(Rectangle movingObject, Vector2 direction)
        {
            movingObject.X += (int)direction.X * 5; //check future rectangle X coord
            movingObject.Y += (int)direction.Y * 5; //check future rectangle Y coord

            if (movingObject.Intersects(staticObject))
            {
                return Vector2.Zero; //direction becomes zero
            }
            return direction;
        }
    }
}
