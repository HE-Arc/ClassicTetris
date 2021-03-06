﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using static ClassicTetris.Tetromino;

namespace ClassicTetris.Renderer
{
    class GameRenderer
    {
        #region Attributes
        private Texture2D background;
		private Texture2D[,] texturesTetrominos;

        #endregion

        #region Properties
        public SpriteFont TetrisFont
		{
			get;
			private set;
		}
        private const string pauseText = "PAUSE";
        private static readonly Color colorTextPause = new Color(92, 148, 252);
        private static readonly Color colorBGPause = Color.Black;
        #endregion

        #region Static
        /// <summary>
        /// Order of the shape to display in statistics section
        /// </summary>
        private static readonly Shape[] shapeStatisticsOrder =
        {
            Shape.T,
            Shape.J,
            Shape.Z,
            Shape.O,
            Shape.S,
            Shape.L,
            Shape.I
        };

        #endregion

        /// <summary>
        /// Constrctor
        /// </summary>
        /// <param name="content">ContentManager</param>
        /// <param name="sb">Sprite batch</param>
        public GameRenderer(ContentManager content, SpriteBatch sb)
        {
            texturesTetrominos = new Texture2D[Settings.NB_COLORS_LEVELS,Settings.NB_TEXTURES];
            LoadContent(content, sb);
        }

        /// <summary>
        /// Load textures and fonts
        /// </summary>
        /// <param name="content">Content manager</param>
        /// <param name="sb">Sprite batch</param>
		private void LoadContent(ContentManager content, SpriteBatch sb)
        {
            background = content.Load<Texture2D>("Textures/tetris_exemple");
			TetrisFont = content.Load<SpriteFont>("Fonts/classic_tetris_font");
            CreateTextures(sb);
        }

        /// <summary>
        /// Create texture for the tetrominos
        /// </summary>
        /// <param name="sb">Sprite batch</param>
        private void CreateTextures(SpriteBatch sb)
        {
            // [level , textureshape]
            texturesTetrominos[0, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_0_PRIMARY);
            texturesTetrominos[0, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_0_PRIMARY);
            texturesTetrominos[0, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_0_PRIMARY);
            texturesTetrominos[0, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_0_SECONDARY);
            texturesTetrominos[0, 4] = CreateTextureTypeEnd(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_0_PRIMARY, Settings.COLOR_LEVEL_0_SECONDARY);

            texturesTetrominos[1, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_1_PRIMARY);
            texturesTetrominos[1, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_1_PRIMARY);
            texturesTetrominos[1, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_1_PRIMARY);
            texturesTetrominos[1, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_1_SECONDARY);
            texturesTetrominos[1, 4] = CreateTextureTypeEnd(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_1_PRIMARY, Settings.COLOR_LEVEL_1_SECONDARY);

            texturesTetrominos[2, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_2_PRIMARY);
            texturesTetrominos[2, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_2_PRIMARY);
            texturesTetrominos[2, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_2_PRIMARY);
            texturesTetrominos[2, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_2_SECONDARY);
            texturesTetrominos[2, 4] = CreateTextureTypeEnd(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_2_PRIMARY, Settings.COLOR_LEVEL_2_SECONDARY);

            texturesTetrominos[3, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_3_PRIMARY);
            texturesTetrominos[3, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_3_PRIMARY);
            texturesTetrominos[3, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_3_PRIMARY);
            texturesTetrominos[3, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_3_SECONDARY);
            texturesTetrominos[3, 4] = CreateTextureTypeEnd(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_3_PRIMARY, Settings.COLOR_LEVEL_3_SECONDARY);

            texturesTetrominos[4, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_4_PRIMARY);
            texturesTetrominos[4, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_4_PRIMARY);
            texturesTetrominos[4, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_4_PRIMARY);
            texturesTetrominos[4, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_4_SECONDARY);
            texturesTetrominos[4, 4] = CreateTextureTypeEnd(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_4_PRIMARY, Settings.COLOR_LEVEL_4_SECONDARY);

            texturesTetrominos[5, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_5_PRIMARY);
            texturesTetrominos[5, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_5_PRIMARY);
            texturesTetrominos[5, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_5_PRIMARY);
            texturesTetrominos[5, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_5_SECONDARY);
            texturesTetrominos[5, 4] = CreateTextureTypeEnd(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_5_PRIMARY, Settings.COLOR_LEVEL_5_SECONDARY);

            texturesTetrominos[6, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_6_PRIMARY);
            texturesTetrominos[6, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_6_PRIMARY);
            texturesTetrominos[6, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_6_PRIMARY);
            texturesTetrominos[6, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_6_SECONDARY);
            texturesTetrominos[6, 4] = CreateTextureTypeEnd(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_6_PRIMARY, Settings.COLOR_LEVEL_6_SECONDARY);

            texturesTetrominos[7, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_7_PRIMARY);
            texturesTetrominos[7, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_7_PRIMARY);
            texturesTetrominos[7, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_7_PRIMARY);
            texturesTetrominos[7, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_7_SECONDARY);
            texturesTetrominos[7, 4] = CreateTextureTypeEnd(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_7_PRIMARY, Settings.COLOR_LEVEL_7_SECONDARY);

            texturesTetrominos[8, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_8_PRIMARY);
            texturesTetrominos[8, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_8_PRIMARY);
            texturesTetrominos[8, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_8_PRIMARY);
            texturesTetrominos[8, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_8_SECONDARY);
            texturesTetrominos[8, 4] = CreateTextureTypeEnd(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_8_PRIMARY, Settings.COLOR_LEVEL_8_SECONDARY);

            texturesTetrominos[9, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_9_PRIMARY);
            texturesTetrominos[9, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_9_PRIMARY);
            texturesTetrominos[9, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_9_PRIMARY);
            texturesTetrominos[9, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_9_SECONDARY);
            texturesTetrominos[9, 4] = CreateTextureTypeEnd(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_9_PRIMARY, Settings.COLOR_LEVEL_9_SECONDARY);
        }
        
