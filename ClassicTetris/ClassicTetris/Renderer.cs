﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassicTetris.Tetromino;

namespace ClassicTetris
{
    class Renderer
    {
        private Texture2D background;
        private SpriteFont tetrisFont;
        private Texture2D[,] texturesTetrominos;
        private int level = 4;
        private static Shape[] shapeStatisticsOrder =
        {
            Shape.T,
            Shape.J,
            Shape.Z,
            Shape.O,
            Shape.S,
            Shape.L,
            Shape.I
        };

        public Renderer(ContentManager content, SpriteBatch sb)
        {
            texturesTetrominos = new Texture2D[Settings.NB_COLORS_LEVELS,Settings.NB_TEXTURES];
            LoadContent(content, sb);

        }
        private void LoadContent(ContentManager content, SpriteBatch sb)
        {
            background = content.Load<Texture2D>("Textures/tetris_exemple");
            tetrisFont = content.Load<SpriteFont>("Fonts/classic_tetris_font");
            CreateTextures(sb);
        }

        private void CreateTextures(SpriteBatch sb)
        {
            // [level , textureshape]
            texturesTetrominos[0, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_0_PRIMARY);
            texturesTetrominos[0, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_0_PRIMARY);
            texturesTetrominos[0, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_0_PRIMARY);
            texturesTetrominos[0, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_0_SECONDARY);

            texturesTetrominos[1, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_1_PRIMARY);
            texturesTetrominos[1, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_1_PRIMARY);
            texturesTetrominos[1, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_1_PRIMARY);
            texturesTetrominos[1, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_1_SECONDARY);

            texturesTetrominos[2, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_2_PRIMARY);
            texturesTetrominos[2, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_2_PRIMARY);
            texturesTetrominos[2, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_2_PRIMARY);
            texturesTetrominos[2, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_2_SECONDARY);

            texturesTetrominos[3, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_3_PRIMARY);
            texturesTetrominos[3, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_3_PRIMARY);
            texturesTetrominos[3, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_3_PRIMARY);
            texturesTetrominos[3, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_3_SECONDARY);

            texturesTetrominos[4, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_4_PRIMARY);
            texturesTetrominos[4, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_4_PRIMARY);
            texturesTetrominos[4, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_4_PRIMARY);
            texturesTetrominos[4, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_4_SECONDARY);
                               
            texturesTetrominos[5, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_5_PRIMARY);
            texturesTetrominos[5, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_5_PRIMARY);
            texturesTetrominos[5, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_5_PRIMARY);
            texturesTetrominos[5, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_5_SECONDARY);
                               
            texturesTetrominos[6, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_6_PRIMARY);
            texturesTetrominos[6, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_6_PRIMARY);
            texturesTetrominos[6, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_6_PRIMARY);
            texturesTetrominos[6, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_6_SECONDARY);
                               
            texturesTetrominos[7, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_7_PRIMARY);
            texturesTetrominos[7, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_7_PRIMARY);
            texturesTetrominos[7, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_7_PRIMARY);
            texturesTetrominos[7, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_7_SECONDARY);

            texturesTetrominos[8, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_8_PRIMARY);
            texturesTetrominos[8, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_8_PRIMARY);
            texturesTetrominos[8, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_8_PRIMARY);
            texturesTetrominos[8, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_8_SECONDARY);

            texturesTetrominos[9, 0] = CreateTextureType0(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_9_PRIMARY);
            texturesTetrominos[9, 1] = CreateTextureType1(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_9_PRIMARY);
            texturesTetrominos[9, 2] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_9_PRIMARY);
            texturesTetrominos[9, 3] = CreateTextureType2(sb, Settings.SQUARE_SIZE, Settings.SQUARE_SIZE, Settings.COLOR_LEVEL_9_SECONDARY);
        }

        private void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
        }

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
            }
            spriteBatch.End();
        }

        private void DrawType(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(tetrisFont, "A", new Vector2(95, 85), Color.White);
        }

        private void DrawStatistics(SpriteBatch spriteBatch)
        {
            int xCoord = 200;
            int yCoord = 330;
            for (int i = 0; i < shapeStatisticsOrder.Length; i++)
            {
                int stat = GameLogic.Instance.GetStatistics()[shapeStatisticsOrder[i]];
                spriteBatch.DrawString(tetrisFont, FormatNumberToNDigits(stat, Settings.STATS_DIGITS), new Vector2(xCoord, yCoord), Color.White);
                yCoord += 64;
            }
        }

        private void DrawLevel(SpriteBatch spriteBatch)
        {
            int level = GameLogic.Instance.Level;
            spriteBatch.DrawString(tetrisFont, FormatNumberToNDigits(level, Settings.LEVEL_DIGITS), new Vector2(820, 630), Color.White);
        }

        private void DrawNextTetromino(SpriteBatch spriteBatch)
        {
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
                        //DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Black);
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
  

        private void DrawCurrentScore(SpriteBatch spriteBatch)
        {
            int score = GameLogic.Instance.Score;
            spriteBatch.DrawString(tetrisFont, FormatNumberToNDigits(score, Settings.SCORE_DIGITS), new Vector2(770, 215), Color.White);
        }

        private void DrawTopScore(SpriteBatch spriteBatch)
        {
            int topScore = 5000;
            spriteBatch.DrawString(tetrisFont, FormatNumberToNDigits(topScore, Settings.SCORE_DIGITS), new Vector2(770, 120), Color.White);
        }

        private void DrawBoard(SpriteBatch spriteBatch)
        {
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
                    coor.X += squareSize + Settings.SQUARE_SPREARD;

                }
                coor.X = offsetX;
                coor.Y += squareSize + Settings.SQUARE_SPREARD;
            }
            
        }

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

        
        private void DrawRectangle(SpriteBatch sb, Vector2 coor, int sizeX, int sizeY, Color color)
        {
            Texture2D rect = new Texture2D(sb.GraphicsDevice, sizeX, sizeY);
            Color[] data = new Color[sizeX * sizeY];
            for (int k = 0; k < data.Length; ++k) data[k] = color;
            rect.SetData(data);
            sb.Draw(rect, coor, Color.White);
        }

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
    }
}
