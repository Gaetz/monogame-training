using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Pong
{
    public class Paddle
    {
        Texture2D texture;
        Rectangle rect;
        int speed;
        int screenHeight;

        public Paddle(int x, int y, int speed, int screenHeight)
        {
            rect = new Rectangle(x, y, 32, 128);
            this.speed = speed;
            this.screenHeight = screenHeight;
        }

        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("images/paddle");
        }

        public virtual void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            double delta = gameTime.ElapsedGameTime.TotalSeconds;

            if (ks.IsKeyDown(Keys.Down))
            {
                rect.Y += (int)(speed * delta);
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                rect.Y -= (int)(speed * delta);
            }
            if (rect.Y < 0)
            {
                rect.Y = 0;
            }
            if (rect.Y > screenHeight - 128)
            {
                rect.Y = screenHeight - 128;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, Color.White);
        }
    }
}
