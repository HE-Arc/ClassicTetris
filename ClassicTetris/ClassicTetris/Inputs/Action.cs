using System;
namespace ClassicTetris.Inputs
{
	/// <summary>
    /// Every possible action
    /// </summary>
    public enum Action
    {
        // gamepad
        Up,
        Down,
		Left,
		Right,
		Start,
        Select,
        A,
        B,
        // console
        Shutdown,
        // debug
        Debug,
    }
}
