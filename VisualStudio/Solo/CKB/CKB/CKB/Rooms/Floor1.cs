using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CKB
{
    public class Floor1 : Floor
    {
        public Floor1()
            : base(Image.Floor1.Wall, Vector2.Zero)
        {
            objs.Add(new BrokenElevator(130));
            objs.Add(new Phone(600));
            objs.Add(new FrontDoor(1000));
            objs.Add(new Trash(1700, "foreach (Light l in lights)\n{\nif (l != null)\n{\nl.update();\nif (t.LightPosition.X != -1f)\n{"));
            objs.Add(new StairDoor(2000, 1));

            List<Light> lights = new List<Light>();
            //lights.Add(new Light(new Vector2(100, 240), true));

            LightComponent.passLights(lights);
        }

        public override void update(GameTime gameTime)
        {
            if (Input.escapePressed())
                Game1.changeFloor(new Floor2());
            base.update(gameTime);
        }
    }
}
