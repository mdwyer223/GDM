using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Solo
{
    public class BasePlayer : AnimatedSprite
    {
        protected float angle;
        private int turnRadius = 20;

        public BasePlayer(Texture2D texture, float scaleFactor, Vector2 start) :
            base(texture, scaleFactor, 3f, start)
        {
            velocity = new Vector2(Speed, 0);
        }

        public override void update(GameTime gameTime)
        {
            if (angle <= 0)
                angle = MathHelper.TwoPi;
            else if (angle > MathHelper.TwoPi)
                angle = 0;
            if (Input.rightDown())
            {
                angle += MathHelper.Pi/(Speed * turnRadius);
            }
            if (Input.leftDown())
            {
                angle -= MathHelper.Pi/(Speed * turnRadius);
            }

            velocity = new Vector2(Speed * (float)Math.Cos(angle), Speed * (float)Math.Sin(angle));

            this.Position += velocity;
            base.update(gameTime);
        }
    }
}
