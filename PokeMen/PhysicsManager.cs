using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace PokeMen
{
    internal class PhysicsManager
    {
        private float speed = 0.05f;
        private int collisionOffset = 3;
        public bool sign = false;
        public bool sign1text = false, sign2text = false, sign3text = false;

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
