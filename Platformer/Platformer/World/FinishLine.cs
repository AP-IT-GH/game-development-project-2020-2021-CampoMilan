using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Interfaces;

namespace Platformer.World
{
    public class FinishLine : ICollision
    {
        private Rectangle collisionRect;
        public int Width { get; set; } = 17;
        public int Height { get; set; } = 17;
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get => collisionRect; set => collisionRect = value; }

        public FinishLine(Texture2D _texture, Vector2 _position)
        {
            Texture = _texture;
            Position = _position;
            collisionRect = new Rectangle((int)_position.X, (int)_position.Y, Width, Height);
        }

        public void Update()
        {
            collisionRect.X = (int)Position.X;
            collisionRect.Y = (int)Position.Y;

        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
