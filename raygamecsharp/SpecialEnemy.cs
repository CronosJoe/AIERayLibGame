using System;
using Raylib_cs;
using static Raylib_cs.Color;
using static Raylib_cs.Raylib;
namespace raygamecsharp
{
    public class SpecialEnemy : BasicEnemy
    {
        public Color col;

        public void DrawEnemy(SpecialEnemy specEn)
        {
            DrawRectangle(specEn.enemySpot, specEn.enYPos, specEn.width, specEn.height, specEn.col);
        }
    }
}
