using Microsoft.Xna.Framework;

namespace Platformer.Animatie
{
    public interface IEntityAnimation
    {
        Animation Animation { get; set; }
        void Draw();
        void Update(GameTime gameTime);
    }
}
