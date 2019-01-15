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
        public AIPaddle(int x, int y, int speed, int screenHeight) : base(x, y, speed, screenHeight)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            double delta = gameTime.ElapsedGameTime.TotalSeconds;

        }
    }
}
