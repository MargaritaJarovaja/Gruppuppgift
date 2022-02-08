using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gruppuppgift
{
    /// <summary>
    /// Klass ärvt från abstrakt klass GameObject
    /// </summary>
    class Player : GameObject
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'w'; //variabel för nedtryckt knapp
        char dir = 'u'; //variabel för riktning

        public List<Position> snakeBody { get; set; } //lista över alla ormkroppsdelar

        public int x { get; set; }
        public int y { get; set; }
        public int score { get; set; }

        /// <summary>
        /// Klasskonstruktör
        /// </summary>
        public Player()
        {
            x = 20;
            y = 20;
            score = 0;

            Console.CursorVisible = false;

            snakeBody = new List<Position>();

            snakeBody.Add(new Position(x, y));
        }

        /// <summary>
        /// Metoden som implementerar visualiseringen av objektet på spelplanen
        /// </summary>
        protected override void Update()
        {
            foreach (Position pos in snakeBody)
            {
                Position head = snakeBody[snakeBody.Count - 1];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(pos.x, pos.y);
                Console.Write("■");
                Console.ForegroundColor = ConsoleColor.White;
                GameWorld gameWorld = new GameWorld();                             
            }
         
        }

        /// <summary>
        /// En metod som låter använda resultatet av smetoden Update();
        /// </summary>
        public void GetUpdates()
        {
            Update();
        }

        /// <summary>
        /// Metod för att acceptera information som angetts av användaren
        /// </summary>
        public void Input()
        {
            if (Console.KeyAvailable == true)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        /// <summary>
        /// Bestämning av ormens rörelseriktning baserat på knappen som
        /// användaren trycker på
        /// </summary>
        public void Direction()
        {
            if (key == 'w' && dir != 'd')
            {
                dir = 'u';
            }
            else if (key == 's' && dir != 'u')
            {
                dir = 'd';
            }
            else if (key == 'd' && dir != 'l')
            {
                dir = 'r';
            }
            else if (key == 'a' && dir != 'r')
            {
                dir = 'l';
            }
        }

        /// <summary>
        /// Implementering av rörelse i en given riktning
        /// </summary>
        public void MoveSnake()
        {
            Direction();

            if (dir == 'u')
            {
                y--;
            }
            else if (dir == 'd')
            {
                y++;
            }
            else if (dir == 'r')
            {
                x++;
            }
            else if (dir == 'l')
            {
                x--;
            }

            snakeBody.Add(new Position(x, y));
            snakeBody.RemoveAt(0);      //Ta bort positionen som ormens kropp har lämnat      
            Thread.Sleep(100);            
            Console.Clear();
        }

        /// <summary>
        /// En metod som avgör om ormens och food positioner på spelplanen matchar, 
        /// och i så fall tas objekt food bort och ett nytt skapas på en annan plats
        /// </summary>
        /// <param name="food"> food objektets position på fältet</param>
        /// <param name="f">food objektet</param>
        public void Eat(Position food, Food f)
        {
            Position head = snakeBody[snakeBody.Count - 1];
            if (head.x == food.x && head.y == food.y)
            {
                snakeBody.Add(new Position(x, y));
                f.FoodNewLocation();
                score++;    //Lägga till poäng för det uppätna objektet food
            }
        }

        /// <summary>
        /// Metoden som kontrollerar om ormen har gått utanför spelplanen.
        /// Metoden avslutar även spelet om ormens position sammanfaller 
        /// med plangränsens koordinater.
        /// </summary>
        /// <param name="gameWorld">spelimplementeringsobjekt</param>
        public void HitWall(GameWorld gameWorld)
        {            
            Position head = snakeBody[snakeBody.Count - 1];
            if (head.x >= gameWorld.Width || head.x <= 0 || head.y >= gameWorld.Height || head.y <= 0)
            {                
                Console.ForegroundColor = ConsoleColor.Red;              
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\tGame over!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n\n\n\t\t\t\t\t\tYour SCORE is: {0} !", score);                
                Console.ReadKey();
                Environment.Exit(0);
            }
        }  

    }

}
