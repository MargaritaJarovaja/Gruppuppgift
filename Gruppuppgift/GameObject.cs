using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppuppgift
{
    /// <summary>
    /// En abstrakt klass som definierar beteendet för alla klasser som ärvts från den
    /// </summary>
    abstract class GameObject
    {       
        Position position = new Position();
        //char appearance;
        public int x { get; set; }
        public int y { get; set; }

        protected abstract void Update();       
        
    }
}
