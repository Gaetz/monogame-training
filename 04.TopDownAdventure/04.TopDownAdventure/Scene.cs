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
    abstract class Scene
    {
        protected ContentManager content;
        protected Game1 game;

        public delegate void ChangeSceneFunc();
        protected ChangeSceneFunc changeScene;

        public abstract void Load(ContentManager content, Game1 game);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
