using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.Collision;
using Platformer.Input;
using Platformer.LevelDesign;
using Platformer.World;
using System;
using System.Diagnostics;

namespace Platformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D textureBlok;
        private Texture2D textureHero;
        private Texture2D textureBG;
        Hero hero;

        CollisionManager collisionManager;

        Level currentLevel;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //source sprites voor blokjes en achtergrond: https://opengameart.org/content/inca-tileset 


            base.Initialize();


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            textureHero = Content.Load<Texture2D>("spritesheetHero"); // Source: https://www.reddit.com/r/spelunky/comments/8zlje0/a_sprite_sheet_of_my_custom_if_anyone_wants_to/
            textureBlok = Content.Load<Texture2D>("Block");
            textureBG = Content.Load<Texture2D>("bgBlock");

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
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

            // TODO: Add your update logic here

            hero.Update(gameTime);
            
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);

            _spriteBatch.Begin();

            currentLevel.Draw(_spriteBatch);
            hero.Draw(_spriteBatch);
            //blokje.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
