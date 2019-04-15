using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TopDownAdventure
{
    class Tilemap
    {
        public Tileset Tileset
        {
            get
            {
                return tileset;
            }
        }

        public int[][] Data
        {
            get
            {
                return data;
            }
        }

        Tileset tileset;
        int[][] data;

        public Tilemap(Tileset tileset, int[][] data)
        {
            this.tileset = tileset;
            this.data = data;
        }

        public void Load(ContentManager content)
        {
            tileset.Load(content);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int r = 0; r < data.Length; r++)
            {
                for (int c = 0; c < data[r].Length ; c++)
                {
                    Rectangle drawRect = new Rectangle(
                        c * tileset.Tilesize, r * tileset.Tilesize, 
                        tileset.Tilesize, tileset.Tilesize
                    );

                    int index = data[r][c];
                    int tilesetCoordX = index % tileset.Cols;
                    int tilesetCoordY = index / tileset.Cols;
                    Rectangle tileRect = new Rectangle(
                        tilesetCoordX * tileset.Tilesize, tilesetCoordY * tileset.Tilesize, 
                        tileset.Tilesize, tileset.Tilesize
                    );

                    spriteBatch.Draw(tileset.Image, drawRect, tileRect, 
                        Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0);
                }
            }
        }


    }
}
