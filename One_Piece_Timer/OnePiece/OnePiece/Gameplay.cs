using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OnePiece
{
    class Gameplay : State
    {
        Estates targetState;
        //Texture2D Charactertexture;
        //Rectangle Position;
        Charakter charakter;
        GameBackground gamebackground;
        Map map;
        Healthbar healthbar;
        Enemy1 enemy1;
        Enemy2 enemy2;

        Timer timer;
        float attackCooldown = 1f;
        //Vector2 newPosition;
        //float newDistance;


        public Gameplay(Texture2D idleSpriteSheet, Texture2D walkSpriteSheet, Texture2D tauntSpriteSheet, Texture2D jumpSpriteSheet, Texture2D backgroundtexture, Map map, Texture2D healthtexture, Texture2D enemyIdleSpritesheet, Texture2D enemyWalkSpritesheet)
        {
            //Charactertexture = charactertexture;
            charakter = new Charakter(idleSpriteSheet, walkSpriteSheet, tauntSpriteSheet, jumpSpriteSheet);
            gamebackground = new GameBackground(backgroundtexture);
            this.map = map;
            healthbar = new Healthbar(healthtexture);
            enemy1 = new Enemy1(enemyIdleSpritesheet, enemyWalkSpritesheet/* newPosition, newDistance*//*new Vector2(80,440)*/);
            enemy2 = new Enemy2(enemyIdleSpritesheet, enemyWalkSpritesheet);
            //camera = new Camera(GraphicsDevice.Viewport);
        }

        ////public Gameplay(Texture2D backgroundtexture)
        ////{
        ////    gamebackground = new GameBackground(backgroundtexture);
        ////}


        public override void Dispose()
        {

        }

        public override void Initialize()
        {
            targetState = Estates.Gameplay;
            timer = new Timer();
        }

        KeyboardState currentKeyState;
        KeyboardState previousKeyState;

        public override Estates Update(GameTime gametime)
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
            charakter.Update(gametime);
            enemy1.Update(gametime, charakter);
            enemy2.Update(gametime, charakter);
            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                charakter.Collision(tile.Rectangle, map.Width, 800);
                enemy1.Collision(tile.Rectangle, map.Width, 800);
                enemy2.Collision(tile.Rectangle, map.Width, 800);
                //Camera.Update(charakter.);
                Camera.Main.Position = charakter.Position;

                if (Camera.Main.Position.X < Camera.Main.Bounds.Width / 2f)
                    Camera.Main.Position = new Vector2(Camera.Main.Bounds.Width / 2f, Camera.Main.Position.Y);
                if (Camera.Main.Position.Y < Camera.Main.Bounds.Height / 2f)
                    Camera.Main.Position = new Vector2(Camera.Main.Position.X, Camera.Main.Bounds.Height / 2f);

            }
            //if (enemy1.Position.X == charakter.Position.X -10  ||  enemy1.Position.X == charakter.Position.X +10)
            if (charakter.CharacterRectangle.Intersects(enemy1.Enemy1Rectangle) || charakter.CharacterRectangle.Intersects(enemy2.Enemy2Rectangle))
            {
                healthbar.DecreaseHealth();
                HealthHandler(gametime);
            }

           
            healthbar.Update(gametime);

            return targetState;
        }

        public void HealthHandler(GameTime gametime)
        {
            timer.Update(gametime);
            attackCooldown -= timer.Current.Seconds;
            if (attackCooldown <= 0)
            {
                healthbar.DecreaseHealth();
                attackCooldown = 1f;
            }
        }



        public override void Draw(SpriteBatch spritebatch)
        {
            //spritebatch.Draw(BackgroundTexture, new Vector2(), Color.White);
            //foreach (CollisionTiles tile in map.CollisionTiles)

            spritebatch.Begin();
            gamebackground.Draw(spritebatch);
            spritebatch.End();
            spritebatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, Camera.Main.TransformMatrix);
            

            map.Draw(spritebatch);

            charakter.Draw(spritebatch);
            enemy1.Draw(spritebatch);
            enemy2.Draw(spritebatch);
            spritebatch.End();
            spritebatch.Begin();
            healthbar.Draw(spritebatch);
            spritebatch.End();
        }


    }
}
