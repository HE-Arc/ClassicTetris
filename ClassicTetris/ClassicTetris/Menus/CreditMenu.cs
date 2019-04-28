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
        private SpriteBatch sb;
        public Texture2D BG { get; private set; }
        public Texture2D CONTROLS { get; private set; }

        private Tetris tetris;
        private Color halfWhite = new Color(255,255,255, 255);

        public CreditMenu(Tetris tetris)
        {
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

        public void LoadContent(ContentManager Content, GraphicsDevice graphicDevice)
        {
            sb = new SpriteBatch(graphicDevice);
            BG = Content.Load<Texture2D>("Textures/creditMenu");
        }

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
			if(Actions.GetInstance()[Inputs.Action.Start].IsPressed())
            {
				tetris.ChangeMenu(new PressStartMenu(tetris));
            }
        }
    }
}
