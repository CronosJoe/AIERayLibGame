using static Raylib_cs.Raylib;
using System.Numerics;
using System;
using Raylib_cs;
using static Raylib_cs.Color;
namespace raygamecsharp
{
    public class Projectile
    {
       public int shotSpeed;
       public Vector2 spot;
       public int yPos;
       public int xPos;
       public int width;
       public int height;
       public bool fired = false;
       public string name;


        public void Fired(Projectile[] bullets, Player player)
        {
            for(int i = 0; i <bullets.Length; i++) //check through each bullet until it finds one that hasn't been fired then fires it, with larger stages it would be more then 2 shots
            {
                if (!bullets[i].fired)
                {
                    bullets[i].fired = true;
                    bullets[i].xPos = player.posX;
                    bullets[i].yPos = player.posY;
                    return;
                }
            }
        }

        public void MoveBullet(Projectile[] bullets)
        {
            for (int i = 0; i < bullets.Length; i++) //this is pretty easy moves the bullet up the stage if it has been fired
            {
                if (bullets[i].fired)
                {
                    bullets[i].yPos -= bullets[i].shotSpeed;
                }
            }
        }

        public void DrawBullet(Projectile bullet) //art stuffs
        {
            DrawRectangle(bullet.xPos,bullet.yPos,bullet.width,bullet.height, SKYBLUE);
            DrawRectangleLines(bullet.xPos, bullet.yPos, bullet.width, bullet.height, GREEN);
        }
        public void OutOfBounds(Projectile[] bullets)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].yPos <= 0)
                {
                    bullets[i].fired = false;
                    bullets[i].yPos = (int)bullets[i].spot.Y;
                    bullets[i].xPos = (int)bullets[i].spot.X;
                    
                }

            }
        }
        public void ResetPos(Projectile[] proArr, int index)
        {
            proArr[index].xPos = (int)proArr[index].spot.X;
            proArr[index].yPos = (int)proArr[index].spot.Y;
            proArr[index].fired = false;
        }

       
    }
}
