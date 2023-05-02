using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            while (counter < n)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();
                BaseHero hero;
                if (heroType == "Druid")
                {
                    hero = new Druid(name);
                    heroes.Add(hero);
                    counter++;
                }
                else if (heroType == "Paladin")
                {
                    hero = new Paladin(name);
                    heroes.Add(hero);
                    counter++;
                }
                else if (heroType == "Rogue")
                {
                    hero = new Rogue(name);
                    heroes.Add(hero);
                    counter++;
                }
                else if (heroType == "Warrior")
                {
                    hero = new Warrior(name);
                    heroes.Add(hero);
                    counter++;
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }


            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int sum = heroes.Sum(x => x.Power);
            if (sum >= bossPower)
            {
                Console.WriteLine("Victory!");
                return;
            }
            Console.WriteLine("Defeat...");

        }
    }
}
