using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.GamestateManagement
{
    public class MainMenu : State
    {
        GraphicsDeviceManager _manager;

        Texture2D btnTexture;
        SpriteFont buttonFont;
        SpriteFont titleFont;

        private List<Component> _components;
        ScreenText gameTitle;
        Button newGameButton;
        Button quitGameButton;

        public MainMenu(Game1 game, GraphicsDevice graphics, GraphicsDeviceManager manager) : base(game, graphics, manager)
        {
            _manager = manager;

            btnTexture = Globals.content.Load<Texture2D>("bgBlock");
            buttonFont = Globals.content.Load<SpriteFont>("buttonFont");
            titleFont = Globals.content.Load<SpriteFont>("titleFont");

            gameTitle = new ScreenText("Don't fall!", titleFont, new Vector2(300, 50));

            newGameButton = new Button(btnTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Play"
            };

            newGameButton.Click += NewGameButton_Click;

            quitGameButton = new Button(btnTexture, buttonFont)
            {
                Position = new Vector2(300,250),
                Text = "Quit"
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                gameTitle,
                newGameButton,
                quitGameButton
            };

            Globals.screenWidth = 800;
            Globals.screenHeight = 500;

            _manager.PreferredBackBufferWidth = Globals.screenWidth;
            _manager.PreferredBackBufferHeight = Globals.screenHeight;

            _manager.ApplyChanges();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            Globals.currentLevelCounter = 0;
            _game.ChangeState(new Gameplay(_game, _graphics, _manager));
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }


        public override void Update(GameTime gameTime)
        {

            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();

            Globals.spriteBatch.Draw(Globals.content.Load<Texture2D>("background"), new Rectangle(0, 0, 800, 500), Color.White);
            foreach (var component in _components)
            {
                component.Draw(gameTime);
            }

            Globals.spriteBatch.End();
        }
    }
}
