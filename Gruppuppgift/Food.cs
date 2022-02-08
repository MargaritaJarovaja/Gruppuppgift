using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gruppuppgift
{
    /// <summary>
    /// Klass ärvt från abstrakt klass GameObject
    /// </summary>
    class Food :GameObject
    {
        public Position foodPos = new Position();
        Random rnd = new Random();
        GameWorld gameWorld = new GameWorld();

        /// <summary>
        /// Klasskonstruktorn skapar ett klassobjekt med en slumpmässig position
        /// </summary>
        public Food()
        {
           foodPos.x = rnd.Next(5, gameWorld.Width);
           foodPos.y = rnd.Next(5, gameWorld.Height);
        }

        /// <summary>
        /// Metoden som implementerar visualiseringen av objektet på spelplanen
        /// </summary>
        protected override void Update()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(foodPos.x, foodPos.y);
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// En metod som låter använda resultatet av smetoden Update();
        /// </summary>
        public void GetUpdates()
        {
            Update();
        }

        /// <summary>
        /// Metod som returnerar värdet för objektets position i fältet
        /// </summary>
        /// <returns></returns>
        public Position FoodLocation()
        {
            return foodPos;
        }

        /// <summary>
        /// Skapa nya objektpositionskoordinater på fältet
        /// </summary>
        public void FoodNewLocation()
        {
            foodPos.x = rnd.Next(5, gameWorld.Width);
            foodPos.y = rnd.Next(5, gameWorld.Height);
        }

    }
}
