﻿using System;
using Raylib_cs;
using static Raylib_cs.Color;
using static Raylib_cs.Raylib;
namespace raygamecsharp
{
    public class BasicEnemy
    {
        #region variables
        public int speed = 1; //This is how fast the enemy will move down the stage
        public string ID;
        public int width = 0; //these are default values because the stage will be set by the player's size
        public int height = 0;
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
            enArr[index].enYPos = -100;
            enArr[index].isAlive = false;
        }
        public void LossCheck(Player player, BasicEnemy[] enArr)
        {
            for (int i = 0; i < enArr.Length; i++)
            {
                if (enArr[i].enYPos >= player.posY)
                {
                    Console.WriteLine("State should change here");
                    player.state = State.End;
                }
            }
            
        }
        #endregion
    }
}
