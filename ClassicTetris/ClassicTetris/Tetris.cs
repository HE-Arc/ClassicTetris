using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ClassicTetris.Inputs;
using ClassicTetris.Audio;
using ClassicTetris.Menus;

namespace ClassicTetris
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Tetris : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Renderer renderer;
		Menu currentMenu;

        public Tetris()
        {
			currentMenu = Menu.Game;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1025;
            graphics.PreferredBackBufferHeight = 895;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AudioManager.GetInstance().Load(Content);
			//AudioManager.GetInstance().Play(Music.Theme1);
            renderer = new Renderer(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
			Actions.GetInstance().Update(Keyboard.GetState());

			if(Actions.GetInstance()[Action.Left].IsPressed())
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
                Exit();
			}
			if (Actions.GetInstance()[Action.Debug].IsPressed())
            {
				//board.Tick();
                GameLogic.Instance.Tick();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            renderer.DrawScene(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
