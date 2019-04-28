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
        #region attributs
        private readonly Tetris tetris;
        #endregion

        #region draw
        private SpriteBatch sb;
        private Texture2D bg;
        #endregion

        /// <summary>
        /// Create the menu
        /// </summary>
        /// <param name="tetris"></param>
        public PressStartMenu(Tetris tetris)
        {
            this.tetris = tetris;
        }

        /// <summary>
        /// Draw the menu
        /// </summary>
        /// <param name="gameTime"></param>
        public void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(bg, Vector2.Zero, Color.White);
            sb.End();
        }

        /// <summary>
        /// Initialize nothing
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// Load the backgorund
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="graphicDevice"></param>
        public void LoadContent(ContentManager Content, GraphicsDevice graphicDevice)
        {
            sb = new SpriteBatch(graphicDevice);
            bg = Content.Load<Texture2D>("Textures/pressStartMenu");
        }

        /// <summary>
        /// Unload nothing
        /// </summary>
        public void UnloadContent()
        {
            bg.Dispose();
        }

        /// <summary>
        /// Handle the controls
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
			if (Actions.GetInstance()[Inputs.Action.Start].IsPressed())
            {
				tetris.ChangeMenu(new GameTypeMenu(tetris));
            }
        }
    }
}
