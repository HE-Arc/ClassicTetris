using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassicTetris.Audio;

namespace ClassicTetris.Menus
{
    class TypeAMenu : IMenus
    {
        #region attributs
        private readonly Tetris tetris;
        private int level;
        private int frameCount = 0;
        #endregion

        #region draw
        private SpriteBatch sb;
        private Texture2D bg;
		private SpriteFont font;
		private Texture2D rect;
        #endregion

        #region consts
        private const int maxmenu = 10;
		private const int sizeX = 55;
        private const int sizeY = sizeX;

		private const int offsetX = 213;
		private const int offsetY = 305;
		private const int border = 9;

		private const int scoreOffsetX = 318;
		private const int scoreOffsetY = 600;
		private const int scoreSpacing = 60;
        #endregion

        /// <summary>
        /// Create the type A menu and select the given level
        /// </summary>
        /// <param name="tetris"></param>
        /// <param name="level"></param>
		public TypeAMenu(Tetris tetris, int level)
        {
            this.tetris = tetris;
			this.level = level;
        }

        /// <summary>
        /// Draw the menu
        /// </summary>
        /// <param name="gameTime"></param>
        public void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(bg, Vector2.Zero, Color.White);
			DrawSelection();
			DrawScores();
            sb.End();
        }
      
        /// <summary>
        /// Draw the blinking selection
        /// </summary>
        private void DrawSelection()
        {
            if ((frameCount % 4) / 2 == 0)
            {
                int x = offsetX + (sizeX + border) * (level % (maxmenu / 2));
                int y = offsetY + (sizeX + border) * (level / (maxmenu / 2));
                sb.Draw(rect, new Vector2(x, y), Color.White);
            }
        }

        /// <summary>
        /// Draw the scores
        /// </summary>
		private void DrawScores()
		{
			List<ScoreEntry> scores = Scores.Instance.GetTopScores();
			for (int i = 0; i < Math.Min(3, scores.Count); i++)
			{
				ScoreEntry scoreEntry = scores[i];
				Vector2 pos = new Vector2(scoreOffsetX, scoreOffsetY + i*scoreSpacing);
				sb.DrawString(font, scoreEntry.Name, pos, Color.White);
				pos.X += 200;
				sb.DrawString(font, ("" + scoreEntry.Score).PadLeft(6, '0'), pos, Color.White);
                pos.X += 220;
				sb.DrawString(font, ("" + scoreEntry.Level).PadLeft(2, '0'), pos, Color.White);
			}
		}

        /// <summary>
        /// Initiliaze nothing
        /// </summary>
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
			bg = Content.Load<Texture2D>("Textures/typeAMenu");
			font = Content.Load<SpriteFont>("Fonts/classic_tetris_font");
			rect = new Texture2D(sb.GraphicsDevice, sizeX, sizeY);
			Color[] data = new Color[sizeX * sizeY];
            Color color = new Color(255, 127, 0, 127);
            for (int k = 0; k < data.Length; ++k) data[k] = color;
            rect.SetData(data);
        }
              
        /// <summary>
        /// dispose what should be disposen
        /// </summary>
        public void UnloadContent()
        {
        }

        /// <summary>
        /// Handle controls for the menu selection
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
			frameCount += 1;

			if (Actions.GetInstance()[Inputs.Action.Start].IsPressed())
            {
				//set level
				tetris.ChangeMenu(new GameMenu(tetris, level, GameType.TypeA));
            }

			if (Actions.GetInstance()[Inputs.Action.Select].IsPressed())
            {
				tetris.ChangeMenu(new GameTypeMenu(tetris));
            }

			if (Actions.GetInstance()[Inputs.Action.Down].IsPressed())
            {
				if (level < maxmenu / 2)
                {
					level += maxmenu / 2;
                }
            }
            if (Actions.GetInstance()[Inputs.Action.Up].IsPressed())
            {
				if(level >= maxmenu / 2)
				{
					level -= maxmenu / 2;
				}
            }
			if (Actions.GetInstance()[Inputs.Action.Right].IsPressed())
            {
				level += 1;
				level %= maxmenu;
            }
			if (Actions.GetInstance()[Inputs.Action.Left].IsPressed())
            {
				level -= 1;
				level = TetrisMath.mod(level, maxmenu);
            }

        }
    }
}
