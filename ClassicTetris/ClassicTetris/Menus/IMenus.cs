using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ClassicTetris.Menus
{
	public interface IMenus
	{
        void Initialize();
		void LoadContent(ContentManager Content, GraphicsDevice GraphicDevice);
		void UnloadContent();
		void Update(GameTime gameTime);
		void Draw(GameTime gameTime);
        void Start();
        void Stop();
    }
}
