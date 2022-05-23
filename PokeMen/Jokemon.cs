using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CharlesPokemon
{
    class Jokemon : Sprite
    {
        public int health { get; set; }
        public int power { get; set; }
        public int defense { get; set; }
        public int attack { get; set; }

        public bool rage { get; set; }

        public int dodge { get; set; } = 0;

        public bool vision { get; set; }

        public bool mirror { get; set; }

        public Jokemon()
        {

        }
        public Jokemon(Texture2D tex, Vector2 pos, Vector2 size, int HP, int atk, int def) : base(tex, pos, size)
        {
            health = HP;
            defense = def;
            attack = atk;
        }


        




    }
}
