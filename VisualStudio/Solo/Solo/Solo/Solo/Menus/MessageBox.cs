using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Solo
{
    public class MessageBox
    {
        private string message;
        Texture2D text;
        Rectangle rec;
        int optionIndex;

        List<MessageOption> options;

        public int OptionIndex
        {
            get { return optionIndex; }
        }

        public Rectangle Rec
        {
            get { return rec; }
            protected set { rec = value; }
        }

        public bool Visible
        {
            get;
            protected set;
        }

        public bool AcceptsInput
        {
            get;
            protected set;
        }

        public MessageBox()
        {
            text = Image.MessageBox;

            rec.Width = (int)(Game1.View.Width * 0.6f);
            rec.Height = (int)(Game1.View.Height * 0.5f);

            rec.X = (int)((Game1.View.Width - rec.Width) / 2);
            rec.Y = (int)((Game1.View.Height - rec.Height) / 2);

            options = new List<MessageOption>();
            message = "";

            //rec = new Rectangle(200, 500, 300, 400);
        }

        public void show(string message)
        {
            Visible = true;
            AcceptsInput = false;
            this.message = (message == null) ? "" : message;
        }
        public void show(string title, List<string> listView)
        {
            Visible = true;
            AcceptsInput = true;
            message = (title == null) ? "" : title;

            //init options
            foreach (string str in listView)
                options.Add(new MessageOption(this, str));

            //position options
            int startY = (int)(Rec.Y + Rec.Height * 0.1f);
            int opHeight = (int)(Rec.Height * 0.1f);
            for (int i = 0; i < options.Count; i++)
            {
                options[i].rec.Y = startY + opHeight * i;
            }
        }

        public void hide()
        {
            Visible = false;
            AcceptsInput = false;
            message = "";
            options = new List<MessageOption>();
        }

        public void update(GameTime gameTime)
        {
            if (Input.actionBarPressed())
                this.hide();

            if (AcceptsInput)
            {
                if (Input.upPressed())
                    optionIndex--;
                if (Input.downPressed())
                    optionIndex++;

                optionIndex = optionIndex % options.Count;
                if (optionIndex < 0)
                    optionIndex = options.Count - 1;

                for (int i = 0; i < options.Count; i++)
                {
                    if (optionIndex == i)
                        options[i].Hover = true;
                    else
                        options[i].Hover = false;

                    options[i].update(this);
                }
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(text, rec, Color.White);
                spriteBatch.DrawString(Fonts.Normal, message, new Vector2(rec.X, rec.Y), Color.White);

                foreach (MessageOption op in options)
                    op.draw(spriteBatch);
            }
        }
    }
}
