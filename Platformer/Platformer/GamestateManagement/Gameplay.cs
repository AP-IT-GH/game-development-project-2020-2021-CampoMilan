using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Collision;
using Platformer.Input;
using Platformer.LevelDesign;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.GamestateManagement
{
    public class Gameplay : State
    {
        GraphicsDeviceManager graphicsManager;
        Game1 game;

        private Texture2D textureBlok;
        private Texture2D textureHero;
        private Texture2D textureBG;

        private Texture2D textureFinish;
        Hero hero;

        CollisionManager collisionManager;

        Level currentLevel;
        Level1 level1;
        Level2 level2;
        bool isInitiated = false;


        public Gameplay(Game1 _game, GraphicsDevice graphics, GraphicsDeviceManager manager) : base(_game, graphics, manager)
        {
            game = _game;
            _graphics = graphics;
            graphicsManager = manager;

            Globals.spriteBatch = new SpriteBatch(graphics);

            textureHero = Globals.content.Load<Texture2D>("spritesheetHero");
            textureBlok = Globals.content.Load<Texture2D>("Block");
            textureBG = Globals.content.Load<Texture2D>("bgBlock");
            textureFinish = Globals.content.Load<Texture2D>("FinishLine");

            InitializeGameObjects();
        }
        private void InitializeGameObjects()
        {

            level1 = new Level1(textureBG, textureBlok, textureFinish);
            level2 = new Level2(textureBG, textureBlok, textureFinish);

            currentLevel = level1;
            InitiateLevel(currentLevel);

        }

        private void InitiateLevel(Level _current)
        {
            collisionManager = new CollisionManager(_current.blokTileArray, _current.finishArray);
            _current.CreateWorld();
            hero = new Hero(textureHero, new KeyboardReader(), _current.StartingPosition, collisionManager);

            Globals.screenWidth = _current.byteTileArray.GetLength(1) * 17;
            Globals.screenHeight = _current.byteTileArray.GetLength(0) * 17;

            graphicsManager.PreferredBackBufferWidth = Globals.screenWidth;
            graphicsManager.PreferredBackBufferHeight = Globals.screenHeight;

            graphicsManager.ApplyChanges();
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();

            currentLevel.Draw();
            hero.Draw();

            Globals.spriteBatch.End();
        }


        public override void Update(GameTime gameTime)
        {

            if (Globals.currentLevelCounter == 0)
            {
                currentLevel = level1;
            }
            else if (Globals.currentLevelCounter == 1)
            {
                currentLevel = level2;
                if (!isInitiated)
                {
                    InitiateLevel(currentLevel);
                    isInitiated = true;
                }
            }
            else if (Globals.currentLevelCounter < 1)
            {
                _game.ChangeState(new EndScreen(_game, _graphics, _manager));
            }


            hero.Update(gameTime);

            if (hero.Position.Y > Globals.screenHeight)
            {
                Globals.playerDied = true;
                Globals.currentLevelCounter = -1;
            }

        }
    }
}
