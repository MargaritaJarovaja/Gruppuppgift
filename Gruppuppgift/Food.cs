using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gruppuppgift
{
    class Food:GameObject
    {
        public Position foodPos = new Position();
        Random rnd = new Random();
        GameWorld gameWorld = new GameWorld();

        public Food()
        {
           foodPos.x = rnd.Next(5, gameWorld.Width);
           foodPos.y = rnd.Next(5, gameWorld.Height);
        }
        
        protected override void Update()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(foodPos.x, foodPos.y);
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void GetUpdates()
        {
            Update();
        }

        protected override void ConsoleRender()
        {
            Console.SetCursorPosition(foodPos.x, foodPos.y);
            Console.Write(" ");
        }
        
        public Position FoodLocation()
        {
            return foodPos;
        }

        public void FoodNewLocation()
        {
            foodPos.x = rnd.Next(5, gameWorld.Width);
            foodPos.y = rnd.Next(5, gameWorld.Height);
        }

    }
}
