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
using System.IO;
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
            #region loadHighScore
            string path = @"HighScore.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Current HighScore: 0");
                }
            }
            int highScore = 0;
            string highScoreString;
            //this will open the file and assign the high score to the string
            using (StreamReader sr = File.OpenText(path))
            {
                
                highScoreString = sr.ReadLine();
                string[] score = highScoreString.Split(' ');
                highScore = TextToInteger(score[2]);
            }
                #endregion

                bool inputRelease = false;
            int spawnCounter = 0;
            bool spawnLock = false;
            int frameCount = 0;
            Player player = new Player();
            Random rand = new Random();
            player.posX = (screenWidth / 2)-100;
            player.posY = screenHeight - 50;
            player.currentScore = 0;
            //So I want space[0] to be the player's starting x subtracted by 2 of the player's size(hardcoded at 50), but I hope to remove the hard code so time to make an equation
            
            for (int i = 0; i<player.space.Length; i++)
            {
                //For the left side of the course
                if (i > ((player.space.Length-1)/2)) 
                {
                    player.space[i] = player.posX - (player.width*(((player.space.Length - 1) / 2) - (i+1)));
                }
                else //for the right side of the course
                {
                    player.space[i] = player.posX + (player.width * ((i+1)- ((player.space.Length - 1) / 2))); //first time i=3 it is simply the player's starting location which should be middle
                }

            }
            //enemy setup
            BasicEnemy[] enemyArr = new BasicEnemy[player.space.Length];
            for (int i = 0; i<enemyArr.Length; i++)
            {
               
                BasicEnemy tempname = new BasicEnemy("ID#: " + i, player.width, player.height, 0);
                //the enemy spot will be determined when they are spawned, and so will they isAlive value
                enemyArr[i] = tempname;
                
            }
            //special enemy setup
            SpecialEnemy[] specEnArr = new SpecialEnemy[5];
            for(int i =0; i<specEnArr.Length; i++)
            {
                int randINT = rand.Next(1, 3);
                if (randINT == 1)
                {
                    SpecialEnemy tempname = new SpecialEnemy("ID " + i, player.width,player.height,0,rand.Next(1,3)); //first constructor hidden enemy
                    specEnArr[i] = tempname;
                }
                else
                {
                    int boolDet = rand.Next(1, 3);
                    bool tempBool;
                    if(boolDet == 1)
                    {
                        tempBool = true;
                    }
                    else
                    {
                        tempBool = false;
                    }
                    SpecialEnemy tempname = new SpecialEnemy("ID " + i, player.width,player.height,0,tempBool); //creates a shown typed enemy through second constructor
                    specEnArr[i] = tempname;
                }
            }
            //projectile setup
            Projectile[] bullets = new Projectile[(player.space.Length-1)/4];
            for(int i = 0; i<bullets.Length; i++)
            {
                Projectile tempname = new Projectile();
                tempname.name = "ID#: " + i;
                tempname.width = player.width/2;
                tempname.height = player.height/2;
                tempname.spot.X = player.space[0]-(player.height*2);
                tempname.spot.Y = (screenHeight / 2) + (i*player.height);
                tempname.shotSpeed = screenHeight / 32;
                tempname.xPos = (int)tempname.spot.X;
                tempname.yPos = (int)tempname.spot.Y;
                tempname.fired = false; /* this is to make sure my bullets start in their side position */
                bullets[i] = tempname;
               
            }
            SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                BeginDrawing();
                ClearBackground(BLACK);
                switch (player.state) {
                    case State.Game:

                        // Update
                        //----------------------------------------------------------------------------------
                        #region timer
                        frameCount++;
                            if (frameCount == 10)
                            {
                                inputRelease = true;

                            }
                            if (inputRelease)
                            {
                                player.inputCount = 0;
                                player.pew = false;
                                inputRelease = false;
                                frameCount = 0;
                            }
                            spawnCounter++;
                            if (spawnCounter == 30)
                            {
                                spawnLock = false;
                            }
                            if (!spawnLock)
                            {
                                spawnCounter = 0;
                            }
                        #endregion
                        player.TakeInput();
                            if (player.pew) // fires the bullet should only fire 1
                            {
                                bullets[0].Fired(bullets, player);
                                player.pew = false;
                            }
                            bullets[0].MoveBullet(bullets);//if the bullet has been fired this will move them up the stage till they leave bounds or collide
                            bullets[0].OutOfBounds(bullets); //checks if a bullet leaves area of play in which case it will reload
                            CollisionCheck(bullets, enemyArr, player);
                            SpecCollisionCheck(bullets, specEnArr, player);
                            player.Move();
                            enemyArr[0].MoveEnemy(enemyArr); //moves the basic enemies
                            specEnArr[0].MoveEnemy(specEnArr); //moves the traited enemies
                       
                            enemyArr[0].LossCheck(player, enemyArr); //this should switch the state to State.End if the enemy reaches player pos
                            specEnArr[0].LossCheck(player, specEnArr); //if the traited enemy passes the player this will also switch to State.End
                            for (int i = 0; i < enemyArr.Length; i++)
                            {
                                if (!enemyArr[i].isAlive && !spawnLock)
                                {
                                //basic enemy part
                                    int b = rand.Next(player.space.Length - 1);
                                    enemyArr[i].enemySpot = player.space[b];
                                    enemyArr[i].isAlive = true;

                                //special enemy part
                                int c = rand.Next(player.space.Length - 1);
                                bool tempBoolLock = true;
                                for(int j = 0; j<specEnArr.Length; j++)
                                {
                                    if(!specEnArr[j].isAlive && tempBoolLock)
                                    {
                                        specEnArr[j].enemySpot = player.space[c];
                                        specEnArr[j].isAlive = true;
                                        tempBoolLock = false;
                                    }
                                }
                                    spawnLock = true;
                                }
                            }
                        
                            //----------------------------------------------------------------------------------

                            // where I want to put all my drawings for case 1
                            //----------------------------------------------------------------------------------
                           
                            DrawText($"Score: {player.currentScore}", 300, 0, 20, MAROON);
                            DrawText(highScoreString, 400, 0, 20, MAROON);
                        player.DrawStage(player); //board setup
                            //drawing my forever changing ammo
                            for (int i = 0; i < bullets.Length; i++)
                            {
                                bullets[i].DrawBullet(bullets[i]);
                            }
                            DrawText("Ammo", (int)bullets[0].spot.X, (int)bullets[0].spot.Y - 50, 15, MAROON);
                            DrawRectangle(player.posX, player.posY, player.width, player.height, RED); //player

                            for (int i = 0; i < enemyArr.Length; i++) //enemies
                            {
                                if (enemyArr[i].isAlive)
                                {

                                    enemyArr[i].DrawEnemy(enemyArr[i]);
                                    DrawRectangleLines(enemyArr[i].enemySpot, enemyArr[i].enYPos, enemyArr[i].width, enemyArr[i].height, GREEN);
                                }
                            }
                            for(int i = 0; i < specEnArr.Length; i++)
                            {
                                if (specEnArr[i].isAlive)
                                {
                                specEnArr[i].DrawEnemy(specEnArr[i]);
                                DrawRectangleLines(specEnArr[i].enemySpot, specEnArr[i].enYPos, specEnArr[i].width, specEnArr[i].height, GOLD);
                                }
                            }
                        break;
                    case State.End:
                        if (player.currentScore > highScore)
                        {
                            highScore = player.currentScore;
                            highScoreString = $"Current HighScore: {highScore}";
                            //Should overwrite the current text file?
                            using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine(highScoreString);
                            }
                        }
                        DrawText($"Game Over, Your score was {player.currentScore}", screenWidth/8, screenHeight/2, 25, MAROON);
                        DrawText(highScoreString, screenWidth/8, screenHeight/2+100, 25, MAROON);
                        break;
                
                       
                }
                EndDrawing();




                //----------------------------------------------------------------------------------
            } //end of main game loop

            // De-Initialization
            //--------------------------------------------------------------------------------------
            CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }//end of main

        public static void CollisionCheck(Projectile[] bullets, BasicEnemy[] enArr, Player player)
        {
            for(int i=0; i < enArr.Length; i++)
            {
                for(int j = 0; j < bullets.Length; j++)
                {
                    if ((bullets[j].fired && enArr[i].isAlive) &&(bullets[j].xPos == enArr[i].enemySpot))
                    {
                        if (bullets[j].yPos <= enArr[i].enYPos + enArr[i].height)
                        {
                            bullets[j].ResetPos(bullets, j);
                            enArr[i].Reset(enArr, i);
                            player.currentScore++;
                        }
                    }
                }
            }
        }// end of the basic enemy porjectile collision
        public static void SpecCollisionCheck(Projectile[] bullets, SpecialEnemy[] enArr, Player player) //the check and parameters are almost the same minus the enemy type
        {
            for (int i = 0; i < enArr.Length; i++)
            {
                for (int j = 0; j < bullets.Length; j++)
                {
                    if ((bullets[j].fired && enArr[i].isAlive) && (bullets[j].xPos == enArr[i].enemySpot))
                    {
                        if (bullets[j].yPos <= enArr[i].enYPos + enArr[i].height)
                        {
                            bullets[j].ResetPos(bullets, j);
                            enArr[i].Reset(enArr, i);
                            player.currentScore++;
                        }
                    }
                }
            }
        }
    }
}