using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.GamestateManagement
{
    class ScreenText : Component
    {
        private SpriteFont _font;

        public Color PenColour;
        public Vector2 Position { get; set; }
        public string Text { get; set; }

        public ScreenText(string text,SpriteFont font, Vector2 position)
        {
            Text = text;
            _font = font;
            Position = position;

            PenColour = Color.White;
        }


        public override void Draw()
        {
            Globals.spriteBatch.DrawString(_font, Text, Position, PenColour);
        }

        public override void Update()
        {
            // do nothing
        }
    }
}
