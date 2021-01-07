using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.GamestateManagement
{
    public interface IState
    {
        public void Update(GameTime gameTime, GamestateManager manager);
    }
}