        public void DrawPause(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            GraphicsDevice gd = spriteBatch.GraphicsDevice;

            gd.Clear(colorBGPause);

            Vector2 size = TetrisFont.MeasureString(pauseText);
            Vector2 pos = new Vector2();
            pos.X = (gd.Viewport.Width - size.X) / 2;
            pos.Y = (gd.Viewport.Height - size.Y) / 2;

            spriteBatch.DrawString(TetrisFont, pauseText, pos, colorTextPause);
            spriteBatch.End();
        }
        
        /// <summary>
        /// Draw background image
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        private void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
        }

        /// <summary>
        /// Draw scene
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        public void DrawScene(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            {
                DrawBackground(spriteBatch);
                DrawBoard(spriteBatch);
                DrawTopScore(spriteBatch);
                DrawCurrentScore(spriteBatch);
                DrawNextTetromino(spriteBatch);
                DrawLevel(spriteBatch);
                DrawStatistics(spriteBatch);
                DrawType(spriteBatch);
                DrawLines(spriteBatch);
            }
            spriteBatch.End();
        }

        /// <summary>
        /// Draw lines
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        private void DrawLines(SpriteBatch spriteBatch)
        {
            int nLines = GameLogic.Instance.NbLines;
            spriteBatch.DrawString(TetrisFont, $"LINES - {FormatNumberToNDigits(nLines, Settings.LINES_DIGITS)}", new Vector2(400, 50), Color.White);
        }

        /// <summary>
        /// Sprite batchzDraw type game
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        private void DrawType(SpriteBatch spriteBatch)
        {
            //TODO
            spriteBatch.DrawString(TetrisFont, "A-TYPE", new Vector2(95, 83), Color.White);
        }

