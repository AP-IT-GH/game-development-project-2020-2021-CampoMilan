using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Interfaces;
using Platformer.Animatie;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Platformer.Input;
using Platformer.Commands;
using Platformer.Animatie.HeroAnimations;

namespace Platformer
{
    class Hero : IGameObject, ITransform, ICollision
    {
        private Texture2D heroTexture;
        private Rectangle collisionRect;
        private IGameCommand moveCommand;

        private IInputReader input;
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        IEntityAnimation walkRight;
        IEntityAnimation walkLeft;
        IEntityAnimation currentAnimation;

        public Hero(Texture2D texture, IInputReader inputReader, Vector2 _position)
        {
            // Animatie van hero initialiseren
            heroTexture = texture;
            walkLeft = new WalkLeftAnimation(texture, this);
            walkRight = new WalkRightAnimation(texture, this);
            currentAnimation = walkLeft;
            
            // Physics van hero initialiseren
            Position = _position;
            collisionRect = new Rectangle((int)Position.X, (int)Position.Y, 40, 85);

            //Controls for hero **input**
            input = inputReader;
            moveCommand = new MoveCommand();
        }

        public void Update(GameTime gameTime)
        {
            var direction = input.ReadInput();
            Move(direction);
            currentAnimation.Update(gameTime);
            collisionRect.X = (int)Position.X;
            collisionRect.Y = (int)Position.Y;
            
        }

        private void Move(Vector2 _direction)
        {
            if (_direction.X == -1)
            {
                currentAnimation = walkLeft;
            }
            else if (_direction.X == 1)
            {
                currentAnimation = walkRight;
            }
            moveCommand.Execute(this, _direction);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch);
        }
    }
}
