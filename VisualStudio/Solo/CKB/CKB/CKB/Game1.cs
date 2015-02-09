using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CKB
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        static Floor f;
        public static MessageBox mBox
        {
            get;
            protected set;
        }

        Vector2 testPos = new Vector2(400, 240);
        Lightmap map;
        SoundComponent sound;
        bool lookingUp = false;

        LightComponent lights;

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        public static Floor CurrentFloor
        {
            get { return f; }
        }

        static GameState mainGameState = GameState.PLAYING;
        public static GameState State
        {
            get { return mainGameState; }
        }

        static Camera2D camera;
        public static Camera2D Camera
        {
            get { return camera; }
        }

        static ContentManager otherContent;
        public static ContentManager GameContent
        {
            get { return otherContent; }
        }

        static GraphicsDevice otherDevice;
        public static GraphicsDevice GameDevice
        {
            get { return otherDevice; }
        }
        public static Viewport View
        {
            get { return otherDevice.Viewport; }

        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            otherContent = new ContentManager(Content.ServiceProvider);
            otherContent.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            otherDevice = this.GraphicsDevice;
            camera = new Camera2D(this);
            Components.Add(camera);
            lights = new LightComponent(this);
            Components.Add(lights);
            sound = new SoundComponent(this);
            Components.Add(sound);
            f = new Floor1();

            mBox = new MessageBox();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            map = new Lightmap(40, 40, 12);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            Game1.Camera.Focus = f.Character.Position;
            Game1.Camera.MoveSpeed = f.Character.Speed;

            mBox.update(gameTime);
            f.update(gameTime);            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp,
                DepthStencilState.Default, rs, null, Game1.Camera.Transform);

            f.draw(spriteBatch);

            spriteBatch.End();

            spriteBatch.Begin();

            mBox.draw(spriteBatch);
            
            spriteBatch.End();
            base.Draw(gameTime);

            spriteBatch.Begin();

            int floorIndex = 0;
            if (f.GetType() == typeof(Floor1))
                floorIndex = 1;
            else if (f.GetType() == typeof(Floor2))
                floorIndex = 2;
            else if (f.GetType() == typeof(Floor3))
                floorIndex = 3;
            else if (f.GetType() == typeof(Floor4))
                floorIndex = 4;


            spriteBatch.DrawString(Fonts.Normal, "Floor: " + floorIndex, Vector2.Zero, Color.White);

            spriteBatch.End();

        }

        public static void changeFloor(Floor newF)
        {
            newF.changePlayer(f.Character);
            f = newF;            
        }

        public static void passMessage(string message)
        {
            mBox = new MessageBox();
            mBox.show(message);
        }
        public static void passMessage(string title, List<string> options)
        {
            mBox = new MessageBox();
            mBox.show(title, options);
        }
        public static void hideMessage()
        {
            mBox.hide();
        }
    }
}
