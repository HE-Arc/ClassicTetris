using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace ClassicTetris
{
    public class Actions
    {

        private static readonly Dictionary<Action, Bind> Binds = new Dictionary<Action, Bind>();

        /// <summary>
        /// Create every actions with the possibles inputs
        /// </summary>
        static Actions()
        {
			// Possible input with the keyboard
			Binds[Action.Left] = new Bind(Keys.Left, Keys.A);
            Binds[Action.Right] = new Bind(Keys.Right, Keys.D);
			Binds[Action.Down] = new Bind(Keys.Down, Keys.S);
			Binds[Action.Rotate] = new Bind(Keys.Up, Keys.W);
			Binds[Action.ForceDown] = new Bind(Keys.Space);
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
