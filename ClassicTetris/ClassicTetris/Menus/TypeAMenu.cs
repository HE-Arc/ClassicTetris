using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris.Menus
{
    class TypeAMenu : IMenus
    {
        private Tetris tetris;
        private SpriteBatch sb;
        private Texture2D bg;

		private Texture2D rect;

		private int level;
		private MusicType musicType;
		private const int maxmenu = 10;
		private const int sizeX = 55;
        private const int sizeY = sizeX;

		private const int offsetX = 213;
		private const int offsetY = 305;
		private const int border = 9;

		private int frameCount = 0;

		public TypeAMenu(Tetris tetris, int level, MusicType musicType)
        {
            this.tetris = tetris;
			this.level = level;
			this.musicType = musicType;
        }

        public void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(bg, Vector2.Zero, Color.White);

			if (frameCount % 2 == 0)
			{
				int x = offsetX + (sizeX + border) * (level % (maxmenu / 2));
				int y = offsetY + (sizeX + border) * (level / (maxmenu / 2));
				sb.Draw(rect, new Vector2(x, y), Color.White);
			}
            
            sb.End();
        }

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager Content, GraphicsDevice graphicDevice)
        {
            sb = new SpriteBatch(graphicDevice);
            bg = Content.Load<Texture2D>("Textures/typeAMenu");


			rect = new Texture2D(sb.GraphicsDevice, sizeX, sizeY);
			Color[] data = new Color[sizeX * sizeY];
            Color color = new Color(255, 127, 0, 127);
            for (int k = 0; k < data.Length; ++k) data[k] = color;
            rect.SetData(data);
        }
              
        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
			frameCount += 1;

            if (Actions.GetInstance()[Inputs.Action.MenuValidate].IsPressed())
            {
				//set level
				tetris.ChangeMenu(new GameMenu(tetris, level, GameType.TypeA, musicType));
            }

            if (Actions.GetInstance()[Inputs.Action.MenuDown].IsPressed())
            {
				if (level < maxmenu / 2)
                {
					level += maxmenu / 2;
                }
            }
            if (Actions.GetInstance()[Inputs.Action.MenuUp].IsPressed())
            {
				if(level >= maxmenu / 2)
				{
					level -= maxmenu / 2;
				}
            }
            if (Actions.GetInstance()[Inputs.Action.MenuRight].IsPressed())
            {
				level += 1;
				level %= maxmenu;
            }
            if (Actions.GetInstance()[Inputs.Action.MenuLeft].IsPressed())
            {
				level -= 1;
				level = TetrisMath.mod(level, maxmenu);
            }

        }
    }
}
