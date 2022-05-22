using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace PokeMen
{
    class Sprite
    {
        public Vector2 spritePosition { get; set; }
        public Vector2 spriteSize { get; set; }
        public Texture2D spriteTexture { get; set; }

        public Color spriteColor = Color.White;

        public Sprite()
        {

        }

        public Sprite(Texture2D tex, Vector2 pos, Vector2 size)
        {
            this.spriteTexture = tex;
            this.spritePosition = pos;
            this.spriteSize = size;
        }


        public void DrawSprite(SpriteBatch s, Texture2D t, Camera camera)
        {
            spriteTexture = t;

            s.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null,  camera.Transform);

            s.Draw(spriteTexture, new Rectangle((int)spritePosition.X, (int)spritePosition.Y, (int)spriteSize.X, (int)spriteSize.Y), spriteColor);

            s.End();


        }

        public void DrawSpriteNoZoom(SpriteBatch s, Texture2D t)
        {
            spriteTexture = t;

            s.Begin();

            s.Draw(spriteTexture, new Rectangle((int)spritePosition.X, (int)spritePosition.Y, (int)spriteSize.X, (int)spriteSize.Y), spriteColor);

            s.End();


        }




    }
}
