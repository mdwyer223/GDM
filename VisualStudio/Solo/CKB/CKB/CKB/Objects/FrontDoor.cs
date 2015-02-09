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
    public class FrontDoor : MessObject
    {

        public FrontDoor(float startPosX)
            : base(Image.Object.FrontDoor, .31f, 0, Vector2.Zero, Sound.DoorOpening, "The front door is locked\nMaybe there's a keys somewhere")
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public FrontDoor(float startPosX, string mess)
            : base(Image.Object.FrontDoor, .31f, 0, Vector2.Zero, Sound.DoorOpening, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public FrontDoor(float startPosX, List<string> mess)
            : base(Image.Object.FrontDoor, .31f, 0, Vector2.Zero, Sound.DoorOpening, mess)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

    }
}