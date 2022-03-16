using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace PokeMen
{
    internal class PhysicsManager
    {
        private float speed = 0.1f;
        private int collisionOffset = 3;
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

        public void goLeft(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X - speed, playerSprite.spritePosition.Y);
        }

        public void goRight(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X + speed, playerSprite.spritePosition.Y);
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
