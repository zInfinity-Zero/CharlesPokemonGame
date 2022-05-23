﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CharlesPokemon
{
    class ReadableObject : Sprite
    {
        public bool isCollidable = true;
        public bool hasCollision = true;

        public ReadableObject(Texture2D tex, Vector2 pos, Vector2 size) : base(tex, pos, size)
        {

        }
    }
}
