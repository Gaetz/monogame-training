using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TopDownAdventure
{
    class Hero2 : Sprite
    {
        public int Direction { get; set; }

        public Vector2 Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        Vector2 speed;

        const float ACCELERATION = 500;
        const float DECELLERATION = 0.95f;
        const float MAX_SPEED = 400;

        public Hero2(int x, int y, string path) : base(x, y, path)
        {
            speed = new Vector2();
            Direction = 6;
            Visible = true;
        }

        public void Update(GameTime gameTime, Tilemap tilemap)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState ks = Keyboard.GetState();

            int speedX = 0;
            int speedY = 0;
            if (ks.IsKeyDown(Keys.Down))
            {
                Direction = 2;
                Y += 5;
                speedY = 5;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                Direction = 8;
                Y -= 5;
                speedY = -5;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                Direction = 6;
                X += 5;
                speedX = 5;
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                Direction = 4;
                X -= 5;
                speedX = -5;
            }

            // Collision
            bool firstCollision = false;
            bool secondCollision = false;
            float collisionOx = X;
            float collisionOy = Y;

            // Premiere collision
            if (Direction == 6 || Direction == 2)
            {
                collisionOx += image.Width;
                collisionOy += image.Height;
            } 
            int nextTileCol = (int)Math.Floor((collisionOx + speedX) / (float)tilemap.Tileset.Tilesize);
            int nextTileRow = (int)Math.Floor((collisionOy + speedY) / (float)tilemap.Tileset.Tilesize);
            int tile = tilemap.Data[nextTileRow][nextTileCol];
            if (tile == 1)
            {
                firstCollision = true;
            }

            // Seconde collision
            if (Direction == 2)
            {
                collisionOx -= image.Width;
            }
            else if (Direction == 4)
            {
                collisionOy += image.Height;
            }
            else if (Direction == 6)
            {
                collisionOy -= image.Height;
            }
            else if (Direction == 8)
            {
                collisionOx += image.Width;
            }
            nextTileCol = (int)Math.Floor((collisionOx + Speed.X * dt) / (float)tilemap.Tileset.Tilesize);
            nextTileRow = (int)Math.Floor((collisionOy + Speed.Y * dt) / (float)tilemap.Tileset.Tilesize);

            tile = tilemap.Data[nextTileRow][nextTileCol];
            if (tile == 1)
            {
                secondCollision = true;
            }

            // Resolution
            if (firstCollision || secondCollision)
            {
                X += -speedX;
                Y += -speedY;
            }
        }
    }
}
