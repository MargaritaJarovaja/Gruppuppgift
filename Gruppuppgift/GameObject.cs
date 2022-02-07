using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppuppgift
{
    abstract class GameObject
    {
        // TODO
        Position position = new Position();
        //char appearance;
        

        protected abstract void Update();

        //protected abstract void ConsoleRender();
        
    }
}
