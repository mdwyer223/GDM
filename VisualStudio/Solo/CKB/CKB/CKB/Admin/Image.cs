using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CKB
{
    public static class Image
    {
        public static Texture2D Particle
        {
            get { return Game1.GameContent.Load<Texture2D>("Testing/Particle"); }
        }

        public static Texture2D MessageBox
        {
            get { return Game1.GameContent.Load<Texture2D>("MessBox"); }
        }

        public static Texture2D Elevator
        {
            get { return Game1.GameContent.Load<Texture2D>("elevator"); }
        }

        public static Texture2D ClosedElevator
        {
            get { return Game1.GameContent.Load<Texture2D>("closedElevator"); }
        }

        public static Texture2D Toy
        {
            get { return Game1.GameContent.Load<Texture2D>("toy"); }
        }

        public static Texture2D ToyIdle
        {
            get { return Game1.GameContent.Load<Texture2D>("toyIdle"); }
        }

        //Character imgs
        public class Character
        {
            public static Texture2D Walk
            {
                get { return Game1.GameContent.Load<Texture2D>("Character/cWalkNew1"); }
            }

            public static Texture2D Idle
            {
                get { return Game1.GameContent.Load<Texture2D>("Character/cIdle"); }
            }
        }

        //Girl imgs
        public class Girl
        {
            public static Texture2D Side
            {
                get { return Game1.GameContent.Load<Texture2D>("Girl/sidegirl"); }
            }

            public static Texture2D Front
            {
                get { return Game1.GameContent.Load<Texture2D>("Girl/girl"); }
            }
        }

        //Crack imgs
        public class Crack
        {
            public static Texture2D Small
            {
                get { return Game1.GameContent.Load<Texture2D>("Objects/smallCrack"); }
            }

            public static Texture2D Mid
            {
                get { return Game1.GameContent.Load<Texture2D>("Objects/mediumCrack"); }
            }

            public static Texture2D Large
            {
                get { return Game1.GameContent.Load<Texture2D>("Objects/largeCrack"); }
            }
        }

        //Objects imgs
        public class Object
        {
            public static Texture2D Phone
            {
                get { return Game1.GameContent.Load<Texture2D>("Objects/phone"); }
            }

            public static Texture2D Trash
            {
                get { return Game1.GameContent.Load<Texture2D>("Objects/trash"); }
            }

            public static Texture2D Bear
            {
                get { return Game1.GameContent.Load<Texture2D>("Objects/bearonwall"); }
            }

            public static Texture2D Bucket
            {
                get { return Game1.GameContent.Load<Texture2D>("Objects/bucket"); }
            }

            public static Texture2D FrontDoor
            {
                get { return Game1.GameContent.Load<Texture2D>("Objects/frontdoors"); }
            }

            public static Texture2D LetsPlay
            {
                get { return Game1.GameContent.Load<Texture2D>("Objects/letsplay"); }
            }
        }
        
        //Floor1 imgs ~~ FAKES
        public class Floor1
        {
            public static Texture2D Wall
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor2/wall"); }
            }

            public static Texture2D DoorClose
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor2/close"); }
            }

            public static Texture2D DoorOpen
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor2/open"); }
            }

            public static Texture2D DoorStair
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor2/stair"); }
            }
        }

        //Floor2 imgs
        public class Floor2
        {
            public static Texture2D Wall
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor2/wall"); }
            }

            public static Texture2D DoorClose
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor2/close"); }
            }

            public static Texture2D DoorOpen
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor2/open"); }
            }

            public static Texture2D DoorStair
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor2/stair"); }
            }
        }

        //Floor3 imgs
        public class Floor3
        {
            public static Texture2D Wall
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor3/wall3"); }
            }

            public static Texture2D DoorClose
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor3/close"); }
            }

            public static Texture2D DoorOpen
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor3/open"); }
            }

            public static Texture2D DoorStair
            {
                get {  return Game1.GameContent.Load<Texture2D>("Floor3/stairs"); }
            }
        }

        //Floor4 imgs ~~ FAKES
        public class Floor4
        {
            public static Texture2D Wall
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor4/wall4"); }
            }

            public static Texture2D DoorClose
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor4/door4"); }
            }

            public static Texture2D DoorOpen
            {
                get { return DoorClose; }
            }

            public static Texture2D DoorStair
            {
                get { return Game1.GameContent.Load<Texture2D>("Floor4/stair"); }
            }
        }

        // other images...
    }
}
