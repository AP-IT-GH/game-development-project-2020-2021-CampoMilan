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
        public Vector2 Speed;
        private CollisionManager collisionManager;

        public MoveCommand(CollisionManager _collisionManager)
        {
            collisionManager = _collisionManager;
            this.Speed = new Vector2(1, 1);
        }

        public void Execute(ITransform transform, Vector2 direction, ICollisionMoving movingObject)
        {
            direction = collisionManager.CheckCollision(movingObject, direction);

            direction *= Speed;
            transform.Position += direction;
        }
    }
}
