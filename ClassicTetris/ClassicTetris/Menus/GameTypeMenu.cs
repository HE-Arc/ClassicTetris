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
    class GameTypeMenu : IMenus
    {
        #region attributs
        private readonly Tetris tetris;
        private int frameCount;
        private GameType currentGameType;
        private MusicType currentMusicType;
        #endregion

        #region draw
        private SpriteBatch sb;
        private Texture2D bg;
        private Texture2D arrow_right;
        private Texture2D arrow_left;
        #endregion

        #region static
        private static Dictionary<GameType, Tuple<Vector2, Vector2>> arrowsPositionsGameType;
		private static Dictionary<MusicType, Tuple<Vector2, Vector2>> arrowsPositionsMusicType;

		static GameTypeMenu()
		{
			arrowsPositionsGameType = new Dictionary<GameType, Tuple<Vector2, Vector2>>();
            arrowsPositionsGameType[GameType.TypeA] = new Tuple<Vector2, Vector2>(new Vector2(246, 226), new Vector2(480, 226));
            arrowsPositionsGameType[GameType.TypeB] = new Tuple<Vector2, Vector2>(new Vector2(630, 226), new Vector2(866, 226));
            arrowsPositionsMusicType = new Dictionary<MusicType, Tuple<Vector2, Vector2>>();
            arrowsPositionsMusicType[MusicType.Music1] = new Tuple<Vector2, Vector2>(new Vector2(406, 546), new Vector2(706, 546));
            arrowsPositionsMusicType[MusicType.Music2] = new Tuple<Vector2, Vector2>(new Vector2(406, 608), new Vector2(706, 608));
            arrowsPositionsMusicType[MusicType.Music3] = new Tuple<Vector2, Vector2>(new Vector2(406, 676), new Vector2(706, 676));
            arrowsPositionsMusicType[MusicType.OFF] = new Tuple<Vector2, Vector2>(new Vector2(406, 733), new Vector2(706, 733));
		}
        #endregion

        public GameTypeMenu(Tetris tetris)
        {
            this.tetris = tetris;
			frameCount = 0;
			currentGameType = GameType.TypeA;
            SelectMusic(MusicType.Music1);
        }

        /// <summary>
        /// Draw the game
        /// </summary>
        /// <param name="gameTime"></param>
        public void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(bg, Vector2.Zero, Color.White);
			if ((frameCount % 4) / 2 == 0)
			{
				sb.Draw(arrow_left, arrowsPositionsGameType[currentGameType].Item1, Color.White);
				sb.Draw(arrow_right, arrowsPositionsGameType[currentGameType].Item2, Color.White);

				sb.Draw(arrow_left, arrowsPositionsMusicType[currentMusicType].Item1, Color.White);
				sb.Draw(arrow_right, arrowsPositionsMusicType[currentMusicType].Item2, Color.White);
			}
            sb.End();
        }

        /// <summary>
        /// Initialize nothing, pretty cool huh ?
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// Load draw content
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="graphicDevice"></param>
        public void LoadContent(ContentManager Content, GraphicsDevice graphicDevice)
        {
            sb = new SpriteBatch(graphicDevice);
            bg = Content.Load<Texture2D>("Textures/gameTypeMenu");
            arrow_right = Content.Load<Texture2D>("Textures/arrow_right");
            arrow_left = Content.Load<Texture2D>("Textures/arrow_left");
        }

        /// <summary>
        /// Unload nothing
        /// </summary>
        public void UnloadContent()
        {
        }

        /// <summary>
        /// Sekect music
        /// </summary>
        /// <param name="music"></param>
        public void SelectMusic(MusicType music)
        {
            currentMusicType = music;
            AudioManager.GetInstance().Play(music);
        }

        /// <summary>
        /// Handle controls
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
			frameCount += 1;
			if (Actions.GetInstance()[Inputs.Action.Start].IsPressed())
            {
				if (currentGameType == GameType.TypeA)
				{
					tetris.ChangeMenu(new TypeAMenu(tetris, 0));
				}

				if (currentGameType == GameType.TypeB)
                {
                    //tetris.ChangeMenu(new TypeBMenu(tetris, currentMusicType));
                }
            }

			if (Actions.GetInstance()[Inputs.Action.Select].IsPressed())
            {
				tetris.ChangeMenu(new PressStartMenu(tetris));
            }

			if (Actions.GetInstance()[Inputs.Action.Down].IsPressed())
            {
                SelectMusic((MusicType)TetrisMath.mod((int)currentMusicType + 1, Enum.GetNames(typeof(MusicType)).Length));
            }
            if (Actions.GetInstance()[Inputs.Action.Up].IsPressed())
            {
                SelectMusic((MusicType)TetrisMath.mod((int)currentMusicType - 1, Enum.GetNames(typeof(MusicType)).Length));
            }
			if (Actions.GetInstance()[Inputs.Action.Right].IsPressed())
            {
                currentGameType = (GameType)TetrisMath.mod((int)currentGameType + 1, Enum.GetNames(typeof(GameType)).Length);
            }
			if (Actions.GetInstance()[Inputs.Action.Left].IsPressed())
            {
                currentGameType = (GameType)TetrisMath.mod((int)currentGameType - 1, Enum.GetNames(typeof(GameType)).Length);
            }
        }
    }
}
