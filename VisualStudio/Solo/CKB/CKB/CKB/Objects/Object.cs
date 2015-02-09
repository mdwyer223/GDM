using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace CKB
{
    public abstract class Object : AnimatedSprite
    {
        protected SoundEffect sound;

        protected string title;
        protected List<string> options;
        protected bool listening;
        
        public Object(Texture2D texture, float scaleFactor, float secondsToCrossScreen, Vector2 startPos, SoundEffect sound)
            : base(texture, scaleFactor, secondsToCrossScreen, startPos)
        {
            title = "";
            options = new List<string>();
            this.sound = sound;
        }

        public sealed override void update(GameTime gameTime)
        {
        }

        public virtual void update(GameTime gameTime, Floor floor)
        {
            base.update(gameTime);
                                    
            //Check if play near by
            if (this == floor.Character.Focus)
            {
                this.color = new Color(185, 185, 185);
                hasFocus(floor);

                //Play sound
                if (Input.actionBarPressed() && sound != null)
                    SoundComponent.playEffect(sound);

            }
            else
                this.color = Color.White;

        }

        protected virtual void hasFocus(Floor floor)
        {
            //Show MessageBox when space pressed
            if (!listening && Input.actionBarPressed() && title != "")
            {
                Game1.passMessage(this.title, this.options);
                listening = true;
            }

            //Check if answer is ready
            if (!Game1.mBox.Visible && listening)
            {
                //React
                respond(floor, Game1.mBox.OptionIndex);
                
                Game1.hideMessage();
                listening = false;
            }      
        }

        protected virtual void respond(Floor floor, int resIndex)
        {
        }
    }
}
