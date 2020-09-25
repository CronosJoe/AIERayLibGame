using System;
using Raylib_cs;
using static Raylib_cs.Color;
using static Raylib_cs.Raylib;
namespace raygamecsharp
{
    public class BasicEnemy
    {
        #region variables
        //This is how fast the enemy will move down the stage every frame
        public int speed = 1; 
        public string ID;
        //these are default values because the stage will be set by the player's size
        public int width; 
        public int height;
        public bool isAlive = false;
        public int enemySpot;
        public int enYPos;
        #endregion
        #region constructor
        public BasicEnemy(string iD, int width, int height, int enYPos)
        {
            ID = iD;
            this.width = width;
            this.height = height;
            this.enYPos = enYPos;
        }
        #endregion
        #region methods
        public void MoveEnemy(BasicEnemy[] enemylist)
        {
            for (int i = 0; i < enemylist.Length; i++)
            {
                if (enemylist[i].isAlive)
                {
                    enemylist[i].enYPos += enemylist[i].speed;
                }
            }
        }
        public void DrawEnemy(BasicEnemy enemy)
        {
            DrawRectangle( enemy.enemySpot, enemy.enYPos, enemy.width,enemy.height,ORANGE);
            
        }
        public void Reset(BasicEnemy[] enArr, int index)
        {
            //this sets them above the screen for while they are dead so that when they respawn they can simply begin moving down again
            enArr[index].enYPos = -100;
            //sets the enemies condition to dead
            enArr[index].isAlive = false; 
        }
        public void LossCheck(Player player, BasicEnemy[] enArr)
        {
            for (int i = 0; i < enArr.Length; i++)
            {
                //this checks if the enemy is officially at the same height as the player(meaning they are lined up) at this point the player removing the enemy is impossible so game ends
                if (enArr[i].enYPos >= player.posY) 
                {
                    player.state = State.End;
                }
            }
            
        }
        #endregion
    }
}
