using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

using ClassicTetris.Inputs;

namespace ClassicTetris
{
    public class Actions
    {
		private static Actions Instance = null;

        private static readonly Dictionary<Action, Bind> Binds = new Dictionary<Action, Bind>();

        /// <summary>
        /// Singleton function
        /// </summary>
        /// <returns>The instance.</returns>
        public static Actions GetInstance()
		{
			if(Instance == null)
			{
				Instance = new Actions();
			}
			return Instance;
		}


        /// <summary>
        /// Create every actions with the possibles inputs
        /// </summary>
        private Actions()
        {
			// Possible input with the keyboard
			Binds[Action.Left] = new Bind(Keys.Left, Keys.A);
            Binds[Action.Right] = new Bind(Keys.Right, Keys.D);
			Binds[Action.Down] = new Bind(Keys.Down, Keys.S);
			Binds[Action.Rotate] = new Bind(Keys.Up, Keys.W);
			Binds[Action.ForceDown] = new Bind(Keys.Space);
			Binds[Action.Quit] = new Bind(Keys.Escape);
            Binds[Action.Debug] = new Bind(Keys.Enter);
        }

        /// <summary>
        /// This indexer return the bind for a specific action
        /// </summary>
        /// <param name="action">Action.</param>
		public Bind this[Action action]
		{
			get
			{
				return Binds[action];
			}
		}

        /// <summary>
        /// Update every bind with the specified keyboard state
        /// </summary>
        /// <param name="state">State.</param>
        public void Update(KeyboardState state)
        {
            foreach(Bind bind in Binds.Values)
            {
                bind.Update(state);
            }
        }
    }
}
