using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Platformer.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.LevelDesign
{
    public class Level1 : Level
    {
        /* level elementen:
            0 = achtergrond,
            1 = blok
         */

        public override void CreateTileArray()
        {
            byteTileArray = new Byte[,]
        {
            { 1, 0, 0, 0, 1, 1 },
            { 1, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 0, 1 },
            { 1, 1, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 1, 1 },
            { 1, 1, 1, 1, 1, 1 },
        };
        }
    }
}
