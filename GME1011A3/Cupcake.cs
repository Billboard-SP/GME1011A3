using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    internal class Cupcake : Minion
    {
        //Constructor
        public Cupcake(int health, int armor, int frosting) : base(health, armor)
        {
            if (frosting < 1 || frosting > 10)
                frosting = 5;
            _frosting = frosting;
        }
    }
}
