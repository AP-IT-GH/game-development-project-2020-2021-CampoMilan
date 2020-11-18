using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.World
{
    public class BackgroundBlok
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }

        public BackgroundBlok(Texture2D _texture, Vector2 _position)
        {
            Texture = _texture;
            Position = _position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
