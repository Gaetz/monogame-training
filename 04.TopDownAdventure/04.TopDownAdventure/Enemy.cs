using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TopDownAdventure
{
    public class Enemy : Sprite
    {
        public Enemy(int x, int y, string path) : base(x, y, path)
        {
            Visible = true;
        }
    }
}
