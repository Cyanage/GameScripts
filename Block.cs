using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownSports
{
    class Block
    {
        public Rectangle[] rects = new Rectangle[32];
        Texture2D[] textures = new Texture2D[32];

        public int selectedRect = 28;
        public bool isUpKeyDown = false;
        public bool isDownKeyDown = false;
        public bool isRightKeyDown = false;
        public bool isLeftKeyDown = false;
        public bool isEnterKeyDown = false;

        public List<Rectangle> coloredRects = new List<Rectangle>();

        public int amountOfBlocksPlaced = 0;

        Player player;

        public Block(Texture2D[] textures)
        {
            this.textures = textures;
            player = new Player();
            PlaceRects();
        }
        public Block()
        {
             
        }
        public void PlaceRects()
        {
            //sets position where rectangles start spawning
            int topLeft = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 200;
            int down = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - 400;

            //creates all rectangles
            for (int i = 0; i < rects.Length; i++)
            {
                rects[i] = new Rectangle(topLeft, down, 100, 100);
                topLeft += 100;
                if (topLeft >= (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 200) + 400)
                {
                    topLeft = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 200;
                    down += 100;
                }
            }
        }

        public void SelectRect()
        {
            //Console.WriteLine(onTop + " " + onBottom + " " + toLeft + " " + toRight);
            //When up is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && isUpKeyDown == false)
            {
                if (selectedRect <= 3)
                {
                    selectedRect += 0;
                }
                else
                {
                    selectedRect -= 4;
                }
                isUpKeyDown = true;
            }
            //checks if the key is released again before being able to do other stuff
            if (isUpKeyDown == true)
            {
                if (Keyboard.GetState().IsKeyUp(Keys.Up))
                {
                    isUpKeyDown = false;
                }
            }

            //When down is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && isDownKeyDown == false)
            {
                if (selectedRect >= 28)
                {
                    selectedRect += 0;
                }
                else
                {
                    selectedRect += 4;
                }
                isDownKeyDown = true;
            }
            if (isDownKeyDown == true)
            {
                if (Keyboard.GetState().IsKeyUp(Keys.Down))
                {
                    isDownKeyDown = false;
                }
            }

            //When right is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && isRightKeyDown == false)
            {
                if (selectedRect == 3 || selectedRect == 7 || selectedRect == 11 || selectedRect == 15 || selectedRect == 19 || selectedRect == 23 || selectedRect == 27 || selectedRect == 31)
                {
                    selectedRect += 0;
                }
                else
                {
                    selectedRect += 1;
                }
                isRightKeyDown = true;
            }
            if (isRightKeyDown == true)
            {
                if (Keyboard.GetState().IsKeyUp(Keys.Right))
                {
                    isRightKeyDown = false;
                }
            }

            //When left is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && isLeftKeyDown == false)
            {
                if (selectedRect == 0 || selectedRect == 4 || selectedRect == 8 || selectedRect == 12 || selectedRect == 16 || selectedRect == 20 || selectedRect == 24 || selectedRect == 28)
                {
                    selectedRect += 0;
                }
                else
                {
                    selectedRect -= 1;
                }
                isLeftKeyDown = true;
            }
            if (isLeftKeyDown == true)
            {
                if (Keyboard.GetState().IsKeyUp(Keys.Left))
                {
                    isLeftKeyDown = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < rects.Length; i++)
            {
                if (i == selectedRect)
                {
                    //the rectangle that is currently highlighted
                    spriteBatch.Draw(textures[i], rects[i], Color.Red);
                    //adds rects to a list that means they were selected
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter) && isEnterKeyDown == false)
                    {
                        //change to just placing a texture
                        coloredRects.Add(rects[i]);
                        amountOfBlocksPlaced += 1;
                        //checks to see if max amount of blocks have been placed
                        if (coloredRects.Count >= 4)
                        {
                            coloredRects.Remove(rects[i]);
                        }
                        if (amountOfBlocksPlaced >= 3)
                        {
                            selectedRect = 1000;
                        }
                        isEnterKeyDown = true;
                    }
                    if (isEnterKeyDown == true)
                    {
                        if(Keyboard.GetState().IsKeyUp(Keys.Enter))
                        {
                            isEnterKeyDown = false;
                        }
                    }
                }
                else
                {
                    //rectangles that aren't highlighted
                    spriteBatch.Draw(textures[i], rects[i], Color.White);
                    //rectangles that have been selected
                    foreach (Rectangle coloredRectangles in coloredRects)
                    {
                        spriteBatch.Draw(textures[i], coloredRectangles, Color.IndianRed);
                    }
                }
            }
            spriteBatch.End();
        }
    }
}
