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
using System.Diagnostics;

namespace Platformer
{
    class Hero : IGameObject, ITransform, ICollisionMoving
    {
        private Rectangle collisionRect;
        private Rectangle futureColRect;
        private IGameCommand moveCommand;
        private Vector2 _direction;



        private IInputReader input;
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get => collisionRect; set => collisionRect = value; }
        public Rectangle FutureCollisionRectangle { get => futureColRect; set => futureColRect = value; }
        public bool IsOnGround { get; set; }
        public Vector2 Gravity { get; set; }

        IEntityAnimation walkRight;
        IEntityAnimation walkLeft;
        IEntityAnimation idle;
        IEntityAnimation currentAnimation;

        public Hero(Texture2D texture, IInputReader inputReader, Vector2 _position, CollisionManager collisionManager)
        {
            // Animatie van hero initialiseren
            walkLeft = new WalkLeftAnimation(texture, this);
            walkRight = new WalkRightAnimation(texture, this);
            idle = new IdleAnimation(texture, this);
            currentAnimation = idle;

            // Physics van hero initialiseren
            Position = _position;
            collisionRect = new Rectangle((int)Position.X, (int)Position.Y, 22, 32);
            futureColRect = new Rectangle(collisionRect.X + (int)_direction.X, collisionRect.Y + (int)_direction.Y, 22, 32);
            Gravity = new Vector2(0, 2);

            //Controls for hero **input**
            input = inputReader;
            moveCommand = new MoveCommand(collisionManager);
        }

        public void Update(GameTime gameTime)
        {
            _direction = input.ReadInput();
            ApplyPhysics();
            Move(_direction);
            currentAnimation.Update(gameTime);
            collisionRect.X = (int)Position.X;
            collisionRect.Y = (int)Position.Y;

            Debug.WriteLine("Position: X= " + Position.X + " Y= " + Position.Y);

        }

        private void ApplyPhysics()
        {
            if (!IsOnGround)
            {
                _direction += Gravity;
            }
            else
            {
                _direction.Y += -1f;
            }
        }

        private void Move(Vector2 _direction)
        {
            if (_direction.X == -1)
            {
                currentAnimation = walkLeft;
                futureColRect.X = (int)CollisionRectangle.X -1;
            }
            if (_direction.X == 1)
            {
                currentAnimation = walkRight;
                futureColRect.X = (int)CollisionRectangle.X + 1;
            }
            if (_direction.X == 0)
            {
                currentAnimation = idle;
                futureColRect.X = (int)Position.X;
            }
            futureColRect.Y = (int)Position.Y + 8;
            moveCommand.Execute(this, _direction, this);
        }

        public void Draw()
        {
            currentAnimation.Draw();
        }
    }
}
