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
        List<ICollision> finishBlocks;

        public CollisionManager(Blok[,] blokTileArray, FinishLine[,] finishLines)
        {
            staticObjects = new List<ICollision>();
            finishBlocks = new List<ICollision>();

            foreach (var item in blokTileArray)
            {
                staticObjects.Add(item);
            }
            foreach (var item in finishLines)
            {
                finishBlocks.Add(item);
            }
        }
        public Vector2 CheckCollision(ICollisionMoving movingObject, Vector2 direction)
        {
            foreach (var finish in finishBlocks)
            {
                if (finish != null)
                {
                    if (movingObject.FutureCollisionRectangle.Intersects(finish.CollisionRectangle))
                    {
                        Globals.currentLevelCounter += 1;
                        if (Globals.currentLevelCounter > 1)
                        {
                            Globals.currentLevelCounter = 1;
                        }
                        return Vector2.Zero;
                    }
                }
            }
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
