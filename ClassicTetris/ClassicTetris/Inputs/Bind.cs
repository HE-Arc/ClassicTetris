using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace ClassicTetris
{
	/// <summary>
	/// Contain a state for a specific action <see cref="T:ClassicTetris.Actions"/> class.
    /// </summary>
    public class Bind
    {
        private readonly Keys[] Keys;
        private bool Current;
        private bool Previous;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClassicTetris.Bind"/> class.
        /// </summary>
        /// <param name="keys">Keys.</param>
        public Bind(params Keys[] keys)
        {
            this.Keys = keys;
            this.Current = false;
            this.Previous = false;
        }

        /// <summary>
        /// Update the bind for this keyboard state
        /// </summary>
        /// <param name="state"></param>
        public void Update(KeyboardState state)
        {
            Previous = Current;
            Current = false;
            foreach (Keys k in Keys)
            {
                if (state.IsKeyDown(k))
                {
                    Current = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Is the bind in a pressed state, triggered on per input
        /// </summary>
        /// <returns><c>true</c>, if pressed was ised, <c>false</c> otherwise.</returns>
        public bool IsPressed()
        {
            return Current == true && Previous == false;
        }

        /// <summary>
		/// Is the bind released, triggered on per input
        /// </summary>
        /// <returns><c>true</c>, if released was ised, <c>false</c> otherwise.</returns>
        public bool IsReleased()
        {
            return Current == true && Previous == false;
        }

        /// <summary>
        /// Is the bind down, true every frame while the key is down
        /// </summary>
        /// <returns><c>true</c>, if down was ised, <c>false</c> otherwise.</returns>
        public bool IsDown()
        {
            return Current;
        }

        /// <summary>
        /// Is the bind up, true every frame while the key is up
        /// </summary>
        /// <returns><c>true</c>, if up was ised, <c>false</c> otherwise.</returns>
        public bool IsUp()
        {
            return !Current;
        }

    }
}
