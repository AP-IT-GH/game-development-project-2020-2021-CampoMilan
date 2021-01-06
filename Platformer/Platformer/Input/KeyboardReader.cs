using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Input
{
    class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            var direction = new Vector2(0,0);
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X = -1f;
                direction.Y = -0.1f;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X = 1f;
                direction.Y = -0.1f;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                direction.Y = -1f;
            }
            return direction;
        }
    }
}
