using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CharlesPokemon
{
    internal class PhysicsManager
    {
        private float speed = 0.04f;
        private int collisionOffset = 3;
        public bool sign = false;
        public bool sign1text = false, sign2text = false, sign3text = false;
        public bool boolean { get; set; } = false;

        public int skinshopc { get; set; } = 0;

        public void checkCollision(Player p, Tree t)
        {
            Rectangle treeRec = new Rectangle((int)t.spritePosition.X, (int)t.spritePosition.Y, (int)t.spriteSize.X, (int)t.spriteSize.Y);

            if (p.goingUp)
            {
                p.projectedPos = new Vector2(p.spritePosition.X, p.spritePosition.Y - collisionOffset);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(treeRec))
                {
                    p.hasCollidedTop = true;
                }
                if(p.hasCollidedTop == false)
                {
                    goUp(p);
                    p.hasCollidedBottom = false;
                }
            }

            else if (p.goingDown)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y + collisionOffset);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(treeRec))
                {
                    p.hasCollidedBottom = true;
                }
                if (p.hasCollidedBottom == false)
                {
                    goDown(p);
                    p.hasCollidedTop = false;

                }
            }
            else if (p.goingLeft)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X - collisionOffset, (int)p.spritePosition.Y);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(treeRec))
                {
                    p.hasCollidedLeft = true;
                }
                if (p.hasCollidedLeft == false)
                {
                    goLeft(p);

                    p.hasCollidedRight = false;

                }
            }
            else if (p.goingRight)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X + collisionOffset, (int)p.spritePosition.Y);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(treeRec))
                {
                    p.hasCollidedRight = true;
                }
                if (p.hasCollidedRight == false)
                {
                    goRight(p);
      
                    p.hasCollidedLeft = false;

                }

            }
        }
        public void checkCollision(Player p, Building b)
        {
            Rectangle BuildingRec = new Rectangle((int)b.spritePosition.X, (int)b.spritePosition.Y, (int)b.spriteSize.X, (int)b.spriteSize.Y);

            if (p.goingUp)
            {
                p.projectedPos = new Vector2(p.spritePosition.X, p.spritePosition.Y - collisionOffset);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(BuildingRec))
                {
                    p.hasCollidedTop = true;
                }
                if (p.hasCollidedTop == false)
                {
                    goUp(p);
                    p.hasCollidedBottom = false;
                    p.hasCollidedLeft = false;
                    p.hasCollidedRight = false;

                }
            }

            else if (p.goingDown)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y + collisionOffset);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(BuildingRec))
                {
                    p.hasCollidedBottom = true;
                }
                if (p.hasCollidedBottom == false)
                {
                    goDown(p);
                    p.hasCollidedTop = false;
                    p.hasCollidedLeft = false;
                    p.hasCollidedRight = false;

                }
            }
            else if (p.goingLeft)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X - collisionOffset, (int)p.spritePosition.Y);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(BuildingRec))
                {
                    p.hasCollidedLeft = true;
                }
                if (p.hasCollidedLeft == false)
                {
                    goLeft(p);
          
                    p.hasCollidedRight = false;
                    p.hasCollidedTop= false;
                    p.hasCollidedBottom = false;
                }
            }
            else if (p.goingRight)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X + collisionOffset, (int)p.spritePosition.Y);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(BuildingRec))
                {
                    p.hasCollidedRight = true;
                }
                if (p.hasCollidedRight == false)
                {
                    goRight(p);
     
                    p.hasCollidedLeft = false;
                    p.hasCollidedTop = false;
                    p.hasCollidedBottom = false;

                }

            }
        }

        public bool CheckCollision (Player p, ReadableObject r,Jokemon user,Jokemon enemy)
        {
            Rectangle playerpos = new Rectangle((int)p.spritePosition.X, (int)p.spritePosition.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
            Rectangle rpos = new Rectangle((int)r.spritePosition.X, (int)r.spritePosition.Y, (int)r.spriteSize.X, (int)r.spriteSize.Y);
            if (playerpos.Intersects(rpos))
            {
                user.health = 100;
                enemy.health = 100;
                return true;
            }
            else
                return false;
        }

        public void CheckCollisionSign(Player p, ReadableObject s, ReadableObject t, ReadableObject u)
        {
            Rectangle playerpos = new Rectangle((int)p.spritePosition.X, (int)p.spritePosition.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
            Rectangle spos = new Rectangle((int)s.spritePosition.X, (int)s.spritePosition.Y, (int)s.spriteSize.X, (int)s.spriteSize.Y);
            Rectangle tpos = new Rectangle((int)t.spritePosition.X, (int)t.spritePosition.Y, (int)t.spriteSize.X, (int)t.spriteSize.Y);
            Rectangle upos = new Rectangle((int)u.spritePosition.X, (int)u.spritePosition.Y, (int)u.spriteSize.X, (int)u.spriteSize.Y);

            if (playerpos.Intersects(spos))
            {
                if (p.goingUp)
                {
                    sign = true;
                    sign1text = true;
                    sign2text = false;
                    sign3text = false;
                }

                
            }
            else if (playerpos.Intersects(tpos))
            {
                if (p.goingUp)
                {
                    sign = true;
                    sign2text = true;
                    sign1text = false;
                    sign3text = false;

                }


            }
            else if (playerpos.Intersects(upos))
            {
                if (p.goingUp)
                {
                    sign = true;
                    sign3text = true;
                    sign1text = false;
                    sign2text = false;
                }


            }

        }


        public bool CheckCollisionDoor(Player p,Sprite door)
        {
            bool boolean = false;
            Rectangle playerpos = new Rectangle((int)p.spritePosition.X, (int)p.spritePosition.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
            Rectangle doorpos = new Rectangle((int)door.spritePosition.X, (int)door.spritePosition.Y, (int)door.spriteSize.X, (int)door.spriteSize.Y);
            if (playerpos.Intersects(doorpos))
            {
                boolean = true;
            }
            else
                boolean = false;

            return boolean;
        }

        public bool CheckCollisionSkinshop(Player p, Sprite shop2,Sprite shop3,Sprite shop4)
        {
            Rectangle playerpos = new Rectangle((int)p.spritePosition.X, (int)p.spritePosition.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
            Rectangle shop2pos = new Rectangle((int)shop2.spritePosition.X, (int)shop2.spritePosition.Y, (int)shop2.spriteSize.X, (int)shop2.spriteSize.Y);
            Rectangle shop3pos = new Rectangle((int)shop3.spritePosition.X, (int)shop3.spritePosition.Y, (int)shop3.spriteSize.X, (int)shop3.spriteSize.Y);
            Rectangle shop4pos = new Rectangle((int)shop4.spritePosition.X, (int)shop4.spritePosition.Y, (int)shop4.spriteSize.X, (int)shop4.spriteSize.Y);


            if (playerpos.Intersects(shop2pos))
            {
                boolean = true;
                skinshopc = 2;
            }
            else if (playerpos.Intersects(shop3pos))
            {
                boolean = true;
                skinshopc = 3;
            }
            else if (playerpos.Intersects(shop4pos))
            {
                boolean = true;
                skinshopc = 4;
            }
            else
                boolean = false;

            return boolean;
        }
        public void goLeft(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X - speed, playerSprite.spritePosition.Y);
            playerSprite.moveleft = true;
            playerSprite.moveright= false;
        }

        public void goRight(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X + speed, playerSprite.spritePosition.Y);
            playerSprite.moveleft = false;
            playerSprite.moveright = true;
        }

        public void goDown(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X, playerSprite.spritePosition.Y + speed);
        }

        public void goUp(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X, playerSprite.spritePosition.Y - speed);
        }



    }
}
