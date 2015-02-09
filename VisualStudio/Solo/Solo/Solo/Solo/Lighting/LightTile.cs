using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Solo
{
    public class LightTile
    {
        Vector2 position;
        Rectangle rec;
        Texture2D blankTexture;
        Color color = Color.Black;
        Light targetLight;
        float brightness = 0f;
        float side; //will become a constant

        public Vector2 Position
        {
            get { return position; }
            protected set
            {
                rec.X = (int)value.X;
                rec.Y = (int)value.Y;
                position.Y = value.Y;
                position.X = value.X;
            }
        }

        public Rectangle Rec
        {
            get { return rec; }
        }

        public Vector2 LightPosition
        {
            get
            {
                Vector2 blank = new Vector2(-1,0);
                if (targetLight == null)
                    return blank;
                else
                {
                    return targetLight.Position;
                }
            }
        }

        public LightTile(float sideLength, Vector2 pos)
            : base()
        {
            this.side = sideLength;
            rec = new Rectangle(0, 0, (int)sideLength, (int)sideLength);
            this.Position = pos;
            blankTexture = Image.Particle;
            targetLight = new Light(new Vector2(-800,0), 1f);
        }

        public virtual void update(GameTime gameTime) //needs the lightmap as a resource for lightdistance
        {
            //brightness = .4f * (float)(255f * ((Math.Sqrt((Math.Pow(Input.mousePos().X - (float)rec.Center.X, 2))
            //   + (Math.Pow(Input.mousePos().Y - rec.Center.Y, 2)))) / (side * 25)));

            if (targetLight != null)
            {
                brightness = targetLight.BrightnessFactor * (float)(255f * ((Math.Sqrt((Math.Pow(targetLight.Position.X - (float)rec.Center.X, 2))
                    + (Math.Pow(targetLight.Position.Y - rec.Center.Y, 2)))) / (side * 25)));
            }

            //brightness = (float)(255f * ((Math.Sqrt((Math.Pow((Game1.Camera.Position.X - Game1.Camera.Origin.X) - (float)rec.Center.X, 2))
            //      + (Math.Pow(Game1.Camera.Focus.Y - rec.Center.Y, 2)))) / (side * 25)));
            //brightness = (float)(255f/100 * ((Math.Sqrt((Math.Pow((Game1.Camera.Position.X - Game1.Camera.Origin.X) - (float)rec.Center.X, 2))
            //        + (Math.Pow(Game1.Camera.Focus.Y - rec.Center.Y, 2)))) / (side * 25)));
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(blankTexture, Rec, color * ((float)Math.Abs(brightness) / 255f));
        }

        public void setTarget(Light l)
        {
            this.targetLight = l;
        }

        public bool brighter(Light l)
        {
            if (this.targetLight != null)
            {
                if ((targetLight.BrightnessFactor * (float)(255f * ((Math.Sqrt((Math.Pow(targetLight.Position.X - (float)rec.Center.X, 2))
                    + (Math.Pow(targetLight.Position.Y - rec.Center.Y, 2)))) / (side * 25)))) > (l.BrightnessFactor * (float)(255f * ((Math.Sqrt((Math.Pow(l.Position.X - (float)rec.Center.X, 2))
                    + (Math.Pow(l.Position.Y - rec.Center.Y, 2)))) / (side * 25)))))
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return true;
            }

        }
    }
}
