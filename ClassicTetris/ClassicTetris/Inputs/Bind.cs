using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace ClassicTetris
{
    public class Bind
    {
        private readonly Keys[] Keys;
        private bool Current;
        private bool Previous;

        public Bind(params Keys[] keys)
        {
            this.Keys = keys;
            this.Current = false;
            this.Previous = false;
        }

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

        public bool IsPressed()
        {
            return Current == true && Previous == false;
        }

        public bool IsReleased()
        {
            return Current == true && Previous == false;
        }

        public bool IsDown()
        {
            return Current;
        }

        public bool IsUp()
        {
            return !Current;
        }

    }
}
