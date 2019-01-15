using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _02.Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Ball ball;
        Paddle leftPaddle;
        AIPaddle rightPaddle;

        public Game1()
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
            ball = new Ball(100, 100, 300, 300, GraphicsDevice.Viewport.Height);
            leftPaddle = new Paddle(0, 100, 200, GraphicsDevice.Viewport.Height);
            rightPaddle = new AIPaddle(GraphicsDevice.Viewport.Width - 32, 300, 200, GraphicsDevice.Viewport.Height, ball);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ball.Load(Content);
            leftPaddle.Load(Content);
            rightPaddle.Load(Content);
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

            double delta = gameTime.ElapsedGameTime.TotalSeconds;
            
            ball.Update(gameTime);
            leftPaddle.Update(gameTime);
            rightPaddle.Update(gameTime);

            BallPaddleCollision();
            BallOutCheck();

            base.Update(gameTime);
        }

        void BallPaddleCollision()
        {
            if (ball.X < leftPaddle.Width)
            {
                if (ball.Y >= leftPaddle.Y && ball.Y <= leftPaddle.Y + leftPaddle.Height)
                {
                    ball.PaddleBounce(leftPaddle.Width);
                }
            }
            if (ball.X + ball.Radius * 2 > rightPaddle.X)
            {
                if (ball.Y >= rightPaddle.Y && ball.Y <= rightPaddle.Y + rightPaddle.Height)
                {
                    ball.PaddleBounce(rightPaddle.X - ball.Radius * 2);
                }
            }
        }

        void BallOutCheck()
        {
            if(ball.X < -ball.Radius || ball.X > GraphicsDevice.Viewport.Width)
            {
                ball.Reset();
            } 
        }
            
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            ball.Draw(gameTime, spriteBatch);
            leftPaddle.Draw(gameTime, spriteBatch);
            rightPaddle.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
