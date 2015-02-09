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
    public class Bear : MessObject
    {
        public Bear(float startPosX)
            : base(Image.Object.Bear, .06f, 0, Vector2.Zero, null, "")
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public Bear(float startPosX, string mess)
            : base(Image.Object.Bear, .06f, 0, Vector2.Zero, null, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public Bear(float startPosX, List<string> mess)
            : base(Image.Object.Bear, .06f, 0, Vector2.Zero, null, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }
    }
}
