using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TopDownAdventure
{
    class Tileset
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public int Tilesize { get; set; }
        public Texture2D Image
        {
            get
            {
                return image;
            }
        } 

        string path;
        Texture2D image;

        public Tileset(int rows, int cols, int tilesize, string path)
        {
            Rows = rows;
            Cols = cols;
            Tilesize = tilesize;
            this.path = path;
        }

        public void Load(ContentManager content)
        {
            image = content.Load<Texture2D>(path);
        }
    }
}
