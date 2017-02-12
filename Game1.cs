using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TopDownSports
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Texture2D levelTest;
        //Rectangle levelRect;

        Texture2D playerTexture;

        Texture2D[] testRect = new Texture2D[32];

        Block block;
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Window.AllowUserResizing = true;
            //graphics.IsFullScreen = true;

            this.IsMouseVisible = true;

            block = new Block(testRect);
        }

        protected override void Initialize()
        {
            float myWidth = GraphicsDevice.Viewport.Width;
            float myHeight = GraphicsDevice.Viewport.Height;
            Console.WriteLine(myWidth + " " + myHeight);

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

            //levelTest = Content.Load<Texture2D>("LevelSizeTest");
            //levelRect = new Rectangle(GraphicsDevice.Viewport.Width / 2 - levelTest.Width / 2, GraphicsDevice.Viewport.Height / 2 - levelTest.Height / 2, levelTest.Width, levelTest.Height);
            for(int i = 0; i < testRect.Length; i++)
            {
                testRect[i] = Content.Load<Texture2D>("OtherPlayer");
            }
            player = new Player(testRect[0]);
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

            block.SelectRect();
            player.Update();
            player.UpdateCollision();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            block.Draw(spriteBatch);
            if (block.amountOfBlocksPlaced >= 3)
            {
                player.movementSpeed = 100;
                player.Draw(spriteBatch);
            }
            spriteBatch.Begin();
            //spriteBatch.Draw(levelTest, levelRect, Color.White
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}