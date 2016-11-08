using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace OnePiece
{
    public class Animation
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int animationSpriteCountX;
        private int animationSpriteCountY;
        private float animationTime;
        private float currentAnimationTime;
        private int animationSpriteHeight;
        private int animationSpriteWidth;
        private List<Rectangle> animationSprites;
        public bool Isloop;

        public Animation(Texture2D spriteSheet, int countX, int countY, int width, int height, float time, bool IsLoop = true)
        {
            this.spriteSheet = spriteSheet;
            this.animationSpriteCountX = countX;
            this.animationSpriteCountY = countY;
            this.animationSpriteWidth = width;
            this.animationSpriteHeight = height;
            this.animationTime = time;
            this.currentAnimationTime = 0.0f;
            this.currentFrame = 0;
            this.animationSprites = new List<Rectangle>();
            Isloop = IsLoop;

            Load();
        }

        protected void Load()
        {
            Rectangle rect;
            for (int y = 0; y < animationSpriteCountY; y++)
            {
                for (int x = 0; x < animationSpriteCountX; x++)
                {
                    rect.X = animationSpriteWidth * x;
                    rect.Y = animationSpriteHeight * y;
                    rect.Width = animationSpriteWidth;
                    rect.Height = animationSpriteHeight;

                    animationSprites.Add(rect);
                }

            }
        }

        public Vector2 GetFrameWidthAndHeight()
        {
            return new Vector2(animationSpriteWidth, animationSpriteHeight);
        }

        public bool Update(GameTime gameTime)
        {
            bool finishedAnimation = false;
            float deltaTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            currentAnimationTime -= deltaTime;

            if (currentAnimationTime <= 0.0f)
            {
                currentFrame++;

                if (currentFrame >= animationSprites.Count)
                {
                    if (Isloop)
                    {
                        currentFrame = 0;

                    }
                    else
                    {
                        currentFrame = animationSprites.Count - 1;
                    }
                    
                    finishedAnimation = true;
                }
                currentAnimationTime = animationTime;
            }
            return finishedAnimation;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, bool InvertHorizontal = false)
        {
            SpriteEffects appliedEffect = SpriteEffects.None;
            if (InvertHorizontal)
                appliedEffect = SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(spriteSheet, new Rectangle((int)position.X, (int)position.Y, animationSpriteWidth, animationSpriteHeight), animationSprites[currentFrame], Color.White, 0.0f, Vector2.Zero, appliedEffect, 0.0f);

        }

        internal void Reset()
        {
            currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float scaleFactor, bool InvertHorizontal = false)
        {
            SpriteEffects appliedEffect = SpriteEffects.None;
            if (InvertHorizontal)
                appliedEffect = SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(spriteSheet, position, animationSprites[currentFrame], Color.White, 0f, Vector2.Zero, scaleFactor, appliedEffect, 0.0f);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float scaleFactor, float rotation, bool InvertHorizontal = false)
        {
            SpriteEffects appliedEffect = SpriteEffects.None;
            if (InvertHorizontal)
                appliedEffect = SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(spriteSheet, position, animationSprites[currentFrame], Color.White, rotation, Vector2.Zero, scaleFactor, appliedEffect, 0.0f);
        }




        

    }
}
