/*******************************************************************************************
*
*   raylib [core] example - Basic window
*
*   Welcome to raylib!
*
*   To test examples, just press F6 and execute raylib_compile_execute script
*   Note that compiled executable is placed in the same folder as .c file
*
*   You can find all basic examples on C:\raylib\raylib\examples folder or
*
*   Enjoy using raylib. :)
*
*   This example has been created using raylib-cs 3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   This example was lightly modified to provide additional 'using' directives to make
*   common math types and utilities readily available, though they are not using in this sample.
*
*   Copyright (c) 2019-2020 Academy of Interactive Entertainment (@aie_usa)
*   Copyright (c) 2013-2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using System;
using raygamecsharp;

namespace Examples
{
    public class core_basic_window
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 800;
            const int screenHeight = 450;

            InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");


            bool inputRelease = false;
            int frameCount = 0;
            Player player = new Player();
            player.posX = (screenWidth / 2)-100;
            player.posY = screenHeight - 50;
            //So I want space[0] to be the player's starting x subtracted by 2 of the player's size(hardcoded at 50), but I hope to remove the hard code so time to make an equation
            //TODO remove the hardcoded size
            for (int i = 0; i<player.space.Length; i++)
            {
                //For the left side of the course, maybe I want to remove the hard coded 3 in case I have a difficulty increase to change amount of lanes?
                if (i > ((player.space.Length-1)/2)) 
                {
                    player.space[i] = player.posX - (player.width*(((player.space.Length - 1) / 2) - (i+1)));
                }
                else //for the right side of the course
                {
                    player.space[i] = player.posX + (player.width * ((i+1)- ((player.space.Length - 1) / 2))); //first time i=3 it is simply the player's starting location which should be middle
                }

            }
            
            SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                frameCount++;
                if (frameCount == 10)
                {
                    inputRelease = true;
                }
                if (inputRelease)
                {
                    player.inputCount = 0;
                    inputRelease = false;
                    frameCount = 0;
                }
                player.TakeInput();
                player.Move();
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(BLACK);

                DrawText("Score Test", 300, 0, 15, MAROON);
                for (int i = 0; i < player.space.Length; i++)
                {
                    DrawLine(player.space[i],screenHeight, player.space[i], 0, DARKBLUE);
                    if(i == player.space.Length - 1)
                    {
                        DrawLine(player.space[i]+(player.width), screenHeight, player.space[i]+(player.width), 0, DARKBLUE);
                    }
                }
                DrawRectangle(player.posX, player.posY, player.width, player.height, RED);
                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}