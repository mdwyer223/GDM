using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CKB
{
    public class SmallCrack : MessObject
    {
        public SmallCrack(float startPosX)
            : base(Image.Crack.Small, .09f, 0, Vector2.Zero, null, "")
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - Game1.View.Height * 0.3f);
        }

        public SmallCrack(float startPosX, string mess)
            : base(Image.Crack.Small, .09f, 0, Vector2.Zero, null, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - Game1.View.Height * 0.3f);
        }

        public SmallCrack(float startPosX, List<string> mess)
            : base(Image.Crack.Small, .09f, 0, Vector2.Zero, null, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - Game1.View.Height * 0.3f);
        }
    }
}
