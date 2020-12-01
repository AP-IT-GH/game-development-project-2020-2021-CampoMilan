using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Animatie.HeroAnimations
{
    class WalkLeftAnimation : IEntityAnimation
    {
        private Animation _animation;
        Texture2D texture;
        ITransform transform;
        public Animation Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }
        public WalkLeftAnimation(Texture2D texture, ITransform transform)
        {
            this.transform = transform;
            this.texture = texture;
            _animation = new Animation();
            _animation.AddFrame(new AnimationFrame(new Rectangle(23, 0, 40, 85)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(103, 0, 40, 85)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(183, 0, 40, 85)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(263, 0, 40, 85)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(343, 0, 40, 85)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(423, 0, 40, 85)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(503, 0, 40, 85)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(583, 0, 40, 85)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(663, 0, 40, 85)));
            _animation.Fps = 10;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, transform.Position, _animation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.FlipHorizontally, 0);
        }

        public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }
    }
}
