using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokeMen
{
    class BattleSystem
    {
        public bool battleOver = false;
        private bool testattack = false;

        public void Battling(Jokemon jokemon, Jokemon enemy)
        {
            while (!battleOver)
            {

                if (jokemon.health <= 0 || enemy.health <= 0)
                {
                    battleOver = true;
                }

            }
        }
    }
}
