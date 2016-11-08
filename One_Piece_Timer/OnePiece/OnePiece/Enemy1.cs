using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnePiece
{
    class Enemy1
    {
        public enum EnemyState
        {
            idle,
            patrolling,
            hunting
        }

        EnemyState state;
        Animation Enemyidle, Enemywalk;
        Vector2 position /*= new Vector2(40, 440)*/;
        Vector2 velocity;
        Rectangle rectangle;
        float distance;



        bool EnemyisWalkingRight = false;
        bool EnemyisWalkingLeft = false;
        bool EnemyisIdle = true;

        //Enemy1 enemy1;

        public Vector2 Position
        {
            get { return position; }
        }

        public Rectangle Enemy1Rectangle
        {
            get { return rectangle; }
        }
        public Enemy1(Texture2D EnemyIdleSpriteSheet, Texture2D EnemyWalkSpriteSheet)
        {
            Enemyidle = new Animation(EnemyIdleSpriteSheet, 3, 1, 199 / 3, 54, 0.3f);
            Enemywalk = new Animation(EnemyWalkSpriteSheet, 5, 1, 344 / 5, 59, 0.1f);

            position = new Vector2(200, 440);
        }

        public void Update(GameTime gameTime, Charakter charakter)
        {
            Console.WriteLine(state);

            velocity.Y += 0.15f;
            distance = charakter.Position.X - this.position.X;

            EnemyisWalkingRight = false;
            EnemyisWalkingLeft = false;


            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 45, 54);


            switch (state)
            {
                case EnemyState.idle:
                    //velocity.X = 0;
                    UpdateIdle();

                    if (Math.Abs(distance) < 150)
                        state = EnemyState.hunting;
                    break;
                case EnemyState.patrolling:
                    break;
                case EnemyState.hunting:
                    UpdateHunting();

                    if (Math.Abs(distance) > 150)
                        state = EnemyState.idle;
                    break;
            }


            Enemyidle.Update(gameTime);
            Enemywalk.Update(gameTime);

        }
        private void UpdateIdle()
        {
            EnemyisIdle = true;
            EnemyisWalkingLeft = false;
            EnemyisWalkingRight = false;

            velocity.X = 0;
        }
        private void UpdateHunting()
        {
            if (distance > 0)
            {
                EnemyisWalkingRight = true;
                EnemyisWalkingLeft = false;
                velocity.X = 1f;
            }

            else if (distance < 0)
            {
                EnemyisWalkingRight = false;
                EnemyisWalkingLeft = true;
                velocity.X = -1f;
            }
            //else
            //{
            //    velocity.X = 0;
            //}
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {


            if (rectangle.TouchLeft(newRectangle))
            {
                if (EnemyisWalkingRight)
                {
                    position.X = newRectangle.X - rectangle.Width - 2;
                    velocity.X = 0;
                }

            }

            if (rectangle.TouchRight(newRectangle))
            {
                if (EnemyisWalkingLeft)
                {
                    position.X = newRectangle.X + newRectangle.Width + 2;
                    velocity.X = 0;
                }

            }
            if (rectangle.TouchTop(newRectangle))
            {

                position.Y += newRectangle.Top - rectangle.Bottom;
                velocity.Y = 0f;
            }


            //if (position.Y  >= 520)
            //{
            //    velocity.Y -= 5f;
            //}



            //if (rectangle.TouchBottom(newRectangle))
            //{
            //    velocity.Y = 1f;

            //}

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.Y = yOffset - rectangle.Height;

            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X > 0)
            {
                Enemywalk.Draw(spriteBatch, position, true);
            }
            else if (velocity.X == 0)
            {
                Enemyidle.Draw(spriteBatch, position);
            }
            else
                Enemywalk.Draw(spriteBatch, position, false);

            ////enemy1.Draw(spriteBatch);
            //spriteBatch.Draw(Statemachine.Pixel, rectangle, Color.White);
        }




    }
}