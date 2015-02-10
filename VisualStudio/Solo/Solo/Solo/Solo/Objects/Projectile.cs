using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Solo
{
    public class Projectile : Object
    {
        string userID;

        public Projectile(Texture2D texture, float scaleFactor, float secondsToCrossScreen, Vector2 startPos)
            : base(texture, scaleFactor, secondsToCrossScreen, startPos, null)
        {
        }

        public void readVeloPos(Vector2 velo, Vector2 pos)
        {
        }
    }
}
