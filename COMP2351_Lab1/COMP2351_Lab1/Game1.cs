﻿using Microsoft.Xna.Framework;
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
        PongEntity ball1;
        PongEntity paddle1;
        PongEntity paddle2;
        Input KeyInput;


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
            ball1 = new ball();
            paddle1 = new paddle();
            paddle2 = new paddle();
            KeyInput = new Input();

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

            // TODO: use this.Content to load your game content here
            paddle1.SetTexture(Content.Load<Texture2D>("paddle"));
            paddle1.SetLocation(0, (Game1.ScreenHeight / 2) - paddle1.GetTexture().Height / 2);
            paddle2.SetTexture(Content.Load<Texture2D>("paddle"));
            paddle2.SetLocation(Game1.ScreenWidth - paddle2.GetTexture().Width, (Game1.ScreenHeight / 2) - paddle2.GetTexture().Height / 2);
            ball1.SetTexture(Content.Load<Texture2D>("square"));
            ball bBall1 = (ball)ball1;
            bBall1.Serve();
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
            Vector2 _p1Velocity = Input.GetKeyboardInputDirection(PlayerIndex.One);
            Vector2 _p2Velocity = Input.GetKeyboardInputDirection(PlayerIndex.Two);
            
            ball1.Update();
            paddle1.Update(_p1Velocity);
            paddle2.Update(_p2Velocity);
            if (PongEntity.CheckPaddleBallCollision(paddle1, ball1) == true || PongEntity.CheckPaddleBallCollision(paddle2, ball1) == true)
            {
                ball1.InvertVelocityX();
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
                ball1.Draw(spriteBatch);
                paddle1.Draw(spriteBatch);
                paddle2.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
