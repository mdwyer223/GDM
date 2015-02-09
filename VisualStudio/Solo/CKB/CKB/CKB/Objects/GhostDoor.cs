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
    public class GhostDoor : Door
    {
        float time;
        bool done = false;

        public GhostDoor(float startPosX, int floorIndex)
            : base(startPosX, floorIndex)
        {
        }


        public override void update(GameTime gameTime, Floor floor)
        {
            if (done || measureDis(floor.Character) < 220)
            {
                done = true;
                Open = false;
                return;
            }


            base.update(gameTime, floor);

            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time >= 1f)
            {
                Open = !Open;
                time = 0;
                SoundComponent.playEffect(Sound.DoorOpening, .25f);
            }
        }

    }
}
