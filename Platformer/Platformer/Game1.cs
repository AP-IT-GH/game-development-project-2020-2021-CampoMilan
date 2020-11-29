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
        Hero hero;
        Blok blokje;

        CollisionManager collisionManager;

        //Level1 level;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //source sprites voor blokjes en achtergrond: https://opengameart.org/content/inca-tileset 
            collisionManager = new CollisionManager();
            //level = new Level1(Content);
            //level.CreateWorld();

            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            textureHero = Content.Load<Texture2D>("spritesheetHero"); // Source: https://www.reddit.com/r/spelunky/comments/8zlje0/a_sprite_sheet_of_my_custom_if_anyone_wants_to/
            textureBlok = Content.Load<Texture2D>("Block");

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(textureHero, new KeyboardReader(), new Vector2(50,265));
            blokje = new Blok(textureBlok, new Vector2(100, 265));
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            hero.Update(gameTime);
            if (collisionManager.CheckCollision(hero.CollisionRectangle, blokje.CollisionRectangle))
            {
                Debug.WriteLine("Collision");
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);

            _spriteBatch.Begin();

            //level.DrawWorld(_spriteBatch);
            hero.Draw(_spriteBatch);
            blokje.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
