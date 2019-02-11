using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LunarLander
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Play : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Lander lander;
        Paddle paddle;
        int outcome;

        UIText rotationUI;
        UIText vxUI;
        UIText vyUI;
        UIText resultUI;

        public Play()
        {
            graphics = new GraphicsDeviceManager(this);
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
            lander = new Lander();
            paddle = new Paddle(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            outcome = -1;
            rotationUI = new UIText(20, 10, "Rotation", "0");
            vxUI = new UIText(20, 40, "H-Speed", "0");
            vyUI = new UIText(20, 70, "V-Speed", "0");
            resultUI = new UIText(20, 100, "", "");

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
            lander.Load(Content);
            paddle.Load(Content);

            rotationUI.Load(Content);
            vxUI.Load(Content);
            vyUI.Load(Content);
            resultUI.Load(Content);
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

            if (outcome == -1)
            {
                lander.Update(gameTime);
                outcome = LandCheck();

                rotationUI.Text = lander.Rotation.ToString();
                vxUI.Text = lander.Vx.ToString();
                vyUI.Text = lander.Vy.ToString();
            }
            else if (outcome == 0)
            {
                resultUI.Text = "Success";
            }
            else if (outcome == 1)
             {
                resultUI.Text = "Failure";
            }

            base.Update(gameTime);
        }

        int LandCheck()
        {
            if (lander.Rect.Intersects(paddle.Rect))
            {
                if (lander.Rect.X >= paddle.Rect.X 
                    && lander.Rect.X + lander.Rect.Width <= paddle.Rect.X + paddle.Rect.Width 
                    && lander.IsLandingOk)
                {
                    return 0; // Landing ok
                }
                else
                {
                    return 1; // Landing ko
                }
            }
            return -1; // No landing
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            lander.Draw(gameTime, spriteBatch);
            paddle.Draw(gameTime, spriteBatch);

            rotationUI.Draw(gameTime, spriteBatch);
            vxUI.Draw(gameTime, spriteBatch);
            vyUI.Draw(gameTime, spriteBatch);
            resultUI.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
