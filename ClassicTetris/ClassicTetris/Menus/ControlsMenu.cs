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
    class ControlsMenu : IMenus
    {
        #region attributs
        private readonly Tetris tetris;
        
        private int frameCount;
        #endregion

        #region draw
        private SpriteBatch sb;
        public Texture2D BG { get; private set; }
        public Texture2D CONTROLS { get; private set; }
        #endregion
        
        public ControlsMenu(Tetris tetris)
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
            int opacity = (int)(Math.Abs(Math.Sin((double)frameCount / 30.0)) * 255);
            DrawRectangle(new Rectangle(300,600,420,110), new Color(0,0, 0, opacity));
            sb.End();
        }

        private static Texture2D rect;

        /// <summary>
        /// https://stackoverflow.com/a/11432298/9263555
        /// </summary>
        /// <param name="coords"></param>
        /// <param name="color"></param>
        private void DrawRectangle(Rectangle coords, Color color)
        {
            if (rect == null)
            {
                rect = new Texture2D(sb.GraphicsDevice, 1, 1);
                rect.SetData(new[] { Color.White });
            }
            sb.Draw(rect, coords, color);
        }

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager Content, GraphicsDevice graphicDevice)
        {
            sb = new SpriteBatch(graphicDevice);
            BG = Content.Load<Texture2D>("Textures/controls");
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
            frameCount += 1;
			if(Actions.GetInstance()[Inputs.Action.Start].IsPressed())
            {
				tetris.ChangeMenu(new CreditMenu(tetris));
            }
        }
    }
}
