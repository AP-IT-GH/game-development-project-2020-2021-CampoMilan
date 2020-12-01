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
        Rectangle player;
        Rectangle block;
        Vector2 stopDir;
        public CollisionLocation CheckCollision(Rectangle obj1, Rectangle obj2)
        {
            
            //if (obj1.Top <= obj2.Bottom)
            //{
            //    return CollisionLocation.Top;
            //}
            //else if(obj1.Bottom >= obj2.Top)
            //{
            //    return CollisionLocation.Bottom;
            //}
            if (obj1.Left >= obj2.Right)
            {
                obj1.X = Math.Clamp(obj1.Left, obj2.Right+1, 3000);
                return CollisionLocation.Left;
            }
            else if (obj1.Right >= obj2.Left)
            {
                obj1.X = Math.Clamp(obj1.X, 0, obj2.Left-1) - obj1.Width;
                return CollisionLocation.Right;
            }
            else
            {
                return CollisionLocation.None;
            }
            
        }

        public Vector2 CheckCollision(Rectangle obj1, Rectangle obj2, Vector2 direction)
        {
            player = obj1;
            block = obj2;
            stopDir = Vector2.Zero;

            player.X += (int)direction.X * 5; //check future rectangle X coord
            player.Y += (int)direction.Y * 5; //check future rectangle Y coord

            if (player.Intersects(block))
            {
                return stopDir; //direction becomes zero
            }
            return direction;
        }
    }
}
