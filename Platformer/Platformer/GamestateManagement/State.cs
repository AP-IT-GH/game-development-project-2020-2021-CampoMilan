using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.GamestateManagement
{
    public abstract class State
    {
        protected GraphicsDevice _graphics;
        protected GraphicsDeviceManager _manager;
        protected Game1 _game;
        


        public State(Game1 game, GraphicsDevice graphics, GraphicsDeviceManager manager)
        {
            _graphics = graphics;
            _manager = manager;
            _game = game;
            
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw();

    }
}
