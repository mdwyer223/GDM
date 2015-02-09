using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Net.Sockets;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Solo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

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

        static bool active = true;
        public static bool Active
        {
            get { return active; }
        }

        public void ReadServer()
        {
            while (Game1.Active)
            {
                try
                {
                    TcpClient clientSocket = new TcpClient("127.0.0.1", 34099);
                    NetworkStream server = default(NetworkStream);

                    server = clientSocket.GetStream();
                    byte[] inStream = new byte[10025];
                    int buffSize = clientSocket.ReceiveBufferSize;
                    server.Read(inStream, 0, buffSize);
                    passMessage(System.Text.Encoding.ASCII.GetString(inStream));
                }
                catch (Exception e)
                {
                    passMessage(e.Message);
                }
            }
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
            //Components.Add(lights);
            sound = new SoundComponent(this);
            Components.Add(sound);

            mBox = new MessageBox();

            Thread tServerRead = new Thread(new ThreadStart(ReadServer));
            tServerRead.Start();
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

            Game1.Camera.Focus = Vector2.Zero;
            Game1.Camera.MoveSpeed = 0;

            mBox.update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp,
                DepthStencilState.Default, rs, null, Game1.Camera.Transform);

            spriteBatch.End();

            spriteBatch.Begin();

            mBox.draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);

            spriteBatch.Begin();

            //draw after lighting

            spriteBatch.End();

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
        public static void changeActive()
        {
            active = !active;
        } 
    }
}