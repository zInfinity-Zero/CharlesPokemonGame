using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CharlesPokemon
{
    class MouseManager
    {
        public bool click { get; set; } = false;
        public bool CheckClickonSprite(Sprite s)
        {
            Rectangle mouserec = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 50, 50);
            Rectangle srec = new Rectangle((int)s.spritePosition.X, (int)s.spritePosition.Y, (int)s.spriteSize.X, (int)s.spriteSize.Y);

           
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                
                if (mouserec.Intersects(srec))
                {
                    click = true;
                   
                }
      
          
            }

            return click;
        }
    }
}
