using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharlesPokemon
{
    class Camera
    {
        public Matrix Transform { get; set; }
        private Viewport viewport;
        public float zoomvalue = 1.75f;
        public void Follow (Sprite sprite)
        {
            Matrix position = Matrix.CreateTranslation(-sprite.spritePosition.X - sprite.spriteSize.X / 2, -sprite.spritePosition.Y - sprite.spriteSize.Y / 2, 0);
            Matrix offset = Matrix.CreateTranslation(250,200, 0);
            Matrix zoom = Matrix.CreateScale(zoomvalue, zoomvalue, 0);
            Transform = position * offset * zoom;
        }
        public void NoFollow(Sprite sprite)
        {
            Matrix position = Matrix.CreateTranslation(-sprite.spritePosition.X - sprite.spriteSize.X / 2, -sprite.spritePosition.Y - sprite.spriteSize.Y / 2, 0);
            Matrix offset = Matrix.CreateTranslation(400, 400, 0);
            Transform = position * offset;
        }

        public Camera (Viewport newvp)
        {
            viewport = newvp;
        }
    }
}
