using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace ClassicTetris
{
    public class Actions
    {
        private Actions Instance = null;

        public readonly Dictionary<Action, Bind> Binds = new Dictionary<Action, Bind>();

        public Actions GetInstance()
        {
            if (Instance == null)
                Instance = new Actions();
            return Instance;
        }

        private Actions()
        {
            Binds[Action.Left] = new Bind(Keys.Left, Keys.A);
            Binds[Action.Right] = new Bind(Keys.Right, Keys.D);
            Binds[Action.Down] = new Bind(Keys.Down, Keys.S);
            Binds[Action.Rotate] = new Bind(Keys.Up, Keys.W);
        }

        public void Update(KeyboardState state)
        {
            foreach(Bind bind in Binds.Values)
            {
                bind.Update(state);
            }
        }
    }

    public enum Action
    {
        Left,
        Right,
        Down,
        Rotate,
    }
}
