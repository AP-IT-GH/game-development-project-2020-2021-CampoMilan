using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Interfaces
{
    public interface ICollision
    {
        public Rectangle CollisionRectangle { get; set; }
    }

    public interface ICollisionMoving : ICollision
    {
        public Rectangle FutureCollisionRectangle { get; set; }
    }
}
