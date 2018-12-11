using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace COMP2351_Lab1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int ScreenWidth;
        public static int ScreenHeight;
        public Texture2D paddle;
        public Vector2 paddleLocn;
        public Texture2D ball;
        public Vector2 ballLocn;
        public float mMoveDirection;         // Direction the ball is moving (1: right; -1: left).
        public float mSpeed;
        public Random rng = new Random();
        public Vector2 Angle;
        Vector2 Direction;
        public int bounce = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;
            mMoveDirection = 1;
            mSpeed = 3;
            Angle = new Vector2((float)rng.NextDouble()*360, (float)rng.NextDouble() * 360);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            paddle = Content.Load<Texture2D>("paddle");
            ball = Content.Load<Texture2D>("square");
            ballLocn.X = ScreenWidth / 2;
            ballLocn.Y = ScreenHeight / 2;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;
            
            if(bounce < 4)
            {
                Direction = Vector2.Normalize(Angle);
                ballLocn = ballLocn + mSpeed * Direction;
                if (ballLocn.X > ScreenWidth || ballLocn.X < 0)
                {
                    Angle.X *= -1;
                    bounce++;
                    mSpeed += 3;
                }
                if (ballLocn.Y > ScreenHeight || ballLocn.Y < 0)
                {
                    Angle.Y *= -1;
                    bounce++;
                    mSpeed += 3;
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
                spriteBatch.Draw(paddle, paddleLocn, Color.AntiqueWhite);
                spriteBatch.Draw(ball, ballLocn, Color.AntiqueWhite);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
