using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppuppgift
{
    class GameWorld
    {
       public int Width { get; set; }
       public int Height { get; set; }

         public GameWorld()
         {
            Width = 100;
            Height = 30;
         }       
        
        List<GameObject> Games = new List<GameObject>();

        public void UpdateBoard()
        {
           for (int i = 0; i < Width; i++)
           {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("-");
           }

            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, Height);
                Console.WriteLine("-");
            }

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("|");
            }

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(Width, i);
                Console.WriteLine("|");
            }
            
        }
    }
}
