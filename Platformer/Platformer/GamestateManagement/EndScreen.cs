using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.GamestateManagement
{
    public class EndScreen : State
    {
        SpriteFont titleFont;
        SpriteFont buttonFont;
        Texture2D btnTexture;

        private List<Component> components;
        ScreenText endTitle;
        Button restartGameButton;
        Button mainMenuButton;

        private string endTitleString = "";

        public EndScreen(Game1 game, GraphicsDevice graphics, GraphicsDeviceManager manager) : base(game, graphics, manager)
        {
            Globals.currentLevelCounter = 0;
            
            _manager = manager;

            btnTexture = Globals.content.Load<Texture2D>("bgBlock");
            buttonFont = Globals.content.Load<SpriteFont>("buttonFont");
            titleFont = Globals.content.Load<SpriteFont>("titleFont");

            if (Globals.playerDied)
            {
                endTitleString = "Game over.";
            }
            else
            {
                endTitleString = "Great! You finished!";
            }
            endTitle = new ScreenText(endTitleString, titleFont, new Vector2(300, 50));
            Globals.playerDied = false;

            restartGameButton = new Button(btnTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Restart game"
            };

            restartGameButton.Click += RestartGameButton_Click;
            
            mainMenuButton= new Button(btnTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Main Menu"
            };

            mainMenuButton.Click += MainMenuButton_Click;

            components = new List<Component>()
            {
                endTitle,
                restartGameButton,
                mainMenuButton
            };

            Globals.screenWidth = 800;
            Globals.screenHeight = 500;

            _manager.PreferredBackBufferWidth = Globals.screenWidth;
            _manager.PreferredBackBufferHeight = Globals.screenHeight;

            _manager.ApplyChanges();

        }

        private void RestartGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new Gameplay(_game, _graphics, _manager));
        }
        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MainMenu(_game, _graphics, _manager));
        }



        public override void Update(GameTime gameTime)
        {
            foreach (var component in components)
            {
                component.Update();
            }
        }
        public override void Draw()
        {
            Globals.spriteBatch.Begin();

            Globals.spriteBatch.Draw(Globals.content.Load<Texture2D>("endscreen"), new Rectangle(0, 0, 800, 500), Color.White);
            foreach (var component in components)
            {
                component.Draw();
            }

            Globals.spriteBatch.End();
        }
    }
}
