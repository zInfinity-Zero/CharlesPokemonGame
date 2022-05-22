using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokeMen
{
    class HealthBar
    {
        private Texture2D texture;
        private Vector2 position;
        private Jokemon jokemon;

        public HealthBar()
        {

        }

        public HealthBar(Texture2D t,Jokemon j, Vector2 pos)
        {
            texture = t;
            jokemon = j;
            position = pos;
        }


        public void DrawHealth(SpriteBatch s)
        {
            if (jokemon.health > 0)
            {
                s.Begin();
                s.Draw(texture, new Rectangle((int)position.X, (int)position.Y, jokemon.health, 20), Color.White);
                s.End();
            }
        }
    }
}
