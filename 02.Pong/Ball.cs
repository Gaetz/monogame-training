using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Pong
{
    public class Ball
    {
        Texture2D texture;
        Rectangle rect;
        int speedX;
        int speedY;
        int screenHeight;

        public Ball(int x, int y, int speedX, int speedY, int screenHeight)
        {
            rect = new Rectangle(x, y, 64, 64);
            this.speedX = speedX;
            this.speedY = speedY;
            this.screenHeight = screenHeight;
        }

        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("images/ball");
        }

        public virtual void Update(GameTime gameTime)
        {
            double delta = gameTime.ElapsedGameTime.TotalSeconds;
            rect.X = rect.X + (int)(speedX * delta);
            rect.Y = rect.Y + (int)(speedY * delta);

            if (rect.Y < 0)
            {
                rect.Y = 0;
                speedY = -speedY;
            }
            if (rect.Y > screenHeight - 64)
            {
                rect.Y = screenHeight - 64;
                speedY = -speedY;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, Color.White);
        }
    }
}
