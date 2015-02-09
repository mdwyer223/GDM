using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace CKB
{
    public class Toy : Object
    {
        Animation aniWalk;
        SoundEffectInstance shriek;
        bool played = false;

        bool temp;
        float timer;

        public Toy(int startX)
            : base(Image.ToyIdle, 0.05f, 6, Vector2.Zero, null)
        {
            aniWalk = new Animation(Image.Toy, 120, 0.53f);
            //playAnimation(aniWalk);

            this.Position = new Vector2(startX, Game1.View.Height - this.rec.Height);
            
            shriek = Sound.Shriek1.CreateInstance();
            temp = Flip;
        }

        public override void update(GameTime gameTime, Floor floor)
        {
            base.update(gameTime, floor);
            //playAnimation(aniWalk);
            
            //Follow Player
            Velocity = floor.Character.Position - this.Position;
            velocity.Y = 0;
            if (Velocity.X > 0)
            {
                velocity.X = this.Speed;
                temp = true;
            }
            else
            {
                velocity.X = -this.Speed;
                temp = false;
            }

            //this.Position += this.Velocity;

            //Delay the flip
            if (Flip != temp)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timer >= 3)
                {
                    timer = 0;
                    Flip = temp;
                }
            }
            
            //Play sound when close
            if (measureDis(floor.Character) < 300)
            {
                if (!played)
                {
                    shriek.Play();
                    played = true;
                }
            }

        }
    }
}
