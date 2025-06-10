using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    internal class Cupcake : Minion
    {

        private int _frosting;

        //Constructor
        public Cupcake(int health, int armour, int frosting) : base(health, armour)
        {
            if (frosting < 1 || frosting > 10)
                frosting = 5;
            _frosting = frosting;
        }

        public override void TakeDamage(int damage)
        {
            int reduction = _frosting / 2;
            int adjusted = damage - (_armour + reduction);
            if (adjusted < 0) adjusted = 0;
            _health -= adjusted;
        }

        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(1, _frosting + 2);
        }

        public int SugarRush()
        {
            Console.WriteLine("**SUGAR RUSH!**");
            Random rng = new Random();
            return rng.Next(10, 15) + _frosting;
        }

        public override string ToString()
        {
            return "Cupcake[" + base.ToString() + ", frosting: " + _frosting + "]";
        }
    }
}
