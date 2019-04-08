using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris.Renderer
{
    class GameRenderer
    {
        private Texture2D background;
        private SpriteFont tetrisFont;

        public GameRenderer(ContentManager content)
        {
            LoadContent(content);         
        }

        private void LoadContent(ContentManager content)
        {
            background = content.Load<Texture2D>("Textures/tetris_exemple");
            tetrisFont = content.Load<SpriteFont>("Fonts/classic_tetris_font");
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
            for (int i = 0; i < Settings.TETROMINOES; i++)
            {
                int stat = GameLogic.Instance.Statistics[i];
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
            spriteBatch.DrawString(tetrisFont, "T", new Vector2(790, 450), Color.White);
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
                        DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Black);
                    }
                    else if (b[i][j] <= 1)
                    {
                        DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Orange);
                    }
                    else if (b[i][j] <= 2)
                    {
                        DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Cyan);
                    }
                    else if (b[i][j] <= 3)
                    {
                        DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Blue);
                    }
                    else if (b[i][j] <= 4)
                    {
                        DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Green);
                    }
                    else if (b[i][j] <= 5)
                    {
                        DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Magenta);
                    }
                    else if (b[i][j] <= 6)
                    {
                        DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Red);
                    }
                    else if (b[i][j] <= 7)
                    {
                        DrawRectangle(spriteBatch, coor, squareSize, squareSize, Color.Yellow);
                    }
                    coor.X += squareSize;

                }
                coor.X = offsetX;
                coor.Y += squareSize;
            }
            
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
    }
}
