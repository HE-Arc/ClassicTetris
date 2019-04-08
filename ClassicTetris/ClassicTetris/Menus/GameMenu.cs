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
        SpriteBatch spriteBatch;
        GameRenderer renderer;

		Tetris tetris;

		public GameMenu(Tetris tetris)
		{
            this.tetris = tetris;
        }

		public void Initialize()
		{
			
		}

		public void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
		{         
			spriteBatch = new SpriteBatch(GraphicsDevice);
            renderer = new GameRenderer(Content);
            AudioManager.GetInstance().Load(Content);
            AudioManager.GetInstance().Play(Music.Theme1);
		}

		public void UnloadContent()
		{
			
		}

		public void Update(GameTime gameTime)
		{
			if (Actions.GetInstance()[Action.Left].IsPressed())
            {
                GameLogic.Instance.Left();
            }
            if (Actions.GetInstance()[Action.Right].IsPressed())
            {
                GameLogic.Instance.Right();
            }
            if (Actions.GetInstance()[Action.Rotate].IsPressed())
            {
                GameLogic.Instance.Turn();
            }
            if (Actions.GetInstance()[Action.Down].IsDown())
            {
                GameLogic.Instance.Down();
            }
            if (Actions.GetInstance()[Action.ForceDown].IsPressed())
            {
                GameLogic.Instance.Drop();
            }
            if (Actions.GetInstance()[Action.Quit].IsPressed())
            {
                tetris.Exit();
            }
            if (Actions.GetInstance()[Action.Debug].IsPressed())
            {
                GameLogic.Instance.Tick();
            }
		}
      
        public void Draw(GameTime gameTime)
        {
            renderer.DrawScene(spriteBatch);
        }
	}
}
