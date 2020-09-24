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
        
        public SpecialEnemy(string iD, int width, int height, int enYPos, int type) : base(iD, width, height, enYPos) //this will create a typed enemy
        {
            this.ID = iD;
            this.width = width;
            this.height = height;
            this.enYPos = enYPos;
            this.type = type;
            
        }

        public SpecialEnemy(string iD, int width, int height, int enYPos, bool slowFast) : base(iD, width, height, enYPos) //this specifically makes a slow/fast enemy, which are more or less basic enemies
        {
            this.ID = iD;
            this.width = width;
            this.height = height;
            this.enYPos = enYPos;
            if (slowFast)
            {

            }
            
        }

        public void DrawEnemy(SpecialEnemy specEn)
        {
            DrawRectangle(specEn.enemySpot, specEn.enYPos, specEn.width, specEn.height, specEn.col);
        }
    }
}
