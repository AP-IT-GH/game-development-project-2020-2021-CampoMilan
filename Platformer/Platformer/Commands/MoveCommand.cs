using Microsoft.Xna.Framework;
using Platformer.Collision;
using Platformer.Interfaces;
using Platformer.LevelDesign;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Commands
{
    class MoveCommand : IGameCommand
    {
        public Vector2 speed;
        private CollisionManager collisionManager;

        public MoveCommand(CollisionManager _collisionManager)
        {
            collisionManager = _collisionManager;
            this.speed = new Vector2(3, 0);
            //TODO: tile mapping doorgeven via de constructor (even niet aan SOLID denken, eerst gewoon werkende krijgen)
        }

        public void Execute(ITransform transform, Vector2 direction, ICollisionMoving movingObject)
        {
            direction = collisionManager.CheckCollision(movingObject, direction);
            direction *= speed;
            transform.Position += direction;
        }
    }
}
