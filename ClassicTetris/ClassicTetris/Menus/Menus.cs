using System;
using Microsoft.Xna.Framework;

namespace ClassicTetris.Menus
{
	public interface Menus
	{
        void Initialize();
		void LoadContent();
		void UnloadContent();
		void Update(GameTime gameTime);
		void Draw(GameTime gameTime);
    }
}
