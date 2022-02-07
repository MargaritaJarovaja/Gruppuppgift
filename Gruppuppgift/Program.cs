using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Gruppuppgift
{
    class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
        /// </summary>
        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

        static  void Menu()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            ConsoleKey consoleKey = new ConsoleKey();           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n\n\n\n\n\t\t\t\t\t\t\tCONSOL SNAKE C#");
            Console.ForegroundColor = ConsoleColor.White;            
            Console.WriteLine("\n\n\n\n\t\t\t\t\t\t- Press 1 to start game");           
            Console.WriteLine("\n\t\t\t\t\t\t- Press Esc to quit a game");
       
            keyInfo = Console.ReadKey(true);
            consoleKey = keyInfo.Key;

            switch (consoleKey)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                    
            }
        }

        //static void Loop()
        //{
        //    // Initialisera spelet
        //    //const int frameRate = 5;
        //    //int Width = 26;
        //    //int Height = 26;
        //    //GameWorld world = new GameWorld(Width, Height);
        //    //ConsoleRenderer renderer = new ConsoleRenderer(world);

        //    Player player = new Player();

        //    // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
        //    // ...

        //    // Huvudloopen
        //    bool running = true;
        //    while (running)
        //    {
        //        // Kom ihåg vad klockan var i början
        //        DateTime before = DateTime.Now;

        //        // Hantera knapptryckningar från användaren
        //        ConsoleKey key = ReadKeyIfExists();
        //        switch (key)
        //        {
        //            case ConsoleKey.Q:
        //                running = false;
        //                break;

        //            case ConsoleKey.W:
        //                running = true;
        //                break;


        //                // TODO Lägg till logik för andra knapptryckningar
        //                // ...
        //        }

                // Uppdatera världen och rendera om
               // world.Update();
               // renderer.Render();

                // Mät hur lång tid det tog
               // double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                //if (frameTime > 0)
                //{
                //    // Vänta rätt antal millisekunder innan loopens nästa varv
                //    Thread.Sleep((int)frameTime);
        //        //}
        //    }
        //}

        static void Main(string[] args)
        {

            bool finished = false;

            GameWorld game = new GameWorld();
            Player player = new Player();
            Food food = new Food();
           
            Menu();
            DateTime before = DateTime.Now;        

            while (!finished)
            {
                game.UpdateBoard();
                Console.SetCursorPosition(90, 5);
                Console.Write("SCORE: {0}", player.score);
                player.Input();
                food.GetUpdates();              
                player.GetUpdates();
                player.MoveSnake();
                player.Eat(food.FoodLocation(), food);                
                player.HitWall(game);
                if (finished)
                {
                    DateTime finish = DateTime.Now;
                    TimeSpan result = finish - before;
                    Console.WriteLine($"\n\t\t\t\t\t\tYour time is: {result.Hours} hours, {result.Minutes} minutes, {result.Seconds} seconds");
                  
                }
               
            }            
            //DateTime finish = DateTime.Now;
           // TimeSpan result = finish - before;
           // Console.WriteLine($"\n\t\t\t\t\t\tYour time is: {result.Hours} hours, {result.Minutes} minutes, {result.Seconds} seconds");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
