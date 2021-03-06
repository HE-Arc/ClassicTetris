﻿using System;
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
        #region attributs
        private Tetris tetris;
        private int frameCount;
        #endregion

        #region draw
        private SpriteBatch sb;
        public Texture2D BG { get; private set; }
        public Texture2D CONTROLS { get; private set; }
        private readonly Color halfWhite = new Color(255, 255, 255, 255);
        #endregion
        
        public CreditMenu(Tetris tetris)
        {
            this.frameCount = 0;
            this.tetris = tetris;
        }

        /// <summary>
        /// Draw it
        /// </summary>
        /// <param name="gameTime"></param>
        public void Draw(GameTime gameTime)
        {
            int w = sb.GraphicsDevice.Viewport.Width;
            int h = sb.GraphicsDevice.Viewport.Height;
            sb.Begin();
            sb.Draw(BG, Vector2.Zero, Color.White);
            sb.End();
        }

        public void Initialize()
        {
        }

        /// <summary>
        /// Load the content
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="graphicDevice"></param>
        public void LoadContent(ContentManager Content, GraphicsDevice graphicDevice)
        {
            sb = new SpriteBatch(graphicDevice);
            BG = Content.Load<Texture2D>("Textures/creditMenu");
        }

        /// <summary>
        /// Unload it
        /// </summary>
        public void UnloadContent()
        {
            BG.Dispose();
        }

        /// <summary>
        /// Wait for the start key to be pressed
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            frameCount += 1;
			if(Actions.GetInstance()[Inputs.Action.Start].IsPressed() || frameCount == 60 * 3)
            {
				tetris.ChangeMenu(new PressStartMenu(tetris));
            }
        }
    }
}
