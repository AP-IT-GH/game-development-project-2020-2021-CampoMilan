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
    class Hero : IGameObject, ITransform
    {
        private Texture2D heroTexture;

        private IInputReader input;
        public Vector2 Position { get; set; }

        private IGameCommand moveCommand;

        IEntityAnimation walkRight;
        IEntityAnimation walkLeft;
        IEntityAnimation currentAnimation;
        IEntityAnimation idle;

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            // Animatie van hero initialiseren
            heroTexture = texture;
            walkLeft = new WalkLeftAnimation(texture, this);
            walkRight = new WalkRightAnimation(texture, this);
            idle = new IdleAnimation(texture, this);
            currentAnimation = idle;
            
            // Physics van hero initialiseren
            Position = new Vector2(10, 10);
            
            //Controls for hero **input**
            input = inputReader;
            moveCommand = new MoveCommand();
        }

        public void Update(GameTime gameTime)
        {
            var direction = input.ReadInput();
            Move(direction);
            currentAnimation.Update(gameTime);
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
            currentAnimation = idle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch);
        }
    }
}
