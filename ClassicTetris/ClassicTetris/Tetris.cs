using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ClassicTetris.Inputs;

namespace ClassicTetris
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Tetris : Game
    {
        GraphicsDeviceManager graphics;
        GameLogic gameLogic;
        SpriteBatch spriteBatch;
        Renderer renderer;
        bool isReadyToDraw;

        public Tetris()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1025;
            graphics.PreferredBackBufferHeight = 895;
            gameLogic = GameLogic.Instance;
            Content.RootDirectory = "Content";
            isReadyToDraw = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            renderer = new Renderer(Content);
            isReadyToDraw = true;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {            
			Actions.GetInstance().Update(Keyboard.GetState());

			if(Actions.GetInstance()[Action.Left].IsPressed())
			{
				GameLogic.Instance.Board.Left();
			}
			else if (Actions.GetInstance()[Action.Right].IsPressed())
            {
                GameLogic.Instance.Board.Right();
            }
			else if (Actions.GetInstance()[Action.Rotate].IsPressed())
            {
                GameLogic.Instance.Board.Turn();
            }
			else if (Actions.GetInstance()[Action.Down].IsPressed())
			{
				
            }
			else if (Actions.GetInstance()[Action.ForceDown].IsPressed())
            {
                GameLogic.Instance.Board.Drop();
			}
			else if (Actions.GetInstance()[Action.Quit].IsPressed())
            {
                Exit();
			}
			else if (Actions.GetInstance()[Action.Debug].IsPressed())
            {
				//board.Tick();
                GameLogic.Instance.Tick();
            }
			else if (Actions.GetInstance()[Action.ForceDown].IsPressed())
            {
                // todo            
			}
			else if (Actions.GetInstance()[Action.Quit].IsPressed())
            {
				Exit();           
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if(isReadyToDraw)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                renderer.DrawScene(spriteBatch);

                base.Draw(gameTime);
            }
        }
    }
}
