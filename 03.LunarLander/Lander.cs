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

        float x;
        float y;
        float rotation;
        float vx;
        float vy;
        float propulsion = 10f;
        float gravity = 98.1f;
        float rotateSpeed = 2f;
        bool isFireOn;
        Texture2D image;
        Texture2D fireImage;

        public void Load(ContentManager Content)
        {
            image = Content.Load<Texture2D>("lander");
            fireImage = Content.Load<Texture2D>("lander-fire");
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                isFireOn = true;
                double xForce = Math.Cos(rotation) * propulsion;
                double yForce = Math.Sin(rotation) * propulsion;
                vx += (float)xForce;
                vy += (float)yForce;
            }
            else
            {
                isFireOn = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                rotation += rotateSpeed * dt;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                rotation -= rotateSpeed * dt;
            }

            vy += gravity * dt;
            x += vx * dt;
            y += vy * dt;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle((int)Math.Round(x), (int)Math.Round(y), image.Width, image.Height);
            Rectangle fireRect = new Rectangle((int)Math.Round(x), (int)Math.Round(y), fireImage.Width, fireImage.Height);
            spriteBatch.Draw(image, rect, null, Color.White, rotation, new Vector2(rect.Width / 2, image.Height / 2), SpriteEffects.None, 0);
            if(isFireOn)
                spriteBatch.Draw(fireImage, fireRect, null, Color.White, rotation, new Vector2(rect.Width / 2, image.Height / 2), SpriteEffects.None, 0);
        }
    }
}
