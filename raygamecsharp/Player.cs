using static Raylib_cs.Raylib;
using System.Numerics; 
using System;
using Raylib_cs;
namespace raygamecsharp
{
    public class Player
    {
        public int score = 0;
        //TODO add a high score from a txt
        public int speed = 10;
        public int jumpHeight;
        public bool touchingGround = true;
        public bool jump = false;

        public bool checkJump()
        {
            bool check = false;
            //this will check if any of the three basic upward inputs are used
            if (IsKeyDown(KeyboardKey.KEY_W) || IsKeyDown(KeyboardKey.KEY_UP) || IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                check = true;
                
            }
            return check;
        }
        public void Jump()
        {
            //TODO inplement jumping, figure out how to go down without freezing the game
        }
    }
}
