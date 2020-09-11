using System;
namespace raygamecsharp
{
    public class BasicEnemy
    {
        public int speed = 30; //This is how fast the enemy will move down the stage
        public string ID;
        public int damage = 1; //This will be how much damage the player takes
        public int width = 0; //these are default values because the stage will be set by the player's size
        public int height = 0;
        public bool isAlive = false;
        public int enemySpot;
        public int enYPos;

        public void MoveEnemy(BasicEnemy enemy)
        {
            enemy.enYPos -= enemy.speed;
        }

    }
}
