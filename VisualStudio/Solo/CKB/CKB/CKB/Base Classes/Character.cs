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
    public class Character : AnimatedSprite
    {

        KeyboardState keys, oldkeys;
        Animation aniWalk, aniIdle;
        SoundEffectInstance walking, breathing, heavyB;

        Random rand;
        int stepIndex = 0;

        public Object Focus
        {
            get;
            private set;
        }

        public Character()
            : base(Image.Character.Walk, 0.15f, 2.5f, Vector2.Zero)
        {
            aniWalk = new Animation(Image.Character.Walk, 350, 0.13f);
            aniIdle = new Animation(Image.Character.Idle, 350, 2f);
            playAnimation(aniIdle);

            this.Position = new Vector2(0, Game1.View.Height - this.Rec.Height);
            Flip = true;
            SoundEffect walk = Sound.Steps.Step1;
            walking = walk.CreateInstance();
            breathing = Sound.NormalBreathing.CreateInstance();
            heavyB = Sound.HeavyBreathing.CreateInstance();

            rand = new Random();
        }

        public void update(GameTime gameTime, Floor floor)
        {
            base.update(gameTime);
            keys = Keyboard.GetState();

            //Play proper breathing sound
            if (floor.GetType() == typeof(Floor1) || floor.GetType() == typeof(Floor2))
            {
                if (breathing.State == SoundState.Stopped)
                    breathing.Play();
                else
                    breathing.Resume();
            }
            else
            {
                if (breathing.State == SoundState.Playing)
                    breathing.Stop();
                if (heavyB.State == SoundState.Stopped)
                    heavyB.Play();
            }

            this.Position += this.velocity;

            velocity = Vector2.Zero;

            //Check for X direction movement--adjust sprite if need
            if ((keys.IsKeyDown(Keys.D) || keys.IsKeyDown(Keys.Right)) &&
                this.Position.X + this.rec.Width < floor.DrawingRec.Width)
            {
                velocity.X = this.Speed;
                Flip = false;
            }
            if ((keys.IsKeyDown(Keys.A) || keys.IsKeyDown(Keys.Left)) &&
                this.Position.X  > floor.DrawingRec.X)
            {
                velocity.X = -this.Speed;
                Flip = true;
            }

            //Play proper animation/walking Sounds
            if (velocity.X == 0)
            {
                playAnimation(aniIdle);
                if (walking.State == SoundState.Playing)
                    walking.Stop();
            }
            else
            {
                if (walking.State == SoundState.Stopped)
                {
                    stepIndex = (stepIndex + 1) % 2;
                    switch (stepIndex)
                    {
                        case 0:
                            walking = Sound.Steps.Step3.CreateInstance();
                            break;
                        case 1:
                            walking = Sound.Steps.Step4.CreateInstance();
                            break;
                    }
                    walking.Play();
                }
                else
                    walking.Resume();
                playAnimation(aniWalk);
            }
            
            //Find closes object
            Focus = null;
            float minDis = floor.DrawingRec.Width;
            int minIndex = -1;

            for (int i = 0; i < floor.Objects.Length; i++)
                if (measureDis(floor.Objects[i]) < minDis)
                {
                    minDis = measureDis(floor.Objects[i]);
                    minIndex = i;
                }

            if (minIndex != -1 && minDis < 150) 
                Focus = floor.Objects[minIndex];

            oldkeys = keys;
        }
    }
}
