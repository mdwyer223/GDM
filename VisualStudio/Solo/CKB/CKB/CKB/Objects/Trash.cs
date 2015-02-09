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
    public class Trash : MessObject
    {       

        public Trash(float startPosX)
            : base(Image.Object.Trash, .058f, 0, Vector2.Zero, Sound.Trash, "The trash can is empty")
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public Trash(float startPosX, string mess)
            : base(Image.Object.Trash, .058f, 0, Vector2.Zero, Sound.Trash, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public Trash(float startPosX, List<string> mess)
            : base(Image.Object.Trash, .058f, 0, Vector2.Zero, Sound.Trash, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

    }
}
