using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CharlesPokemon
{
    class InputManager
    {
        KeyboardState state;

        public void checkKeyboard(Player playerSprite)
        {
            state = Keyboard.GetState();
            playerSprite.goingLeft = false;
            playerSprite.goingRight = false;
            playerSprite.goingUp = false;
            playerSprite.goingDown = false;

            if (state.IsKeyDown(Keys.A))
            {
                playerSprite.goingLeft = true;
            }

            if (state.IsKeyDown(Keys.D))
            {
                playerSprite.goingRight = true;
            }

            if (state.IsKeyDown(Keys.W))
            {
                playerSprite.goingUp = true;
            }

            if (state.IsKeyDown(Keys.S))
            {
                playerSprite.goingDown = true;
            }
            if (state.IsKeyDown(Keys.G))
            {
                playerSprite.coins += 10;
            }
           
            if (state.IsKeyDown(Keys.D1))
            {
                playerSprite.costume = 1;
            }

            if (state.IsKeyDown(Keys.D2))
            {
                playerSprite.costume = 2;
            }
            if (state.IsKeyDown(Keys.D3))
            {
                playerSprite.costume = 3;
            }
            if (state.IsKeyDown(Keys.D4))
            {
                playerSprite.costume = 4;
            }


        }



    }
}
