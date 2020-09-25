using System;
using Raylib_cs;
using static Raylib_cs.Color;
using static Raylib_cs.Raylib;
namespace raygamecsharp
{
    public class SpecialEnemy : BasicEnemy
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
                    speed *= 3;
                    break;

                case 2:
                    speed *= 2;
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
                speed *= 3;
            }
            else
            {
                col = BLUE;
                speed *=2;
            }
            
        }
        #region methods
        //these methods are all simply overloads of the methods in Basic enemy they do about the same thing just with different arguments from the SpecialEnemy class
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
        public void Reset(SpecialEnemy[] enArr, int index) //this will reset the enemy object above the stage view so that once they are set to alive again they are ready to move down.
        {
            enArr[index].enYPos = -100;
            enArr[index].isAlive = false;
        }
        #endregion
    }
}
