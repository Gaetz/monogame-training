using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Pong
{
    public class AIPaddle : Paddle
    {
        Ball ball;

        public AIPaddle(int x, int y, int speed, int screenHeight, Ball ball) : base(x, y, speed, screenHeight)
        {
            this.ball = ball;
        }

        public override void Update(GameTime gameTime)
        {
            double delta = gameTime.ElapsedGameTime.TotalSeconds;
            
            if(ball.Y < rect.Y + rect.Height / 4)
            {
                rect.Y -= (int)(speed * delta);
            }
            if (ball.Y > rect.Y + rect.Height * 3 / 4)
            {
                rect.Y += (int)(speed * delta);
            }
        }
    }
}
