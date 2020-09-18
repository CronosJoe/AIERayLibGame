using static Raylib_cs.Raylib;
using System.Numerics; 
using System;
using Raylib_cs;
using static Raylib_cs.Color;
namespace raygamecsharp
{
    public class Player
    {
        public int score = 0;
        //TODO add a high score from a txt
        public int posX = 0;
        public int posY = 0;
        public int width = 50;
        public int height = 50;
        public int[] space = new int[9];
        public int spot = 2; //idea of this is if going left it will get get -1, and if going right it will get +1, then it can access an array that will store the different positions the player can be in
        public int inputCount = 0;
        public bool pew = false;
        public int currentScore = 0;

        public void TakeInput()
        {
            if (IsKeyDown(KeyboardKey.KEY_A) || IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                if (inputCount == 0)
                {
                    inputCount++;
                    spot--;
                    if (spot < 0)
                    {
                        spot = 0;
                    }
                }

            }
            if (IsKeyDown(KeyboardKey.KEY_D) || IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                if (inputCount == 0)
                {
                    spot++;
                    inputCount++;
                    if (spot >= space.Length)
                    {
                        spot = space.Length - 1;
                    }
                }
            }
            if (IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                
                   if(inputCount == 0)
                {
                    Console.WriteLine("pew");
                    pew = true;
                    inputCount++;
                }

               
            }

        }
        public void Move()
        {
            posX = space[spot];
        }
        

    }
}
