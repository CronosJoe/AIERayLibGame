using System;
using Raylib_cs;
using static Raylib_cs.Color;
using static Raylib_cs.Raylib;
namespace raygamecsharp
{
    public class BasicEnemy
    {
        public int speed = 1; //This is how fast the enemy will move down the stage
        public string ID;
        public int damage = 1; //This will be how much damage the player takes
        public int width = 0; //these are default values because the stage will be set by the player's size
        public int height = 0;
        public bool isAlive = false;
        public int enemySpot;
        public int enYPos;

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

    }
}
