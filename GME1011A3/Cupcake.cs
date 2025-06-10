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

        public override void TakeDamage(int damage)
        {
            int reduction = _frosting / 2;
            int adjusted = damage - (_armor + reduction);
            if (adjusted < 0) adjusted = 0;
            _health -= adjusted;
        }

        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(1, _frosting + 2);
        }
    }
}
