using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.GamestateManagement
{
    public class GamestateManager
    {
        public IState CurrentState;

        public Gameplay GameplayState;
        public MainMenu MainMenuState;
        public EndOfGame EndOfGameState;

        public GamestateManager()
        {
            GameplayState = new Gameplay();
            MainMenuState = new MainMenu();
            EndOfGameState = new EndOfGame();
        }
        public void ChangeGamestateTo(IState gamestate)
        {
            CurrentState = gamestate;
        }
    }
}
