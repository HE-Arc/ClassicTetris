﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris.Menus
{
    class GameTypeMenu : IMenus
    {
        private Tetris tetris;
        private SpriteBatch sb;
        private Texture2D bg;
        private Texture2D arrow_right;
        private Texture2D arrow_left;

        private enum GameType
        {
            TypeA,
            TypeB
        }

        private enum MusicType
        {
            Music1,
            Music2,
            Music3,
            OFF,
        }

        private GameType currentGameType;
        private MusicType currentMusicType;

        private Dictionary<GameType, Tuple<Vector2, Vector2>> arrowsPositionsGameType;
        private Dictionary<MusicType, Tuple<Vector2, Vector2>> arrowsPositionsMusicType;

        public GameTypeMenu(Tetris tetris)
        {
            this.tetris = tetris;
            currentGameType = GameType.TypeA;
            currentMusicType = MusicType.Music1;

            arrowsPositionsGameType = new Dictionary<GameType, Tuple<Vector2, Vector2>>();
            arrowsPositionsGameType[GameType.TypeA] = new Tuple<Vector2, Vector2>(new Vector2(246, 226), new Vector2(480, 226));
            arrowsPositionsGameType[GameType.TypeB] = new Tuple<Vector2, Vector2>(new Vector2(630, 226), new Vector2(866, 226));
            arrowsPositionsMusicType = new Dictionary<MusicType, Tuple<Vector2, Vector2>>();
            arrowsPositionsMusicType[MusicType.Music1] = new Tuple<Vector2, Vector2>(new Vector2(406, 546), new Vector2(706, 546));
            arrowsPositionsMusicType[MusicType.Music2] = new Tuple<Vector2, Vector2>(new Vector2(406, 608), new Vector2(706, 608));
            arrowsPositionsMusicType[MusicType.Music3] = new Tuple<Vector2, Vector2>(new Vector2(406, 676), new Vector2(706, 676));
            arrowsPositionsMusicType[MusicType.OFF] = new Tuple<Vector2, Vector2>(new Vector2(406, 733), new Vector2(706, 733));
        }

        public void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(bg, Vector2.Zero, Color.White);
            sb.Draw(arrow_left, arrowsPositionsGameType[currentGameType].Item1, Color.White);
            sb.Draw(arrow_right, arrowsPositionsGameType[currentGameType].Item2, Color.White);

            sb.Draw(arrow_left, arrowsPositionsMusicType[currentMusicType].Item1, Color.White);
            sb.Draw(arrow_right, arrowsPositionsMusicType[currentMusicType].Item2, Color.White);
            sb.End();
        }

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager Content, GraphicsDevice graphicDevice)
        {
            sb = new SpriteBatch(graphicDevice);
            bg = Content.Load<Texture2D>("Textures/gameTypeMenu");
            arrow_right = Content.Load<Texture2D>("Textures/arrow_right");
            arrow_left = Content.Load<Texture2D>("Textures/arrow_left");
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            if (Actions.GetInstance()[Inputs.Action.MenuValidate].IsPressed())
            {
                tetris.ChangeMenu(EMenu.TypeAMenu);
            }
            if (Actions.GetInstance()[Inputs.Action.MenuDown].IsPressed())
            {
                currentMusicType = (MusicType)(TetrisMath.mod(((int)currentMusicType + 1), Enum.GetNames(typeof(MusicType)).Length));
            }
            if (Actions.GetInstance()[Inputs.Action.MenuUp].IsPressed())
            {
                currentMusicType = (MusicType)(TetrisMath.mod(((int)currentMusicType - 1), Enum.GetNames(typeof(MusicType)).Length));
            }
            if (Actions.GetInstance()[Inputs.Action.MenuRight].IsPressed())
            {
                currentGameType = (GameType)(TetrisMath.mod(((int)currentGameType + 1), Enum.GetNames(typeof(GameType)).Length));
            }
            if (Actions.GetInstance()[Inputs.Action.MenuLeft].IsPressed())
            {
                currentGameType = (GameType)(TetrisMath.mod(((int)currentGameType - 1), Enum.GetNames(typeof(GameType)).Length));
            }
        }
    }
}