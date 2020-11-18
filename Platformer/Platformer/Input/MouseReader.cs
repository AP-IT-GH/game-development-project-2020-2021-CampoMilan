using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Input
{
    public class MouseReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            MouseState state = Mouse.GetState();
            var mouseVector = new Vector2(state.X, state.Y);
            return mouseVector;
        }
    }
}
