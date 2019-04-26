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
		private MusicType musicType;
		private Tetris tetris;

		private bool isPause;

        private const string pauseText = "PAUSE";
		private const Color colorPause = new Color(92, 148, 252);

		public GameMenu(Tetris tetris, int baseLevel, GameType gameType, MusicType musicType)
		{
            this.isPause = false;
			this.tetris = tetris;
			this.baseLevel = baseLevel;
			this.gameType = gameType;
			this.musicType = musicType;
        }

		public void Initialize()
		{
			AudioManager.GetInstance().Play(musicType);
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
			if (Actions.GetInstance()[Action.Pause].IsPressed())
				isPause ^= true;

			if (isPause)
				return;
			
            //DAS initial delay is 16 frames, and then every 6 frames
			GameLogic.Instance.update();
            if (GameLogic.Instance.GameEnded)
			{
				tetris.ChangeMenu(new TypeAMenu(tetris, baseLevel, musicType));	
			}


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
                downCounter = Settings.DELAY_AUTO_SHIFT_INITIAL;
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

            if (Actions.GetInstance()[Action.Rotate].IsPressed())
            {
                GameLogic.Instance.Turn();
            }

            //TODO: Remove for debug purposes
            if (Actions.GetInstance()[Action.ForceDown].IsPressed())
            {
                GameLogic.Instance.Drop();
            }

            if (Actions.GetInstance()[Action.Quit].IsPressed())
            {
                tetris.Exit();
            }

		}
      
        public void Draw(GameTime gameTime)
        {
			if (isPause)
			{
				spriteBatch.Begin();

				GraphicsDevice gd = spriteBatch.GraphicsDevice;

				gd.Clear(Color.Black);

				Vector2 size = renderer.TetrisFont.MeasureString(pauseText);
				Vector2 pos = new Vector2();
				pos.X = (gd.Viewport.Width - size.X) / 2;
				pos.Y = (gd.Viewport.Height - size.Y) / 2;

				spriteBatch.DrawString(renderer.TetrisFont, pauseText, pos, colorPause);
				spriteBatch.End();
			}
			else
			{
				renderer.DrawScene(spriteBatch);
			}
        }
    }
}
