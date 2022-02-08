using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppuppgift
{
    class Position
    {
        /// <summary>
        /// Konstruktör för att skapa ett klassobjekt
        /// </summary>
        public Position()
        {

        }
        public int x { get; set; }
        public int y { get; set; }

        /// <summary>
        /// Konstruktör för att skapa ett klassobjekt med inkommande argument
        /// </summary>
        /// <param name="x">X-koordinat</param>
        /// <param name="y">Y-koordinat</param>
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
