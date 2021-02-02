using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Interfaces;

namespace Platformer.Animatie.HeroAnimations
{
    class IdleAnimation : IEntityAnimation
    {
        private Animation _animation;
        Texture2D texture;
        ITransform transform;

        public Animation Animation {
            get { return _animation; }
            set { _animation = value; }
        }
        public IdleAnimation(Texture2D texture, ITransform transform)
        {
            this.transform = transform;
            this.texture = texture;
            _animation = new Animation();
            _animation.AddFrame(new AnimationFrame(new Rectangle(23, 0, 40, 85)));
            _animation.Fps = 10;
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(texture, transform.Position, _animation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }
    }
}
