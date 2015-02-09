using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Solo
{
    public class MessageOption
    {
        string mess;
        public Rectangle rec;
        private Color color;
        bool hover;
        
        public bool Selected
        {
            get;
            set;
        }

        public bool Hover
        {
            get
            {
                return hover;
            }
            set
            {
                hover = value;
                if (!value)
                    color = Color.Black;
                else
                    color = Color.Gray;
            }
        }

        public MessageOption(MessageBox messBox, string mess)
        {
            this.mess = mess;
            Hover = false;

            rec.Width = (int)(messBox.Rec.Width * 0.9f);
            rec.Height = (int)(messBox.Rec.Height * 0.1f);

            rec.X = (int)(messBox.Rec.X + messBox.Rec.Width * 0.05f);
            //rec.Y = (int)(messBox.Rec.Y + messBox.Rec.Height * 0.1f);
        }

        public void update(MessageBox box)
        {
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image.Particle, rec, color);
            spriteBatch.DrawString(Fonts.Normal, mess, new Vector2(rec.X, rec.Y), Color.White);
        }


    }
}
