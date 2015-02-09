using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Solo
{
    public class Floor
    {
        //list of objects
        protected Color color;
        Texture2D background;
        Vector2 position;

        int width, height;

        protected List<Object> objs;

        public Rectangle DrawingRec
        {
            get;
            protected set;
        }

        public Object[] Objects
        {
            get
            {
                return objs.ToArray();
            }
        }

        public MessageBox MessBox
        {
            get;
            private set;
        }

        public Floor(Texture2D background, Vector2 position)
            : base()
        {
            color = Color.White;
            this.background = background;
            this.position = position;

            this.height = (int)(Game1.View.Height * 0.55f);
            float aspectRatio = background.Width / background.Height;
            this.width = (int)(aspectRatio * background.Width);
            if (width >= 5 * Game1.View.Width)
                width = 5 * Game1.View.Width;


            DrawingRec = new Rectangle((int)position.X, (int)Game1.View.Height - this.height, width, height);

            objs = new List<Object>();
            MessBox = new MessageBox();

            
        }

        public virtual void update(GameTime gameTime)
        {
            //updates everything

            foreach (Object obj in objs)
                obj.update(gameTime, this);
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            //draws everything
            spriteBatch.Draw(background, DrawingRec, color);

            foreach (Object obj in objs)
                obj.draw(spriteBatch);
        }
    }
}
