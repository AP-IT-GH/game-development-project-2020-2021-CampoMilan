using Microsoft.Xna.Framework;
using Platformer.Collision;
using Platformer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Commands
{
    public interface IGameCommand
    {
        void Execute(ITransform transform, Vector2 direction, CollisionLocation _collisionLocation);
    }
}
