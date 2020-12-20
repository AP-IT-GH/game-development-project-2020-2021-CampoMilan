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
using Platformer.Collision;

namespace Platformer
{
    class Hero : IGameObject, ITransform, ICollisionMoving
    {
        private Texture2D heroTexture;
        private Rectangle collisionRect;
        private Rectangle futureColRect;
        private IGameCommand moveCommand;
        private Vector2 _direction;
        

        private IInputReader input;
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get => collisionRect; set => collisionRect = value; }
        public Rectangle FutureCollisionRectangle { get => futureColRect; set => futureColRect = value; }

        IEntityAnimation walkRight;
        IEntityAnimation walkLeft;
        IEntityAnimation idle;
        IEntityAnimation currentAnimation;

        public Hero(Texture2D texture, IInputReader inputReader, Vector2 _position, CollisionManager collisionManager)
        {
            // Animatie van hero initialiseren
            heroTexture = texture;
            walkLeft = new WalkLeftAnimation(texture, this);
            walkRight = new WalkRightAnimation(texture, this);
            idle = new IdleAnimation(texture, this);
            currentAnimation = idle;

            // Physics van hero initialiseren
            Position = _position;
            collisionRect = new Rectangle((int)Position.X, (int)Position.Y, 40, 85);
            futureColRect = new Rectangle(collisionRect.X + (collisionRect.Width * (int)_direction.X), collisionRect.Y + (collisionRect.Height * (int)_direction.Y), 40, 85);

            //Controls for hero **input**
            input = inputReader;
            moveCommand = new MoveCommand(collisionManager);
        }

        public void Update(GameTime gameTime)
        {
            _direction = input.ReadInput();
            Move(_direction);
            currentAnimation.Update(gameTime);
            collisionRect.X = (int)Position.X;
            collisionRect.Y = (int)Position.Y;

        }

        private void Move(Vector2 _direction)
        {
            if (_direction.X == -1)
            {
                currentAnimation = walkLeft;
                futureColRect.X -= collisionRect.Width;
            }
            else if (_direction.X == 1)
            {
                currentAnimation = walkRight;
                futureColRect.X += collisionRect.Width;
            }
            else if (_direction.X == 0)
            {
                currentAnimation = idle;
            }
            moveCommand.Execute(this, _direction, this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch);
        }
    }
}
