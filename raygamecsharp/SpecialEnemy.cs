using System;
using Raylib_cs;
using static Raylib_cs.Color;
using static Raylib_cs.Raylib;
namespace raygamecsharp
{
    public class SpecialEnemy : BasicEnemy, ISpecialEnemy
    {
        public Color col;
        public int type;
        
        public SpecialEnemy(string iD, int width, int height, int enYPos, int type) : base(iD, width, height, enYPos) //this will create a hidden typed enemy
        {
            ID = iD;
            this.width = width;
            this.height = height;
            this.enYPos = enYPos;
            col = PURPLE;
            this.isAlive = false;
            switch (type)
            {
                case 1:
                    speed *= 2;
                    break;

                case 2:
                    speed /= 2;
                    break;

            }
            
        }

        public SpecialEnemy(string iD, int width, int height, int enYPos, bool slowFast) : base(iD, width, height, enYPos) //this specifically makes revealed traited enemy
        {
            ID = iD;
            this.width = width;
            this.height = height;
            this.enYPos = enYPos;
            this.isAlive = false;
            if (slowFast)
            {
                col = RED;
                speed *= 2;
            }
            else
            {
                col = BLUE;
                speed *= 1/2;
            }
            
        }

        public void DrawEnemy(SpecialEnemy specEn)
        {
            DrawRectangle(specEn.enemySpot, specEn.enYPos, specEn.width, specEn.height, specEn.col);
        }
        public void MoveEnemy(SpecialEnemy[] enemylist)
        {
            for (int i = 0; i < enemylist.Length; i++)
            {
                if (enemylist[i].isAlive)
                {
                    enemylist[i].enYPos += enemylist[i].speed;
                }
            }
        }
        public void LossCheck(Player player, SpecialEnemy[] enArr)
        {
            for (int i = 0; i < enArr.Length; i++)
            {
                if (enArr[i].enYPos >= player.posY)
                {
                    player.state = State.End;
                }
            }

        }
        public void Reset(SpecialEnemy[] enArr, int index)
        {
            enArr[index].enYPos = -100;
            enArr[index].isAlive = false;
        }
    }
}
