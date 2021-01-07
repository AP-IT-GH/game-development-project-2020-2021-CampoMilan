using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.GamestateManagement
{
    public class Gameplay : IState
    {
        public bool playerDied;

        public void Update(GameTime gameTime, GamestateManager manager)
        {
            if (playerDied)
            {
                manager.ChangeGamestateTo(manager.EndOfGameState);
            }
        }

        public void ResetLevel()
        {

        }

    }
}
