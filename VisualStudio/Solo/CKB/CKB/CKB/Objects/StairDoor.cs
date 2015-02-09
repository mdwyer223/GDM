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
    public class StairDoor : Object
    {
        int floorIndex;

        public StairDoor(float startPosX, int floorIndex)
            : base(Image.Floor2.DoorStair, .205f, 0, Vector2.Zero, Sound.DoorOpening)
        {
            //Select texture
            switch (floorIndex)
            {
                case 1:
                    this.texture = Image.Floor1.DoorStair;
                    break;

                case 2:
                    this.texture = Image.Floor2.DoorStair;
                    break;

                case 3:
                    this.texture = Image.Floor3.DoorStair;
                    break;

                case 4:
                    this.texture = Image.Floor4.DoorStair;
                    break;
            }

            this.floorIndex = floorIndex;
            this.Position = new Vector2(startPosX, Game1.View.Height - this.rec.Height);
            
            options.Add("Up");
            options.Add("Down");
            options.Add("Cancel");
            title = "Up or down?";
        }
        
        protected override void respond(Floor floor, int resIndex)
        {
            string response = options[Game1.mBox.OptionIndex];   
        
            //react to answer
            int add = 0;            
            if (response == "Up")
                add = 1;
            else if (response == "Down")
                add = -1;
            else if (response == "Cancel")
                add = 0;

            switch (floorIndex + add)
            {
                case 1:
                    Game1.changeFloor(new Floor1());
                    break;
                case 2:
                    Game1.changeFloor(new Floor2());
                    break;
                case 3:
                    Game1.changeFloor(new Floor3());
                    break;
                case 4:
                    Game1.changeFloor(new Floor4());
                    break;
            }  
            Game1.hideMessage();
            
        }

    }
}
