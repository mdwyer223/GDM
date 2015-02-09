using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace CKB
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SoundComponent : Microsoft.Xna.Framework.GameComponent
    {
        static Song currentSong;
        static float timer, timeTillSound;
        static int minTime, maxTime;
        Random rand = new Random();

        public SoundComponent(Game game)
            : base(game)
        {
            minTime = 16;
            maxTime = 45;
            timeTillSound = rand.Next(minTime, maxTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (currentSong != null)
            {
                if (MediaPlayer.State == MediaState.Playing)
                    MediaPlayer.Resume();
                else if (MediaPlayer.State == MediaState.Stopped)
                    MediaPlayer.Play(currentSong);
            }

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= timeTillSound)
            {
                //random sound
                switch (rand.Next(7))
                {
                    case 0:
                        Sound.CreepyRun1.Play();
                        break;
                    case 1:
                        Sound.Exhale.Play();
                        break;
                    case 2:
                        Sound.Laugh1.Play();
                        break;
                    case 3:
                        Sound.Shuffling1.Play();
                        break;
                    case 4:
                        Sound.Scratch.Play(.5f, 0, 0);
                        break;
                    case 5:
                        Sound.SmallGiggle.Play(.5f, 0, 0);
                        break;
                    case 6:
                        Sound.Creepy.Play();
                        break;
                }
                timer = 0;
                timeTillSound = rand.Next(minTime, maxTime);
            }
            base.Update(gameTime);
        }

        public static void playEffect(SoundEffect effect)
        {
            if (effect != null)
                effect.Play();
        }

        public static void playEffect(SoundEffect effect, float volume)
        {
            if (effect != null)
                effect.Play(volume, 0f, 0f);
        }

        public static void increaseFrequency()
        {
            minTime = 2;
            maxTime = 5;
            timer = 999;
        }

        public static void decreaseFrequency()
        {
            minTime = 16;
            maxTime = 45;
            timer = 0;
        }
    }
}
