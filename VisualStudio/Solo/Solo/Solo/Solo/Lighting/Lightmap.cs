using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Solo
{
    public class Lightmap
    {
        List<LightTile> tiles = new List<LightTile>();
        int offSetX, offSetY, widthInTiles, heightInTiles, tileSide;

        public Lightmap(int sideLength, int width, int height)
            : base()
        {
            tileSide = sideLength;
            widthInTiles = width;
            heightInTiles = height;

            offSetX = (int)Game1.Camera.Origin.X - (int)Game1.Camera.Position.X;
            offSetY = (int)Game1.Camera.Origin.Y - (int)Game1.Camera.Position.Y;

            for (int x = 0; x < widthInTiles; x++)
            {
                Vector2 placing = new Vector2((x * sideLength), 0);
                for (int y = 0; y < heightInTiles; y++)
                {
                    placing.Y = sideLength * y;
                    tiles.Add(new LightTile(sideLength, placing));
                }
            }
        }

        public virtual void update(GameTime gameTime, List<Light> lights)
        {
            offSetX = (int)Game1.Camera.Origin.X - (int)Game1.Camera.Position.X;
            offSetY = (int)Game1.Camera.Origin.Y - (int)Game1.Camera.Position.Y;

            foreach (LightTile t in tiles)
            {
                foreach (Light l in lights)
                {
                    if (l != null)
                    {
                        l.update();
                        if (t.LightPosition.X != -1f)
                        {
                            if(t.brighter(l))
                            {
                                t.setTarget(l);
                            }
                        }
                        else
                            t.setTarget(l);
                    }
                }
                if (t != null)
                    t.update(gameTime);
            }
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            foreach (LightTile t in tiles)
            {
                if (t != null)
                    t.draw(spriteBatch);
            }
        }

        public float measureDis(Vector2 point1, Vector2 point2)
        {
            return (float)Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }
    }
}
