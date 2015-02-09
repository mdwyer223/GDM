using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace CKB
{
    class Sound
    {
        public static SoundEffect Trash
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Objects/GarbageSearch"); }
        }

        public static SoundEffect Walking
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Footsteps"); }
        }

        public static SoundEffect Dialtone
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Objects/Dialtone"); }
        }

        public static SoundEffect DoorOpening
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Objects/DoorOpening"); }
        }

        public static SoundEffect Elevator
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Objects/ElevatorBell"); }
        }

        public static SoundEffect Exhale
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Random/Exhale"); }
        }

        public static SoundEffect Laugh1
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Random/laugh1"); }
        }

        public static SoundEffect Scratch
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Random/Scratch"); }
        }

        public static SoundEffect Shriek1
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Shriek1"); }
        }

        public static SoundEffect Shriek2
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Shriek2"); }
        }

        public static SoundEffect Shuffling1
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Random/Shuffling1"); }
        }

        public static SoundEffect CreepyRun1
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Random/CreepyRun1"); }
        }

        public static SoundEffect HeavyBreathing
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/HeavyBreathing"); }
        }

        public static SoundEffect NormalBreathing
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/NormalBreathing"); }
        }

        public static SoundEffect Giggle
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Giggle"); }
        }

        public static SoundEffect SmallGiggle
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Random/SmallGiggle"); }
        }

        public static SoundEffect LoudWhisper
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/LoudWhisper"); }
        }

        public static SoundEffect Whispers
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Objects/Whispers"); }
        }

        public static SoundEffect HighPitchScream
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/HighPitchScream"); }
        }

        public static SoundEffect SmallScream
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/SmallScream"); }
        }

        public static SoundEffect Creepy
        {
            get { return Game1.GameContent.Load<SoundEffect>("Sounds/Random/creepy-sound"); }
        }

        //Different steps sounds
        public class Steps
        {
            public static SoundEffect Step1
            {
                get { return Game1.GameContent.Load<SoundEffect>("Sounds/Steps/concrete-footstep-1"); }
            }
            public static SoundEffect Step2
            {
                get { return Game1.GameContent.Load<SoundEffect>("Sounds/Steps/concrete-footstep-2"); }
            }
            public static SoundEffect Step3
            {
                get { return Game1.GameContent.Load<SoundEffect>("Sounds/Steps/concrete-footstep-3"); }
            }
            public static SoundEffect Step4
            {
                get { return Game1.GameContent.Load<SoundEffect>("Sounds/Steps/concrete-footstep-4"); }
            }
        }
    }
}
