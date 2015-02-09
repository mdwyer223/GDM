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
    public class LetsPlay : MessObject
    {
        public LetsPlay(float startPosX)
            : base(Image.Object.LetsPlay, .33f, 0, Vector2.Zero, null, "")
        {
            this.Position = new Vector2(startPosX, (int)(Game1.View.Height * 0.55f));
        }

        public LetsPlay(float startPosX, string mess)
            : base(Image.Object.LetsPlay, .33f, 0, Vector2.Zero, null, mess)
        {
            this.Position = new Vector2(startPosX, (int)(Game1.View.Height * 0.55f));
        }

        public LetsPlay(float startPosX, List<string> mess)
            : base(Image.Object.LetsPlay, .33f, 0, Vector2.Zero, null, mess)
        {
            this.Position = new Vector2(startPosX, (int)(Game1.View.Height * 0.55f));
        }
    }
}