        /// <summary>
        /// Draw statistics section
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        private void DrawStatistics(SpriteBatch spriteBatch)
        {
            int xCoord = 190;
            int yCoord = 250;
            int level = GameLogic.Instance.Level;
            int[] piecesOrder = new int[8] {0, 6, 3, 7, 2, 5, 4, 1 };
            spriteBatch.DrawString(TetrisFont, "STATISTICS", new Vector2(xCoord - 4*Settings.SQUARE_SIZE, yCoord), Color.White);
            xCoord += Settings.SQUARE_SIZE;
            yCoord += (int)(2.5 * Settings.SQUARE_SIZE);
            for (int a = 0; a < shapeStatisticsOrder.Length; a++)
            {
                int stat = GameLogic.Instance.GetStatistics()[shapeStatisticsOrder[a]];
                spriteBatch.DrawString(TetrisFont, FormatNumberToNDigits(stat, Settings.STATS_DIGITS), new Vector2(xCoord, yCoord), Color.Red);

                int[,] b = Tetromino.sequence[(Shape)(piecesOrder[a+1])][0];
                int dim = b.GetLength(0);
                int offsetDim = dim != 3 ? 0 : 15;
                int offsetX = xCoord + offsetDim - 150;
                int offsetY = yCoord - 20;
                Vector2 coor = new Vector2(offsetX, offsetY);
                for (int i = 0; i < dim; i++)
                {
                    for (int j = 0; j < dim; j++)
                    {

                        if (b[i, j] <= 0)
                        {
                            //DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Black);
                        }
                        else if (b[i, j] <= 1) //I
                        {
                            coor.Y -= Settings.SQUARE_SIZE;
                            DrawTexture(spriteBatch, texturesTetrominos[level, 1], coor);
                            coor.Y += Settings.SQUARE_SIZE;
                        }
                        else if (b[i, j] <= 2) //0
                        {
                            DrawTexture(spriteBatch, texturesTetrominos[level, 0], coor);
                        }
                        else if (b[i, j] <= 3) //J
                        {
                            DrawTexture(spriteBatch, texturesTetrominos[level, 2], coor);
                        }
                        else if (b[i, j] <= 4) //L
                        {
                            DrawTexture(spriteBatch, texturesTetrominos[level, 3], coor);
                        }
                        else if (b[i, j] <= 5) //S
                        {
                            DrawTexture(spriteBatch, texturesTetrominos[level, 2], coor);
                        }
                        else if (b[i, j] <= 6) //T
                        {
                            DrawTexture(spriteBatch, texturesTetrominos[level, 1], coor);
                        }
                        else if (b[i, j] <= 7) //Z
                        {
                            DrawTexture(spriteBatch, texturesTetrominos[level, 3], coor);
                        }
                        coor.X += Settings.SQUARE_SIZE + Settings.SQUARE_SPREARD;

                    }
                    coor.X = offsetX;
                    coor.Y += Settings.SQUARE_SIZE + Settings.SQUARE_SPREARD;
                }

                yCoord += 2*Settings.SQUARE_SIZE + 10;
            }

        }

        /// <summary>
        /// Draw level section
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        private void DrawLevel(SpriteBatch spriteBatch)
        {
            int level = GameLogic.Instance.Level;
            spriteBatch.DrawString(TetrisFont, "LEVEL", new Vector2(780, 590), Color.White);
            spriteBatch.DrawString(TetrisFont, FormatNumberToNDigits(level, Settings.LEVEL_DIGITS), new Vector2(820, 630), Color.White);
        }

