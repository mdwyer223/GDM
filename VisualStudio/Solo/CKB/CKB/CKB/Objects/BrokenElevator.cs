using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CKB
{
    public class BrokenElevator : MessObject
    {
        public BrokenElevator(float startPosX)
            : base(Image.ClosedElevator, .18f, 0, Vector2.Zero, null, "OUT OF ORDER")
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

    }
}
