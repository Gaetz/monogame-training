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
    class Sprite
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Ox { get; set; }
        public float Oy { get; set; }
        public float Rotation { get; set; }
        public bool Visible { get; set; }
        public Color Color { get; set; }

        Texture2D image;
        string path;

        public Vector2 Position
        {
            get
            {
                return new Vector2(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)(X + Ox), (int)(Y + Oy), image.Width, image.Height);
            }
        }

        public byte Opacity
        {
            get
            {
                return Color.A;
            }
            set
            {
                Color = new Color(Color.R, Color.G, Color.B, value);
            }
        }

        public Sprite(int x, int y, string path)
        {
            X = x;
            Y = y;
            this.path = path;
            Color = Color.White;
        }

        public virtual void Load(ContentManager content)
        {
            image = content.Load<Texture2D>(path);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
                spriteBatch.Draw(image, rect, null, Color, Rotation, new Vector2(Ox, Oy), SpriteEffects.None, 0);
            }
        }
    }
}
