using System;
namespace ClassicTetris.Inputs
{
	/// <summary>
    /// Every possible action
    /// </summary>
    public enum Action
    {
        // game keys
        Left,
        Right,
		Down,
		Rotate,
        ForceDown,
        // misc
        Quit,
        // debug
        Debug,
        // menus keys
        MenuUp,
        MenuDown,
        MenuLeft,
		MenuRight,
		MenuValidate,
        MenuBack,
    }
}
