using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeMen
{
    class Camera
    {
        public Matrix Transform { get; set; }

        public void Follow (Sprite sprite)
        {
            Matrix position = Matrix.CreateTranslation(-sprite.spritePosition.X - sprite.spriteSize.X / 2, -sprite.spritePosition.Y - sprite.spriteSize.Y / 2, 0);
            Matrix offset = Matrix.CreateTranslation(400,400, 0);
            Matrix zoom = Matrix.CreateScale(new Vector3(float(0.1f), float(0.1f), 0));
            Transform = position * offset;
        }
    }
}
