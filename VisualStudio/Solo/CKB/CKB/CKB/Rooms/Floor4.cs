using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace CKB
{
    public class Floor4 : Floor
    {
        bool turnedOffLights = false;
        SoundEffectInstance whipser;       

        public Floor4()
            : base(Image.Floor4.Wall, Vector2.Zero)
        {
            objs.Add(new Elevator(130));

            objs.Add(new Door(800, 4));
            objs.Add(new Girl(800, false, true));
            objs.Add(new Trash(1800, "YOu lik dis bUlding here?"));

            objs.Add(new LockedStairDoor(2000, 4));

            whipser = Sound.LoudWhisper.CreateInstance();
        }

        public override void update(GameTime gameTime)
        {
            if (Input.escapePressed())
                Game1.changeFloor(new Floor1());
            base.update(gameTime);

            if (whipser.State == SoundState.Stopped)
                whipser.Play();
            else
                whipser.Resume();

            if (Character.Position.X < 1040 && !turnedOffLights)
            {
                LightComponent.turnOffLights();
                Sound.HighPitchScream.Play();
                Sound.SmallScream.Play();
                turnedOffLights = true;
            }
        }
    }
}
