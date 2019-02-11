using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander
{
    class Paddle
    {
        int x;
        int y;
        Texture2D image;
        int ox;
        int oy;
        int screenWidth;
        int screenHeight;

        Random random;
        const int MINIMUM_HEIGHT = 300;

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(x - ox, y - oy, image.Width, image.Height);
            }
        }

        public Paddle(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            random = new Random();
        }

        public void Load(ContentManager content)
        {
            image = content.Load<Texture2D>("paddle");
            x = random.Next(image.Width / 2, screenWidth - image.Width / 2);
            y = random.Next(MINIMUM_HEIGHT, screenHeight - image.Height);
            ox = image.Width / 2;
            oy = 0;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle(x, y, image.Width, image.Height);
            spriteBatch.Draw(image, rect, null, Color.White, 0, new Vector2(ox, oy), SpriteEffects.None, 0);
        }

    }
}
