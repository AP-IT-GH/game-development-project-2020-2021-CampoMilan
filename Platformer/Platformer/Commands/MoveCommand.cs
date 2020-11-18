using Microsoft.Xna.Framework;
using Platformer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Commands
{
    class MoveCommand : IGameCommand
    {
        public Vector2 speed;

        public MoveCommand()
        {
            this.speed = new Vector2(5, 0);
        }
        public void Execute(ITransform transform, Vector2 direction)
        {
            direction *= speed;
            transform.Position += direction;
        }

    }
}
