using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.Collision;
using Platformer.GamestateManagement;
using Platformer.Input;
using Platformer.LevelDesign;
using Platformer.World;
using System;
using System.Diagnostics;

namespace Platformer
{
    public class Game1 : Game
    {
        /* Referenties:
         * Algemene kennis over MonoGame en hoe een game te structureren:
         * Youtube kanaal -- Batholith Entertainment (https://youtube.com/playlist?list=PLZ6ofHM1rvK8lQSoKX1USZstM-ZXikFHp)
         * 
         * block sprites: https://opengameart.org/content/inca-tileset
         * hero sprite: https://www.reddit.com/r/spelunky/comments/8zlje0/a_sprite_sheet_of_my_custom_if_anyone_wants_to/
         * 
         */


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D textureBlok;
        private Texture2D textureHero;
        private Texture2D textureBG;
        Hero hero;

        CollisionManager collisionManager;

        private GamestateManager gamestateManager;
        Level currentLevel;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            //source sprites voor blokjes en achtergrond: https://opengameart.org/content/inca-tileset 
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            
            textureHero = Globals.content.Load<Texture2D>("spritesheetHero"); // Source: https://www.reddit.com/r/spelunky/comments/8zlje0/a_sprite_sheet_of_my_custom_if_anyone_wants_to/
            textureBlok = Globals.content.Load<Texture2D>("Block");
            textureBG = Globals.content.Load<Texture2D>("bgBlock");

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {

            gamestateManager = new GamestateManager();

            currentLevel = new Level1(textureBG, textureBlok);
            collisionManager = new CollisionManager(currentLevel.blokTileArray);
            currentLevel.CreateWorld();
            hero = new Hero(textureHero, new KeyboardReader(), new Vector2(50,10), collisionManager);
            //blokje = new Blok(textureBlok, new Vector2(1000, 10));
            
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);

            gamestateManager.CurrentState.Update(gameTime, gamestateManager);

            hero.Update(gameTime);

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);

            Globals.spriteBatch.Begin();

            currentLevel.Draw(Globals.spriteBatch);
            hero.Draw(Globals.spriteBatch);
            //blokje.Draw(_spriteBatch);

            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
