using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _04.TopDownAdventure
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Hero link;
        List<Projectile> projectiles = new List<Projectile>();
        float cooldownCounter = 0;
        const float COOLDOWN = 0.1f;

        Tileset tileset;
        Tilemap tilemap;

        List<Enemy> enemies = new List<Enemy>();

        int[][] tilemapData = new int[][]
        {
             new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
             new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
             new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
             new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
             new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
             new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
             new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
             new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
             new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
             new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
             new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
             new int[] { 1, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        };

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
            // TODO: Add your initialization logic here
            link = new Hero(100, 100, "hero");
            tileset = new Tileset(1, 3, 40, "tileset");
            tilemap = new Tilemap(tileset, tilemapData);
            
            Enemy enemy0 = new Enemy(400, 200, "enemy");
            Enemy enemy1 = new Enemy(300, 300, "enemy");
            enemies.Add(enemy0);
            enemies.Add(enemy1);

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

            link.Load(Content);
            tilemap.Load(Content);
            foreach (Enemy e in enemies)
            {
                e.Load(Content);
            }

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

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            cooldownCounter += dt;

            // TODO: Add your update logic here
            link.Update(gameTime, tilemap);
            

            KeyboardState ks = Keyboard.GetState();
            if(ks.IsKeyDown(Keys.Space) && cooldownCounter > COOLDOWN)
            {
                Projectile energyWave = new Projectile(link);
                energyWave.Load(Content);
                energyWave.Visible = true;
                projectiles.Add(energyWave);
                cooldownCounter = 0;
            }

            foreach (Projectile p in projectiles)
            {
                p.Update(gameTime);
                foreach (Enemy e in enemies)
                {
                    if (CollisionSprites(e, p))
                    {
                        e.Visible = false;
                        p.Visible = false;
                    }
                }
            }

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if(!enemies[i].Visible)
                {
                    enemies.RemoveAt(i);
                }
            }



            base.Update(gameTime);
        }

        bool CollisionSprites(Sprite e, Sprite p)
        {
            // Si collision
            if (e.Rect.Intersects(p.Rect))
            {
                return true;
            }
            // sinon
            return false;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            tilemap.Draw(gameTime, spriteBatch);

            foreach (Enemy e in enemies)
            {
                e.Draw(gameTime, spriteBatch);
            }

            link.Draw(gameTime, spriteBatch);
            

            foreach (Projectile p in projectiles)
            {
                p.Draw(gameTime, spriteBatch);
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
