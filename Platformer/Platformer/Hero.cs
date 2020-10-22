using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Interfaces;
using Platformer.Animatie;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer
{
    class Hero : IGameObject
    {
        Texture2D heroTexture;

        Animation animation;
        

        public Hero(Texture2D texture)
        {
            heroTexture = texture;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(23, 0, 40, 85)));
            animation.AddFrame(new AnimationFrame(new Rectangle(103, 0, 40, 85)));
            animation.AddFrame(new AnimationFrame(new Rectangle(183, 0, 40, 85)));
            animation.AddFrame(new AnimationFrame(new Rectangle(263, 0, 40, 85)));
            animation.AddFrame(new AnimationFrame(new Rectangle(343, 0, 40, 85)));
            animation.AddFrame(new AnimationFrame(new Rectangle(423, 0, 40, 85)));
            animation.AddFrame(new AnimationFrame(new Rectangle(503, 0, 40, 85)));
            animation.AddFrame(new AnimationFrame(new Rectangle(583, 0, 40, 85)));
            animation.AddFrame(new AnimationFrame(new Rectangle(663, 0, 40, 85)));
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, new Vector2(10, 10), animation.CurrentFrame.SourceRectangle, Color.CornflowerBlue);

        }
    }
}
