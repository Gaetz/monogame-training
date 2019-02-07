using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LunarLander
{
    class Lander
    {
        public Lander()
        {
            x = 400;
            y = 0;
            rotation = (float)-Math.PI / 2;
        }

        const float PROPULSION = -180f;
        const float GRAVITY = 98.1f;
        const float ROTATE_SPEED = 1f;

        float x;
        float y;
        float rotation;
        float vx;
        float vy;
        bool isFireOn;
        Texture2D image;
        Texture2D fireImage;

        public void Load(ContentManager content)
        {
            image = content.Load<Texture2D>("lander");
            fireImage = content.Load<Texture2D>("lander-fire");
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                isFireOn = true;
                vx += (float)Math.Cos(rotation) * Math.Abs(PROPULSION) * dt;
                vy += (float)Math.Sin(rotation) * Math.Abs(PROPULSION) * dt;
            }
            else
            {
                isFireOn = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                rotation -= ROTATE_SPEED * dt;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                rotation += ROTATE_SPEED * dt;
            }
            
            vy += GRAVITY * dt;
            x += vx * dt;
            y += vy * dt;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle((int)x, (int)y, image.Width, image.Height);
            spriteBatch.Draw(image, rect, null, Color.White, rotation, new Vector2(rect.Width / 2, image.Height / 2), SpriteEffects.None, 0);

            Rectangle fireRect = new Rectangle((int)x, (int)y, fireImage.Width, fireImage.Height);
            if(isFireOn)
            {
                spriteBatch.Draw(fireImage, fireRect, null, Color.White, rotation, new Vector2(rect.Width / 2, image.Height / 2), SpriteEffects.None, 0);
            }
        }
    }
}
