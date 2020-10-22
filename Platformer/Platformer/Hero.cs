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

        private Vector2 position;
        private Vector2 speed;
        private Vector2 velocity;


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

            position = new Vector2(10, 10);
            speed = new Vector2(1, 1);
            velocity = new Vector2(0.1f, 0.1f);
        }

        private void Move()
        {
            position += speed;
            speed += velocity;
            speed = Limit(speed,5); //limits the vector length of speed to 5
            
            //invert the movement when boundaries are hit
            if (position.X > 600 || position.X < 0)
            {
                speed.X *= -1;
                velocity.X *= -1;
            }
            if (position.Y > 400 || position.Y < 0)
            {
                speed.Y *= -1;
                velocity.Y *= -1;
            }
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, position, animation.CurrentFrame.SourceRectangle, Color.CornflowerBlue);

        }
    }
}
