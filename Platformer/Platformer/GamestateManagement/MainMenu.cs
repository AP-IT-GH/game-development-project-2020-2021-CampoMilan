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
        SpriteFont font;

        private List<Component> _components;
        Button newGameButton;
        Button quitGameButton;

        public MainMenu(Game1 game, GraphicsDevice graphics, GraphicsDeviceManager manager) : base(game, graphics, manager)
        {
            _manager = manager;

            btnTexture = Globals.content.Load<Texture2D>("bgBlock");
            font = Globals.content.Load<SpriteFont>("font");

            newGameButton = new Button(btnTexture, font)
            {
                Position = new Vector2(300, 200),
                Text = "Play"
            };

            newGameButton.Click += NewGameButton_Click;

            quitGameButton = new Button(btnTexture, font)
            {
                Position = new Vector2(300,250),
                Text = "Quit"
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
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
