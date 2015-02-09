using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CKB
{
    public class Girl : MessObject
    {
        public Girl(float startPosX, bool front, bool flip = false)
            : base(Image.Crack.Small, .056f, 0, Vector2.Zero, null, "")
        {
            this.Flip = flip;

            if (front)
                this.texture = Image.Girl.Front;
            else
                this.texture = Image.Girl.Side;

            //Rescale image
            int inDisplayWidth = Game1.View.Width;
            if (texture != null)
            {
                rec.Width = (int)(inDisplayWidth * ScaleFactor + 0.5f);
                float aspectRatio = (float)texture.Width / texture.Height;
                rec.Height = (int)(Rec.Width / aspectRatio + 0.5f);
            }
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public Girl(float startPosX, string mess, bool front)
            : base(Image.Crack.Small, .056f, 0, Vector2.Zero, null, mess)
        {
            if (front)
                this.texture = Image.Girl.Front;
            else
                this.texture = Image.Girl.Side;

            //Rescale image
            int inDisplayWidth = Game1.View.Width;
            if (texture != null)
            {
                rec.Width = (int)(inDisplayWidth * ScaleFactor + 0.5f);
                float aspectRatio = (float)texture.Width / texture.Height;
                rec.Height = (int)(Rec.Width / aspectRatio + 0.5f);
            }
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public Girl(float startPosX, List<string> mess, bool front)
            : base(Image.Crack.Small, .056f, 0, Vector2.Zero, null, mess)
        {
            if (front)
                this.texture = Image.Girl.Front;
            else
                this.texture = Image.Girl.Side;

            //Rescale image
            int inDisplayWidth = Game1.View.Width;
            if (texture != null)
            {
                rec.Width = (int)(inDisplayWidth * ScaleFactor + 0.5f);
                float aspectRatio = (float)texture.Width / texture.Height;
                rec.Height = (int)(Rec.Width / aspectRatio + 0.5f);
            }
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
        }

        public override void update(GameTime gameTime, Floor floor)
        {
            base.update(gameTime, floor);
            if (measureDis(floor.Character) < 210)
            {
                this.IsVisible = false;
            }
        }
    }
}
