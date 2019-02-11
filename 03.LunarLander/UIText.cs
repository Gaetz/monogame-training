using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander
{
    class UIText
    {
        string label;
        string text;
        int x;
        int y;
        int ox;
        int oy;
        SpriteFont font;

        public string Text
        {
            set
            {
                text = value;
            }
        }

        public void Load(ContentManager content)
        {
            font = content.Load<SpriteFont>("uiFont");
        }

        public UIText(int x, int y, string label, string defaultText)
        {
            this.x = x;
            this.y = y;
            ox = 0;
            oy = 0;
            this.label = label;
            text = defaultText;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            string labelText = (label == "" ? "" : label + ": ");
            spriteBatch.DrawString(font, labelText + text, new Vector2(x + ox, y + oy), Color.White);
        }
    }
}
