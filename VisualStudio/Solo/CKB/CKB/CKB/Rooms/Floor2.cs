using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CKB
{
    public class Floor2 : Floor
    {
        public Floor2()
            : base(Image.Floor2.Wall, Vector2.Zero)
        {
            objs.Add(new Elevator(130));
           
            objs.Add(new Trash(400, "Don't go to the top floor whatever you do."));
            objs.Add(new GhostDoor(700, 2));
            objs.Add(new Trash(900, "The doors lock behind you,\nwhy did it go dark..."));            
            objs.Add(new Door(1500, 2));
            objs.Add(new Trash(1800, "Where is everyone...\n\nHello? I'm scared"));

            objs.Add(new LockedStairDoor(2000, 2));
            objs.Add(new Toy(1100));
            
        }

        public override void update(GameTime gameTime)
        {
            if (Input.escapePressed())
                Game1.changeFloor(new Floor3());
            base.update(gameTime);
        }
    }
}
