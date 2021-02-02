﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
