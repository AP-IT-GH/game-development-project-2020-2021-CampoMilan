using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.GamestateManagement
{
    public abstract class Component
    {
        public abstract void Draw();
        public abstract void Update();

    }
}