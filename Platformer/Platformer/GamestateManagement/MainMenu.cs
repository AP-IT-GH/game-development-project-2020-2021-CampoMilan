using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.GamestateManagement
{
    public class MainMenu : IState
    {
        public bool StartGameButton = false;
        public void Update(GameTime gameTime, GamestateManager manager)
        {
            if (StartGameButton)
            {
                manager.ChangeGamestateTo(manager.GameplayState);
            }
        }
    }
}
