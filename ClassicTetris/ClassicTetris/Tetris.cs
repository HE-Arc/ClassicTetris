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
        private GraphicsDeviceManager graphics;

		private Dictionary<EMenu, IMenus> menus;
        private EMenu currentMenu;

        public Tetris()
        {
			menus = new Dictionary<EMenu, IMenus>();

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1025;
            graphics.PreferredBackBufferHeight = 895;
			Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            menus[EMenu.CreditMenu] = new CreditMenu(this);
            menus[EMenu.PressStartMenu] = new PressStartMenu(this);
            menus[EMenu.GameTypeMenu] = new GameTypeMenu(this);
            menus[EMenu.TypeAMenu] = new TypeAMenu(this);
            menus[EMenu.Game] = new GameMenu(this);
			ChangeMenu(EMenu.TypeAMenu);
            base.Initialize();
			foreach(KeyValuePair<EMenu, IMenus> menu in menus)
			{
				menu.Value.Initialize();
			}
        }

        protected override void LoadContent()
        {
            base.LoadContent();
			foreach (KeyValuePair<EMenu, IMenus> menu in menus)
            {
				menu.Value.LoadContent(Content, GraphicsDevice);
            }
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
			foreach (KeyValuePair<EMenu, IMenus> menu in menus)
            {
				menu.Value.UnloadContent();
            }
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
            menus[currentMenu].Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
			menus[currentMenu].Draw(gameTime);
        }

		public void ChangeMenu(EMenu menu)
		{
            menus[currentMenu].Stop();
			currentMenu = menu;
            menus[currentMenu].Start();
		}
    }
}
