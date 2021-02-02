using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer
{
    public class Globals
    {
        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static GraphicsDeviceManager graphicsManager;

        public static int screenWidth;
        public static int screenHeight;

        public static GameTime gameTime;

        public static int currentLevelCounter;
        public static bool playerDied;
    }
}
