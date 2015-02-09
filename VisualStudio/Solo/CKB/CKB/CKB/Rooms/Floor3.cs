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
    public class Floor3 : Floor
    {
        float lightsOffTimer = 0, timeOff = 3;
        bool lightsOff = false;
        public Floor3()
            : base(Image.Floor3.Wall, Vector2.Zero)
        {
            List<SoundEffect> sounds = new List<SoundEffect>();
            sounds.Add(Sound.Whispers);

            objs.Add(new BrokenElevator(130));
            objs.Add(new Phone(350, sounds));
            objs.Add(new Trash(600, "You should turn around"));
            objs.Add(new Bear(850));
            objs.Add(new Trash(1200, "She is coming after you...\nI am coming after you\nWe are all coming after you"));
            //objs.Add(new Trash(1900, "Didn't I say not to go to the top floor?"));
            objs.Add(new StairDoor(2000, 3));
        }

        public override void update(GameTime gameTime)
        {
            if (Input.escapePressed())
                Game1.changeFloor(new Floor4());
            if (Character.Position.X > 700 && Character.Position.X <= 1200 && !lightsOff)
            {
                Sound.Shriek1.Play();
                lightsOff = true;
                LightComponent.turnOffLights();
                Sound.Giggle.Play();

                //Display creepy stuff
                objs.Add(new LetsPlay(760));
                objs.Add(new SmallCrack(1300));
                objs.Add(new MidCrack(1700));
                objs.Add(new LargeCrack(2200));

                foreach (Object obj in objs)
                    if (obj.GetType() == typeof(Bear))
                    {
                        objs.Remove(obj);
                        break;
                    }

            }
            if(lightsOff)
                lightsOffTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (lightsOffTimer > timeOff)
            {
                LightComponent.turnLightOn();
                lightsOffTimer = 0;
            }
            base.update(gameTime);
        }
    }
}
