using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.World
{
    class Blok : ICollision
    {
        private Rectangle collisionRect;
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public Blok(Texture2D _texture, Vector2 _position)
        {
            Texture = _texture;
            Position = _position;
            collisionRect = new Rectangle((int)_position.X, (int)_position.Y, 17, 17);
        }

        public void Update()
        {
            collisionRect.X = (int)Position.X;
            collisionRect.Y = (int)Position.Y;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
