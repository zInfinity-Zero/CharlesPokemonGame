using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CharlesPokemon
{
    class BattleSystem
    {
        public bool battle = false;
        public bool userturn = false;
        public bool enemyturn = true;
        private string choice;


        public void Battling(Jokemon user, Jokemon enemy,bool b,Sprite skillbox1, Sprite skillbox2, Sprite skillbox3, Sprite skillbox4, Sprite skillbox5, Sprite skillbox6, Sprite eskillbox6, Sprite eskillbox5, Sprite eskillbox4, Sprite eskillbox3, Sprite eskillbox2, Sprite eskillbox1,Texture2D atkt, Texture2D mirrort, Texture2D storet, Texture2D visiont, Texture2D dodget, Texture2D raget, Texture2D def)
        {
            
            this.AI();
            userturn = true;
          
    
            if (userturn)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Rectangle mouserec = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
                    Rectangle skillbox1rec = new Rectangle((int)skillbox1.spritePosition.X, (int)skillbox1.spritePosition.Y, (int)skillbox1.spriteSize.X, (int)skillbox1.spriteSize.Y);
                    Rectangle skillbox2rec = new Rectangle((int)skillbox2.spritePosition.X, (int)skillbox2.spritePosition.Y, (int)skillbox2.spriteSize.X, (int)skillbox2.spriteSize.Y);
                    Rectangle skillbox3rec = new Rectangle((int)skillbox3.spritePosition.X, (int)skillbox3.spritePosition.Y, (int)skillbox3.spriteSize.X, (int)skillbox3.spriteSize.Y);
                    Rectangle skillbox4rec = new Rectangle((int)skillbox4.spritePosition.X, (int)skillbox4.spritePosition.Y, (int)skillbox4.spriteSize.X, (int)skillbox4.spriteSize.Y);
                    Rectangle skillbox5rec = new Rectangle((int)skillbox5.spritePosition.X, (int)skillbox5.spritePosition.Y, (int)skillbox5.spriteSize.X, (int)skillbox5.spriteSize.Y);
                    Rectangle skillbox6rec = new Rectangle((int)skillbox6.spritePosition.X, (int)skillbox6.spritePosition.Y, (int)skillbox6.spriteSize.X, (int)skillbox6.spriteSize.Y);

                    if (mouserec.Intersects(skillbox1rec))
                    {
                        if (choice != "Mirror")
                        {
                            enemy.health -= user.attack;
                            userturn = false;
                        }
                        else
                        {
                            user.health -= user.attack;
                            userturn = false;
                        }
                    }
                    else if (mouserec.Intersects(skillbox2rec))
                    {

                        user.mirror = true;
                        userturn = false;
                    }
                    else if (mouserec.Intersects(skillbox3rec))
                    {

                        user.attack += 3;
                        user.defense += 2;
                        userturn = false;
                    }
                    else if (mouserec.Intersects(skillbox4rec))
                    {

                        user.vision = true;
                        userturn = false;
                    }
                    else if (mouserec.Intersects(skillbox5rec))
                    {

                        user.dodge += 5;
                        userturn = false;
                    }
                    else if (mouserec.Intersects(skillbox6rec))
                    {

                        user.rage = true;
                        userturn = false;
                    }

                    //e
                    if (choice == "Mirror")
                    {
                        eskillbox2.spriteTexture = mirrort;
                        eskillbox1.spriteTexture = def;
                        eskillbox3.spriteTexture = def;
                        eskillbox4.spriteTexture = def;
                        eskillbox5.spriteTexture = def;
                        eskillbox6.spriteTexture = def;
                    }
                       
                    if (choice == "Attack")
                    {
                        eskillbox1.spriteTexture = atkt;
                        eskillbox2.spriteTexture = def;
                        eskillbox3.spriteTexture = def;
                        eskillbox4.spriteTexture = def;
                        eskillbox5.spriteTexture = def;
                        eskillbox6.spriteTexture = def;
                        if (!user.mirror)
                        {
                            user.health -= enemy.attack;
                        }
                        else
                            enemy.health -= enemy.attack;

                    }

                    else if (choice == "Store")
                    {
                        eskillbox3.spriteTexture = storet;
                        eskillbox1.spriteTexture = def;
                        eskillbox2.spriteTexture = def;
                        eskillbox4.spriteTexture = def;
                        eskillbox5.spriteTexture = def;
                        eskillbox6.spriteTexture = def;
                        enemy.attack += 3;
                        enemy.defense += 2;
                    }
                    else if (choice == "Dodge")
                    {
                        eskillbox5.spriteTexture = dodget;
                        eskillbox1.spriteTexture = def;
                        eskillbox3.spriteTexture = def;
                        eskillbox4.spriteTexture = def;
                        eskillbox2.spriteTexture = def;
                        eskillbox6.spriteTexture = def;
                        enemy.dodge += 5;
               
                    }
                    else if (choice == "Rage")
                    {
                        eskillbox6.spriteTexture = raget;
                        eskillbox1.spriteTexture = def;
                        eskillbox3.spriteTexture = def;
                        eskillbox4.spriteTexture = def;
                        eskillbox5.spriteTexture = def;
                        eskillbox2.spriteTexture = def;
                        enemy.rage = true;
                    }
                }
            }
            //Thread.Sleep(300);
  

           
        }

        public void AI()
        {//manipulate probability so if user is rage or smthing increase the chance of shield and no double rage stuff

            Random random = new Random();
            int a = random.Next(1, 6);
            switch (a)
            { 
                case 1:
                    choice = "Attack";
                    break;
                case 2:
                    choice = "Mirror";
                    break;
                case 3:
                    choice = "Store";
                    break;
                case 4:
                    choice = "Dodge";
                    break;
                case 5:
                    choice = "Rage";
                    break;


            }
                    

        }
    }
}
