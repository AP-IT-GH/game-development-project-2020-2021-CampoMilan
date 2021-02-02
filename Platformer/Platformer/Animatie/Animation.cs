using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Platformer.Animatie
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        public int Fps { get; set; }

        private List<AnimationFrame> frames;
        private int counter;
        private double frameMovement = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            frameMovement += CurrentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds; //tijdsafhankelijke animatie ipv frame-afhankelijk
            if (frameMovement >= CurrentFrame.SourceRectangle.Width/Fps) //Width delen door grotere getallen = snellere animatie
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

    }
}
