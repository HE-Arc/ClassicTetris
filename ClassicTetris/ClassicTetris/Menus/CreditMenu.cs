using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ClassicTetris.Menus
{
    class CreditMenu : IMenus
    {
        private SpriteBatch sb;
        private Texture2D bg;
        private Tetris tetris;

        public CreditMenu(Tetris tetris)
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
            bg = Content.Load<Texture2D>("Textures/creditMenu");
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
			if(Actions.GetInstance()[Inputs.Action.Start].IsPressed())
            {
				tetris.ChangeMenu(new PressStartMenu(tetris));
            }
        }
    }
}
