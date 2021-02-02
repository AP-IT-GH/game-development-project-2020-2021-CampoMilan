using Microsoft.Xna.Framework;
using Platformer.Interfaces;

namespace Platformer.Commands
{
    public interface IGameCommand
    {
        void Execute(ITransform transform, Vector2 direction, ICollisionMoving movingObject);
    }
}
