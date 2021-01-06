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
                        if (movingObject.FutureCollisionRectangle.Bottom >= staticObject.CollisionRectangle.Y)
                        {
                            movingObject.IsOnGround = true;

                            if (movingObject.FutureCollisionRectangle.Left < staticObject.CollisionRectangle.Right)
                            {
                                direction.X = 0;
                                return direction;
                            }
                            if (movingObject.FutureCollisionRectangle.Right > staticObject.CollisionRectangle.Left)
                            {
                                direction.X = 0;
                                return direction;
                            }
                        }
                        return Vector2.Zero;
                    }
                    
                }
                
            }
            Debug.WriteLine("Direction value: " + direction);
            movingObject.IsOnGround = false;
            return direction;
        }
    }
}
