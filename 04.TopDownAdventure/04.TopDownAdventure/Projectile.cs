using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TopDownAdventure
{
    class Projectile : Sprite
    {
        int direction;

        public Projectile(Hero hero) : base("projectile_horizontal")
        {
            direction = hero.Direction;
            if (direction == 6)
            {
                X = hero.X + 64;
                Y = hero.Y;
            }
            else if (direction == 4)
            {
                X = hero.X;
                Y = hero.Y;
            }

        }

        public void Update(GameTime gameTime)
        {
            if(direction == 6)
            {
                X = X + 5;
            }
            if(direction == 4)
            {
                X = X - 5;
            }
        }

        
    }
}
