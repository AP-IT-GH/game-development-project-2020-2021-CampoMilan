using Microsoft.Xna.Framework;
using Platformer.Interfaces;
using Platformer.World;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        List<ICollision> staticObjects;

        public CollisionManager(Blok[,] blokTileArray)
        {
            staticObjects = new List<ICollision>();

            foreach (var item in blokTileArray)
            {
                staticObjects.Add(item);
            }
        }
        public Vector2 CheckCollision(ICollisionMoving movingObject, Vector2 direction)
        {
            foreach (var staticObject in staticObjects)
            {
                if (staticObject != null)
                {
                    if (movingObject.FutureCollisionRectangle.Intersects(staticObject.CollisionRectangle))
                    {
                        Debug.WriteLine("Collision");
                        Debug.WriteLine("blokje" + staticObject.CollisionRectangle.Location);
                        Debug.WriteLine(staticObject);
                        return Vector2.Zero; //direction becomes zero
                    }
                }
                
            }
            return direction;
        }
    }
}
