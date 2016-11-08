using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OnePiece
{

    class Charakter
    {
        Animation idle, walk, taunt, jump;
        Vector2 position;
        Vector2 velocity = new Vector2(0, 1);
        Rectangle rectangle;

     


        bool isWalkingRight = false;
        bool isWalkingLeft = false;
        bool isIdle = true;
        bool isTaunting = false;
        bool hasJumped = true;


        KeyboardState currentKeyState;
        KeyboardState previousKeyState;

        public Vector2 Position
        {
            get { return position; }
        }
        public Rectangle CharacterRectangle
        {
            get { return rectangle; }
        }
        public Charakter(Texture2D idleSpriteSheet, Texture2D walkSpriteSheet, Texture2D tauntSpriteSheet, Texture2D jumpSpritesheet)
        {
            idle = new Animation(idleSpriteSheet, 3, 1, 134 / 3, 82, 0.3f);
            walk = new Animation(walkSpriteSheet, 8, 1, 581 / 8, 82, 0.1f);
            taunt = new Animation(tauntSpriteSheet, 6, 1, 237 / 6, 82, 0.1f);
            jump = new Animation(jumpSpritesheet, 7, 1, 280 / 7, 79, 0.19f, false);
            position = new Vector2(10, 440);
            //rectangle = new Rectangle((int) position.X,(int) position.Y, walkSpriteSheet.Width, walkSpriteSheet.Height);   
        }

        public void Update(GameTime gametime)
        {


            isWalkingRight = false;
            isWalkingLeft = false;

            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 45, 80);

            currentKeyState = Keyboard.GetState();

            if (currentKeyState.IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadRight))
            {
                isWalkingRight = true;
                isIdle = false;
                position.X += 3;
            }

            if (currentKeyState.IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadLeft)) 
            {
                isWalkingLeft = true;
                isIdle = false;
                position.X -= 3;
            }


            if ((currentKeyState.IsKeyDown(Keys.Up) && hasJumped == false) || (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.A) && hasJumped == false))
            {
                position.Y -= 10f;
                velocity.Y = -5f;
                hasJumped = true;

            }
            if (hasJumped)
            {
                //float i = 1;

                isWalkingRight = false;
                isWalkingLeft = false;
                isIdle = false;
            }

            if (position.Y + jump.GetFrameWidthAndHeight().Y >= 800)
            {
                hasJumped = false;
            }

            if (!hasJumped)
            {
                //velocity.Y = 0f;
            }
            velocity.Y += 0.15f;

            if (currentKeyState.IsKeyDown(Keys.T) && !previousKeyState.IsKeyDown(Keys.T))
            {
                isTaunting = true;
                isIdle = false;
            }
            //if (previousKeyState.IsKeyUp(Keys.Right) && previousKeyState.IsKeyUp(Keys.Left) && !isTaunting)
            if (!isWalkingLeft && !isWalkingRight && !isTaunting && !hasJumped)
            {
                isIdle = true;
            }

            idle.Update(gametime);
            walk.Update(gametime);
            taunt.Update(gametime);
            if (hasJumped)
            {
                jump.Update(gametime);
            }
            else
            {
                jump.Reset();
            }

            previousKeyState = currentKeyState;

        }





        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTop(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if (rectangle.TouchLeft(newRectangle))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    position.X = newRectangle.X - rectangle.Width - 2;

            }

            if (rectangle.TouchRight(newRectangle))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    position.X = newRectangle.X + newRectangle.Width + 2;


            }
            if (rectangle.TouchBottom(newRectangle))
            {
                velocity.Y = 1f;

            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.Y = yOffset - rectangle.Height;
        }


        public void Draw(SpriteBatch spritebatch)
        {

            if (isWalkingRight)
            {
                walk.Draw(spritebatch, position, false);
            }
            if (isWalkingLeft)
            {
                walk.Draw(spritebatch, position, true);
            }
            if (isIdle)
            {
                idle.Draw(spritebatch, position);
            }
            if (isTaunting)
            {
                taunt.Draw(spritebatch, position);
            }
            if (hasJumped)
            {
                jump.Draw(spritebatch, position);
            }

            //spritebatch.Draw(Statemachine.Pixel, rectangle, Color.White);
        }






    }
}
