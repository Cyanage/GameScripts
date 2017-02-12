using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopDownSports
{
    class Player
    {
        Texture2D player;
        Rectangle playerPos;

        bool isLeftDown = false;
        bool isRightDown = false;
        bool isUpDown = false;
        bool isDownDown = false;

        List<Rectangle> collidableObjects = new List<Rectangle>();

        public int movementSpeed = 0;

        Block block;

        public Player(Texture2D player)
        {
            this.player = player;
            playerPos = new Rectangle(760, 840, 100, 100);
            block = new Block();
        }
        public Player()
        {
            
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && isLeftDown == false)
            {
                if (playerPos.X < 860)
                {
                    playerPos.X -= 0;
                }
                else
                {
                    playerPos.X -= 100;
                    isLeftDown = true;
                }
            }
            if (isLeftDown == true)
            {
                if (Keyboard.GetState().IsKeyUp(Keys.Left))
                {
                    isLeftDown = false;
                }
            }


            //Right Key
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && isRightDown == false)
            {
                if (playerPos.X > 960)
                {
                    playerPos.X += 0;
                }
                else
                {
                    playerPos.X += 100;
                    isRightDown = true;
                }
            }
            if (isRightDown == true)
            {
                if (Keyboard.GetState().IsKeyUp(Keys.Right))
                {
                    isRightDown = false;
                }
            }


            //Up Key
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && isUpDown == false)
            {
                if (playerPos.Y < 240)
                {
                    playerPos.Y += 0;
                }
                else
                {
                    playerPos.Y -= movementSpeed;
                    isUpDown = true;
                }
            }
            if (isUpDown == true)
            {
                if (Keyboard.GetState().IsKeyUp(Keys.Up))
                {
                    isUpDown = false;
                }
            }


            //Down Key
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && isDownDown == false)
            {
                if (playerPos.Y > 740)
                {
                    playerPos.Y += 0;
                }
                else
                {
                    playerPos.Y += movementSpeed;
                    isDownDown = true;
                }
            }
            if (isDownDown == true)
            {
                if (Keyboard.GetState().IsKeyUp(Keys.Down))
                {
                    isDownDown = false;
                }
            }
        }

        public void UpdateCollision()
        {
            Console.WriteLine(block.coloredRects.Count);
            foreach (Rectangle item in block.coloredRects)
            {
                if (playerPos.Top > item.Bottom)
                {
                    Console.WriteLine("I'm Below the Rect");
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(player, playerPos, Color.Green);
            spriteBatch.End();
        }
    }
}
