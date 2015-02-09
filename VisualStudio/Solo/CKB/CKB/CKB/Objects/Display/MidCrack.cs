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
    public class MidCrack : MessObject
    {
        public MidCrack(float startPosX)
            : base(Image.Crack.Mid, .16f, 0, Vector2.Zero, null, "")
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public MidCrack(float startPosX, string mess)
            : base(Image.Crack.Mid, .16f, 0, Vector2.Zero, null, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public MidCrack(float startPosX, List<string> mess)
            : base(Image.Crack.Mid, .16f, 0, Vector2.Zero, null, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }
    }
}
