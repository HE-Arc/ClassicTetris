using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris
{
    class Renderer
    {
        private Texture2D background;
        private SpriteFont tetrisFont;

        public Renderer(ContentManager content)
        {
            LoadContent(content);

        }
        private void LoadContent(ContentManager content)
        {
            background = content.Load<Texture2D>("Textures/tetris_exemple");
            tetrisFont = content.Load<SpriteFont>("Fonts/classic_tetris_font");
        }

        private void drawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
        }

        public void DrawScene(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            {
                drawBackground(spriteBatch);
                drawBoard(spriteBatch);
                drawTopScore(spriteBatch);
                drawCurrentScore(spriteBatch);
                drawNextTetromino(spriteBatch);
                drawLevel(spriteBatch);
                drawStatistics(spriteBatch);
                drawType(spriteBatch);
            }
            spriteBatch.End();
        }

        private void drawType(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(tetrisFont, "A", new Vector2(95, 85), Color.White);
        }

        private void drawStatistics(SpriteBatch spriteBatch)
        {
            int xCoord = 200;
            int yCoord = 330;
            for (int i = 0; i < 7; i++)
            {
                int stat = 21; //DEBUG
                spriteBatch.DrawString(tetrisFont, formatNumberToNDigits(stat, 3), new Vector2(xCoord, yCoord), Color.White);
                yCoord += 64;
            }
        }

        private void drawLevel(SpriteBatch spriteBatch)
        {
            int level = 9;
            spriteBatch.DrawString(tetrisFont, formatNumberToNDigits(level, 2), new Vector2(820, 630), Color.White);
        }

        private void drawNextTetromino(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(tetrisFont, "T", new Vector2(790, 450), Color.White);
        }

        private void drawCurrentScore(SpriteBatch spriteBatch)
        {
            //int score = Board.GetScore();
            int score = 3000; //DEBUG

            //String formattedTopScore = formatNumberToNDigits(topScore, Settings.SCORE_DIGITS);
            String formattedScore = formatNumberToNDigits(score, 6);

            spriteBatch.DrawString(tetrisFont, formattedScore, new Vector2(770, 215), Color.White);
        }

        private void drawTopScore(SpriteBatch spriteBatch)
        {
            //int topScore = Save.GetTopScore();
            int topScore = 5000;

            //String formattedTopScore = formatNumberToNDigits(topScore, Settings.SCORE_DIGITS);
            String formattedTopScore = formatNumberToNDigits(topScore, 6);

            spriteBatch.DrawString(tetrisFont, formattedTopScore, new Vector2(770, 120), Color.White);
        }

        private void drawBoard(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(tetrisFont, "BOARD", new Vector2(381, 160), Color.White);

            int[][] b = Board.GetGrid(); 

            int offsetX = 383;
            int offsetY = 162;
            int squareSize = 32;

            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, squareSize, squareSize);


            

            Vector2 coor = new Vector2(offsetX, offsetY);
            for (int i = 0; i < 20; i++) //todo settings
            {
                for (int j = 0; j < 10; j++) //todo settings
                {
                    
                    if(b[i][j] <= 0)
                    {
                        Color[] data = new Color[squareSize * squareSize];
                        for (int k = 0; k < data.Length; ++k) data[k] = Color.Black;
                        rect.SetData(data);
                    }
                    else
                    {
                        Color[] data = new Color[squareSize * squareSize];
                        for (int k = 0; k < data.Length; ++k) data[k] = Color.Yellow;
                        rect.SetData(data);
                    }
                    spriteBatch.Draw(rect, coor, Color.White);
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
        private String formatNumberToNDigits(int number, int n)
        {
            Debug.Assert(n > 0);
            number %= Convert.ToInt32(Math.Pow(10, n));
            Debug.Assert(number < Convert.ToInt32(Math.Pow(10, n)));
            String formattedNumber = new String('0', n).Substring(1, n - number.ToString().Length) + number.ToString();
            return formattedNumber;
            
        }
    }
}
