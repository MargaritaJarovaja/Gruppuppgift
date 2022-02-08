using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

//Programmet implementerar följande:
//skapande av spelplansobjektet och dess visualisering,
//skapa ett ormobjekt som rör sig i en användarspecificerad riktning, 
//hamnar i en position med ett matobjekt, äter upp det, får en poäng för det och ökar i storlek.
//När du träffar väggen på planen tar spelet slut. 
//I början av spelet dyker en liten meny upp med möjlighet att spela och avsluta programmet. 
//Under spelets gång syns poängen som användaren tjänar på planen. 
//Efter att ha förlorat informeras användaren om att spelet är över 
//och det totala antalet poäng för spelet, varefter programmet stänger.
//Visualiseringen av vart och ett av objekten sker i motsvarande klass och inte i en separat klass.
//Programmet fungerar en gång tills användaren lämnar spelplanen, det finns inga begränsningar
//för poäng i spelet.

namespace Gruppuppgift
{
    class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
        /// </summary>
        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

        /// <summary>
        /// En metod som erbjuder användaren en alternativ handling.
        /// </summary>
        static void Menu()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            ConsoleKey consoleKey = new ConsoleKey();           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n\n\n\n\n\t\t\t\t\t\t\tCONSOL SNAKE C#");
            Console.ForegroundColor = ConsoleColor.White;            
            Console.WriteLine("\n\n\n\n\t\t\t\t\t\t- Press 1 to start game");           
            Console.WriteLine("\n\t\t\t\t\t\t- Press Esc to quit a game");
            Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\tW - to go UP");
            Console.WriteLine("\n\t\t\t\t\t\t\tS - to go DOWN");
            Console.WriteLine("\n\t\t\t\t\t\t\tD - to go RIGHT");
            Console.WriteLine("\n\t\t\t\t\t\t\tA - to go LEFT");

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

        static void Loop()
        {
            bool finished = false;
            const int frameRate = 5;
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
            double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
            if (frameTime > 0)
            {
                // Vänta rätt antal millisekunder innan loopens nästa varv
                Thread.Sleep((int)frameTime);
            }
            Console.ReadKey();
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            Loop();           
        }
    }
}
