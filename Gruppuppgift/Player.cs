using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gruppuppgift
{
    class Player: GameObject
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'w';
        char dir = 'u';

        public List<Position> snakeBody { get; set; }

        public int x { get; set; }
        public int y { get; set; }
        public int score { get; set; }

        public Player()
        {
            x = 20;
            y = 20;
            score = 0;

            Console.CursorVisible = false;

            snakeBody = new List<Position>();

            snakeBody.Add(new Position(x, y));
        }


              

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
                HitWall(gameWorld);               
            }
         
        }

        public void GetUpdates()
        {
            Update();
        }

        //protected override void ConsoleRender()
        //{
        //    foreach (Position pos in snakeBody)
        //    {
        //        Console.SetCursorPosition(pos.x, pos.y);
        //        Console.Write("H");
        //    }

        //}

        //public void GetConsoleRender()
        //{
        //    ConsoleRender();
        //}

        public void Input()
        {
            if (Console.KeyAvailable == true)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

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
            snakeBody.RemoveAt(0);            
            Thread.Sleep(100);            
            Console.Clear();
        }

        public void Eat(Position food, Food f)
        {
            Position head = snakeBody[snakeBody.Count - 1];
            if (head.x == food.x && head.y == food.y)
            {
                snakeBody.Add(new Position(x, y));
                f.FoodNewLocation();
                score++;
            }
        }

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
