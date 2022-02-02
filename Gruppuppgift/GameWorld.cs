using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppuppgift
{
    class GameWorld
    {
        public static int Width { get; } = 26;
        public static int Height { get; } = 26;
        int score;
        List<GameObject> Games = new List<GameObject>();
        public void Update()
        {
            // TODO
            foreach (var game in Games)
            {
                Console.WriteLine(game);
            }
        }
    }
}
