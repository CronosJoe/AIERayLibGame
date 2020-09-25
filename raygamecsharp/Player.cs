using static Raylib_cs.Raylib;
using System.Numerics; 
using System;
using Raylib_cs;
using static Raylib_cs.Color;
namespace raygamecsharp
{
    //game state set up
    enum State
    {
        Game,
        End,
        Start
    }
    public class Player
    {
        public Enum state = State.Start;
      
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
                //left movement!
                if (inputCount == 0)
                {
                    inputCount++;
                    spot--; //using spots to find which lane the player will be in.
                    if (spot < 0)
                    {
                        spot = 0;
                    }
                }

            }
            if (IsKeyDown(KeyboardKey.KEY_D) || IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                //right movement!
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
                //this is the shoot command
                //this can only activate if the player isn't moving
                   if(inputCount == 0)
                {
                    pew = true;
                    inputCount++;
                }

               
            }

        }
        public void Move()
        {
            //simply sets the player's position to their x spot so that they are always in a lane
            posX = space[spot];
        }
        public void DrawStage(Player player)
        {
            for (int i = 0; i < player.space.Length; i++) //Board setup, copy and pasted over from main to clean up main so it has player.space instead of just space
            {
                DrawLine(player.space[i], GetScreenHeight(), player.space[i], 0, DARKBLUE);
                if (i == player.space.Length - 1)
                {
                    DrawLine(player.space[i] + (player.width), GetScreenHeight(), player.space[i] + (player.width), 0, DARKBLUE);
                }
            }
        }
        
        

    }
}
