using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Solo
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

        public static Texture2D Triangle
        {
            get { return Game1.GameContent.Load<Texture2D>("Testing/Triangle"); }
        }

        public static Texture2D Fighter
        {
            get { return Game1.GameContent.Load<Texture2D>("Testing/FighterJet"); }
        }

        // other images...
    }
}
