using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Platformer.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.LevelDesign
{
    class Level1
    {
        private Texture2D blockTexture;
        private Texture2D bgTexture;
        private Blok[,] blokArray = new Blok[6, 7];
        private BackgroundBlok[,] bgArray = new BackgroundBlok[6,7];
        private ContentManager content;

        /* level elementen:
            0 = achtergrond,
            1 = blok
         */
        public byte[,] tileArray = new Byte[,]
        {
            { 1, 0, 0, 0, 1, 1 },
            { 1, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 0, 1 },
            { 1, 1, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 1, 1 },
            { 1, 1, 1, 1, 1, 1 },
        };
        public Level1(ContentManager content)
        {
            this.content = content;

            InitializeContent();
        }

        private void InitializeContent()
        {
            blockTexture = content.Load<Texture2D>("Block");
            bgTexture = content.Load<Texture2D>("bgBlock");
        }

        public void CreateWorld()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    switch (tileArray[x, y])
                    {
                        case 1:
                            blokArray[x, y] = new Blok(blockTexture, new Vector2(y * 17, x * 17));
                            break;
                        case 0:
                            bgArray[x, y] = new BackgroundBlok(bgTexture, new Vector2(y * 17, x * 17));
                            break;
                    }

                }
            }
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (blokArray[x,y] != null)
                    {
                        blokArray[x, y].Draw(spriteBatch);
                    }
                    if (bgArray[x,y] != null)
                    {
                        bgArray[x, y].Draw(spriteBatch);
                    }
                }
            }
        }
        
    }
}
