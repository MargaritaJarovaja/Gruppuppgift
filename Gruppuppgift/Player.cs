using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppuppgift
{
    class Player: GameObject
    {
        enum Riktning
        {
           Down,
           Up,
           Left,
           Right,
        }

        protected override void Update()
        {
            Console.WriteLine("Hejo!");
        }
    }

}
