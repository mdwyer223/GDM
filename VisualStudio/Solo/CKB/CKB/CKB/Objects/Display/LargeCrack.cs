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
    public class LargeCrack : MessObject
    {
        public LargeCrack(float startPosX)
            : base(Image.Crack.Large, .33f, 0, Vector2.Zero, null, "")
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - Game1.View.Height * 0.48f);
        }

        public LargeCrack(float startPosX, string mess)
            : base(Image.Crack.Large, .33f, 0, Vector2.Zero, null, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - Game1.View.Height * 0.48f);
        }

        public LargeCrack(float startPosX, List<string> mess)
            : base(Image.Crack.Large, .33f, 0, Vector2.Zero, null, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - Game1.View.Height * 0.48f);
        }
    }
}
