using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.GamestateManagement
{
    public class EndOfGame : IState
    {
        public bool RestartButton;
        public bool MainMenuButton;

        public void Update(GameTime gameTime, GamestateManager manager)
        {
            if (MainMenuButton)
            {
                manager.ChangeGamestateTo(manager.MainMenuState);
            }
            else if (RestartButton)
            {
                manager.ChangeGamestateTo(manager.GameplayState);
            }
        }
    }
}
