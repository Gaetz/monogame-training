using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TopDownAdventure
{
    class Hero : Sprite
    {
        Vector2 speed;
        const float ACCELERATION = 500;
        const float DECELLERATION = 0.95f;
        const float MAX_SPEED = 400;

        public Hero(int x, int y, string path) : base(x, y, path)
        {
            Visible = true;
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down))
            {
                speed.Y += ACCELERATION * dt;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                speed.Y -= ACCELERATION * dt;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                speed.X += ACCELERATION * dt;
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                speed.X -= ACCELERATION * dt;
            }
            
            speed *= DECELLERATION;
            

            if (speed.X > 0) speed.X = Math.Min(MAX_SPEED, speed.X);
            if (speed.X < 0) speed.X = Math.Max(-MAX_SPEED, speed.X);
            if (speed.Y > 0) speed.Y = Math.Min(MAX_SPEED, speed.Y);
            if (speed.Y < 0) speed.Y = Math.Max(-MAX_SPEED, speed.Y);

            Position += speed * dt;
        }
    }
}
