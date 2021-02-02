using Microsoft.Xna.Framework;

namespace Platformer.Interfaces
{
    interface IGameObject
    {
        void Update(GameTime gameTime);
        void Draw();
    }
}
