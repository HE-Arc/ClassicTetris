using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using ClassicTetris.Inputs;
using System.Collections.Generic;

namespace ClassicTetris.Menus
{
	public class CongratulationMenu : IMenus
    {
        #region attributes
        private readonly Tetris tetris;
        private readonly int score;
        private readonly int level;
        private readonly IMenus nextMenu;

		private int frameCount;
		private int selectedIndexCharCursor;
        #endregion

        #region draw
        private SpriteBatch sb;
        private Texture2D bg;
        private Texture2D textureSelection;
        private SpriteFont font;
        #endregion

        #region consts
        private readonly Color blinkColor = new Color(252, 116, 96);
        private const int sizeTextureSelection = 45;
        private const int scoreOffsetX = 318;
        private const int scoreOffsetY = 600;
        private const int scoreSpacing = 60;
        #endregion


		private int[] selectedIndexChar;

        //possibles chars, the first is the one displayed
        public const string POSSIBLE_CHARS = "-ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789,/()\". ";
        
        /// <summary>
        /// Create a congratulation menu
        /// </summary>
        /// <param name="tetris"></param>
        /// <param name="score"></param>
        /// <param name="level"></param>
        /// <param name="nextMenu"></param>
		public CongratulationMenu(Tetris tetris, int score, int level, IMenus nextMenu)
        {
			this.frameCount = 0;
			this.tetris = tetris;
            this.score = score;
            this.level = level;
			this.nextMenu = nextMenu;
			this.selectedIndexCharCursor = 0;
			this.selectedIndexChar = new int[6];
			for (int i = 0; i < selectedIndexChar.Length; i++)
			{
				this.selectedIndexChar[i] = 0;
			}
        }

        /// <summary>
        /// Draw the menu with selection
        /// </summary>
        /// <param name="gameTime"></param>
		public void Draw(GameTime gameTime)
		{
			sb.Begin();
			sb.Draw(bg, Vector2.Zero, Color.White);


			List<ScoreEntry> scores = Scores.Instance.GetTopScores();

			bool isIt = false;

            for (int i = 0; i < Math.Min(3, scores.Count); i++)
			{
				int score_i;
				int level_i;
                ScoreEntry scoreEntry = scores[i];

                Vector2 pos = new Vector2(scoreOffsetX, scoreOffsetY + i * scoreSpacing);

				if (this.score >= scoreEntry.Score && !isIt)
				{
					for (int j = 0; j < selectedIndexChar.Length; j++)
					{
						sb.DrawString(font, "" + POSSIBLE_CHARS[selectedIndexChar[j]], pos, Color.White);

						if (j == selectedIndexCharCursor && (frameCount % 4) / 2 == 0)
						{
							sb.Draw(textureSelection, new Vector2(pos.X - 5, pos.Y), Color.White);
						}
                        pos.X += 33;
					}
					isIt = true;

					score_i = this.score;
					level_i = this.level;
				}
				else
				{
					sb.DrawString(font, scoreEntry.Name, pos, Color.White);
					pos.X += 198;
					score_i = scoreEntry.Score;
					level_i = scoreEntry.Level;
				}

				sb.DrawString(font, ("" + score_i).PadLeft(6, '0'), pos, Color.White);
                pos.X += 220;
				sb.DrawString(font, ("" + level_i).PadLeft(2, '0'), pos, Color.White);
            }

            sb.End();
		}
        
        /// <summary>
        /// Do nothing
        /// </summary>
		public void Initialize()
		{
			//
		}

		public void LoadContent(ContentManager Content, GraphicsDevice graphicDevice)
		{
			sb = new SpriteBatch(graphicDevice);
			bg = Content.Load<Texture2D>("Textures/congratulationMenu");
            font = Content.Load<SpriteFont>("Fonts/classic_tetris_font");

			textureSelection = new Texture2D(sb.GraphicsDevice, sizeTextureSelection, sizeTextureSelection);
            Color[] data = new Color[sizeTextureSelection * sizeTextureSelection];
            Color color = new Color(255, 127, 0, 127);
            for (int k = 0; k < data.Length; ++k) data[k] = color;
			textureSelection.SetData(data);
		}

        /// <summary>
        /// Get ride of the loaded content
        /// </summary>
		public void UnloadContent()
        {
            bg.Dispose();
            textureSelection.Dispose();
        }

        /// <summary>
        /// Handle moves in this menu
        /// </summary>
        /// <param name="gameTime"></param>
		public void Update(GameTime gameTime)
		{
			frameCount += 1;
			if (Actions.GetInstance()[Inputs.Action.Left].IsPressed())
			{
                selectedIndexCharCursor = TetrisMath.mod(selectedIndexCharCursor - 1, selectedIndexChar.Length);
			}

			if (Actions.GetInstance()[Inputs.Action.Right].IsPressed())
            {
				selectedIndexCharCursor = TetrisMath.mod(selectedIndexCharCursor + 1, selectedIndexChar.Length);
            }

			if (Actions.GetInstance()[Inputs.Action.Up].IsPressed())
            {
				selectedIndexChar[selectedIndexCharCursor] = TetrisMath.mod(selectedIndexChar[selectedIndexCharCursor] + 1, POSSIBLE_CHARS.Length);
            }

			if (Actions.GetInstance()[Inputs.Action.Down].IsPressed())
            {
                selectedIndexChar[selectedIndexCharCursor] = TetrisMath.mod(selectedIndexChar[selectedIndexCharCursor] - 1, POSSIBLE_CHARS.Length);
            }
            
			if (Actions.GetInstance()[Inputs.Action.Start].IsPressed())
            {
				ScoreEntry scoreEntry = new ScoreEntry(IndicesToString(), score, level);
				Scores.Instance.AddScore(scoreEntry);
				tetris.ChangeMenu(nextMenu);
            }

		}

        private string IndicesToString()
		{
			string name = "";
            for (int i = 0; i < selectedIndexChar.Length; i++)
            {
                name += POSSIBLE_CHARS[selectedIndexChar[i]];
            }
			return name;
		}
	}
}
