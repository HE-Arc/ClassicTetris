using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ClassicTetris.Inputs;
using ClassicTetris.Audio;
using ClassicTetris.Renderer;
using ClassicTetris.Menus;
using System.Collections.Generic;
using System;

namespace ClassicTetris
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Tetris : Game
    {
		private IMenus currentMenu;

        /// <summary>
        /// Constructor
        /// </summary>
        public Tetris()
        {
            GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Settings.WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = Settings.WINDOW_HEIGHT;
            Content.RootDirectory = "Content";
        }
        
        /// <summary>
        /// Initialisation of the app
        /// </summary>
        protected override void Initialize()
        {
			ChangeMenu(new CreditMenu(this));
            base.Initialize();
        }

        /// <summary>
        /// Load assets for the game
        /// </summary>
        protected override void LoadContent()
        {
			AudioManager.GetInstance().Load(Content);
			base.LoadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
			base.Update(gameTime);
            Actions.GetInstance().Update(Keyboard.GetState());
            currentMenu.Update(gameTime);
        }

        /// <summary>
        /// Main function called when need to draw
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
			currentMenu.Draw(gameTime);
        }

        /// <summary>
        /// Switch menu
        /// </summary>
        /// <param name="menu">New menu</param>
		public void ChangeMenu(IMenus menu)
		{
			currentMenu?.UnloadContent(); // ?. to avoid crash on the first menu load
            currentMenu = menu;
			currentMenu.Initialize();
			currentMenu.LoadContent(Content, GraphicsDevice);
		}
    }
}
