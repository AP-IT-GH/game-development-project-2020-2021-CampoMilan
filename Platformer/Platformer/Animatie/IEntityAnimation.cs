using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Animatie
{
    public interface IEntityAnimation
    {
        Animation Animation { get; set; }
        void Draw();
        void Update(GameTime gameTime);
    }
}
