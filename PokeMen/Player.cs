using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokeMen
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

        public Player(Texture2D tex, Vector2 pos, Vector2 size) : base(tex, pos, size)
        {
          
        }

    }
}
