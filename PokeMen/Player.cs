using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CharlesPokemon
{
    class Player : Sprite
    {

        public Vector2 projectedPos;
        public bool hasCollidedTop = false;
        public bool hasCollidedBottom = false;
        public bool hasCollidedLeft = false;
        public bool hasCollidedRight = false;
        public bool goingLeft;
        public bool goingRight;
        public bool goingUp;
        public bool goingDown;
        public bool moveright = false;
        public bool moveleft = false;
        public int coins { get; set; } = 500;

        public int costume { get; set; } = 2;
        public Texture2D spriteTextureb { get; set; }
        public Texture2D spriteTexture { get; set; }

        public Texture2D spriteTexture2b { get; set; }
        public Texture2D spriteTexture2 { get; set; }



        public Player(Texture2D tex,Texture2D texb, Texture2D tex2, Texture2D tex2b, Vector2 pos, Vector2 size) : base(tex, pos, size)
        {
            spriteTexture = tex;
            spriteTextureb = texb;

            spriteTexture2 = tex2;
            spriteTexture2b = tex2b;

        }

    }
}
