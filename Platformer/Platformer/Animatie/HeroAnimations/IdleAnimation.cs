using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Animatie.HeroAnimations
{
    class IdleAnimation : IEntityAnimation
    {
        private Animation _animation;
        Texture2D texture;
        ITransform transform;

        public IdleAnimation(Texture2D texture, ITransform transform)
        {
            this.transform = transform;
            this.texture = texture;
            _animation = new Animation();
            _animation.AddFrame(new AnimationFrame(new Rectangle(19, 654, 50, 76)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(99, 654, 50, 76)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(179, 654, 50, 76)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(259, 654, 50, 76)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(339, 654, 50, 76)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(419, 654, 50, 76)));
            _animation.Fps = 10;
        }

        public Animation Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, transform.Position, _animation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }
    }
}
