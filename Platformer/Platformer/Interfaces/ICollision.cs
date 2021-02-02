using Microsoft.Xna.Framework;

namespace Platformer.Interfaces
{
    public interface ICollision
    {
        public Rectangle CollisionRectangle { get; set; }
    }

    public interface ICollisionMoving : ICollision
    {
        public Rectangle FutureCollisionRectangle { get; set; }
        public bool IsOnGround { get; set; }
        public Vector2 Gravity { get; set; }
    }
}
