using Microsoft.Xna.Framework;

namespace Platformer.Animatie
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle source)
        {
            SourceRectangle = source;
        }
    }
}
