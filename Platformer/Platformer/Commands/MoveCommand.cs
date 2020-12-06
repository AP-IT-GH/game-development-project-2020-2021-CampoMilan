using Microsoft.Xna.Framework;
using Platformer.Collision;
using Platformer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Commands
{
    class MoveCommand : IGameCommand
    {
        public Vector2 speed;
        public CollisionManager collisionManager = new CollisionManager();

        public MoveCommand()
        {
            this.speed = new Vector2(5, 0);
            //TODO: tile mapping doorgeven via de constructor (even niet aan SOLID denken, eerst gewoon werkende krijgen)
        }

        public void Execute(ITransform transform, Vector2 direction, Rectangle collisionRectangle)
        {
            collisionManager.CheckCollision(collisionRectangle, direction);
            direction *= speed;
            transform.Position += direction;
        }
    }
}
