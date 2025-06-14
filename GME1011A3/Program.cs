﻿using System.Collections.Generic;

namespace GME1011A3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Epic battle goes here :)
            Random rng = new Random();

            Console.Write("Enter hero Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter hero health (1 - 100); ");
            int health = int.Parse(Console.ReadLine());

            Console.Write("Enter hero strength (1 - 10): ");
            int strength = int.Parse(Console.ReadLine());

            Fighter hero = new Fighter(health, name, strength); //TODO: Get these arguments from the user - health, name, strength

            Console.Write("Enter number of baddies: ");
            int numBaddies = int.Parse(Console.ReadLine()); //TODO: Get number of baddies from the user
            int numAliveBaddies = numBaddies;


            //TODO: change this so that it can contain goblins and skellies! Just change the type of the list!!

            List<Minion> baddies = new List<Minion>(); // goblin => minion



            for (int i = 0; i < numBaddies; i++)
            {


                //TODO: each baddie should have 50% chance of being a goblin, 50% chance of
                //being a skellie. A skellie should have random health between 25 and 30, and 0 armour (remember
                //skellie armour is 0 anyway)
                double roll = rng.NextDouble();

                if (roll < 0.33)
                {
                    // Goblin: 33%
                    baddies.Add(new Goblin(rng.Next(30, 36), rng.Next(1, 6), rng.Next(1, 11)));
                }
                else if (roll < 0.66)
                {
                    // Skellie: 33%
                    baddies.Add(new Skellie(rng.Next(25, 31), 0));
                }
                else
                {
                    // Cupcake: 33%
                    baddies.Add(new Cupcake(rng.Next(20, 26), rng.Next(0, 3), rng.Next(1, 5)));
                }
            }

            //this should work even after you make the changes above
            Console.WriteLine("Here are the baddies!!!");
            for(int i = 0; i < baddies.Count; i++)
            {
                Console.WriteLine(baddies[i]);
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Let the EPIC battle begin!!!");
            Console.WriteLine("----------------------------");


            //loop runs as long as there are baddies still alive and the hero is still alive!!
            while (numAliveBaddies > 0 && !hero.isDead())
            {
                //figure out which enemy we are going to battle - the first one that isn't dead
                int indexOfEnemy = 0;
                while (baddies[indexOfEnemy].isDead())
                {
                    indexOfEnemy++;
                }

                //hero deals damage first
                Console.WriteLine(hero.GetName() + " is attacking enemy #" + (indexOfEnemy+1) + " of " + numBaddies + ". Eek, it's a " + baddies[indexOfEnemy].GetType().Name);
                int heroDamage = 0;

                if (hero is Fighter fighter)
                {
                    if (rng.NextDouble() < 0.33)  // 33% chance to use special
                    {
                        heroDamage = fighter.Berserk();
                        Console.WriteLine("Fighter uses BERSERK! Massive damage incoming!");
                    }
                    else
                    {
                        heroDamage = fighter.DealDamage();
                    }
                }
                else
                {
                    heroDamage = hero.DealDamage();
                }

                Console.WriteLine("Hero deals " + heroDamage + " heroic damage.");
                baddies[indexOfEnemy].TakeDamage(heroDamage); //baddie takes the damage




                //TODO: The hero doesn't ever use their special attack - but they should. Change the above to 
                //have a 33% chance that the hero uses their special, and 67% that they use their regular attack.
                //If the hero doesn't have enough special power to use their special attack, they do their regular 
                //attack instead - but make a note of it in the output. There's no way for the hero to get more special
                //power points, but if you want to craft a way for that to happen, that's fine.




                //NOTE to coders - armour affects how much damage goblins take, and skellies take
                //half damage - remember that when reviewing the output

                //did we vanquish the baddie we were battling?
                if (baddies[indexOfEnemy].isDead())
                {
                    numAliveBaddies--; //one less baddie to worry about.
                    Console.WriteLine("Enemy #" + (indexOfEnemy+1) + " has been dispatched to void.");
                }
                else //baddie survived, now attacks the hero
                {
                    int baddieDamage;
                    if (rng.NextDouble() < 0.33)
                    {
                        if (baddies[indexOfEnemy] is Goblin goblin)
                        {
                            baddieDamage = goblin.GoblinBite();
                            Console.WriteLine($"Enemy #{indexOfEnemy + 1} used Goblin Bite!");
                        }
                        else if (baddies[indexOfEnemy] is Skellie skellie)
                        {
                            baddieDamage = skellie.SkellieRattle();
                            Console.WriteLine($"Enemy #{indexOfEnemy + 1} used Skellie Rattle!");
                        }
                        else
                        {
                            baddieDamage = baddies[indexOfEnemy].DealDamage();
                        }
                    }
                    else
                    {
                        baddieDamage = baddies[indexOfEnemy].DealDamage();
                    }
                    Console.WriteLine("Enemy #" + (indexOfEnemy+1) + " deals " + baddieDamage + " damage!");
                    hero.TakeDamage(baddieDamage); //hero takes damage




                    //TODO: The baddie doesn't ever use their special attack - but they should. Change the above to 
                    //have a 33% chance that the baddie uses their special, and 67% that they use their regular attack.
                    



                    //let's look in on our hero.
                    Console.WriteLine(hero.GetName() + " has " + hero.GetHealth() + " health remaining.");
                    if (hero.isDead()) //did the hero die
                    {
                        Console.WriteLine(hero.GetName() + " has died. All hope is lost.");
                    }

                }
                Console.WriteLine("-----------------------------------------");
            }
            //if we made it this far, the hero is victorious! (that's what the message says.
            if(!hero.isDead())
                Console.WriteLine("\nAll enemies have been dispatched!! " + hero.GetName() + " is victorious!");
        }

    }
}