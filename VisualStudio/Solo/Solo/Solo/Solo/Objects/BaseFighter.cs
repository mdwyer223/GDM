using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Solo.Objects
{
    public class BaseFighter : AnimatedSprite
    {
        string userID;

        public BaseFighter(Texture2D texture, float scaleFactor, float secondsToCrossScreen, Vector2 startPos)
            : base(texture, scaleFactor, secondsToCrossScreen, startPos)
        {
        }

        public void readVeloPos(Vector2 velo, Vector2 position)
        {
            this.Position = position;
        }
    }
}
