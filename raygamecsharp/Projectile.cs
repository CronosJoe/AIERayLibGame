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
       public string type;//might not use just setting up for the possibility
       public string name;


        public void Fired(Projectile[] bullets, Player player)
        {
            for(int i = bullets.Length-1; i == 0; i--)
            {
                if (bullets[i].fired == false)
                {
                    bullets[i].fired = true;
                    bullets[i].xPos = player.posX;
                    bullets[i].yPos = player.posY;
                    return;
                }
            }
        }


       
    }
}
