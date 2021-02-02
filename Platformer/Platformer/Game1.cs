using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.GamestateManagement;

namespace Platformer
{
    public class Game1 : Game
    {
        /* Referenties:
         * Algemene kennis over MonoGame en hoe een game te structureren:
         * YouTube kanaal -- Batholith Entertainment (https://youtube.com/playlist?list=PLZ6ofHM1rvK8lQSoKX1USZstM-ZXikFHp)
         * 
         * Voor gamestates: (heeft ook een YouTube kanaal) 
         * https://github.com/Oyyou/MonoGame_Tutorials/tree/master/MonoGame_Tutorials/Tutorial013
         * 
         * block sprites: https://opengameart.org/content/inca-tileset
         * hero sprite: https://www.reddit.com/r/spelunky/comments/8zlje0/a_sprite_sheet_of_my_custom_if_anyone_wants_to/
         * 
         */

        private GraphicsDeviceManager graphics;

        private State currentState;
        private State nextState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Globals.graphicsManager = graphics;
            Globals.content = this.Content;
            Globals.content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            currentState = new MainMenu(this, graphics.GraphicsDevice, graphics);
        }

        
        public void ChangeState(State state)
        {
            nextState = state;
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.gameTime = gameTime;

            currentState.Update(gameTime);

            if (nextState != null)
            {
                currentState = nextState;
                nextState = null;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {

            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            GraphicsDevice.Clear(Color.Crimson);

            currentState.Draw();

            base.Draw(gameTime);
        }
    }
}
