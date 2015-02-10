using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Text;
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

        static string message = "";
        static List<byte> coordinates = new List<byte>();

        public static MessageBox mBox
        {
            get;
            protected set;
        }

        Vector2 testPos = new Vector2(400, 240);
        Lightmap map;
        SoundComponent sound;

        LightComponent lights;

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        static TcpClient clientSocket = new TcpClient();

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

        static Server server;
        public static Server CurrentServer
        {
            get { return server; }
        }

        BasePlayer p;

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
            //server = new Server();
            try
            {
                clientSocket = new TcpClient(ServerConstants.IP, ServerConstants.PORT);
            }
            catch (Exception e)
            {
            }
            camera = new Camera2D(this);
            Components.Add(camera);
            lights = new LightComponent(this);
            //Components.Add(lights);
            sound = new SoundComponent(this);
            Components.Add(sound);

            mBox = new MessageBox();

            Thread tServerRead = new Thread(new ThreadStart(ReadServer));
            tServerRead.Start();
            //Thread tServerWrite = new Thread(new ThreadStart(SendMessage));
            //tServerWrite.Start();
            base.Initialize();

            p = new BasePlayer(Image.Fighter, .07f, Vector2.Zero);
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

            if (Input.actionBarPressed())
                hideMessage();

            message += Input.getRecentKeys();

            Game1.Camera.Focus = new Vector2(p.Rec.Center.X, p.Rec.Center.Y);
            Game1.Camera.MoveSpeed = p.Speed;

            mBox.update(gameTime);
            p.update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp,
                DepthStencilState.Default, rs, null, Game1.Camera.Transform);

            spriteBatch.Draw(Image.Particle, new Rectangle(0, 0, 420, 240), Color.Red);
            if(coordinates.Count >= 2)
                spriteBatch.DrawString(Fonts.Normal, "Here", new Vector2(coordinates[coordinates.Count - 2], 
                    coordinates[coordinates.Count - 1]), Color.White);

            p.draw(spriteBatch);

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

        public void ReadServer()
        {
            NetworkStream server = default(NetworkStream);
            string returnData = "";
            while (Game1.Active)
            {
                try
                {
                    server = clientSocket.GetStream();
                    int buffSize = clientSocket.ReceiveBufferSize;
                    byte[] inStream = new byte[buffSize];
                    server.Read(inStream, 0, buffSize);
                    returnData += Encoding.ASCII.GetString(inStream);
                    message = Encoding.ASCII.GetString(inStream);
                    message = message.Trim('\0');
                    returnData = returnData.Trim('\0');
                    message = message.Replace("\"", "");
                    try
                    {
                       
                    }
                    catch (Exception e)
                    { }
                    int l = message.Length;
                }
                catch (Exception e)
                {
                    passMessage(e.Message);
                }
                Thread.Sleep(16);
            }
        }

        public static void SendMessage()
        {
            NetworkStream serverStream = default(NetworkStream);
            while (Game1.Active)
            {
                try
                {
                    serverStream = clientSocket.GetStream();
                    byte[] outStream = Encoding.ASCII.GetBytes(message);
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                }
                catch (Exception e)
                {
                    passMessage(e.Message);
                }

                Thread.Sleep(5000);
            }
        }
    }
}