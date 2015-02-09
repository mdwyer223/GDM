using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CKB
{
    public class Light
    {
        Random rand = new Random();
        Vector2 position, startPosition;
        float brightnessFactor = 1, originalBrightness;
        bool isDead, flickering;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool IsDead
        {
            get { return isDead; }
        }

        public bool Distorted
        {
            get;
            set;
        }

        public bool FollowingPlayer
        {
            get;
            protected set;
        }

        public float BrightnessFactor
        {
            get { return brightnessFactor; }
            set { brightnessFactor = value; }
        }

        public Light(Vector2 position, float brightness)
            : base()
        {
            this.position = position;
            startPosition = new Vector2(position.X + 400, position.Y + 240);
            this.brightnessFactor = brightness;
            isDead = false;
        }

        public Light(bool following)
            : base()
        {
            this.FollowingPlayer = true;
            brightnessFactor = .85f;
        }

        public Light(Vector2 position, bool flickering)
        {
            originalBrightness = 1f;
            this.flickering = true;
            this.position = position;
        }

        public virtual void update()
        {
            if (!FollowingPlayer)
            {
                this.position.X = (this.startPosition.X - Game1.Camera.Position.X);
                this.position.Y = (this.startPosition.Y - Game1.Camera.Position.Y);
            }
            else if (flickering)
            {
                brightnessFactor = (float)(originalBrightness * (rand.NextDouble()));
                this.position = new Vector2(Game1.CurrentFloor.Character.Position.X, Game1.CurrentFloor.Character.Position.Y - 50);
                this.position = new Vector2(position.X - Game1.Camera.Position.X + Game1.Camera.Origin.X,
                    position.Y);
            }
            else
            {
                this.position = new Vector2(Game1.CurrentFloor.Character.Position.X, Game1.CurrentFloor.Character.Position.Y - 50);
                this.position = new Vector2(position.X - Game1.Camera.Position.X + Game1.Camera.Origin.X,
                    position.Y);
            }
            if(Distorted)
                brightnessFactor = (float)(rand.NextDouble() *2f);
        }
    }
}
