using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ClassicTetris.Inputs;
using ClassicTetris.Audio;
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
        GraphicsDeviceManager graphics;

		Dictionary<EMenu, IMenus> menus;
        EMenu currentMenu;

        public Tetris()
        {
			currentMenu = EMenu.Game;
			menus = new Dictionary<EMenu, IMenus>();

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1025;
            graphics.PreferredBackBufferHeight = 895;
			Content.RootDirectory = "Content";
        }

        protected override void Initialize()
		{
            menus[EMenu.MainMenu] = new MainMenu(this);
            menus[EMenu.Game] = new GameMenu(this);
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
			currentMenu = menu;
		}
    }
}
