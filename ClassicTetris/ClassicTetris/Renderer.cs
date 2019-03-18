using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris
{
    class Renderer
    {
        private Texture2D background;

        public Renderer(ContentManager content)
        {
            LoadContent(content);

        }
        private void LoadContent(ContentManager content)
        {
            background = content.Load<Texture2D>("Textures/tetris_exemple");
        }

        private void drawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
        }

        public void DrawScene(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            {
                drawBackground(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
