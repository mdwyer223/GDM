using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace CKB
{
    public class Phone : Object
    {
        bool loop;
        int clickCount;
        List<SoundEffect> sounds;

        public Phone(float startPosX)
            : base(Image.Object.Phone, .033f, 0, Vector2.Zero, Sound.Dialtone)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - Game1.View.Height * 0.21f);
            sounds = new List<SoundEffect>();
        }

        public Phone(float startPosX, SoundEffect sound)
            : base(Image.Object.Phone, .033f, 0, Vector2.Zero, sound)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - Game1.View.Height * 0.21f);
        }
        public Phone(float startPosX, List<SoundEffect> sounds, bool loop = false)
            : base(Image.Object.Phone, .033f, 0, Vector2.Zero, null)
        {
            this.Position = new Vector2(startPosX, Game1.View.Height - Game1.View.Height * 0.21f);
            this.sounds = sounds;

            if (!loop)
                sounds.Add(Sound.Dialtone);
        }

        public override void update(GameTime gameTime, Floor floor)
        {
            base.update(gameTime, floor);

            if (sounds == null || sounds.Count == 0)
                return;

            //Show message
            if (Input.actionBarPressed())
            {
                sounds[clickCount].Play();

                clickCount++;

                if (loop)
                    clickCount %= sounds.Count;
                else
                    clickCount = sounds.Count - 1;

            }


        }
    }
}
