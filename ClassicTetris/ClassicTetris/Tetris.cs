using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ClassicTetris.Inputs;
using ClassicTetris.Audio;

namespace ClassicTetris
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Tetris : Game
    {
        private GraphicsDeviceManager graphics;
        private GameLogic gameLogic;
        private SpriteBatch spriteBatch;
        private Renderer renderer;
        private bool isReadyToDraw;
        private int leftCounter;
        private int rightCounter;
        private int downCounter;

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
            renderer = new Renderer(Content, spriteBatch);
            AudioManager.GetInstance().Load(Content);
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
            //DAS initial delay is 16 frames, and then every 6 frames
            GameLogic.Instance.update();
            if (GameLogic.Instance.GameEnded) return;

            Actions.GetInstance().Update(Keyboard.GetState());

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
                    downCounter = Settings.DELAY_AUTO_SHIFT;
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
                Exit();
			}

            //TODO: Remove for debug purposes
            if (Actions.GetInstance()[Action.Debug].IsPressed())
            {
                GameLogic.Instance.Tick();
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
