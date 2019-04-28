using System.Collections.Generic;
using ClassicTetris.Audio;
using ClassicTetris.Inputs;
using ClassicTetris.Renderer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ClassicTetris.Menus
{
	public class GameMenu : IMenus
    {      
		private SpriteBatch spriteBatch;
        private GameRenderer renderer;      
        private int leftCounter;
        private int rightCounter;
        private int downCounter;

		private int baseLevel;
		private GameType gameType;
		private Tetris tetris;

		private bool isPause;


		public GameMenu(Tetris tetris, int baseLevel, GameType gameType)
		{
            this.isPause = false;
			this.tetris = tetris;
			this.baseLevel = baseLevel;
			this.gameType = gameType;
        }

		public void Initialize()
		{
            GameLogic.Reset(baseLevel, gameType);
		}

		public void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			renderer = new GameRenderer(Content, spriteBatch);
            AudioManager.GetInstance().Load(Content);
		}

		public void UnloadContent()
		{
			AudioManager.GetInstance().Play(MusicType.OFF);
		}

		public void Update(GameTime gameTime)
		{
			if (GameLogic.Instance.GameEnded)
            {
				if (Actions.GetInstance()[Action.Start].IsPressed())
                {
					IMenus menu = new TypeAMenu(tetris, baseLevel);

					int score = GameLogic.Instance.Score;
					int level = GameLogic.Instance.Level;

					List<ScoreEntry> scores = Scores.Instance.GetTopScores();
					int thirdScore = scores[System.Math.Min(2, scores.Count - 1)].Score;

					if(score >= thirdScore)
					{
						tetris.ChangeMenu(new CongratulationMenu(tetris, score, level, menu));
						return;
					}
					tetris.ChangeMenu(menu);
					return;
                }
            }

			if (Actions.GetInstance()[Action.Start].IsPressed())
				isPause ^= true;

			if (isPause)
				return;
			
            //DAS initial delay is 16 frames, and then every 6 frames

			GameLogic.Instance.update();
            

            //Priotity given to right action like in NES
            if (Actions.GetInstance()[Action.Right].IsPressed())
            {
                GameLogic.Instance.Right();
                rightCounter = Settings.DELAY_AUTO_SHIFT_INITIAL;
            }
            else if (Actions.GetInstance()[Action.Right].IsDown())
            {
                --rightCounter;
                if (rightCounter < 0)
                {
                    GameLogic.Instance.Right();
                    rightCounter = Settings.DELAY_AUTO_SHIFT;
                }
            }
            else if (Actions.GetInstance()[Action.Left].IsPressed())
            {
                GameLogic.Instance.Left();
                leftCounter = Settings.DELAY_AUTO_SHIFT_INITIAL;
            }
            else if (Actions.GetInstance()[Action.Left].IsDown())
            {
                --leftCounter;
                if (leftCounter < 0)
                {
                    GameLogic.Instance.Left();
                    leftCounter = Settings.DELAY_AUTO_SHIFT;
                }
            }

            if (Actions.GetInstance()[Action.Down].IsPressed())
            {
                GameLogic.Instance.Down();
                downCounter = Settings.FAST_DROP_GRAVITY;
            }
            else if (Actions.GetInstance()[Action.Down].IsDown())
            {
                --downCounter;
                if (downCounter < 0)
                {
                    GameLogic.Instance.Down();
                    downCounter = Settings.FAST_DROP_GRAVITY;
                }
            }
            
            if (Actions.GetInstance()[Action.B].IsPressed())
            {
                GameLogic.Instance.TurnCCW();
            }
            if (Actions.GetInstance()[Action.A].IsPressed())
            {
                GameLogic.Instance.TurnCW();
            }

            //TODO: Remove for debug purposes
            if (Actions.GetInstance()[Action.Debug].IsPressed())
            {
                GameLogic.Instance.Drop();
            }

			if (Actions.GetInstance()[Action.Shutdown].IsPressed())
            {
                tetris.Exit();
            }
        }
        
        /// <summary>
        /// Draw the game with the renderer
        /// </summary>
        /// <param name="gameTime"></param>
        public void Draw(GameTime gameTime)
        {
			if (isPause)
			{
                renderer.DrawPause(spriteBatch);
			}
			else
			{
				renderer.DrawScene(spriteBatch);
			}
        }
    }
}
