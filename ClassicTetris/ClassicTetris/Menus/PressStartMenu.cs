using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris.Menus
{
    class PressStartMenu : IMenus
    {
        private SpriteBatch sb;
        private Texture2D bg;
        private Tetris tetris;

        public PressStartMenu(Tetris tetris)
        {
            this.tetris = tetris;
        }

        public void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(bg, Vector2.Zero, Color.White);
            sb.End();
        }

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager Content, GraphicsDevice graphicDevice)
        {
            sb = new SpriteBatch(graphicDevice);
            bg = Content.Load<Texture2D>("Textures/pressStartMenu");
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
			if (Actions.GetInstance()[Inputs.Action.Start].IsPressed())
            {
				tetris.ChangeMenu(new GameTypeMenu(tetris));
            }
        }
    }
}