        /// <summary>
        /// Draw next tetrominos section
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        private void DrawNextTetromino(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(TetrisFont, "NEXT", new Vector2(765, 375), Color.White);
            int level = GameLogic.Instance.Level;
            int[,] b = GameLogic.Instance.GetNextShape().Grid;
            int dim = b.GetLength(0);
            int offsetDim = dim != 3 ? 0:15;

            int offsetX = Settings.NEXT_TETRO_OFFSET_X + offsetDim;
            int offsetY = Settings.NEXT_TETRO_OFFSET_Y;
            int squareSize = Settings.SQUARE_SIZE;
            Vector2 coor = new Vector2(offsetX, offsetY);
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    if (b[i,j] <= 0)
                    {
                        //DrawTexture(spriteBatch, texturesTetrominos[level, 4], coor);
                    }
                    else if (b[i,j] <= 1) //I
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 1], coor);
                    }
                    else if (b[i,j] <= 2) //0
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 0], coor);
                    }
                    else if (b[i,j] <= 3) //J
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 2], coor);
                    }
                    else if (b[i,j] <= 4) //L
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 3], coor);
                    }
                    else if (b[i,j] <= 5) //S
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 2], coor);
                    }
                    else if (b[i,j] <= 6) //T
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 1], coor);
                    }
                    else if (b[i,j] <= 7) //Z
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 3], coor);
                    }
                    coor.X += squareSize + Settings.SQUARE_SPREARD;

                }
                coor.X = offsetX;
                coor.Y += squareSize + Settings.SQUARE_SPREARD;
            }

        }

        /// <summary>
        /// Draw current score section
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        private void DrawCurrentScore(SpriteBatch spriteBatch)
        {
            int score = GameLogic.Instance.Score;
            spriteBatch.DrawString(TetrisFont, "SCORE", new Vector2(765, 175), Color.White);
            spriteBatch.DrawString(TetrisFont, FormatNumberToNDigits(score, Settings.SCORE_DIGITS), new Vector2(770, 215), Color.White);
        }

        /// <summary>
        /// Draw the top score
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawTopScore(SpriteBatch spriteBatch)
        {
            int topScore = 5000; //TODO
            spriteBatch.DrawString(TetrisFont, "TOP", new Vector2(765, 80), Color.White);
            spriteBatch.DrawString(TetrisFont, FormatNumberToNDigits(topScore, Settings.SCORE_DIGITS), new Vector2(770, 120), Color.White);
        }

        /// <summary>
        /// Draw the complete board
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        private void DrawBoard(SpriteBatch spriteBatch)
		{
			int level = GameLogic.Instance.Level;
            int[][] b = GameLogic.Instance.GetGrid(); 
            int offsetX = Settings.BOARD_OFFSET_X;
            int offsetY = Settings.BOARD_OFFSET_Y;
            int squareSize = Settings.SQUARE_SIZE;
            Vector2 coor = new Vector2(offsetX, offsetY);
            for (int i = 0; i < Settings.BOARD_HEIGHT; i++) //todo settings
            {
                for (int j = 0; j < Settings.BOARD_WIDTH; j++) //todo settings
                {

                    if(b[i][j] <= 0)
                    {
                        //DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Black);
                    }
                    else if (b[i][j] <= 1) //I
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 1], coor);
                    }
                    else if (b[i][j] <= 2) //0
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 0], coor);
                    }
                    else if (b[i][j] <= 3) //J
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 2], coor);
                    }
                    else if (b[i][j] <= 4) //L
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 3], coor);
                    }
                    else if (b[i][j] <= 5) //S
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 2], coor);
                    }
                    else if (b[i][j] <= 6) //T
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 1], coor);
                    }
                    else if (b[i][j] <= 7) //Z
                    {
                        DrawTexture(spriteBatch, texturesTetrominos[level, 3], coor);
                    }
                    else if (b[i][j] <= 8) //END
                    {
                        coor.X -= Settings.SQUARE_SPREARD / 2;
                        DrawTexture(spriteBatch, texturesTetrominos[level, 4], coor);
                        coor.X += Settings.SQUARE_SPREARD / 2;
                    }
                    coor.X += squareSize + Settings.SQUARE_SPREARD;

                }
                coor.X = offsetX;
                coor.Y += squareSize + Settings.SQUARE_SPREARD;
            }

        }

        /// <summary>
        /// Draw a texture at the given coordinates
        /// </summary>
        /// <param name="sb">Sprite batch</param>
        /// <param name="texture">Texture</param>
        /// <param name="coor">Coordinates</param>
        private void DrawTexture(SpriteBatch sb, Texture2D texture, Vector2 coor)
        {
            sb.Draw(texture, coor, Color.White);
        }

        /// <summary>
        /// Converts a number into a string of n characters.
        /// Example for n = 6 : (100 -> "000100", 50000 -> "050000)
        /// </summary>
        /// <param name="number">The input number</param>
        /// <param name="n">The number of chars wanted</param>
        /// <returns></returns>
        private string FormatNumberToNDigits(int number, int n)
        {
            Debug.Assert(n > 0);
            number %= Convert.ToInt32(Math.Pow(10, n));
            Debug.Assert(number < Convert.ToInt32(Math.Pow(10, n)));
            String formattedNumber = new String('0', n).Substring(1, n - number.ToString().Length) + number.ToString();
            return formattedNumber;
        }

        /// <summary>
        /// Draw a rectangle
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        /// <param name="coor">coordinates</param>
        /// <param name="sizeX">Size x</param>
        /// <param name="sizeY">Size y</param>
        /// <param name="color">Color</param>
        private void DrawRectangle(SpriteBatch sb, Vector2 coor, int sizeX, int sizeY, Color color)
        {
            Texture2D rect = new Texture2D(sb.GraphicsDevice, sizeX, sizeY);
            Color[] data = new Color[sizeX * sizeY];
            for (int k = 0; k < data.Length; ++k) data[k] = color;
            rect.SetData(data);
            sb.Draw(rect, coor, Color.White);
        }

        /// <summary>
        /// Create a texture of type 0
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        /// <param name="coor">coordinates</param>
        /// <param name="sizeX">Size x</param>
        /// <param name="sizeY">Size y</param>
        /// <param name="color">Color</param>
        /// <returns>Texture</returns>
        private Texture2D CreateTextureType0(SpriteBatch sb, int sizeX, int sizeY, Color color)
        {
            Texture2D rect = new Texture2D(sb.GraphicsDevice, sizeX, sizeY);
            Color[] data = new Color[sizeX * sizeY];
            int edgeSize = Settings.EDGE_SIZE; //in px
            for (int k = 0; k < data.Length; ++k)
            {
                if (k < sizeX*edgeSize || k % sizeX < edgeSize || k % sizeX > sizeX-edgeSize || k > (sizeX*sizeY)-(edgeSize*sizeX))
                {
                    data[k] = color;
                }
                else
                {
                    data[k] = Color.White;
                }
            }
            rect.SetData(data);
            return rect;
        }
        /// <summary>
        /// Create a texture of type 1
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        /// <param name="coor">coordinates</param>
        /// <param name="sizeX">Size x</param>
        /// <param name="sizeY">Size y</param>
        /// <param name="color">Color</param>
        /// <returns>Texture</returns>
        private Texture2D CreateTextureType1(SpriteBatch sb, int sizeX, int sizeY, Color color)
        {
            Texture2D rect = new Texture2D(sb.GraphicsDevice, sizeX, sizeY);
            Color[] data = new Color[sizeX * sizeY];
            int edgeSize = Settings.EDGE_SIZE; //in px
            for (int k = 0; k < data.Length; ++k)
            {
                if (k < sizeX * edgeSize || k % sizeX < edgeSize || k % sizeX > sizeX - edgeSize || k > (sizeX * sizeY) - (edgeSize * sizeX))
                {
                    data[k] = color;
                }
                else
                {
                    data[k] = Color.White;
                }
            }
            for(int k = 0; k < edgeSize; k++)
            {
                for (int i = 0; i < edgeSize; i++)
                {
                    data[i + k * sizeX] = Color.White;
                }
            }

            rect.SetData(data);
            return rect;
        }

        /// <summary>
        /// Create a texture of type 2
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        /// <param name="coor">coordinates</param>
        /// <param name="sizeX">Size x</param>
        /// <param name="sizeY">Size y</param>
        /// <param name="color">Color</param>
        /// <returns>Texture</returns>
        private Texture2D CreateTextureType2(SpriteBatch sb, int sizeX, int sizeY, Color color)
        {
            Texture2D rect = new Texture2D(sb.GraphicsDevice, sizeX, sizeY);
            Color[] data = new Color[sizeX * sizeY];
            int edgeSize = Settings.EDGE_SIZE; //in px
            for (int k = 0; k < data.Length; ++k)
            {
                data[k] = color;
            }
            for (int k = 0; k < edgeSize; k++)
            {
                for (int i = 0; i < edgeSize; i++)
                {
                    data[i + k * sizeX] = Color.White;
                    data[i + k * sizeX + (edgeSize*sizeX) + edgeSize] = Color.White;
                    data[i + k * sizeX + (edgeSize * sizeX) + 2*edgeSize] = Color.White;
                    data[i + k * sizeX + 2* (edgeSize * sizeX) + edgeSize] = Color.White;
                }
            }
            rect.SetData(data);
            return rect;
        }

        /// <summary>
        /// Create a texture of type 3
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        /// <param name="coor">coordinates</param>
        /// <param name="sizeX">Size x</param>
        /// <param name="sizeY">Size y</param>
        /// <param name="color">Color</param>
        /// <returns>Texture</returns>
        private Texture2D CreateTextureTypeEnd(SpriteBatch sb, int sizeX, int sizeY, Color colorPrimary, Color colorSecondary)
        {
            sizeX += Settings.SQUARE_SPREARD;
            Texture2D rect = new Texture2D(sb.GraphicsDevice, sizeX, sizeY);
            Color[] data = new Color[sizeX * sizeY];
            int n = data.Length;
            for (int k = 0; k < n; ++k)
            {
                if (k < n / 3)
                {
                    data[k] = colorSecondary;
                }
                else if( k < 2*n / 3)
                {
                    data[k] = Color.White;
                }

                else
                {
                    data[k] = colorPrimary;
                }
            }
            rect.SetData(data);
            return rect;
        }
    }
}
