﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace PokeMen
{
    class Tree : Sprite
    {
        public bool isCollidable = true;

        public Tree(Texture2D tex, Vector2 pos, Vector2 size) : base(tex, pos, size)
        {

        }
    }
}
